using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {

	public class SkillTreeJobSkill : Dictionary<int, SkillTreeJobSkillRequirement> {

		public int ID {
			get;
			set;
		}

		public int MaxLevel {
			get;
			set;
		}

		public int JobLevel {
			get;
			set;
		}


		public SkillTreeJobSkill() {
		}
		
	}

}
