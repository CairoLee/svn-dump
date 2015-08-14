using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDataEditor.Library {

	public class ItemSData : IShaiyaSData {
		private List<ItemSDataEntry> mEntrys = new List<ItemSDataEntry>();


		public ItemSData( string Filename )
			: base( Filename ) {
		}



		public override void Open() {
			base.Open();

			int fileCount = this.ReadInt32();
			for( int i = 0; i < fileCount; i++ ) {
				int num4 = this.ReadInt32();
				for( int j = 0; j < num4; j++ ) {
					int textLen = this.ReadInt32() - 1; // exclude \0
					if( textLen < 1 ) {
						mIndex += 87;
						continue;
					}

					ItemSDataEntry item = new ItemSDataEntry();
					item.Text1 = this.ReadString( textLen );
					mIndex++; // \0

					int textLen2 = this.ReadInt32() - 1;
					item.Text2 = this.ReadString( textLen2 ).Replace( "\n\r", " ;; " );
					mIndex++; // \0

					item.MinLv = BitConverter.ToInt16( mBuffer, mIndex + 4 );
					item.Quality = mBuffer[ mIndex + 36 ];
					item.Haltbarkeit = BitConverter.ToInt16( mBuffer, mIndex + 37 );
					item.Eff1 = BitConverter.ToInt16( mBuffer, mIndex + 39 );
					item.Eff2 = BitConverter.ToInt16( mBuffer, mIndex + 41 );
					item.Eff3 = BitConverter.ToInt16( mBuffer, mIndex + 43 );
					item.Eff4 = BitConverter.ToInt16( mBuffer, mIndex + 45 );
					item.ConstHP = BitConverter.ToInt16( mBuffer, mIndex + 47 );
					item.ConstSP = BitConverter.ToInt16( mBuffer, mIndex + 49 );
					item.ConstMP = BitConverter.ToInt16( mBuffer, mIndex + 51 );
					item.ConstSTR = BitConverter.ToInt16( mBuffer, mIndex + 53 );
					item.ConstGES = BitConverter.ToInt16( mBuffer, mIndex + 55 );
					item.ConstABW = BitConverter.ToInt16( mBuffer, mIndex + 57 );
					item.ConstINT = BitConverter.ToInt16( mBuffer, mIndex + 59 );
					item.ConstWEI = BitConverter.ToInt16( mBuffer, mIndex + 61 );
					item.ConstGLU = BitConverter.ToInt16( mBuffer, mIndex + 63 );
					// o.o
					item.Preis = BitConverter.ToInt32( mBuffer, mIndex + 67 );

					// todo
					/*item.IntValues = new int[]{
						BitConverter.ToInt16( mBuffer, mIndex ),
						BitConverter.ToInt16( mBuffer, mIndex + 6 ),
						BitConverter.ToInt16( mBuffer, mIndex + 8 ),
						BitConverter.ToInt16( mBuffer, mIndex + 10 ),
						BitConverter.ToInt16( mBuffer, mIndex + 12 ),
						BitConverter.ToInt16( mBuffer, mIndex + 14 ),
						BitConverter.ToInt16( mBuffer, mIndex + 16 ),
						BitConverter.ToInt16( mBuffer, mIndex + 18 ),
						BitConverter.ToInt16( mBuffer, mIndex + 20 ),
						BitConverter.ToInt16( mBuffer, mIndex + 22 ),
						BitConverter.ToInt16( mBuffer, mIndex + 24 ),
						BitConverter.ToInt16( mBuffer, mIndex + 26 ),
						BitConverter.ToInt16( mBuffer, mIndex + 28 ),
						BitConverter.ToInt32( mBuffer, mIndex + 30 ),
						BitConverter.ToInt32( mBuffer, mIndex + 32 ),
						BitConverter.ToInt32( mBuffer, mIndex + 34 ),
					};*/

					mEntrys.Add( item );
					mIndex += 81;
				}
			}


		}

		public override void Fill( DataGridView Grid ) {
			base.Fill( Grid );

			AddColumns( Grid );
			FillData( Grid );
		}

		public override void AddColumns( DataGridView Grid ) {
			Grid.Columns.Clear();

			Grid.Columns.Add( "colRowNum", "Zeile" );
			Grid.Columns.Add( "colItemname", "Name" );
			Grid.Columns.Add( "colItemdesc", "Beschreibung" );

			Grid.Columns.Add( "colMinLv", "MinLv" ); // int 0
			Grid.Columns.Add( "colQuality", "Quality" );
			Grid.Columns.Add( "colHaltbarkeit", "Haltbarkeit" );
			Grid.Columns.Add( "colEffect1", "Eff1" );
			Grid.Columns.Add( "colEffect2", "Eff2" );
			Grid.Columns.Add( "colEffect3", "Eff3" );
			Grid.Columns.Add( "colEffect4", "Eff4" );
			Grid.Columns.Add( "colConstHP", "HP" );
			Grid.Columns.Add( "colConstSP", "SP" );
			Grid.Columns.Add( "colConstMP", "MP" );
			Grid.Columns.Add( "colConstStr", "STR" );
			Grid.Columns.Add( "colConstDex", "GES" );
			Grid.Columns.Add( "colConstRec", "ABW" );
			Grid.Columns.Add( "colConstInt", "INT" );
			Grid.Columns.Add( "colConstWis", "WEI" );
			Grid.Columns.Add( "colConstLuc", "GLU" );
			Grid.Columns.Add( "colPreis", "Preis" ); // int 16

			if( mEntrys[ 0 ].IntValues != null )
				for( int i = 0; i < mEntrys[ 0 ].IntValues.Length; i++ )
					Grid.Columns.Add( "colInt" + i, "Int" + i );
		}

		public override void FillData( DataGridView Grid ) {
			Grid.Rows.Clear();
			for( int i = 0; i < mEntrys.Count; i++ ) {
				DataGridViewRow row = new DataGridViewRow();
				row.CreateCells( Grid, mEntrys[ i ].ToRow( i ) );
				Grid.Rows.Add( row );
			}

		}

	}

}
