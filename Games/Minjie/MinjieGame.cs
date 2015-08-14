using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace Minjie {

	public class MinjieGame : Microsoft.Xna.Framework.Game {
		GraphicsDeviceManager graphics;
		ScreenManager screenManager;


		/// <summary>
		/// Construct a new MinjieGame object.
		/// </summary>
		public MinjieGame() {
			graphics = new GraphicsDeviceManager( this );

			Content.RootDirectory = "Content";

			// start the audio manager
			AudioManager.Initialize( this, @"Content\Minjie.xgs", @"Content\Minjie.xwb", @"Content\Minjie.xsb" );

			// initialize the screen manager
			screenManager = new ScreenManager( this );
			Components.Add( screenManager );
		}


		protected override void Initialize() {
			graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
			graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
#if !DEBUG
			graphics.IsFullScreen = true;
#endif
			graphics.ApplyChanges();

			screenManager.AddScreen( new TitleScreen() );

			base.Initialize();
		}



		static void Main() {
			using( MinjieGame game = new MinjieGame() ) {
				game.Run();
			}
		}

	}

}
