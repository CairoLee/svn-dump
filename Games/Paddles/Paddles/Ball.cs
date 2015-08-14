using System;
using Microsoft.Xna.Framework;
using Paddles.GameScreens;

namespace Paddles {

	public class Ball {
		Vector2 iPosition, cPosition, velocity, ballSize;
		Rectangle boundry;
		float angle;
		float speed;
		private double resetTimer = 0;

		public Vector2 Velocity {
			get { return this.velocity; }
		}

		public Vector2 Position {
			get { return this.cPosition; }
		}


		public Ball(float speed) {
			this.ballSize = new Vector2(10, 10);
			this.iPosition = this.cPosition = centerBall();
			this.boundry = new Rectangle((int)cPosition.X, (int)cPosition.Y, (int)ballSize.X, (int)ballSize.Y);
			this.speed = speed;

			this.velocity = findVelocity();
		}


		private void reset(GameTime gameTime) {
			if (resetTimer < 3000) {
				resetTimer += gameTime.ElapsedGameTime.TotalMilliseconds;
				return;
			}

			resetTimer = 0;
			this.iPosition = this.cPosition = centerBall();
			this.velocity = findVelocity();
		}

		private Vector2 centerBall() {
			return (Game1.windowSize / 2) - (this.ballSize / 2);
		}

		private Vector2 findVelocity() {
			Random random = new Random();
			int r = 0;
			while (r % 2 == 0)
				r = random.Next(1, 7);
			this.angle = (float)((r * 45 * Math.PI) / 180);

			return new Vector2((float)(this.speed * Math.Cos(this.angle)), (float)(this.speed * Math.Sin(this.angle)));
		}

		public void Update(GameTime gameTime, Paddle player, Paddle enemy) {
			if ((this.boundry.Intersects(player.Boundry) || this.boundry.Intersects(enemy.Boundry)) && ((this.boundry.Left + 3 > player.Boundry.Right) || (this.boundry.Right - 3 < enemy.Boundry.Left))) {
				this.velocity.X *= -1.0f;
				if ((this.velocity.X > -8) && (this.velocity.X < 8))
					this.velocity *= 1.05f;
			}

			if (((this.boundry.Top <= 0) || (this.boundry.Bottom >= Game1.windowSize.Y)) && (this.boundry.Right < enemy.Boundry.Left)) {
				this.velocity.Y *= -1.0f;
				if ((this.velocity.Y > -8) && (this.velocity.Y < 8))
					this.velocity *= 1.05f;
			}

			if (this.boundry.Left < 0) {
				if (resetTimer == 0)
					GameScreen.scoreComputer++;
				reset(gameTime);
			} else if (this.boundry.Right > Game1.windowSize.X) {
				if (resetTimer == 0)
					GameScreen.scorePlayer++;
				reset(gameTime);
			}

			cPosition += velocity;
			this.boundry = new Rectangle((int)cPosition.X, (int)cPosition.Y, (int)ballSize.X, (int)ballSize.Y);
		}

		public void Draw() {
			Game1.sBatch.Draw(Game1.pixel, this.boundry, Color.White);
			if (resetTimer > 0) {
				string rTime = "Reset in: " + (3 - (int)(resetTimer / 1000)) + "sec";
				Game1.sBatch.DrawString(Game1.gSFont, rTime, Text.centerText(rTime, Game1.gSFont), Color.Yellow);
			}
		}


	}
}
