

namespace GodLesZ.SettlerOnline.FightSimulator.Klassen {
	class Skills {
		int skill0;
		int skill1;
		bool skill2;
		bool skill3;
		bool skill4;
		bool skill5;
		bool skill6;
		bool skill7;
		bool skill8;

		public Skills() {
			skill0 = 0;
			skill1 = 0;
			skill2 = false;
			skill3 = false;
			skill4 = false;
			skill5 = false;
			skill6 = false;
			skill7 = false;
			skill8 = false;
		}

		/// <summary>
		/// Bonus damage vs. buildings +250%
		/// </summary>
		public int Skill0 {
			get { return skill0; }
			set { skill0 = value; }
		}

		/// <summary>
		/// Bonus damage vs. units +250%  
		/// </summary>
		public int Skill1 {
			get { return skill0; }
			set { skill0 = value; }
		}

		/// <summary>
		/// Attacks weakest unit first   
		/// </summary>
		public bool Skill2 {
			get { return skill2; }
			set { skill2 = value; }
		}

		/// <summary>
		/// Splash damage		
		/// </summary>
		public bool Skill3 {
			get { return skill3; }
			set { skill3 = value; }
		}

		/// <summary>
		/// Bonus Tower Armor	
		/// </summary>
		public bool Skill4 {
			get { return skill4; }
			set { skill4 = value; }
		}

		/// <summary>
		/// First Strike   
		/// </summary>
		public bool Skill5 {
			get { return skill5; }
			set { skill5 = value; }
		}

		/// <summary>
		/// Last Strike
		/// </summary>
		public bool Skill6 {
			get { return skill6; }
			set { skill6 = value; }
		}

		/// <summary>
		/// Ignores [x] % armor vs units in tower
		/// </summary>
		public bool Skill7 {
			get { return skill7; }
			set { skill7 = value; }
		}

		/// <summary>
		/// Is Specialist       
		/// </summary>
		public bool Skill8 {
			get { return skill8; }
			set { skill8 = value; }
		}
	}
}
