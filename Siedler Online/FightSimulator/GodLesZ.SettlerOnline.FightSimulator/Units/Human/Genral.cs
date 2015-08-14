using GodLesZ.SettlerOnline.FightSimulator.Library.Units;

namespace GodLesZ.SettlerOnline.FightSimulator.Units.Human {

	public class Genral : Unit {

		public Genral()
			: base() {
			SequencePrio = 901;
			Avatar = GodLesZ.SettlerOnline.FightSimulator.Properties.Resources.General_s;
			Name = "General";
			PlayerLevel = 0;
			HitDamage = 120;
			MissDamage = 120;
			HitPercentage = 80;
			HitPoints = 1;
			Experience = 0;
			Produceable = false;
			ProductionTime = 180;

			// Skills
			Skills.Add(Library.ESkill.IsSpecialist, 1);
		}

	}

}
