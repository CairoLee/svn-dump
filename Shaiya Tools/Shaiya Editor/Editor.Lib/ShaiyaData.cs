using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Editor.Lib {

	// saf = File Data
	// sah = File Offsets [absolute]

	public class ShaiyaData : IDisposable {
		public static int StartOffset = 56; // 0x38
		public static Encoding Encoding = Encoding.GetEncoding( "GB2312" );

		private ShaiyaDataEntryList mFiles = new ShaiyaDataEntryList();
		private Dictionary<string, ShaiyaDataEntry> mFilesFlat = new Dictionary<string, ShaiyaDataEntry>();

		private string mBasePath;
		private int Offset = 0;
		private byte[] Buffer;

		public ShaiyaDataEntry this[ int Index ] {
			get { return mFiles[ Index ]; }
			set {
				if( value == null )
					mFilesFlat[ mFiles[ Index ].ID ] = value;
				else
					mFilesFlat[ value.ID ] = value;
				mFiles[ Index ] = value;
			}
		}

		public ShaiyaDataEntry this[ string Index ] {
			get { return mFilesFlat[ Index ]; }
		}

		public ShaiyaDataEntryList Files {
			get { return mFiles; }
			set { mFiles = value; }
		}

		public Dictionary<string, ShaiyaDataEntry> FilesFlat {
			get { return mFilesFlat; }
		}

		public string BasePath {
			get { return mBasePath; }
		}


		public ShaiyaData() {
		}

		public ShaiyaData( string Name ) {
			Read( Name );
		}

		~ShaiyaData() {
			Dispose();
		}


		public void Read( string Name ) {
			mBasePath = Name.Substring( 0, Name.LastIndexOf( '.' ) );

			Offset = StartOffset;
			using( FileStream fs = File.OpenRead( Name ) ) {
				Buffer = new byte[ (int)fs.Length ];
				fs.Read( Buffer, 0, (int)fs.Length );
			}

			mFiles = new ShaiyaDataEntryList();

			mFiles.AddRange( ReadFiles( "" ) );
			mFiles.AddRange( ReadDirs( "" ) );

			// cleanup
			Offset = 0;
			Buffer = null;
		}

		public bool Repack( string SavePath, ShaiyaWriteFileData OnWriteData ) {
			if( OnWriteData != null )
				ShaiyaDataRepacker.OnWriteFile += OnWriteData;
			ShaiyaDataRepacker.SaveData( this, SavePath );

			return true;
		}

		public bool Save( ShaiyaWriteFileData OnWriteData ) {
			if( OnWriteData != null )
				ShaiyaDataUpdater.OnWriteFile += OnWriteData;
			ShaiyaDataUpdater.SaveData( this );

			return true;
		}

		public bool ExtractAll( string RootDir ) {
			bool result = true;
			for( int i = 0; i < Files.Count; i++ ) {
				if( ExtractFile( Files[ i ].ID, RootDir ) == false )
					result = false;
			}
			return result;
		}

		public bool ExtractFile( string FlatName, string RootDir ) {
			byte[] buffer;
			Editor.Lib.ShaiyaDataEntry entry;
			try {
				entry = GetFlatEntry( FlatName );
				if( entry == null )
					return false;

				if( entry.IsDir == true ) {
					bool result = true;
					for( int i = 0; i < entry.Entrys.Count; i++ ) {
						if( ExtractFile( entry.Entrys[ i ].ID, RootDir ) == false )
							result = false;
					}
					return result;
				}

				GetData( entry, out buffer );


				string dataDir = GetRootDir( entry );
				string saveInDir = Path.Combine( RootDir, dataDir ) + @"\" + entry.Filename;
				Directory.CreateDirectory( Path.GetDirectoryName( saveInDir ) );
				File.WriteAllBytes( saveInDir, buffer );

				entry = null;
				buffer = null;
				return true;
			} catch( Exception ex ) {
				System.Diagnostics.Debug.WriteLine( ex );

				entry = null;
				buffer = null;
				return false;
			}

		}


		public void Dispose() {
			for( int i = 0; i < Files.Count; i++ )
				Files[ i ].Dispose();
		}


		public ShaiyaDataEntry GetFlatEntry( string GuidString ) {
			if( mFilesFlat.ContainsKey( GuidString ) == false )
				return null;
			return mFilesFlat[ GuidString ];
		}

		public ShaiyaDataEntry GetEntry( string GuidString ) {
			if( mFilesFlat.ContainsKey( GuidString ) == false )
				return null;
			return mFilesFlat[ GuidString ];
		}

		public string GetRootDir( ShaiyaDataEntry baseEntry ) {
			ShaiyaDataEntry tmpEntry = baseEntry;
			List<string> rootDir = new List<string>();
			while( ( tmpEntry = GetFlatEntry( tmpEntry.ParentID ) ) != null )
				rootDir.Add( tmpEntry.Filename );

			rootDir.Reverse();
			return string.Join( @"\", rootDir.ToArray() );
		}

		public int GetFileCount( ShaiyaDataEntry Entry, bool Deep ) {
			if( Entry.IsDir == false )
				return 0;

			int count = 0;
			foreach( ShaiyaDataEntry e in Entry.Entrys ) {
				if( e.IsDir == false )
					count++;
				else {
					if( Deep == true )
						count += GetFileCount( e );
					else
						count++;
				}
			}

			return count;
		}

		public int GetFileCount( ShaiyaDataEntry Entry ) {
			return GetFileCount( Entry, true );
		}

		public bool GetData( ShaiyaDataEntry Entry, out byte[] buf ) {
			if( Entry.Buffer != null ) { // new/updated File
				buf = Entry.Buffer.Clone() as byte[];
				return true;
			}

			buf = new byte[ Entry.Length ];
			try {
				using( FileStream stream = File.OpenRead( BasePath + ".saf" ) ) {
					stream.Seek( Entry.Offset, SeekOrigin.Begin );
					stream.Read( buf, 0, buf.Length );
				}
			} catch {
				return false;
			}

			return true;
		}

		public bool UpdateFile( string ID, string Filepath ) {
			ShaiyaDataEntry Entry = mFilesFlat[ ID ];
			byte[] buf = File.ReadAllBytes( Filepath );

			// fill Buffer for newly added or updated Files
			Entry.Buffer = buf.Clone() as byte[];
			Entry.Offset = new FileInfo( this.BasePath + ".saf" ).Length;
			Entry.Length = Entry.Buffer.Length;
			Entry.Filename = Path.GetFileName( Filepath );

			//mFiles.UpdateEntry( ID, Entry ); // referenced, no need to update *-*
			buf = null;

			return true;
		}

		public bool AddFile( ShaiyaDataEntry ParentEntry, string Filepath, out ShaiyaDataEntry NewEntry ) {
			NewEntry = null;
			if( ParentEntry.IsDir == false )
				return false;

			NewEntry = new ShaiyaDataEntry();
			NewEntry.ParentID = ParentEntry.ID;
			NewEntry.Filename = Path.GetFileName( Filepath );
			NewEntry.Buffer = File.ReadAllBytes( Filepath );
			NewEntry.Length = NewEntry.Buffer.Length;
			NewEntry.Offset = new FileInfo( this.BasePath + ".saf" ).Length;

			mFilesFlat.Add( NewEntry.ID, NewEntry );
			mFilesFlat[ ParentEntry.ID ].Entrys.Add( NewEntry );
			return true;
		}
		public bool AddFolder( string Filepath ) {
			return false;
		}


		private ShaiyaDataEntry[] ReadFiles( string ParentID ) {
			int fileCount = BitConverter.ToInt32( Buffer, Offset );
			ShaiyaDataEntry[] entrys = new ShaiyaDataEntry[ fileCount ];

			Offset += 4;
			if( fileCount == 0 )
				return entrys;

			for( int i = 0; i < fileCount; i++ ) {
				int nameLength = BitConverter.ToInt32( Buffer, Offset ) - 1; // exclude \0
				Offset += 4;
				char[] nameChars = new char[ nameLength ];
				Array.Copy( Buffer, Offset, nameChars, 0, nameLength );

				Offset += nameLength + 1; // include \0

				entrys[ i ] = new ShaiyaDataEntry( new String( nameChars ), false, BitConverter.ToInt64( Buffer, Offset ), Offset, BitConverter.ToInt32( Buffer, Offset + 8 ) );
				entrys[ i ].ParentID = ParentID;
				entrys[ i ].OffsetOffset = Offset;
				entrys[ i ].UnkownValue = new byte[ 4 ] { Buffer[ Offset + 12 ], Buffer[ Offset + 13 ], Buffer[ Offset + 14 ], Buffer[ Offset + 15 ] };
				mFilesFlat.Add( entrys[ i ].ID, entrys[ i ] );

				Offset += 16;
			}

			return entrys;
		}
		private ShaiyaDataEntry[] ReadDirs( string ParentID ) {
			int dirCount = BitConverter.ToInt32( Buffer, Offset );
			ShaiyaDataEntry[] entrys = new ShaiyaDataEntry[ dirCount ];

			Offset += 4;
			if( dirCount == 0 )
				return entrys;

			for( int i = 0; i < dirCount; i++ ) {
				int nameLength = BitConverter.ToInt32( Buffer, Offset ) - 1; // exclude \0
				Offset += 4;

				char[] nameChars = new char[ nameLength ];
				Array.Copy( Buffer, Offset, nameChars, 0, nameLength );

				Offset += nameLength + 1; // include \0

				entrys[ i ] = new ShaiyaDataEntry( new String( nameChars ), true, 0, 0, 0 );
				entrys[ i ].ParentID = ParentID;
				mFilesFlat.Add( entrys[ i ].ID, entrys[ i ] );
				entrys[ i ].Entrys.AddRange( ReadFiles( entrys[ i ].ID ) );
				entrys[ i ].Entrys.AddRange( ReadDirs( entrys[ i ].ID ) );

			}

			return entrys;
		}

	}

}
