using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Shaiya_Skill_Ressources.Structs {

	[Serializable]
	[XmlRoot( ElementName = "SkillList" )]
	public class SkillList {
		private string mFilename;
		[XmlArray( ElementName = "Skills" )]
		[XmlArrayItem( ElementName = "Skill" )]
		public List<Skill> Skills = new List<Skill>();

		public int Count {
			get { return Skills.Count; }
		}

		[XmlIgnore()]
		public string Filename {
			get { return mFilename; }
			set { mFilename = value; }
		}

		public Skill this[ int Index ] {
			get { return Skills[ Index ]; }
		}


		public SkillList() {
		}


		public void Save() {
			if( Filename == string.Empty )
				throw new Exception();

			XmlSerializer xml = new XmlSerializer( typeof( SkillList ) );
			if( System.IO.File.Exists( Filename ) == true )
				System.IO.File.Delete( Filename );
			using( System.IO.FileStream fs = System.IO.File.OpenWrite( Filename ) ) {
				try {
					xml.Serialize( fs, this );
				} catch( Exception e ) {
					System.Diagnostics.Debug.WriteLine( e );
				}
			}
		}

		public void LoadIcons() {
			if( Skills == null || Skills.Count == 0 )
				return;
			for( int i = 0; i < Skills.Count; i++ )
				Skills[ i ].LoadIcon();
		}


		public static SkillList Load( string Filename ) {
			SkillList skills;
			using( System.IO.FileStream fs = System.IO.File.OpenRead( Filename ) ) {
				XmlSerializer xml = new XmlSerializer( typeof( SkillList ) );
				try {
					skills = xml.Deserialize( fs ) as SkillList;
					skills.Filename = Filename;
				} catch( Exception e ) {
					System.Diagnostics.Debug.WriteLine( e );
					skills = new SkillList();
				}
			}

			return skills;
		}

	}

}
