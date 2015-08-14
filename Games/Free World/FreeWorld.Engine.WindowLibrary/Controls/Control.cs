using System;
using System.Collections;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using FreeWorld.Engine;

namespace FreeWorld.Engine.WindowLibrary {

	[Serializable]
	[XmlInclude( typeof( Button ) )]
	[XmlInclude( typeof( ButtonSimple ) )]
	[XmlInclude( typeof( Checkbox ) )]
	[XmlInclude( typeof( ComboBox ) )]
	[XmlInclude( typeof( ImageBox ) )]
	[XmlInclude( typeof( Label ) )]
	[XmlInclude( typeof( Listbox ) )]
	[XmlInclude( typeof( Progressbar ) )]
	[XmlInclude( typeof( RadioButton ) )]
	[XmlInclude( typeof( Scrollbar ) )]
	[XmlInclude( typeof( Slider ) )]
	[XmlInclude( typeof( Textbox ) )]
	[XmlInclude( typeof( TextButton ) )]
	public partial class Control {

		#region Variable declare
		private EControlType mControlType = EControlType.None;
		private Form mFormOwner = null;
		private MouseState mMouseState;
		private KeyboardState mKeyboardState;
		private SpriteFont mSpriteFont;
		private EProgressBarStyle mProgressBarStyle = EProgressBarStyle.Continuous;
		private EComboBoxState mComboBoxState = EComboBoxState.Closed;
		private EScrollBarAxis mScrollBarAxis = EScrollBarAxis.Horizontal;

		private Button[] mButtons;
		private Scrollbar mScrollbar;

		private Vector2 mPositionOrg = Vector2.Zero;
		private Vector2 mPosition = Vector2.Zero;
		private Point mControlSize = Point.Zero;
		private Point mControlSizeMin = Point.Zero;
		private Point mControlSizeMax = Point.Zero;

		private EBtnState mBtnState = EBtnState.None;

		private SFormStyle mWindowStyle = null;

		private string mControlTextureName;
		private string[] mControlTextureNames;
		private Texture2D mControlTexture;
		private Texture2D[] mControlTextures;
		private Rectangle mControlRectangle = Rectangle.Empty;
		private Rectangle[] mControlRectangles;

		private int mTabOrder = 0;
		private int mMinValue = 0;
		private int mMaxValue = 1;
		private int mValue = 0;

		private float mAlpha = 1f;

		private string mName = string.Empty;
		private string mText = string.Empty;
		private object mTag = null;
		private string mSelectedItem = string.Empty;
		private int mSelectedIndex = -1;

		private bool mVisible = true;
		private bool mDisabled = false;
		private bool mChecked = false;

		private Color mColorBgDefault = Color.White;
		private Color mColorBgCurrent = Color.White;
		private Color mColorFgDefault = Color.Black;
		private Color mColorFgCurrent = Color.Black;
		private Color mBorderColor = Color.Transparent;
		private Color[] mColorBgDefaults;

		private ArrayList mItems = new ArrayList(); 
		#endregion

		#region Setter && Getter
		public EControlType ControlType {
			get { return mControlType; }
			set { mControlType = value; }
		}
		public EProgressBarStyle ProgressBarStyle {
			get { return mProgressBarStyle; }
			set { mProgressBarStyle = value; }
		}
		public EScrollBarAxis ScrollBarAxis {
			get { return mScrollBarAxis; }
			set { mScrollBarAxis = value; }
		}

		public Button[] Buttons {
			get { return mButtons; }
			set { mButtons = value; }
		}
		public Scrollbar Scrollbar {
			get { return mScrollbar; }
			set { mScrollbar = value; }
		}
		public Vector2 PositionOrg {
			get { return mPositionOrg; }
			set { mPositionOrg = value; }
		}
		public Vector2 Position {
			get { return mPosition; }
			set { mPosition = value; }
		}
		public Point ControlSize {
			get { return mControlSize; }
			set { mControlSize = value; }
		}
		public Point ControlSizeMin {
			get { return mControlSizeMin; }
			set { mControlSizeMin = value; }
		}
		public Point ControlSizeMax {
			get { return mControlSizeMax; }
			set { mControlSizeMax = value; }
		}


		public SFormStyle WindowStyle {
			get { return mWindowStyle; }
			set { mWindowStyle = value; }
		}

		public string ControlTextureName {
			get { return mControlTextureName; }
			set { mControlTextureName = value; }
		}
		public string[] ControlTextureNames {
			get { return mControlTextureNames; }
			set { mControlTextureNames = value; }
		}

		public int Value {
			get { return mValue; }
			set { mValue = value; }
		}
		public int MinValue {
			get { return mMinValue; }
			set { mMinValue = value; }
		}
		public int MaxValue {
			get { return mMaxValue; }
			set { mMaxValue = value; }
		}


