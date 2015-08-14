using Microsoft.Xna.Framework;
using WindowLibrary.Controls;
using InsaneRO.Cards.Client.Compontents;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace InsaneRO.Cards.Client.Screens {

	public abstract class GameScreen {
		private List<Control> mWindows = new List<Control>();
		protected string mName = "Screen";
		protected ScreenManager mScreenManager;
		protected EScreenState mScreenState = EScreenState.Hidden;
		protected bool mIsExiting = false;
		protected bool mHandleInput = false;
		protected bool mInitialized = false;
		protected GameClient mGameInstance;

		public string Name {
			get { return mName; }
			set { mName = value; }
		}

		public EScreenState ScreenState {
			get { return mScreenState; }
			set { mScreenState = value; }
		}

		public bool IsExiting {
			get { return mIsExiting; }
			set { mIsExiting = value; }
		}

		public bool InputHandle {
			get { return mHandleInput; }
			set { mHandleInput = value; }
		}

		public bool IsActive {
			get { return (mScreenState == EScreenState.Active); }
			set { mScreenState = (value == true ? EScreenState.Active : EScreenState.Hidden); }
		}

		public ScreenManager ScreenManager {
			get { return mScreenManager; }
			set { mScreenManager = value; }
		}

		public SpriteBatch SpriteBatch {
			get { return mScreenManager.SpriteBatch; }
		}

		public SpriteFont SpriteFont {
			get { return mScreenManager.Font; }
		}

		public Manager WindowManager {
			get { return mScreenManager.WindowManager; }
		}

		public GameClient Game {
			get { return mGameInstance; }
			set { mGameInstance = value; }
		}

		public List<Control> Windows {
			get { return mWindows; }
		}


		public GameScreen(GameClient game) {
		}


		public virtual void Initialize() {
			mInitialized = true;
		}

		public virtual void LoadContent() {
			if (mInitialized == false)
				Initialize();
		}

		public virtual void UnloadContent() {
			if (mInitialized == false)
				Initialize();
			for (int i = 0; i < mWindows.Count; i++)
				ScreenManager.MainWindow.Remove(mWindows[i]);
		}

		public virtual void Update(GameTime gameTime) {
			if (mInitialized == false)
				Initialize();

			mScreenState = EScreenState.Active;
		}

		public virtual void Draw(GameTime gameTime) {
			if (mInitialized == false)
				Initialize();
		}

		public virtual void HandleInput(InputHelper Input, GameTime gameTime) {
			if (mInitialized == false)
				Initialize();
		}

		public void ExitScreen() {
			if (mInitialized == false)
				Initialize();
			mIsExiting = true;
		}

		public void AddWindow(Control wnd) {
			mWindows.Add(wnd);
			ScreenManager.MainWindow.Add(wnd, true);
		}

	}

}
