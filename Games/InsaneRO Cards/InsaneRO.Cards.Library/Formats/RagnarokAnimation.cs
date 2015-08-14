using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace InsaneRO.Cards.Library.Formats {

	public class RagnarokAnimation {
		protected BinaryReader mReader;
		protected BinaryWriter mWriter;

		private List<RagnarokAnimationImage> mImages;
		private RagnarokAnimationPalette mPalette;
		private RagnarokAnimationActionList mActions;
		private List<string> mActionSounds;

		public BinaryReader Reader {
			get { return mReader; }
		}

		public BinaryWriter Writer {
			get { return mWriter; }
		}

		public RagnarokAnimationImage this[ int Index ] {
			get { return mImages[ Index ]; }
		}

		public List<RagnarokAnimationImage> Images {
			get { return mImages; }
			set { mImages = value; }
		}

		public RagnarokAnimationPalette Palette {
			get { return mPalette; }
			set { mPalette = value; }
		}

		public RagnarokAnimationActionList Actions {
			get { return mActions; }
			set { mActions = value; }
		}

		public List<string> ActionSounds {
			get { return mActionSounds; }
			set { mActionSounds = value; }
		}


		public RagnarokAnimation() {
		}


		public bool Read( string Filepath, bool CloseStream ) {
			if( File.Exists( Filepath ) == false )
				return false;

			bool result = false;
			FileStream fs = File.OpenRead( Filepath );
			result = Read( fs );
			if( CloseStream == true )
				fs.Dispose();

			return result;
		}

		public bool Read( Stream stream ) {
			mReader = new BinaryReader( stream );

			int imgCount = Reader.ReadUInt16();

			// Image Data \\
			mImages = new List<RagnarokAnimationImage>();
			for( int i = 0; i < imgCount; i++ ) {
				mImages.Add( new RagnarokAnimationImage() );
				mImages[ i ].Width = Reader.ReadUInt16();
				mImages[ i ].Height = Reader.ReadUInt16();
				int size = Reader.ReadInt32();
				mImages[ i ].Data = Reader.ReadBytes( size );
			}

			// Palette \\
			mPalette = new RagnarokAnimationPalette( 256 );
			for( int i = 0; i < 256; i++ )
				mPalette.ReadColor( Reader );

			// Actions \\
			mActions = new RagnarokAnimationActionList();
			int actCount = mReader.ReadUInt16();
			for( int i = 0; i < actCount; i++ ) {
				RagnarokAnimationAction action = new RagnarokAnimationAction();
				action.Frames = new RagnarokAnimationActionFrameList();
				int frameCount = mReader.ReadUInt16();
				for( int f = 0; f < frameCount; f++ ) {
					RagnarokAnimationActionFrame frame = new RagnarokAnimationActionFrame();
					frame.Images = new RagnarokAnimationActionFrameImageList();
					frame.Palette1 = mReader.ReadUInt32();
					frame.Palette2 = mReader.ReadUInt32();
					frame.Audio = mReader.ReadInt32();
					frame.Numxxx = mReader.ReadInt32();
					if( frame.Numxxx == 1 ) {
						frame.Ext1 = mReader.ReadInt32();
						frame.ExtX = mReader.ReadInt32();
						frame.ExtY = mReader.ReadInt32();
						frame.Terminate = mReader.ReadInt32();
					}

					int imageCount = mReader.ReadUInt16();
					for( int s = 0; s < imageCount; s++ ) {
						RagnarokAnimationActionFrameImage img = new RagnarokAnimationActionFrameImage() {
							X = mReader.ReadInt16(),
							Y = mReader.ReadInt16(),
							Number = mReader.ReadUInt16(),
							Mirror = mReader.ReadBoolean(),
							Color = new Color( mReader.ReadByte(), mReader.ReadByte(), mReader.ReadByte(), mReader.ReadByte() ),
							ScaleX = mReader.ReadSingle(),
							ScaleY = mReader.ReadSingle(),
							Rotation = mReader.ReadInt16(),
							Type = mReader.ReadInt16(),
							Width = mReader.ReadUInt16(),
							Height = mReader.ReadUInt16(),
						};

						frame.Images.Add( img );
					}
					action.Frames.Add( frame );
				}
				mActions.Add( action );
			}

			// Sounds \\
			mActionSounds = new List<string>();
			int soundCount = Reader.ReadUInt16();
			for( int i = 0; i < soundCount; i++ )
				mActionSounds.Add( Reader.ReadString() );

			return true;
		}


		public bool Write( string Filepath, bool CloseStream ) {
			if( File.Exists( Filepath ) == true )
				File.Delete( Filepath );

			bool result = false;
			FileStream fs = File.OpenWrite( Filepath );
			result = Write( fs );
			if( CloseStream == true )
				fs.Dispose();

			return result;
		}

		public bool Write( Stream stream ) {
			mWriter = new BinaryWriter( stream );

			mWriter.Write( (ushort)mImages.Count );

			// Image Data \\
			for( int i = 0; i < mImages.Count; i++ ) {
				mWriter.Write( (ushort)mImages[ i ].Width );
				mWriter.Write( (ushort)mImages[ i ].Height );
				mWriter.Write( (int)mImages[ i ].Data.Length );
				mWriter.Write( mImages[ i ].Data );
			}

			// Palette \\
			for( int i = 0; i < mPalette.Count; i++ )
				mPalette.WriteColor( i, mWriter );

			// Actions \\
			mWriter.Write( (ushort)mActions.Count );
			for( int i = 0; i < mActions.Count; i++ ) {
				mWriter.Write( (ushort)mActions[ i ].Frames.Count );
				for( int f = 0; f < mActions[ i ].Frames.Count; f++ ) {
					RagnarokAnimationActionFrame frame = mActions[ i ].Frames[ f ];
					mWriter.Write( (uint)frame.Palette1 );
					mWriter.Write( (uint)frame.Palette2 );
					mWriter.Write( (int)frame.Audio );
					mWriter.Write( (int)frame.Numxxx );
					if( frame.Numxxx == 1 ) {
						mWriter.Write( (int)frame.Ext1 );
						mWriter.Write( (int)frame.ExtX );
						mWriter.Write( (int)frame.ExtY );
						mWriter.Write( (int)frame.Terminate );
					}

					mWriter.Write( (ushort)frame.Images.Count );
					for( int s = 0; s < frame.Images.Count; s++ ) {
						Writer.Write( (short)frame.Images[ s ].X );
						Writer.Write( (short)frame.Images[ s ].Y );
						Writer.Write( (ushort)frame.Images[ s ].Number );
						Writer.Write( (bool)frame.Images[ s ].Mirror );
						Writer.Write( (byte)frame.Images[ s ].Color.R );
						Writer.Write( (byte)frame.Images[ s ].Color.G );
						Writer.Write( (byte)frame.Images[ s ].Color.B );
						Writer.Write( (byte)frame.Images[ s ].Color.A );
						Writer.Write( (float)frame.Images[ s ].ScaleX );
						Writer.Write( (float)frame.Images[ s ].ScaleY );
						Writer.Write( (short)frame.Images[ s ].Rotation );
						Writer.Write( (short)frame.Images[ s ].Type );
						Writer.Write( (ushort)frame.Images[ s ].Width );
						Writer.Write( (ushort)frame.Images[ s ].Height );
					}
				}
			}

			// Sounds \\
			mWriter.Write( (ushort)mActionSounds.Count );
			for( int i = 0; i < mActionSounds.Count; i++ )
				mWriter.Write( mActionSounds[ i ] );


			return true;
		}


	}

}