		public string Name {
			get { return mName; }
			set { mName = value; }
		}
		public string Text {
			get { return mText; }
			set { mText = value; }
		}
		public object Tag {
			get { return mTag; }
			set { mTag = value; }
		}
		public string SelectedItem {
			get { return mSelectedItem; }
			set { mSelectedItem = value; }
		}
		public int SelectedIndex {
			get { return mSelectedIndex; }
			set { mSelectedIndex = value; }
		}

		public bool Disabled {
			get { return mDisabled; }
			set { mDisabled = value; }
		}
		public bool Checked {
			get { return mChecked; }
			set { mChecked = value; }
		}

		[XmlElement( Namespace = "Microsoft.Xna.Framework.Graphics" )]
		public Color ColorBgDefault {
			get { return mColorBgDefault; }
			set { mColorBgDefault = value; }
		}
		[XmlElement( Namespace = "Microsoft.Xna.Framework.Graphics" )]
		public Color ColorBgCurrent {
			get { return mColorBgCurrent; }
			set { mColorBgCurrent = value; }
		}
		[XmlElement( Namespace = "Microsoft.Xna.Framework.Graphics" )]
		public Color ColorFgDefault {
			get { return mColorFgDefault; }
			set { mColorFgDefault = value; }
		}
		[XmlElement( Namespace = "Microsoft.Xna.Framework.Graphics" )]
		public Color ColorFgCurrent {
			get { return mColorFgCurrent; }
			set { mColorFgCurrent = value; }
		}
		[XmlElement( Namespace = "Microsoft.Xna.Framework.Graphics" )]
		public Color BorderColor {
			get { return mBorderColor; }
			set { mBorderColor = value; }
		}
		[XmlElement( Namespace = "Microsoft.Xna.Framework.Graphics" )]
		public Color[] ColorBgDefaults {
			get { return mColorBgDefaults; }
			set { mColorBgDefaults = value; }
		}

		public ArrayList Items {
			get { return mItems; }
			set { mItems = value; }
		}
		#endregion
		
		#region [XmlIgnore]
		[XmlIgnore]
		public MouseState MouseState {
			get { return mMouseState; }
			set { mMouseState = value; }
		}
		[XmlIgnore]
		public KeyboardState KeyboardState {
			get { return mKeyboardState; }
			set { mKeyboardState = value; }
		}
		[XmlIgnore]
		public EComboBoxState ComboBoxState {
			get { return mComboBoxState; }
			set { mComboBoxState = value; }
		}
		[XmlIgnore]
		public EBtnState BtnState {
			get { return mBtnState; }
			set { mBtnState = value; }
		}
		[XmlIgnore]
		public Rectangle ControlRectangle {
			get { return mControlRectangle; }
			set { mControlRectangle = value; }
		}
		[XmlIgnore]
		public Rectangle[] ControlRectangles {
			get { return mControlRectangles; }
			set { mControlRectangles = value; }
		}
		[XmlIgnore]
		public int TabOrder {
			get { return mTabOrder; }
			set { mTabOrder = value; }
		}
		[XmlIgnore]
		public float Alpha {
			get { return mAlpha; }
			set { mAlpha = value; }
		}
		[XmlIgnore]
		public bool Visible {
			get { return mVisible; }
			set { mVisible = value; }
		}
		[XmlIgnore]
		public Texture2D[] ControlTextures {
			get { return mControlTextures; }
			set { mControlTextures = value; }
		}
		[XmlIgnore]
		public Texture2D ControlTexture {
			get { return mControlTexture; }
			set { mControlTexture = value; }
		}
		[XmlIgnore]
		public SpriteFont SpriteFont {
			get { return mSpriteFont; }
			set { mSpriteFont = value; }
		}
		[XmlIgnore]
		public Form Owner {
			get { return mFormOwner; }
			set { mFormOwner = value; }
		}
		[XmlIgnore]
		public System.Windows.Forms.Cursor Cursor {
			get { return System.Windows.Forms.Cursor.Current; }
			set { System.Windows.Forms.Cursor.Current = value; }
		} 
		#endregion


		public Control() {
			mSpriteFont = EngineCore.ContentLoader.Load<SpriteFont>( @"Fonts\Arial" );
		}




		public virtual void MoveTo( Vector2 newPosition ) {
			mPositionOrg = newPosition;
		}


		public virtual void Update() {
		}

		public virtual void Update( GameTime gameTime ) {
		}

		public virtual void Update( GameTime gameTime, Vector2 formPosition, Vector2 formSize ) {
			mPosition = mPositionOrg + formPosition;
		}



		public virtual void Draw() {
		}

		public virtual void Draw( SpriteBatch spriteBatch, float alpha ) {
			mAlpha = alpha;
		}
		
		public virtual void InitDefaults() {
		}

		public virtual void InitEvents() {
		}

		public virtual void InitTextures( string Filename ) {
		}

		public virtual void InitTextures() {
		}
	}

}
