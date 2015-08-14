using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using System.Diagnostics;

namespace Puzzle3D {

	public class Puzzle3D : Microsoft.Xna.Framework.Game {
		public static readonly TimeSpan TransitionTime = TimeSpan.FromSeconds( 2.5 );
		private static Puzzle3D mInstance;

		public static Puzzle3D Instance {
			get { return mInstance; }
		}

		GraphicsDeviceManager graphics;

		public Puzzle3D() {
			if( mInstance != null )
				throw new InvalidOperationException( "Only one instance of Puzzle3D may be created." );

			mInstance = this;

			graphics = new GraphicsDeviceManager( this );
			graphics.MinimumVertexShaderProfile = ShaderProfile.VS_2_0;
			graphics.MinimumPixelShaderProfile = ShaderProfile.PS_2_0;

			graphics.PreferredBackBufferWidth = 800;
			graphics.PreferredBackBufferHeight = 600;
			Window.AllowUserResizing = true;
			graphics.IsFullScreen = false;

			Content.RootDirectory = "Content";

			ScreenManager screenManager = new ScreenManager( this );
			Components.Add( screenManager );

			PictureDatabase.Initialize();
			if( PictureDatabase.Count >= 2 ) {
				screenManager.AddScreen( new MainMenuScreen() );
			} else {
				MessageBoxScreen messageBox = new MessageBoxScreen( "Unable to find enough pictures to play.", false );
				messageBox.Accepted += new EventHandler<EventArgs>( messageBox_Accepted );
				screenManager.AddScreen( messageBox );
			}
		}

		void messageBox_Accepted( object sender, EventArgs e ) {
			Exit();
		}


		protected override void Update( GameTime gameTime ) {
			Audio.Update();

			base.Update( gameTime );
		}

		protected override void Draw( GameTime gameTime ) {
			graphics.GraphicsDevice.Clear( Color.Black );

			base.Draw( gameTime );
		}

	}

}