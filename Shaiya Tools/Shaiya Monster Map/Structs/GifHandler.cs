using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace ShaiyaMonsterMap.Structs {

	public class GifHandler {
		private Image mImage;

		private FrameDimension mFrameDimension;
		private int mFrameCount;
		private int[] mFrameTimes;
		private DateTime mLastTime = new DateTime( 1970, 1, 1 );

		private Image mCurrentFrame = null;
		private int mCurrentFrameIndex = -1;


		public Image Image {
			get { return mImage; }
			set {
				mImage = value;
				if( value != null ) {
					mFrameDimension = new FrameDimension( mImage.FrameDimensionsList[ 0 ] );
					mFrameCount = mImage.GetFrameCount( mFrameDimension );
					mCurrentFrameIndex = -1;
					mLastTime = new DateTime( 1970, 1, 1 );
				}
			}
		}

		public FrameDimension FrameDimension {
			get { return mFrameDimension; }
		}

		public int FrameCount {
			get { return mFrameCount; }
		}

		public int[] FrameTimes {
			get { return mFrameTimes; }
		}

		public Image CurrentFrame {
			get { return GetNextFrame(); }
		}

		public int CurrentFrameIndex {
			get { return mCurrentFrameIndex; }
		}


		public GifHandler( Image Image ) {
			mImage = Image.Clone() as Image;
			mFrameDimension = new FrameDimension( mImage.FrameDimensionsList[ 0 ] );
			mFrameCount = mImage.GetFrameCount( mFrameDimension );

			mFrameTimes = new int[ mFrameCount ];
			byte[] times = mImage.GetPropertyItem( 0x5100 ).Value;
			for( int i = 0; i < mFrameCount; i++ )
				mFrameTimes[ i ] = BitConverter.ToInt32( times, 4 * i ) * 10;
		}

		public GifHandler( string Filepath )
			: this( Image.FromFile( Filepath ) ) {
		}


		public Image GetNextFrame() {
			if( mCurrentFrameIndex >= 0 && ( DateTime.Now - mLastTime ).TotalMilliseconds < mFrameTimes[ mCurrentFrameIndex ] )
				return mCurrentFrame;

			mLastTime = DateTime.Now;
			mCurrentFrameIndex++;
			if( mCurrentFrameIndex >= mFrameCount || mCurrentFrameIndex < 1 )
				mCurrentFrameIndex = 0;

			return mCurrentFrame = GetFrame( mCurrentFrameIndex );
		}



		private Image GetFrame( int index ) {
			mImage.SelectActiveFrame( mFrameDimension, index );
			return (Image)mImage.Clone();
		}

	}

}
