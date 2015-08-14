using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDataEditor.Library {

	public class QuestSData : IShaiyaSData {
		private List<QuestSDataEntry> mEntrys = new List<QuestSDataEntry>();

		public QuestSData( string Filename )
			: base( Filename ) {
		}



		public override void Open() {
			base.Open();

			int entryCount;
			int num3;
			bool flag;
			string str24;
			do {
				entryCount = this.ReadInt32();
			} while( entryCount == 0 );

			for( int e = 0; e < entryCount; e++ ) {
				QuestSDataEntry iEntry = new QuestSDataEntry();
				byte[] buffer4;
				string text = this.GetHex( mBuffer[ mIndex ] ) + this.GetHex( mBuffer[ mIndex + 1 ] ) + this.GetHex( mBuffer[ mIndex + 2 ] );
				mIndex += 3;
				string str2 = "";
				if( text.Substring( 0, 2 ) == "01" ) {
					mIndex++;
				}
				byte[] buffer = new byte[ 0x10 ];
				int num4 = 0;
				while( num4 < 0x10 ) {
					buffer[ num4 ] = mBuffer[ mIndex + num4 ];
					str2 = str2 + this.GetHex( mBuffer[ mIndex + num4 ] ) + " ";
					num4++;
				}
				mIndex += 0x10;
				int num5 = ( ( ( ( ( mBuffer[ mIndex + 3 ] * 0x100 ) * 0x100 ) * 0x100 ) + ( ( mBuffer[ mIndex + 2 ] * 0x100 ) * 0x100 ) ) + ( mBuffer[ mIndex + 1 ] * 0x100 ) ) + mBuffer[ mIndex ];
				mIndex += 4;
				byte[] bytes = new byte[ num5 ];
				num4 = 0;
				while( num4 < num5 ) {
					bytes[ num4 ] = mBuffer[ mIndex + num4 ];
					num4++;
				}
				mIndex += num5;
				string str3 = IShaiyaSData.Encoding.GetString( bytes );
				int num6 = ( ( ( ( ( mBuffer[ mIndex + 3 ] * 0x100 ) * 0x100 ) * 0x100 ) + ( ( mBuffer[ mIndex + 2 ] * 0x100 ) * 0x100 ) ) + ( mBuffer[ mIndex + 1 ] * 0x100 ) ) + mBuffer[ mIndex ];
				mIndex += 4;
				byte[] buffer3 = new byte[ num6 ];
				num4 = 0;
				while( num4 < num6 ) {
					buffer3[ num4 ] = mBuffer[ mIndex + num4 ];
					num4++;
				}
				mIndex += num6;
				string str4 = IShaiyaSData.Encoding.GetString( buffer3 ).Replace( "\r\n", "&lt;br /&gt;" );
				string str5 = "";
				if( text.Substring( 0, 2 ) == "01" ) {
					int num7 = ( ( ( ( ( mBuffer[ mIndex + 3 ] * 0x100 ) * 0x100 ) * 0x100 ) + ( ( mBuffer[ mIndex + 2 ] * 0x100 ) * 0x100 ) ) + ( mBuffer[ mIndex + 1 ] * 0x100 ) ) + mBuffer[ mIndex ];
					mIndex += 4;
					buffer4 = new byte[ num7 * 2 ];
					num4 = 0;
					while( num4 < ( num7 * 2 ) ) {
						buffer4[ num4 ] = mBuffer[ mIndex + num4 ];
						str5 = str5 + this.GetHex( mBuffer[ mIndex + num4 ] ) + " ";
						num4++;
					}
					mIndex += num7 * 2;
				} else if( text.Substring( 0, 2 ) == "02" ) {
					for( int i = 0; i < 3; i++ ) {
						buffer4 = new byte[ 14 ];
						num4 = 0;
						while( num4 < 14 ) {
							buffer4[ num4 ] = mBuffer[ mIndex + num4 ];
							str5 = str5 + this.GetHex( mBuffer[ mIndex + num4 ] ) + " ";
							num4++;
						}
						mIndex += 14;
						int num9 = ( ( ( ( ( mBuffer[ mIndex + 3 ] * 0x100 ) * 0x100 ) * 0x100 ) + ( ( mBuffer[ mIndex + 2 ] * 0x100 ) * 0x100 ) ) + ( mBuffer[ mIndex + 1 ] * 0x100 ) ) + mBuffer[ mIndex ];
						mIndex += 4;
						byte[] buffer5 = new byte[ num9 ];
						num4 = 0;
						while( num4 < num9 ) {
							buffer5[ num4 ] = mBuffer[ mIndex + num4 ];
							num4++;
						}
						mIndex += num9;
						str24 = str5 + IShaiyaSData.Encoding.GetString( buffer5 ) + " ";
						str5 = str24 + this.GetHex( mBuffer[ mIndex ] ) + " " + this.GetHex( mBuffer[ mIndex + 1 ] ) + " " + this.GetHex( mBuffer[ mIndex + 2 ] ) + " " + this.GetHex( mBuffer[ mIndex + 3 ] ) + " | ";
						mIndex += 4;
					}
				}
				int num10 = ( ( ( ( ( mBuffer[ mIndex + 3 ] * 0x100 ) * 0x100 ) * 0x100 ) + ( ( mBuffer[ mIndex + 2 ] * 0x100 ) * 0x100 ) ) + ( mBuffer[ mIndex + 1 ] * 0x100 ) ) + mBuffer[ mIndex ];
				mIndex += 4;
				byte[] buffer6 = new byte[ num10 * 2 ];
				string str6 = "";
				num4 = 0;
				while( num4 < ( num10 * 2 ) ) {
					buffer6[ num4 ] = mBuffer[ mIndex + num4 ];
					str6 = str6 + this.GetHex( mBuffer[ mIndex + num4 ] ) + " ";
					num4++;
				}
				mIndex += num10 * 2;
				int num11 = ( ( ( ( ( mBuffer[ mIndex + 3 ] * 0x100 ) * 0x100 ) * 0x100 ) + ( ( mBuffer[ mIndex + 2 ] * 0x100 ) * 0x100 ) ) + ( mBuffer[ mIndex + 1 ] * 0x100 ) ) + mBuffer[ mIndex ];
				mIndex += 4;
				byte[] buffer7 = new byte[ num11 * 2 ];
				string str7 = "";
				for( num4 = 0; num4 < ( num11 * 2 ); num4++ ) {
					buffer7[ num4 ] = mBuffer[ mIndex + num4 ];
					str7 = str7 + this.GetHex( mBuffer[ mIndex + num4 ] ) + " ";
				}
				mIndex += num11 * 2;

				iEntry.text = text;
				iEntry.str2 = str2;
				iEntry.str3 = str3;
				iEntry.str4 = str4;
				iEntry.str5 = str5;
				iEntry.str6 = str6;
				iEntry.str7 = str7;
				iEntry.num5 = num5;
				iEntry.num6 = num6;
				iEntry.num10 = num10;
				iEntry.num11 = num11;

				mEntrys.Add( iEntry );
			}
		}

		public override void Fill( DataGridView Grid ) {
			base.Fill( Grid );
		}

		public override void AddColumns( DataGridView Grid ) {
			Grid.Columns.Clear();

			Grid.Columns.Add( "text", "Zeile" );
			Grid.Columns.Add( "text", "text" );
			Grid.Columns.Add( "str3", "str3" );
			Grid.Columns.Add( "num5", "num5" );
			Grid.Columns.Add( "str4", "str4" );
			Grid.Columns.Add( "num6", "num6" );
			Grid.Columns.Add( "str5", "str5" );
			Grid.Columns.Add( "str6", "str6" );
			Grid.Columns.Add( "num10", "num10" );
			Grid.Columns.Add( "str7", "str7" );
			Grid.Columns.Add( "num11", "num11" );
			Grid.Columns.Add( "str2", "str2" );
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
