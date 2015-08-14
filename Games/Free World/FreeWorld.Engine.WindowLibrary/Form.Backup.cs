using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

using FreeWorld.Engine;

namespace FreeWorld.Engine.WindowLibrary {

	public delegate void Form_OnResizedHandler( FormResizedEventsArgs e );

	[Serializable]
	public class Form {
		private bool mCanResize = false;

		private bool mDragging = false;
		private bool mResizing = false;
		private bool mCanLostFocus = true;
		private bool mModifyAlpha = true;

		private int mDrawOrder = 0;

		private Rectangle[] mDestinationRect;

		private Vector2 mFormPosPrev = Vector2.Zero;
		private Vector2 mFormSizePrev = new Vector2( 100f, 100f );
		private Vector2 startDragPos = Vector2.Zero;
		private Vector2 startResizePos = Vector2.Zero;

		private Vector2 mScreenSize = Vector2.Zero;

		private float mAlphaSpeed = 0.05f;
		private float mFormAlpha = 1f;
		private float mAlpha = 0f;
		private EFormState mFormStatePrev = EFormState.Restored;
		private EFormProcState mFormProcState = EFormProcState.Closed;

		private MouseState mMouseState;
		private Vector2 mMousePos = Vector2.Zero;
		private KeyboardState mKeyboardState;

		private ControlCollection mControls = new ControlCollection();

		private ButtonSimple mBtnClose;
		private ButtonSimple mBtnMini;
		private ButtonSimple mBtnMaxi;
		private ButtonSimple mBtnRestore;

		private Vector2 mBtnClosePos;
		private Vector2 mBtnMiniPos;
		private Vector2 mBtnMaxiPos;
		private Vector2 mBtnRestorePos;

		private bool mCanClose = true;
		private bool mCanDrag = true;
		private bool mCanMini = false;
		private bool mCanMaxi = false;
		private bool mVisible = false;

		private bool mHideTitle = false;

		private Vector2 mFormPos = Vector2.Zero;
		private Vector2 mFormTitlePos = new Vector2( 10f, 10f );
		private Vector2 mFormSize = new Vector2( 100f, 100f );
		private Vector2 mFormSizeMin = Vector2.Zero;

		private Texture2D[] mFormTexture;
		private string[] mFormTextureName;

		private bool mCanSnap = true;
		private int mSnapSize = 20;
		private float mAlphaDef = 1f;


		private SpriteFont mFormFont;
		private string mFormTitle;
		private Color mColBackground;
		private Color mColForeground;

		private EFormState mFormState = EFormState.Restored;

		private SFormStyle mFormStyle = new SFormStyle();
		private bool mFocused = false;

		private static bool mIsInUse = false;
		private static int mCurrentDrawOrder = 0;
		private static int[] mMinimizeSpot = new int[ 10 ];
		private int Spot = 0;

		private static Form mTopForm;

		private FormCollection mOwner;

		private int mTabIndex = 0;
		private Vector2 previousDragPos = Vector2.Zero;
		private int previousIndex;


		public event EventHandler OnMouseClick;
		public event Form_OnResizedHandler OnResized;


		public Control this[ string Key ] {
			get { return mControls[ Key ]; }
		}

		public ControlCollection Controls {
			get { return mControls; }
			set { mControls = value; }
		}

		public ButtonSimple BtnClose {
			get { return mBtnClose; }
			set { mBtnClose = value; }
		}
		public ButtonSimple BtnMini {
			get { return mBtnMini; }
			set { mBtnMini = value; }
		}
		public ButtonSimple BtnMaxi {
			get { return mBtnMaxi; }
			set { mBtnMaxi = value; }
		}
		public ButtonSimple BtnRestore {
			get { return mBtnRestore; }
			set { mBtnRestore = value; }
		}

		public Vector2 BtnClosePos {
			get { return mBtnClosePos; }
			set { mBtnClosePos = value; }
		}
		public Vector2 BtnMiniPos {
			get { return mBtnMiniPos; }
			set { mBtnMiniPos = value; }
		}
		public Vector2 BtnMaxiPos {
			get { return mBtnMaxiPos; }
			set { mBtnMaxiPos = value; }
		}
		public Vector2 BtnRestorePos {
			get { return mBtnRestorePos; }
			set { mBtnRestorePos = value; }
		}

		public bool CanClose {
			get { return mCanClose; }
			set { mCanClose = value; }
		}
		public bool CanDrag {
			get { return mCanDrag; }
			set { mCanDrag = value; }
		}
		public bool CanMini {
			get { return mCanMini; }
			set { mCanMini = value; }
		}
		public bool CanMaxi {
			get { return mCanMaxi; }
			set { mCanMaxi = value; }
		}
		public bool CanResize {
			set {
				mCanResize = value;
				if( FormTexture != null && FormTextureName != null ) {
					FormTextureName[ 8 ] = @"Interface\" + FormStyle + @"\Form\form_bottomright" + ( mCanResize ? "_resize" : "" ) + "";
					FormTexture[ 8 ] = EngineCore.ContentLoader.Load<Texture2D>( FormTextureName[ 8 ] );
				}
			}
			get { return mCanResize; }
		}
		public bool ModifyAlpha {
			get { return mModifyAlpha; }
			set { mModifyAlpha = value; }
		}


