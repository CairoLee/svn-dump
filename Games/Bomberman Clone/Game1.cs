#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using System.Collections;
#endregion

namespace Bomberman_Clone {

	public class BomberMan : Game {
		public static ArrayList bombs = new ArrayList();
		public static ArrayList explosions = new ArrayList();

		private GraphicsDeviceManager graphics;
		private SpriteBatch sb;
		private SpriteFont font;
		private Player player;

		private Texture2D bombsTexture;
		private Texture2D playerSprite;
		private float buttonDelay = 0.5f;
		private float elapsed = 0.0f;
		private bool collision;

		private float fps;
		private float updateInterval = 0.5f;
		private float timeSinceLastUpdate = 0.0f;
		private float frameCount = 0;


		public BomberMan() {
			graphics = new GraphicsDeviceManager( this );
			graphics.SynchronizeWithVerticalRetrace = true;
			graphics.PreferredBackBufferHeight = 600;
			graphics.PreferredBackBufferWidth = 800;

			Content.RootDirectory = "Content";
		}


		protected override void Initialize() {
			sb = new SpriteBatch( graphics.GraphicsDevice );
			base.Initialize();
		}

		protected override void LoadContent() {
			font = Content.Load<SpriteFont>( @"Sprites\Arial" );
			player = new Player();
			playerSprite = Content.Load<Texture2D>( @"Sprites\bomberman_black" );
			bombsTexture = Content.Load<Texture2D>( @"Sprites\bomberman_bomb_sheet" );
		}

		protected override void UnloadContent() {
			Content.Unload();
		}

		protected override void Update( GameTime gameTime ) {

			if( Keyboard.GetState().IsKeyDown( Keys.Escape ) )
				this.Exit();

			if( player.IsDead != true ) {
				if( Keyboard.GetState().IsKeyDown( Keys.Up ) )
					player.Move( MoveDirection.Up );
				else if( Keyboard.GetState().IsKeyDown( Keys.Down ) )
					player.Move( MoveDirection.Down );
				else if( Keyboard.GetState().IsKeyDown( Keys.Right ) )
					player.Move( MoveDirection.Right );
				else if( Keyboard.GetState().IsKeyDown( Keys.Left ) )
					player.Move( MoveDirection.Left );
				else
					player.Move( MoveDirection.Idle );
			}

			elapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
			if( elapsed >= buttonDelay ) {
				if( player.BombPlaced == false && ( Keyboard.GetState().IsKeyDown( Keys.Space ) ) ) {
					player.BombPlaced = true;
					player.plantBomb( player );
					elapsed = 0.0f;
				} else {
					player.BombPlaced = false;
				}
			}


			if( bombs != null )
				Bomb.Update( gameTime );
			if( explosions != null )
				Explosion.Update( gameTime );

			collision = Collision.checkDeath( player );

			base.Update( gameTime );
		}

		protected override void Draw( GameTime gameTime ) {
			graphics.GraphicsDevice.Clear( Color.CornflowerBlue );
			sb.Begin();
			#region Frames Per Second Stuff
			float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
			frameCount++;
			timeSinceLastUpdate += elapsed;
			if( timeSinceLastUpdate > updateInterval ) {
				fps = frameCount / timeSinceLastUpdate;
				frameCount = 0;
				timeSinceLastUpdate -= updateInterval;
			}
			string FPS = String.Empty;
			FPS += "FPS: " + fps.ToString();
			//FPS += " - RT: " + gameTime.ElapsedRealTime.TotalSeconds.ToString();
			//FPS += " - GT: " + gameTime.ElapsedGameTime.ToString();
			sb.DrawString( font, FPS, new Vector2( 60, 70 ), Color.Black );
			#endregion


			// Begin Debug Info
			sb.DrawString( font, "Player X: " + player.playerPosition.X.ToString(), new Vector2( 60, 30 ), Color.Black );
			sb.DrawString( font, "Player Y: " + player.playerPosition.Y.ToString(), new Vector2( 60, 50 ), Color.Black );
			sb.DrawString( font, "Bombs: " + player.CurrentBombs.ToString(), new Vector2( 60, 90 ), Color.Black );
			sb.DrawString( font, "Player Collision: " + collision.ToString(), new Vector2( 60, 110 ), Color.Black );
			// End Debug Info

			if( collision != true && player.IsDead != true ) {
				switch( player.currentDirection ) {
					case MoveDirection.Up:
						Animation.DrawAnimation( sb, playerSprite, player, player.Up, gameTime, 0.5f );
						break;
					case MoveDirection.Right:
						Animation.DrawAnimation( sb, playerSprite, player, player.Right, gameTime, 0.5f );
						break;
					case MoveDirection.Down:
						Animation.DrawAnimation( sb, playerSprite, player, player.Down, gameTime, 0.5f );
						break;
					case MoveDirection.Left:
						Animation.DrawAnimation( sb, playerSprite, player, player.Left, gameTime, 0.5f );
						break;
					default:
						Animation.DrawAnimation( sb, playerSprite, player, player.Idle, gameTime, 0.5f );
						break;
				}
				// Draw Bombs
				for( int i = 0; i < bombs.Count; i++ ) {
					Bomb bomb = (Bomb)bombs[ i ];
					if( bomb.Detonate == false )
						Animation.DrawAnimation( sb, bombsTexture, bomb.TimerAnimation, gameTime, bomb.Position, true, 0.5f );
					else {
						bombs.RemoveAt( i );
					}
				}
				for( int j = 0; j < explosions.Count; j++ ) {
					Explosion exp = (Explosion)explosions[ j ];
					if( exp.Elapsed < exp.ExplosionTime ) {
						Animation.DrawAnimation( sb, bombsTexture, exp.FlameMiddle, gameTime, exp.Position, false, 0.1f );
						Animation.DrawAnimation( sb, bombsTexture, exp.FlameLeft, gameTime, exp.positionLeft, false, 0.1f );
						Animation.DrawAnimation( sb, bombsTexture, exp.FlameRight, gameTime, exp.positionRight, false, 0.1f );
					} else
						explosions.RemoveAt( j );
				}
			} else {
				player.IsDead = true;
				sb.DrawString( font, "PWNED", new Vector2( 380, 200 ), Color.Red );
			}

			sb.End();
			base.Draw( gameTime );
		}

	}
}
