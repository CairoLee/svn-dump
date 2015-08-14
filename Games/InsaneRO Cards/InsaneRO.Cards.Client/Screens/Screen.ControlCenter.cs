using System;
using System.Collections.Generic;
using System.Text;
using WindowLibrary.Controls;
using Microsoft.Xna.Framework.Graphics;
using GodLesZ.Library.MySql;
using Microsoft.Xna.Framework;
using System.Data;

namespace InsaneRO.Cards.Client.Screens {

	public class ScreenControlCenter : GameScreen {
		private WindowLibrary.Controls.Console mConsole;

		public ScreenControlCenter(GameClient game)
			: base(game) {
			Name = "ControlCenter";
			IsActive = true;
			InputHandle = true;
		}


		public override void Initialize() {
			base.Initialize();

			string[] actions = new string[]{
				"Gegner suchen",
				"Deck bearbeiten",
				"noch ne Aktion",
				"Und noch eine",
				"keine Ahnung",
				"Ficken?",
				"Ok o.o",
				"blubb",
				"foo",
				"bar",
				"moepse sin toll",
			};

			// just to refresh
			ScreenManager.MainWindow.BringToFront();

			#region Links - Übersicht
			GroupPanel wnd = new GroupPanel(WindowManager);
			wnd.Init();
			wnd.Text = "Übersicht";
			wnd.TextColor = Color.LightGray;
			wnd.Width = 200;
			wnd.Height = ScreenManager.MainWindow.ClientHeight - 40;
			wnd.Top = 20;
			wnd.Left = 20;
			wnd.Visible = true;

			// Actions
			int btnWidth = 160;
			int btnHeight = 40;
			Button btn;

			for (int i = 0; i < actions.Length; i++) {
				btn = new Button(WindowManager);
				btn.Init();
				btn.Width = btnWidth;
				btn.Height = btnHeight;
				btn.Left = 20;
				btn.Top = ((i * 20) + btnHeight * i) + 20;
				btn.Text = actions[i];
				btn.Click += new WindowLibrary.Controls.EventHandler(ActionButton_Click);
				btn.Tag = i;
				wnd.Add(btn);
			}

			AddWindow(wnd);
			#endregion

			#region Rechts - Spiele & Statistik
			GroupPanel runingGamesPanel = new GroupPanel(WindowManager);
			runingGamesPanel.Init();
			runingGamesPanel.Text = "Laufende Spiele";
			runingGamesPanel.TextColor = Color.LightGray;
			runingGamesPanel.Width = 200;
			runingGamesPanel.Height = 400;
			runingGamesPanel.Top = 20;
			runingGamesPanel.Left = ScreenManager.MainWindow.ClientWidth - runingGamesPanel.Width - 20;
			runingGamesPanel.Visible = true;
			AddWindow(runingGamesPanel);

			GroupPanel statPanel = new GroupPanel(WindowManager);
			statPanel.Init();
			statPanel.Text = "Statistik";
			statPanel.TextColor = Color.LightGray;
			statPanel.Width = 200;
			statPanel.Height = ScreenManager.MainWindow.ClientHeight - 460;
			statPanel.Top = 440;
			statPanel.Left = ScreenManager.MainWindow.ClientWidth - statPanel.Width - 20;
			statPanel.Visible = true;
			AddWindow(statPanel);
			#endregion

			#region Mitte - Chat
			TabControl tbc = new TabControl(WindowManager);
			mConsole = new WindowLibrary.Controls.Console(WindowManager);

			tbc.Init();
			tbc.AddPage("Allgemein");

			tbc.Alpha = 200;
			tbc.Left = 240;
			tbc.Height = 220;
			tbc.Width = ScreenManager.MainWindow.ClientWidth - 480;
			tbc.Top = ScreenManager.MainWindow.ClientHeight - tbc.Height - 18;
			tbc.Movable = false;
			tbc.Resizable = false;
			tbc.MinimumHeight = 96;
			tbc.MinimumWidth = 160;

			tbc.TabPages[0].Add(mConsole);

			mConsole.Init();
			mConsole.Width = tbc.TabPages[0].ClientWidth;
			mConsole.Height = tbc.TabPages[0].ClientHeight;
			mConsole.Anchor = EAnchors.All;

			mConsole.Channels.Add(new ConsoleChannel(0, "Allgemein", Color.White));
			mConsole.SelectedChannel = 0;

			mConsole.MessageFormat = ConsoleMessageFormats.None;

			SendSystemMessage("Dein Login war erfolgreich!");
			SendSystemMessage("Willkommen im InsaneRO Card Game ;D");

			mConsole.MessageSent += new ConsoleMessageEventHandler(Channel1_MessageSent);

			AddWindow(tbc);
			#endregion

			GroupPanel newsPanel = new GroupPanel(WindowManager);
			newsPanel.Init();
			newsPanel.Text = "InsaneRO News";
			newsPanel.TextColor = Color.LightGray;
			newsPanel.Width = ScreenManager.MainWindow.ClientWidth - 480;
			newsPanel.Height = ScreenManager.MainWindow.ClientHeight - 40 - 220;
			newsPanel.Top = 20;
			newsPanel.Left = 240;
			newsPanel.Visible = true;
			newsPanel.AutoScroll = EAutoScroll.Vertical;

			AddWindow(newsPanel);

			LoadNews();
		}


