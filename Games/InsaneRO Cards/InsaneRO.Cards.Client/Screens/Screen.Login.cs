using System;
using System.Collections.Generic;
using System.Text;
using WindowLibrary.Controls;
using GodLesZ.Library.MySql;
using System.Data;

namespace InsaneRO.Cards.Client.Screens {

	public class ScreenLogin : GameScreen {
		private Button mSubmitButton;
		private TextBox mUsername;
		private TextBox mPassword;

		public ScreenLogin(GameClient game)
			: base(game) {
			Name = "Login";
			IsActive = true;
			InputHandle = true;
		}


		public override void Initialize() {
			base.Initialize();

			Window win = new Window(WindowManager);
			win.Init();
			win.Text = "Account Login";
			win.Width = 350;
			win.Height = 150;
			win.Center();
			win.Resizable = false;
			win.Movable = false;
			win.StayOnTop = true;
			win.Shadow = false;
			win.CloseButtonVisible = false;
			win.IconVisible = false;
			win.FocusLost += delegate(object sender, WindowLibrary.Controls.EventArgs e) {
				win.Focused = true;
			};
			win.Visible = true;

			Label lbl = new Label(WindowManager);
			lbl.Init();
			lbl.Parent = win;
			lbl.Text = "Name";
			lbl.Left = 20;
			lbl.Top = 20;
			win.Add(lbl);

			mUsername = new TextBox(WindowManager);
			mUsername.Init();
			mUsername.Parent = win;
			mUsername.Left = 80;
			mUsername.Top = 20;
			mUsername.Width = win.ClientWidth - 160;
			mUsername.Focused = true;
			mUsername.KeyPress += new KeyEventHandler(txt_KeyPress);
			win.Add(mUsername);

			lbl = new Label(WindowManager);
			lbl.Init();
			lbl.Parent = win;
			lbl.Text = "Passwort";
			lbl.Left = 20;
			lbl.Top = 40;
			win.Add(lbl);

			mPassword = new TextBox(WindowManager);
			mPassword.Init();
			mPassword.Parent = win;
			mPassword.Left = 80;
			mPassword.Top = 40;
			mPassword.Width = win.ClientWidth - 160;
			mPassword.PasswordChar = '*';
			mPassword.Mode = ETextBoxMode.Password;
			mPassword.KeyPress += new KeyEventHandler(txt_KeyPress);
			win.Add(mPassword);

			mSubmitButton = new Button(WindowManager);
			mSubmitButton.Init();
			mSubmitButton.Parent = win;
			mSubmitButton.Text = "Login";
			mSubmitButton.Width = 72;
			mSubmitButton.Height = 24;
			mSubmitButton.Left = win.ClientWidth - 74;
			mSubmitButton.Top = win.ClientHeight - 26;
			mSubmitButton.Anchor = EAnchors.Bottom | EAnchors.Right;
			mSubmitButton.Click += new WindowLibrary.Controls.EventHandler(mSubmitButton_Click);
			win.Add(mSubmitButton);

			AddWindow(win);
		}

		private void txt_KeyPress(object sender, KeyEventArgs e) {
			if (e.Key == Microsoft.Xna.Framework.Input.Keys.Enter)
				mSubmitButton.PerformClick();
		}



		private void mSubmitButton_Click(object sender, WindowLibrary.Controls.EventArgs e) {
			ScreenManager.MainWindow.DisableClientControl("Account Login");

			string username = mUsername.Text.MysqlEscape();
			string password = mPassword.Text.MysqlEscape();
			if (username.Length < 4 || password.Length < 4) {
				InfoDialog msg = new InfoDialog(WindowManager, "Login fehlgeschlagen", "Dein Name und Passwort\nmüssen mindestens 4 Zeichen lang sein!", "Icon.Warning");
				msg.Init();
				msg.IconVisible = false;
				msg.BtnOK.ModalResult = EModalResult.None; // any other close the root
				msg.Closing += new WindowClosingEventHandler(msg_Closed);

				ScreenManager.MainWindow.Add(msg);
				return;
			}

			DataTable result = Game.MySql.Query("SELECT u.*, g.level, g.name AS groupName FROM `user` AS u LEFT JOIN `groups` AS g ON g.id = u.groupID WHERE u.username = '{0}' AND u.password = '{1}'", username, password);
			if (result.Rows.Count == 0) {
				InfoDialog msg = new InfoDialog(WindowManager, "Login fehlgeschlagen", "User nicht gefunden!\nBitte überprüfe deinen Username und Passwort\nnoch einmal und versuche es erneut.", "Icon.Error");
				msg.Init();
				msg.IconVisible = false;
				msg.BtnOK.ModalResult = EModalResult.None; // any other close the root
				msg.Closing += new WindowClosingEventHandler(msg_Closed);

				ScreenManager.MainWindow.Add(msg);
				return;
			}

			ScreenManager.MainWindow.EnableClientControl("Account Login");

			Game.Player = new InsaneRO.Cards.Client.Classes.GamePlayer(result.Rows[0]);
			// switch to control center
			ScreenManager.AddScreen(new ScreenControlCenter(Game));
			ExitScreen();
		}


		private void msg_Closed(object sender, WindowClosingEventArgs e) {
			if (e.Handled == true)
				return;
			Control wnd = ScreenManager.MainWindow.EnableClientControl("Account Login");
			wnd.BringToFront();
			mUsername.Focused = true; // re-focus
			e.Handled = true;
		}

	}

}
