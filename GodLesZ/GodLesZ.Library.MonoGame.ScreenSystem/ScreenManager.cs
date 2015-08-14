using System;
using System.Collections.Generic;
using System.Linq;
using GodLesZ.Library.Xna.Geometry;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GodLesZ.Library.Xna.ScreenSystem {

	public class ScreenManager : DrawableGameComponent {

		protected static ScreenManager mInstance;

		/// <exception cref="Exception">No screen manager instance created</exception>
		public static ScreenManager Instance {
			get {
				if (mInstance == null) {
					throw new Exception("No screen manager instance created");
				}
				return mInstance;
			}
			protected set { mInstance = value; }
		}

		protected Dictionary<string, AbstractScreen> mScreens = new Dictionary<string, AbstractScreen>();
		protected List<AbstractScreen> mScreensToAdd = new List<AbstractScreen>();
		protected List<AbstractScreen> mScreensToRemove = new List<AbstractScreen>();

		protected bool mIsInitialized;
		protected bool mContentLoaded;

		public ICamera Camera {
			get;
			protected set;
		}

		public SpriteBatch SpriteBatch {
			get;
			protected set;
		}

		public SpriteFont Font {
			get;
			protected set;
		}

		public Dictionary<string, AbstractScreen>.ValueCollection Screens {
			get { return mScreens.Values; }
		}

		public AbstractScreen this[string name] {
			get {
				return mScreens.ContainsKey(name) == false ? null : mScreens[name];
			}
		}


		/// <exception cref="Exception">Singleton class; use ScreenManager.Instance instead</exception>
		public ScreenManager(Game game)
			: base(game) {
			if (mInstance != null) {
				throw new Exception("Singleton class; use ScreenManager.Instance instead");
			}
			mInstance = this;

			mIsInitialized = false;
			mContentLoaded = false;
		}

		public override void Initialize() {
			lock (mScreens) {
				foreach (var screen in mScreens.Values) {
					screen.Initialize();
				}
			}

			base.Initialize();
			mIsInitialized = true;
		}


		protected override void LoadContent() {
			SpriteBatch = new SpriteBatch(GraphicsDevice);


			lock (mScreens) {
				foreach (AbstractScreen screen in mScreens.Values) {
					screen.LoadContent();
				}
			}

			base.LoadContent();
			mContentLoaded = true;
		}


		protected override void UnloadContent() {
			if (mIsInitialized == false) {
				Initialize();
			}
			if (mContentLoaded == false) {
				LoadContent();
			}

			lock (mScreens) {
				foreach (var screen in mScreens.Values) {
					screen.UnloadContent();
				}
			}
		}


		public override void Update(GameTime gameTime) {
			if (mIsInitialized == false) {
				Initialize();
			}
			if (mContentLoaded == false) {
				LoadContent();
			}

			var inputHandled = false;

			lock (mScreens) {
				foreach (var screen in mScreensToAdd) {
					mScreens.Add(screen.Name, screen);
				}
				foreach (var screen in mScreensToRemove) {
					Remove(screen);
				}

				mScreensToAdd.Clear();
				mScreensToRemove.Clear();

				foreach (var screen in mScreens.Values) {
					if (screen.IsExiting) {
						mScreensToRemove.Add(screen);
						continue;
					}

					// Update every screen
					screen.Update(gameTime);
					// Only handle input once and only for active screens
					if (screen.ScreenState != EScreenState.Active || screen.InputHandle != true || inputHandled) {
						continue;
					}

					screen.HandleInput(gameTime);
					inputHandled = true;
				}

				foreach (var screen in mScreensToRemove) {
					Remove(screen);
				}
				mScreensToRemove.Clear();
			}

		}


		/// <summary>
		/// tell each Screen to Draw itself
		/// </summary>
		/// <param name="gameTime"></param>
		public override void Draw(GameTime gameTime) {
			if (mIsInitialized == false) {
				Initialize();
			}
			if (mContentLoaded == false) {
				LoadContent();
			}

			lock (mScreens) {
				foreach (var screen in mScreens.Values.Where(screen => screen.ScreenState != EScreenState.Hidden)) {
					Draw(screen, gameTime);
				}
			}
		}

		/// <summary>
		/// Draws a single screen for the given gameTime
		/// </summary>
		/// <param name="screen"></param>
		/// <param name="gameTime"></param>
		public virtual void Draw(AbstractScreen screen, GameTime gameTime) {
			SpriteBatch.Begin();
			screen.Draw(gameTime);
			SpriteBatch.End();
		}


		/// <summary>
		/// Adds a new Screen to the List
		/// </summary>
		/// <param name="screen"></param>
		/// <param name="closeScreen"></param>
		/// <exception cref="Exception">Screen missing name</exception>
		public virtual AbstractScreen Add(AbstractScreen screen, AbstractScreen closeScreen = null) {
			if (closeScreen != null) {
				closeScreen.ExitScreen();
			}

			// @TODO: Why should the screen state default to hidden?
			//screen.ScreenState = EScreenState.Hidden;
			if (string.IsNullOrEmpty(screen.Name)) {
				throw new Exception("Screen missing name");
			}

			if (mIsInitialized) {
				screen.Initialize();
			}
			if (mContentLoaded) {
				screen.LoadContent();
			}

			lock (mScreens) {
				mScreensToAdd.Add(screen);
			}

			return screen;
		}

		/// <summary>
		/// Removes a Screen from the List
		/// </summary>
		/// <param name="screen"></param>
		public virtual void Remove(AbstractScreen screen) {
			if (mContentLoaded) {
				screen.UnloadContent();
			}

			lock (mScreens) {
				mScreens.Remove(screen.Name);
			}
		}


		public virtual AbstractScreen[] AsArray() {
			var screens = new AbstractScreen[Screens.Count];
			Screens.CopyTo(screens, 0);
			return screens;
		}

	}

}
