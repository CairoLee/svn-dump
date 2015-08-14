using FreeWorld.Engine.Geometry;
using FreeWorld.Engine.Geometry.Camera;
using Microsoft.Xna.Framework.Graphics;

namespace FreeWorld.Game {

	public class GameCamera : EngineCamera {

		public GameCamera(GraphicsDevice graphicsDevice)
			: base(graphicsDevice) {
		}

		/*
		public void LockToTarget(AnimatedSprite sprite, int screenWidth, int screenHeight) {
			X = (int)sprite.Position.X + (sprite.CurrentAnimation.CurrentRect.Width / 2) - (screenWidth / 2);
			Y = (int)sprite.Position.Y + (sprite.CurrentAnimation.CurrentRect.Height / 2) - (screenHeight / 2);
		}
		*/
		public void ClampToArea(int width, int height) {
			if (X > width)
				X = width;
			if (Y > height)
				Y = height;

			if (X < 0)
				X = 0;
			if (Y < 0)
				Y = 0;
		}

	}

}
