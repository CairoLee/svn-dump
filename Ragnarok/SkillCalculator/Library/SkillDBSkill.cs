using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Drawing;
using GodLesZ.Library.Ragnarok.Grf;
using System.IO;

namespace GodLesZ.Ragnarok.SkillCalculator.Library {

	[XmlRoot("SkillDBSkill")]
	public class SkillDBSkill {
		private int mID;

		public int ID {
			get { return mID; }
			set {
				mID = value;
				Imagepath = Environment.CurrentDirectory + @"\data\skills\" + ID + ".png";
			}
		}

		public string Name {
			get;
			set;
		}

		public string NameEathena {
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


		public SkillDBSkill()
			: this(0, "UNKNOWN_SKILL", "UNKNOWN_SKILL", EElement.Neutral) {
		}

		public SkillDBSkill(int id, string name, string eaName, EElement ele) {
			ID = id;
			Name = name;
			Element = ele;
			ElementLevel = 1;
		}


		public bool ExportImage(RoGrfFileItem grfItem) {
			byte[] imageData = grfItem.FileData;

			try {
				using (MemoryStream ms = new MemoryStream(imageData)) {
					using (Bitmap bmp = (Bitmap)Bitmap.FromStream(ms)) {
						// Replace fuchsia (255, 0, 255)
						bmp.MakeTransparent(Color.Fuchsia);
						bmp.Save(Imagepath);
					}
				}
			} catch (Exception ex) {
				return false;
			}

			return true;
		}


		public override string ToString() {
			return string.Format("{0}: {1} [{2}], {3}", ID, Name, NameEathena, Element);
		}

	}

}
