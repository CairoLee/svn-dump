#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
#endregion


namespace GLibary {
	public static class Intersection {


		///********************************************************************
		//Desc: Taken from comp.graphics.algorithms FAQ
		//*********************************************************************/
		public static bool IntersectionOfTwoLines( Vector3 a, Vector3 b, Vector3 c, Vector3 d, ref Vector3 result ) {
			double r, s;

			double denominator = ( b.X - a.X ) * ( d.Y - c.Y ) - ( b.Y - a.Y ) * ( d.X - c.X );

			// If the denominator in above is zero, AB & CD are colinear
			if( denominator == 0 )
				return false;

			double numeratorR = ( a.Y - c.Y ) * ( d.X - c.X ) - ( a.X - c.X ) * ( d.Y - c.Y );
			//  If the numerator above is also zero, AB & CD are collinear.
			//  If they are collinear, then the segments may be projected to the x- 
			//  or y-axis, and overlap of the projected intervals checked.

			r = numeratorR / denominator;

			double numeratorS = ( a.Y - c.Y ) * ( b.X - a.X ) - ( a.X - c.X ) * ( b.Y - a.Y );

			s = numeratorS / denominator;

			//  If 0<=r<=1 & 0<=s<=1, intersection exists
			//  r<0 or r>1 or s<0 or s>1 line segments do not intersect
			if( r < 0 || r > 1 || s < 0 || s > 1 )
				return false;

			///*
			//    Note:
			//    If the intersection point of the 2 lines are needed (lines in this
			//    context mean infinite lines) regardless whether the two line
			//    segments intersect, then
			//
			//        If r>1, P is located on extension of AB
			//        If r<0, P is located on extension of BA
			//        If s>1, P is located on extension of CD
			//        If s<0, P is located on extension of DC
			//*/

			// Find intersection point
			result.X = (float)( a.X + ( r * ( b.X - a.X ) ) );
			result.Y = (float)( a.Y + ( r * ( b.Y - a.Y ) ) );

			return true;
		}



		public static float Epsilon = 1E-5f; //for numerical imprecision 
		//dont declare this more than once

		public static bool PointInsideEdge( ref Vector3 edgeA, ref Vector3 edgeB, ref Vector3 point ) {
			return Vector3.Dot( edgeA - point, edgeB - point ) <= Epsilon;
		}


		public static bool PointInsidePoly(	ref Vector3 vA, ref Vector3 vB, ref Vector3 vC, ref Vector3 p ) {
			int pos = 0;
			int neg = 0;
			Vector3[] verts = { vA, vB, vC };
			Plane pl = new Plane( vA, vB, vC );

			uint v0 = 3 - 1;
			for( uint v1 = 0; v1 < 3; v0 = v1, ++v1 ) {
				Vector3 p0 = verts[ v0 ];
				Vector3 p1 = verts[ v1 ];

				// Generate a normal for this edge

				Vector3 n = Vector3.Cross( p1 - p0, pl.Normal );

				// Which side of this edge-plane is the point?

				float halfPlane = Vector3.Dot( p, n ) - Vector3.Dot( p0, n );

				// Keep track of positives and negatives 
				//(but not zeros -- which means it's on the edge)

				if( halfPlane > Epsilon )
					pos++;
				else if( halfPlane < -Epsilon )
					neg++;

				// Early-out

				if( ( pos | neg ) != 0 )
					return false;
			}

			// If they're ALL positive, or ALL negative, then it's inside

			if( ( pos | neg ) == 0 )
				return true;

			// Must not be inside, because some were pos and some were neg

			return false;
		}



		// triangle intersect from http://www.graphics.cornell.edu/pubs/1997/MT97.pdf
		public static bool RayTriangleIntersect( Vector3 ray_origin, Vector3 ray_direction, Vector3 vert0, Vector3 vert1, Vector3 vert2, out float t, out float u, out float v ) {
			t = 0;
			u = 0;
			v = 0;

			Vector3 edge1 = vert1 - vert0;
			Vector3 edge2 = vert2 - vert0;

			Vector3 tvec, pvec, qvec;
			float det, inv_det;

			pvec = Vector3.Cross( ray_direction, edge2 );

			det = Vector3.Dot( edge1, pvec );

			if( det > -0.00001f )
				return false;

			inv_det = 1.0f / det;

			tvec = ray_origin - vert0;

			u = Vector3.Dot( tvec, pvec ) * inv_det;
			if( u < -0.001f || u > 1.001f )
				return false;

			qvec = Vector3.Cross( tvec, edge1 );

			v = Vector3.Dot( ray_direction, qvec ) * inv_det;
			if( v < -0.001f || u + v > 1.001f )
				return false;

			t = Vector3.Dot( edge2, qvec ) * inv_det;

			if( t <= 0 )
				return false;

			return true;
		}

