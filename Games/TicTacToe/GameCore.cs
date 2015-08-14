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

namespace TicTacToe {

	public class GameCore : Game {
		private GraphicsDeviceManager mGraphics;
		private SpriteBatch mSpriteBatch;

		private Texture2D mTexO;
		private Texture2D mTexX;
		private Texture2D mTexStroke;


		public GameCore() {
			mGraphics = new GraphicsDeviceManager( this );
			mGraphics.PreferredBackBufferWidth = 800;
			mGraphics.PreferredBackBufferHeight = 600;

			Content.RootDirectory = "Content";

			IsMouseVisible = true;
		}


		protected override void Initialize() {
			base.Initialize();
		}

		protected override void LoadContent() {
			mSpriteBatch = new SpriteBatch( GraphicsDevice );

			mTexO = Content.Load<Texture2D>( "o" );
			mTexX = Content.Load<Texture2D>( "x" );
			mTexStroke = Content.Load<Texture2D>( "stroke" );
		}

		protected override void UnloadContent() {
			Content.Unload();
		}


		protected override void Update( GameTime gameTime ) {
			if( GamePad.GetState( PlayerIndex.One ).Buttons.Back == ButtonState.Pressed )
				this.Exit();

			base.Update( gameTime );
		}

		protected override void Draw( GameTime gameTime ) {
			GraphicsDevice.Clear( Color.White );

			mSpriteBatch.Begin();

			// test stroke
			mSpriteBatch.Draw( mTexStroke, new Rectangle( 0, 0, mTexStroke.Width, mTexStroke.Height ), Color.White );

			// test X
			mSpriteBatch.Draw( mTexX, new Rectangle( mTexX.Width, mTexX.Height, mTexX.Width, mTexX.Height ), Color.White );

			mSpriteBatch.End();

			base.Draw( gameTime );
		}

	}

}
