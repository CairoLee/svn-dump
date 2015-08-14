using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;

namespace ClientPatcher {

	public class Tools {
		public static int FindString( string stringBuf, string SearchString, int SearchStart ) {
			int i = stringBuf.IndexOf( SearchString, SearchStart );
			if( i == -1 )
				return -1;

			if( ( i % 2 ) != 0 )
				return -1;

			return i > 0 ? i / 2 : i;
		}

		public static byte Hex2Dec( string hex ) {
			if( hex == "**" )
				return 0;

			return Hex.SingleHexToByte( hex );
		}


		public static void Error( string Message ) {
			MessageBox.Show( Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
		}
		public static void Info( string Message ) {
			MessageBox.Show( Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information );
		}

	}

}
