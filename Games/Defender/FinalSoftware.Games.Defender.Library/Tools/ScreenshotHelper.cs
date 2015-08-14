using System.IO;
using System.Drawing;

namespace FinalSoftware.Games.Defender.Library.Tools {

	public class ScreenshotHelper {
		public static string Path;

		public static void MakeScreenshot() {
			if( ScreenshotHelper.Path == null )
				ScreenshotHelper.Path = System.AppDomain.CurrentDomain.BaseDirectory + @"\Screeshot\";

			using( Bitmap img = new Bitmap( DefenderWorld.Instance.Game.GraphicsDevice.Viewport.Width, DefenderWorld.Instance.Game.GraphicsDevice.Viewport.Height ) ) {
				using( Graphics g = Graphics.FromImage( img ) ) {
					g.CopyFromScreen( new Point( 0, 0 ), new Point( 0, 0 ), new Size( img.Width, img.Height ) );
					img.Save( GetFilename(), System.Drawing.Imaging.ImageFormat.Png );
				}
			}
		}


		private static string GetFilename() {
			string fileName = "";
			if( !Directory.Exists( ScreenshotHelper.Path ) )
				Directory.CreateDirectory( ScreenshotHelper.Path );

			string[] files = System.IO.Directory.GetFiles( ScreenshotHelper.Path, "*.png" );

			if( files.Length > 0 ) {
				fileName = files[ files.Length - 1 ].Substring( 0, files[ files.Length - 1 ].Length - 5 );
				fileName += (string)( files.Length + 1 ).ToString() + ".png";

			} else {
				fileName = ScreenshotHelper.Path + "\\screenshot1.png";
			}
			return fileName;
		}

	}

}