		// triangle intersect from http://www.graphics.cornell.edu/pubs/1997/MT97.pdf
		public static bool RayTriangleIntersect( Ray r,	Vector3 vert0, Vector3 vert1, Vector3 vert2,
					out float distance ) {
			distance = 0;

			Vector3 edge1 = vert1 - vert0;
			Vector3 edge2 = vert2 - vert0;

			Vector3 tvec, pvec, qvec;
			float det, inv_det;

			pvec = Vector3.Cross( r.Direction, edge2 );

			det = Vector3.Dot( edge1, pvec );

			if( det > -0.00001f )
				return false;

			inv_det = 1.0f / det;

			tvec = r.Position - vert0;

			float u = Vector3.Dot( tvec, pvec ) * inv_det;
			if( u < -0.001f || u > 1.001f )
				return false;

			qvec = Vector3.Cross( tvec, edge1 );

			float v = Vector3.Dot( r.Direction, qvec ) * inv_det;
			if( v < -0.001f || u + v > 1.001f )
				return false;

			distance = Vector3.Dot( edge2, qvec ) * inv_det;

			if( distance <= 0 )
				return false;

			return true;
		}


		// Compute barycentric coordinates (u, v, w) for 
		// Vector3 p with respect to triangle (a, b, c)
		public static void Barycentric( Vector3 a, Vector3 b, Vector3 c, Vector3 p, out Vector3 uvw ) {
			Vector3 v0 = b - a, v1 = c - a, v2 = p - a;
			float d00 = Vector3.Dot( v0, v0 );
			float d01 = Vector3.Dot( v0, v1 );
			float d11 = Vector3.Dot( v1, v1 );
			float d20 = Vector3.Dot( v2, v0 );
			float d21 = Vector3.Dot( v2, v1 );
			float denom = d00 * d11 - d01 * d01;

			uvw = new Vector3();
			if( denom == 0 )
				return;

			uvw.Y = ( d11 * d20 - d01 * d21 ) / denom;
			uvw.Z = ( d00 * d21 - d01 * d20 ) / denom;
			uvw.X = 1.0f - uvw.Y - uvw.Z;
		}

		public static float TriArea2D( Vector2 p1, Vector2 p2, Vector2 p3 ) {
			return ( p1.X - p2.X ) * ( p2.Y - p3.Y ) - ( p2.X - p3.X ) * ( p1.Y - p2.Y );
		}

		public static float TriArea2D( float x1, float y1, float x2, float y2, float x3, float y3 ) {
			return ( x1 - x2 ) * ( y2 - y3 ) - ( x2 - x3 ) * ( y1 - y2 );
		}

		// Compute barycentric coordinates (u, v) for 
		// Vector3 p with respect to triangle (a, b, c)
		public static void Barycentric2( Vector3 a, Vector3 b, Vector3 c, Vector3 p, out Vector2 uv ) {
			uv = new Vector2();

			// Unnormalized triangle normal
			Vector3 m = Vector3.Cross( b - a, c - a );
			// Nominators and one-over-denominator for u and v ratios
			float nu, nv, ood;
			// Absolute components for determining projection plane
			float x = Math.Abs( m.X ), y = Math.Abs( m.Y ), z = Math.Abs( m.Z );


			// Compute areas in plane of largest projection
			if( x >= y && x >= z ) {
				// x is largest, project to the yz plane
				nu = TriArea2D( p.Y, p.Z, b.Y, b.Z, c.Y, c.Z ); // Area of PBC in yz plane
				nv = TriArea2D( p.Y, p.Z, c.Y, c.Z, a.Y, a.Z ); // Area of PCA in yz plane
				ood = 1.0f / m.X;                             // 1/(2*area of ABC in yz plane)
			} else if( y >= x && y >= z ) {
				// y is largest, project to the xz plane
				nu = TriArea2D( p.X, p.Z, b.X, b.Z, c.X, c.Z );
				nv = TriArea2D( p.X, p.Z, c.X, c.Z, a.X, a.Z );
				ood = 1.0f / -m.Y;
			} else {
				// z is largest, project to the xy plane
				nu = TriArea2D( p.X, p.Y, b.X, b.Y, c.X, c.Y );
				nv = TriArea2D( p.X, p.Y, c.X, c.Y, a.X, a.Y );
				ood = 1.0f / m.Z;
			}

			uv.X = nu * ood;
			uv.Y = nv * ood;
		}


		// Test if Vector3 p is contained in triangle (a, b, c)
		public static bool PointInTriangleBarycentric( Vector3 a, Vector3 b, Vector3 c, Vector3 p ) {
			Vector3 uvw;
			Barycentric( a, b, c, p, out uvw );
			return uvw.Y >= 0.0f && uvw.Z >= 0.0f && ( uvw.Y + uvw.Z ) <= 1.0f;
		}



		// Test if quadrilateral (a, b, c, d) is convex
		public static bool IsConvexQuad( Vector3 a, Vector3 b, Vector3 c, Vector3 d ) {
			// Quad is nonconvex if Vector3.Dot(Vector3.Cross(bd, ba), Vector3.Cross(bd, bc)) >= 0
			Vector3 bda = Vector3.Cross( d - b, a - b );
			Vector3 bdc = Vector3.Cross( d - b, c - b );
			if( Vector3.Dot( bda, bdc ) >= 0.0f )
				return false;
			// Quad is now convex iff Vector3.Dot(Vector3.Cross(ac, ad), Vector3.Cross(ac, ab)) < 0
			Vector3 acd = Vector3.Cross( c - a, d - a );
			Vector3 acb = Vector3.Cross( c - a, b - a );
			return Vector3.Dot( acd, acb ) < 0.0f;
		}


