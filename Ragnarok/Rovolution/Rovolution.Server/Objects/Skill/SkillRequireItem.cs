using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {
	
	public class SkillRequireItem {

		public int ItemID {
			get;
			protected set;
		}

		public int Amount {
			get;
			protected set;
		}


		public SkillRequireItem() {
		}

		public SkillRequireItem(int id, int amount) {
			ItemID = id;
			Amount = amount;
		}

	}

}
