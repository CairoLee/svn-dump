using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ImageHelper {

	public class Helper {
		private static System.Reflection.Assembly mAssembly = null;
		private static System.Drawing.Text.PrivateFontCollection mFontColection = new System.Drawing.Text.PrivateFontCollection();

		public static System.Reflection.Assembly Assembly {
			get {
				if( mAssembly == null )
					mAssembly = System.Reflection.Assembly.GetExecutingAssembly();
				return mAssembly; 
			}
		}



		public static System.Drawing.Image GetShaiyaClass( int i ) {
			if( i == -1 )
				return null;

			string resName = Assembly.GetName().Name + ".Resources.Class_" + ( i + 1 ) + ".png";
			return System.Drawing.Bitmap.FromStream( Assembly.GetManifestResourceStream( resName ) );
		}


		public static FontFamily LoadFont( string Fontname ) {
			FontFamily font = null;
			try {
				string asmName = Assembly.GetName().Name.Replace( " ", "_" );
				using( System.IO.Stream s = Assembly.GetManifestResourceStream( asmName + ".Resources." + Fontname + ".ttf" ) ) {
					System.IntPtr ptr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem( (int)s.Length );

					byte[] data = new byte[ (int)s.Length ];
					s.Read( data, 0, (int)s.Length );
					System.Runtime.InteropServices.Marshal.Copy( data, 0, ptr, data.Length );
					mFontColection.AddMemoryFont( ptr, data.Length );

					font = new FontFamily( mFontColection.Families[ mFontColection.Families.Length - 1 ].Name, mFontColection );

					System.Runtime.InteropServices.Marshal.FreeCoTaskMem( ptr );
				}
				return font;
			} catch {
				return null;
			}

		}

		public static void ClearFonts() {
			mFontColection = new System.Drawing.Text.PrivateFontCollection();
		}

	}

}
