using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shaiya_Enchant_Calculator {

	public class IEnchant {

		public int EnchantNumber;
		public float Chance;
		public int Cost;
		public int Bonus;

		public IEnchant( int EnchantNumber, float Chance, int Cost, int Bonus ) {
			this.EnchantNumber = EnchantNumber;
			this.Chance = Chance;
			this.Cost = Cost;
			this.Bonus = Bonus;
		}

	}

}
