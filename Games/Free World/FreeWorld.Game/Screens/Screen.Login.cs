using System;
using Microsoft.Xna.Framework;

namespace FreeWorld.Game.Screens {

	public class ScreenLogin : GameScreen {
		
		public ScreenLogin() {
			Name = "ScreenLogin";
			InputHandle = true;
		}


		/// <exception cref="Exception">Failed to load interface</exception>
		public override void LoadContent() {
			base.LoadContent();
			
			if (LoadInterface("login.html") == false) {
				throw new Exception("Failed to load interface");
			}

		}


		public override void Update(GameTime gameTime) {
			base.Update(gameTime);

			// Update objects
		}

		public override void HandleInput(GameTime gameTime) {
			base.HandleInput(gameTime);
			
			// Handle me
		}

		public override void Draw(GameTime gameTime) {
			// Draw something

			base.Draw(gameTime);
		}
		
	}

}
