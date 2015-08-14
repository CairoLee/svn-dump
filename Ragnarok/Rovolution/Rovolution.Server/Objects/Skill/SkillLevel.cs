using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rovolution.Server.Database;
using System.Data;

namespace Rovolution.Server.Objects {

	public class SkillLevel : StoreableObject {

		public int Level {
			get;
			protected set;
		}

		public int Range {
			get;
			protected set;
		}

		public int Element {
			get;
			protected set;
		}

		public int Splash {
			get;
			protected set;
		}

		public int Num {
			get;
			protected set;
		}

		public int Cast {
			get;
			protected set;
		}

		public int WalkDelay {
			get;
			protected set;
		}

		public int Delay {
			get;
			protected set;
		}

		public int UpkeepTime {
			get;
			protected set;
		}

		public int UpkeepTime2 {
			get;
			protected set;
		}

		public int MaxCount {
			get;
			protected set;
		}

		public int BlewCount {
			get;
			protected set;
		}

		public int Hp {
			get;
			protected set;
		}

		public int Sp {
			get;
			protected set;
		}

		public int MHp {
			get;
			protected set;
		}

		public int HpRate {
			get;
			protected set;
		}

		public int SpRate {
			get;
			protected set;
		}

		public int Zeny {
			get;
			protected set;
		}

		public int AmmoQty {
			get;
			protected set;
		}

		public int Spritiball {
			get;
			protected set;
		}

		public int CastNoDex {
			get;
			protected set;
		}

		public int DelayNoDex {
			get;
			protected set;
		}

		public int UnitLayoutType {
			get;
			protected set;
		}

		public int UnitRange {
			get;
			protected set;
		}


		public SkillLevel() {
		}


		public static SkillLevel Load(DataRow row) {
			SkillLevel level = new SkillLevel();
			if (level.LoadFromDatabase(row) == false) {
				return null;
			}
			return level;
		}


		protected override bool LoadFromDatabase(DataRow row) {
			Level = row.Field<sbyte>("level");
			Range = row.Field<short>("range");
			Element = row.Field<int>("element");
			Splash = row.Field<short>("splash");
			Num = row.Field<short>("num");
			MaxCount = row.Field<short>("maxcount");
			BlewCount = row.Field<short>("blowcount");

			return true;
		}

	}

}
