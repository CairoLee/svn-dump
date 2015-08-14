using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ssc {

	[Serializable]
	public enum EGameMode {
		Leicht = 0,
		Normal = 1,
		Hart = 2,
		Ultimate = 3,
	}

	[Serializable]
	public enum EClass {
		Jäger,
		Heide,
		Orakel,
		Attentäter,
		Wächter,
		Krieger
	}

	[Serializable]
	public enum EItemBonus {
		Stärke,
		Abwehr,
		Intelligenz,
		Weisheit,
		Geschick,
		Glück,

		Verteidigung,
		Resistenz,
		SchadenMin,
		SchadenMax
	}

}
