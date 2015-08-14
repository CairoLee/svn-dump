using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rovolution.Server.Internal;

namespace Rovolution.Server.Objects {

	public class CharacterJobModifer : Dictionary<EClientClass, CharacterJobModiferValues> {
		public static CharacterJobModifer Modifer;


		public static void Initialize() {
			string filepath = Core.Conf.ConfigDir + "/Database/JobModifer.xml";
			Modifer = Parser.ParseJobModifer(filepath);

		}

	}

}
