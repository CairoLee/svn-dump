using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace GLibary {
	public static class GameTimeExtnesions {
		public static float ElapsedSeconds( this GameTime gameTime ) {
			return (float)gameTime.ElapsedGameTime.TotalSeconds;
		}

		public static float TotalSeconds( this GameTime gameTime ) {
			return (float)gameTime.TotalGameTime.TotalSeconds;
		}
	}
}
