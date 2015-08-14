using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shaiya_Hotkey_Emulator {

	public partial class frmMain : Form {
		private Keys mCapturedKey = Keys.None;
		private Keys mCapturedMod = Keys.None;
		private int mActiveSetButton = -1;
		private Dictionary<int, Keys> mKeys = new Dictionary<int, Keys>();
		private Dictionary<int, Keys> mMods = new Dictionary<int, Keys>();
		private HotKey mHotkey;


		public frmMain() {
			InitializeComponent();

			mHotkey = new HotKey();
			mHotkey.OwnerForm = this;
			mHotkey.HotKeyPressed += new HotKey.HotKeyPressedEventHandler( mHotkey_HotKeyPressed );
		}

		private void mHotkey_HotKeyPressed( string HotKeyID ) {
			Keys key = (Keys)Enum.Parse( typeof( Keys ), HotKeyID );
			if( key == Keys.None )
				return;
		}



		private void frmMain_FormClosing( object sender, FormClosingEventArgs e ) {
			mHotkey.RemoveAllHotKeys();
		}

		private void frmMain_KeyDown( object sender, KeyEventArgs e ) {
			if( e.Modifiers == Keys.None )
				mCapturedKey = e.KeyCode;
			else
				mCapturedMod = e.Modifiers;
			lblKeyInfo.Text = "Keys: " + mCapturedKey.ToString();
			lblKeyModInfo.Text = "Modifers: " + mCapturedMod.ToString();

			e.Handled = true;
			e.SuppressKeyPress = false;
		}

		private void btnReset_Click( object sender, EventArgs e ) {
			mCapturedKey = mCapturedMod = Keys.None;
			lblKeyInfo.Text = "Keys: " + mCapturedKey.ToString();
			lblKeyModInfo.Text = "Modifers: " + mCapturedMod.ToString();
		}

		private void btnSetKey_Click( object sender, EventArgs e ) {
			Button btn = sender as Button;
			// start capture
			if( btn.Text == "set Key" ) {
				mActiveSetButton = int.Parse( btn.Name.Substring( btn.Name.Length - 1 ) );
				SetState( false, mActiveSetButton );
				btn.Text = "save Key";
			} else {
				// save capture
				if( mCapturedKey != Keys.None )
					SetHotkey();

				SetState( true, -1 );
				btn.Text = "set Key";

				lblStatus.Text = "Drücke einen der \"set Key\" Button um den Key zu ändern";
			}
		}




		private void SetHotkey() {
			if( mKeys.ContainsKey( mActiveSetButton ) == true ) {
				mKeys.Remove( mActiveSetButton );
				mMods.Remove( mActiveSetButton );
			}

			Label lbl = Hotkeybar1.Controls[ "lblKey" + mActiveSetButton ] as Label;
			lbl.Text = "";

			mKeys.Add( mActiveSetButton, mCapturedKey );
			mMods.Add( mActiveSetButton, mCapturedMod );
			if( mCapturedMod != Keys.None )
				lbl.Text = mCapturedMod.ToString() + " + ";
			lbl.Text += mCapturedKey.ToString();
		}

		private void SetState( bool State, int ExceptThis ) {

			for( int i = 0; i < 10; i++ ) {
				if( i != ExceptThis )
					Hotkeybar1.Controls[ "btnSetKey" + i ].Enabled = State;
			}

		}


	}


}
