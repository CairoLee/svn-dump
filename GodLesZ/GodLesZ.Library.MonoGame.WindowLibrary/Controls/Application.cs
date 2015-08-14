using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GodLesZ.Library.Xna.WindowLibrary.Controls;
using System;

#if (!XBOX && !XBOX_FAKE)
using System.Windows.Forms;
#endif

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	/// <summary>
	/// Extends the Game class by an styleable window layout
	/// </summary>
	public class Application : Game {

		private GraphicsDeviceManager mGraphicsManager;
		private Manager mManager;
		private SpriteBatch mSpriteBatch;
		private bool mClearBackground = false;
		private Color mBackgroundColor = Color.Black;
		private Texture2D mBackgroundImage;
		private Window mMainWindow;
		private bool mAppWindow = false;
		private Point mMousePos = Point.Zero;
		private bool mSystemBorder = true;
		private bool mFullScreenBorder = true;
		private bool mExitConfirmation = true;
		private bool mExit = false;
		private ExitDialog mExitDialog = null;
#if (!XBOX && !XBOX_FAKE)
		private bool mMouseDown = false;
#endif

		public virtual GraphicsDeviceManager Graphics {
			get { return mGraphicsManager; }
			set { mGraphicsManager = value; }
		}

		public virtual Manager Manager {
			get { return mManager; }
			set { mManager = value; }
		}

		public virtual bool ClearBackground {
			get { return mClearBackground; }
			set { mClearBackground = value; }
		}

		public virtual Color BackgroundColor {
			get { return mBackgroundColor; }
			set { mBackgroundColor = value; }
		}

		public virtual Texture2D BackgroundImage {
			get { return mBackgroundImage; }
			set { mBackgroundImage = value; }
		}

		public virtual Window MainWindow {
			get { return mMainWindow; }
		}

		public virtual bool SystemBorder {
			get { return mSystemBorder; }
			set { mSystemBorder = value; }
		}

		public virtual bool FullScreenBorder {
			get { return mFullScreenBorder; }
			set { mFullScreenBorder = value; }
		}

		public virtual bool ExitConfirmation {
			get { return mExitConfirmation; }
			set { mExitConfirmation = value; }
		}


		public Application()
			: this("Default", false) {
		}

		public Application(string skin)
			: this(skin, false) {
		}

		public Application(bool appWindow)
			: this("Default", appWindow) {
		}

		public Application(string skin, bool appWindow) {
			this.mAppWindow = appWindow;

			mGraphicsManager = new GraphicsDeviceManager(this);
			mGraphicsManager.PreferredBackBufferWidth = 1024;
			mGraphicsManager.PreferredBackBufferHeight = 768;
			mGraphicsManager.PreferredBackBufferFormat = SurfaceFormat.Color;
			mGraphicsManager.IsFullScreen = false;
			mGraphicsManager.PreferMultiSampling = false;
			mGraphicsManager.SynchronizeWithVerticalRetrace = false;
			mGraphicsManager.DeviceReset += new EventHandler<System.EventArgs>(Graphics_DeviceReset);

			IsFixedTimeStep = false;
			IsMouseVisible = true;

			mManager = new Manager(this, mGraphicsManager, skin);
			mManager.AutoCreateRenderTarget = false;
			mManager.TargetFrames = 60;
			mManager.WindowClosing += new WindowClosingEventHandler(Manager_WindowClosing);
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
				if (mManager != null)
					mManager.Dispose();
				if (mSpriteBatch != null)
					mSpriteBatch.Dispose();
			}
			base.Dispose(disposing);
		}

		protected override void Initialize() {
			base.Initialize();

			mManager.Initialize();

			Manager.RenderTarget = CreateRenderTarget();
			Manager.Input.InputOffset = new InputOffset(0, 0, Manager.ScreenWidth / (float)Manager.TargetWidth, Manager.ScreenHeight / (float)Manager.TargetHeight);

			mSpriteBatch = new SpriteBatch(GraphicsDevice);

#if (!XBOX && !XBOX_FAKE)
			Manager.Window.BackColor = System.Drawing.Color.Black;
			Manager.Window.FormBorderStyle = mSystemBorder ? System.Windows.Forms.FormBorderStyle.FixedDialog : System.Windows.Forms.FormBorderStyle.None;

			Manager.Input.MouseMove += new MouseEventHandler(Input_MouseMove);
			Manager.Input.MouseDown += new MouseEventHandler(Input_MouseDown);
			Manager.Input.MouseUp += new MouseEventHandler(Input_MouseUp);
#endif

			if (mAppWindow) {
				mMainWindow = CreateMainWindow();
			}

			InitMainWindow();
		}

		protected override void Update(GameTime gameTime) {
			base.Update(gameTime);
			mManager.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime) {
			mManager.BeginDraw(gameTime);

			if (mClearBackground)
				GraphicsDevice.Clear(mBackgroundColor);
			if (mBackgroundImage != null && mMainWindow == null) {
				int sx = mManager.TargetWidth;
				int sy = mManager.TargetHeight;
				mSpriteBatch.Begin();
				mSpriteBatch.Draw(mBackgroundImage, new Rectangle(0, 0, sx, sy), Color.White);
				mSpriteBatch.End();
			}

			base.Draw(gameTime);
			DrawScene(gameTime);

			mManager.EndDraw(new Rectangle(0, 0, Manager.ScreenWidth, Manager.ScreenHeight));
		}

		protected virtual Window CreateMainWindow() {
			return new Window(mManager);
		}

		protected virtual void InitMainWindow() {
			if (mMainWindow != null) {
				if (!mMainWindow.Initialized)
					mMainWindow.Init();

				mMainWindow.Alpha = 255;
				mMainWindow.Width = mManager.TargetWidth;
				mMainWindow.Height = mManager.TargetHeight;
				mMainWindow.Shadow = false;
				mMainWindow.Left = 0;
				mMainWindow.Top = 0;
				mMainWindow.CloseButtonVisible = true;
				mMainWindow.Resizable = false;
				mMainWindow.Movable = false;
				mMainWindow.Text = this.Window.Title;
				mMainWindow.Closing += new WindowClosingEventHandler(MainWindow_Closing);
				mMainWindow.ClientArea.Draw += new DrawEventHandler(MainWindow_Draw);
				mMainWindow.BorderVisible = mMainWindow.CaptionVisible = (!mSystemBorder && !Graphics.IsFullScreen) || (Graphics.IsFullScreen && mFullScreenBorder);
				mMainWindow.StayOnBack = true;

				mManager.Add(mMainWindow);

				mMainWindow.SendToBack();
			}
		}

		private void MainWindow_Draw(object sender, DrawEventArgs e) {
			if (mBackgroundImage != null && mMainWindow != null) {
				e.Renderer.Draw(mBackgroundImage, e.Rectangle, Color.White);
			}
		}

		public new virtual void Exit() {
			mExit = true;
			base.Exit();
		}

		private void Manager_WindowClosing(object sender, WindowClosingEventArgs e) {
			e.Cancel = !mExit && mExitConfirmation;

			if (!mExit && mExitConfirmation && mExitDialog == null) {
				mExitDialog = new ExitDialog(Manager);
				mExitDialog.Init();
				mExitDialog.Closed += new WindowClosedEventHandler(closeDialog_Closed);
				mExitDialog.ShowModal();
				Manager.Add(mExitDialog);
			} else if (!mExitConfirmation) {
				Exit();
			}
		}

		private void closeDialog_Closed(object sender, WindowClosedEventArgs e) {
			if ((sender as Dialog).ModalResult == EModalResult.Yes) {
				Exit();
			} else {
				mExit = false;
				mExitDialog.Closed -= closeDialog_Closed;
				mExitDialog.Dispose();
				mExitDialog = null;
				if (mMainWindow != null)
					mMainWindow.Focused = true;
			}
		}

		private void MainWindow_Closing(object sender, WindowClosingEventArgs e) {
			e.Cancel = true;
			Manager_WindowClosing(sender, e);
		}

		private void Graphics_DeviceReset(object sender, System.EventArgs e) {
			if (Manager.RenderTarget != null) {
				Manager.RenderTarget.Dispose();
				Manager.RenderTarget = CreateRenderTarget();
				Manager.Input.InputOffset = new InputOffset(0, 0, Manager.ScreenWidth / (float)Manager.TargetWidth, Manager.ScreenHeight / (float)Manager.TargetHeight);
			}

			if (mMainWindow != null) {
				mMainWindow.Height = Manager.TargetHeight;
				mMainWindow.Width = Manager.TargetWidth;
				mMainWindow.BorderVisible = mMainWindow.CaptionVisible = (!mSystemBorder && !Graphics.IsFullScreen) || (Graphics.IsFullScreen && mFullScreenBorder);
			}
		}

		protected virtual RenderTarget2D CreateRenderTarget() {
			return mManager.CreateRenderTarget();
		}

		protected virtual void DrawScene(GameTime gameTime) {
		}

		public new void Run() {
			base.Run();
		}