		public bool HideTitle {
			get { return mHideTitle; }
			set { mHideTitle = value; }
		}

		public Vector2 FormPos {
			get { return mFormPos; }
			set { mFormPos = value; }
		}
		public Vector2 FormTitlePos {
			get { return mFormTitlePos; }
			set { mFormTitlePos = value; }
		}
		public Vector2 FormSize {
			get { return mFormSize; }
			set { mFormSize = value; }
		}
		public Vector2 FormSizeMin {
			get { return mFormSizeMin; }
			set { mFormSizeMin = value; }
		}


		public bool CanSnap {
			get { return mCanSnap; }
			set { mCanSnap = value; }
		}
		public int SnapSize {
			get { return mSnapSize; }
			set { mSnapSize = value; }
		}
		public float AlphaDef {
			get { return mAlphaDef; }
			set { mAlphaDef = value; }
		}
		public bool CanLostFocus {
			get { return mCanLostFocus; }
			set { mCanLostFocus = value; }
		}


		public string FormTitle {
			get { return mFormTitle; }
			set { mFormTitle = value; }
		}
		[XmlElement( Namespace = "Microsoft.Xna.Framework.Graphics" )]
		public Color ColorBackground {
			get { return mColBackground; }
			set { mColBackground = value; }
		}
		[XmlElement( Namespace = "Microsoft.Xna.Framework.Graphics" )]
		public Color ColorForeground {
			get { return mColForeground; }
			set { mColForeground = value; }
		}


		public SFormStyle FormStyle {
			get { return mFormStyle; }
			set { mFormStyle = value; }
		}

		public string[] FormTextureName {
			get { return mFormTextureName; }
			set { mFormTextureName = value; }
		}

		public int DrawOrder {
			set { mDrawOrder = value; }
			get { return mDrawOrder; }
		}

		public bool bTabDown = false;






		[XmlIgnore]
		public Texture2D[] FormTexture {
			get { return mFormTexture; }
			set { mFormTexture = value; }
		}
		[XmlIgnore]
		public SpriteFont FormFont {
			get { return mFormFont; }
			set { mFormFont = value; }
		}
		[XmlIgnore]
		public FormCollection Owner {
			get { return mOwner; }
			set { mOwner = value; }
		}
		[XmlIgnore]
		public static Form TopForm {
			get { return mTopForm; }
			set { mTopForm = value; }
		}
		[XmlIgnore]
		public static bool InUse {
			get { return mIsInUse; }
			set { mIsInUse = value; }
		}
		[XmlIgnore]
		public bool Focused {
			get { return mFocused; }
			set { mFocused = value; }
		}
		[XmlIgnore]
		public EFormState FormState {
			get { return mFormState; }
			set { mFormState = value; }
		}
		[XmlIgnore]
		public bool Visible {
			get { return mVisible; }
			set { mVisible = value; }
		}
		[XmlIgnore]
		public static int CurrentDrawOrder {
			get { return mCurrentDrawOrder; }
			set { mCurrentDrawOrder = value; }
		}
		[XmlIgnore]
		public static int[] MinimizeSpot {
			get { return mMinimizeSpot; }
			set { mMinimizeSpot = value; }
		}
		[XmlIgnore]
		public int TabIndex {
			get { return mTabIndex; }
			set { mTabIndex = value; }
		}


		private void form_onMouseClick( Object obj, EventArgs e ) {
			SetFocus();
		}

		private void form_onResized( FormResizedEventsArgs e ) {
		}







