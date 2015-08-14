using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Puzzle3D {

	public class MessageBoxScreen : GameScreen {
		string message;

		public event EventHandler<EventArgs> Accepted;
		public event EventHandler<EventArgs> Cancelled;


		public MessageBoxScreen( string message )
			: this( message, true ) {
		}

		public MessageBoxScreen( string message, bool includeUsageText ) {
			const string usageText = "\nA button, Space, Enter = ok\nB button, Esc = cancel";
			if( includeUsageText )
				this.message = message + usageText;
			else
				this.message = message;

			IsPopup = true;

			TransitionOnTime = TimeSpan.FromSeconds( 0.2 );
			TransitionOffTime = TimeSpan.FromSeconds( 0.2 );
		}


		public override void HandleInput( InputState input ) {
			if( input.MenuSelect ) {
				if( Accepted != null )
					Accepted( this, EventArgs.Empty );
				ExitScreen();
			} else if( input.MenuCancel ) {
				if( Cancelled != null )
					Cancelled( this, EventArgs.Empty );
				ExitScreen();
			}
		}


		public override void Draw( GameTime gameTime ) {
			SpriteBatch spriteBatch = ScreenManager.SpriteBatch;
			SpriteFont font = ScreenManager.Font;

			ScreenManager.FadeBackBufferToBlack( TransitionAlpha * 2 / 3 );

			Viewport viewport = ScreenManager.GraphicsDevice.Viewport;
			Vector2 viewportSize = new Vector2( viewport.Width, viewport.Height );
			Vector2 textSize = font.MeasureString( message );
			Vector2 textPosition = ( viewportSize - textSize ) / 2;

			Color color = new Color( 255, 255, 255, TransitionAlpha );

			spriteBatch.Begin();

			spriteBatch.DrawString( font, message, textPosition, color );

			spriteBatch.End();
		}

	}

}
