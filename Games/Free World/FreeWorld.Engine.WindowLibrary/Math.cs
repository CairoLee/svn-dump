using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace FreeWorld.Engine.WindowLibrary {
	public class MathAdd {

		public static void Clamp( ref int Value, int Min, int Max ) {
			Value = Math.Min( Max, Value );
			Value = Math.Max( Min, Value );
		}

		public static int Clamp( int Value, int Min, int Max ) {
			MathAdd.Clamp( ref Value, Min, Max );
			return Value;
		}


		public static float GetAngleFrom2DVectors( Vector2 OriginLoc, Vector2 TargetLoc, bool bRadian ) {
			double Angle;
			float xDist = OriginLoc.X - TargetLoc.X;
			float yDist = OriginLoc.Y - TargetLoc.Y;
			double norm = System.Math.Abs( xDist ) + System.Math.Abs( yDist );

			if( ( xDist >= 0 ) & ( yDist >= 0 ) ) {
				//Lower Right Quadran
				Angle = 90 * ( yDist / norm ) + 270;
			} else if( ( xDist <= 0 ) && ( yDist >= 0 ) ) {
				//Lower Left Quadran
				Angle = -90 * ( yDist / norm ) + 90;
			} else if( ( ( xDist ) <= 0 ) && ( ( yDist ) <= 0 ) ) {
				//Upper Left Quadran
				Angle = 90 * ( xDist / norm ) + 180;
			} else {
				//Upper Right Quadran
				Angle = 90 * ( xDist / norm ) + 180;
			}

			if( bRadian )
				Angle = MathHelper.ToRadians( System.Convert.ToSingle( Angle ) );

			return System.Convert.ToSingle( Angle );
		}

		public static bool isInRectangle( Point position, Rectangle rectangle ) {
			if( position.X >= rectangle.X && position.X <= rectangle.X + rectangle.Width )
				if( position.Y >= rectangle.Y && position.Y <= rectangle.Y + rectangle.Height )
					return true;

			return false;
		}

	}

}
