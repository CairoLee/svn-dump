using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace OverlayLib {

	public class OverlayRender : IDisposable {
		private Overlay mOverlay;
		private Timer mRenderTimer;
		private Point mPosition;
		private Size mSize;
		private int mTimerTick = 1000;

		public Overlay Overlay {
			get {
				if( mOverlay == null )
					Initialize();
				return mOverlay;
			}
		}

		public Point Position {
			get { return mPosition; }
			set {
				mPosition = value;
				Update();
			}
		}

		public Size Size {
			get { return mSize; }
			set {
				mSize = value;
				Update();
			}
		}

		public Rectangle Boundings {
			get {
				if( mOverlay == null )
					Initialize();
				return mOverlay.Boundings;
			}
		}

		public Bitmap RenderTarget {
			get { return mOverlay.RenderTarget; }
		}

		public RenderDelegate OnRender;
		public EventHandler TimerTick;


		public OverlayRender( Point Pos, Size size, int TimerTick ) {
			mPosition = Pos;
			mSize = size;
			mTimerTick = TimerTick;
			Initialize();
		}


		public void Initialize() {
			try {
				if( mOverlay == null )
					mOverlay = new Overlay();
				mOverlay.Position = mPosition;
				mOverlay.Size = mSize;
				mOverlay.Renderer = OnRenderHandler;
				if( mOverlay != null && mOverlay.Initialized == false )
					mOverlay.Initialise();

				InitializeTimer();
			} catch {
				// init Timer, so initialize will be called again
				InitializeTimer();
			}

		}

		public void Update() {
			try {
				if( mOverlay == null )
					Initialize();
				mOverlay.Position = mPosition;
				mOverlay.Size = mSize;
				mOverlay.Renderer = OnRenderHandler;
			} catch { }
		}

		private void InitializeTimer() {
			if( mRenderTimer != null )
				mRenderTimer.Stop();

			mRenderTimer = new Timer();
			mRenderTimer.Tick += TimerTickHandler;
			mRenderTimer.Interval = mTimerTick;
			mRenderTimer.Start();
		}





		private void TimerTickHandler( object sender, EventArgs args ) {
			try {
				if( TimerTick != null )
					TimerTick( null, EventArgs.Empty );

				if( mOverlay.Position != mPosition )
					mOverlay.Position = mPosition;
				if( mOverlay.Size != mSize )
					mOverlay.Size = mSize;

				if( mOverlay.Update() == false )
					throw new Exception(); // fall to catch{ } & Initialize()
			} catch {
				// error in Surface? try re-initialize
				Initialize();
			}
		}

		private void OnRenderHandler( Graphics g ) {

			try {
				//g.Clear( Color.Transparent );

				if( OnRender != null )
					OnRender( g );

			} catch {
				// error in Surface? try re-initialize
				Initialize();
			}
		}



		#region IDisposable Member
		public void Dispose() {
			try {
				if( mRenderTimer != null ) {
					mRenderTimer.Stop();
					mRenderTimer.Dispose();
					mRenderTimer = null;
				}
				if( mOverlay != null ) {
					mOverlay.Dispose();
					mOverlay = null;
				}
			} catch { }
		}

		void IDisposable.Dispose() {
			this.Dispose();
		}
		#endregion

	}

}
