using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.DirectDraw;

namespace OverlayLib {

	public class Overlay : IDisposable {
		private static EPixelFormat mPixelFormat = EPixelFormat.RGB32;

		/// <summary>
		/// The PixelFormat of the render surface
		/// </summary>
		public enum EPixelFormat {
			RGB32, // RGB32 (R,G,B, -)
			YUY2, // YUY2 (16 bit)
		}


		private bool mAlphaEnabled = true;
		private Surface mBackBuffer;
		private Surface mBuffer; //Render Source
		private Device mDevice;
		private OverlayEffects mEffects;
		private OverlayFlags mFlags;
		private Point mPosition = Point.Empty;
		private Surface mPrimary;
		private RenderDelegate mRenderer;
		private Bitmap mRenderTarget;

		private Size mSize = new Size( 100, 100 );

		/// <summary>
		/// The position of the overlay on the screen
		/// </summary>
		public Point Position {
			get { return mPosition; }
			set {
				if( mDevice != null ) {
					Hide();
					mPosition = value;
					Update();
				} else {
					mPosition = value;
				}
			}
		}

		/// <summary>
		/// The Size of the overlay
		/// </summary>
		public Size Size {
			get { return mSize; }
			set {
				mSize = value;
				if( Initialized ) {
					Dispose();
					Initialise();
				}
			}
		}

		/// <summary>
		/// Boundings of the overlay
		/// Combins Position and Size
		/// </summary>
		public Rectangle Boundings {
			get { return new Rectangle( Position, Size ); }
		}

		/// <summary>
		/// Called when the overlay shall be redrawn
		/// </summary>
		public RenderDelegate Renderer {
			get { return mRenderer; }
			set { mRenderer = value; }
		}

		/// <summary>
		/// The pixelformat currently used
		/// Either let this be determined default, or set it to try using the specified value as a start value
		/// </summary>
		public EPixelFormat PixelFormat {
			get { return mPixelFormat; }
			set { mPixelFormat = value; }
		}

		/// <summary>
		/// Determines whether alpha is enabled or not
		/// Beware: Is not supported on many (all?) nvidia graphic cards
		/// </summary>
		public bool AlphaEnabled {
			get { return mAlphaEnabled; }
			set {
				mAlphaEnabled = value;

				if( mDevice != null ) {
					CreateFlags();
				}
			}
		}

		public bool Initialized {
			get { return mDevice != null && mBuffer != null && mRenderTarget != null; }
		}

		public Bitmap RenderTarget {
			get { return mRenderTarget; }
		}



		/// <summary>
		/// Initialises the overlay with the specified Boundings
		/// </summary>
		public void Initialise() {
			mDevice = new Device();
			mDevice.SetCooperativeLevel( null, CooperativeLevelFlags.Normal ); //Only a overlay..

			//Create Primary
			SurfaceDescription desc = new SurfaceDescription();
			desc.SurfaceCaps.PrimarySurface = true;
			mPrimary = new Surface( desc, mDevice );

			//Create buffer
			desc = new SurfaceDescription();
			desc.Width = Boundings.Width;
			desc.Height = Boundings.Height;
			desc.BackBufferCount = 1;
			desc.SurfaceCaps.Flip = true;
			desc.SurfaceCaps.Overlay = true;
			desc.SurfaceCaps.Complex = true;
			desc.SurfaceCaps.VideoMemory = true;

			//Try which pixelformat works
			do {
				try {
					desc.PixelFormatStructure = GetPixelFormat( mPixelFormat );
					mBuffer = new Surface( desc, mDevice );
				} catch( InvalidPixelFormatException ) {
					mPixelFormat++;
				} catch( DirectXException ex ) {
					System.Diagnostics.Debug.WriteLine( ex );
					mBuffer = null;
					break;
				}
			} while( mBuffer == null && Enum.IsDefined( typeof( EPixelFormat ), mPixelFormat ) ); //Stop if a valid format is found or no one is left

			if( mBuffer == null || Enum.IsDefined( typeof( EPixelFormat ), mPixelFormat ) == false ) {
				mPixelFormat = EPixelFormat.RGB32; // reset Format
				mBuffer = null;
				throw new GraphicsException( "Could not create overlay - Either your graphic card does not support any of the available pixelformats or overlays in general." );
			}

			//Create backbuffer
			SurfaceCaps caps = new SurfaceCaps();
			caps.BackBuffer = true;
			mBackBuffer = mBuffer.GetAttachedSurface( caps );

			//Create rendertarget
			//Bitmap works on every graphicscard, a RGB-Surface wont
			mRenderTarget = new Bitmap( Boundings.Width, Boundings.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb );

			CreateFlags();
		}

