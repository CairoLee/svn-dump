using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace InsaneRO.Cards.Library.Formats {

	public class RagnarokAnimationImage {
		private ushort mWidth;
		private ushort mHeight;
		private int mSize;
		private byte[] mData;

		private bool mDecoded;

		public ushort Width {
			get { return mWidth; }
			set { mWidth = value; }
		}

		public ushort Height {
			get { return mHeight; }
			set { mHeight = value; }
		}

		public int Size {
			get { return mSize; }
			set { mSize = value; }
		}

		public byte[] Data {
			get { return mData; }
			set {
				mData = value;
				mDecoded = false;
			}
		}

		public bool Decoded {
			get { return mDecoded; }
		}


		public RagnarokAnimationImage() {
			mDecoded = false;
		}


		public byte[] DecodedData() {
			if( Decoded == true )
				return mData;

			mData = InsaneRO.Cards.Library.Cryptic.RLE.Decode( mData );
			mDecoded = true;
			return mData;
		}

		public byte[] EncodedData() {
			if( Decoded == false )
				return mData;

			mData = InsaneRO.Cards.Library.Cryptic.RLE.Encode( mData );
			mDecoded = false;
			return mData;
		}


		public Texture2D BuildTexture2D( RagnarokAnimationPalette Palette, GraphicsDevice Device ) {
			byte[] data = DecodedData();
			Texture2D tex = new Texture2D( Device, Width, Height );
			Color[] colors = new Color[ Width * Height ];

			/*int index;
			for( int x = 0; x < Width; x++ ) {
				for( int y = 0; y < Height; y++ ) {
					index = ( x + ( y * Width ) );
					if( index >= data.Length )
						colors[ index ] = Color.TransparentWhite;
					else
						colors[ index ] = Palette[ data[ index ] ];
				}
			}*/
			for( int i = 0; i < colors.Length; i++ ) {
				// make first index transparent
				if( i >= data.Length || data[ i ] == 0 )
					colors[ i ] = Color.Transparent;
				else
					colors[ i ] = Palette[ data[ i ] ];
			}
			tex.SetData<Color>( colors );

			data = null;
			colors = null;

			return tex;
		}

	}

}
