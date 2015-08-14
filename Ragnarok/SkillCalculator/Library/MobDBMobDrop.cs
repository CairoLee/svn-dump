using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GodLesZ.Ragnarok.SkillCalculator.Library {

	public class MobDBMobDrop {
		public int ItemID {
			get;
			set;
		}

		public int Chance {
			get;
			set;
		}


		public MobDBMobDrop() {
		}

		public MobDBMobDrop(int id, int chance) {
			ItemID = id;
			Chance = chance;
		}


		public override string ToString() {
			return string.Format("{0}: {1} ({2}%)", ItemID, Chance, Math.Round((decimal)((decimal)Chance / 100m), 2));
		}
	}

}