		/// <summary>
		/// Creates the render flags
		/// </summary>
		public void CreateFlags() {
			//Create Flags
			mFlags = OverlayFlags.Show;

			//Create Effects
			mEffects = new Microsoft.DirectX.DirectDraw.OverlayEffects();
		}

		/// <summary>
		/// Renders (Updates) the overlay
		/// * Calls the RenderDelegate
		/// </summary>
		public bool Update() {
			if( mDevice == null || mRenderTarget == null || mBuffer == null )
				return false;

			try {
				if( mRenderer != null ) {
					//Draw on the backbuffer
					Graphics g = Graphics.FromImage( mRenderTarget );
					g.Clear( Color.Transparent );
					mRenderer( g );
					Blit( mRenderTarget, mBackBuffer );
				}

				//Flip maps
				mBuffer.Flip( null, FlipFlags.Wait );

				//Render
				mBuffer.UpdateOverlay( mPrimary, Boundings, mFlags, mEffects );
			} catch( SurfaceLostException ) {
				//May occur, but not bad - TestCooperativeLevel wont work in some D3D apps, but overlay will still render
				if( mDevice.TestCooperativeLevel() ) {
					mDevice.RestoreAllSurfaces();
				} else
					Initialise();
			}
			return true;
		}

		/// <summary>
		/// Hides the overlay from screen
		/// Can be undone by calling Update()
		/// </summary>
		public void Hide() {
			if( mDevice == null || mBuffer == null || mPrimary == null )
				return;

			mBuffer.UpdateOverlay( mPrimary, Boundings, OverlayFlags.Hide );
		}

		/// <summary>
		/// Blits the RGB Bitmap to the specified surface
		/// </summary>
		/// <param name="src">RGB Bitmap</param>
		/// <param name="dest">Surface</param>
		public void Blit( Bitmap src, Surface dest ) {
			switch( mPixelFormat ) {
				case EPixelFormat.RGB32:
					BlitRGB32( src, dest );
					break;
				case EPixelFormat.YUY2:
					BlitYUY2( src, dest );
					break;
			}
		}

		/// <summary>
		/// Blits the RGB Bitmap to a YUY2 surface
		/// </summary>
		/// <param name="src">RGB Bitmap</param>
		/// <param name="dest">YUY2 Surface</param>
		public unsafe void BlitYUY2( Bitmap src, Surface dest ) {
			BitmapData ds = src.LockBits( new Rectangle( 0, 0, src.Width, src.Height ), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb );
			try {
				LockedData dd = dest.Lock( LockFlags.WriteOnly );

				try {
					int ps = ds.Stride - ( ds.Width * 3 );
					byte[] pd = new byte[ dd.Pitch - ( dd.Width * 2 ) ];

					byte* ptr = (byte*)ds.Scan0;

					for( int h = 0; h < ds.Height; h++ ) {
						for( int w = 0; w < ds.Width; w += 2 ) {
							byte[] dbuf = new byte[ 4 ]; //2 pixel (2x16bit)

							byte r1 = ptr[ 0 ];
							byte g1 = ptr[ 1 ];
							byte b1 = ptr[ 2 ];

							ptr += 3;

							byte r2 = ptr[ 0 ];
							byte g2 = ptr[ 1 ];
							byte b2 = ptr[ 2 ];

							ptr += 3;

							//Dont ask me for the conversion formulas - They are from FourCC and a bit of own modifications to match colors better
							dbuf[ 0 ] = (byte)Math.Min( 255, ( 0.230 * r1 ) + ( 0.600 * g1 ) + ( 0.170 * b1 ) ); //Yo - luminescent 1
							dbuf[ 2 ] = (byte)Math.Min( 255, ( 0.230 * r2 ) + ( 0.600 * g2 ) + ( 0.170 * b2 ) ); //Y1 - luminescent 2
							dbuf[ 1 ] = (byte)Math.Min( 255, +( 0.439 * r1 ) - ( 0.368 * g1 ) - ( 0.071 * b1 ) + 128 ); //Ux - same for both
							dbuf[ 3 ] = (byte)Math.Min( 255, -( 0.148 * r1 ) - ( 0.291 * g1 ) + ( 0.439 * b1 ) + 128 ); //Vx - same for both

							dd.Data.Write( dbuf, 0, dbuf.Length );
						}
						ptr += ps;

						if( pd.Length > 0 ) {
							dd.Data.Write( pd, 0, pd.Length );
						}
					}
				} catch( Exception e ) {
					MessageBox.Show( e.ToString() );
				} finally {
					dest.Unlock();
				}
			} catch( Exception e ) {
				System.Diagnostics.Debug.WriteLine( e );
			} finally {
				src.UnlockBits( ds );
			}
		}

