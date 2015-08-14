#if false
using System;
using System.Collections.Generic;
using System.Text;
using FreeWorld.Engine.TileEngine;
using Microsoft.Xna.Framework.Graphics;
using FreeWorld.Engine;
using Microsoft.Xna.Framework;

namespace FreeWorld.Game {

	public class AnimatedSpriteList : List<AnimatedSprite> {

		public void Draw(SpriteFont SpriteFont) {
			Draw(EngineCore.SpriteBatch, SpriteFont, false);
		}

		public void Draw(SpriteBatch SpriteBatch, SpriteFont SpriteFont) {
			Draw(SpriteBatch, SpriteFont, false);
		}

		public void Draw(SpriteBatch SpriteBatch, SpriteFont SpriteFont, bool DrawAttributes) {
			foreach (AnimatedSprite s in this)
				s.Draw(SpriteBatch, SpriteFont, DrawAttributes);
		}


		public void Update(GameTime gameTime) {
			Update(gameTime, null, false);
		}

		public void Update(GameTime gameTime, TileMap TileMap, bool HandleInput) {
			foreach (AnimatedSprite s in this)
				s.Update(gameTime, TileMap, HandleInput);
		}

	}

}
#endif