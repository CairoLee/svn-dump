using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using TomShane.Neoforce.Controls;

namespace PathDefence.InGameGui
{
    public class TowerBaseInfoWindow : Window
    {
        public const int DesiredWidth = 335;
        protected readonly Label lblDamage;
        protected readonly RappingLabel lblDescription;
        protected readonly Label lblInterval;
        protected readonly Label lblPrice;
        protected readonly Label lblRange;
        private List<Label> LabelsToShow;

        public TowerBaseInfoWindow(Manager manager)
            : base(manager)
        {
            lblInterval = new Label(manager);
            lblDamage = new Label(manager);
            lblDescription = new RappingLabel(manager);
            lblRange = new Label(manager);
            lblPrice = new Label(manager);
            manager.Add(this);
        }

        public float Interval
        {
            set { lblInterval.Text = "Schuss-Intervall: " + value; }
        }

        public float Damage
        {
            set { lblDamage.Text = "Schaden: " + value; }
        }

        public float Range
        {
            set { lblRange.Text = "Reichweite: " + value; }
        }

        public string TowerName
        {
            set { Text = value; }
        }

        public string Description
        {
            set { lblDescription.Text = "Besonderheiten: " + value; }
        }

        public int Price
        {
            set { lblPrice.Text = "Preis: " + value; }
        }

        public virtual void Init(bool damage, bool range, bool interval)
        {
            base.Init();
            Alpha = 200;
            LabelsToShow = new List<Label>();
            if (damage)
                LabelsToShow.Add(lblDamage);
            if (range)
                LabelsToShow.Add(lblRange);
            if (interval)
                LabelsToShow.Add(lblInterval);
            LabelsToShow.Add(lblPrice);
            LabelsToShow.Add(lblDescription);

            CloseButtonVisible = false;
            Passive = true;

            Width = DesiredWidth;
            Height = 150;

            lblInterval.Init();
            lblDamage.Init();
            lblRange.Init();
            lblPrice.Init();
            lblDescription.Init();

            InitializeControls(this, 2);
        }

        protected void InitializeControls(Control parent, int top)
        {
            foreach (Label label in LabelsToShow)
            {
                parent.Add(label);
            }

            for (int i = 0; i < LabelsToShow.Count; i++)
            {
                Label label = LabelsToShow[i];
                label.Left = 4;
                label.Width = label.Parent.Width - 4;
                if (i == 0)
                    label.Top = top;
                else
                {
                    label.Top = LabelsToShow[i - 1].Top + LabelsToShow[i - 1].Height + 2;
                }
                if (label is RappingLabel)
                {
                    label.Height = label.Parent.Height - label.Top - 4;
                    label.Alignment = Alignment.TopLeft;
                    label.TextColor = Microsoft.Xna.Framework.Color.LightGray;
                    (label as RappingLabel).WrapText();
                }
            }
        }
    }
}