		// Return index i of Vector3 p[i] farthest from the edge ab, to the left of the edge
		public static int Vector3FarthestFromEdge( Vector2 a, Vector2 b, Vector2[] p, int n ) {
			// Create edge Vector3 and Vector3 (counterclockwise) perpendicular to it
			Vector2 e = b - a;
			Vector2 eperp = new Vector2( -e.Y, e.X );

			// Track index, ‘distance’ and ‘rightmostness’ of currently best Vector3
			int bestIndex = -1;
			float maxVal = -float.MaxValue, rightMostVal = -float.MaxValue;

			// Test all Vector3s to find the one farthest from edge ab on the left side
			for( int i = 1; i < n; i++ ) {
				float d = Vector2.Dot( p[ i ] - a, eperp ); // d is proportional to distance along eperp
				float r = Vector2.Dot( p[ i ] - a, e );     // r is proportional to distance along e
				if( d > maxVal || ( d == maxVal && r > rightMostVal ) ) {
					bestIndex = i;
					maxVal = d;
					rightMostVal = r;
				}
			}
			return bestIndex;
		}



		public static Vector3 ClosestPtPointPlane( Vector3 q, Plane p ) {
			float t = Vector3.Dot( p.Normal, q ) - p.D;
			return q - t * p.Normal;
		}


		public static float DistPointPlane( Vector3 q, Plane p ) {
			return ( Vector3.Dot( p.Normal, q ) - p.D ) / Vector3.Dot( p.Normal, p.Normal );
		}


		// Given segment ab and Vector3 c, computes closest Vector3 d on ab.
		// Also returns t for the position of d, d(t) = a + t*(b - a)
		public static void ClosestPtPointSegment( Vector3 c, Vector3 a, Vector3 b, ref float t, ref Vector3 d ) {
			Vector3 ab = b - a;
			// Project c onto ab, computing parameterized position d(t) = a + t*(b - a)
			t = Vector3.Dot( c - a, ab ) / Vector3.Dot( ab, ab );
			// If outside segment, clamp t (and therefore d) to the closest endpoint
			if( t < 0.0f )
				t = 0.0f;
			if( t > 1.0f )
				t = 1.0f;
			// Compute projected position from the clamped t
			d = a + t * ab;
		}


		// Given segment ab and Vector2 c, computes closest Vector3 2 on ab.
		// Also returns t for the parametric position of d, d(t) = a + t*(b - a)
		public static void ClosestPtPointSegment2D( Vector2 c, Vector2 a, Vector2 b, ref float t, ref Vector2 d ) {
			Vector2 ab = b - a;
			// Project c onto ab, but deferring divide by Vector2.Dot(ab, ab)
			t = Vector2.Dot( c - a, ab );
			if( t <= 0.0f ) {
				// c projects outside the [a,b] interval, on the a side; clamp to a
				t = 0.0f;
				d = a;
			} else {
				float denom = Vector2.Dot( ab, ab ); // Always nonnegative since denom = ||ab||^2
				if( t >= denom ) {
					// c projects outside the [a,b] interval, on the b side; clamp to b
					t = 1.0f;
					d = b;
				} else {
					// c projects inside the [a,b] interval; must do deferred divide now
					t = t / denom;
					d = a + t * ab;
				}
			}
		}


		// Returns the squared distance between Vector3 c and segment ab
		public static float SqDistPointSegment( Vector3 a, Vector3 b, Vector3 c ) {
			Vector3 ab = b - a, ac = c - a, bc = c - b;
			float e = Vector3.Dot( ac, ab );
			// Handle cases where c projects outside ab
			if( e <= 0.0f )
				return Vector3.Dot( ac, ac );
			float f = Vector3.Dot( ab, ab );
			if( e >= f )
				return Vector3.Dot( bc, bc );
			// Handle case where c projects onto ab
			return Vector3.Dot( ac, ac ) - e * e / f;
		}


		// Given Vector4 p, return the Vector4 q on or in AABB b, that is closest to p
		public static void ClosestPtPointAABB( Vector4 p, BoundingBox b, ref Vector3 q ) {
			// For each coordinate axis, if the Vector3 coordinate value is
			// outside box, clamp it to the box, else keep it as is
			float v = p.X;
			if( v < b.Min.X )
				v = b.Min.X;
			if( v > b.Max.X )
				v = b.Max.X;
			q.X = v;
			if( v < b.Min.Y )
				v = b.Min.Y;
			if( v > b.Max.Y )
				v = b.Max.Y;
			q.Y = v;
			if( v < b.Min.Z )
				v = b.Min.Z;
			if( v > b.Max.Z )
				v = b.Max.Z;
			q.Z = v;
		}


