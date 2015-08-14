using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Timers;

namespace Ragnarok3D.Editor {
	public class Sun {
		public Vector3 position = Vector3.Zero;
		public Vector3 rotation = Vector3.Zero;
		public Vector3 direction = Vector3.Zero;
		Vector3 targetPos = Vector3.Zero;
		Matrix rotationMatrix = Matrix.Identity;

		float distance = 1000f;
		public Vector3 sunPosition = Vector3.Zero;

		public Vector3[] layerPos;
		SunQuad[] layer;

		public bool bCheckTerrainCollision = false;
		private bool bHasBlockedRay = false;

		public Vector3 color = Vector3.One;

		public double LongitudeSpeed = 0f;
		public double LatitudeSpeed = 0f;

		public double lightPower = 2.2f;

		public Sun() {
			InitLayers();
			Editor.console.Add( "Sun Initialized" );
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sAngle">View Angle in Degrees</param>
		/// <param name="sElevation">Elevation in Degrees</param>
		public Sun( double sAngle, double sElevation ) {
			InitLayers();
			rotation.X = MathHelper.ToRadians( (float)sElevation );
			rotation.Y = MathHelper.ToRadians( (float)sAngle );
			rotation.X %= MathHelper.ToRadians( 360f );
			rotation.Y %= MathHelper.ToRadians( 360f );
			Editor.console.Add( "Sun Initialized" );
		}

		private void InitLayers() {
			layer = new SunQuad[ 4 ];
			layerPos = new Vector3[ 4 ];

			layer[ 0 ] = new SunQuad( new Vector2( 10f, 10f ), "lens04", 120f );
			layer[ 1 ] = new SunQuad( new Vector2( 12f, 12f ), "lens03", 12f );
			layer[ 2 ] = new SunQuad( new Vector2( 10f, 10f ), "lens02", 30f );
			layer[ 3 ] = new SunQuad( new Vector2( 15f, 15f ), "lens01", 15f );
		}

		public void Update() {
			//Angle
			rotation.Y += (float)LongitudeSpeed;

			//Elevation
			rotation.X -= (float)LatitudeSpeed;

			//rotation.X %= MathHelper.ToRadians(360f);
			//rotation.Y %= MathHelper.ToRadians(360f);

			position = Editor.camera.position;

			//Same code as the camera
			rotationMatrix = Matrix.CreateRotationX( rotation.X ) * Matrix.CreateRotationY( rotation.Y );
			targetPos = position + Vector3.Transform( new Vector3( 0, 0, 1 ), rotationMatrix );
			Vector3 upVector = Vector3.Transform( new Vector3( 0, 1, 0 ), rotationMatrix );
			direction = Vector3.Normalize( targetPos - position );

			if( Editor.heightmap != null )
				sunPosition = Editor.heightmap.center + direction * distance;
			else
				sunPosition = position + direction * distance;

			UpdateLayers();
		}

		private void UpdateLayers() {
			layerPos[ 0 ] = direction * distance + position;
			layerPos[ 3 ] = direction * distance / 1.4f + position + Editor.camera.direction * distance * 0.4f;
			layerPos[ 2 ] = direction * distance / 2f + position + Editor.camera.direction * distance * 0.6f;
			layerPos[ 1 ] = direction * distance / 4f + position + Editor.camera.direction * distance * 1f;

			float dotProduct = Vector3.Dot( direction, Vector3.Normalize( position - Editor.camera.targetPos ) ) * 50f;
			Vector3 crossProduct = Vector3.Cross( direction, Vector3.Normalize( position - Editor.camera.targetPos ) );

			layer[ 0 ].glowFactor = 1.0f * ( 0.5f - crossProduct.Length() );
			layer[ 0 ].Update( layerPos[ 0 ], position );
			layer[ 1 ].Update( layerPos[ 1 ], position );
			layer[ 2 ].Update( layerPos[ 2 ], position );
			layer[ 3 ].Update( layerPos[ 3 ], position );

			if( bCheckTerrainCollision ) {
				if( Editor.heightmap != null )
					CheckTerrainRay();

				UpdateVisibility();
			}
		}

		//Brute force method
		private void CheckTerrainRay() {
			Ray sunSay = new Ray( Editor.camera.position, direction );
			bHasBlockedRay = false;

			if( Editor.heightmap != null && Editor.heightmap.triangle != null && Editor.heightmap.triangle.Length > 0 ) {
				for( int i = 0; i < Editor.heightmap.triangle.Length; i++ ) {
					Heightmap.Tri triangle = Editor.heightmap.triangle[ i ];
					float rayLength = 0f;
					if( MathExtra.Intersects( sunSay, triangle.p1, triangle.p2, triangle.p3, triangle.normal, true, true, out rayLength ) ) {
						bHasBlockedRay = true;
						break;
					}
				}
			}
		}

		private void UpdateVisibility() {
			for( int i = 0; i < layer.Length; i++ ) {
				if( bHasBlockedRay )
					layer[ i ].bVisible = false;
				else
					layer[ i ].bVisible = true;
			}
		}

		public void Draw( Matrix view, Matrix projection ) {
			float dotProduct = Vector3.Dot( direction, Vector3.Normalize( Editor.camera.position - Editor.camera.targetPos ) );

			if( layer[ 0 ].alpha != 0f )
				layer[ 0 ].Draw( view, projection );

			if( layer[ 0 ].alpha > 0.7f && dotProduct < -0.8f ) {
				for( int i = 1; i < layer.Length; i++ )
					if( layer[ i ] != null )
						layer[ i ].Draw( view, projection );
			}
		}
	}
}