#if (!XBOX && !XBOX_FAKE)

		private void Input_MouseMove(object sender, MouseEventArgs e) {
			if (mMouseDown) {
				Manager.Window.Left = e.Position.X + Manager.Window.Left - mMousePos.X;
				Manager.Window.Top = e.Position.Y + Manager.Window.Top - mMousePos.Y;
			}
		}

		private void Input_MouseDown(object sender, MouseEventArgs e) {
			if (e.Button == EMouseButton.Left && !Graphics.IsFullScreen && !mSystemBorder) {
				if (CheckPos(e.Position)) {
					mMouseDown = true;
					mMousePos = e.Position;
				}
			}
		}

		private void Input_MouseUp(object sender, MouseEventArgs e) {
			mMouseDown = false;
		}

		private bool CheckPos(Point pos) {
			if (pos.X >= 24 && pos.X <= Manager.TargetWidth - 48 &&
				pos.Y >= 0 && pos.Y <= Manager.Skin.Controls["Window"].Layers["Caption"].Height) {
				foreach (Control c in Manager.Controls) {
					if (c.Visible && c != MainWindow &&
						pos.X >= c.AbsoluteRect.Left && pos.X <= c.AbsoluteRect.Right &&
						pos.Y >= c.AbsoluteRect.Top && pos.Y <= c.AbsoluteRect.Bottom) {
						return false;
					}
				}
				return true;
			} else
				return false;
		}

#endif

	}
}
