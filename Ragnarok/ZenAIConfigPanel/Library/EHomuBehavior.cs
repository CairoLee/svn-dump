
namespace ZenAIConfigPanel.Library {

	public enum EHomuBehavior {
		[ConfigDescription("Escape everytime and don't even help the owner", "BEHA_avoid")]
		Avoid = 0,
		[ConfigDescription("Escape when hit, but come to help the owner", "BEHA_coward")]
		Coward = 1,
		[ConfigDescription("Defend only (highest priority) or cooperate", "BEHA_react_1st")]
		React1st = 2,
		[ConfigDescription("Defend only (medium priority) or cooperate", "BEHA_react")]
		React = 3,
		[ConfigDescription("Defend only (low priority) or cooperate", "BEHA_react_last")]
		ReactLast = 4,
		[ConfigDescription("Aggressive (when HPs are OK), highest priority", "BEHA_attack_1st")]
		Attack1st = 5,
		[ConfigDescription("Aggressive (when HPs are OK), medium priority", "BEHA_attack")]
		Attack = 6,
		[ConfigDescription("Aggressive (when HPs are OK), low priority", "BEHA_attack_last")]
		AttackLast = 7,
		[ConfigDescription("Aggressive (weak monster: ignore his attacks), low priority", "BEHA_attack_weak")]
		AttackWeak = 8,
	}


	public static class EHomuBehaviorExtension {
		public static bool FromConfig(this string Value, out EHomuBehavior Behav) {
			Behav = (EHomuBehavior)(-1);
			if (Value == "BEHA_avoid")
				Behav = EHomuBehavior.Avoid;
			else if (Value == "BEHA_coward")
				Behav = EHomuBehavior.Coward;
			else if (Value == "BEHA_react_1st")
				Behav = EHomuBehavior.React1st;
			else if (Value == "BEHA_react")
				Behav = EHomuBehavior.React;
			else if (Value == "BEHA_react_last")
				Behav = EHomuBehavior.ReactLast;
			else if (Value == "BEHA_attack_1st")
				Behav = EHomuBehavior.Attack1st;
			else if (Value == "BEHA_attack")
				Behav = EHomuBehavior.Attack;
			else if (Value == "BEHA_attack_last")
				Behav = EHomuBehavior.AttackLast;
			else if (Value == "BEHA_attack_weak")
				Behav = EHomuBehavior.AttackWeak;

			return (Behav != (EHomuBehavior)(-1));
		}
	}

}
