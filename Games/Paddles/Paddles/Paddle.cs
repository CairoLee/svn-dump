using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Paddles {

	public enum PaddleControl {
		Player,
		Computer
	}

	public class Paddle {
		Vector2 iPosition, cPosition, velocity, paddleSize;
		Rectangle boundry;
		TimeSpan eTime, cTime;
		PaddleControl control;
		string time;
		float speed;

		public Paddle(Vector2 position, Vector2 velocity, bool player) {
			this.iPosition = this.cPosition = position;
			this.velocity = velocity;
			this.speed = (float)Math.Abs(velocity.Y);
			this.paddleSize = new Vector2(10, 50);
			this.boundry = new Rectangle((int)cPosition.X, (int)cPosition.Y, (int)paddleSize.X, (int)paddleSize.Y);
			this.time = "";
			this.cTime = new TimeSpan(0, 0, 0);
			if (player == true)
				control = PaddleControl.Player;
			else
				control = PaddleControl.Computer;
		}
		public void Update(GameTime gTime, Ball ball) {
			eTime = gTime.TotalGameTime;
			if (eTime.TotalMinutes < 10)
				time = "Time - 0" + (int)(eTime.TotalMinutes);
			else
				time = "Time - " + (int)(eTime.TotalMinutes);
			if (eTime.TotalSeconds < 10)
				time += ":0" + (int)(eTime.TotalSeconds);
			else
				time += ":" + (int)(eTime.TotalSeconds);
			#region Player Controlled Paddle Code
			if (control == PaddleControl.Player) {
				eTime = gTime.TotalGameTime;
				velocity = Vector2.Zero;
				if ((ScreenManager.keyboard.MoveUp) && (cPosition.Y >= 10))
					velocity = new Vector2(0, speed * -1.0f);
				else if ((ScreenManager.keyboard.MoveDown) && (cPosition.Y <= Game1.windowSize.Y - this.paddleSize.Y - 10))
					velocity = new Vector2(0, speed);

				cPosition = cPosition + velocity;
				this.boundry = new Rectangle((int)cPosition.X, (int)cPosition.Y, (int)paddleSize.X, (int)paddleSize.Y);
			}
			#endregion
			#region Enemy Controlled Paddle Code
 else if (control == PaddleControl.Computer) {
				if (ball.Velocity.X > 0) {
					this.velocity = Vector2.Zero;
					float distance = Math.Abs(this.cPosition.Y - ball.Position.Y);
					if ((ball.Position.Y < this.cPosition.Y) && (cPosition.Y >= 10) && (distance > 10)) {
						this.velocity = new Vector2(0, speed * -1);
						cTime = eTime;
					} else if ((ball.Position.Y > this.cPosition.Y) && (cPosition.Y <= Game1.windowSize.Y - this.paddleSize.Y - 10) && (distance > 10)) {
						this.velocity = new Vector2(0, speed);
						cTime = eTime;
					}
					this.cPosition += this.velocity;
				}
				this.boundry = new Rectangle((int)cPosition.X, (int)cPosition.Y, (int)paddleSize.X, (int)paddleSize.Y);
			}
			#endregion
		}
		public void Draw() {
			Game1.sBatch.Draw(Game1.pixel, boundry, Color.White);
			Game1.sBatch.DrawString(Game1.gSFont, time, new Vector2(centerTextX(time, Game1.gSFont), 10), Color.White);
		}

		private float centerTextX(string time, SpriteFont spriteFont) {
			return (Game1.windowSize.X / 2) - (spriteFont.MeasureString(time).X / 2);
		}

		public Rectangle Boundry {
			get {
				return this.boundry;
			}
		}
	}
}
