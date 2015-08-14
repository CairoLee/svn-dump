using GodLesZ.SettlerOnline.FightSimulator.Library.Units;

namespace GodLesZ.SettlerOnline.FightSimulator.Units.Human {

	public class Kanonier : Unit {

		public Kanonier()
			: base() {
			SequencePrio = 9;
			Avatar = GodLesZ.SettlerOnline.FightSimulator.Properties.Resources.Kanonier;
			Name = "Kanonier";
			PlayerLevel = 41;
			HitDamage = 120;
			MissDamage = 60;
			HitPercentage = 90;
			HitPoints = 60;
			Experience = 30;
			ProductionTime = 1800;

			// Resources
			Resources.Add(Library.EResource.Population, 1);
			Resources.Add(Library.EResource.Cannon, 10);
			Resources.Add(Library.EResource.Beer, 50);

			// Skills
			Skills.Add(Library.ESkill.DamageBonusBuildings250, 100);
			Skills.Add(Library.ESkill.BonusTowerArmor, 1);
			Skills.Add(Library.ESkill.LastStrike, 1);
			Skills.Add(Library.ESkill.IgnoreUnitArmorInTower, 1);
		}

	}

}
