using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Shaiya.Extended.Library.Utility;

namespace Shaiya.Extended.Server {

	[Serializable]
	public enum EScriptContent {
		None = 0,
		Npc = 1,
		Warp = 2,
		MobSpawn = 3
	}

	[Serializable]
	public enum EScriptType {
		None = 0,
		Path = 1,
		Include = 2
	}

	[Serializable]
	[XmlRoot( ElementName = "ScriptList" )]
	public class ScriptList : List<ScriptListEntry> {
	}

	[Serializable]
	public class ScriptListEntry {
		private List<ScriptEntry> mEntrys;
		private EScriptContent mType;

		[XmlAttribute( "Type" )]
		public EScriptContent Type {
			get { return mType; }
			set { mType = value; }
		}

		[XmlArray( "Entrys" )]
		[XmlArrayItem( "Entry" )]
		public List<ScriptEntry> Entrys {
			get { return mEntrys; }
			set { mEntrys = value; }
		}


		public ScriptListEntry() {
			Entrys = new List<ScriptEntry>();
		}

		public ScriptListEntry( EScriptContent Type, List<ScriptEntry> Entrys ) {
			mType = Type;
			mEntrys = Entrys;
		}
	}

	[Serializable]
	public class ScriptEntry {
		private string mPath;
		private EScriptType mType;

		[XmlAttribute( "Type" )]
		public EScriptType Type {
			get { return mType; }
			set { mType = value; }
		}

		[XmlAttribute( "Path" )]
		public string Path {
			get { return mPath; }
			set { mPath = value; }
		}


		public ScriptEntry() {
		}

		public ScriptEntry( EScriptType Type, string Path ) {
			mType = Type;
			mPath = Path;
		}
	}

	[Serializable]
	public static class ScriptDatabase {

		public static ScriptList Scripts = new ScriptList();
		private static XmlSerializer mXmlSerializer = new XmlSerializer( typeof( ScriptList ) );


		public static void Initialize( string ScriptListPath ) {
			ScriptList ScriptEntrys = new ScriptList();
			if( File.Exists( ScriptListPath ) == false ) {
				CConsole.ErrorLine( "Can't load File from \"" + ScriptListPath + "\"!" );
				return;
			}

			using( FileStream s = File.OpenRead( ScriptListPath ) )
				ScriptEntrys = mXmlSerializer.Deserialize( s ) as ScriptList;

			string basePath = Path.GetDirectoryName( ScriptListPath );
			for( int i = 0; i < ScriptEntrys.Count; i++ ) {
				for( int j = 0; j < ScriptEntrys[ i ].Entrys.Count; j++ )
					if( ScriptEntrys[ i ].Entrys[ j ].Type == EScriptType.Include )
						ScriptDatabase.Initialize( Path.Combine( Path.GetDirectoryName( ScriptListPath ), ScriptEntrys[ i ].Entrys[ j ].Path ) );
					else {
						// fixx Directory
						ScriptEntrys[ i ].Entrys[ j ].Path = Path.Combine( basePath, Path.GetDirectoryName( ScriptEntrys[ i ].Entrys[ j ].Path ) ) + @"\" + Path.GetFileName( ScriptEntrys[ i ].Entrys[ j ].Path );
					}
			}

			if( ScriptEntrys.Count > 0 )
				Scripts.AddRange( ScriptEntrys );
		}



		public static ScriptEntry[] GetType( EScriptContent type ) {
			List<ScriptEntry> ret = new List<ScriptEntry>();
			for( int i = 0; i < Scripts.Count; i++ )
				if( Scripts[ i ].Type == type )
					ret.AddRange( Scripts[ i ].Entrys );

			return ret.ToArray();
		}


	}


}
