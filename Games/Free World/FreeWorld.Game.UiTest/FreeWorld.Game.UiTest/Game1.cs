using System;
using GodLesZ.Library.Xna.Awesomium;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Awesomium.Core;

namespace FreeWorld.Game.UiTest {

	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game1 : Microsoft.Xna.Framework.Game {
		protected GraphicsDeviceManager mGraphics;
		protected SpriteBatch mSpriteBatch;

		protected int mScreenSizeWidth = 800;
		protected int mScreenSizeHeight = 600;

		protected AwesomiumGameComponent mUi;

		protected Texture2D mTestTexture;
		protected Rectangle mTexturePosition = new Rectangle(0, 0, 150, 150);

		protected string mGuiTestLayoutPath = "Gui/index.html";


		public Game1() {
			Window.Title = "Awesomium UI Test";

			Content.RootDirectory = "Content";

			mGraphics = new GraphicsDeviceManager(this) {
				PreferredBackBufferWidth = mScreenSizeWidth,
				PreferredBackBufferHeight = mScreenSizeHeight
			};
			mGraphics.ApplyChanges();

			IsMouseVisible = true;
		}


		protected override void Initialize() {
			mSpriteBatch = new SpriteBatch(GraphicsDevice);

			mUi = new AwesomiumGameComponent(this);
			Components.Add(mUi);

			mUi.Awesomium.OnLoadCompleted += delegate {
				Window.Title = "Awesomium UI Test [OnLoadCompleted]";
			};
			mUi.Awesomium.OnDocumentCompleted += delegate {
				Window.Title = "Awesomium UI Test [OnDocumentCompleted]";

				mUi.Awesomium.CreateJsObject("MyObject", "SelectItem", OnSelectItem);
				mUi.Awesomium.CreateJsObject("AnotherObject", "ChatTextEntered", OnChatTextEntered);
				mUi.Awesomium.CreateJsObject("AnotherObject", "ThisClicked", OnThisClicked);
			};

			base.Initialize();
		}

		protected override void LoadContent() {
			// Create a new SpriteBatch, which can be used to draw textures.
			mSpriteBatch = new SpriteBatch(GraphicsDevice);

			Window.Title = "Awesomium UI Test: Loading...";

			if (!mUi.Awesomium.LoadFromUrl(mGuiTestLayoutPath)) {
				// Failed to load UI.htm
			}

			mTestTexture = Content.Load<Texture2D>("texture");
		}





		protected override void Update(GameTime gameTime) {
			var keyState = Keyboard.GetState();
			var mouseState = Mouse.GetState();

			if (keyState.IsKeyDown(Keys.Escape)) {
				Exit();
				return;
			}

			// UI refresh test
			if (keyState.IsKeyDown(Keys.F5)) {
				mUi.Awesomium.LoadFromUrl(mGuiTestLayoutPath);
			}

			// Test texture movement
			if (keyState.IsKeyDown(Keys.Left)) {
				mTexturePosition.X--;
			}
			if (keyState.IsKeyDown(Keys.Right)) {
				mTexturePosition.X++;
			}
			if (keyState.IsKeyDown(Keys.Up)) {
				mTexturePosition.Y--;
			}
			if (keyState.IsKeyDown(Keys.Down)) {
				mTexturePosition.Y++;
			}

			// Bounds collision just to be save
			if (mTexturePosition.X < 0) {
				mTexturePosition.X = 0;
			}
			if (mTexturePosition.X > mScreenSizeWidth) {
				mTexturePosition.X = mScreenSizeWidth;
			}
			if (mTexturePosition.Y < 0) {
				mTexturePosition.Y = 0;
			}
			if (mTexturePosition.Y > mScreenSizeHeight) {
				mTexturePosition.Y = mScreenSizeHeight;
			}

			var mousePos = new Point(mouseState.X, mouseState.Y);
			if (mTexturePosition.Contains(mousePos) && mouseState.LeftButton == ButtonState.Pressed) {
				mUi.Awesomium.CallJavascript(@"
					$('#dialog')
						.html('Clicked on test texture at: " + mouseState.X + ", " + mouseState.Y + "')" +
						".dialog();" +
				"");
				mUi.Awesomium.CallJavascriptFunction("ShowDialog", "dialog");
			}

			base.Update(gameTime);
		}


		protected override void Draw(GameTime gameTime) {
			GraphicsDevice.Clear(Color.Black);

			GraphicsDevice.BlendState = BlendState.AlphaBlend;

			mSpriteBatch.Begin();
			mSpriteBatch.Draw(mTestTexture, new Rectangle(mTexturePosition.X, mTexturePosition.Y, 100, 100), Color.White);

			if (mUi.Awesomium.WebTexture != null) {
				mSpriteBatch.Draw(mUi.Awesomium.WebTexture, new Rectangle(0, 0, mScreenSizeWidth, mScreenSizeHeight), Color.White);
			}
			mSpriteBatch.End();

			GraphicsDevice.BlendState = BlendState.Opaque;

			base.Draw(gameTime);
		}







		public void AddToChat(string message) {
			//JSValue[] args = new JSValue[1];
			//args[0] = new JSValue(message);

			mUi.Awesomium.CallJavascriptFunction("addTextMessage", message);
		}

		public void OnSelectItem(object sender, JavascriptMethodEventArgs e) {
			Console.WriteLine("Player selected item:" + e.Arguments[0].ToString());
			AddToChat(e.Arguments[0].ToString());
		}

		public void OnChatTextEntered(object sender, JavascriptMethodEventArgs e) {
			Console.WriteLine("Player selected item:" + e.Arguments[0].ToString());
			AddToChat(e.Arguments[0].ToString());
		}

		public void OnThisClicked(object sender, JavascriptMethodEventArgs e) {
			Console.WriteLine(e.Arguments[0].ToString());
			AddToChat(e.Arguments[0].ToString());

			var argument = e.Arguments[0].ToString();
			switch (argument) {
				case "Inventory":
					mUi.Awesomium.CallJavascriptFunction("ShowDialog", "dlgInventory");
					break;
				case "Stats":
					mUi.Awesomium.CallJavascriptFunction("ShowDialog", "dlgStats");
					break;
				case "Options":
					mUi.Awesomium.CallJavascriptFunction("ShowDialog", "dlgOptions");
					break;
			}

		}

	}
}
