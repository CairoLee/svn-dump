using GodLesZ.SettlerOnline.FightSimulator.Library.Units;

namespace GodLesZ.SettlerOnline.FightSimulator.Units.Human {

	public class Kavallerie : Unit {

		public Kavallerie()
			: base() {
			SequencePrio = 3;
			Avatar = GodLesZ.SettlerOnline.FightSimulator.Properties.Resources.Reiterei;
			Name = "Kavallerie";
			PlayerLevel = 20;
			HitDamage = 10;
			MissDamage = 5;
			HitPercentage = 80;
			HitPoints = 5;
			Experience = 8;
			ProductionTime = 1080;

			// Resources
			Resources.Add(Library.EResource.Population, 1);
			Resources.Add(Library.EResource.Horse, 40);
			Resources.Add(Library.EResource.Beer, 30);

			// Skills
			Skills.Add(Library.ESkill.AttackWeakestFirst, 1);
			Skills.Add(Library.ESkill.FirstStrike, 1);
		}

	}

}
