using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rovolution.Server.Geometry;

namespace Rovolution.Server.Objects {

	public class MonsterSpawnData {
		// TODO: callback/event

		public string Name {
			get;
			protected set;
		}

		public short MobID {
			get;
			protected set;
		}

		public bool IsBoss {
			get;
			protected set;
		}

		public Location Location {
			get;
			protected set;
		}

		public short Xs {
			get;
			protected set;
		}

		public short Ys {
			get;
			protected set;
		}

		public ushort Num {
			get;
			protected set;
		}

		public ushort Active {
			get;
			protected set;
		}

		public uint Delay1 {
			get;
			protected set;
		}

		public uint Delay2 {
			get;
			protected set;
		}


		public ESize Size {
			get;
			protected set;
		}

		public EMonsterAiType Ai {
			get;
			protected set;
		}

		public bool IsDynamic {
			get;
			protected set;
		}


		public MonsterSpawnData() {
		}

	}

}
