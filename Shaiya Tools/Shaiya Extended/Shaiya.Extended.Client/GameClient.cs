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
using Shaiya.Extended.Client.Library;

namespace Shaiya.Extended.Client {

	public class GameClient : Game {
		private static GameClient mInstance;

		public static GameClient Instance {
			get { return mInstance; }
		}


		public GameClient() {
			mInstance = this;

			IsFixedTimeStep = false;
			IsMouseVisible = true;

			Constants.Graphics = new GraphicsDeviceManager( this );
			Constants.Content = new ContentManager( this.Services, "Content" );
			Constants.InputHelper = new InputHelper( this );
			Components.Add( Constants.InputHelper );
#if DEBUG
			Components.Add( new FPS( this ) );
#endif
		}

		protected override void Initialize() {
			base.Initialize();
		}

		protected override void LoadContent() {
			if( Constants.SpriteBatch == null )
				Constants.SpriteBatch = new SpriteBatch( Constants.GraphicsDevice );
		}

		protected override void UnloadContent() {
			Constants.Content.Unload();
		}

		protected override void Update( GameTime gameTime ) {
			if( Constants.InputHelper.IsActionPressed( EActions.ExitGame ) )
				this.Exit();

			base.Update( gameTime );
		}

		protected override void Draw( GameTime gameTime ) {
			Constants.GraphicsDevice.Clear( Color.CornflowerBlue );

			base.Draw( gameTime );
		}

	}

}
