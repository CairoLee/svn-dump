using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Editor.Lib {

	public delegate void ShaiyaWriteFileData( ShaiyaDataEntry Entry, int Num );

	public class ShaiyaDataRepacker {
		public static event ShaiyaWriteFileData OnWriteFile;

		public static void SaveData( ShaiyaData Data, string SavePath ) {
			string baseSavePath = Path.GetDirectoryName( SavePath );
			string nameSavePath = Path.GetFileNameWithoutExtension( SavePath );
			string tempPrefix = "__tmp__";
			SavePath = baseSavePath + @"\" + tempPrefix + nameSavePath;

			// save File Data (updates offsets)
			using( FileStream fs = File.OpenWrite( SavePath + ".saf" ) )
				WriteFileData( fs, Data );

			// save Header File (with new offsets)
			using( FileStream fs = File.OpenWrite( SavePath + ".sah" ) ) {
				WriteHead( fs );
				WriteFileStructure( fs, Data.Files );
			}


			// remove tmpPrefix, delete existing Files & rename tmp's
			string newSavePath = SavePath.Replace( tempPrefix, "" );
			if( File.Exists( newSavePath + ".sah" ) )
				File.Delete( newSavePath + ".sah" );
			if( File.Exists( newSavePath + ".saf" ) )
				File.Delete( newSavePath + ".saf" );

			File.Move( SavePath + ".sah", newSavePath + ".sah" );
			File.Move( SavePath + ".saf", newSavePath + ".saf" );

			if( OnWriteFile != null )
				OnWriteFile( null, 100 );
		}



		private static void WriteHead( FileStream fs ) {
			byte[] data = ShaiyaDataWriterHelper.GetHeader();

			fs.Write( data, 0, data.Length );
		}

		private static void WriteFileStructure( FileStream fs, List<ShaiyaDataEntry> DataEntrys ) {
			if( DataEntrys == null || DataEntrys.Count == 0 )
				return;

			int fCount = 0, dCount = 0;
			while( fCount + dCount < DataEntrys.Count )
				if( DataEntrys[ fCount ].IsDir == false )
					fCount++;
				else
					dCount++;

			// Filecount
			fs.Write( BitConverter.GetBytes( fCount ), 0, 4 );

			// write Fileinfo
			for( int i = 0; i < DataEntrys.Count; i++ ) {
				if( DataEntrys[ i ].IsDir == true )
					continue;

				fs.Write( BitConverter.GetBytes( DataEntrys[ i ].Filename.Length + 1 ), 0, 4 ); // Namelength + \0
				for( int f = 0; f < DataEntrys[ i ].Filename.Length; f++ )
					fs.Write( BitConverter.GetBytes( DataEntrys[ i ].Filename[ f ] ), 0, 1 );
				fs.Write( BitConverter.GetBytes( 0 ), 0, 1 );
				fs.Write( BitConverter.GetBytes( (long)DataEntrys[ i ].Offset ), 0, 8 ); // Offset
				fs.Write( BitConverter.GetBytes( (int)DataEntrys[ i ].Length ), 0, 4 ); // Length
				fs.Write( DataEntrys[ i ].UnkownValue, 0, DataEntrys[ i ].UnkownValue.Length );
			}

			// Dircount
			fs.Write( BitConverter.GetBytes( dCount ), 0, 4 );

			// write Dirdata
			for( int i = 0; i < DataEntrys.Count; i++ ) {
				if( DataEntrys[ i ].IsDir == false )
					continue;

				fs.Write( BitConverter.GetBytes( DataEntrys[ i ].Filename.Length + 1 ), 0, 4 ); // Namelength + \0
				for( int f = 0; f < DataEntrys[ i ].Filename.Length; f++ )
					fs.Write( BitConverter.GetBytes( DataEntrys[ i ].Filename[ f ] ), 0, 1 );
				fs.Write( BitConverter.GetBytes( 0 ), 0, 1 );

				// Entrydata
				WriteFileStructure( fs, DataEntrys[ i ].Entrys );
			}

		}

		private static void WriteFileData( FileStream fs, ShaiyaData Data ) {
			byte[] buf;
			int i = 0;
			foreach( ShaiyaDataEntry Entry in Data.FilesFlat.Values ) {
				if( Entry.IsDir ) {
					i++;
					continue;
				}

				if( OnWriteFile != null )
					OnWriteFile( Entry, i );

				if( Data.GetData( Entry, out buf ) == false || buf == null || buf.Length == 0 ) {
					i++;
					continue;
				}

				// update new Offset
				Data[ Entry.ID ].Offset = fs.Position;
				fs.Write( buf, 0, buf.Length );

				buf = null;
				i++;
			}

		}

	}

}
