#region Using Statements
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace Paddles {

	public class Text {
		string text;
		Vector2 position;
		float scale, sScale;
		bool bubble;
		Color sColor, bColor, color;

		public Text(string text, Vector2 position, bool bubble) {
			this.text = text;
			this.position = position;
			this.scale = this.sScale = 1.0f;
			this.bubble = bubble;
			this.sColor = Color.White;
			this.bColor = Color.Yellow;
		}
		public Text(string text, Vector2 position, bool bubble, float scale, Color color) {
			this.text = text;
			this.position = position;
			this.scale = this.sScale = scale;
			this.bubble = bubble;
			this.sColor = color;
			this.bColor = color;
		}
		public void update(GameTime gTime) {
			if (this.bubble) {
				this.scale = 1.0f + ((float)Math.Sin(gTime.TotalGameTime.TotalSeconds * 5) + 1) * 0.1f;
				this.color = this.bColor;
			} else {
				this.scale = this.sScale;
				this.color = this.sColor;
			}
		}
		public void setBubble(bool bubble) {
			this.bubble = bubble;
		}
		public void draw() {
			Game1.sBatch.DrawString(Game1.gSFont, this.text, this.position, this.color, 0.0f, Vector2.Zero, this.scale, SpriteEffects.None, 0.0f);
		}
		public Vector2 Position {
			get {
				return this.position;
			}
		}
		public string Contents {
			get {
				return this.text;
			}
		}

		public static Vector2 centerText(string victory, SpriteFont spriteFont) {
			return new Vector2((float)((Game1.windowSize.X / 2) - (spriteFont.MeasureString(victory).X / 2)),
				(float)((Game1.windowSize.Y / 2) - (spriteFont.MeasureString(victory).Y / 2)));
		}
	}
}
