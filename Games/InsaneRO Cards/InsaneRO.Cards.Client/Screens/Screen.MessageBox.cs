using System;
using System.Collections.Generic;
using System.Text;
using WindowLibrary.Controls;
using Microsoft.Xna.Framework;

namespace InsaneRO.Cards.Client.Screens {

	public class ScreenMessageBox : GameScreen {
		private Window mDialog;

		private string mTitle, mMessage;
		private int mWidth, mHeight;

		public event System.EventHandler OnClose;

		public ScreenMessageBox(GameClient game, string Title, string Message, int width, int height)
			: base(game) {
			Name = "MessageBox";
			mTitle = Title;
			mMessage = Message;
			mWidth = width;
			mHeight = height;
		}

		public ScreenMessageBox(GameClient game, string Title, string Message)
			: this(game, Title, Message, 350, 170) {
		}


		public override void Initialize() {
			base.Initialize();

			mDialog = new Window(WindowManager);
			mDialog.Init();
			mDialog.Width = mWidth;
			mDialog.Height = mHeight;
			mDialog.Text = mTitle;
			mDialog.Visible = true;
			mDialog.Resizable = false;
			mDialog.Closed += new WindowClosedEventHandler(mDialog_Closed);

			Label lbl = new Label(WindowManager);
			lbl.Init();
			lbl.Width = mDialog.ClientWidth - 10;
			lbl.Height = mDialog.ClientHeight - 40;
			lbl.Left = 5;
			lbl.Top = 5;
			lbl.Text = mMessage;
			lbl.Alignment = EAlignment.TopCenter;
			mDialog.Add(lbl);

			Panel pnl = new Panel(WindowManager);
			pnl.Height = 40;
			pnl.Top = mDialog.ClientHeight - pnl.Height;
			pnl.BevelBorder = EBevelBorder.Top;
			pnl.BevelMargin = 1;
			pnl.BackColor = new Color(16, 16, 16);
			pnl.Anchor = EAnchors.Bottom | EAnchors.Horizontal;
			pnl.Width = mDialog.ClientWidth;
			mDialog.Add(pnl);

			/*
			 * wont work oO
			Button btnOK = new Button( WindowManager );
			btnOK.Init();
			//btnOK.Width = 20;
			btnOK.Height = 24;
			btnOK.Text = "OK";
			btnOK.Click += new WindowLibrary.Controls.EventHandler( btnOK_Click );
			pnl.Controls.Add( btnOK );
			*/

			AddWindow(mDialog);
		}


		private void btnOK_Click(object sender, WindowLibrary.Controls.EventArgs e) {
			mDialog.Close();
		}

		private void mDialog_Closed(object sender, WindowClosedEventArgs e) {
			if (OnClose != null)
				OnClose(this, System.EventArgs.Empty);
			ExitScreen();
		}

	}

}
