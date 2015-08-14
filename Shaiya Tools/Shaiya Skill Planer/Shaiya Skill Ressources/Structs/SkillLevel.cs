using System;
using System.Collections;
using System.Drawing;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace Shaiya_Skill_Ressources.Structs {

	public class SkillLevel {
		private string mDescription = string.Empty;
		private string mName = string.Empty;
		private string mStatus = string.Empty;
		private ESkillElement mElement = ESkillElement.None;
		private float mCastTime = 0f;
		private int mMana = 0;
		private int mRange = 0;
		private int mStamina = 0;
		private float mDelay = 0;
		private int mAoE = 0;
		private int mReqLvl = 0;
		private int mSkillPunkte = 0;

		[XmlAttribute]
		public int AoE {
			get { return mAoE; }
			set { mAoE = value; }
		}

		[XmlAttribute]
		public float CastTime {
			get { return mCastTime; }
			set { mCastTime = value; }
		}

		public string Description {
			get { return mDescription; }
			set { mDescription = value; }
		}

		[XmlAttribute]
		public ESkillElement Element {
			get { return mElement; }
			set { mElement = value; }
		}

		[XmlAttribute]
		public string Name {
			get { return mName; }
			set { mName = value; }
		}

		[XmlAttribute]
		public int Mana {
			get { return mMana; }
			set { mMana = value; }
		}

		[XmlAttribute]
		public int Range {
			get { return mRange; }
			set { mRange = value; }
		}

		[XmlAttribute]
		public int RequiredLevel {
			get { return mReqLvl; }
			set { mReqLvl = value; }
		}

		[XmlAttribute]
		public int SkillPunkte {
			get { return mSkillPunkte; }
			set { mSkillPunkte = value; }
		}

		[XmlAttribute]
		public int Stamina {
			get { return mStamina; }
			set { mStamina = value; }
		}

		[XmlAttribute]
		public string Status {
			get { return mStatus; }
			set { mStatus = value; }
		}

		[XmlAttribute]
		public float Delay {
			get { return mDelay; }
			set { mDelay = value; }
		}



		public SkillLevel() {
		}

		public SkillLevel( string Name ) {
			mName = Name;
		}

	}


}

