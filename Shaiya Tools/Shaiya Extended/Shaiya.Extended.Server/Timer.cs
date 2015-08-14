using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading;
using Shaiya.Extended.Server.Diagnostics;
using System.IO;

namespace Shaiya.Extended.Server {

	public enum TimerPriority {
		EveryTick,
		TenMS,
		TwentyFiveMS,
		FiftyMS,
		TwoFiftyMS,
		OneSecond,
		FiveSeconds,
		OneMinute
	}

	public delegate void TimerCallback();
	public delegate void TimerStateCallback( object state );
	public delegate void TimerStateCallback<T>( T state );

	public class Timer {
		private DateTime mNext;
		private TimeSpan mDelay;
		private TimeSpan mInterval;
		private bool mRunning;
		private int mIndex, mCount;
		private TimerPriority mPriority;
		private List<Timer> mList;

		private static string FormatDelegate( Delegate callback ) {
			if( callback == null )
				return "null";

			return String.Format( "{0}.{1}", callback.Method.DeclaringType.FullName, callback.Method.Name );
		}

		public static void DumpInfo( TextWriter tw ) {
			TimerThread.DumpInfo( tw );
		}

		public TimerPriority Priority {
			get { return mPriority; }
			set {
				if( mPriority != value ) {
					mPriority = value;

					if( mRunning )
						TimerThread.PriorityChange( this, (int)mPriority );
				}
			}
		}

		public DateTime Next {
			get { return mNext; }
		}

		public TimeSpan Delay {
			get { return mDelay; }
			set { mDelay = value; }
		}

		public TimeSpan Interval {
			get { return mInterval; }
			set { mInterval = value; }
		}

		public bool Running {
			get { return mRunning; }
			set {
				if( value == true ) {
					Start();
				} else {
					Stop();
				}
			}
		}

		public TimerProfile GetProfile() {
			if( !Core.Profiling ) {
				return null;
			}

			string name = ToString();

			if( name == null ) {
				name = "null";
			}

			return TimerProfile.Acquire( name );
		}

		public class TimerThread {
			private static Queue mChangeQueue = Queue.Synchronized( new Queue() );

			private static DateTime[] mNextPriorities = new DateTime[ 8 ];
			private static TimeSpan[] mPriorityDelays = new TimeSpan[ 8 ] {
				TimeSpan.Zero,
				TimeSpan.FromMilliseconds( 10.0 ),
				TimeSpan.FromMilliseconds( 25.0 ),
				TimeSpan.FromMilliseconds( 50.0 ),
				TimeSpan.FromMilliseconds( 250.0 ),
				TimeSpan.FromSeconds( 1.0 ),
				TimeSpan.FromSeconds( 5.0 ),
				TimeSpan.FromMinutes( 1.0 )
			};

			private static List<Timer>[] mTimers = new List<Timer>[ 8 ] {
				new List<Timer>(),
				new List<Timer>(),
				new List<Timer>(),
				new List<Timer>(),
				new List<Timer>(),
				new List<Timer>(),
				new List<Timer>(),
				new List<Timer>(),
			};

			public static void DumpInfo( TextWriter tw ) {
				for( int i = 0; i < 8; ++i ) {
					tw.WriteLine( "Priority: {0}", (TimerPriority)i );
					tw.WriteLine();

					Dictionary<string, List<Timer>> hash = new Dictionary<string, List<Timer>>();

					for( int j = 0; j < mTimers[ i ].Count; ++j ) {
						Timer t = mTimers[ i ][ j ];

						string key = t.ToString();

						List<Timer> list;
						hash.TryGetValue( key, out list );

						if( list == null )
							hash[ key ] = list = new List<Timer>();

						list.Add( t );
					}

					foreach( KeyValuePair<string, List<Timer>> kv in hash ) {
						string key = kv.Key;
						List<Timer> list = kv.Value;

						tw.WriteLine( "Type: {0}; Count: {1}; Percent: {2}%", key, list.Count, (int)( 100 * ( list.Count / (double)mTimers[ i ].Count ) ) );
					}

					tw.WriteLine();
					tw.WriteLine();
				}
			}

			private class TimerChangeEntry {
				public Timer mTimer;
				public int mNewIndex;
				public bool mIsAdd;

				private TimerChangeEntry( Timer t, int newIndex, bool isAdd ) {
					mTimer = t;
					mNewIndex = newIndex;
					mIsAdd = isAdd;
				}

				public void Free() {
					mInstancePool.Enqueue( this );
				}

				private static Queue<TimerChangeEntry> mInstancePool = new Queue<TimerChangeEntry>();

				public static TimerChangeEntry GetInstance( Timer t, int newIndex, bool isAdd ) {
					TimerChangeEntry e;

					if( mInstancePool.Count > 0 ) {
						e = mInstancePool.Dequeue();

						if( e == null )
							e = new TimerChangeEntry( t, newIndex, isAdd );
						else {
							e.mTimer = t;
							e.mNewIndex = newIndex;
							e.mIsAdd = isAdd;
						}
					} else {
						e = new TimerChangeEntry( t, newIndex, isAdd );
					}

					return e;
				}
			}

