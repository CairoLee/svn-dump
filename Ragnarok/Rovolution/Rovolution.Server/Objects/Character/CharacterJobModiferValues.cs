using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {

	public class CharacterJobModiferValues : Dictionary<int, int> {

		public int this[ECharacterJobModifer mod] {
			get { return this[(int)mod]; }
			set { this[(int)mod] = value; }
		}

		public int this[EWeaponType mod] {
			get { return this[(int)mod]; }
			set { this[(int)mod] = value; }
		}


	}

}
