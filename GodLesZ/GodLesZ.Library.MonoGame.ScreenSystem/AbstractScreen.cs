using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GodLesZ.Library.Xna.ScreenSystem {

	public abstract class AbstractScreen {
		protected bool mInitialized = false;
		protected bool mContentLoaded = false;
		protected ScreenManager mScreenManager;

		public string Name {
			get;
			protected set;
		}

		public EScreenState ScreenState {
			get;
			set;
		}

		public bool IsExiting {
			get;
			protected set;
		}

		public bool InputHandle {
			get;
			protected set;
		}

		public bool IsActive {
			get { return (ScreenState == EScreenState.Active); }
			set { ScreenState = (value ? EScreenState.Active : EScreenState.Hidden); }
		}

		public SpriteBatch SpriteBatch {
			get { return ScreenManager.SpriteBatch; }
		}

		public SpriteFont SpriteFont {
			get { return ScreenManager.Font; }
		}

		public Game Game {
			get { return ScreenManager.Game; }
		}

		public virtual ScreenManager ScreenManager {
			get { return mScreenManager; }
		}

		public KeyboardState CurrentKeyboardState {
			get;
			protected set;
		}

		public KeyboardState PrevKeyboardState {
			get;
			protected set;
		}

		public MouseState CurrentMouseState {
			get;
			protected set;
		}

		public MouseState PrevMouseState {
			get;
			protected set;
		}

		public bool WasKeyPressed(Keys key) {
			return (PrevKeyboardState.IsKeyDown(key) && CurrentKeyboardState.IsKeyUp(key));
		}

		public bool IsKeyDown(Keys key) {
			return CurrentKeyboardState.IsKeyDown(key);
		}

		public bool IsLeftMouseButtonDown {
			get { return CurrentMouseState.LeftButton == ButtonState.Pressed; }
		}

		public bool IsRightMouseButtonDown {
			get { return CurrentMouseState.RightButton == ButtonState.Pressed; }
		}

		public bool WasLeftMouseButtonDown {
			get { return PrevMouseState.LeftButton == ButtonState.Pressed && IsLeftMouseButtonDown == false; }
		}

		public bool WasRightMouseButtonDown {
			get { return PrevMouseState.RightButton == ButtonState.Pressed && IsRightMouseButtonDown == false; }
		}

		public int ScrollValue {
			get { return (CurrentMouseState.ScrollWheelValue - PrevMouseState.ScrollWheelValue); }
		}


		protected AbstractScreen(ScreenManager mgr) {
			mScreenManager = mgr;
			Name = GetType().Name;

			IsActive = true;
			CurrentKeyboardState = new KeyboardState();
			CurrentMouseState = new MouseState();
		}

		protected AbstractScreen()
			: this(ScreenManager.Instance) {
		}


		public virtual void Initialize() {
			mInitialized = true;
		}

		public virtual void LoadContent() {
			if (mInitialized == false) {
				Initialize();
			}
			mContentLoaded = true;
		}

		public virtual void UnloadContent() {
			if (mInitialized == false) {
				Initialize();
			}
			if (mContentLoaded == false) {
				LoadContent();
			}
		}

		public virtual void Update(GameTime gameTime) {
			if (mInitialized == false) {
				Initialize();
			}
			if (mContentLoaded == false) {
				LoadContent();
			}

		}

		public virtual void Draw(GameTime gameTime) {
			if (mInitialized == false) {
				Initialize();
			}
			if (mContentLoaded == false) {
				LoadContent();
			}
		}

		public virtual void HandleInput(GameTime gameTime) {
			if (mInitialized == false) {
				Initialize();
			}
			if (mContentLoaded == false) {
				LoadContent();
			}

			PrevKeyboardState = CurrentKeyboardState;
			CurrentKeyboardState = Keyboard.GetState();
			PrevMouseState = CurrentMouseState;
			CurrentMouseState = Mouse.GetState();
		}

		public void ExitScreen() {
			if (mInitialized == false) {
				Initialize();
			}
			if (mContentLoaded == false) {
				LoadContent();
			}

			IsExiting = true;
		}

	}

}
