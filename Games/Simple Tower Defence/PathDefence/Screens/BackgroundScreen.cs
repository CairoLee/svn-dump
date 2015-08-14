using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PathDefence.ScreenManagement;

namespace PathDefence.Screens {
	/// <summary>
	///     The background screen sits behind all the other menu screens. It draws a
	///     background image that remains fixed in place regardless of whatever
	///     transitions the screens on top of it may be doing.
	/// </summary>
	internal class BackgroundScreen : GameScreen {
		private Texture2D backgroundTexture;
		private ContentManager content;

		/// <summary>
		///     Constructor.
		/// </summary>
		public BackgroundScreen() {
			TransitionOnTime = TimeSpan.FromSeconds(0.5);
			TransitionOffTime = TimeSpan.FromSeconds(0.5);
		}

		/// <summary>
		///     Loads graphics <see cref="content" /> for this screen. The background
		///     texture is quite big, so we use our own local
		///     <see cref="ContentManager" /> to load it. This allows us to unload
		///     before going from the menus into the game itself, wheras if we used
		///     the shared <see cref="ContentManager" /> provided by the
		///     <see cref="Game" /> class, the <see cref="content" /> would remain
		///     loaded forever.
		/// </summary>
		public override void LoadContent() {
			if (content == null) {
				content = new ContentManager(ScreenManager.Game.Services, "Content");
			}

			backgroundTexture = content.Load<Texture2D>("GUI/background");
		}

		/// <summary>
		///     Unloads graphics <see cref="content" /> for this screen.
		/// </summary>
		public override void UnloadContent() {
			content.Unload();
		}

		/// <summary>
		///     Updates the background screen. Unlike most screens, this should not
		///     transition off even if it has been covered by another screen: it is
		///     supposed to be covered, after all! This overload forces the
		///     <paramref name="coveredByOtherScreen" /> parameter to
		///     <see langword="false" /> in order to stop the base
		///     <see cref="Update" /> method wanting to transition off.
		/// </summary>
		public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen) {
			base.Update(gameTime, otherScreenHasFocus, false);
		}

		/// <summary>
		///     Draws the background screen.
		/// </summary>
		public override void Draw(GameTime gameTime) {
			var spriteBatch = ScreenManager.SpriteBatch;
			var viewport = ScreenManager.GraphicsDevice.Viewport;
			var fullscreen = new Rectangle(0, 0, viewport.Width, viewport.Height);
			var fade = TransitionAlpha;

			spriteBatch.Begin();

			spriteBatch.Draw(backgroundTexture, fullscreen, new Color(fade, fade, fade));

			spriteBatch.End();
		}
	}
}