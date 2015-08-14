using GodLesZ.Library.Xna.Awesomium;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GodLesZ.Library.Xna.ScreenSystem {

	public abstract class AwesomiumAbstractScreen : AbstractScreen {

		public AwesomiumGameComponent Awesomium {
			get;
			protected set;
		}


		protected AwesomiumAbstractScreen()
			: base(ScreenManager.Instance) {
		}


		public override void Initialize() {
			base.Initialize();

			Awesomium = new AwesomiumGameComponent(Game);
			Awesomium.Initialize();
			Game.Components.Add(Awesomium);
		}

		public override void UnloadContent() {
			base.UnloadContent();

			Game.Components.Remove(Awesomium);
			Awesomium.Dispose();
		}

		public override void Draw(GameTime gameTime) {
			base.Draw(gameTime);

			if (Awesomium.Awesomium.WebTexture != null) {
				var tex = Awesomium.Awesomium.WebTexture;
				var rectSrc = new Rectangle(0, 0, tex.Width, tex.Height);
				var rectDest = Game.GraphicsDevice.Viewport.Bounds;
				SpriteBatch.Draw(tex, rectDest, rectSrc, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
			}
		}


		public virtual bool LoadInterface(string url) {
			return Awesomium.Awesomium.LoadFromUrl(url);
		}

	}

}