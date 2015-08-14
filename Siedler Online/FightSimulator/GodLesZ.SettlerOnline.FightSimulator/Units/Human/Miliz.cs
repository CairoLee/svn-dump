
namespace GodLesZ.SettlerOnline.FightSimulator.Units.Human {

	public class Militz : Unit {

		public Militz()
			: base() {
			SequencePrio = 2;
			Avatar = GodLesZ.SettlerOnline.FightSimulator.Properties.Resources.Miliz;
			Name = "Miliz";
			PlayerLevel = 18;
			HitDamage = 40;
			MissDamage = 20;
			HitPercentage = 80;
			HitPoints = 60;
			Experience = 9;
			ProductionTime = 480;

			// Resources
			Resources.Add(Library.EResource.Population, 1);
			Resources.Add(Library.EResource.SwordIron, 10);
			Resources.Add(Library.EResource.Beer, 10);
		}

	}

}
