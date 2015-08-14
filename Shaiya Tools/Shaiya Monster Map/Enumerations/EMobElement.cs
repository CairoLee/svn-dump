using System.Drawing;

namespace ShaiyaMonsterMap.Enumerations {

	public enum EMobElement {
		Unbekannt = 0,
		Neutral,
		Feuer,
		Wasser,
		Erde,
		Wind
	}

	public static class MobElementExtensions {
		public static Color ToColor( this EMobElement Ele, bool ForeGround ) {
			switch( Ele ) {
				case EMobElement.Neutral:
					return Color.Gray;
				case EMobElement.Feuer:
					return Color.Red;
				case EMobElement.Wasser:
					return Color.Blue;
				case EMobElement.Wind:
					return Color.Gray; // FromArgb( 198, 198, 198 );
				case EMobElement.Erde:
					return Color.FromArgb( 145, 202, 35 );

				case EMobElement.Unbekannt:
				default:
					return ForeGround ? Color.Black : Color.White;
			}
		}
		public static Image ToImage( this EMobElement Ele ) {
			switch( Ele ) {
				default:
				case EMobElement.Unbekannt:
				case EMobElement.Neutral:
					return Properties.Resources.mon_not;
				case EMobElement.Feuer:
					return Properties.Resources.mon_fire;
				case EMobElement.Wasser:
					return Properties.Resources.mon_water;
				case EMobElement.Wind:
					return Properties.Resources.mon_wind;
				case EMobElement.Erde:
					return Properties.Resources.mon_ground;
			}
		}
		public static string ToName( this EMobElement Ele, bool shortString ) {
			if( shortString == false )
				return Ele.ToString();

			switch( Ele ) {
				case EMobElement.Neutral:
					return "Neu";
				case EMobElement.Feuer:
					return "Fi";
				case EMobElement.Wasser:
					return "Wa";
				case EMobElement.Wind:
					return "Wi";
				case EMobElement.Erde:
					return "Er";

				case EMobElement.Unbekannt:
				default:
					return "~";
			}
		}
	}


}
