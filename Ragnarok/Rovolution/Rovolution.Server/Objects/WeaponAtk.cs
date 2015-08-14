using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {

	public class WeaponAtk {
		public ushort AtkMin {
			get;
			set;
		}

		public ushort AtkMax {
			get;
			set;
		}

		public EElement Element {
			get;
			set;
		}

		public ushort Range {
			get;
			set;
		}


		public WeaponAtk()
			: this(0, 0, EElement.Neutral, 0) {
		}

		public WeaponAtk(ushort min, ushort max, EElement ele, ushort range) {
			AtkMin = min;
			AtkMax = max;
			Element = ele;
			Range = range;
		}
	}

}
