using Microsoft.Xna.Framework;

namespace GodLesZ.Library.MonoGame {

	/// <summary>
	/// Represents a simple timer
	/// </summary>
	public class SimpleTimer {

		public delegate void OnSecondTickHandler(SimpleTimer timer);

		private float mTimer;
		private float mTickOnSecondTimer;

		public float Interval {
			get;
			set;
		}

		public bool ManualReset {
			get;
			set;
		}

		public bool IsActive {
			get;
			set;
		}

		public bool TickOnSecond {
			get;
			set;
		}

		public float Value {
			get { return mTimer; }
		}

		public event OnSecondTickHandler OnSecondTick;


		public SimpleTimer(float intervalInSeconds)
			: this(intervalInSeconds, false) {
		}

		public SimpleTimer(float intervalInSeconds, bool manualReset) {
			Interval = intervalInSeconds;
			ManualReset = manualReset;

			IsActive = true;
			TickOnSecond = false;

			Reset();
		}


		/// <summary>
		/// Updates the elpased time using gameTime.ElapsedGameTime.TotalSeconds
		/// </summary>
		/// <param name="gameTime"></param>
		/// <returns>True, if Interval has been reached</returns>
		public bool Update(GameTime gameTime) {
			if (IsActive == false) {
				return false;
			}

			mTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
			// Only if we need a tick per second
			if (TickOnSecond) {
				mTickOnSecondTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

				if (mTickOnSecondTimer >= 1) {
					mTickOnSecondTimer = 0;
					if (OnSecondTick != null) {
						OnSecondTick(this);
					}
				}
			}

			if (mTimer >= Interval) {
				if (ManualReset == false) {
					mTimer -= Interval;
				}
				return true;
			}

			return false;
		}

		/// <summary>
		/// Sets the elapsed time to 0
		/// </summary>
		public void Reset() {
			Subtract(mTimer);
		}

		/// <summary>
		/// Subtracts the Interval time from the elapsed time.
		/// </summary>
		public void Subtract() {
			Subtract(Interval);
		}

		/// <summary>
		/// Subtracts the value from the elapsed time.
		/// </summary>
		public void Subtract(float interval) {
			if (IsActive == false) {
				return;
			}

			mTimer -= interval;
			mTickOnSecondTimer = MathHelper.Max(0, mTickOnSecondTimer - interval);
		}

	}

}