			public TimerThread() {
			}

			public static void Change( Timer t, int newIndex, bool isAdd ) {
				mChangeQueue.Enqueue( TimerChangeEntry.GetInstance( t, newIndex, isAdd ) );
				mSignal.Set();
			}

			public static void AddTimer( Timer t ) {
				Change( t, (int)t.Priority, true );
			}

			public static void PriorityChange( Timer t, int newPrio ) {
				Change( t, newPrio, false );
			}

			public static void RemoveTimer( Timer t ) {
				Change( t, -1, false );
			}

			private static void ProcessChangeQueue() {
				while( mChangeQueue.Count > 0 ) {
					TimerChangeEntry tce = (TimerChangeEntry)mChangeQueue.Dequeue();
					Timer timer = tce.mTimer;
					int newIndex = tce.mNewIndex;

					if( timer.mList != null )
						timer.mList.Remove( timer );

					if( tce.mIsAdd ) {
						timer.mNext = DateTime.Now + timer.mDelay;
						timer.mIndex = 0;
					}

					if( newIndex >= 0 ) {
						timer.mList = mTimers[ newIndex ];
						timer.mList.Add( timer );
					} else {
						timer.mList = null;
					}

					tce.Free();
				}
			}

			private static AutoResetEvent mSignal = new AutoResetEvent( false );
			public static void Set() {
				mSignal.Set();
			}

			public void TimerMain() {
				DateTime now;
				int i, j;
				bool loaded;

				while( !Core.Closing ) {
					ProcessChangeQueue();

					loaded = false;

					for( i = 0; i < mTimers.Length; i++ ) {
						now = DateTime.Now;
						if( now < mNextPriorities[ i ] )
							break;

						mNextPriorities[ i ] = now + mPriorityDelays[ i ];

						for( j = 0; j < mTimers[ i ].Count; j++ ) {
							Timer t = mTimers[ i ][ j ];

							if( !t.mQueued && now > t.mNext ) {
								t.mQueued = true;

								lock( mQueue )
									mQueue.Enqueue( t );

								loaded = true;

								if( t.mCount != 0 && ( ++t.mIndex >= t.mCount ) ) {
									t.Stop();
								} else {
									t.mNext = now + t.mInterval;
								}
							}
						}
					}

					if( loaded )
						Core.Set();

					mSignal.WaitOne( 10, false );
				}
			}
		}

		private static Queue<Timer> mQueue = new Queue<Timer>();
		private static int mBreakCount = 20000;

		public static int BreakCount {
			get { return mBreakCount; }
			set { mBreakCount = value; }
		}

		private static int mQueueCountAtSlice;

		private bool mQueued;

		public static void Slice() {
			lock( mQueue ) {
				mQueueCountAtSlice = mQueue.Count;

				int index = 0;
				while( index < mBreakCount && mQueue.Count != 0 ) {
					Timer t = mQueue.Dequeue();
					TimerProfile prof = t.GetProfile();
					if( prof != null ) 
						prof.Start();

					t.OnTick();
					t.mQueued = false;
					++index;

					if( prof != null ) 
						prof.Finish();

				}
			}
		}

		public Timer( TimeSpan delay )
			: this( delay, TimeSpan.Zero, 1 ) {
		}

		public Timer( TimeSpan delay, TimeSpan interval )
			: this( delay, interval, 0 ) {
		}

		public virtual bool DefRegCreation {
			get { return true; }
		}

		public virtual void RegCreation() {
			TimerProfile prof = GetProfile();

			if( prof != null )
				prof.Created++;
		}

		public Timer( TimeSpan delay, TimeSpan interval, int count ) {
			mDelay = delay;
			mInterval = interval;
			mCount = count;

			if( DefRegCreation )
				RegCreation();
		}

		public override string ToString() {
			return GetType().FullName;
		}

		public static TimerPriority ComputePriority( TimeSpan ts ) {
			if( ts >= TimeSpan.FromMinutes( 1.0 ) )
				return TimerPriority.FiveSeconds;

			if( ts >= TimeSpan.FromSeconds( 10.0 ) )
				return TimerPriority.OneSecond;

			if( ts >= TimeSpan.FromSeconds( 5.0 ) )
				return TimerPriority.TwoFiftyMS;

			if( ts >= TimeSpan.FromSeconds( 2.5 ) )
				return TimerPriority.FiftyMS;

			if( ts >= TimeSpan.FromSeconds( 1.0 ) )
				return TimerPriority.TwentyFiveMS;

			if( ts >= TimeSpan.FromSeconds( 0.5 ) )
				return TimerPriority.TenMS;

			return TimerPriority.EveryTick;
		}

