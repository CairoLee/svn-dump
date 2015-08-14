using System;
using System.Collections;
using System.Drawing;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace Ssc.Classes {

	[Serializable]
	public class SkillList {
		[XmlArray( ElementName = "Skills" )]
		[XmlArrayItem( ElementName = "Skill" )]
		public List<Skill> Skills = new List<Skill>();

		public int Count {
			get { return Skills.Count; }
		}

		public Skill this[ int Index ] {
			get { return Skills[ Index ]; }
		}



		public void Save( string Filename ) {
			XmlSerializer xml = new XmlSerializer( typeof( SkillList ) );
			using( System.IO.FileStream fs = System.IO.File.OpenWrite( Filename ) ) {
				try {
					xml.Serialize( fs, this );
				} catch( Exception e ) {
					System.Diagnostics.Debug.WriteLine( e );
				}
			}
		}


		public static SkillList Load( string Filename ) {
			SkillList skills;
			using( System.IO.FileStream fs = System.IO.File.OpenRead( Filename ) )
				skills = SkillList.Load( fs );

			return skills;
		}

		public static SkillList Load( System.IO.Stream s ) {
			SkillList skills;
			XmlSerializer xml = new XmlSerializer( typeof( SkillList ) );
			try {
				skills = xml.Deserialize( s ) as SkillList;
			} catch( Exception e ) {
				System.Diagnostics.Debug.WriteLine( e );
				skills = new SkillList();
			}

			return skills;
		}

	}

	public class Skill {
		private List<SkillLevel> mSkillLevel = new List<SkillLevel>();
		private Image mImgIco = null;
		private string mImgName = string.Empty;
		private int mMode = 0;
		private string mClass = string.Empty;
		private string mID = string.Empty;
		private string mName = string.Empty;
		private SkillType mType = SkillType.Passive;

		public string Class {
			get { return mClass; }
			set { mClass = value; }
		}

		public Image Icon {
			get {
				if( mImgIco == null )
					LoadIcon();
				return mImgIco;
			}
		}

		public string IconName {
			get { return mImgName; }
			set {
				mImgName = value;
				LoadIcon();
			}
		}

		public string ID {
			get { return mID; }
			set { mID = value; }
		}

		public int MaxLvl {
			get { return mSkillLevel.Count; }
		}

		public int Mode {
			get { return mMode; }
			set { mMode = value; }
		}

		public string Name {
			get { return mName; }
			set { mName = value; }
		}

		[XmlArray( ElementName = "SkillLevel" )]
		[XmlArrayItem( ElementName = "Level" )]
		public List<SkillLevel> Level {
			get { return mSkillLevel; }
			set { mSkillLevel = value; }
		}

		public SkillType Type {
			get { return mType; }
			set { mType = value; }
		}


		public Skill() {
		}




		public void LoadIcon() {
			if( frmMain.ExecutingAssembly == null )
				return;
			try {
				System.IO.Stream s = frmMain.ExecutingAssembly.GetManifestResourceStream( string.Format( frmMain.XmlSkillIconFile, mImgName ) );
				mImgIco = Bitmap.FromStream( s );
			} catch {
				mImgIco = null;
			}

		}

	}

	public enum SkillType {
		Passive = 0,
		Basic = 1,
		Combat = 2,
		Special = 3,

		Max = 4
	}

}

