using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Map_Formats {

	public class GAT {

		[Serializable]
		public enum ECellType {
			Walkable = 0,
			NoWalkable = 1,
			NoWalkableNoSnipeableWater = 2, // not snipeable
			WalkableWater = 3,
			NoWalkableSnipeableWater = 4, // snipeable
			Snipeable = 5, // snipeable
			NoSnipeable = 6,
			Unknown = 10
		};

		[Serializable]
		public struct Cell {
			public class CellHeight {
				[XmlAttribute()]
				public float UpperLeft;        // 0
				[XmlAttribute()]
				public float UpperRight;       // 4
				[XmlAttribute()]
				public float LowerLeft;        // 8
				[XmlAttribute()]
				public float LowerRight;       // 12

				public CellHeight() {
				}

				public CellHeight( float ul, float ur, float ll, float lr ) {
					UpperLeft = ul;
					UpperRight = ur;
					LowerLeft = ll;
					LowerRight = lr;
				}
			};

			[XmlElement( "CellHeight" )]
			public CellHeight Height; // 0 - 15 ( 4 x float )
			[XmlAttribute( "CellType" )]
			public ECellType Type; // 16

			[XmlIgnore]
			public char[] Unknown; // 17: 3
		};

		[Serializable]
		public struct GatFile {
			[XmlAttribute()]
			public int Width;
			[XmlAttribute()]
			public int Height;
			[XmlArray( "Cells" )]
			[XmlArrayItem( "Cell" )]
			public Cell[] Cells;
		};

		private GatFile mFile;

		public GatFile File {
			get { return mFile; }
		}

		public GAT( string Filename ) {
			Read( Filename );
		}


		private void Read( string Filename ) {
			mFile = new GatFile();

			using( FileStream s = System.IO.File.OpenRead( Filename ) ) {
				if( s.CanRead == false ) {
					try { s.Close(); } catch { }
					return;
				}
				using( BinaryReader bin = new BinaryReader( s ) ) {
					char[] magic = bin.ReadChars( 6 );
					int num_cells = 0;

					mFile.Width = bin.ReadInt32();
					mFile.Height = bin.ReadInt32();

					num_cells = ( mFile.Width * mFile.Height );
					mFile.Cells = new Cell[ num_cells ];
					for( int i = 0; i < num_cells; i++ ) {
						mFile.Cells[ i ] = new Cell();
						mFile.Cells[ i ].Height = new Cell.CellHeight(
							bin.ReadSingle(),
							bin.ReadSingle(),
							bin.ReadSingle(),
							bin.ReadSingle()
						);
						mFile.Cells[ i ].Type = Convert.Parse<ECellType>( bin.ReadByte().ToString() );
						mFile.Cells[ i ].Unknown = bin.ReadChars( 3 ); // 3x unknown Char
					}
				}
			}
		}
	}
}
