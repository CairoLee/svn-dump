#if false
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GodLesZ.Library.Xna.Geometry;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using FreeWorld.Engine;

namespace FreeWorld.Game {

	public class SpriteMap {
		private AnimatedSprite[][] mSpriteMap;

		public SpriteMap( int Width, int Height ) {
			mSpriteMap = new AnimatedSprite[ Width ][];

			for( int x = 0; x < Width; x++ ) {
				mSpriteMap[ x ] = new AnimatedSprite[ Height ];
				for( int y = 0; y < Height; y++ )
					mSpriteMap[ x ][ y ] = null;
			}
		}


		public AnimatedSprite GetSprite( int x, int y ) {
			if( IsValidPoint( x, y ) == false )
				return null;

			return mSpriteMap[ x ][ y ];
		}

		public AnimatedSprite GetSprite( Point2D Cell ) {
			return GetSprite( Cell.X, Cell.Y );
		}

		public void SetSprite( int x, int y, AnimatedSprite Sprite ) {
			if( IsValidPoint( x, y ) == false )
				return;

			mSpriteMap[ x ][ y ] = Sprite;
		}

		public void SetSprite( Point2D Cell, AnimatedSprite Sprite ) {
			SetSprite( Cell.X, Cell.Y, Sprite );
		}



		private bool IsValidPoint( int x, int y ) {
			return ( mSpriteMap == null || x < 0 || x >= mSpriteMap.Length || y < 0 || y >= mSpriteMap[ 0 ].Length ) == false;
		}

		private bool IsValidPoint( Point2D cell ) {
			return IsValidPoint( cell.X, cell.Y );
		}

	}

}
#endif