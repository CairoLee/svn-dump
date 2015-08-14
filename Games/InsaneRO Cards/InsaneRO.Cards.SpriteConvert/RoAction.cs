using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;

namespace InsaneRO.Cards.SpriteConvert {

	public class RoAction {
		public class RoActionPattern {
			public List<RoActionPatternFrame> Frames;
		}

		public class RoActionPatternFrame {
			public uint Palette1;
			public uint Palette2;
			public int Audio;
			public int Numxxx;
			public int Ext1;
			public int ExtX;
			public int ExtY;
			public int Terminate;
			public List<RoActionPatternFrameSprite> Sprites;
		}

		public class RoActionPatternFrameSprite {
			public uint X;
			public uint Y;
			public uint Number;
			public uint Mirror;

			// Major > 2
			public byte ColorR;
			public byte ColorG;
			public byte ColorB;
			public byte ColorA;
			public float ScaleXY; // only: Major <= 3 && Minor <= 2
			public float ScaleX; // else
			public float ScaleY; // ^
			public uint Rotation;
			public uint Type;

			// Major >= 5
			public uint Width;
			public uint Height;
		}

		private BinaryReader mReader;
		private string mFilepath;

		private List<RoActionPattern> mActions;
		private List<string> mSounds;



		public BinaryReader Reader {
			get { return mReader; }
		}

		public string Filepath {
			get { return mFilepath; }
		}

		public List<RoActionPattern> Actions {
			get { return mActions; }
		}

		public List<string> Sounds {
			get { return mSounds; }
		}



		public RoAction() {
		}



		public bool Read( string Filepath ) {
			if( File.Exists( Filepath ) == false )
				return false;

			mFilepath = Filepath;
			using( mReader = new BinaryReader( File.OpenRead( Filepath ) ) ) {
				char[] header = mReader.ReadChars( 2 );
				byte major = mReader.ReadByte();
				byte minor = mReader.ReadByte();
				ushort actionCount = mReader.ReadUInt16();
				mReader.BaseStream.Position += 10; // unknown [ushort, uint, uint]

				mActions = new List<RoActionPattern>();
				for( int i = 0; i < actionCount; i++ ) {
					RoActionPattern act = new RoActionPattern();
					act.Frames = new List<RoActionPatternFrame>();

					uint frameCount = mReader.ReadUInt32();
					for( int f = 0; f < frameCount; f++ ) {
						RoActionPatternFrame frame = new RoActionPatternFrame();
						frame.Sprites = new List<RoActionPatternFrameSprite>();

						frame.Palette1 = mReader.ReadUInt32();
						frame.Palette2 = mReader.ReadUInt32();
						mReader.BaseStream.Position += 24; // 12x ushort

						uint spriteCount = mReader.ReadUInt32();
						for( int s = 0; s < spriteCount; s++ ) {
							RoActionPatternFrameSprite sprite = new RoActionPatternFrameSprite();

							sprite.X = mReader.ReadUInt32();
							sprite.Y = mReader.ReadUInt32();
							int num = mReader.ReadInt32();
							// TODO: google this!
							// every/most/many frames seems to have first sprite -1
							if( num == -1 )
								continue;

							sprite.Number = (uint)num;

							sprite.Mirror = mReader.ReadUInt32();
							if( major > 2 ) {
								sprite.ColorR = mReader.ReadByte();
								sprite.ColorG = mReader.ReadByte();
								sprite.ColorB = mReader.ReadByte();
								sprite.ColorA = mReader.ReadByte();

								if( major <= 3 && minor <= 2 )
									sprite.ScaleXY = mReader.ReadSingle();
								else {
									sprite.ScaleX = mReader.ReadSingle();
									sprite.ScaleY = mReader.ReadSingle();
								}

								sprite.Rotation = mReader.ReadUInt32();
								sprite.Type = mReader.ReadUInt32();

								if( major >= 5 ) {
									sprite.Width = mReader.ReadUInt32();
									sprite.Height = mReader.ReadUInt32();
								}
							}

							frame.Sprites.Add( sprite );
						}

						frame.Audio = mReader.ReadInt32();
						frame.Numxxx = mReader.ReadInt32();
						if( frame.Numxxx == 1 ) {
							frame.Ext1 = mReader.ReadInt32();
							frame.ExtX = mReader.ReadInt32();
							frame.ExtY = mReader.ReadInt32();
							frame.Terminate = mReader.ReadInt32();
						}

						act.Frames.Add( frame );
					}

					mActions.Add( act );
				}


				mSounds = new List<string>();
				uint soundCount = mReader.ReadUInt32();
				for( int i = 0; i < soundCount; i++ ) {
					string name = "";
					char c = '\0';
					for( int n = 0; n < 40; n++ )
						if( ( c = mReader.ReadChar() ) != '\0' )
							name += c;
					mSounds.Add( name );
				}

			}

			return true;
		}

	}

}
