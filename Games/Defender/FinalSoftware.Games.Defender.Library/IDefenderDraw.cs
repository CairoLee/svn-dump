using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalSoftware.Games.Defender.Library {

	public interface IDefenderDraw {

		void Initialize();
		void LoadContent();
		void Update( GameTime gameTime );
		void Draw( GameTime gameTime, SpriteBatch spriteBatch, SpriteBatch additiveBatch );

	}

}
