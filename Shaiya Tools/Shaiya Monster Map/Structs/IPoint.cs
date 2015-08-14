using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShaiyaMonsterMap {

	public partial class IPoint : IEquatable<IPoint> {
		public static int FalseDefault = -9999;
		public static int ImageSize = 12;

		public int ID = 0;

		public bool Marked = false;
		public bool Changed = false;

		protected int mX;
		protected int mY;
		protected int mRectX = FalseDefault;
		protected int mRectY = FalseDefault;
		protected int mRectWidth = FalseDefault;
		protected int mRectHeight = FalseDefault;
		protected ShaiyaMonsterMap.Structs.GifHandler mGifHandler = new ShaiyaMonsterMap.Structs.GifHandler( Properties.Resources.MobMarkedAni );

		public int X {
			get { return mX; }
			set {
				mX = value;
				mRectX = FalseDefault;
				mRectWidth = FalseDefault;
			}
		}

		public int Y {
			get { return mY; }
			set {
				mY = value;
				mRectY = FalseDefault;
				mRectHeight = FalseDefault;
			}
		}

		public int RectX {
			get {
				if( mRectX == FalseDefault )
					mRectX = X - ( ImageSize / 2 );
				return mRectX;
			}
		}

		public int RectY {
			get {
				if( mRectY == FalseDefault )
					mRectY = Y - ( ImageSize / 2 );
				return mRectY;
			}
		}

		public int RectWidth {
			get {
				if( mRectWidth == FalseDefault )
					mRectWidth = X + ( ImageSize / 2 );
				return mRectWidth;
			}
		}

		public int RectHeight {
			get {
				if( mRectHeight == FalseDefault )
					mRectHeight = Y + ( ImageSize / 2 );
				return mRectHeight;
			}
		}

		public ShaiyaMonsterMap.Structs.GifHandler Gif {
			get { return mGifHandler; }
		}




		public bool Equals( IPoint other ) {
			if( this.ID != other.ID )
				return false;
			if( this.Marked != other.Marked )
				return false;
			if( this.Changed != other.Changed )
				return false;
			if( this.X != other.X )
				return false;
			if( this.Y != other.Y )
				return false;

			return true;
		}

	}


}
