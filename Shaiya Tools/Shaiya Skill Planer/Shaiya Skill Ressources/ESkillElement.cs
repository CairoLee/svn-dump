using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Shaiya_Skill_Ressources {
	
	public enum ESkillElement {
		None,
		Neutral,
		Feuer,
		Wasser,
		Wind,
		Erde
	}

	public static class ESkillElementExtensions {
		public static Image ToImage( this ESkillElement Ele ) {
			switch( Ele ) {
				default:
				case ESkillElement.None:
				case ESkillElement.Neutral:
					return Properties.Resources.mon_not;
				case ESkillElement.Feuer:
					return Properties.Resources.mon_fire;
				case ESkillElement.Wasser:
					return Properties.Resources.mon_water;
				case ESkillElement.Wind:
					return Properties.Resources.mon_wind;
				case ESkillElement.Erde:
					return Properties.Resources.mon_ground;
			}
		}
	}

}
