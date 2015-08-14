using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace FinalSoftware.Games.Defender.Library {

	public class DefenderStatus {
		private int mHealth, mSurvived;
		private float mTime;
		private bool mSunrise, mLost;

		public int Health {
			get { return mHealth; }
			set {
				mHealth = value;
				if( mHealth <= 0 )
					mLost = true;
			}
		}

		public int Kills {
			get;
			private set;
		}

		public int Survived {
			get { return mSurvived; }
			set {
				mSurvived = value;
				if( mSurvived >= Health )
					Lost = true;
			}
		}

		public float GraphicsQuality {
			get;
			set;
		}

		public float Time {
			get { return mTime; }
			set {
				if( mTime >= 180.0f || mTime <= 0.0f )
					mSunrise = !mSunrise;

				if( mSunrise )
					mTime += value;
				else
					mTime -= value;
			}
		}

		public float MoneyTime {
			get;
			set;
		}

		public int Wave {
			get;
			set;
		}

		public int Stage {
			get;
			set;
		}

		public int Money {
			get;
			set;
		}

		public bool Sound {
			get;
			set;
		}

		public int Created {
			get;
			set;
		}

		public bool Lost {
			get { return mLost; }
			set { mLost = value; }
		}


		public DefenderStatus() {
			mHealth = 20;
			Kills = 0;
			Money = 200;
			mTime = 0;
			MoneyTime = 0;
			mSurvived = 0;
			Wave = 0;
			Stage = 1;
			GraphicsQuality = 1.0f;

			mLost = false;
			mSunrise = false;
			Sound = true;
		}


		public virtual void AddKill( int value ) {
			Kills += 1;
			Money += value;
		}

		public virtual void Update( GameTime gameTime, DefenderWorld world ) {
			if( world.StartWaves == false ) // not yet started
				return;

			MoneyTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
			if( MoneyTime < 3000 )
				return;
			MoneyTime -= 3000;
			Money += 1;
		}

	}

}
