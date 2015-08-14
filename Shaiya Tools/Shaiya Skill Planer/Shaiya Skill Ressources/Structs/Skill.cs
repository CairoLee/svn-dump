using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Drawing;

namespace Shaiya_Skill_Ressources.Structs {

	[Serializable]
	public class Skill {
		public static System.Reflection.Assembly MainAssembly = null;
		public static string EmbeddedSkillIconFile = @"Shaiya_Skill_Ressources.Embedded.{0}";

		private List<SkillLevel> mSkillLevel = new List<SkillLevel>();
		private Image mImgIco = null;
		private string mImgName = "icons.archer01.png";
		private int mMode = 0;
		private ESkillType mType = ESkillType.Passive;

		public SkillLevel this[ int Index ] {
			get { return mSkillLevel[ Index ]; }
		}

		public string Name {
			get { return mSkillLevel.Count > 0 ? mSkillLevel[ 0 ].Name : "Unbekannt"; }
		}

		[XmlArray( ElementName = "LevelList" )]
		[XmlArrayItem( ElementName = "Level" )]
		public List<SkillLevel> Level {
			get { return mSkillLevel; }
			set { mSkillLevel = value; }
		}

		public Image Icon {
			get {
				if( mImgIco == null )
					LoadIcon();
				return mImgIco;
			}
		}

		[XmlAttribute]
		public string IconName {
			get { return mImgName; }
			set {
				mImgName = value;
				LoadIcon();
			}
		}

		[XmlAttribute]
		public int MaxLvl {
			get { return mSkillLevel.Count; }
		}

		[XmlAttribute]
		public int Mode {
			get { return mMode; }
			set { mMode = value; }
		}

		[XmlAttribute]
		public ESkillType Type {
			get { return mType; }
			set { mType = value; }
		}


		public Skill() {
		}




		public void LoadIcon() {
			if( MainAssembly == null )
				return;
			try {
				System.IO.Stream s = MainAssembly.GetManifestResourceStream( string.Format( EmbeddedSkillIconFile, mImgName ) );
				mImgIco = Bitmap.FromStream( s );
			} catch {
				mImgIco = null;
			}

		}

	}
	

}
