using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {

	public class MonsterDamageLogEntry {
		public int ID {
			get;
			protected set;
		}

		public uint Dmg {
			get;
			protected set;
		}

		public EMonsterDamageLogType Flag {
			get;
			protected set;
		}


		public MonsterDamageLogEntry(int id, uint dmg, EMonsterDamageLogType type) {
			ID = id;
			Dmg = dmg;
			Flag = type;
		}


	}

}
