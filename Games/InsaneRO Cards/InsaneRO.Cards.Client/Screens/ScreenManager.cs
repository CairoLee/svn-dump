using System;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using InsaneRO.Cards.Client.Compontents;
using WindowLibrary.Controls;

namespace InsaneRO.Cards.Client.Screens {

	public class ScreenManager : DrawableGameComponent {
		private Dictionary<string, GameScreen> mScreens = new Dictionary<string, GameScreen>();
		private List<GameScreen> mScreensToAdd = new List<GameScreen>();
		private List<GameScreen> mScreensToRemove = new List<GameScreen>();

		private bool mIsInitialized;

		private SpriteBatch mSpriteBatch;
		private SpriteFont mFont;
		private InputHelper mInput;
		private Manager mWindowManager;
		private Window mMainWindow;

		private GameClient mGameInstance;

		public SpriteBatch SpriteBatch {
			get { return mSpriteBatch; }
		}

		public SpriteFont Font {
			get { return mFont; }
		}

		public InputHelper Input {
			get { return mInput; }
		}

		public Manager WindowManager {
			get { return mWindowManager; }
		}

		public Window MainWindow {
			get { return mMainWindow; }
			set { mMainWindow = value; }
		}


		public Dictionary<string, GameScreen>.ValueCollection Screens {
			get { return mScreens.Values; }
		}

		public GameScreen this[ string Name ] {
			get {
				if( mScreens.ContainsKey( Name ) == false )
					return null;
				return mScreens[ Name ];
			}
		}



		public ScreenManager( GameClient game, bool debugPos )
			: base( game ) {
			mGameInstance = game;
			mInput = new InputHelper( game );
			mInput.DebugPosition = debugPos;
		}

		public override void Initialize() {
			mWindowManager = new Manager( mGameInstance as Game, GameClient.GraphicsManager, "Default", false );
			mWindowManager.SkinDirectory = mGameInstance.Content.RootDirectory + @"\Skins\";
			mWindowManager.Initialize();
			mWindowManager.AutoUnfocus = false;

			lock( mScreens ) {
				foreach( GameScreen screen in mScreens.Values ) {
					screen.Initialize();
				}
			}

			mInput.Initialize();
			base.Initialize();
			mIsInitialized = true;
		}


		protected override void LoadContent() {
			mSpriteBatch = new SpriteBatch( GraphicsDevice );
			mFont = Game.Content.Load<SpriteFont>( @"Fonts\Tahoma" );


			lock( mScreens ) {
				foreach( GameScreen screen in mScreens.Values ) {
					screen.LoadContent();
				}
			}
		}


		protected override void UnloadContent() {
			lock( mScreens ) {
				foreach( GameScreen screen in mScreens.Values ) {
					screen.UnloadContent();
				}
			}

			mWindowManager.Dispose();
		}


		public override void Update( GameTime gameTime ) {
			bool inputHandled = false;
			bool activeFound = false;

			mWindowManager.Update( gameTime );
			mInput.Update( gameTime );

			lock( mScreens ) {
				foreach( GameScreen screen in mScreensToAdd )
					mScreens.Add( screen.Name, screen );
				foreach( GameScreen screen in mScreensToRemove )
					RemoveScreen( screen );

				mScreensToAdd.Clear();
				mScreensToRemove.Clear();

				foreach( GameScreen screen in mScreens.Values ) {
					if( screen.IsExiting == true ) {
						mScreensToRemove.Add( screen );
						continue;
					}

					// ever found a actve Screen?
					if( activeFound == false && screen.ScreenState == EScreenState.Active )
						activeFound = true;
					else if( activeFound == true )
						// active found some turns before - hide this
						screen.ScreenState = EScreenState.Hidden;

					screen.Update( gameTime );

					if( screen.ScreenState == EScreenState.Active && screen.InputHandle == true && inputHandled == false ) {
						screen.HandleInput( mInput, gameTime );
						inputHandled = true;
					}
				}

				foreach( GameScreen screen in mScreensToRemove )
					RemoveScreen( screen );
				mScreensToRemove.Clear();

			}

		}


		/// <summary>
		/// tell each Screen to Draw itself
		/// </summary>
		/// <param name="gameTime"></param>
		public override void Draw( GameTime gameTime ) {
			Game.GraphicsDevice.Clear( Color.Black );

			mWindowManager.Draw( gameTime );
			mInput.Draw( gameTime );

			lock( mScreens ) {
				foreach( GameScreen screen in mScreens.Values ) {
					if( screen.ScreenState == EScreenState.Hidden )
						continue;

					screen.Draw( gameTime );
				}
			}
		}

		/// <summary>
		/// Adds a new Screen to the List
		/// </summary>
		/// <param name="screen"></param>
		public void AddScreen( GameScreen screen ) {
			AddScreen( screen, null );
		}

		/// <summary>
		/// Adds a new Screen to the List
		/// </summary>
		/// <param name="screen"></param>
		/// <param name="CloseMe"></param>
		public GameScreen AddScreen( GameScreen screen, GameScreen CloseMe ) {
			if( CloseMe != null )
				CloseMe.ExitScreen();

			screen.ScreenManager = this;
			screen.IsExiting = false;
			screen.ScreenState = EScreenState.Hidden;
			screen.Game = mGameInstance;
			if( screen.Name == string.Empty )
				screen.Name = "SCREEN" + mScreens.Count;

			if( mIsInitialized == true )
				screen.LoadContent();

			lock( mScreens ) {
				mScreensToAdd.Add( screen );
			}

			return screen;
		}

		/// <summary>
		/// Removes a Screen from the List
		/// </summary>
		/// <param name="screen"></param>
		public void RemoveScreen( GameScreen screen ) {
			if( mIsInitialized == true )
				screen.UnloadContent();

			lock( mScreens ) {
				mScreens.Remove( screen.Name );
			}
		}

	}

}
