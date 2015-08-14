using System;
using Microsoft.Xna.Framework;

namespace Puzzle3D {

	public enum ScreenState {
		TransitionOn,
		Active,
		TransitionOff,
		Hidden,
	}

	public abstract class GameScreen {
		bool isPopup = false;
		TimeSpan transitionOnTime = TimeSpan.Zero;
		TimeSpan transitionOffTime = TimeSpan.Zero;
		float transitionPosition = 1;
		ScreenState screenState = ScreenState.TransitionOn;
		bool isExiting = false;
		bool otherScreenHasFocus;
		ScreenManager screenManager;

		public bool IsPopup {
			get { return isPopup; }
			protected set { isPopup = value; }
		}

		public TimeSpan TransitionOnTime {
			get { return transitionOnTime; }
			protected set { transitionOnTime = value; }
		}

		public TimeSpan TransitionOffTime {
			get { return transitionOffTime; }
			protected set { transitionOffTime = value; }
		}

		public float TransitionPosition {
			get { return transitionPosition; }
			protected set { transitionPosition = value; }
		}

		public byte TransitionAlpha {
			get { return (byte)( 255 - TransitionPosition * 255 ); }
		}

		public ScreenState ScreenState {
			get { return screenState; }
			protected set { screenState = value; }
		}

		public bool IsExiting {
			get { return isExiting; }
			protected internal set { isExiting = value; }
		}

		public bool IsActive {
			get { return !otherScreenHasFocus && ( screenState == ScreenState.TransitionOn || screenState == ScreenState.Active ); }
		}

		public ScreenManager ScreenManager {
			get { return screenManager; }
			internal set { screenManager = value; }
		}


		public virtual void LoadContent() { }


		public virtual void UnloadContent() { }


		public virtual void Update( GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen ) {
			this.otherScreenHasFocus = otherScreenHasFocus;

			if( isExiting ) {
				screenState = ScreenState.TransitionOff;
				if( !UpdateTransition( gameTime, transitionOffTime, 1 ) )
					ScreenManager.RemoveScreen( this );
			} else if( coveredByOtherScreen ) {
				if( UpdateTransition( gameTime, transitionOffTime, 1 ) ) {
					screenState = ScreenState.TransitionOff;
				} else {
					screenState = ScreenState.Hidden;
				}
			} else {
				if( UpdateTransition( gameTime, transitionOnTime, -1 ) ) {
					screenState = ScreenState.TransitionOn;
				} else {
					screenState = ScreenState.Active;
				}
			}
		}


		bool UpdateTransition( GameTime gameTime, TimeSpan time, int direction ) {
			float transitionDelta;
			if( time == TimeSpan.Zero )
				transitionDelta = 1;
			else
				transitionDelta = (float)( gameTime.ElapsedGameTime.TotalMilliseconds / time.TotalMilliseconds );

			transitionPosition += transitionDelta * direction;
			if( ( transitionPosition <= 0 ) || ( transitionPosition >= 1 ) ) {
				transitionPosition = MathHelper.Clamp( transitionPosition, 0, 1 );
				return false;
			}

			return true;
		}


		public virtual void HandleInput( InputState input ) { }


		public virtual void Draw( GameTime gameTime ) {
		}


		public void ExitScreen() {
			if( TransitionOffTime == TimeSpan.Zero ) {
				ScreenManager.RemoveScreen( this );
			} else {
				isExiting = true;
			}
		}

	}

}
