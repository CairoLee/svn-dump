using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shaiya_Enchant_Calculator {

	public class EnchantMatrix {
		public static Random Random = new Random();
		public static List<IEnchant> WeaponEnchants = new List<IEnchant>();
		public static List<IEnchant> ArmorEnchants = new List<IEnchant>();


		public static void Initialize() {

			WeaponEnchants.Add( new IEnchant( 01, 85.82f, 2500000, 7 ) );
			WeaponEnchants.Add( new IEnchant( 02, 74.64f, 2500000, 7 ) );
			WeaponEnchants.Add( new IEnchant( 03, 47.85f, 2500000, 7 ) );
			WeaponEnchants.Add( new IEnchant( 04, 26.26f, 2500000, 10 ) );
			WeaponEnchants.Add( new IEnchant( 05, 11.72f, 2500000, 10 ) );
			WeaponEnchants.Add( new IEnchant( 06, 08.99f, 2500000, 10 ) );
			WeaponEnchants.Add( new IEnchant( 07, 06.00f, 2500000, 13 ) );
			WeaponEnchants.Add( new IEnchant( 08, 04.44f, 2500000, 13 ) );
			WeaponEnchants.Add( new IEnchant( 09, 02.89f, 2500000, 13 ) );
			WeaponEnchants.Add( new IEnchant( 10, 01.85f, 2500000, 16 ) );
			WeaponEnchants.Add( new IEnchant( 11, 01.62f, 2500000, 16 ) );
			WeaponEnchants.Add( new IEnchant( 12, 01.33f, 2500000, 16 ) );
			WeaponEnchants.Add( new IEnchant( 13, 01.00f, 2500000, 19 ) );
			WeaponEnchants.Add( new IEnchant( 14, 00.70f, 2500000, 19 ) );
			WeaponEnchants.Add( new IEnchant( 15, 00.40f, 2500000, 19 ) );
			WeaponEnchants.Add( new IEnchant( 16, 00.10f, 2500000, 22 ) );
			WeaponEnchants.Add( new IEnchant( 17, 00.07f, 2500000, 22 ) );
			WeaponEnchants.Add( new IEnchant( 18, 00.04f, 2500000, 22 ) );
			WeaponEnchants.Add( new IEnchant( 19, 00.01f, 2500000, 25 ) );
			WeaponEnchants.Add( new IEnchant( 20, 00.01f, 2500000, 25 ) );

			ArmorEnchants.Add( new IEnchant( 01, 99.99f, 1040000, 5 ) );
			ArmorEnchants.Add( new IEnchant( 02, 96.43f, 1040000, 5 ) );
			ArmorEnchants.Add( new IEnchant( 03, 90.78f, 1040000, 5 ) );
			ArmorEnchants.Add( new IEnchant( 04, 51.05f, 1040000, 5 ) );
			ArmorEnchants.Add( new IEnchant( 05, 27.74f, 1040000, 5 ) );
			ArmorEnchants.Add( new IEnchant( 06, 10.37f, 1040000, 5 ) );
			ArmorEnchants.Add( new IEnchant( 07, 06.00f, 1040000, 5 ) );
			ArmorEnchants.Add( new IEnchant( 08, 04.44f, 1040000, 5 ) );
			ArmorEnchants.Add( new IEnchant( 09, 02.89f, 1040000, 5 ) );
			ArmorEnchants.Add( new IEnchant( 10, 01.85f, 1040000, 5 ) );
			ArmorEnchants.Add( new IEnchant( 11, 01.62f, 1040000, 5 ) );
			ArmorEnchants.Add( new IEnchant( 12, 01.33f, 1040000, 5 ) );
			ArmorEnchants.Add( new IEnchant( 13, 01.00f, 1040000, 5 ) );
			ArmorEnchants.Add( new IEnchant( 14, 00.70f, 1040000, 5 ) );
			ArmorEnchants.Add( new IEnchant( 15, 00.40f, 1040000, 5 ) );
			ArmorEnchants.Add( new IEnchant( 16, 00.10f, 1040000, 5 ) );
			ArmorEnchants.Add( new IEnchant( 17, 00.07f, 1040000, 5 ) );
			ArmorEnchants.Add( new IEnchant( 18, 00.04f, 1040000, 5 ) );
			ArmorEnchants.Add( new IEnchant( 19, 00.01f, 1040000, 5 ) );
			ArmorEnchants.Add( new IEnchant( 20, 00.01f, 1040000, 5 ) );

		}


		public EnchantResult Calc( EEnchantType Type, int from, int To, int TryCount ) {
			List<IEnchant> enchantList;
			EnchantResult result = new EnchantResult();
			if( Type == EEnchantType.Armor )
				enchantList = ArmorEnchants;
			else
				enchantList = ArmorEnchants;
			result.CostPer = enchantList[ 0 ].Cost;

			for( int t = 0; t < TryCount; t++ ) {
				int costAll = 0;
				for( int i = from; i < To; i++ ) {
					do {
						costAll += enchantList[ i ].Cost;
					} while( Random.Next( 100 ) > enchantList[ i ].Chance );

				}


			}

			return result;
		}


	}

	public enum EEnchantType {
		Weapon,
		Armor
	}

	public struct EnchantResult {
		public int CostPer;
		public int CostAllMin;
		public int CostAllMax;
		public int CostAllAvg;
	}

}
