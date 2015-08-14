using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GodLesZ.Library.MonoGame.Extensions {

	public static class SpritebatchExtensions {

		public static void DrawLine(this SpriteBatch batch, Texture2D LineTexture, Microsoft.Xna.Framework.Rectangle rect, Color Col) {
			batch.Draw(LineTexture, rect, Col);
		}

		public static void DrawStringShadowed(this SpriteBatch SpriteBatch, SpriteFont font, string text, Vector2 position, Color color, Color shadowColor) {
			SpriteBatch.DrawString(font, text, new Vector2(position.X + 1f, position.Y + 1f), shadowColor);
			SpriteBatch.DrawString(font, text, position, color);
		}

		public static void DrawRectangle(this SpriteBatch spriteBatch, Texture2D lineTexture, Rectangle area, int lineWidth, Color color) {
			DrawRectangle(spriteBatch, lineTexture, area, lineWidth, new Color[4] { color, color, color, color });
		}

		public static void DrawRectangle(this SpriteBatch spriteBatch, Texture2D lineTexture, Rectangle area, int lineWidth, Color[] color) {
			Rectangle rect = area;

			// | left 
			rect.Width = lineWidth;
			rect.Height = area.Height;
			spriteBatch.Draw(lineTexture, rect, color[2]);
			// | right
			rect.Width = lineWidth;
			rect.Height = area.Height;
			rect.X += area.Width - lineWidth;
			spriteBatch.Draw(lineTexture, rect, color[3]);

			rect.X -= area.Width - lineWidth;

			// - top
			rect.Width = area.Width;
			rect.Height = lineWidth;
			spriteBatch.Draw(lineTexture, rect, color[0]);
			// - bottom
			rect.Width = area.Width;
			rect.Height = lineWidth;
			rect.Y += area.Height - lineWidth;
			spriteBatch.Draw(lineTexture, rect, color[1]);
		}

	}

}
