using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ShaiyaMonsterMap.Helper {

	public class HelperMsg {

		public static void Error( string Text, string Title ) {
			MessageBox.Show( Text, Title, MessageBoxButtons.OK, MessageBoxIcon.Error );
		}

		public static bool Ask( string Question, string Title ) {
			return MessageBox.Show( Question, Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.Yes;
		}

	}

}
