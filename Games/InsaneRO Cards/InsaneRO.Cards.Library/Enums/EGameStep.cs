using System;
using System.Collections.Generic;
using System.Text;

namespace InsaneRO.Cards.Library {

	public enum EGameStep {
		/// <summary>
		/// Game not started yet
		/// </summary>
		None = 0,

		/// <summary>
		/// draw a Card
		/// </summary>
		DrawPhase = 1,

		/// <summary>
		/// set Cards to the Field
		/// </summary>
		StandbyPhase,

		/// <summary>
		/// Attackstep 1: declare attacking Cards
		/// </summary>
		AttackPhase,

		/// <summary>
		/// Attackstep 2: react on attacking Cards
		/// </summary>
		AttackReactPhase,

		/// <summary>
		/// Attackstep 3: make damage
		/// </summary>
		AttackDamagePhase,

		/// <summary>
		/// set Cards to the Field - after AttackPhase
		/// </summary>
		AfterAttackPhase,

		/// <summary>
		/// Turn is over, switch to opponent
		/// </summary>
		EndOfTurn

	}

}
