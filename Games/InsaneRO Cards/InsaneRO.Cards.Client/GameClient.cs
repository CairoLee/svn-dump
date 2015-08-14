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
using InsaneRO.Cards.Client.Screens;
using InsaneRO.Cards.Library;
using InsaneRO.Cards.Client.Components;
using InsaneRO.Cards.Client.Classes;

namespace InsaneRO.Cards.Client {

	public class GameClient : Microsoft.Xna.Framework.Game {
		private static GameClient mInstance;
		private static System.Windows.Forms.Form mFormHandle = null;

		public static GraphicsDeviceManager GraphicsManager;
		public static ScreenManager ScreenManager;
		public static FPS DebugFPS;

		private GodLesZ.Library.MySql.MySqlWrapper mMySql;
		private GamePlayer mPlayer;

		public System.Windows.Forms.Form FormHandle {
			get {
				if (mFormHandle == null)
					mFormHandle = (System.Windows.Forms.Form)System.Windows.Forms.Form.FromHandle(mInstance.Window.Handle);
				return mFormHandle;
			}
		}

		public GodLesZ.Library.MySql.MySqlWrapper MySql {
			get { return mMySql; }
		}

		public GamePlayer Player {
			get { return mPlayer; }
			set { mPlayer = value; }
		}


		public GameClient() {
			mInstance = this;

			FormHandle.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

			GraphicsManager = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";

			IsFixedTimeStep = false;
			IsMouseVisible = true;
		}


		private void SetupGraphicdevice() {
			GraphicsManager.PreferMultiSampling = false;
			GraphicsManager.SynchronizeWithVerticalRetrace = false;
			GraphicsManager.GraphicsDevice.PresentationParameters.BackBufferWidth = 1024;
			GraphicsManager.GraphicsDevice.PresentationParameters.BackBufferHeight = 786;
			GraphicsManager.PreferredBackBufferWidth = 1024;
			GraphicsManager.PreferredBackBufferHeight = 786;
			GraphicsManager.ApplyChanges();

#if !DEBUG
			GraphicsManager.IsFullScreen = true;
#endif
		}


		protected override void Initialize() {
			SetupGraphicdevice();

			DebugFPS = new FPS(this);
			ScreenManager = new ScreenManager(this, true);
			Components.Add(ScreenManager);
			Components.Add(DebugFPS);

			base.Initialize();

			// set again after WindowManager initialized, prevent flicker
			SetupGraphicdevice();

			ScreenManager.AddScreen(new ScreenBackground(this));
			ScreenManager.AddScreen(new ScreenLogin(this));

			mMySql = new GodLesZ.Library.MySql.MySqlWrapper("localhost", 3306, "root", "", "ragnarok_cards");
			if (mMySql.Prepare() != GodLesZ.Library.MySql.EMysqlConnectionError.None) {
				System.Windows.Forms.MessageBox.Show("Es ist ein Fehler beim verbinden zur Datenbank aufgetreten!\nBitte geh ins InsaneRO Forum und frag GodLesZ, falls dieses Problem weiterhin besteht.\n\nFehlermeldung:\n" + MySql.LastError.ToString(), "Datenbank Fehler", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
				this.Exit();
			}
		}

		protected override void LoadContent() {
			// load ragnarok animations
			RagnarokAnimationHandler.Load(Content.RootDirectory, 1002);

			// fill up Cardlist
			Card.CardList.Add(new Card());

			base.LoadContent();
		}

		protected override void UnloadContent() {
			ScreenManager.Dispose();
			Content.Unload();
		}

		protected override void Update(GameTime gameTime) {
			//if( ScreenManager.Input.WasKeyPressed( Keys.Escape ) )
			//	this.Exit();

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime) {
			base.Draw(gameTime);
		}

	}

}
