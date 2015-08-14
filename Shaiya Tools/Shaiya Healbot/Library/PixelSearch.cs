using System.Drawing;
using System.Drawing.Imaging;
using System.ComponentModel;
using System.Windows.Forms;

namespace Healbot.Library {

	public delegate void UpdatePixelinfo_Handler( PixelInfo Info );

	public class PixelSearch {
		public bool Locked = false;
		public event UpdatePixelinfo_Handler OnUpdate;
		public Size CaptureSize;

		public bool IsBusy {
			get { return mBackgroundWorker != null && mBackgroundWorker.IsBusy == true; }
		}

		private BackgroundWorker mBackgroundWorker = null;


		public PixelSearch( Size Size ) {
			CaptureSize = Size;
		}


		public void Run() {
			if( mBackgroundWorker == null ) {
				mBackgroundWorker = new BackgroundWorker();
				mBackgroundWorker.WorkerReportsProgress = true;
				mBackgroundWorker.WorkerSupportsCancellation = true;
				mBackgroundWorker.ProgressChanged += new ProgressChangedEventHandler( mBackgroundWorker_ProgressChanged );
				mBackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler( mBackgroundWorker_RunWorkerCompleted );
				mBackgroundWorker.DoWork += new DoWorkEventHandler( mBackgroundWorker_DoWork );
			}

			if( mBackgroundWorker.IsBusy == false )
				mBackgroundWorker.RunWorkerAsync( mBackgroundWorker );
		}



		private void mBackgroundWorker_DoWork( object sender, DoWorkEventArgs e ) {
			BackgroundWorker worker = e.Argument as BackgroundWorker;
			PixelInfo info = new PixelInfo();

			while( true ) {
				if( Locked == false ) {
					Point mp = Control.MousePosition;
					info.Image = PixelSearch.CaptureScreenRegion( new Rectangle( mp.X, mp.Y, CaptureSize.Width, CaptureSize.Height ) );
					info.Position = mp;
					info.Color = info.Image.GetPixel( CaptureSize.Width / 2, CaptureSize.Height / 2 );

					worker.ReportProgress( 0, info );
				}

				System.Threading.Thread.Sleep( 10 );
			}
		}

		private void mBackgroundWorker_ProgressChanged( object sender, ProgressChangedEventArgs e ) {
			if( OnUpdate != null )
				OnUpdate( e.UserState as PixelInfo );
		}

		private void mBackgroundWorker_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e ) {

		}


		#region Search
		public static Point Search( Rectangle rect, Color PixelColor, Color Shade_Variation, ref Image Img ) {
			return PixelSearch.Search( rect, PixelColor.ToArgb(), Shade_Variation.ToArgb(), ref Img );
		}

		public static Point Search( Rectangle rect, int PixelColor, int Shade_Variation, ref Image regionInBitmap ) {
			Color pixelColor = Color.FromArgb( PixelColor );
			Point pixelCoords = Point.Empty;
			regionInBitmap = CaptureScreenRegion( rect );
			BitmapData regionInBitmapData = ( regionInBitmap as Bitmap ).LockBits( new Rectangle( 0, 0, regionInBitmap.Width, regionInBitmap.Height ), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb );

			int[] fromColor = new int[ 3 ] { 
				pixelColor.B - Shade_Variation, 
				pixelColor.G - Shade_Variation, 
				pixelColor.R - Shade_Variation 
			};

			int[] toColor = new int[ 3 ] { 
				pixelColor.B + Shade_Variation, 
				pixelColor.G + Shade_Variation, 
				pixelColor.R + Shade_Variation
			};

			unsafe {
				for( int y = 0; y < regionInBitmapData.Height; y++ ) {
					byte* row = (byte*)regionInBitmapData.Scan0 + ( y * regionInBitmapData.Stride );

					for( int x = 0; x < regionInBitmapData.Width; x++ ) {
						if( row[ x * 3 ] >= fromColor[ 0 ] && row[ x * 3 ] <= toColor[ 0 ] ) {
							if( row[ ( x * 3 ) + 1 ] >= fromColor[ 1 ] && row[ ( x * 3 ) + 1 ] <= toColor[ 1 ] ) {
								if( row[ ( x * 3 ) + 2 ] >= fromColor[ 2 ] && row[ ( x * 3 ) + 2 ] <= toColor[ 2 ] ) {
									pixelCoords = new Point( x + rect.X, y + rect.Y );
									break;
								}
							}
						}
					}
				}
			}

			( regionInBitmap as Bitmap ).UnlockBits( regionInBitmapData );

			return pixelCoords;
		}
		#endregion

		#region CaptureScreenRegion
		public static Bitmap CaptureScreenRegion( Rectangle rect ) {
			Bitmap bmp = new Bitmap( rect.Width, rect.Height, PixelFormat.Format24bppRgb );
			using( Graphics g = Graphics.FromImage( bmp ) )
				g.CopyFromScreen( rect.X, rect.Y, 0, 0, rect.Size, CopyPixelOperation.SourceCopy );
			return bmp;
		} 
		#endregion

	}


	public class PixelInfo {

		public Point Position;
		public Color Color;
		public Bitmap Image;

	}


	public static class ColorExtensions {
		public static string ToHex( this Color col ) {
			return ColorTranslator.ToHtml( col );
		}
		public static Color HexToColor( this string col ) {
			return ColorTranslator.FromHtml( col );
		}
	}

}
