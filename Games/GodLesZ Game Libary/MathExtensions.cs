using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace GLibary {
	public static class MathExtensions {
		public static bool NearlyZero( this float val ) {
			return val < float.Epsilon && val > -float.Epsilon;
		}

		public static bool NearlyEqual( this Vector3 v1, Vector3 v2 ) {
			return ( v2 - v1 ).LengthSquared() > float.MinValue * 5.0f ? false : true;
		}
	}
}
