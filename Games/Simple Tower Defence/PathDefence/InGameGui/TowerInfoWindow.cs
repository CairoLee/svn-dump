using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using PathDefence.Screens;
using TomShane.Neoforce.Controls;
using TowerInterface;
using EventArgs = TomShane.Neoforce.Controls.EventArgs;

namespace PathDefence.InGameGui
{
    public class TowerInfoWindow : TowerBaseInfoWindow
    {
        private const int DesiredHeight = 265;
        private new const int DesiredWidth = 335;
        private readonly List<Button> Buttons = new List<Button>();
        private readonly PathDefenceGame CurrGame;

        private readonly Dictionary<string, Label> CustomLabels = new Dictionary<string, Label>();
        private readonly GamePlayScreen GamePlayScreen;

        public int DesiredLeft;
        public int DesiredTop;
        private GroupBox infoBox;
        private int lastWidth;
        private GroupBox UpgradeBox;

        public TowerInfoWindow(Manager manager, PathDefenceGame game, GamePlayScreen gamePlayScreen)
            : base(manager)
        {
            CurrGame = game;
            GamePlayScreen = gamePlayScreen;
        }

        public ITower Tower { get; set; }

        public override void Init(bool damage, bool range, bool interval)
        {
            base.Init(damage, range, interval);
            Height = DesiredHeight;
            Width = DesiredWidth;
            lblDescription.Visible = false;
            Passive = false;

            if ((DesiredLeft + DesiredWidth < CurrGame.CreepFieldWidth) || (DesiredLeft - DesiredWidth) < 0)
            {
                Left = DesiredLeft;
            }
            else
            {
                Left = DesiredLeft - DesiredWidth;
            }

            if (DesiredTop + DesiredHeight < CurrGame.CreepFieldHeight)
            {
                Top = DesiredTop;
            }
            else
            {
                Top = DesiredTop - DesiredHeight;
            }


            infoBox = new GroupBox(Manager);
            infoBox.Init();
            Add(infoBox);
            infoBox.Left = 2;
            infoBox.Top = 2;
            infoBox.Width = infoBox.Parent.Width - 4;
            infoBox.Height = 160;
            infoBox.Text = "Eigenschaften";
            infoBox.TextColor = Microsoft.Xna.Framework.Color.LightGray;

            InitializeControls(infoBox, 14);
            InitializeCustomLabels();
            UpdateTowerInformation();

            var sellButton = new Button(Manager);
            sellButton.Init();
            infoBox.Add(sellButton);
            sellButton.Text = "Verkaufen";
            sellButton.ToolTip = new ToolTip(Manager) { Text = "Verkaufpreis: Preis * 75%" };
            sellButton.Left = 220;
            sellButton.Top = 14;
            sellButton.Width = sellButton.Parent.Width - sellButton.Left - 5;
            sellButton.Click += delegate
                                    {
                                        Tower.Sell();
                                        Close();
                                    };

            InitializeUpgradeButtons();

            Closing += TowerInfoWindow_Closing;
            CloseButtonVisible = true;
            Passive = false;
            Resizable = false;
            Movable = true;
            GamePlayScreen.MoneyManager.MoneyChanged += MoneyManager_MoneyChanged;
        }

        private void MoneyManager_MoneyChanged(double money)
        {
            if (Visible)
            {
                foreach (Button button in Buttons)
                {
                    button.Enabled = money >= Tower.PossibleUpgrades[(string)button.Tag].Price;
                }
            }
        }