		// Computes the square distance between a Vector3 p and an AABB b
		public static float SqDistPointAABB( Vector3 p, BoundingBox b ) {
			float sqDist = 0.0f;

			float v = p.X;
			if( v < b.Min.X )
				sqDist += ( b.Min.X - v ) * ( b.Min.X - v );
			if( v > b.Max.X )
				sqDist += ( v - b.Max.X ) * ( v - b.Max.X );
			v = p.Y;
			if( v < b.Min.Y )
				sqDist += ( b.Min.Y - v ) * ( b.Min.Y - v );
			if( v > b.Max.Y )
				sqDist += ( v - b.Max.Y ) * ( v - b.Max.Y );
			v = p.Z;
			if( v < b.Min.Z )
				sqDist += ( b.Min.Z - v ) * ( b.Min.Z - v );
			if( v > b.Max.Z )
				sqDist += ( v - b.Max.Z ) * ( v - b.Max.Z );

			return sqDist;
		}




		// Return Vector3 q on (or in) rect (specified by a, b, and c), closest to given Vector3 p
		public static void ClosestPtPointRect( Vector3 p, Vector3 a, Vector3 b, Vector3 c, ref Vector3 q ) {
			Vector3 ab = b - a; // Vector3 across rect
			Vector3 ac = c - a; // Vector3 down rect
			Vector3 d = p - a;
			// Start result at top-left corner of rect; make steps from there
			q = a;
			// Clamp p’ (projection of p to plane of r) to rectangle in the across direction
			float dist = Vector3.Dot( d, ab );
			float maxdist = Vector3.Dot( ab, ab );
			if( dist >= maxdist )
				q += ab;
			else if( dist > 0.0f )
				q += ( dist / maxdist ) * ab;
			// Clamp p’ (projection of p to plane of r) to rectangle in the down direction
			dist = Vector3.Dot( d, ac );
			maxdist = Vector3.Dot( ac, ac );
			if( dist >= maxdist )
				q += ac;
			else if( dist > 0.0f )
				q += ( dist / maxdist ) * ac;
		}


		public static Vector3 ClosestPtPointTriangle( Vector3 p, Vector3 a, Vector3 b, Vector3 c ) {
			Vector3 ab = b - a;
			Vector3 ac = c - a;
			Vector3 bc = c - b;

			// Compute parametric position s for projection P' of P on AB,
			// P' = A + s*AB, s = snom/(snom+sdenom)
			float snom = Vector3.Dot( p - a, ab ), sdenom = Vector3.Dot( p - b, a - b );

			// Compute parametric position t for projection P' of P on AC,
			// P' = A + t*AC, s = tnom/(tnom+tdenom)
			float tnom = Vector3.Dot( p - a, ac ), tdenom = Vector3.Dot( p - c, a - c );

			if( snom <= 0.0f && tnom <= 0.0f )
				return a; // Vertex region early out

			// Compute parametric position u for projection P' of P on BC,
			// P' = B + u*BC, u = unom/(unom+udenom)
			float unom = Vector3.Dot( p - b, bc ), udenom = Vector3.Dot( p - c, b - c );

			if( sdenom <= 0.0f && unom <= 0.0f )
				return b; // Vertex region early out
			if( tdenom <= 0.0f && udenom <= 0.0f )
				return c; // Vertex region early out


			// P is outside (or on) AB if the triple scalar product [N PA PB] <= 0
			Vector3 n = Vector3.Cross( b - a, c - a );
			float vc = Vector3.Dot( n, Vector3.Cross( a - p, b - p ) );
			// If P outside AB and within feature region of AB,
			// return projection of P onto AB
			if( vc <= 0.0f && snom >= 0.0f && sdenom >= 0.0f )
				return a + snom / ( snom + sdenom ) * ab;

			// P is outside (or on) BC if the triple scalar product [N PB PC] <= 0
			float va = Vector3.Dot( n, Vector3.Cross( b - p, c - p ) );
			// If P outside BC and within feature region of BC,
			// return projection of P onto BC
			if( va <= 0.0f && unom >= 0.0f && udenom >= 0.0f )
				return b + unom / ( unom + udenom ) * bc;

			// P is outside (or on) CA if the triple scalar product [N PC PA] <= 0
			float vb = Vector3.Dot( n, Vector3.Cross( c - p, a - p ) );
			// If P outside CA and within feature region of CA,
			// return projection of P onto CA
			if( vb <= 0.0f && tnom >= 0.0f && tdenom >= 0.0f )
				return a + tnom / ( tnom + tdenom ) * ac;

			// P must project inside face region. Compute Q using barycentric coordinates
			float u = va / ( va + vb + vc );
			float v = vb / ( va + vb + vc );
			float w = 1.0f - u - v; // = vc / (va + vb + vc)
			return u * a + v * b + w * c;
		}


