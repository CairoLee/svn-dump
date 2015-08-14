using System;
using Microsoft.Xna.Framework.Graphics;
using XnaKeys = Microsoft.Xna.Framework.Input.Keys;
using Microsoft.Xna.Framework;

namespace InsaneRO.Cards.Client {
	public static class KeyboardStateExtensions {

		public static bool IsCtrlDown( this Microsoft.Xna.Framework.Input.KeyboardState KeyState ) {
			return KeyState.IsKeyDown( XnaKeys.LeftControl ) || KeyState.IsKeyDown( XnaKeys.RightControl );
		}

		public static bool IsCtrlUp( this Microsoft.Xna.Framework.Input.KeyboardState KeyState ) {
			return KeyState.IsCtrlDown() == false;
		}

		public static bool IsShiftDown( this Microsoft.Xna.Framework.Input.KeyboardState KeyState ) {
			return KeyState.IsKeyDown( XnaKeys.LeftShift ) || KeyState.IsKeyDown( XnaKeys.RightShift );
		}

		public static bool IsShiftUp( this Microsoft.Xna.Framework.Input.KeyboardState KeyState ) {
			return KeyState.IsShiftDown() == false;
		}

	}

	public static class SpritebatchExtensions {

		public static void DrawLine( this SpriteBatch batch, Texture2D LineTexture, Microsoft.Xna.Framework.Rectangle rect, Color Col ) {
			batch.Draw( LineTexture, rect, Col );
		}

		public static void DrawStringShadowed( this SpriteBatch SpriteBatch, SpriteFont font, string text, Vector2 position, Color color, Color shadowColor ) {
			SpriteBatch.DrawString( font, text, new Vector2( position.X + 1f, position.Y + 1f ), shadowColor );
			SpriteBatch.DrawString( font, text, position, color );
		}

		public static void DrawRectangle( this SpriteBatch mSpriteBatch, Texture2D LineTexture, Rectangle Position, int LineWidth, Color Col ) {
			Rectangle rect = Position;

			// | left 
			rect.Width = LineWidth;
			rect.Height = Position.Height;
			mSpriteBatch.Draw( LineTexture, rect, Col );
			// | right
			rect.Width = LineWidth;
			rect.Height = Position.Height;
			rect.X += Position.Width - LineWidth;
			mSpriteBatch.Draw( LineTexture, rect, Col );

			rect.X -= Position.Width - LineWidth;

			// - top
			rect.Width = Position.Width;
			rect.Height = LineWidth;
			mSpriteBatch.Draw( LineTexture, rect, Col );
			// - bottom
			rect.Width = Position.Width;
			rect.Height = LineWidth;
			rect.Y += Position.Height - LineWidth;
			mSpriteBatch.Draw( LineTexture, rect, Col );
		}

		public static void DrawRectangle( this SpriteBatch mSpriteBatch, Texture2D LineTexture, Rectangle Position, int LineWidth, Color[] Col ) {
			Rectangle rect = Position;

			// | left 
			rect.Width = LineWidth;
			rect.Height = Position.Height;
			mSpriteBatch.Draw( LineTexture, rect, Col[ 2 ] );
			// | right
			rect.Width = LineWidth;
			rect.Height = Position.Height;
			rect.X += Position.Width - LineWidth;
			mSpriteBatch.Draw( LineTexture, rect, Col[ 3 ] );

			rect.X -= Position.Width - LineWidth;

			// - top
			rect.Width = Position.Width;
			rect.Height = LineWidth;
			mSpriteBatch.Draw( LineTexture, rect, Col[ 0 ] );
			// - bottom
			rect.Width = Position.Width;
			rect.Height = LineWidth;
			rect.Y += Position.Height - LineWidth;
			mSpriteBatch.Draw( LineTexture, rect, Col[ 1 ] );
		}

	}

	public static class DateTimeExtesions {

		public static int UnixTimestamp( this DateTime Date ) {
			TimeSpan span = Date - new DateTime( 1970, 1, 1 );
			return Convert.ToInt32( span.TotalSeconds );
		}

	}

}
