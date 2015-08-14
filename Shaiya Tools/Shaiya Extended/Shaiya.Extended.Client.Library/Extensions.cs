using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shaiya.Extended.Client.Library {

	public static class Extensions {

		public static void DrawStringShadowed( this SpriteBatch SpriteBatch, SpriteFont font, string text, Vector2 position, Color color, Color shadowColor ) {
			SpriteBatch.DrawString( font, text, new Vector2( position.X + 1f, position.Y + 1f ), shadowColor );
			SpriteBatch.DrawString( font, text, position, color );
		}

	}

}
