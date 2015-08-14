using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MarketTool.Library {

	public class GoldInputBox : TextBox {
		public int GoldAmount {
			get { return GetGold(); }
			set { SetGold( value ); }
		}


		public GoldInputBox()
			: base() {

			BackColor = System.Drawing.Color.Black;
			ForeColor = System.Drawing.Color.White;
			TextAlign = HorizontalAlignment.Right;
			KeyUp += new KeyEventHandler( GoldInputBox_KeyUp );
		}



		public void SetGold( int value ) {
			value = value.Clamp();

			// save Cursor Position
			int oldPos = this.SelectionStart;
			int curLen = Text.Length;
			
			Text = value.ToString( "#,#" );

			// restore Position + possible Format signs
			int newLen = Text.Length;
			if( newLen >= curLen )
				this.SelectionStart = oldPos + ( newLen - curLen );
			else
				this.SelectionStart = oldPos + ( curLen - newLen );
		}

		public int GetGold() {
			long val = 0;
			if( long.TryParse( Text.Replace( ".", "" ).Replace( ",", "" ), out val ) == false )
				val = 0;
			if( val > int.MaxValue )
				val = int.MaxValue;
			return (int)val;
		}



		private void GoldInputBox_KeyUp( object sender, KeyEventArgs e ) {
			if( e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right )
				return;

			int val = GoldAmount;
			GoldAmount = val;
			ForeColor = val.ToGoldColor();
		}

	}

}
