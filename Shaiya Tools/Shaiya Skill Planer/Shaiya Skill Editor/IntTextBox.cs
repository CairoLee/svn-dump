using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shaiya_Skill_Editor {

	public class IntTextBox : TextBox {
		public int Value {
			get {
				int i = 0;
				if( int.TryParse( Text, out i ) == false )
					return 0;
				return i;
			}
			set { Text = value.ToString(); }
		}


		public IntTextBox()
			: base() {

			KeyDown += new KeyEventHandler( IntTextBox_KeyDown );
		}


		private void IntTextBox_KeyDown( object sender, KeyEventArgs e ) {
			if( !( ( '0' <= e.KeyValue && e.KeyValue <= '9' ) || e.KeyCode < Keys.Help ) ) 
				e.SuppressKeyPress = true;
		}

	}

}
