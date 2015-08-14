using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Ragnarok3D.Editor {
	class MathExtra {
		public static float GetAngleFrom2DVectors( Vector2 OriginLoc, Vector2 TargetLoc, bool bRadian ) {
			double Angle;
			float xDist = OriginLoc.X - TargetLoc.X;
			float yDist = OriginLoc.Y - TargetLoc.Y;
			double norm = Math.Abs( xDist ) + Math.Abs( yDist );

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
				Angle = MathHelper.ToRadians( Convert.ToSingle( Angle ) );

			return Convert.ToSingle( Angle );
		}

		public static Vector2 TriangleCentroid( Vector3 P, Vector3 Q, Vector3 R ) {
			Vector2[] triPoint = new Vector2[ 3 ];
			triPoint[ 0 ] = new Vector2( P.X );
			triPoint[ 1 ] = new Vector2( Q.X );
			triPoint[ 2 ] = new Vector2( R.X );
			return new Vector2( ( triPoint[ 0 ].X + triPoint[ 1 ].X + triPoint[ 2 ].X ) / 3f, ( triPoint[ 0 ].Y + triPoint[ 1 ].Y + triPoint[ 2 ].Y ) / 3f );
		}

		public static Vector3 GetNormal( Vector3 p1, Vector3 p2, Vector3 p3 ) {
			Vector3 v1 = p2 - p1;
			Vector3 v2 = p1 - p3;

			Vector3 norm = Vector3.Cross( v1, v2 );
			norm.Normalize();

			return norm;
		}

		// <summary Special Thanks>
		// to Derek Nedelman (http://www.gameprojects.com)
		// </summary>
		public static Matrix MatrixFromNormal( Vector3 normal ) {
			bool lookingUp = false;

			Vector3 right = new Vector3( normal.Y, -normal.X, 0.0f );
			if( right.X == 0.0f && right.Y == 0.0f ) {
				lookingUp = true;
				right.X = 1.0f;
			}

			Matrix m;
			if( lookingUp )
				m = FromRowVectors( right, Vector3.Cross( right, normal ), normal, Vector3.Zero );
			else
				m = FromRowVectors( Vector3.Cross( right, normal ), right, normal, Vector3.Zero );

			//It would be better to orthogonolize the matrix but normalizing it
			//seems to work well enough
			Normalize( ref m );

			return m;
		}

		// <summary Special Thanks>
		// to Derek Nedelman (http://www.gameprojects.com)
		// </summary>
		public static Matrix FromRowVectors( Vector3 m0, Vector3 m1, Vector3 m2, Vector3 m3 ) {
			return new Matrix
				(
				m0.X, m0.Y, m0.Z, 0.0f,
				m1.X, m1.Y, m1.Z, 0.0f,
				m2.X, m2.Y, m2.Z, 0.0f,
				m3.X, m3.Y, m3.Z, 1.0f
				);
		}

		// <summary Special Thanks>
		// to Derek Nedelman (http://www.gameprojects.com)
		// </summary>
		public static void Normalize( ref Matrix m ) {
			float row1Normalizer = 1.0f / (float)Math.Sqrt( m.M11 * m.M11 + m.M12 * m.M12 + m.M13 * m.M13 );
			m.M11 *= row1Normalizer;
			m.M12 *= row1Normalizer;
			m.M13 *= row1Normalizer;

			float row2Normalizer = 1.0f / (float)Math.Sqrt( m.M21 * m.M21 + m.M22 * m.M22 + m.M23 * m.M23 );
			m.M21 *= row2Normalizer;
			m.M22 *= row2Normalizer;
			m.M23 *= row2Normalizer;

			float row3Normalizer = 1.0f / (float)Math.Sqrt( m.M31 * m.M31 + m.M32 * m.M32 + m.M33 * m.M33 );
			m.M31 *= row3Normalizer;
			m.M32 *= row3Normalizer;
			m.M33 *= row3Normalizer;
		}

		// <summary Special Thanks>
		// to minahito http://lablab.jp/
		// ref: http://forums.microsoft.com/MSDN/ShowPost.aspx?PostID=1144568&SiteID=1
		// </summary>
		public static bool Intersects( Ray ray, Vector3 a, Vector3 b, Vector3 c, Vector3 normal, bool positiveSide, bool negativeSide, out float t ) {
			t = 0;
			{
				float denom = Vector3.Dot( normal, ray.Direction );

				if( denom > float.Epsilon ) {
					if( !negativeSide )
						return false;
				} else if( denom < -float.Epsilon ) {
					if( !positiveSide )
						return false;
				} else {
					return false;
				}

				t = Vector3.Dot( normal, a - ray.Position ) / denom;

				if( t < 0 ) {
					// Interersection is behind origin
					return false;
				}
			}

			// Calculate the largest area projection plane in X, Y or Z.
			int i0, i1;
			{
				float n0 = Math.Abs( normal.X );
				float n1 = Math.Abs( normal.Y );
				float n2 = Math.Abs( normal.Z );

				i0 = 1;
				i1 = 2;

				if( n1 > n2 ) {
					if( n1 > n0 )
						i0 = 0;
				} else {
					if( n2 > n0 )
						i1 = 0;
				}
			}

			float[] A = { a.X, a.Y, a.Z };
			float[] B = { b.X, b.Y, b.Z };
			float[] C = { c.X, c.Y, c.Z };
			float[] R = { ray.Direction.X, ray.Direction.Y, ray.Direction.Z };
			float[] RO = { ray.Position.X, ray.Position.Y, ray.Position.Z };

			// Check the intersection point is inside the triangle.
			{
				float u1 = B[ i0 ] - A[ i0 ];
				float v1 = B[ i1 ] - A[ i1 ];
				float u2 = C[ i0 ] - A[ i0 ];
				float v2 = C[ i1 ] - A[ i1 ];
				float u0 = t * R[ i0 ] + RO[ i0 ] - A[ i0 ];
				float v0 = t * R[ i1 ] + RO[ i1 ] - A[ i1 ];

				float alpha = u0 * v2 - u2 * v0;
				float beta = u1 * v0 - u0 * v1;
				float area = u1 * v2 - u2 * v1;

				float EPSILON = 1e-3f;

				float tolerance = EPSILON * area;

				if( area > 0 ) {
					if( alpha < tolerance || beta < tolerance || alpha + beta > area - tolerance )
						return false;
				} else {
					if( alpha > tolerance || beta > tolerance || alpha + beta < area - tolerance )
						return false;
				}
			}

			return true;
		}

		// <summary Special Thanks>
		// to minahito http://lablab.jp/
		// </summary>
		public static Nullable<float> RayPlaneIntersects( Ray ray, Plane plane ) {
			float denom = Vector3.Dot( plane.Normal, ray.Direction );
			if( Math.Abs( denom ) < float.Epsilon ) {
				return null;
			} else {
				float nom = Vector3.Dot( plane.Normal, ray.Position ) + plane.D;
				float t = -( nom / denom );

				if( t >= 0 )
					return t;

				return null;
			}
		}

		// <summary Special Thanks>
		// to Dr^Nick http://www.andrewbutcher.net/
		// </summary>
		public static Plane TransformPlane( ref Plane p, ref Matrix m ) {
			Vector3 pNorm = p.Normal;
			pNorm.Normalize();

			Vector3 planeCenter = Vector3.Zero + p.D * pNorm;

			Vector3 newCenter = Vector3.Transform( planeCenter, m );

			Vector3 centerToOrigin = Vector3.Zero - newCenter;

			float newDist = Math.Abs( centerToOrigin.Length() );

			Vector3 newNorm = Vector3.TransformNormal( pNorm, m );
			newNorm.Normalize();

			return new Plane( newNorm, newDist );
		}

		// <summary Special Thanks>
		// to Derek Nedelman (http://www.gameprojects.com)
		// </summary>
		public static Matrix CreateReflectionMatrix( Plane plane ) {
			Matrix m;
			CreateReflectionMatrix( ref plane, out m );
			return m;
		}

		// <summary Special Thanks>
		// to Derek Nedelman (http://www.gameprojects.com)
		// </summary>
		public static void CreateReflectionMatrix( ref Plane plane, out Matrix result ) {
			//Scale to the other side of the plane
			CreateDirectionScaleMatrix( ref plane.Normal, -1.0f, out result );

			//Translate to the other side of the plane, moving along the 
			//negative direction of the plane normal
			result.Translation = plane.Normal * -2.0f * plane.D;
		}

		// <summary Special Thanks>
		// to Derek Nedelman (http://www.gameprojects.com)
		// </summary>
		public static void CreateDirectionScaleMatrix( ref Vector3 direction, float scaleX, float scaleY, float scaleZ, out Matrix result ) {
			float xy = direction.X * direction.Y;
			float xz = direction.X * direction.Z;
			float yz = direction.Y * direction.Z;

			result = new Matrix
				(
				1.0f + ( scaleX - 1.0f ) * direction.X * direction.X, ( scaleY - 1.0f ) * xy, ( scaleZ - 1.0f ) * xz, 0.0f,
				( scaleX - 1.0f ) * xy, 1.0f + ( scaleY - 1.0f ) * direction.Y * direction.Y, ( scaleZ - 1.0f ) * yz, 0.0f,
				( scaleX - 1.0f ) * xz, ( scaleY - 1.0f ) * yz, 1.0f + ( scaleZ - 1.0f ) * direction.Z * direction.Z, 0.0f,
				0.0f, 0.0f, 0.0f, 1.0f
				);
		}

		public static Matrix CreateDirectionScaleMatrix( Vector3 direction, float scale ) {
			Matrix m;
			CreateDirectionScaleMatrix( ref direction, scale, out m );
			return m;
		}

		public static void CreateDirectionScaleMatrix( ref Vector3 direction, float scale, out Matrix result ) {
			CreateDirectionScaleMatrix( ref direction, scale, scale, scale, out result );
		}

		public static Matrix CreateDirectionScaleMatrix( Vector3 direction, float scaleX, float scaleY, float scaleZ ) {
			Matrix m;
			CreateDirectionScaleMatrix( ref direction, scaleX, scaleY, scaleZ, out m );
			return m;
		}
	}
}
