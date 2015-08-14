using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseEditor.Library.Classes {

	public class DatabaseMob {

		private int mID;
		private string mNameSprite;
		private string mNameKorea;
		private string mNameInter;
		private int mLevel;
		private int mHP;
		private int mSP;
		private int mEXP;
		private int mJEXP;
		private int mRangeAttack;
		private int mAttackMin;
		private int mAttackMax;
		private int mDefence;
		private int mDefenceMagic;
		private int mAttSTR;
		private int mAttAGI;
		private int mAttVIT;
		private int mAttINT;
		private int mAttDEX;
		private int mAttLUK;
		private int mRangeView;
		private int mRangeFollow;
		private int mScale;
		private ERace mRace;
		private EElement mElement;
		private EMobMode mMode;
		private int mSpeed;
		private int mAttackDelay;
		private int mAttackMotion;
		private int mDefenceMotion;
		private int mMvPEXP;
		private int mMvPEXPChance;
		private List<DatabaseMobDrop> mDropsMvP;
		private List<DatabaseMobDrop> mDrops;
		private DatabaseMobDrop mDropCard;

		public int ID {
			get { return mID; }
			set { mID = value; }
		}

		public string NameSprite {
			get { return mNameSprite; }
			set { mNameSprite = value; }
		}

		public string NameKorea {
			get { return mNameKorea; }
			set { mNameKorea = value; }
		}

		public string NameInter {
			get { return mNameInter; }
			set { mNameInter = value; }
		}

		public int Level {
			get { return mLevel; }
			set { mLevel = value; }
		}

		public int HP {
			get { return mHP; }
			set { mHP = value; }
		}

		public int SP {
			get { return mSP; }
			set { mSP = value; }
		}

		public int EXP {
			get { return mEXP; }
			set { mEXP = value; }
		}

		public int JEXP {
			get { return mJEXP; }
			set { mJEXP = value; }
		}

		public int RangeAttack {
			get { return mRangeAttack; }
			set { mRangeAttack = value; }
		}

		public int AttackMin {
			get { return mAttackMin; }
			set { mAttackMin = value; }
		}

		public int AttackMax {
			get { return mAttackMax; }
			set { mAttackMax = value; }
		}

		public int Defence {
			get { return mDefence; }
			set { mDefence = value; }
		}

		public int DefenceMagic {
			get { return mDefenceMagic; }
			set { mDefenceMagic = value; }
		}

		public int AttSTR {
			get { return mAttSTR; }
			set { mAttSTR = value; }
		}

		public int AttAGI {
			get { return mAttAGI; }
			set { mAttAGI = value; }
		}

		public int AttVIT {
			get { return mAttVIT; }
			set { mAttVIT = value; }
		}

		public int AttINT {
			get { return mAttINT; }
			set { mAttINT = value; }
		}

		public int AttDEX {
			get { return mAttDEX; }
			set { mAttDEX = value; }
		}

		public int AttLUK {
			get { return mAttLUK; }
			set { mAttLUK = value; }
		}

		public int RangeView {
			get { return mRangeView; }
			set { mRangeView = value; }
		}

		public int RangeFollow {
			get { return mRangeFollow; }
			set { mRangeFollow = value; }
		}

		public int Scale {
			get { return mScale; }
			set { mScale = value; }
		}

		public ERace Race {
			get { return mRace; }
			set { mRace = value; }
		}

		public EElement Element {
			get { return mElement; }
			set { mElement = value; }
		}

		public EMobMode Mode {
			get { return mMode; }
			set { mMode = value; }
		}

		public int Speed {
			get { return mSpeed; }
			set { mSpeed = value; }
		}

		public int AttackDelay {
			get { return mAttackDelay; }
			set { mAttackDelay = value; }
		}

		public int AttackMotion {
			get { return mAttackMotion; }
			set { mAttackMotion = value; }
		}

		public int DefenceMotion {
			get { return mDefenceMotion; }
			set { mDefenceMotion = value; }
		}

		public int MvPEXP {
			get { return mMvPEXP; }
			set { mMvPEXP = value; }
		}

		public int MvPEXPChance {
			get { return mMvPEXPChance; }
			set { mMvPEXPChance = value; }
		}

		public List<DatabaseMobDrop> DropsMvP {
			get { return mDropsMvP; }
			set { mDropsMvP = value; }
		}

		public List<DatabaseMobDrop> Drops {
			get { return mDrops; }
			set { mDrops = value; }
		}

		public DatabaseMobDrop DropCard {
			get { return mDropCard; }
			set { mDropCard = value; }
		}


		public DatabaseMob() {
		}

	}

}
