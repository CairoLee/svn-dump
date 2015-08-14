using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace FinalSoftware.Games.Defender.Library.Map {

	public class Paths : List<Path> {

		public Paths()
			: base() {
		}

		public Paths( int capacity )
			: base( capacity ) {
		}


		public void CalculatePaths( CrossroadList sourceXRS ) {
			Vector2 origin;
			Vector2 target;
			Vector2 difference;
			CrossroadList targetXRS;

			float angle;
			int height;
			int distance;
			int quadrant;

			float lBound = 0, rBound = 0, tBound1 = 0, bBound1 = 0, vHeight = 0;
			for( int i = 0; i < sourceXRS.Count; i++ ) {
				targetXRS = sourceXRS[ i ].Connections;
				for( int j = 0; j < sourceXRS[ i ].Connections.Count; j++ ) {
					origin = sourceXRS[ i ].Position;
					target = targetXRS[ j ].Position;
					difference = target - origin;

					if( target.X < origin.X ) {
						angle = (float)( Math.Atan( difference.Y / difference.X ) + Math.PI );
					} else {
						angle = (float)( Math.Atan( difference.Y / difference.X ) );
					}

					height = (int)( DefenderWorld.TileSize + ( DefenderWorld.TileSize / Math.Sin( Math.PI / 4 ) - DefenderWorld.TileSize ) * Math.Abs( Math.Sin( angle * 2 ) ) );
					vHeight = 0;

					distance = (int)Math.Sqrt( Math.Pow( (double)( target.X - origin.X ), 2 ) + Math.Pow( (double)( target.Y - origin.Y ), 2 ) );

					if( difference.X > 0 && difference.Y < 0 ) {
						lBound = origin.X;
						rBound = target.X + DefenderWorld.TileSize;
						bBound1 = origin.Y + DefenderWorld.TileSize;
						tBound1 = target.Y;
						vHeight = (float)( height / Math.Sin( MathHelper.PiOver2 - angle ) );

						quadrant = 1;
					} else if( difference.X < 0 && difference.Y < 0 ) {

						origin.Y += DefenderWorld.TileSize;
						target.Y += DefenderWorld.TileSize;

						lBound = target.X;
						rBound = origin.X + DefenderWorld.TileSize;
						tBound1 = target.Y - DefenderWorld.TileSize;
						bBound1 = origin.Y;
						vHeight = (float)( height / Math.Sin( MathHelper.PiOver2 - angle ) );

						quadrant = 2;
					} else if( difference.X < 0 && difference.Y > 0 ) {

						origin.Y += DefenderWorld.TileSize;
						origin.X += DefenderWorld.TileSize;
						target.Y += DefenderWorld.TileSize;
						target.X += DefenderWorld.TileSize;

						lBound = target.X - DefenderWorld.TileSize;
						rBound = origin.X;
						tBound1 = origin.Y - DefenderWorld.TileSize;
						bBound1 = target.Y;
						vHeight = (float)( height / Math.Sin( angle ) );

						quadrant = 3;
					} else if( difference.X > 0 && difference.Y > 0 ) {

						origin.X += DefenderWorld.TileSize;
						target.X += DefenderWorld.TileSize;

						lBound = origin.X - DefenderWorld.TileSize;
						rBound = target.X;
						bBound1 = target.Y + DefenderWorld.TileSize;
						tBound1 = origin.Y;
						vHeight = (float)( height / Math.Sin( angle ) );

						quadrant = 4;
					} else if( difference.X == 0 && difference.Y < 0 ) {
						origin.Y += DefenderWorld.TileSize;
						target.Y += DefenderWorld.TileSize;

						lBound = origin.X;
						rBound = origin.X + DefenderWorld.TileSize;
						bBound1 = origin.Y;
						tBound1 = target.Y - DefenderWorld.TileSize;

						quadrant = 5;
					} else if( difference.X < 0 && difference.Y == 0 ) {
						origin.X += DefenderWorld.TileSize;
						origin.Y += DefenderWorld.TileSize;
						target.X += DefenderWorld.TileSize;
						target.Y += DefenderWorld.TileSize;

						lBound = target.X - DefenderWorld.TileSize;
						rBound = origin.X;
						bBound1 = origin.Y;
						tBound1 = target.Y - DefenderWorld.TileSize;

						quadrant = 6;
					} else if( difference.X == 0 && difference.Y > 0 ) {
						origin.X += DefenderWorld.TileSize;
						target.X += DefenderWorld.TileSize;

						lBound = origin.X - DefenderWorld.TileSize;
						rBound = origin.X;
						bBound1 = target.Y + DefenderWorld.TileSize;
						tBound1 = origin.Y;

						quadrant = 7;
					} else {
						lBound = origin.X;
						rBound = target.X + DefenderWorld.TileSize;
						bBound1 = origin.Y + DefenderWorld.TileSize;
						tBound1 = origin.Y;

						quadrant = 8;
					}

					Add( new Path( (int)origin.X, (int)origin.Y, distance, height, angle, quadrant, lBound, rBound, bBound1, tBound1, vHeight, DefenderWorld.TileSize ) );
				}
			}
		}

	}

}
