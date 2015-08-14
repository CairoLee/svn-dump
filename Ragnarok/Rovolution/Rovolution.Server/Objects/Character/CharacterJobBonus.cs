using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rovolution.Server.Internal;

namespace Rovolution.Server.Objects {

	public class CharacterJobBonus : Dictionary<EClientClass, Dictionary<int, EStatusAttribute>> {
		public static CharacterJobBonus Bonus;

		public static void Initialize() {
			string filepath = Core.Conf.ConfigDir + "/Database/JobBonus.xml";
			Bonus = Parser.ParseJobBonus(filepath);

		}

	}

}
