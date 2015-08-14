using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FreeWorld.Editor.Map {

	public class Messagehelper {

		public static void ShowInfo( string Title, string Message ) {
			MessageBox.Show( Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Asterisk );
		}

		public static void ShowError( string Title, string Message ) {
			MessageBox.Show( Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Error );
		}

	}

}
