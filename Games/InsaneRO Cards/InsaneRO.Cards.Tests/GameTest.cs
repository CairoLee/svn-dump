using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using InsaneRO.Cards.Library.Formats;
using System.Diagnostics;
using InsaneRO.Cards.Library;

namespace InsaneRO.Cards.Tests {

	public class GameTest : Microsoft.Xna.Framework.Game {
		private GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;
		private SpriteFont spriteFont;
		private AnimationHandler mAnimation;
		private Texture2D poringCard;
		private Player mPlayer;

		private KeyboardState oldState, state;
		private MouseState mouseState;

		private int mDrawAction = 0;


		public GameTest() {
			graphics = new GraphicsDeviceManager( this );
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
			//graphics.IsFullScreen = true;
		}


		protected override void Initialize() {
			mPlayer = new Player( "GodLesZ", 10 );

			base.Initialize();
		}

		protected override void LoadContent() {
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch( GraphicsDevice );
			spriteFont = Content.Load<SpriteFont>( "Fonts/Tahoma" );

			state = Keyboard.GetState();

			// provide Cardlist
			// => default to Poring
			Card.CardList.Add( new Card() );

			// add 3 Poring Cards
			mPlayer.DeckHandler.Deck.Add( Card.CardList[ 0 ] );
			mPlayer.DeckHandler.Deck.Add( Card.CardList[ 0 ] );
			mPlayer.DeckHandler.Deck.Add( Card.CardList[ 0 ] );

			// load textures
			mPlayer.DeckHandler.LoadCards( Content );

			// testing stuff..
			poringCard = Content.Load<Texture2D>( "Cards/1002" );

			RagnarokAnimation ani = new RagnarokAnimation();
			ani.Read( Content.RootDirectory + @"\Mobs\1002.ani", true );

			mAnimation = new AnimationHandler( ani );
			mAnimation.Initialize( GraphicsDevice );
			mAnimation.SetFrameLength( 0.15f );
		}

		protected override void UnloadContent() {
			Content.Unload();
		}

		protected override void Update( GameTime gameTime ) {
			oldState = state;
			state = Keyboard.GetState();
			mouseState = Mouse.GetState();
			if( oldState.IsKeyDown( Keys.Escape ) && state.IsKeyUp( Keys.Escape ) )
				this.Exit();

			// mod framerate for testing best speed
			if( oldState.IsKeyDown( Keys.Up ) && state.IsKeyUp( Keys.Up ) )
				mAnimation.FrameLength += 0.001f;
			if( oldState.IsKeyDown( Keys.Down ) && state.IsKeyUp( Keys.Down ) )
				mAnimation.FrameLength -= 0.001f;

			// switch actions
			if( oldState.IsKeyDown( Keys.Right ) && state.IsKeyUp( Keys.Right ) )
				mDrawAction = ( mDrawAction + 1 ) % mAnimation.ActionCount;
			if( oldState.IsKeyDown( Keys.Left ) && state.IsKeyUp( Keys.Left ) ) {
				mDrawAction--;
				if( mDrawAction < 0 )
					mDrawAction = mAnimation.ActionCount - 1;
			}

			mAnimation.Update( gameTime.ElapsedGameTime.TotalSeconds );


			base.Update( gameTime );
		}

		protected override void Draw( GameTime gameTime ) {
			float scale = 0.5f;
			Vector2 pos = new Vector2( 10, 180 );
			Rectangle bounds = new Rectangle( (int)pos.X, (int)pos.Y, (int)( poringCard.Width * scale ), (int)( poringCard.Height * scale ) );
			GraphicsDevice.Clear( Color.CornflowerBlue );

			spriteBatch.Begin();
			mAnimation.DrawAction( mDrawAction, spriteBatch, new Point( 100, 100 ) );

			spriteBatch.DrawString( spriteFont, "Framelength: " + mAnimation.FrameLength.ToString() + " (Up/Down)", new Vector2( 10, 10 ), Color.Black );
			spriteBatch.DrawString( spriteFont, "Action: " + ( mDrawAction + 1 ).ToString() + "/" + mAnimation.ActionCount + " (Left/Right)", new Vector2( 10, 25 ), Color.Black );

			if( bounds.Intersects( new Rectangle( mouseState.X, mouseState.Y, 1, 1 ) ) == true )
				spriteBatch.Draw( poringCard, pos, Color.White );
			else
				spriteBatch.Draw( poringCard, pos, null, Color.White, 0, Vector2.Zero, scale, SpriteEffects.None, 0f );

			Card card = Card.CardList[ 0 ];
			spriteBatch.DrawString( spriteFont, "Card Attributes", new Vector2( 400, pos.Y - 1 ), Color.White );
			spriteBatch.DrawString( spriteFont, "Card Attributes", new Vector2( 400, pos.Y + 1 ), Color.White );
			spriteBatch.DrawString( spriteFont, "Card Attributes", new Vector2( 400 - 1, pos.Y ), Color.White );
			spriteBatch.DrawString( spriteFont, "Card Attributes", new Vector2( 400 + 1, pos.Y ), Color.White );
			spriteBatch.DrawString( spriteFont, "Card Attributes", new Vector2( 400, pos.Y ), Color.Black );
			spriteBatch.DrawString( spriteFont, "ID: " + card.ID, new Vector2( 400, pos.Y + 15 ), Color.Black );
			spriteBatch.DrawString( spriteFont, "Name: " + card.Name, new Vector2( 400, pos.Y + 30 ), Color.Black );
			spriteBatch.DrawString( spriteFont, "Race: " + card.Race, new Vector2( 400, pos.Y + 45 ), Color.Black );
			spriteBatch.DrawString( spriteFont, "Element: " + card.Element, new Vector2( 400, pos.Y + 60 ), Color.Black );
			spriteBatch.DrawString( spriteFont, "Cost: " + card.Cost, new Vector2( 400, pos.Y + 75 ), Color.Black );
			spriteBatch.DrawString( spriteFont, "Power: " + card.Strength + "/" + card.Defence, new Vector2( 400, pos.Y + 90 ), Color.Black );
			spriteBatch.DrawString( spriteFont, "Type: " + card.Type, new Vector2( 400, pos.Y + 105 ), Color.Black );


			spriteBatch.End();

			base.Draw( gameTime );
		}

	}

}
