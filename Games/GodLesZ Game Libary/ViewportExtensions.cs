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
	public static class ViewportExtnesions {

		public static Vector4 BoundsV4( this Viewport vp ) {
			return new Vector4( vp.X, vp.Y, vp.Width, vp.Height );
		}

		public static Rectangle Bounds( this Viewport vp ) {
			return new Rectangle( vp.X, vp.Y, vp.Width, vp.Height );
		}

		public static Vector2 SafeAreaBottomLeft( this Viewport vp ) {
			return new Vector2( vp.TitleSafeArea.Left, vp.TitleSafeArea.Bottom );
		}
		public static Vector2 SafeAreaBottomRight( this Viewport vp ) {
			return new Vector2( vp.TitleSafeArea.Right, vp.TitleSafeArea.Bottom );
		}
		public static Vector2 SafeAreaTopLeft( this Viewport vp ) {
			return new Vector2( vp.TitleSafeArea.Left, vp.TitleSafeArea.Top );
		}
		public static Vector2 SafeAreaTopRight( this Viewport vp ) {
			return new Vector2( vp.TitleSafeArea.Right, vp.TitleSafeArea.Top );
		}
	}
}
