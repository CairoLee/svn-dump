using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Ssc {

	public class Helper {

		public static void MessageError( string Text, string Title ) {
			MessageBox.Show( Text, Title, MessageBoxButtons.OK, MessageBoxIcon.Error );
		}

	}

	public class Native {
		public struct IconInfo {
			public bool fIcon;
			public int xHotspot;
			public int yHotspot;
			public IntPtr hbmMask;
			public IntPtr hbmColor;
		}

		[DllImport( "user32.dll" )]
		public static extern IntPtr CreateIconIndirect( ref IconInfo icon );

		[DllImport( "user32.dll" )]
		[return: MarshalAs( UnmanagedType.Bool )]
		public static extern bool GetIconInfo( IntPtr hIcon, ref IconInfo pIconInfo );

		public static System.Windows.Forms.Cursor CreateCursor( System.Drawing.Bitmap bmp, int xHotSpot, int yHotSpot ) {
			IconInfo tmp = new IconInfo();
			GetIconInfo( bmp.GetHicon(), ref tmp );
			tmp.xHotspot = xHotSpot;
			tmp.yHotspot = yHotSpot;
			tmp.fIcon = false;
			return new System.Windows.Forms.Cursor( CreateIconIndirect( ref tmp ) );
		}

		public static System.Windows.Forms.Cursor GetCursor( string FileName, System.Reflection.Assembly Assembly ) {
			System.Drawing.Bitmap bmp = System.Drawing.Bitmap.FromStream( Assembly.GetManifestResourceStream( FileName ) ) as System.Drawing.Bitmap;
			return Native.CreateCursor( bmp, 0, 0 );
		}

	}

}
