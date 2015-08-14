using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Ssc {


	[Serializable]
	public class SPlayerStatus {
		public static SPlayerStatus BaseJäger = new SPlayerStatus( 13, 12, 7, 10, 10, 13 );
		public static SPlayerStatus BaseHeide = new SPlayerStatus( 7, 9, 17, 14, 9, 9 );
		public static SPlayerStatus BaseOrakel = new SPlayerStatus( 8, 10, 14, 16, 9, 8 );
		public static SPlayerStatus BaseAttentäter = new SPlayerStatus( 10, 9, 9, 10, 9, 10 );
		public static SPlayerStatus BaseWächter = new SPlayerStatus( 12, 14, 10, 10, 9, 10 );
		public static SPlayerStatus BaseKrieger = new SPlayerStatus( 1, 1, 1, 1, 1, 1 ); // todo

		private int mLevel = 1;
		private EGameMode mMode = EGameMode.Hart;
		private EClass mClass = EClass.Jäger;

		private decimal mSTR = 0;
		private decimal mABW = 0;
		private decimal mINT = 0;
		private decimal mWEI = 0;
		private decimal mGES = 0;
		private decimal mGLU = 0;

		private decimal mSTRBase = 1;
		private decimal mABWBase = 1;
		private decimal mINTBase = 1;
		private decimal mWEIBase = 1;
		private decimal mGESBase = 1;
		private decimal mGLUBase = 1;

		private SItem mItemHelm = SItem.Empty;
		private SItem mItemRüstung = SItem.Empty;
		private SItem mItemHose = SItem.Empty;
		private SItem mItemHandschuhe = SItem.Empty;
		private SItem mItemSchuhe = SItem.Empty;
		private SItem mItemWaffe = SItem.Empty;
		private SItem mItemSchild = SItem.Empty;
		private SItem mItemMantel = SItem.Empty;
		private SItem mItemRing1 = SItem.Empty;
		private SItem mItemRing2 = SItem.Empty;
		private SItem mItemArmreif1 = SItem.Empty;
		private SItem mItemArmreif2 = SItem.Empty;
		private SItem mItemAmulett = SItem.Empty;
		private SItem mItemReitTier = SItem.Empty;

		public SItem ItemHelm {
			get { return mItemHelm; }
			set { SetItem( out mItemHelm, value ); }
		}
		public SItem ItemRüstung {
			get { return mItemRüstung; }
			set { SetItem( out mItemRüstung, value ); }
		}
		public SItem ItemHose {
			get { return mItemHose; }
			set { SetItem( out mItemHose, value ); }
		}
		public SItem ItemHandschuhe {
			get { return mItemHandschuhe; }
			set { SetItem( out mItemHandschuhe, value ); }
		}
		public SItem ItemSchuhe {
			get { return mItemSchuhe; }
			set { SetItem( out mItemSchuhe, value ); }
		}
		public SItem ItemWaffe {
			get { return mItemWaffe; }
			set { SetItem( out mItemWaffe, value ); }
		}
		public SItem ItemSchild {
			get { return mItemSchild; }
			set { SetItem( out mItemSchild, value ); }
		}
		public SItem ItemMantel {
			get { return mItemMantel; }
			set { SetItem( out mItemMantel, value ); }
		}
		public SItem ItemRing1 {
			get { return mItemRing1; }
			set { SetItem( out mItemRing1, value ); }
		}
		public SItem ItemRing2 {
			get { return mItemRing2; }
			set { SetItem( out mItemRing2, value ); }
		}
		public SItem ItemArmreif1 {
			get { return mItemArmreif1; }
			set { SetItem( out mItemArmreif1, value ); }
		}
		public SItem ItemArmreif2 {
			get { return mItemArmreif2; }
			set { SetItem( out mItemArmreif2, value ); }
		}
		public SItem ItemAmulett {
			get { return mItemAmulett; }
			set { SetItem( out mItemAmulett, value ); }
		}
		public SItem ItemReitTier {
			get { return mItemReitTier; }
			set { SetItem( out mItemReitTier, value ); }
		}


		public int Level {
			get { return mLevel; }
			set { mLevel = value; }
		}
		public EGameMode Mode {
			get { return mMode; }
			set { mMode = value; }
		}
		public EClass Class {
			get { return mClass; }
			set { mClass = value; }
		}

		#region Status
		public decimal STR {
			get { return mSTR; }
			set { mSTR = value; }
		}
		public decimal ABW {
			get { return mABW; }
			set { mABW = value; }
		}
		public decimal INT {
			get { return mINT; }
			set { mINT = value; }
		}
		public decimal WEI {
			get { return mWEI; }
			set { mWEI = value; }
		}
		public decimal GES {
			get { return mGES; }
			set { mGES = value; }
		}
		public decimal GLU {
			get { return mGLU; }
			set { mGLU = value; }
		}
		#endregion

		#region Status All
		public decimal STRAll {
			get { return mSTR + mSTRBase; }
		}
		public decimal ABWAll {
			get { return mABW + mABWBase; }
		}
		public decimal INTAll {
			get { return mINT + mINTBase; }
		}
		public decimal WEIAll {
			get { return mWEI + mWEIBase; }
		}
		public decimal GESAll {
			get { return mGES + mGESBase; }
		}
		public decimal GLUAll {
			get { return mGLU + mGLUBase; }
		}
		#endregion

		#region Status Pure
		public decimal STRPure {
			get { return Math.Max( 0, mSTR - mSTRBase ); }
		}
		public decimal ABWPure {
			get { return Math.Max( 0, mABW - mABWBase ); }
		}
		public decimal INTPure {
			get { return Math.Max( 0, mINT - mINTBase ); }
		}
		public decimal WEIPure {
			get { return Math.Max( 0, mWEI - mWEIBase ); }
		}
		public decimal GESPure {
			get { return Math.Max( 0, mGES - mGESBase ); }
		}
		public decimal GLUPure {
			get { return Math.Max( 0, mGLU - mGLUBase ); }
		}
		#endregion


		public SPlayerStatus() {
		}

		public SPlayerStatus( int str, int abw, int _int, int wei, int ges, int glu ) {
			mSTRBase = str;
			mABWBase = abw;
			mINTBase = _int;
			mWEIBase = wei;
			mGESBase = ges;
			mGLUBase = glu;
		}


		public void SetItem( out SItem Item, SItem newItem ) {
			Item = newItem.Clone() as SItem;
		}

		public List<SItemBonus> GetAllBonus() {
			List<SItemBonus> list = new List<SItemBonus>();

			list.AddRange( ItemHelm.Bonus );
			list.AddRange( ItemRüstung.Bonus );
			list.AddRange( ItemHose.Bonus );
			list.AddRange( ItemHandschuhe.Bonus );
			list.AddRange( ItemSchuhe.Bonus );
			list.AddRange( ItemWaffe.Bonus );
			list.AddRange( ItemSchild.Bonus );
			list.AddRange( ItemMantel.Bonus );
			list.AddRange( ItemRing1.Bonus );
			list.AddRange( ItemRing2.Bonus );
			list.AddRange( ItemArmreif1.Bonus );
			list.AddRange( ItemArmreif2.Bonus );
			list.AddRange( ItemAmulett.Bonus );
			list.AddRange( ItemReitTier.Bonus );

			return list;
		}
		public SItem GetItemFromName( string Name ) {
			switch( Name ) {
				case "Schuhe":
					return ItemSchuhe;
				case "Handschuh":
					return ItemHandschuhe;
				case "Hose":
					return ItemHose;
				case "Rüstung":
					return ItemRüstung;
				case "Helm":
					return ItemHelm;
				case "Armreif1":
					return ItemArmreif1;
				case "Armreif2":
					return ItemArmreif2;
				case "Ring1":
					return ItemRing1;
				case "Ring2":
					return ItemRing2;
				case "Reittier":
					return ItemReitTier;
				case "Amulett":
					return ItemAmulett;
				case "Mantel":
					return ItemMantel;
				case "Schild":
					return ItemSchild;
				case "Waffe":
					return ItemWaffe;
			}

			return null;
		}
		public void SaveItemByName( string Name, SItem newItem ) {
			switch( Name ) {
				case "Schuhe":
					ItemSchuhe = newItem.Clone() as SItem;
					break;
				case "Handschuh":
					ItemHandschuhe = newItem.Clone() as SItem;
					break;
				case "Hose":
					ItemHose = newItem.Clone() as SItem;
					break;
				case "Rüstung":
					ItemRüstung = newItem.Clone() as SItem;
					break;
				case "Helm":
					ItemHelm = newItem.Clone() as SItem;
					break;
				case "Armreif1":
					ItemArmreif1 = newItem.Clone() as SItem;
					break;
				case "Armreif2":
					ItemArmreif2 = newItem.Clone() as SItem;
					break;
				case "Ring1":
					ItemRing1 = newItem.Clone() as SItem;
					break;
				case "Ring2":
					ItemRing2 = newItem.Clone() as SItem;
					break;
				case "Reittier":
					ItemReitTier = newItem.Clone() as SItem;
					break;
				case "Amulett":
					ItemAmulett = newItem.Clone() as SItem;
					break;
				case "Mantel":
					ItemMantel = newItem.Clone() as SItem;
					break;
				case "Schild":
					ItemSchild = newItem.Clone() as SItem;
					break;
				case "Waffe":
					ItemWaffe = newItem.Clone() as SItem;
					break;
			}
		}
		public void SetBaseStatus( SPlayerStatus state ) {
			mSTRBase = state.STR;
			mABWBase = state.ABW;
			mINTBase = state.INT;
			mWEIBase = state.WEI;
			mGESBase = state.GES;
			mGLUBase = state.GLU;
		}


	}

}
