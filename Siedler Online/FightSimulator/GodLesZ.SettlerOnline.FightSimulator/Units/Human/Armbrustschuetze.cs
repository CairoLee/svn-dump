using GodLesZ.SettlerOnline.FightSimulator.Library.Units;

namespace GodLesZ.SettlerOnline.FightSimulator.Units.Human {

	public class Armbrustschuetze : Unit {

		public Armbrustschuetze()
			: base() {
			SequencePrio = 8;
			Avatar = GodLesZ.SettlerOnline.FightSimulator.Properties.Resources.Armbrustschuetze;
			Name = "Armbrustschützen";
			PlayerLevel = 37;
			HitDamage = 90;
			MissDamage = 45;
			HitPercentage = 80;
			HitPoints = 10;
			Experience = 20;
			ProductionTime = 720;

			// Resources
			Resources.Add(Library.EResource.Population, 1);
			Resources.Add(Library.EResource.BowCross, 10);
			Resources.Add(Library.EResource.Beer, 90);
			// Skills
			Skills.Add(Library.ESkill.BonusTowerArmor, 1);
		}

	}

}
