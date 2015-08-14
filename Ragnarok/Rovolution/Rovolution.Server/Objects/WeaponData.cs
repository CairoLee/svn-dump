using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {

	public class WeaponData {
		public struct DrainData {
			public short Rate;
			public short Per;
			public short Value;
			public bool Type;
		}

		public struct AddDamageEntry {
			public short Class;
			public short Rate;
		}

		public struct AddElee2Entry {
			public short Flag;
			public short Rate;
			public EElement Ele;
		}


		public int[] AtkMods {
			get;
			set;
		}

		// all the variables except atkmods get zero'ed in each call of status_calc_pc
		public int OverRefine {
			get;
			set;
		}
		public int Star {
			get;
			set;
		}
		public int IgnoreDefEle {
			get;
			set;
		}
		public int IgnoreDefRace {
			get;
			set;
		}
		public int DefRatioAtkEle {
			get;
			set;
		}
		public int DefRatioAtkRace {
			get;
			set;
		}
		public int[] AddEle {
			get;
			set;
		}
		public int[] AddRace {
			get;
			set;
		}
		public int[] AddRace2 {
			get;
			set;
		}
		public int[] addSize {
			get;
			set;
		}

		public DrainData[] HPDrain {
			get;
			set;
		}
		public DrainData[] SPDrain {
			get;
			set;
		}

		public AddDamageEntry[] AddDamage {
			get;
			set;
		}

		public AddElee2Entry[] AddEle2 {
			get;
			set;
		}

	}

}
