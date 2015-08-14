using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacMan {

	/// <summary>
	/// Defines a position on the board where a ghost has died or a fruit was eaten, as well as the score earned.
	/// This is used for knowing where to draw those scores
	/// </summary>
	public struct ScoreEvent {
		public EntityPosition Position;
		public DateTime Date;
		public int Score;


		public ScoreEvent(EntityPosition position, DateTime date, int score) {
			Position = position;
			Date = date;
			Score = score;
		}
	}

}
