
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace WebUtil {

	public struct PixelData {
		public byte B;
		public byte G;
		public byte R;
	}

	public unsafe class FastImage : IDisposable {
		private Bitmap mBitmap;

		private int mWidth;
		private BitmapData BitmapData = null;
		private Byte* mPBase = null;

		public Bitmap Bitmap {
			get { return mBitmap; }
		}

		private Point PixelSize {
			get {
				GraphicsUnit unit = GraphicsUnit.Pixel;
				RectangleF bounds = mBitmap.GetBounds( ref unit );

				return new Point( (int)bounds.Width, (int)bounds.Height );
			}
		}



		public FastImage( Bitmap bitmap ) {
			this.mBitmap = new Bitmap( bitmap );
		}

		public FastImage( int width, int height ) {
			this.mBitmap = new Bitmap( width, height, PixelFormat.Format24bppRgb );
		}



		public void LockBitmap() {
			GraphicsUnit unit = GraphicsUnit.Pixel;
			RectangleF boundsF = mBitmap.GetBounds( ref unit );
			Rectangle bounds = new Rectangle( (int)boundsF.X, (int)boundsF.Y, (int)boundsF.Width, (int)boundsF.Height );

			mWidth = (int)boundsF.Width * sizeof( PixelData );
			if( mWidth % 4 != 0 )
				mWidth = 4 * ( mWidth / 4 + 1 );

			BitmapData = mBitmap.LockBits( bounds, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb );

			mPBase = (Byte*)BitmapData.Scan0.ToPointer();
		}

		public PixelData GetPixel( int x, int y ) {
			PixelData returnValue = *PixelAt( x, y );
			return returnValue;
		}

		public void SetPixel( int x, int y, PixelData colour ) {
			PixelData* pixel = PixelAt( x, y );
			*pixel = colour;
		}

		public void UnlockBitmap() {
			mBitmap.UnlockBits( BitmapData );
			BitmapData = null;
			mPBase = null;
		}
		public PixelData* PixelAt( int x, int y ) {
			return (PixelData*)( mPBase + y * mWidth + x * sizeof( PixelData ) );
		}

		#region IDisposable Member
		public void Dispose() {
			if( mBitmap != null ) {
				try { mBitmap.Dispose(); } catch { }
				mBitmap = null;
			}
		}

		void IDisposable.Dispose() {
			Dispose();
		}
		#endregion
	}


}
