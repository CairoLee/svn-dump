using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Shaiya.Extended.Library.Utility.Other {

	public class GameClock {
		private Stopwatch mWatch;
		private TimeSpan mElapsedGameTime;

		public TimeSpan ElapsedGameTime {
			get { return mElapsedGameTime; }
		}


		public GameClock() {
			mWatch = new Stopwatch();
			mElapsedGameTime = TimeSpan.Zero;
		}


		public static GameClock StartNew() {
			GameClock clock = new GameClock();
			clock.Start();
			return clock;
		}


		public void Start() {
			Start( false );
		}

		public void Start( bool Reset ) {
			if( Reset )
				this.Reset();
			mWatch.Start();
		}

		public void Stop() {
			mWatch.Stop();
			mElapsedGameTime = mWatch.Elapsed;
		}

		public void Reset() {
			mElapsedGameTime = TimeSpan.Zero;
			mWatch.Reset();
		}

	}

}
