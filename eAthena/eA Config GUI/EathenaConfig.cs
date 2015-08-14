using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace eACGUI {

	public class EathenaConfig {
		public string Name;
		public object Value; // could be int, float, string...
		public int Line = -1;
		public string[] Comments;

		public override string ToString() {
			return String.Format( "{1}: {2}", Line, Name, Value );
		}
	}
	public class EathenaConfigFile {
		private List<EathenaConfig> mConfigs;
		private string mFilename;

		public List<EathenaConfig> Configs {
			get { return mConfigs; }
		}
		public string Filename {
			get { return mFilename; }
			set { mFilename = value; }
		}


		public EathenaConfigFile() {
			mConfigs = new List<EathenaConfig>();
			mFilename = string.Empty;
		}


		public void Add( EathenaConfig Conf ) {
			mConfigs.Add( Conf );
		}

		public void Remove( int Key ) {
			mConfigs.RemoveAt( Key );
		}

		/// <summary>
		/// Saves all Configs to the File
		/// <para>Backup will be created</para>
		/// </summary>
		public void ToFile( bool BackupFirst ) {
			if( File.Exists( mFilename ) == false )
				return;

			string[] Lines = File.ReadAllLines( mFilename );
			for( int i = 0; i < mConfigs.Count; i++ )
				Lines[ mConfigs[ i ].Line ] = mConfigs[ i ].ToString();

			// Backup? and Save
			if( BackupFirst == true ) {
				string backupName = Path.Combine( Path.GetDirectoryName( mFilename ), Path.GetFileNameWithoutExtension( mFilename ) + ".backup" );
				File.Delete( backupName ); // just to be sure...
				File.Move( mFilename, backupName );
			}
			File.WriteAllLines( mFilename, Lines );
		}
	}
	public class EathenaConfigFileCollection {
		private Dictionary<string, EathenaConfigFile> mFiles;

		public Dictionary<string, EathenaConfigFile> Files {
			get { return mFiles; }
		}
		public Dictionary<string, EathenaConfigFile>.KeyCollection Keys {
			get { return mFiles.Keys; }
		}
		public int Count {
			get { return mFiles.Count; }
		}
		public EathenaConfigFile this[ string Key ] {
			get { return mFiles[ Key ]; }
		}


		public EathenaConfigFileCollection() {
			mFiles = new Dictionary<string, EathenaConfigFile>();
		}


		public void Add( string Key, EathenaConfigFile File ) {
			mFiles.Add( Key, File );
		}

		public void AddRange( List<EathenaConfigFile> Files ) {
			for( int i = 0; i < Files.Count; i++ )
				mFiles.Add( Files[ i ].Filename, Files[ i ] );
		}

		public void AddRange( EathenaConfigFileCollection FileCollection ) {
			foreach( string Key in FileCollection.Keys )
				mFiles.Add( Key.GetPathParts( "conf" ), FileCollection[ Key ] );
		}

		public void Remove( string Key ) {
			mFiles.Remove( Key );
		}

		public bool ContainsKey( string Key ) {
			return mFiles.ContainsKey( Key );
		}

		public bool Export( string Filename ) {
			return new EathenaConfigFileCollectionSerializeable( this ).Export( Filename );
		}
	}

	public class EathenaConfigFileCollectionSerializeable {
		private List<EathenaConfigFile> mFiles;

		public List<EathenaConfigFile> Files {
			get { return mFiles; }
		}
		public int Count {
			get { return mFiles.Count; }
		}
		public EathenaConfigFile this[ int Key ] {
			get { return mFiles[ Key ]; }
		}


		public EathenaConfigFileCollectionSerializeable( EathenaConfigFileCollection col ) {
			mFiles = new List<EathenaConfigFile>();
			foreach( string key in col.Keys )
				mFiles.Add( col[ key ] );
		}

		public EathenaConfigFileCollectionSerializeable() {
			mFiles = new List<EathenaConfigFile>();
		}


		public void Add( EathenaConfigFile File ) {
			mFiles.Add( File );
		}

		public void Remove( int Key ) {
			mFiles.RemoveAt( Key );
		}

		public bool Export( string Filename ) {
			try {
				XmlSerializer xml = new XmlSerializer( typeof( EathenaConfigFileCollectionSerializeable ) );
				xml.Serialize( File.OpenWrite( Filename ), this );
			} catch( Exception e ) {
				System.Diagnostics.Debug.WriteLine( e );
				return false;
			}

			return true;
		}

		public EathenaConfigFileCollection Import( string Filename ) {
			EathenaConfigFileCollectionSerializeable col;
			try {
				XmlSerializer xml = new XmlSerializer( typeof( EathenaConfigFileCollectionSerializeable ) );
				col = xml.Deserialize( File.OpenRead( Filename ) ) as EathenaConfigFileCollectionSerializeable;
			} catch( Exception e ) {
				System.Diagnostics.Debug.WriteLine( e );
				return null;
			}

			return col.ToNormal();
		}

		public EathenaConfigFileCollection ToNormal() {
			EathenaConfigFileCollection col = new EathenaConfigFileCollection();
			for( int i = 0; i < mFiles.Count; i++ )
				col.Add( mFiles[ i ].Filename.GetPathParts( "conf" ), mFiles[ i ] );

			return col;
		}
	}
}