		public static Vector3 ClosestPtPointTriangleNew( Vector3 p, Vector3 a, Vector3 b, Vector3 c ) {
			// Check if P in vertex region outside A
			Vector3 ab = b - a;
			Vector3 ac = c - a;
			Vector3 ap = p - a;
			float d1 = Vector3.Dot( ab, ap );
			float d2 = Vector3.Dot( ac, ap );
			if( d1 <= 0.0f && d2 <= 0.0f )
				return a; // barycentric coordinates (1,0,0)

			// Check if P in vertex region outside B
			Vector3 bp = p - b;
			float d3 = Vector3.Dot( ab, bp );
			float d4 = Vector3.Dot( ac, bp );
			if( d3 >= 0.0f && d4 <= d3 )
				return b; // barycentric coordinates (0,1,0)

			// Check if P in edge region of AB, if so return projection of P onto AB
			float vc = d1 * d4 - d3 * d2;
			if( vc <= 0.0f && d1 >= 0.0f && d3 <= 0.0f ) {
				float v = d1 / ( d1 - d3 );
				return a + v * ab; // barycentric coordinates (1-v,v,0)
			}

			// Check if P in vertex region outside C
			Vector3 cp = p - c;
			float d5 = Vector3.Dot( ab, cp );
			float d6 = Vector3.Dot( ac, cp );
			if( d6 >= 0.0f && d5 <= d6 )
				return c; // barycentric coordinates (0,0,1)

			// Check if P in edge region of AC, if so return projection of P onto AC
			float vb = d5 * d2 - d1 * d6;
			if( vb <= 0.0f && d2 >= 0.0f && d6 <= 0.0f ) {
				float w = d2 / ( d2 - d6 );
				return a + w * ac; // barycentric coordinates (1-w,0,w)
			}

			// Check if P in edge region of BC, if so return projection of P onto BC
			float va = d3 * d6 - d5 * d4;
			if( va <= 0.0f && ( d4 - d3 ) >= 0.0f && ( d5 - d6 ) >= 0.0f ) {
				float w = ( d4 - d3 ) / ( ( d4 - d3 ) + ( d5 - d6 ) );
				return b + w * ( c - b ); // barycentric coordinates (0,1-w,w)
			}

			// P inside face region. Compute Q through its barycentric coordinates (u,v,w)
			float denom = 1.0f / ( va + vb + vc );
			float v1 = vb * denom;
			float w1 = vc * denom;
			return a + ab * v1 + ac * w1; // = u*a + v*b + w*c, u = va * denom = 1.0f - v - w
		}






		// Clamp n to lie within the range [min, max]
		public static float Clamp( float n, float min, float max ) {
			if( n < min )
				return min;
			if( n > max )
				return max;
			return n;
		}



		// Returns 2 times the signed triangle area. The result is positive if
		// abc is ccw, negative if abc is cw, zero if abc is degenerate.
		public static float Signed2DTriArea( Vector2 a, Vector2 b, Vector2 c ) {
			return ( a.X - c.X ) * ( b.Y - c.Y ) - ( a.Y - c.Y ) * ( b.X - c.X );
		}


		// Test if segments ab and cd overlap. If they do, compute and return
		// intersection t value along ab and intersection position p
		public static bool Test2DSegmentSegment( Vector2 a, Vector2 b, Vector2 c,
												Vector2 d, ref float t, ref Vector2 p ) {
			// Sign of areas correspond to which side of ab points c and d are
			float a1 = Signed2DTriArea( a, b, d ); // Compute winding of abd (+ or -)
			float a2 = Signed2DTriArea( a, b, c ); // To intersect, must have sign opposite of a1

			// If c and d are on different sides of ab, areas have different signs
			if( a1 * a2 < 0.0f ) {
				// Compute signs for a and b with respect to segment cd
				float a3 = Signed2DTriArea( c, d, a ); // Compute winding of cda (+ or -)
				// Since area is constant a1-a2 = a3-a4, or a4=a3+a2-a1
				//      float a4 = Signed2DTriArea(c, d, b); // Must have opposite sign of a3
				float a4 = a3 + a2 - a1;
				// Points a and b on different sides of cd if areas have different signs
				if( a3 * a4 < 0.0f ) {
					// Segments intersect. Find intersection Vector2 along L(t)=a+t*(b-a).
					// Given height h1 of a over cd and height h2 of b over cd,
					// t = h1 / (h1 - h2) = (b*h1/2) / (b*h1/2 - b*h2/2) = a3 / (a3 - a4),
					// where b (the base of the triangles cda and cdb, i.e., the length
					// of cd) cancels out.
					t = a3 / ( a3 - a4 );
					p = a + t * ( b - a );
					return true;
				}
			}

			// Segments not intersecting (or collinear)
			return false;
		}


		public static bool IntersectSegmentPlane( Vector3 a, Vector3 b, Plane p, ref float t, ref Vector3 q ) {
			// Compute the t value for the directed line ab intersecting the plane
			Vector3 ab = b - a;
			t = ( p.D - Vector3.Dot( p.Normal, a ) ) / Vector3.Dot( p.Normal, ab );

			// If t in [0..1] compute and return intersection Vector3
			if( t >= 0.0f && t <= 1.0f ) {
				q = a + t * ab;
				return true;
			}
			// Else no intersection
			return false;
		}




