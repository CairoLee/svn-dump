using System;
using FinalSoftware.Games.Defender.Library.Map;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FinalSoftware.Games.Defender.Library.Units {

	public class UnitWave : IDefenderDraw, IUnitWave {
		protected UnitList mUnits = new UnitList();
		protected UnitList mDeadUnits = new UnitList();

		protected Crossroad mSpawningPoint;
		protected EUnitType mUnitType;
		protected Random mRand = new Random();
		protected int mMaxX, mMaxY, mTile, mToCreate;
		protected float mTimer, mInterval;
		protected bool mFinished;
		protected int mThisWave;

		public UnitList Units {
			get { return mUnits; }
		}

		public bool Finished {
			get { return mFinished; }
		}


		public UnitWave( EUnitType unitType, Crossroad spawn, int numUnits, int tileSize, float interval ) {
			mThisWave = DefenderWorld.Instance.Status.Wave;
			mSpawningPoint = spawn;
			mTile = tileSize;
			mUnitType = unitType;
			mToCreate = numUnits;
			mInterval = interval;

			Initialize();
		}


		public virtual void Initialize() {
			if( mThisWave < 10 )
				mUnitType = EUnitType.Basic;

			mMaxX = mTile;
			mMaxY = mTile;
		}

		public virtual void LoadContent() {
		}


		public virtual void Update( GameTime gameTime ) {
			for( int i = 0; i < mUnits.Count; i++ ) {
				if( mUnits[ i ].Lost ) {
					mUnits.RemoveAt( i );
					i--;
				} else if( mUnits[ i ].Dead ) {
					DefenderWorld.Instance.Status.AddKill( mUnits[ i ].Money );
					mUnits[ i ].Color = new Color( 255, 255, 255, 64 ); // dead color
					mDeadUnits.Add( mUnits[ i ] );
					mUnits.RemoveAt( i );
					i--;
				} else
					mUnits[ i ].Update( gameTime );
			}

			if( mDeadUnits.Count > DefenderWorld.MaxCorpses )
				mDeadUnits.RemoveAt( 0 );

			if( mUnits.Count == 0 && mToCreate == 0 ) {
				mFinished = true;
				return;
			}

			if( mToCreate == 0 )
				return;

			mTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
			if( mTimer <= mInterval )
				return;

			CreateUnit();
			mTimer = 0f;
		}

		public virtual void Draw( GameTime gameTime, SpriteBatch spriteBatch, SpriteBatch additiveBatch ) {
			if( mFinished )
				return;

			mUnits.Draw( gameTime, spriteBatch, additiveBatch );
			if( DefenderWorld.Instance.Status.GraphicsQuality > 0.2 )
				mDeadUnits.Draw( gameTime, spriteBatch, additiveBatch );
		}


		public virtual bool BossesDead() {
			for( int i = 0; i < mUnits.Count; i++ )
				if( ( mUnits[ i ] is UnitBoss ) && mUnits[ i ].Dead == false )
					return false;
			return true;
		}

		public virtual void CreateUnit() {
			DefenderWorld.Instance.SpawnHealth = 100 + ( mThisWave * 10 );
			int value = 1;
			Vector2 offset = new Vector2( mRand.Next( mMaxX ), mRand.Next( mMaxY ) );

			mUnits.Add( new Unit( mSpawningPoint, offset, Vector2.Zero, 0.5f, mSpawningPoint.Tier, DefenderWorld.Instance.texUnit, DefenderWorld.Instance.texUnitDead, value, DefenderWorld.Instance.SpawnHealth ) );
			DefenderWorld.Instance.Status.Created++;
			mToCreate--;
		}

		public virtual void CreateBoss( Crossroad Spawn, Texture2D texUnit, Texture2D texUnitDead ) {
			int hp = mThisWave * 1000;
			int value = mThisWave * 2;
			if( mThisWave >= 50 )
				hp *= ( mThisWave / 25 );
			UnitBoss b = new UnitBoss( Spawn, Vector2.Zero, Vector2.Zero, 0.5f, 1, texUnit, texUnitDead, value, hp );
			mUnits.Add( b );

			DefenderWorld.Instance.Status.Created++;
		}



		#region GetTarget
		public virtual UnitList GetTargets( Vector2 Distance, int Range ) {
			UnitList units = new UnitList();
			for( int i = 0; i < mUnits.Count; i++ ) {
				if( mUnits[ i ].Dead || mUnits[ i ].GetDistance( Distance ) > Range )
					continue;
				units.Add( mUnits[ i ] );
			}

			return units;
		}

		public virtual Unit GetFirstTarget( Vector2 Distance, int Range ) {
			for( int i = 0; i < mUnits.Count; i++ ) {
				if( mUnits[ i ].Dead || mUnits[ i ].GetDistance( Distance ) > Range )
					continue;
				return mUnits[ i ];
			}

			return null;
		}

		public virtual Unit GetRandomTarget( Vector2 Distance, int Range ) {
			UnitList randUnits = new UnitList();
			for( int i = 0; i < mUnits.Count; i++ ) {
				if( mUnits[ i ].Dead || mUnits[ i ].GetDistance( Distance ) > Range )
					continue;
				randUnits.Add( mUnits[ i ] );
			}

			if( randUnits.Count == 0 )
				return null;
			return randUnits[ mRand.Next( randUnits.Count ) ];
		}

		public virtual Unit GetClosestTarget( Vector2 Distance, int Range ) {
			Unit closeUnit = null;
			float closestSoFar = Range;
			float currentRange;

			for( int i = 0; i < mUnits.Count; i++ ) {
				if( mUnits[ i ].Dead || ( currentRange = mUnits[ i ].GetDistance( Distance ) ) > Range || currentRange >= closestSoFar )
					continue;

				closestSoFar = currentRange;
				closeUnit = mUnits[ i ];
			}

			return closeUnit;
		}
		#endregion

	}

}
