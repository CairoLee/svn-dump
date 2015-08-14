using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Puzzle3D {

	public class ImageMenuEntry : MenuEntry {
		Texture2D texture;
		Vector2 textureOrigin = Vector2.Zero;

		public Texture2D Texture {
			get { return texture; }
			set {
				texture = value;
				if( texture == null ) {
					textureOrigin = Vector2.Zero;
				} else {
					textureOrigin = new Vector2( texture.Width / 2, texture.Height / 2 );
				}
			}
		}


		public ImageMenuEntry( Texture2D texture )
			: base( "ImageMenuEntry" ) {
			this.texture = texture;
		}


		public override void Draw( MenuScreen screen, Vector2 position, bool isSelected, GameTime gameTime ) {
			if( texture == null ) {
				base.Draw( screen, position, isSelected, gameTime );
			} else {
				double time = gameTime.TotalGameTime.TotalSeconds;
				float pulsate = (float)Math.Sin( time * 6 ) + 1;
				float scale = 1 + pulsate * 0.05f * selectionFade;

				Color color = new Color( Vector4.One * ( 1.0f - screen.TransitionPosition ) );

				ScreenManager screenManager = screen.ScreenManager;
				SpriteBatch spriteBatch = screenManager.SpriteBatch;

				spriteBatch.Draw( texture, position, null, color, 0, textureOrigin, scale, SpriteEffects.None, 0 );
			}
		}

	}

}