		// Intersects ray r = p + td, |d| = 1, with BoundingSphere s and, if intersecting,
		// returns t value of intersection and intersection Vector3 q
		public static bool IntersectRaySphere( Vector3 p, Vector3 d, BoundingSphere s, ref float t, ref Vector3 q ) {
			Vector3 m = p - s.Center;
			float b = Vector3.Dot( m, d );
			float c = Vector3.Dot( m, m ) - s.Radius * s.Radius;
			// Exit if r’s origin outside s (c > 0)and r pointing away from s (b > 0)
			if( c > 0.0f && b > 0.0f )
				return false;
			float discr = b * b - c;
			// A negative discriminant corresponds to ray missing BoundingSphere
			if( discr < 0.0f )
				return false;
			// Ray now found to intersect BoundingSphere, compute smallest t value of intersection
			t = -b - (float)Math.Sqrt( discr );
			// If t is negative, ray started inside BoundingSphere so clamp t to zero
			if( t < 0.0f )
				t = 0.0f;
			q = p + t * d;
			return true;
		}


		// Test if ray r = p + td intersects BoundingSphere s
		public static bool TestRaySphere( Vector3 p, Vector3 d, BoundingSphere s ) {
			Vector3 m = p - s.Center;
			float c = Vector3.Dot( m, m ) - s.Radius * s.Radius;
			// If there is definitely at least one real root, there must be an intersection
			if( c <= 0.0f )
				return true;
			float b = Vector3.Dot( m, d );
			// Early exit if ray origin outside BoundingSphere and ray pointing away from BoundingSphere
			if( b > 0.0f )
				return false;
			float disc = b * b - c;
			// A negative discriminant corresponds to ray missing BoundingSphere
			if( disc < 0.0f )
				return false;
			// Now ray must hit BoundingSphere
			return true;
		}



		// Given segment pq and triangle abc, returns whether segment intersects
		// triangle and if so, also returns the barycentric coordinates (u,v,w)
		// of the intersection Vector3
		public static bool IntersectSegmentTriangle( Vector3 p, Vector3 q, Vector3 a, Vector3 b, Vector3 c, ref float u, ref float v, ref float w, ref float t ) {
			Vector3 ab = b - a;
			Vector3 ac = c - a;
			Vector3 qp = p - q;

			// Compute triangle normal. Can be precalculated or cached if
			// intersecting multiple segments against the same triangle
			Vector3 n = Vector3.Cross( ab, ac );

			// Compute denominator d. If d <= 0, segment is parallel to or points
			// away from triangle, so exit early
			float d = Vector3.Dot( qp, n );
			if( d <= 0.0f )
				return false;

			// Compute intersection t value of pq with plane of triangle. A ray
			// intersects iff 0 <= t. Segment intersects iff 0 <= t <= 1. Delay
			// dividing by d until intersection has been found to pierce triangle
			Vector3 ap = p - a;
			t = Vector3.Dot( ap, n );
			if( t < 0.0f )
				return false;
			if( t > d )
				return false; // For segment; exclude this code line for a ray test

			// Compute barycentric coordinate components and test if within bounds
			Vector3 e = Vector3.Cross( qp, ap );
			v = Vector3.Dot( ac, e );
			if( v < 0.0f || v > d )
				return false;
			w = -Vector3.Dot( ab, e );
			if( w < 0.0f || v + w > d )
				return false;

			// Segment/ray intersects triangle. Perform delayed division and
			// compute the last barycentric coordinate component
			float ood = 1.0f / d;
			t *= ood;
			v *= ood;
			w *= ood;
			u = 1.0f - v - w;
			return true;
		}


		// Intersect segment S(t)=sa+t(sb-sa), 0<=t<=1 against cylinder specified by p, q and r
		public static bool IntersectSegmentCylinder( Vector3 sa, Vector3 sb, Vector3 p, Vector3 q, float r, ref float t ) {
			Vector3 d = q - p, m = sa - p, n = sb - sa;
			float md = Vector3.Dot( m, d );
			float nd = Vector3.Dot( n, d );
			float dd = Vector3.Dot( d, d );
			// Test if segment fully outside either endcap of cylinder
			if( md < 0.0f && md + nd < 0.0f )
				return false; // Segment outside ‘p’ side of cylinder
			if( md > dd && md + nd > dd )
				return false;     // Segment outside ‘q’ side of cylinder
			float nn = Vector3.Dot( n, n );
			float mn = Vector3.Dot( m, n );
			float a = dd * nn - nd * nd;
			float k = Vector3.Dot( m, m ) - r * r;
			float c = dd * k - md * md;
			if( ( a ) < 0.0001f ) {
				// Segment runs parallel to cylinder axis
				if( c > 0.0f )
					return false; // ‘a’ and thus the segment lie outside cylinder
				// Now known that segment intersects cylinder; figure out how it intersects
				if( md < 0.0f )
					t = -mn / nn; // Intersect segment against ‘p’ endcap
				else if( md > dd )
					t = ( nd - mn ) / nn; // Intersect segment against ‘q’ endcap
				else
					t = 0.0f; // ‘a’ lies inside cylinder
				return true;
			}
			float b = dd * mn - nd * md;
			float discr = b * b - a * c;
			if( discr < 0.0f )
				return false; // No real roots; no intersection
			t = ( -b - (float)Math.Sqrt( discr ) ) / a;
			if( t < 0.0f || t > 1.0f )
				return false; // Intersection lies outside segment
			if( md + t * nd < 0.0f ) {
				// Intersection outside cylinder on ‘p’ side
				if( nd <= 0.0f )
					return false; // Segment pointing away from endcap
				t = -md / nd;
				// Keep intersection if Vector3.Dot(S(t) - p, S(t) - p) <= r^2
				return ( ( k + 2 * t * ( mn + t * nn ) ) <= 0.0f ) ? true : false;
			} else if( md + t * nd > dd ) {
				// Intersection outside cylinder on ‘q’ side
				if( nd >= 0.0f )
					return false; // Segment pointing away from endcap
				t = ( dd - md ) / nd;
				// Keep intersection if Vector3.Dot(S(t) - q, S(t) - q) <= r^2
				return k + dd - 2 * md + t * ( 2 * ( mn - nd ) + t * nn ) <= 0.0f;
			}
			// Segment intersects cylinder between the end-caps; t is correct
			return false;
		}


