using System;
using System.Collections.Generic;
using System.Text;

namespace ShaiyaMonsterMap.Enumerations {

	public enum EMap {
		// Light Maps
		Erina,
		Willieoseu,
		Adellia,
		Skulleron,

		// Dark Maps
		Reikeuseu,
		Keuraijen,
		Adeurian,
		Astenes,

		// Light Dungeons
		Cornwell,
		Senechios,
		Colorons_1,
		Colorons_2,
		Colorons_3,
		ElementHöhle,
		Maitrevan_1,
		Maitrevan_2,
		Sigmas,

		// Dark Dungeons
		Argilla,
		Fantasmas_1,
		Fantasmas_2,
		Fantasmas_3,
		Kalamus_Anwesen,
		Aidion_Neckria_1,
		Aidion_Neckria_2,
		RuberChaos,
		Aurizen,

		// PvP
		PvP_1, // 1-15
		PvP_2, // 20-30
		PvP_3, // 1-60
	}

	public static class EMapExtensions {

		public static string ToName( this EMap map ) {
			switch( map ) {
				default:
					return "unknown map";

				// Light Maps
				case EMap.Erina:
					return "Erina (1-20)";
				case EMap.Willieoseu:
					return "Willieoseu (21-35)";
				case EMap.Adellia:
					return "Adellia (36-50)";
				case EMap.Skulleron:
					return "Skulleron (51-60)";

				// Dark Maps
				case EMap.Reikeuseu:
					return "Reikeuseu (1-20)";
				case EMap.Keuraijen:
					return "Keuraijen (21-35)";
				case EMap.Adeurian:
					return "Adeurian (36-50)";
				case EMap.Astenes:
					return "Astenes (51-60)";

				// Light Dungeons
				case EMap.Cornwell:
					return "Ruinen von Cornwell";
				case EMap.Senechios:
					return "Senechios Kerker";
				case EMap.Colorons_1:
					return "Colorons Schlupfwinkel - 1. Ebene";
				case EMap.Colorons_2:
					return "Colorons Schlupfwinkel - 2. Ebene";
				case EMap.Colorons_3:
					return "Colorons Schlupfwinkel - 3. Ebene";
				case EMap.ElementHöhle:
					return "Höhle der Elemente";
				case EMap.Maitrevan_1:
					return "Maitrevan - 1. Ebene";
				case EMap.Maitrevan_2:
					return "Maitrevan - 2. Ebene";
				case EMap.Sigmas:
					return "Sigmas Höhle";

				// Dark Dungeons
				case EMap.Argilla:
					return "Ruinen von Argilla";
				case EMap.Fantasmas_1:
					return "Fantasmas Schlupfwinkel - 1. Ebene";
				case EMap.Fantasmas_2:
					return "Fantasmas Schlupfwinkel - 2. Ebene";
				case EMap.Fantasmas_3:
					return "Fantasmas Schlupfwinkel - 3. Ebene";
				case EMap.Kalamus_Anwesen:
					return "Kalamus Anwesen";
				case EMap.Aidion_Neckria_1:
					return "Aidion Neckria - 1. Ebene";
				case EMap.Aidion_Neckria_2:
					return "Aidion Neckria - 2. Ebene";
				case EMap.RuberChaos:
					return "Ruber Chaos";
				case EMap.Aurizen:
					return "Ruinen von Aurizen";


				// PvP
				case EMap.PvP_1:
					return "PvP 1-15";
				case EMap.PvP_2:
					return "PvP 20-30";
				case EMap.PvP_3:
					return "PvP 1-60";
			}
		}

		public static EMap ToEMap( this string Mapname ) {

			switch( Mapname ) {
				default:
					return EMap.Erina;
				// Light Maps
				case "Erina (1-20)":
					return EMap.Erina;
				case "Willieoseu (21-35)":
					return EMap.Willieoseu;
				case "Adellia (36-50)":
					return EMap.Adellia;
				case "Skulleron (51-60)":
					return EMap.Skulleron;

				// Dark Maps
				case "Reikeuseu (1-20)":
					return EMap.Reikeuseu;
				case "Keuraijen (21-35)":
					return EMap.Keuraijen;
				case "Adeurian (36-50)":
					return EMap.Adeurian;
				case "Astenes (51-60)":
					return EMap.Astenes;

				// Light Dungeons
				case "Ruinen von Cornwell":
					return EMap.Cornwell;
				case "Senechios Kerker":
					return EMap.Senechios;
				case "Colorons Schlupfwinkel - 1. Ebene":
					return EMap.Colorons_1;
				case "Colorons Schlupfwinkel - 2. Ebene":
					return EMap.Colorons_2;
				case "Colorons Schlupfwinkel - 3. Ebene":
					return EMap.Colorons_3;
				case "Höhle der Elemente":
					return EMap.ElementHöhle;
				case "Maitrevan - 1. Ebene":
					return EMap.Maitrevan_1;
				case "Maitrevan - 2. Ebene":
					return EMap.Maitrevan_2;
				case "Sigmas Höhle":
					return EMap.Sigmas;

				// Dark Dungeons
				case "Ruinen von Argilla":
					return EMap.Argilla;
				case "Fantasmas Schlupfwinkel - 1. Ebene":
					return EMap.Fantasmas_1;
				case "Fantasmas Schlupfwinkel - 2. Ebene":
					return EMap.Fantasmas_2;
				case "Fantasmas Schlupfwinkel - 3. Ebene":
					return EMap.Fantasmas_3;
				case "Kalamus Anwesen":
					return EMap.Kalamus_Anwesen;
				case "Aidion Neckria - 1. Ebene":
					return EMap.Aidion_Neckria_1;
				case "Aidion Neckria - 2. Ebene":
					return EMap.Aidion_Neckria_2;
				case "Ruber Chaos":
					return EMap.RuberChaos;
				case "Ruinen von Aurizen":
					return EMap.Aurizen;


				// PvP
				case "PvP 1-15":
					return EMap.PvP_1;
				case "PvP 20-30":
					return EMap.PvP_2;
				case "PvP 1-60":
					return EMap.PvP_3;
			}

		}

	}

}
