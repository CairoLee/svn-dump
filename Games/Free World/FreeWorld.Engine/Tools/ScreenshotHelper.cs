using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace FreeWorld.Engine.Tools {

	public class ScreenshotHelper {
		public static string Path;

		public static void MakeScreenshot() {
			return;
			/*
			GraphicsDevice device = Constants.GraphicsDevice;
			using( ResolveTexture2D dstTexture = new ResolveTexture2D( device, device.PresentationParameters.BackBufferWidth, device.PresentationParameters.BackBufferHeight, 1, device.PresentationParameters.BackBufferFormat ) ) {

				device.ResolveBackBuffer( dstTexture );
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

				dstTexture.Save( fileName, ImageFileFormat.Png );
			}
			*/
		}

	}

}