		// Intersect segment S(t)=A+t(B-A), 0<=t<=1 against convex polyhedron specified
		// by the n halfspaces defined by the planes p[]. On exit tfirst and tlast
		// define the intersection, if any
		public static bool IntersectSegmentPolyhedron( Vector3 a, Vector3 b, Plane[] p, int n, ref float tfirst, ref float tlast ) {
			// Compute direction Vector3 for the segment
			Vector3 d = b - a;
			// Set initial interval to being the whole segment. For a ray, tlast should be
			// set to +FLT_MAX. For a line, additionally tfirst should be set to -FLT_MAX
			tfirst = 0.0f;
			tlast = 1.0f;
			// Intersect segment against each plane 
			for( int i = 0; i < n; i++ ) {
				float denom = Vector3.Dot( p[ i ].Normal, d );
				float dist = p[ i ].D - Vector3.Dot( p[ i ].Normal, a );
				// Test if segment runs parallel to the plane
				if( denom == 0.0f ) {
					// If so, return “no intersection” if segment lies outside plane
					if( dist > 0.0f )
						return false;
				} else {
					// Compute parameterized t value for intersection with current plane
					float t = dist / denom;
					if( denom < 0.0f ) {
						// When entering halfspace, update tfirst if t is larger
						if( t > tfirst )
							tfirst = t;
					} else {
						// When exiting halfspace, update tlast if t is smaller
						if( t < tlast )
							tlast = t;
					}
					// Exit with “no intersection” if intersection becomes empty
					if( tfirst > tlast )
						return false;
				}
			}
			// A nonzero logical intersection, so the segment intersects the polyhedron
			return true;
		}



		// Test if Vector3 P lies inside the counterclockwise triangle ABC
		public static bool PointInTriangle( Vector3 p, Vector3 a, Vector3 b, Vector3 c ) {
			// Translate Vector3 and triangle so that Vector3 lies at origin
			a -= p;
			b -= p;
			c -= p;
			// Compute normal vectors for triangles pab and pbc
			Vector3 u = Vector3.Cross( b, c );
			Vector3 v = Vector3.Cross( c, a );
			// Make sure they are both pointing in the same direction
			if( Vector3.Dot( u, v ) < 0.0f )
				return false;
			// Compute normal Vector3 for triangle pca
			Vector3 w = Vector3.Cross( a, b );
			// Make sure it points in the same direction as the first two
			if( Vector3.Dot( u, w ) < 0.0f )
				return false;
			// Otherwise P must be in (or on) the triangle
			return true;
		}



		public static bool PointInTriangle( Vector2 p, Vector2 a, Vector2 b, Vector2 c ) {
			// If P to the right of AB then outside triangle
			if( Vector2.Dot( p - a, b - a ) < 0.0f )
				return false;
			// If P to the right of BC then outside triangle
			if( Vector2.Dot( p - b, c - b ) < 0.0f )
				return false;
			// If P to the right of CA then outside triangle
			if( Vector2.Dot( p - c, a - c ) < 0.0f )
				return false;
			// Otherwise P must be in (or on) the triangle
			return true;
		}

		public static bool PointInTriangle2D( Vector2 p, Vector2 a, Vector2 b, Vector2 c ) {
			float pab = Vector2.Dot( p - a, b - a );
			float pbc = Vector2.Dot( p - b, c - b );
			// If P left of one of AB and BC and right of the other, not inside triangle
			if( Math.Sign( pab ) != Math.Sign( pbc ) )
				return false;
			float pca = Vector2.Dot( p - c, a - c );
			// If P left of one of AB and CA and right of the other, not inside triangle
			if( Math.Sign( pab ) != Math.Sign( pca ) )
				return false;
			// P left or right of all edges, so must be in (or on) the triangle
			return true;
		}


