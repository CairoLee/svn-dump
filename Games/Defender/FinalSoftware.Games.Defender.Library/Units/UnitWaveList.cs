using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalSoftware.Games.Defender.Library.Units {

	public class UnitWaveList : List<UnitWave>, IDefenderDraw, IUnitWave {
		protected Random mRand = new Random();


		public virtual void Initialize() {
			for( int i = 0; i < Count; i++ )
				this[ i ].Initialize();
		}

		public virtual void LoadContent() {
			for( int i = 0; i < Count; i++ )
				this[ i ].LoadContent();
		}


		public virtual void Update( GameTime gameTime ) {
			for( int i = 0; i < Count; i++ )
				this[ i ].Update( gameTime );
		}

		public virtual void Draw( GameTime gameTime, SpriteBatch spriteBatch, SpriteBatch additiveBatch ) {
			for( int i = 0; i < Count; i++ )
				this[ i ].Draw( gameTime, spriteBatch, additiveBatch );
		}


		public virtual UnitList GetUnits() {
			UnitList list = new UnitList();
			for( int i = 0; i < Count; i++ )
				list.AddRange( this[ i ].Units );
			return list;
		}

		#region GetTarget
		public virtual UnitList GetTargets( Vector2 Distance, int Range ) {
			UnitList units = new UnitList();
			for( int i = 0; i < Count; i++ )
				units.AddRange( this[ i ].GetTargets( Distance, Range ) );
			return units;
		}

		public Unit GetFirstTarget( Vector2 Distance, int Range ) {
			Unit u;
			for( int i = 0; i < Count; i++ ) {
				if( ( u = this[ i ].GetFirstTarget( Distance, Range ) ) != null )
					return u;
			}
			return null;
		}

		public Unit GetRandomTarget( Vector2 Distance, int Range ) {
			UnitList units = GetTargets( Distance, Range );
			if( units.Count == 0 )
				return null;
			return units[ mRand.Next( units.Count ) ];
		}

		public Unit GetClosestTarget( Vector2 Distance, int Range ) {
			Unit u;
			UnitList units = new UnitList();
			for( int i = 0; i < Count; i++ ) {
				if( ( u = this[ i ].GetClosestTarget( Distance, Range ) ) != null )
					units.Add( u );
			}

			if( units.Count == 0 )
				return null;

			float closestSoFar = Range;
			float currentRange = units[ 0 ].GetDistance( Distance );
			u = units[ 0 ];

			for( int i = 0; i < units.Count; i++ ) {
				if( currentRange >= closestSoFar )
					continue;

				closestSoFar = currentRange;
				u = units[ i ];
			}

			return u;
		}
		#endregion

	}

}
