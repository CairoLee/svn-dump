using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {
	
	public class SkillCondition {

		public int Weapon {
			get;
			set;
		}

		public int Ammo {
			get;
			set;
		}

		public int AmmoQty {
			get;
			set;
		}

		public int Hp {
			get;
			set;
		}

		public int Sp {
			get;
			set;
		}

		public int Zeny {
			get;
			set;
		}

		public int Spiritball {
			get;
			set;
		}

		public int MHp {
			get;
			set;
		}

		public int State {
			get;
			set;
		}


		public List<SkillRequireItem> Item {
			get;
			set;
		}


		public SkillCondition() {
			Item = new List<SkillRequireItem>();
		}
		
	}

}