		/// <summary>
		/// Blits the RGB-Bitmap to a RGB32 Surface
		/// </summary>
		/// <param name="src">RGB Bitmap</param>
		/// <param name="dest">RGB32 Surface</param>
		public unsafe void BlitRGB32( Bitmap src, Surface dest ) {
			BitmapData ds = src.LockBits( new Rectangle( 0, 0, src.Width, src.Height ), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb );
			try {
				LockedData dd = dest.Lock( LockFlags.WriteOnly );

				try {
					int ps = ds.Stride - ( ds.Width * 3 );
					byte[] pd = new byte[ dd.Pitch - ( dd.Width * 4 ) ];

					byte* ptr = (byte*)ds.Scan0;

					for( int h = 0; h < ds.Height; h++ ) {
						for( int w = 0; w < ds.Width; w += 1 ) {
							byte[] dbuf = new byte[ 4 ]; //2 pixel (2x16)

							byte r = ptr[ 0 ];
							byte g = ptr[ 1 ];
							byte b = ptr[ 2 ];

							ptr += 3;

							dbuf[ 0 ] = r;
							dbuf[ 1 ] = g;
							dbuf[ 2 ] = b;

							dd.Data.Write( dbuf, 0, dbuf.Length );
						}

						ptr += ps;

						if( pd.Length > 0 )
							dd.Data.Write( pd, 0, pd.Length );

					}
				} finally {
					dest.Unlock();
				}
			} finally {
				src.UnlockBits( ds );
			}
		}

		/// <summary>
		/// Gets the directX pixelformat for the specified pixelformat
		/// </summary>
		/// <param name="e">ePixelFormat</param>
		/// <returns>DirectX PixelFormat</returns>
		public static Microsoft.DirectX.DirectDraw.PixelFormat GetPixelFormat( EPixelFormat e ) {
			Microsoft.DirectX.DirectDraw.PixelFormat pixelFormat = new Microsoft.DirectX.DirectDraw.PixelFormat();

			switch( e ) {
				case EPixelFormat.RGB32:
					pixelFormat.Rgb = true;
					pixelFormat.RgbBitCount = 32;
					pixelFormat.RBitMask = 0xFF0000;
					pixelFormat.GBitMask = 0x00FF00;
					pixelFormat.BBitMask = 0x0000FF;
					break;
				case EPixelFormat.YUY2:
					pixelFormat.FourCC = 0x32595559;
					pixelFormat.FourCcIsValid = true;
					break;
			}

			return pixelFormat;
		}

		#region IDisposable Members
		/// <summary>
		/// Disposes the overlay and frees resources
		/// </summary>
		public void Dispose() {
			if( mPrimary != null ) {
				mPrimary.Dispose();
				mPrimary = null;
			}

			if( mBuffer != null ) {
				mBuffer.Dispose();
				mBuffer = null;
			}

			if( mBackBuffer != null ) {
				mBackBuffer.Dispose();
				mBackBuffer = null;
			}

			if( mRenderTarget != null ) {
				mRenderTarget.Dispose();
				mRenderTarget = null;
			}

			if( mDevice != null ) {
				mDevice.Dispose();
				mDevice = null;
			}
		}
		#endregion
	}

	/// <summary>
	/// Delegate for rendering
	/// </summary>
	/// <param name="g">Graphics Object</param>
	public delegate void RenderDelegate( Graphics g );

}