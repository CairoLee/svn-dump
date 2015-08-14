using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseEditor.Library.Classes {

	[Flags()]
	public enum ERace {
		Formless = 0,
		Undead,
		Brute,
		Plant,
		Insect,
		Fish,
		Demon,
		DemiHuman,
		Angel,
		Dragon,
		Boss,
		NonBoss,
		NonDemiHuman,
	}

}
