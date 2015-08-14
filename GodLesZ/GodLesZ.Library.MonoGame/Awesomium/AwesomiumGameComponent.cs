using System;
using System.IO;
using System.Reflection;
using Microsoft.Xna.Framework;

namespace GodLesZ.Library.MonoGame.Awesomium {

	public class AwesomiumGameComponent : DrawableGameComponent {
		protected string mBaseDir;
		protected AwesomiumComponent mAwesomium;
		protected log4net.ILog mLogger = null;

		public AwesomiumComponent Awesomium {
			get { return mAwesomium; }
		}


		public AwesomiumGameComponent(Game game)
			: this(game, null, null) {
		}

		public AwesomiumGameComponent(Game game, string baseDir)
			: this(game, baseDir, null) {
		}

		public AwesomiumGameComponent(Game game, string baseDir, log4net.ILog logger)
			: base(game) {
			mBaseDir = baseDir;
			mLogger = logger;
			mAwesomium = new AwesomiumComponent(logger);
		}


		public override void Initialize() {
			var gameBounds = Game.GraphicsDevice.PresentationParameters.Bounds;
			if (string.IsNullOrEmpty(mBaseDir) || Directory.Exists(mBaseDir) == false) {
				mBaseDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
			}

			System.Diagnostics.Debug.WriteLine("Current bounds: {0}", gameBounds);
			mAwesomium.Initialize(Game.GraphicsDevice, gameBounds.Width, gameBounds.Height, mBaseDir);

			InputSystem.Initialize(Game.Window);
			InputSystem.CharEntered += OnAwesomiumCharEnteredHandler;
			InputSystem.KeyUp += OnAwesomiumKeyUpHandler;
			InputSystem.FullKeyHandler += OnAwesomiumFullKeyHandler;
			InputSystem.MouseMove += OnAwesomiumMouseMoveHandler;
			InputSystem.MouseDown += OnAwesomiumMouseDownHandler;
			InputSystem.MouseUp += OnAwesomiumMouseUpHandler;

			// We have to update our render surface to the new bounds
			Game.Window.ClientSizeChanged += delegate(object sender, EventArgs args) {
				gameBounds = Game.GraphicsDevice.PresentationParameters.Bounds;
				// EDIT: Failed.. try to recreate it

				mAwesomium = new AwesomiumComponent(mLogger);
				mAwesomium.Initialize(Game.GraphicsDevice, gameBounds.Width, gameBounds.Height, mBaseDir);
				
				System.Diagnostics.Debug.WriteLine("New bounds: {0}", gameBounds);
			};

			base.Initialize();
		}

		protected override void UnloadContent() {
			mAwesomium.Shutdown();

			base.UnloadContent();
		}

		public override void Update(GameTime gameTime) {
			mAwesomium.Update();

			base.Update(gameTime);
		}

		public override void Draw(GameTime gameTime) {
			if (mAwesomium.NeedsToBeDrawn()) {
				mAwesomium.RenderWebView();
			}

			base.Draw(gameTime);
		}


		protected virtual void OnAwesomiumCharEnteredHandler(object sender, CharacterEventArgs e) {

		}
		
		protected virtual void OnAwesomiumMouseMoveHandler(object sender, MouseEventArgs e) {
			mAwesomium.InjectMouseMove(e.Location.X, e.Location.Y);
		}

		protected virtual void OnAwesomiumMouseDownHandler(object sender, MouseEventArgs e) {
			mAwesomium.InjectMouseDown(e.Button);
		}

		protected virtual void OnAwesomiumMouseUpHandler(object sender, MouseEventArgs e) {
			mAwesomium.InjectMouseUp(e.Button);
		}

		protected virtual void OnAwesomiumFullKeyHandler(object sender, uint msg, IntPtr wParam, IntPtr lParam) {
			mAwesomium.InjectKeyboardEvent((int)msg, (int)wParam, (int)lParam);
		}

		protected virtual void OnAwesomiumKeyUpHandler(object sender, KeyEventArgs e) {
			
		}

	}

}
