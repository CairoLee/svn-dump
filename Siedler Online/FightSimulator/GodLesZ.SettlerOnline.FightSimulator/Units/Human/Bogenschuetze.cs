using GodLesZ.SettlerOnline.FightSimulator.Library.Units;

namespace GodLesZ.SettlerOnline.FightSimulator.Units.Human {

	public class Bogenschuetze : Unit {

		public Bogenschuetze()
			: base() {
			SequencePrio = 6;
			Avatar = GodLesZ.SettlerOnline.FightSimulator.Properties.Resources.Bogenschuetze;
			Name = "Bogenschütze";
			PlayerLevel = 16;
			HitDamage = 40;
			MissDamage = 20;
			HitPercentage = 80;
			HitPoints = 10;
			Experience = 3;
			ProductionTime = 240;

			// Resources
			Resources.Add(Library.EResource.Population, 1);
			Resources.Add(Library.EResource.Beer, 10);
			Resources.Add(Library.EResource.Bow, 10);

			// Skills
			Skills.Add(Library.ESkill.BonusTowerArmor, 1);
		}

	}

}
