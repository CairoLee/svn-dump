using GodLesZ.SettlerOnline.FightSimulator.Library.Units;

namespace GodLesZ.SettlerOnline.FightSimulator.Units.Human {

	public class Elitesoldat : Unit {

		public Elitesoldat()
			: base() {
			SequencePrio = 5;
			Avatar = GodLesZ.SettlerOnline.FightSimulator.Properties.Resources.Elitesoldat;
			Name = "Elitesoldaten";
			PlayerLevel = 35;
			HitDamage = 40;
			MissDamage = 20;
			HitPercentage = 90;
			HitPoints = 120;
			Experience = 20;
			ProductionTime = 1800;

			// Resources
			Resources.Add(Library.EResource.Population, 1);
			Resources.Add(Library.EResource.SwordTitanium, 10);
			Resources.Add(Library.EResource.Beer, 50);
		}

	}

}
