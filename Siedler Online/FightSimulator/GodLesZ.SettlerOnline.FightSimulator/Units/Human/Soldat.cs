using GodLesZ.SettlerOnline.FightSimulator.Library.Units;

namespace GodLesZ.SettlerOnline.FightSimulator.Units.Human {

	public class Soldat : Unit {

		public Soldat()
			: base() {
			SequencePrio = 4;
			Avatar = GodLesZ.SettlerOnline.FightSimulator.Properties.Resources.Soldat;
			Name = "Soldat";
			PlayerLevel = 25;
			HitDamage = 40;
			MissDamage = 20;
			HitPercentage = 85;
			HitPoints = 90;
			Experience = 10;
			ProductionTime = 720;

			// Resources
			Resources.Add(Library.EResource.Population, 1);
			Resources.Add(Library.EResource.SwordSteel, 10);
			Resources.Add(Library.EResource.Beer, 15);
		}

	}

}
