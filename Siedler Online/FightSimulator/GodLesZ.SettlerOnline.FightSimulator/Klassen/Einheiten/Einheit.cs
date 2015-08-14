using System;
using System.Collections;

namespace GodLesZ.SettlerOnline.FightSimulator.Klassen {
	class Einheit {
		System.Drawing.Bitmap bild;
		string type;
		int playerLevel;
		int hitDamage;
		int missDamage;
		int hitPercentage;
		int hitPoints;
		int maxhp;
		int xpForDefeat;
		int sequencePrio;
		int productionTimeSeconds;
		bool produceable;
		Rohstoffe r;
		Skills s;

		public Einheit() { }

		public Einheit(int SequencePrio, System.Drawing.Bitmap Bild, string Type, int PlayerLevel, int HitDamage, int MissDamage, int HitPercentage, int HitPoints, int XpForDefeat, bool Produceable, int ProductionTimeSeconds, Rohstoffe rohstoffe, Skills skills) {
			sequencePrio = SequencePrio;
			type = Type;
			playerLevel = PlayerLevel;
			hitPoints = HitPoints;
			maxhp = HitPoints;
			hitDamage = HitDamage;
			missDamage = MissDamage;
			hitPercentage = HitPercentage;
			xpForDefeat = XpForDefeat;
			produceable = Produceable;
			productionTimeSeconds = ProductionTimeSeconds;
			r = rohstoffe;
			s = skills;
			bild = Bild;
		}

		public Rohstoffe rohstoffe {
			get { return r; }
			set { r = value; }
		}

		public Skills skills {
			get { return s; }
			set { s = value; }
		}

		public bool Produceable {
			get { return produceable; }
			set { produceable = value; }
		}

		public int SequencePrio {
			get { return sequencePrio; }
			set { sequencePrio = value; }
		}

		public int ProductionTimeSeconds {
			get { return productionTimeSeconds; }
			set { productionTimeSeconds = value; }
		}

		public System.Drawing.Bitmap Bild {
			get { return bild; }
			set { bild = value; }
		}

		public string Typ {
			get { return type; }
			set { type = value; }
		}

		public int HitDamage {
			get { return hitDamage; }
			set { hitDamage = value; }
		}

		public int MissDamage {
			get { return missDamage; }
			set { missDamage = value; }
		}

		public int HitPercentage {
			get { return hitPercentage; }
			set { hitPercentage = value; }
		}

		public int MaxHP {
			get { return maxhp; }
			set { maxhp = value; }
		}

		public int HitPoints {
			get { return hitPoints; }
			set { hitPoints = value; }
		}


		public int XpForDefeat {
			get { return xpForDefeat; }
			set { xpForDefeat = value; }
		}



		public class SortByNameClass : IComparer {
			public int Compare(object obj1, object obj2) {
				Einheit e1 = (Einheit)obj1;
				Einheit e2 = (Einheit)obj2;

				return (String.Compare(e1.Typ, e2.Typ));
			}
		}

		public class SortByHpThendPrio : IComparer {
			public int Compare(object obj1, object obj2) {
				Einheit e1 = (Einheit)obj1;
				Einheit e2 = (Einheit)obj2;

				if (e1.skills.Skill8)
					return 0;

				if (e1.MaxHP > e2.MaxHP) { return 1; } else if (e1.MaxHP == e2.MaxHP) {
					if (e1.SequencePrio > e2.SequencePrio) { return 1; } else if (e1.SequencePrio == e2.SequencePrio) { return 0; } else { return -1; }
				} else { return -1; }
			}
		}

		public class SortBysequencePrioThenHp : IComparer {
			public int Compare(object obj1, object obj2) {
				Einheit e1 = (Einheit)obj1;
				Einheit e2 = (Einheit)obj2;

				if (e1.SequencePrio > e2.SequencePrio) { return 1; } else if (e1.MaxHP == e2.MaxHP) {
					if (e1.MaxHP > e2.MaxHP) { return 1; } else if (e1.MaxHP == e2.MaxHP) { return 0; } else { return -1; }
				} else { return -1; }
			}
		}



	}

}
