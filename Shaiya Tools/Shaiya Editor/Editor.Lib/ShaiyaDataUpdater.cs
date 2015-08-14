using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Editor.Lib {

	public class ShaiyaDataUpdater {
		public static event ShaiyaWriteFileData OnWriteFile;

		public static void SaveData( ShaiyaData Data ) {
			// delete Header, we rewrite it
			if( File.Exists( Data.BasePath + ".sah" ) )
				File.Delete( Data.BasePath + ".sah" );

			// save Header File
			using( FileStream fs = File.OpenWrite( Data.BasePath + ".sah" ) ) {
				WriteHead( fs );
				WriteFileStructure( fs, Data.Files );
			}

			// save new/updated File Data
			using( FileStream fs = File.OpenWrite( Data.BasePath + ".saf" ) )
				WriteFileData( fs, Data );

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

			// write Filedata
			for( int i = 0; i < DataEntrys.Count; i++ ) {
				if( DataEntrys[ i ].IsDir == true )
					continue;

				fs.Write( BitConverter.GetBytes( DataEntrys[ i ].Filename.Length + 1 ), 0, 4 ); // Namelength + \0
				for( int f = 0; f < DataEntrys[ i ].Filename.Length; f++ )
					fs.Write( BitConverter.GetBytes( DataEntrys[ i ].Filename[ f ] ), 0, 1 );
				fs.Write( BitConverter.GetBytes( '\0' ), 0, 1 );
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
				fs.Write( BitConverter.GetBytes( '\0' ), 0, 1 );

				// Entrydata
				WriteFileStructure( fs, DataEntrys[ i ].Entrys );
			}

		}

		private static void WriteFileData( FileStream fs, ShaiyaData Data ) {
			foreach( ShaiyaDataEntry Entry in Data.FilesFlat.Values ) {
				if( Entry.IsDir ) 
					continue;

				if( Entry.Buffer == null ) // not changed or new
					continue;

				if( OnWriteFile != null )
					OnWriteFile( Entry, 0 );

				System.Diagnostics.Debug.WriteLine( "[updated] " + Entry.Filename );

				fs.Seek( Entry.Offset, SeekOrigin.Begin );
				fs.Write( Entry.Buffer, 0, Entry.Buffer.Length );

				Data.FilesFlat[ Entry.ID ].Buffer = null; // updated
			}

			System.Diagnostics.Debug.WriteLine( "saving done" );
		}

	}

}
