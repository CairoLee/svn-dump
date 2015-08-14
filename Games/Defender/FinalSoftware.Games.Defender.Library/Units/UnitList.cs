using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalSoftware.Games.Defender.Library.Units {

	public class UnitList : List<Unit>, IDefenderDraw {

		public virtual void Initialize() {
			for( int i = 0; i < Count; i++ )
				this[ i ].Initialize();
		}

		public virtual void LoadContent() {
			for( int i = 0; i < Count; i++ )
				this[ i ].LoadContent();
		}


		public virtual void Update( GameTime gameTime ) {
			for( int i = 0; i < Count; i++ ) {
				this[ i ].Update( gameTime );
			}
		}

		public virtual void Draw( GameTime gameTime, SpriteBatch spriteBatch, SpriteBatch additiveBatch ) {
			for( int i = 0; i < Count; i++ )
				this[ i ].Draw( gameTime, spriteBatch, additiveBatch );
		}

	}

}
