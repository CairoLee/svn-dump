using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Drawing;
using GodLesZ.Library.Ragnarok.Grf;
using System.IO;
using GodLesZ.Library.Ragnarok.Sprite;

namespace GodLesZ.Ragnarok.SkillCalculator.Library {

	[XmlRoot("MobDBMob")]
	public class MobDBMob {
		private int mID;

		#region Properties
		public int ID {
			get { return mID; }
			set {
				mID = value;
				Imagepath = Environment.CurrentDirectory + @"\data\mobs\" + ID + ".png";
			}
		}

		public string Sprite_Name {
			get;
			set;
		}

		public string kROName {
			get;
			set;
		}

		public string iROName {
			get;
			set;
		}

		public string Name {
			get { return iROName; }
			set { iROName = value; }
		}

		public int LV {
			get;
			set;
		}

		public int HP {
			get;
			set;
		}

		public int SP {
			get;
			set;
		}

		public int EXP {
			get;
			set;
		}

		public int JEXP {
			get;
			set;
		}

		public int Range1 {
			get;
			set;
		}

		public int ATK1 {
			get;
			set;
		}

		public int ATK2 {
			get;
			set;
		}

		public int DEF {
			get;
			set;
		}

		public int MDEF {
			get;
			set;
		}

		public int STR {
			get;
			set;
		}

		public int AGI {
			get;
			set;
		}

		public int VIT {
			get;
			set;
		}

		public int INT {
			get;
			set;
		}

		public int DEX {
			get;
			set;
		}

		public int LUK {
			get;
			set;
		}

		public int Range2 {
			get;
			set;
		}

		public int Range3 {
			get;
			set;
		}

		public EScale Scale {
			get;
			set;
		}

		public ERace Race {
			get;
			set;
		}

		public EElement Element {
			get;
			set;
		}

		public int ElementLevel {
			get;
			set;
		}

		public int Mode {
			get;
			set;
		}

		public int Speed {
			get;
			set;
		}

		public int aDelay {
			get;
			set;
		}

		public int aMotion {
			get;
			set;
		}

		public int dMotion {
			get;
			set;
		}

		public int MEXP {
			get;
			set;
		}

		public int MExpPer {
			get;
			set;
		}

		public List<MobDBMobDrop> Drops {
			get;
			set;
		}

		public List<MobDBMobDrop> DropsMvp {
			get;
			set;
		}

		public MobDBMobDrop DropCard {
			get;
			set;
		}

		#endregion

		public string Imagepath {
			get;
			set;
		}

		[XmlIgnore()]
		public Image Image {
			get { return Bitmap.FromFile(Imagepath); }
		}

		[XmlIgnore()]
		public bool ImageExists {
			get { return (string.IsNullOrEmpty(Imagepath) == false && File.Exists(Imagepath)); }
		}

		
		public MobDBMob() {
			Drops = new List<MobDBMobDrop>();
			DropsMvp = new List<MobDBMobDrop>();
		}


		public bool ExportImage(RoGrfFileItem grfItem) {
			byte[] spriteData = grfItem.FileData;
			string sprFilepath = Path.GetTempFileName();
			File.WriteAllBytes(sprFilepath, spriteData);
			spriteData = null;

			try {
				using (RoSprite sprFile = new RoSprite(sprFilepath)) {
					sprFile.DrawImage(0);

					using (Bitmap bmp = sprFile.GetImageTransparent(0)) {
						bmp.Save(Environment.CurrentDirectory + @"\data\mobs\" + ID + ".png");
					}
				}
			} catch (Exception ex) {
				return false;
			}

			return true;
		}

		public override string ToString() {
			return string.Format("{0}: {1}", ID, Name);
		}
	}

}
