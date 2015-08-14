using System;
using Microsoft.Xna.Framework;

namespace Paddles.GameScreens {

	public enum State {
		Playing,
		Victory
	}

	public class GameScreen {
		Paddle player, enemy;
		Ball ball;
		State state = State.Playing;
		public static TimeSpan sTime, eTime;
		public static int scorePlayer, scoreComputer, scoreFinal;
		public string victory;

		public GameScreen() {
			player = new Paddle(new Vector2(50, 200), new Vector2(0, 8), true);
			enemy = new Paddle(new Vector2(Game1.windowSize.X - 50, 200), new Vector2(0, 8), false);
			ball = new Ball(6);
			scoreFinal = 5;
		}


		public static void Start(GameTime gTime) {
			sTime = gTime.TotalGameTime;
		}

		public void Update(GameTime gTime) {
			if (state == State.Playing) {
				player.Update(gTime, ball);
				enemy.Update(gTime, ball);
				ball.Update(gTime, player, enemy);
			}
			if (scorePlayer > scoreFinal) {
				state = State.Victory;
				victory = "Congratulations! You beat the computer. Your Score: " + scorePlayer + "     Computer Score: " + scoreComputer;
			} else if (scoreComputer > scoreFinal) {
				state = State.Victory;
				victory = "Better luck next time! Your Score: " + scorePlayer + "     Computer Score: " + scoreComputer;
			}
		}

		public void Draw() {
			player.Draw();
			enemy.Draw();
			Game1.sBatch.DrawString(Game1.gSFont, "Score: " + scorePlayer, new Vector2(5, 10), Color.Yellow);
			Game1.sBatch.DrawString(Game1.gSFont, "Computer: " + scoreComputer, new Vector2(Game1.windowSize.X - Game1.gSFont.MeasureString("Computer: " + scoreComputer).X - 5, 10), Color.Yellow);
			if (state == State.Victory)
				Game1.sBatch.DrawString(Game1.gSFont, victory, Text.centerText(victory, Game1.gSFont), Color.Yellow);
			else
				ball.Draw();
		}

	}

}