		public Form() {
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="WndPos">Window Position (Vector2.zero for Center)</param>
		/// <param name="WndSize">Window Size</param>
		/// <param name="WndTitle">Title Name</param>
		/// <param name="ManualInit">Initialize manual?</param>
		/// <param name="ColBg">Background Color</param>
		/// <param name="ColFg">Foreground Color</param>
		/// <param name="WndFont">Window Font for Title Name</param>
		/// <param name="WndStyle">Window Style</param>
		public Form( Vector2 WndPos, Vector2 WndSize, string WndTitle, bool ManualInit, Color ColBg, Color ColFg, SpriteFont WndFont, SFormStyle WndStyle ) {
			Form.CurrentDrawOrder++;

			mScreenSize = new Vector2( Constants.GraphicsDevice.Viewport.Width, Constants.GraphicsDevice.Viewport.Height );

			// public Settings
			this.FormPos = WndPos;
			this.FormSize = WndSize;
			this.FormTitle = WndTitle;
			this.ColorBackground = ColBg;
			this.ColorForeground = ColFg;
			this.FormStyle = WndStyle;
			this.FormFont = WndFont;
			this.FormTitlePos = this.FormStyle.TitlePosition;

			// private Settings
			Form.TopForm = this;
			this.mFormAlpha = 0f;
			this.mAlpha = 0f;
			this.mFormPosPrev = this.FormPos;
			this.mFormSizePrev = this.FormSize;
			this.mDrawOrder = Form.CurrentDrawOrder;

			if( this.FormPos == Vector2.Zero )
				this.FormPos = new Vector2( Constants.GraphicsDevice.Viewport.Width / 2f - this.FormSize.X / 2f, Constants.GraphicsDevice.Viewport.Height / 2f - this.FormSize.Y / 2f );

			Initialize( ManualInit );
		}

		public void Initialize( bool ManualInit ) {
			mScreenSize = new Vector2( Constants.GraphicsDevice.Viewport.Width, Constants.GraphicsDevice.Viewport.Height );
			if( mFormFont == null )
				mFormFont = EngineCore.ContentLoader.Load<SpriteFont>( @"Fonts\Arial" );

			InitTexture( ManualInit );
			InitEvents();
		}

		public void InitEvents() {
			OnMouseClick += new EventHandler( form_onMouseClick );
			OnResized += new Form_OnResizedHandler( form_onResized );
		}

		public void InitTexture( bool isManualInit ) {
			if( isManualInit == false ) {
				FormTextureName = new string[ 9 ]{
					@"Interface\" + FormStyle + @"\Form\form_topleft",
					@"Interface\" + FormStyle + @"\Form\form_topmiddle",
					@"Interface\" + FormStyle + @"\Form\form_topright",
					@"Interface\" + FormStyle + @"\Form\form_middleleft",
					@"Interface\" + FormStyle + @"\Form\form_middlemiddle",
					@"Interface\" + FormStyle + @"\Form\form_middleright",
					@"Interface\" + FormStyle + @"\Form\form_bottomleft",
					@"Interface\" + FormStyle + @"\Form\form_bottommiddle",
					@"Interface\" + FormStyle + @"\Form\form_bottomright"+( mCanResize ? "_resize" : "" )+"",
				};
			}

			if( FormTextureName == null )
				return;

			FormTexture = EngineCore.ContentLoader.Load<Texture2D>( FormTextureName );

			mDestinationRect = new Rectangle[ 5 ];

			//Top Middle
			mDestinationRect[ 0 ] = new Rectangle( FormTexture[ 0 ].Width, 0, FormTexture[ 1 ].Width, FormTexture[ 1 ].Height );
			//Middle Middle
			mDestinationRect[ 1 ] = new Rectangle( FormTexture[ 3 ].Width, FormTexture[ 1 ].Height, FormTexture[ 4 ].Width, FormTexture[ 4 ].Height );
			//Bottom Middle
			mDestinationRect[ 2 ] = new Rectangle( FormTexture[ 6 ].Width, FormTexture[ 1 ].Height + FormTexture[ 4 ].Height, FormTexture[ 7 ].Width, FormTexture[ 7 ].Height );

			//Middle Left
			mDestinationRect[ 3 ] = new Rectangle( 0, FormTexture[ 0 ].Height, FormTexture[ 3 ].Width, FormTexture[ 3 ].Height );
			//Middle Right
			mDestinationRect[ 4 ] = new Rectangle( FormTexture[ 1 ].Width + FormTexture[ 4 ].Width, FormTexture[ 2 ].Height, FormTexture[ 5 ].Width, FormTexture[ 5 ].Height );

			Calculate();

			FormSizeMin = new Vector2( FormTexture[ 0 ].Width + FormTexture[ 1 ].Width + 125f, FormTexture[ 0 ].Height + FormTexture[ 6 ].Height );

			Redraw();
		}

		public void Calculate() {
			//Top Middle
			mDestinationRect[ 0 ].X = (int)FormPos.X + FormTexture[ 0 ].Width;
			mDestinationRect[ 0 ].Y = (int)FormPos.Y;
			mDestinationRect[ 0 ].Width = (int)FormSize.X - ( FormTexture[ 0 ].Width + FormTexture[ 2 ].Width );

			//Middle Left
			mDestinationRect[ 3 ].X = (int)FormPos.X;
			mDestinationRect[ 3 ].Y = (int)FormPos.Y + FormTexture[ 0 ].Height;
			mDestinationRect[ 3 ].Height = (int)FormSize.Y - ( FormTexture[ 0 ].Height + FormTexture[ 6 ].Height );

			//Middle Middle
			mDestinationRect[ 1 ].X = (int)FormPos.X + FormTexture[ 3 ].Width;
			mDestinationRect[ 1 ].Y = (int)FormPos.Y + FormTexture[ 1 ].Height;
			mDestinationRect[ 1 ].Width = (int)FormSize.X - ( FormTexture[ 3 ].Width + FormTexture[ 5 ].Width );
			mDestinationRect[ 1 ].Height = (int)FormSize.Y - ( FormTexture[ 1 ].Height + FormTexture[ 7 ].Height );

			//Middle Right
			mDestinationRect[ 4 ].X = (int)FormPos.X + FormTexture[ 3 ].Width + mDestinationRect[ 1 ].Width;
			mDestinationRect[ 4 ].Y = (int)FormPos.Y + FormTexture[ 2 ].Height;
			mDestinationRect[ 4 ].Height = (int)FormSize.Y - ( FormTexture[ 2 ].Height + FormTexture[ 8 ].Height );

			//Bottom Middle
			mDestinationRect[ 2 ].X = (int)FormPos.X + FormTexture[ 6 ].Width;
			mDestinationRect[ 2 ].Y = (int)FormPos.Y + FormTexture[ 1 ].Height + mDestinationRect[ 4 ].Height;
			mDestinationRect[ 2 ].Width = (int)FormSize.X - ( FormTexture[ 6 ].Width + FormTexture[ 8 ].Width );
		}

		public void InitButtons() {
			Vector2 buttonPosition = new Vector2( FormSize.X - 15f, 5f ) + FormPos;
			Color buttonColor = new Color( new Vector4( new Vector3( 0.3f ) + ColorBackground.ToVector3() * 0.6f, 1.0f ) );

			if( CanClose ) {
				BtnClose = new ButtonSimple( "btClose", buttonPosition, "button_close", FormStyle );
				BtnClose.OnMouseRelease += new EventHandler( closeButton_onMouseRelease );
			}

			if( CanMini ) {
				BtnMini = new ButtonSimple( "btMinimize", buttonPosition - new Vector2( 25, 0f ), "button_minimize", FormStyle );
				BtnMini.OnMouseRelease += new EventHandler( minimizeButton_onMouseRelease );
			}

			if( CanMaxi ) {
				BtnMaxi = new ButtonSimple( "btMaximize", buttonPosition - new Vector2( 15, 0f ), "button_maximize", FormStyle );
				BtnMaxi.OnMouseRelease += new EventHandler( maximizeButton_onMouseRelease );
			}

			BtnRestore = new ButtonSimple( "btRestore", buttonPosition - new Vector2( 15, 0f ), "button_restore", FormStyle );
			BtnRestore.OnMouseRelease += new EventHandler( maximizeButton_onMouseRelease );
		}



		public void SetFocus() {
			Form.CurrentDrawOrder++;
			Form.TopForm = this;

			mDrawOrder = Form.CurrentDrawOrder;
			Focused = true;
			bTabDown = true;
		}

		public void SetCenter() {
			mFormPos = new Vector2( ( mScreenSize.X / 2 ) - ( mFormSize.X / 2 ), ( mScreenSize.Y / 2 ) - ( mFormSize.Y / 2 ) );
			mFormPosPrev = mFormPos;
		}

		public void Add( Control control ) {
			control.Owner = this;
			control.TabOrder = TabIndex;
			TabIndex++;

			Controls.Add( control );

			Redraw();
		}

		private void closeButton_onMouseRelease( Object obj, EventArgs e ) {
			if( Form.TopForm != this )
				return;
			Hide();
		}

		private void maximizeButton_onMouseRelease( Object obj, EventArgs e ) {
			if( CanMaxi == false && FormState != EFormState.Minimized )
				return;
			if( Form.TopForm != this )
				return;

			if( FormState == EFormState.Restored ) {
				mFormPosPrev = FormPos;
				mFormSizePrev = FormSize;
				mFormStatePrev = FormState;
				FormState = EFormState.Maximizing;
				SetFocus();
			} else if( FormState == EFormState.Minimized || FormState == EFormState.Maximized ) {
				mFormStatePrev = FormState;
				if( FormState == EFormState.Minimized ) {
					if( Spot != -1 && Form.MinimizeSpot[ Spot ] == 1 ) {
						Form.MinimizeSpot[ Spot ] = 0;
						Spot = -1;
					}
				}
				SetFocus();
				FormState = EFormState.Restoring;
			} else if( FormState == EFormState.Minimizing ) {
				if( Spot != -1 && Form.MinimizeSpot[ Spot ] == 1 ) {
					Form.MinimizeSpot[ Spot ] = 0;
					Spot = -1;
				}
				SetFocus();
				FormState = EFormState.Restoring;
			}
		}


		private void minimizeButton_onMouseRelease( Object obj, EventArgs e ) {
			if( !CanMini )
				return;
			if( Form.TopForm != this )
				return;

			if( FormState == EFormState.Maximized || FormState == EFormState.Restored ) {
				if( FormState == EFormState.Restored ) {
					mFormPosPrev = FormPos;
					mFormSizePrev = FormSize;
				}
				Spot = FindSpot();
				Form.MinimizeSpot[ Spot ] = 1;
				FormState = EFormState.Minimizing;
			}
		}




		public void Show() {
			Visible = true;
			mFormProcState = EFormProcState.Opening;
		}

		public void Hide() {
			if( FormState == EFormState.Minimized )
				Form.MinimizeSpot[ Spot ] = 0;

			mFormProcState = EFormProcState.Closing;
		}

		public void Unload() {
			Form.InUse = false;

			if( Owner != null )
				Owner.Remove( this );
		}

		public virtual void Update( GameTime gameTime ) {
			mMouseState = Mouse.GetState();

			mMousePos.X = mMouseState.X;
			mMousePos.Y = mMouseState.Y;

			if( Visible && ( Form.TopForm == this || Form.TopForm == null || Form.TopForm.CanLostFocus == true ) ) {
				if( !Form.InUse )
					CheckFocus();

				if( BtnClose != null )
					BtnClose.Update( gameTime );
				if( BtnMini != null )
					BtnMini.Update( gameTime );
				if( BtnMaxi != null )
					BtnMaxi.Update( gameTime );
				if( BtnRestore != null )
					BtnRestore.Update( gameTime );

				if( Controls.Count > 0 )
					Controls.Update( gameTime, FormPos, FormSize );

				if( CanDrag ) {
					if( mMouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed ) {
						if( !mDragging && !Form.InUse )
							CheckDrag();
						else if( mDragging ) {
							if( mFormAlpha > 0.5f )
								mFormAlpha -= 0.02f;
							Drag();
						}
					} else if( mDragging ) {
						StopDrag();
						mFormAlpha = 1f;
					}
				}

				if( mCanResize )
					CheckResize();

				if( Controls.Count > 0 )
					Controls.Update( gameTime, FormPos, FormSize );

				if( FormState == EFormState.Maximizing )
					Maximize();
				else if( FormState == EFormState.Minimizing )
					Minimize();
				else if( FormState == EFormState.Restoring )
					Restore();

				if( Form.TopForm == this )
					CheckKeyboardState();

				UpdateVisibility();
			}
		}

		private void UpdateVisibility() {
			if( mFormProcState == EFormProcState.Opening ) {
				if( !Visible ) {
					Visible = true;
					foreach( Control thisControl in Controls.Controls )
						thisControl.Visible = true;
				}

				if( mFormAlpha < this.AlphaDef )
					mFormAlpha += mAlphaSpeed;
				else {
					mFormAlpha = this.AlphaDef;
					mFormProcState = EFormProcState.Opened;
				}
			} else if( mFormProcState == EFormProcState.Closing ) {
				if( mFormAlpha > 0f )
					mFormAlpha -= mAlphaSpeed;
				else {
					mFormAlpha = 0f;
					mFormProcState = EFormProcState.Closed;
					Visible = false;
					foreach( Control thisControl in Controls.Controls )
						thisControl.Visible = false;
				}
			}
		}

		private void CheckKeyboardState() {
			mKeyboardState = Keyboard.GetState();

			if( mKeyboardState.IsKeyDown( Microsoft.Xna.Framework.Input.Keys.LeftControl ) || mKeyboardState.IsKeyDown( Microsoft.Xna.Framework.Input.Keys.RightControl ) ) {
				if( mKeyboardState.IsKeyDown( Microsoft.Xna.Framework.Input.Keys.Tab ) ) {
					if( !bTabDown ) {
						bTabDown = true;
						Owner.FocusNextForm();
					}
				} else if( bTabDown == true )
					bTabDown = false;
			} else if( bTabDown == true )
				bTabDown = false;
		}

		private void Maximize() {
			if( !CanMaxi )
				return;

			if( FormPos.X * 0.9f > 0.05f )
				FormPos *= new Vector2( 0.9f, 0 );
			else
				FormPos = Vector2.Zero;

			if( FormPos.Y * 0.9f > 0.05f )
				FormPos *= new Vector2( 0.9f, 0 );
			else
				FormPos = Vector2.Zero;

			FormPos = new Vector2( (int)FormPos.X, (int)FormPos.Y );

			if( FormSize.X * 1.025f < mScreenSize.X )
				FormSize = new Vector2( FormSize.X * 1.025f, FormSize.Y );
			else
				FormSize = new Vector2( mScreenSize.X, FormSize.Y );

			if( FormSize.Y * 1.025f < mScreenSize.Y )
				FormSize = new Vector2( FormSize.X, FormSize.Y * 1.025f );
			else
				FormSize = new Vector2( FormSize.X, mScreenSize.Y );

			FormSize = new Vector2( (int)FormSize.X, (int)FormSize.Y );

			Redraw();

			if( FormPos == Vector2.Zero && FormSize == mScreenSize ) {
				Form.InUse = false;
				if( mFormStatePrev == EFormState.Minimized )
					Form.MinimizeSpot[ Spot ] = 0;
				mFormStatePrev = FormState;
				FormState = EFormState.Maximized;

				if( OnResized != null )
					OnResized( new FormResizedEventsArgs( FormState ) );
			}
		}

		private void Minimize() {
			if( !CanMini )
				return;

			if( FormPos.X * 0.925f > 0.1f + FormSizeMin.X * ( Spot % ( (int)System.Math.Round( mScreenSize.X / FormSizeMin.X, MidpointRounding.AwayFromZero ) - 1 ) ) )
				FormPos *= new Vector2( 0.925f, 0 );
			else
				FormPos = new Vector2( 0f + FormSizeMin.X * ( Spot % ( (int)System.Math.Round( mScreenSize.X / FormSizeMin.X, MidpointRounding.AwayFromZero ) - 1 ) ), FormPos.Y );

			float targetPosY = ( mScreenSize.Y - FormSizeMin.Y * (int)( System.Math.Round( Spot / 5f, MidpointRounding.AwayFromZero ) + 1 ) );

			if( System.Math.Abs( targetPosY - FormPos.Y ) > 0.2f )
				FormPos += new Vector2( 0, ( targetPosY - FormPos.Y ) * 0.2f );
			else
				FormPos = new Vector2( FormPos.X, mScreenSize.Y - FormSizeMin.Y * (int)( System.Math.Round( Spot / 5f, MidpointRounding.AwayFromZero ) + 1 ) );

			if( FormSize.X * 0.925f > FormSizeMin.X + 0.1f )
				FormSize *= new Vector2( 0.925f, 0 );
			else
				FormSize = new Vector2( FormSizeMin.X, FormSize.Y );

			if( FormSize.Y * 0.9f > FormSizeMin.Y + 0.1f )
				FormSize *= new Vector2( 0, 0.9f );
			else
				FormSize = new Vector2( FormSize.X, FormSizeMin.Y );

			FormPos = new Vector2( (int)FormPos.X, FormPos.Y );
			FormSize = new Vector2( (int)FormSize.X, (int)FormSize.Y );

			Redraw();

			if( FormPos == new Vector2( 0f + FormSizeMin.X * ( Spot % ( (int)System.Math.Round( mScreenSize.X / FormSizeMin.X, MidpointRounding.AwayFromZero ) - 1 ) ), mScreenSize.Y - FormSizeMin.Y * (int)( System.Math.Round( Spot / 5f, MidpointRounding.AwayFromZero ) + 1 ) ) && FormSize == FormSizeMin ) {
				Form.InUse = false;
				mFormStatePrev = FormState;
				FormState = EFormState.Minimized;

				if( OnResized != null )
					OnResized( new FormResizedEventsArgs( FormState ) );
			}
		}

		public int FindSpot() {
			for( int i = 0; i < Form.MinimizeSpot.Length; i++ ) {
				if( Form.MinimizeSpot[ i ] == 0 )
					return i;
			}

			return 0;
		}

		private void Restore() {
			if( Vector2.Distance( mFormPosPrev, FormPos ) > 10f )
				FormPos += ( mFormPosPrev - FormPos ) * 0.2f;
			else
				FormPos = mFormPosPrev;

			if( Vector2.Distance( mFormSizePrev, FormSize ) > 10f )
				FormSize += ( mFormSizePrev - FormSize ) * 0.2f;
			else
				FormSize = mFormSizePrev;

			FormPos = new Vector2( (int)FormPos.X, (int)FormPos.Y );
			FormSize = new Vector2( (int)FormSize.X, (int)FormSize.Y );

			Redraw();

			if( FormPos == mFormPosPrev && FormSize == mFormSizePrev ) {
				Form.InUse = false;
				mFormStatePrev = FormState;
				FormState = EFormState.Restored;

				if( OnResized != null )
					OnResized( new FormResizedEventsArgs( FormState ) );
			}
		}

		private void CheckFocus() {
			if( Form.TopForm != null && Form.TopForm.CanLostFocus == false )
				return;

			if( mMouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed )
				if( Form.TopForm != this && bMouseInForm() ) {
					SetFocus();
					if( OnMouseClick != null )
						OnMouseClick( this, EventArgs.Empty );
				}
		}

		private void FocusNextControl() {
			previousIndex = TabIndex;
			if( previousIndex >= Controls.Count )
				previousIndex = 0;

			TabIndex++;
			if( TabIndex >= Controls.Count )
				TabIndex = 0;

			switch( Controls[ previousIndex ].ControlType ) {
				case EControlType.Textbox:
					( (Textbox)Controls[ previousIndex ] ).Unfocus();
					break;
			}

			switch( Controls[ TabIndex ].ControlType ) {
				case EControlType.Textbox:
					( (Textbox)Controls[ TabIndex ] ).SetFocus();
					break;
			}
		}

		private void FocusPreviousControl() {
			previousIndex = TabIndex;
			if( previousIndex >= Controls.Count )
				previousIndex = 0;

			TabIndex--;
			if( TabIndex < 0 )
				TabIndex = Controls.Count - 1;

			switch( Controls[ previousIndex ].ControlType ) {
				case EControlType.Textbox:
					( (Textbox)Controls[ previousIndex ] ).Unfocus();
					break;
			}

			switch( Controls[ TabIndex ].ControlType ) {
				case EControlType.Textbox:
					( (Textbox)Controls[ TabIndex ] ).SetFocus();
					break;
			}
		}

		private void CheckDrag() {
			if( bMouseOnTitlebar() == false || mDragging || mResizing || Form.InUse )
				return;

			if( Form.TopForm != this && !Form.InUse )
				SetFocus();

			if( !Form.InUse && FormState == EFormState.Restored ) {
				Form.InUse = true;
				mDragging = true;
				startDragPos = mMousePos;
				previousDragPos = FormPos;
			}
		}

		private void Drag() {
			Cursor.Current = Cursors.Default;
			if( mDragging == false )
				return;

			Form.InUse = true;

			if( mMouseState.X < 0 || mMouseState.Y < 0 || mMouseState.X > mScreenSize.X || mMouseState.Y > mScreenSize.Y )
				return;

			Cursor.Current = Cursors.SizeAll;
			Vector2 wndPos = previousDragPos + mMousePos - startDragPos;

			if( wndPos.X < 0f )
				wndPos.X = 0f;
			if( wndPos.Y < 0f )
				wndPos.Y = 0f;
			if( wndPos.X > ( mScreenSize.X - FormSize.X ) )
				wndPos.X = mScreenSize.X - FormSize.X;
			if( wndPos.Y > ( mScreenSize.Y - FormSize.Y ) )
				wndPos.Y = mScreenSize.Y - FormSize.Y;

			if( wndPos.X < SnapSize && ( wndPos.X > -SnapSize ) )
				wndPos.X = 0f;
			if( wndPos.Y < SnapSize && ( wndPos.Y > -SnapSize ) )
				wndPos.Y = 0f;
			if( wndPos.X > ( mScreenSize.X - FormSize.X - SnapSize ) && wndPos.X < ( mScreenSize.X - FormSize.X + SnapSize ) )
				wndPos.X = mScreenSize.X - FormSize.X;
			if( wndPos.Y > ( mScreenSize.Y - FormSize.Y - SnapSize ) && wndPos.Y < ( mScreenSize.Y - FormSize.Y + SnapSize ) )
				wndPos.Y = mScreenSize.Y - FormSize.Y;

			FormPos = wndPos;

			Redraw();
		}

		private void StopDrag() {
			mDragging = false;
			Form.InUse = false;

			if( FormState == EFormState.Restored )
				mFormPosPrev = FormPos;
		}

		private void CheckResize() {

			if( mMouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed ) {
				if( Form.TopForm == this && bMouseOnFormResize() && !mResizing && !mDragging && !Form.InUse && FormState == EFormState.Restored ) {
					Form.InUse = true;
					Cursor.Current = Cursors.SizeNWSE;

					mResizing = true;
					startResizePos = mMousePos;

					if( FormState == EFormState.Restored ) {
						mFormPosPrev = FormPos;
						mFormSizePrev = FormSize;
					} else
						FormState = EFormState.Restored;
				} else if( mResizing ) {
					Form.InUse = true;
					Cursor.Current = Cursors.SizeNWSE;

					if( mMouseState.X < 0 || mMouseState.Y < 0 || mMouseState.X > mScreenSize.X || mMouseState.Y > mScreenSize.Y )
						return;

					FormSize = mFormSizePrev + mMousePos - startResizePos;

					if( CanSnap == true && SnapSize > 0 ) {
						if( FormPos.X + FormSize.X > mScreenSize.X - SnapSize )
							FormSize = new Vector2( mScreenSize.X - FormPos.X, FormSize.Y );
						if( FormPos.Y + FormSize.Y > mScreenSize.Y - SnapSize )
							FormSize = new Vector2( FormSize.X, mScreenSize.Y - FormPos.Y );
					}

					if( FormSize.X < (int)FormSizeMin.X )
						FormSize = new Vector2( (int)FormSizeMin.X, FormSize.Y );
					if( FormSize.Y < (int)FormSizeMin.Y )
						FormSize = new Vector2( FormSize.X, (int)FormSizeMin.Y );

					FormSize = new Vector2( (int)FormSize.X, (int)FormSize.Y );

					Redraw();
				}
			} else if( mResizing ) {
				Cursor.Current = Cursors.Default;
				Form.InUse = false;
				mResizing = false;

				if( OnResized != null )
					OnResized( new FormResizedEventsArgs( FormState ) );
			}
		}

		private bool bMouseOnFormResize() {
			if( mMouseState.X > ( FormPos.X + FormSize.X - 20 ) && mMouseState.X < ( FormPos.X + FormSize.X ) && mMouseState.Y > ( FormPos.Y + FormSize.Y - 20 ) && mMouseState.Y < ( FormPos.Y + FormSize.Y ) )
				return true;
			return false;
		}

		private bool bMouseOnTitlebar() {
			if( mMouseState.X > FormPos.X && mMouseState.X < ( FormPos.X + FormSize.X ) && mMouseState.Y > FormPos.Y && mMouseState.Y < ( FormPos.Y + FormTexture[ 0 ].Height ) )
				return true;
			return false;
		}

		private bool bMouseInForm() {
			if( mMouseState.X > FormPos.X && mMouseState.X < ( FormPos.X + FormSize.X ) && mMouseState.Y > FormPos.Y && mMouseState.Y < ( FormPos.Y + FormSize.Y ) )
				return true;
			return false;
		}

		public void Redraw() {
			Calculate();

			Vector2 buttonPosition = new Vector2( FormSize.X - 15f, 2f ) + FormPos;
			int x = 0;
			if( BtnClose != null )
				BtnClose.MoveTo( buttonPosition );
			if( BtnMini != null ) {
				x = 0;
				if( BtnClose != null )
					x += 10;
				if( BtnMaxi != null )
					x += 10;
				BtnMini.MoveTo( buttonPosition - new Vector2( x, 0f ) );
			}
			if( BtnMaxi != null ) {
				x = 0;
				if( BtnClose != null )
					x += 10;
				BtnMaxi.MoveTo( buttonPosition - new Vector2( x, 0f ) );
			}
			if( BtnRestore != null ) {
				x = 0;
				if( BtnClose != null )
					x += 10;
				BtnRestore.MoveTo( buttonPosition - new Vector2( x, 0f ) );
			}
		}

		public virtual void Draw() {
			if( Visible == false )
				return;

			EngineCore.SpriteBatch.Begin( SpriteBlendMode.AlphaBlend );

			if( mDrawOrder != Form.CurrentDrawOrder && mCanLostFocus == true && mModifyAlpha == true )
				mAlpha = mFormAlpha * 0.7f;
			else
				mAlpha = mFormAlpha;

			Color dynamicColor = new Color( new Vector4( ColorBackground.ToVector3().X, ColorBackground.ToVector3().Y, ColorBackground.ToVector3().Z, mAlpha ) );

			DrawWindowParts( EngineCore.SpriteBatch, dynamicColor );

			DrawButtons();

			Color dynamicTextColor = new Color( new Vector4( ColorForeground.ToVector3().X, ColorForeground.ToVector3().Y, ColorForeground.ToVector3().Z, mAlpha ) );
			if( HideTitle == false ) {
				if( FormStyle.TitleShadow == true ) {
					EngineCore.SpriteBatch.DrawString( FormFont, FormTitle, FormPos + new Vector2( FormTitlePos.X + 1f, FormTitlePos.Y + 1f ), new Color( new Vector4( Color.White.ToVector3().X, Color.White.ToVector3().Y, Color.White.ToVector3().Z, mAlpha ) ) );
				}
				EngineCore.SpriteBatch.DrawString( FormFont, FormTitle, FormPos + new Vector2( FormTitlePos.X, FormTitlePos.Y ), dynamicTextColor );
			}

			Controls.Draw( EngineCore.SpriteBatch, mAlpha );

			EngineCore.SpriteBatch.End();
		}

		private void DrawWindowParts( SpriteBatch spriteBatch, Color dynamicColor ) {
			//Top
			spriteBatch.Draw( FormTexture[ 0 ], FormPos, dynamicColor ); //Top Left
			spriteBatch.Draw( FormTexture[ 1 ], mDestinationRect[ 0 ], dynamicColor ); //Top Middle
			spriteBatch.Draw( FormTexture[ 2 ], FormPos + new Vector2( FormTexture[ 0 ].Width + mDestinationRect[ 0 ].Width, 0f ), dynamicColor ); //Top Right

			//Middle
			spriteBatch.Draw( FormTexture[ 3 ], mDestinationRect[ 3 ], dynamicColor ); //Middle Left
			spriteBatch.Draw( FormTexture[ 4 ], mDestinationRect[ 1 ], dynamicColor ); //Middle Middle
			spriteBatch.Draw( FormTexture[ 5 ], mDestinationRect[ 4 ], dynamicColor ); //Middle Right

			//Bottom
			spriteBatch.Draw( FormTexture[ 6 ], FormPos + new Vector2( 0f, FormTexture[ 0 ].Height + mDestinationRect[ 1 ].Height ), dynamicColor ); //Bottom Left
			spriteBatch.Draw( FormTexture[ 7 ], mDestinationRect[ 2 ], dynamicColor ); //Bottom Middle
			spriteBatch.Draw( FormTexture[ 8 ], FormPos + new Vector2( FormTexture[ 0 ].Width + mDestinationRect[ 1 ].Width, FormTexture[ 0 ].Height + mDestinationRect[ 1 ].Height ), dynamicColor ); //Bottom Right
		}

		private void DrawButtons() {
			if( BtnClose != null && CanClose == true )
				BtnClose.Draw( EngineCore.SpriteBatch, mAlpha );
			if( FormState != EFormState.Minimized && FormState != EFormState.Minimizing && BtnMini != null && CanMini == true )
				BtnMini.Draw( EngineCore.SpriteBatch, mAlpha );

			if( BtnRestore != null && FormState != EFormState.Restored && FormState != EFormState.Restoring )
				BtnRestore.Draw( EngineCore.SpriteBatch, mAlpha );
			else if( BtnMaxi != null && CanMaxi == true )
				BtnMaxi.Draw( EngineCore.SpriteBatch, mAlpha );

		}

	}

}
