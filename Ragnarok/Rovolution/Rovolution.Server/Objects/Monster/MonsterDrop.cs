using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Rovolution.Server.Objects {

	public class MonsterDrop {

		public int MobID {
			get;
			protected set;
		}

		public int ItemID {
			get;
			protected set;
		}

		public short Chance {
			get;
			protected set;
		}


		// Future features :D
		public sbyte Amount {
			get;
			set;
		}

		public bool IsMvp {
			get;
			set;
		}

		public bool IsCard {
			get;
			set;
		}


		public MonsterDrop(int mobID, int itemID, int chance, sbyte amount, bool mvp, bool card) {
			MobID = mobID;
			ItemID = itemID;
			Chance = (short)chance;
			Amount = amount;
			IsMvp = mvp;
			IsCard = card;
		}

		public MonsterDrop(DataRow row)
			: this(row.Field<int>("mobID"), row.Field<int>("itemID"), row.Field<int>("chance"), row.Field<sbyte>("amount"), row.Field<bool>("isMvp"), row.Field<bool>("isCard")) {
		}


		public static MonsterDrop Load(DataRow row) {
			return new MonsterDrop(row);
		}

	}

}