		// Test if Vector3 p inside polyhedron given as the intersection volume of n halfspaces
		public static bool TestPointPolyhedron( Vector3 p, Plane[] planes ) {
			for( int i = 0; i < planes.Length; i++ ) {
				// Exit with ‘no containment’ if p ever found outside a halfspace
				if( DistPointPlane( p, planes[ i ] ) > 0.0f )
					return false;
			}
			// p inside all halfspaces, so p must be inside intersection volume
			return true;
		}




		// Given planes p1 and p2, compute line L = p+t*d of their intersection.
		// Return 0 if no such line exists
		public static bool IntersectPlanes( Plane p1, Plane p2, ref Vector3 p, ref Vector3 d ) {
			// Compute direction of intersection line
			d = Vector3.Cross( p1.Normal, p2.Normal );

			// If d is (near) zero, the planes are parallel (and separated)
			// or coincident, so they’re not considered intersecting
			float denom = Vector3.Dot( d, d );
			if( denom < 0.00001f )
				return false;

			// Compute Vector3 on intersection line
			p = Vector3.Cross( p1.D * p2.Normal - p2.D * p1.Normal, d ) / denom;
			return true;
		}



		// Compute the Vector3 p at which the three planes p1, p2, and p3 intersect (if at all)
		public static bool IntersectPlanes( Plane p1, Plane p2, Plane p3, ref Vector3 p ) {
			Vector3 u = Vector3.Cross( p2.Normal, p3.Normal );
			float denom = Vector3.Dot( p1.Normal, u );
			if( (float)Math.Abs( denom ) < 0.0001f )
				return false; // Planes do not intersect in a Vector3
			p = ( p1.D * u + Vector3.Cross( p1.Normal, p3.D * p2.Normal - p2.D * p3.Normal ) ) / denom;
			return true;
		}



		// Intersect BoundingSphere s with movement Vector3 v with plane p. If intersecting
		// return time t of collision and Vector3 q at which BoundingSphere hits plane
		public static bool IntersectMovingSpherePlane( BoundingSphere s, Vector3 v,
														Plane p, ref float t, ref Vector3 q ) {
			// Compute distance of BoundingSphere center to plane
			float dist = Vector3.Dot( p.Normal, s.Center ) - p.D;
			if( Math.Abs( dist ) <= s.Radius ) {
				// The BoundingSphere is already overlapping the plane. Set time of
				// intersection to zero and q to BoundingSphere center
				t = 0.0f;
				q = s.Center;
				return true;
			} else {
				float denom = Vector3.Dot( p.Normal, v );
				if( denom * dist >= 0.0f ) {
					// No intersection as BoundingSphere moving parallel to or away from plane
					return false;
				} else {
					// BoundingSphere is moving towards the plane

					// Use +r in computations if BoundingSphere in front of plane, else -r
					float r = dist > 0.0f ? s.Radius : -s.Radius;
					t = ( r - dist ) / denom;
					if( t > 1.0f )
						return false;
					q = s.Center + t * v - r * p.Normal;
					return true;
				}
			}
		}


		// Test if BoundingSphere with radius r moving from a to b intersects with plane p
		public static bool TestMovingSpherePlane( Vector3 a, Vector3 b, float r, Plane p ) {
			// Get the distance for both a and b from plane p
			float adist = Vector3.Dot( a, p.Normal ) - p.D;
			float bdist = Vector3.Dot( b, p.Normal ) - p.D;
			// Intersects if on different sides of plane (distances have different signs)
			if( adist * bdist < 0.0f )
				return true;
			// Intersects if start or end position within radius from plane
			if( Math.Abs( adist ) <= r || Math.Abs( bdist ) <= r )
				return true;
			// No intersection
			return false;
		}


		public static bool TestMovingSphereSphere( BoundingSphere s0, BoundingSphere s1, Vector3 v0, Vector3 v1, ref float t ) {
			Vector3 s = s1.Center - s0.Center;      // Vector3 between BoundingSphere centers
			Vector3 v = v1 - v0;          // Relative motion of s1 with respect to stationary s0
			float r = s1.Radius + s0.Radius;       // Sum of BoundingSphere radii
			float c = Vector3.Dot( s, s ) - r * r;
			if( c < 0.0f ) {
				// Spheres initially overlapping so exit directly
				t = 0.0f;
				return true;
			}
			float a = Vector3.Dot( v, v );
			if( a < 0.0001f )
				return false; // Spheres not moving relative each other
			float b = Vector3.Dot( v, s );
			if( b >= 0.0f )
				return false;   // Spheres not moving towards each other
			float d = b * b - a * c;
			if( d < 0.0f )
				return false;  // No real-valued root, spheres do not intersect

			t = ( -b - (float)Math.Sqrt( d ) ) / a;
			return true;
		}



		// Support function that returns the AABB vertex with index n
		public static Vector3 Corner( BoundingBox b, int n ) {
			Vector3 p = new Vector3();
			p.X = ( ( n & 1 ) == 1 ) ? b.Max.X : b.Min.X;
			p.Y = ( ( n & 2 ) == 2 ) ? b.Max.Y : b.Min.Y;
			p.Z = ( ( n & 4 ) == 4 ) ? b.Max.Z : b.Min.Z;
			return p;
		}
	}
}