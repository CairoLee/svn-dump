using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Cam_Test {

	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main(string[] args) {
			using (CamTest game = new CamTest()) {
				game.Run();
			}
		}
	}


	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class CamTest : Microsoft.Xna.Framework.Game {
		public static GraphicsDeviceManager graphics;
		public static ContentManager content;
		public static SpriteBatch spriteBatch;
		public static Skybox skybox;
		public static Camera camera;
		public static ConsoleInfo console;

		private Grid grid;


		public CamTest() {
			IsMouseVisible = true;
			graphics = new GraphicsDeviceManager(this);
			graphics.PreferredBackBufferWidth = 1024;
			graphics.PreferredBackBufferHeight = 768;
			graphics.IsFullScreen = true;
			content = new ContentManager(Services);
			content.RootDirectory = "Content";
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize() {
			//ContentLoader.Initialize();

			console = new ConsoleInfo();

			grid = new Grid(new Vector2(5000f, 5000f), 50, Color.Navy, 1f, Vector3.Zero, new Vector3(0f, 0f, 0f));

			skybox = new Skybox();

			camera = new MouseCam();
			camera.SetPosition(new Vector3(1500f, 400f, 1500f));
			camera.rotation = new Vector3(0f, MathHelper.ToRadians(180f), 0f);

			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent() {
			spriteBatch = new SpriteBatch(GraphicsDevice);

			//InitAnimation();
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// all content.
		/// </summary>
		protected override void UnloadContent() {
			// TODO: Unload any non ContentManager content here
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime) {

			if (Keyboard.GetState().IsKeyDown(Keys.Escape))
				this.Exit();


			if (camera != null) {
				camera.Update(gameTime);

				if (camera.state == Camera.State.Fixed && !IsMouseVisible)
					IsMouseVisible = true;
				else if (camera.state != Camera.State.Fixed && IsMouseVisible)
					IsMouseVisible = false;
			}

			if (skybox != null && camera != null)
				skybox.Update(camera.position);

			if (console != null)
				console.Update();

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime) {
			graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
			/*
			if (graphics.GraphicsDevice.RenderState.AlphaBlendEnable)
				graphics.GraphicsDevice.RenderState.AlphaBlendEnable = false;
			if (!graphics.GraphicsDevice.RenderState.DepthBufferEnable)
				graphics.GraphicsDevice.RenderState.DepthBufferEnable = true;
			if (!graphics.GraphicsDevice.RenderState.DepthBufferWriteEnable)
				graphics.GraphicsDevice.RenderState.DepthBufferWriteEnable = true;
			*/

			if (grid != null)
				grid.Draw(camera.view, camera.projection);

			if (skybox != null)
				skybox.Draw(camera.view, camera.projection);

			if (console != null)
				console.Draw();

			spriteBatch.Begin();

			spriteBatch.End();

			base.Draw(gameTime);

		}
	}
}