        private void InitializeCustomLabels()
        {
            int lastTop = lblPrice.Top + lblPrice.Height;
            foreach (IShowableProperty property in Tower.CustomProperties)
            {
                var label = new Label(Manager);
                label.Init();
                label.Parent = infoBox;
                label.Left = 4;
                label.Top = lastTop + 2;
                label.Width = label.Parent.Width - 2;
                label.Tag = property.Name;
                label.Passive = false;
                label.ToolTip = new ToolTip(Manager) { Visible = true, Text = property.Hint };
                if (!CustomLabels.ContainsKey(property.PropertyName))
                {
                    CustomLabels.Add(property.PropertyName, label);
                }
                else
                {
					/*
                    LogFramework.AddLog(string.Format(
                                             "Turm \"{0}\" hat einen Fehler in den Customlabels, Key \"{1}\" existiert doppelt!",
                                             Tower.Name, property.PropertyName),false,LogType.Error);
					*/
                }

                lastTop = label.Top + label.Height;
            }
        }

        private void InitializeUpgradeButtons()
        {
            Remove(UpgradeBox);
            UpgradeBox = new GroupBox(Manager);
            Add(UpgradeBox);

            UpgradeBox.Init();
            UpgradeBox.Left = 2;
            UpgradeBox.Top = infoBox.Top + infoBox.Height + 2;
            UpgradeBox.Width = UpgradeBox.Parent.Width - 4;
            UpgradeBox.Height = UpgradeBox.Parent.Height - UpgradeBox.Top - 2;
            UpgradeBox.Text = "Upgrades";
            UpgradeBox.TextColor = Microsoft.Xna.Framework.Color.LightGray;

            UpgradeBox.AutoScroll = false;
            foreach (Button button in Buttons)
            {
                UpgradeBox.Remove(button);
                Remove(button);
                button.Visible = false;
                button.Invalidate();
            }
            Buttons.Clear();
            lastWidth = 0;

            SpriteFont cFont = Skin.Layers[0].Text.Font.Resource;
            UpgradeBox.Enabled = Tower.PossibleUpgrades.Count > 0;
            foreach (var upgrade in Tower.PossibleUpgrades)
            {
                var button = new Button(Manager);
                button.Init();
                UpgradeBox.Add(button);
                Buttons.Add(button);
                button.Text = upgrade.Value.Name;
                button.Width = (int)cFont.MeasureString(button.Text).X + 15;
                button.Left = 6 + lastWidth;
                button.Top = 14;
                button.Tag = upgrade.Value.Key;
                button.Enabled = GamePlayScreen.MoneyManager.Money >= upgrade.Value.Price;
                button.Click += button_Click;
                button.ToolTip = new ToolTip(Manager)
                                     {
                                         Text = string.Format("Neuer Wert: {0}\nPreis: {1}", upgrade.Value.Value,
                                                              upgrade.Value.Price)
                                     };
                if (upgrade.Value.Description.Length > 0)
                {
                    button.ToolTip.Text += string.Format("\nBeschreibung: {0}", upgrade.Value.Description);
                }

                lastWidth = button.Left + button.Width;
            }

            UpgradeBox.AutoScroll = true;
            UpgradeBox.Refresh();
        }

        private void button_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var upgrade = (string)button.Tag;
            Tower.BuyUpgrade(upgrade);
            InitializeUpgradeButtons();
        }

        private void TowerInfoWindow_Closing(object sender, WindowClosingEventArgs e)
        {
            if (GamePlayScreen.TowerManager.SelectedTower == Tower)
                GamePlayScreen.TowerManager.DeselectTower();
        }

        public void UpdateTowerInformation()
        {
            Text = Tower.Name;
            Interval = Tower.Interval;
            Range = Tower.Range;
            Price = (int)Tower.Price;
            Damage = Tower.Damage;
            Description = Tower.Description;

            foreach (var label in CustomLabels)
            {
                if (Tower.GetProperties.ContainsKey(label.Key))
                {
                    label.Value.Text = (string)label.Value.Tag + ": " +
                                       Math.Round(Tower.GetProperties[label.Key](), 2, MidpointRounding.AwayFromZero);
                }
                else
                {
					/*
                    LogFramework.AddLog(string.Format("Turm \"{0}\" hat keine GetProperty \"{1}\"", Tower.Name,
                                                       label.Key), false, LogType.Error);
					*/
                }
            }
        }
    }
}