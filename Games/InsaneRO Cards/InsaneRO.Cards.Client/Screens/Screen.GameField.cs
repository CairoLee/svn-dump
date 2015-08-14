using System;
using System.Collections.Generic;
using System.Text;
using InsaneRO.Cards.Client.Compontents;
using Microsoft.Xna.Framework;
using InsaneRO.Cards.Library;
using System.Diagnostics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace InsaneRO.Cards.Client.Screens {

	public class ScreenGameField : GameScreen {
		private Player mPlayer;


		public ScreenGameField( GameClient game )
			: base( game ) {
			Name = "GameField";
			IsActive = true;
			InputHandle = true;

			mPlayer = Game.Player;
		}


		public override void Initialize() {
			base.Initialize();
		}

		public override void LoadContent() {
			base.LoadContent();

			// add 4 Poring Cards
			mPlayer.DeckHandler.Deck.Add( Card.CardList[ 0 ] );
			mPlayer.DeckHandler.Deck.Add( Card.CardList[ 0 ] );
			mPlayer.DeckHandler.Deck.Add( Card.CardList[ 0 ] );
			mPlayer.DeckHandler.Deck.Add( Card.CardList[ 0 ] );

			// test limitdeck parameter
			if( mPlayer.DeckHandler.Deck.Add( Card.CardList[ 0 ] ) == false )
				System.Diagnostics.Debug.WriteLine( "failed to add card no. 5!" );
			else
				System.Diagnostics.Debug.WriteLine( "successfull added card no. 5?" );

			// load textures
			mPlayer.DeckHandler.LoadCards( Game.Content );
		}

		public override void Update( GameTime gameTime ) {
			base.Update( gameTime );

			mPlayer.Update( gameTime );
			if( mPlayer.Step == EGameStep.None ) {
				// game not started yet - let it start
				mPlayer.Step = EGameStep.DrawPhase;
				mPlayer.NeedToDraw = true;
			} else if( mPlayer.Step == EGameStep.DrawPhase ) {
				// draw phase, try to draw new card
				if( mPlayer.NeedToDraw == true ) {
					if( mPlayer.DeckHandler.Deck.Count == 0 ) {
						// we cant draw a card..
						mPlayer.NeedToDraw = false;
					} else {
						if( mPlayer.DrawCard() == null )
							Debug.WriteLine( "Player '" + mPlayer.Name + "' failed to draw a Card?" );
					}
				}
			}
		}

		public override void Draw( GameTime gameTime ) {
			base.Draw( gameTime );

			Vector2 stepPos = new Vector2( 10, 10 );
			Vector2 basePos = new Vector2( 10, 200 );
			Vector2 scaleCard = new Vector2( 1.0f, 1.0f );

			SpriteBatch.Begin();

			// draw players hand
			foreach( DeckCard card in mPlayer.HandHandler.Deck.Cards.Values ) {
				Vector2 cardOrgin = new Vector2( card.Texture.Width * 0.5f, card.Texture.Height * 0.5f );
				// may have more than one in his hand!
				for( int i = 0; i < card.DeckCount; i++ ) {
					SpriteBatch.Draw( card.Texture, new Rectangle( (int)basePos.X, (int)basePos.Y, (int)( card.Texture.Width * scaleCard.X ), (int)( card.Texture.Height * scaleCard.Y ) ), null, Color.White, MathHelper.ToRadians( 30 ), cardOrgin, SpriteEffects.None, 0f );
					basePos.X += card.Texture.Width + 10;
				}
			}

			SpriteBatch.DrawString( SpriteFont, "Step: " + mPlayer.Step, stepPos, Color.White );
			SpriteBatch.DrawString( SpriteFont, "Timer: " + mPlayer.StepTimer, stepPos + new Vector2( 0, 15 ), Color.White );

			SpriteBatch.End();
		}

		public override void HandleInput( InputHelper Input, GameTime gameTime ) {
			base.HandleInput( Input, gameTime );

			// switch through steps
			if( Input.WasKeyPressed( Keys.S ) )
				mPlayer.Step++;
		}

	}

}
