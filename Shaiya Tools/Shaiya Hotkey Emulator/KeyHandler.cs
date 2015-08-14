using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Shaiya_Hotkey_Emulator {

	public class KeyHandler {

		public static bool Send( string Key, bool SendWait, bool SetForeground ) {
			int iHandle = Native.FindWindow( null, "Calculator" );
			if( iHandle == 0 )
				return false;

			if( SetForeground == false ) {
				// maybe Windows is in Background...
				return SendBG( iHandle, Key );
			}
			
			Native.SetForegroundWindow( iHandle );
			if( SendWait )
				SendKeys.SendWait( Key );
			else
				SendKeys.Send( Key );

			return true;
		}

		public const int WM_CHAR = 0x0102;
		public static bool SendBG( int iHandle, string Key ) {
			if( Key.Length == 0 )
				return false;

			Native.SendMessage( iHandle, WM_CHAR, (int)Key[ 0 ], 0 );
			if( Key.Length > 1 )
				return SendBG( iHandle, Key.Substring( 1 ) );

			return true;
		}

	}

}
