using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using InsaneRO.Cards.Library.Formats;

namespace InsaneRO.Cards.SpriteConvert {

	public class RoSprite {
		protected BinaryReader mReader;
		protected BinaryWriter mWriter;
		protected string mFilepath;

		public class SpriteImage {
			public ushort Width;
			public ushort Height;
			public ushort Size;
			public byte[] Data;
		}

		private char[] mMagicHead;
		private bool mCompression;
		private byte mUnknown;
		private byte[] mUnknown2;
		private List<SpriteImage> mImages;
		private RoSpritePalette mPalette;

		public BinaryReader Reader {
			get { return mReader; }
		}

		public BinaryWriter Writer {
			get { return mWriter; }
		}

		public string Filepath {
			get { return mFilepath; }
		}

		public bool Compressed {
			get { return mCompression; }
		}

		public SpriteImage this[ int Index ] {
			get { return mImages[ Index ]; }
		}

		public List<SpriteImage> Images {
			get { return mImages; }
		}

		public RoSpritePalette Palette {
			get { return mPalette; }
		}



		public RoSprite() {
		}



		public bool Read( string Filepath ) {
			if( File.Exists( Filepath ) == false )
				return false;

			mFilepath = Filepath;
			mReader = new BinaryReader( File.OpenRead( Filepath ) );

			mMagicHead = Reader.ReadChars( 2 );
			mCompression = ( Reader.ReadByte() > 0 ? true : false );
			mUnknown = Reader.ReadByte();
			int imgCount = Reader.ReadUInt16();
			mUnknown2 = Reader.ReadBytes( 2 );

			// Image Data \\
			mImages = new List<SpriteImage>();
			for( int i = 0; i < imgCount; i++ ) {
				mImages.Add( new SpriteImage() );
				mImages[ i ].Width = Reader.ReadUInt16();
				mImages[ i ].Height = Reader.ReadUInt16();
				if( mCompression == true )
					mImages[ i ].Size = Reader.ReadUInt16();
				else
					mImages[ i ].Size = (ushort)( mImages[ i ].Width * mImages[ i ].Height );
				mImages[ i ].Data = Reader.ReadBytes( mImages[ i ].Size );
			}

			// Palette \\
			mPalette = new RoSpritePalette( 256 );
			Reader.BaseStream.Position = ( Reader.BaseStream.Length - ( 4 * 256 ) );
			for( int i = 0; i < 256; i++ )
				mPalette.Add( Reader.ReadRoSpriteColor() );

			return true;
		}

	}

}