		#region DelayCall(..)
		public static Timer DelayCall( TimeSpan delay, TimerCallback callback ) {
			return DelayCall( delay, TimeSpan.Zero, 1, callback );
		}

		public static Timer DelayCall( TimeSpan delay, TimeSpan interval, TimerCallback callback ) {
			return DelayCall( delay, interval, 0, callback );
		}

		public static Timer DelayCall( TimeSpan delay, TimeSpan interval, int count, TimerCallback callback ) {
			Timer t = new DelayCallTimer( delay, interval, count, callback );

			if( count == 1 )
				t.Priority = ComputePriority( delay );
			else
				t.Priority = ComputePriority( interval );

			t.Start();

			return t;
		}

		public static Timer DelayCall( TimeSpan delay, TimerStateCallback callback, object state ) {
			return DelayCall( delay, TimeSpan.Zero, 1, callback, state );
		}

		public static Timer DelayCall( TimeSpan delay, TimeSpan interval, TimerStateCallback callback, object state ) {
			return DelayCall( delay, interval, 0, callback, state );
		}

		public static Timer DelayCall( TimeSpan delay, TimeSpan interval, int count, TimerStateCallback callback, object state ) {
			Timer t = new DelayStateCallTimer( delay, interval, count, callback, state );

			if( count == 1 )
				t.Priority = ComputePriority( delay );
			else
				t.Priority = ComputePriority( interval );

			t.Start();

			return t;
		}
		#endregion

		#region DelayCall<T>(..)
		public static Timer DelayCall<T>( TimeSpan delay, TimerStateCallback<T> callback, T state ) {
			return DelayCall( delay, TimeSpan.Zero, 1, callback, state );
		}

		public static Timer DelayCall<T>( TimeSpan delay, TimeSpan interval, TimerStateCallback<T> callback, T state ) {
			return DelayCall( delay, interval, 0, callback, state );
		}

		public static Timer DelayCall<T>( TimeSpan delay, TimeSpan interval, int count, TimerStateCallback<T> callback, T state ) {
			Timer t = new DelayStateCallTimer<T>( delay, interval, count, callback, state );

			if( count == 1 )
				t.Priority = ComputePriority( delay );
			else
				t.Priority = ComputePriority( interval );

			t.Start();

			return t;
		}
		#endregion

		#region DelayCall Timers
		private class DelayCallTimer : Timer {
			private TimerCallback mCallback;

			public TimerCallback Callback {
				get { return mCallback; }
			}

			public override bool DefRegCreation {
				get { return false; }
			}


			public DelayCallTimer( TimeSpan delay, TimeSpan interval, int count, TimerCallback callback )
				: base( delay, interval, count ) {
				mCallback = callback;
				RegCreation();
			}

			protected override void OnTick() {
				if( mCallback != null )
					mCallback();
			}

			public override string ToString() {
				return String.Format( "DelayCallTimer[{0}]", FormatDelegate( mCallback ) );
			}
		}

		private class DelayStateCallTimer : Timer {
			private TimerStateCallback mCallback;
			private object mState;

			public TimerStateCallback Callback {
				get { return mCallback; }
			}

			public override bool DefRegCreation {
				get { return false; }
			}

			public DelayStateCallTimer( TimeSpan delay, TimeSpan interval, int count, TimerStateCallback callback, object state )
				: base( delay, interval, count ) {
				mCallback = callback;
				mState = state;

				RegCreation();
			}

			protected override void OnTick() {
				if( mCallback != null )
					mCallback( mState );
			}

			public override string ToString() {
				return String.Format( "DelayStateCall[{0}]", FormatDelegate( mCallback ) );
			}
		}

		private class DelayStateCallTimer<T> : Timer {
			private TimerStateCallback<T> mCallback;
			private T mState;

			public TimerStateCallback<T> Callback {
				get { return mCallback; }
			}

			public override bool DefRegCreation {
				get { return false; }
			}

			public DelayStateCallTimer( TimeSpan delay, TimeSpan interval, int count, TimerStateCallback<T> callback, T state )
				: base( delay, interval, count ) {
				mCallback = callback;
				mState = state;

				RegCreation();
			}

			protected override void OnTick() {
				if( mCallback != null )
					mCallback( mState );
			}

			public override string ToString() {
				return String.Format( "DelayStateCall[{0}]", FormatDelegate( mCallback ) );
			}
		}
		#endregion

		public void Start() {
			if( mRunning )
				return;

			mRunning = true;
			TimerThread.AddTimer( this );

			TimerProfile prof = GetProfile();
			if( prof != null )
				prof.Started++;
		}

		public void Stop() {
			if( !mRunning )
				return;
			mRunning = false;
			TimerThread.RemoveTimer( this );

			TimerProfile prof = GetProfile();
			if( prof != null ) 
				prof.Stopped++;
		}

		protected virtual void OnTick() {
		}

	}


}
