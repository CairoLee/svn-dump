using System;
using System.Collections.Generic;
using System.Text;

using ShaiyaMonsterMap.Enumerations;

namespace ShaiyaMonsterMap.Structs {

	public class SMobMapRule {
		public static Dictionary<EMap, SMobMapRule> Rules = new Dictionary<EMap, SMobMapRule>();

		public string MobLevel1 = "1-5";
		public string MobLevel2 = "6-10";
		public string MobLevel3 = "11-15";
		public string MobLevel4 = "16+";

		public int MobLevelInt2 = 6;
		public int MobLevelInt3 = 11;
		public int MobLevelInt4 = 16;

		public SMobMapRule( string s1, string s2, string s3, string s4, int i2, int i3, int i4 ) {
			MobLevel1 = s1;
			MobLevel2 = s2;
			MobLevel3 = s3;
			MobLevel4 = s4;

			MobLevelInt2 = i2;
			MobLevelInt3 = i3;
			MobLevelInt4 = i4;
		}

		// Light Dungeons

		public static void Initialize() {
			// Light \\
			Rules.Add( EMap.Erina, new SMobMapRule( "1-5", "6-10", "11-15", "16+", 6, 11, 16 ) );
			Rules.Add( EMap.Willieoseu, new SMobMapRule( "20-25", "26-30", "31-35", "36+", 26, 31, 36 ) );
			Rules.Add( EMap.Adellia, new SMobMapRule( "30-35", "36-40", "41-45", "46+", 36, 41, 46 ) );
			Rules.Add( EMap.Skulleron, new SMobMapRule( "40-45", "46-50", "51-55", "56+", 46, 51, 56 ) );
			// Dungeons
			Rules.Add( EMap.Cornwell, new SMobMapRule( "18", "19-20", "21-22", "23+", 19, 21, 23 ) );
			Rules.Add( EMap.Senechios, new SMobMapRule( "30-31", "32-33", "34-35", "36+", 32, 34, 36 ) );
			Rules.Add( EMap.Maitrevan_1, new SMobMapRule( "39-41", "42-44", "45-47", "48+", 42, 45, 48 ) );
			Rules.Add( EMap.Maitrevan_2, new SMobMapRule( "39-41", "42-44", "45-47", "48+", 42, 45, 48 ) );
			Rules.Add( EMap.Colorons_1, new SMobMapRule( "39-41", "42-44", "45-47", "48+", 42, 45, 48 ) );
			Rules.Add( EMap.Colorons_2, new SMobMapRule( "39-41", "42-44", "45-47", "48+", 42, 45, 48 ) );
			Rules.Add( EMap.Colorons_3, new SMobMapRule( "39-41", "42-44", "45-47", "48+", 42, 45, 48 ) );
			Rules.Add( EMap.Sigmas, new SMobMapRule( "55", "56", "57", "58+", 56, 57, 58 ) );
			Rules.Add( EMap.ElementHöhle, new SMobMapRule( "50-52", "53-55", "56-58", "59+", 53, 56, 59 ) );

			// Dark \\
			Rules.Add( EMap.Reikeuseu, new SMobMapRule( "1-5", "6-10", "11-15", "16+", 6, 11, 16 ) );
			Rules.Add( EMap.Keuraijen, new SMobMapRule( "20-25", "26-30", "31-35", "36+", 26, 31, 36 ) );
			Rules.Add( EMap.Adeurian, new SMobMapRule( "30-35", "36-40", "41-45", "46+", 36, 41, 46 ) );
			Rules.Add( EMap.Astenes, new SMobMapRule( "40-45", "46-50", "51-55", "56+", 46, 51, 56 ) );
			// Dungeons
			Rules.Add( EMap.Argilla, new SMobMapRule( "18", "19-20", "21-22", "23+", 19, 21, 23 ) );
			Rules.Add( EMap.Kalamus_Anwesen, new SMobMapRule( "30-31", "32-33", "34-35", "36+", 32, 34, 36 ) );
			Rules.Add( EMap.Aidion_Neckria_1, new SMobMapRule( "39-41", "42-44", "45-47", "48+", 42, 45, 48 ) );
			Rules.Add( EMap.Aidion_Neckria_2, new SMobMapRule( "39-41", "42-44", "45-47", "48+", 42, 45, 48 ) );
			Rules.Add( EMap.Fantasmas_1, new SMobMapRule( "39-41", "42-44", "45-47", "48+", 42, 45, 48 ) );
			Rules.Add( EMap.Fantasmas_2, new SMobMapRule( "39-41", "42-44", "45-47", "48+", 42, 45, 48 ) );
			Rules.Add( EMap.Fantasmas_3, new SMobMapRule( "39-41", "42-44", "45-47", "48+", 42, 45, 48 ) );
			Rules.Add( EMap.RuberChaos, new SMobMapRule( "55", "56", "57", "58+", 56, 57, 58 ) );
			Rules.Add( EMap.Aurizen, new SMobMapRule( "50-52", "53-55", "56-58", "59+", 53, 56, 59 ) );

			// PvP
			Rules.Add( EMap.PvP_1, new SMobMapRule( "1-5", "6-10", "11-15", "16+", 6, 11, 16 ) );
			Rules.Add( EMap.PvP_2, new SMobMapRule( "20-22", "23-25", "26-28", "29+", 23, 26, 29 ) );
			Rules.Add( EMap.PvP_3, new SMobMapRule( "35-37", "38-41", "42-44", "45+", 38, 42, 46 ) );
		}


		public static SMobMapRule GetRule( EMap Map ) {
			if( SMobMapRule.Rules.ContainsKey( Map ) == false )
				throw new Exception();

			return SMobMapRule.Rules[ Map ];
		}

	}

}
