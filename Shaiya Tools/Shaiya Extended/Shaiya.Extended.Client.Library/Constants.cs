using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Shaiya.Extended.Client.Library {

	public static class Constants {
		public static GraphicsDeviceManager Graphics;
		public static GraphicsDevice GraphicsDevice {
			get { return Graphics.GraphicsDevice; }
		}
		public static ContentManager Content;

		public static SpriteBatch SpriteBatch;
		public static InputHelper InputHelper;

	}

}
