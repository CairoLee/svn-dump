using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;


namespace GLibary {
	public static class SpriteBatchExtensions {
		public static void DrawStringImmediate( this SpriteBatch sb, SpriteFont font,
			string text, Vector2 pos, Color color ) {
			sb.Begin( SpriteBlendMode.AlphaBlend,
					 SpriteSortMode.Immediate,
					 SaveStateMode.SaveState );

			sb.DrawString( font,
				text,
				pos,
				color );

			sb.End();

		}


		public static void DrawImmediate( this SpriteBatch sb,
			Texture2D texture,
			Rectangle destinationRectangle,
			Color color ) {
			sb.Begin();

			sb.Draw( texture, destinationRectangle, color );

			sb.End();

		}

	}
}
