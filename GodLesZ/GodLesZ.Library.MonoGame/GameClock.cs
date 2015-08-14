using System;
using System.Diagnostics;

namespace GodLesZ.Library.MonoGame {

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


		public void Start() {
			mWatch.Start();
		}

		public void Stop() {
			mWatch.Stop();

			mElapsedGameTime = mWatch.Elapsed;

			mWatch.Reset();
		}

	}

}
