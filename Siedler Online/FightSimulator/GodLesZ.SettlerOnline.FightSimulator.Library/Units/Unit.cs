using System.Drawing;

namespace GodLesZ.SettlerOnline.FightSimulator.Library.Units {

	public class Unit {

		public string Name {
			get;
			protected set;
		}

		public Bitmap Avatar {
			get;
			protected set;
		}

		public int MaxHP {
			get;
			protected set;
		}

		public int HitPoints {
			get;
			protected set;
		}

		public int PlayerLevel {
			get;
			protected set;
		}

		public ResourceList Resources {
			get;
			protected set;
		}

		public SkillList Skills {
			get;
			protected set;
		}

		public bool Produceable {
			get;
			protected set;
		}

		public int SequencePrio {
			get;
			protected set;
		}

		public int ProductionTime {
			get;
			protected set;
		}

		public int HitDamage {
			get;
			protected set;
		}

		public int MissDamage {
			get;
			protected set;
		}

		public int HitPercentage {
			get;
			protected set;
		}

		public int Experience {
			get;
			protected set;
		}

		public Unit() {
			Produceable = true;
			Resources = new ResourceList();
			Skills = new SkillList();
		}

	}

}
