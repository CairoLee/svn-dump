using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Engine3DFromRiemersTutorial {
	static class Extentions {
		public static float DistanceTo( this Point p1, Point p2 ) {
			return Vector2.Distance( new Vector2( p1.X, p1.Y ), new Vector2( p2.X, p2.Y ) );
		}
	}
}
