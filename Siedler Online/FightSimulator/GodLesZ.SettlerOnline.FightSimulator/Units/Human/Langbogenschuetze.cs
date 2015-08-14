using GodLesZ.SettlerOnline.FightSimulator.Library.Units;

namespace GodLesZ.SettlerOnline.FightSimulator.Units.Human {

	public class Langbogenschuetze : Unit {

		public Langbogenschuetze()
			: base() {
			SequencePrio = 7;
			Avatar = GodLesZ.SettlerOnline.FightSimulator.Properties.Resources.Langbogenschuetze;
			Name = "Langbogenschütze";
			PlayerLevel = 22;
			HitDamage = 60;
			MissDamage = 30;
			HitPercentage = 80;
			HitPoints = 10;
			Experience = 8;
			ProductionTime = 480;

			// Resources
			Resources.Add(Library.EResource.Population, 1);
			Resources.Add(Library.EResource.BowLong, 10);
			Resources.Add(Library.EResource.Beer, 20);

			// Skills
			Skills.Add(Library.ESkill.BonusTowerArmor, 1);
		}

	}

}
