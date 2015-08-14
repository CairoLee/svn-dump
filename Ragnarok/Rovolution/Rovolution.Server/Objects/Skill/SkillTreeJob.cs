using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {

	public class SkillTreeJob : Dictionary<int, SkillTreeJobSkill> {

		public int ID {
			get;
			set;
		}

		public SkillTreeJob() {
		}

	}

}
