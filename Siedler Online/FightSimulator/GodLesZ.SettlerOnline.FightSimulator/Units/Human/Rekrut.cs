using GodLesZ.SettlerOnline.FightSimulator.Library.Units;

namespace GodLesZ.SettlerOnline.FightSimulator.Units.Human {

	public class Rekrut : Unit {

		public Rekrut()
			: base() {
			SequencePrio = 1;
			Avatar = GodLesZ.SettlerOnline.FightSimulator.Properties.Resources.Rekrut;
			Name = "Rekrut";
			PlayerLevel = 12;
			HitDamage = 30;
			MissDamage = 15;
			HitPercentage = 80;
			HitPoints = 40;
			Experience = 2;
			ProductionTime = 180;

			// Resources
			Resources.Add(Library.EResource.Population, 1);
			Resources.Add(Library.EResource.SwordBronze, 10);
			Resources.Add(Library.EResource.Beer, 5);
		}

	}

}
