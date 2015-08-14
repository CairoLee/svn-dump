using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shaiya_Skill_Editor {

	public class FloatTextBox : TextBox {
		public float Value {
			get {
				float i = 0;
				if( float.TryParse( Text, out i ) == false )
					return 0;
				return i;
			}
			set { Text = value.ToString(); }
		}


		public FloatTextBox()
			: base() {

			KeyDown += new KeyEventHandler( IntTextBox_KeyDown );
		}


		private void IntTextBox_KeyDown( object sender, KeyEventArgs e ) {
			if( !( ( '0' <= e.KeyValue && e.KeyValue <= '9' ) || e.KeyCode < Keys.Help || e.KeyValue == ',' ) ) 
				e.SuppressKeyPress = true;
		}

	}

}