		private void Channel1_MessageSent(object sender, ConsoleMessageEventArgs e) {
			e.Message.Text = string.Format("[{0}][{1}]: {2}", e.Message.Time.ToLongTimeString(), Game.Player.Displayname, e.Message.Text);
		}

		private void ActionButton_Click(object sender, WindowLibrary.Controls.EventArgs e) {
			Button btn = sender as Button;
			int i = int.Parse(btn.Tag.ToString());
			/*
				"Gegner suchen",
				"Deck bearbeiten",
				"noch ne Aktion",
				"Und noch eine",
				"keine Ahnung",
				"Ficken?",
				"Ok o.o",
				"blubb",
				"foo",
				"bar",
				"moepse sin toll",
			 */
		}






		private void LoadNews() {
			DataTable table = Game.MySql.Query("SELECT u.name AS author, n.title, n.message, DATE_FORMAT( n.date, '%d.%m.%Y %H:%i' ) AS `date` FROM `news` AS n LEFT JOIN `user` AS u ON u.id = n.authorID ORDER BY n.`date` DESC");
			for (int i = 0; i < table.Rows.Count; i++) {
				DataRow row = table.Rows[i];
				string author = row.Field<string>("author");
				string date = row.Field<string>("date");
				string message = row.Field<string>("message");
				string title = row.Field<string>("title");

				string today = DateTime.Today.ToString("d.m.Y");

				AddNews(author, date, title, message, i);
			}
		}

		private void AddNews(string author, string date, string title, string message, int num) {
			GroupPanel newsPnl = ScreenManager.MainWindow.ClientArea.Controls["InsaneRO News"] as GroupPanel;
			Panel pnl = new Panel(WindowManager);
			pnl.Init();
			pnl.Text = "News_" + num;
			pnl.Tag = num;
			pnl.Width = newsPnl.ClientWidth - 20;
			pnl.Height = 210;
			pnl.Left = 10;
			pnl.Top = (num * 10) + (num * 210) + 10;
			pnl.BevelBorder = EBevelBorder.All;
			pnl.BevelMargin = 1;
			pnl.BevelStyle = EBevelStyle.Flat;
			pnl.Color = Color.Transparent;
			pnl.Passive = true;

			Label lblTitle = new Label(WindowManager);
			lblTitle.Init();
			lblTitle.Skin.Layers[0].Text.Font.Resource = WindowManager.Skin.Fonts[WindowManager.Skin.Controls["Dialog"].Layers["TopPanel"].Attributes["CaptFont"].Value].Resource;
			lblTitle.Text = "'" + title + "' - Von " + author + " (" + date + ")";
			lblTitle.TextColor = new Color(81, 172, 232);
			lblTitle.Top = 5;
			lblTitle.Left = 5;
			lblTitle.Width = pnl.ClientWidth - 15;
			lblTitle.Height = 24;
			lblTitle.Alignment = EAlignment.TopLeft;
			pnl.Add(lblTitle);

			Label lblMessage = new Label(WindowManager);
			lblMessage.Init();
			lblMessage.Text = "";
			lblMessage.TextLines.AddRange(message.Split(new string[] { Environment.NewLine }, StringSplitOptions.None));
			lblMessage.Top = 5 + 5 + 24;
			lblMessage.Left = 10;
			lblMessage.Width = pnl.ClientWidth - 20;
			lblMessage.Height = pnl.ClientHeight - 15 - 24;
			lblMessage.Ellipsis = false;
			lblMessage.Alignment = EAlignment.TopLeft;
			lblMessage.Autosize = true;
			lblMessage.Draw += new DrawEventHandler(lblMessage_Draw);
			pnl.Add(lblMessage);

			newsPnl.Add(pnl);
		}


		private void lblMessage_Draw(object sender, DrawEventArgs e) {
			// update parent Panel with new Height
			Label lbl = sender as Label;
			string parentName = lbl.Parent.Parent.Text;
			int num = int.Parse(lbl.Parent.Parent.Tag.ToString());
			GroupPanel newsPnl = ScreenManager.MainWindow.ClientArea.Controls["InsaneRO News"] as GroupPanel;
			Panel newsSubPanel = newsPnl.ClientArea.Controls[parentName] as Panel;
			newsSubPanel.Height = lbl.ClientHeight + 15 + 24;

			// get top padding from other panels above this
			int top = 10 + (num * 10);
			for (int i = 0; i < num; i++)
				top += newsPnl.ClientArea.Controls["News_" + num].ClientHeight;
			newsSubPanel.Top = top;
			newsSubPanel.Invalidate();

			// refresh
			newsPnl.Refresh();
			newsPnl.Invalidate();

			// no need to do this more than once
			lbl.Draw -= new DrawEventHandler(lblMessage_Draw);
		}


		private void SendSystemMessage(string Message) {
			Message = string.Format("[{0}][System]: {1}", DateTime.Now.ToLongTimeString(), Message);
			mConsole.MessageBuffer.Add(new ConsoleMessage(Message, 0));
		}

	}

}
