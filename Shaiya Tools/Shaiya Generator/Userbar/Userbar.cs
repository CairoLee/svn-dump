using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Text;
using System.IO;
using System.Drawing.Drawing2D;
using System.Xml.Serialization;

using ImageHelper;

namespace Shaiya_Userbar_Generator {

	[Serializable()]
	[XmlInclude( typeof( Bitmap ) )]
	[XmlInclude( typeof( LinearGradientMode ) )]
	public class Userbar {
		#region Properties
		public int Width = 350;
		public int Height = 20;

		public int CustomPadRight = 10;
		public int CustomPadTop = 0;
		public string CustomText = "Shaiya Userbar Generator";
		public int CustomTextBorderAlpha = 0;
		public bool CustomTextBorder = true;

		public LinearGradientMode BackgroundGradientMode = LinearGradientMode.Horizontal;
		public int BackgroundOverlayOpacity = 200;
		public bool BackgroundBorder = false;
		public int BackgroundOpacity = 0;


		public int ShaiyaTextBorderAlpha = 0;
		public bool ShaiyaTextBorder = true;

		public string ShaiyaName;
		public int ShaiyaNamePadRight = 10;
		public int ShaiyaNamePadTop = 0;

		[XmlIgnore]
		public Image ShaiyaClass;
		[XmlElement( ElementName = "ShaiyaClass" )]
		public int XmlShaiyaClass = -1;
		public int ShaiyaClassWidth = 24;
		public int ShaiyaClassHeight = 24;
		public int ShaiyaClassPadRight = 10;
		public int ShaiyaClassPadTop = 0;

		public string ShaiyaLevel;
		public int ShaiyaLevelPadRight = 10;
		public int ShaiyaLevelPadTop = 0;

		[XmlIgnore]
		public Image BackgroundImage;
		[XmlElement( ElementName = "BackgroundImage" )]
		public int XmlBackgroundImage = -1;
		public int BackgroundImageSrcX = 0;
		public int BackgroundImageSrcY = 0;
		public int BackgroundImageDstX = 0;
		public int BackgroundImageDstY = 0;
		public int BackgroundImageMode = 0;

		[XmlIgnore]
		public Font CustomFont;
		[XmlElement( ElementName = "CustomFont" )]
		public int XmlCustomFont = -1;
		[XmlIgnore]
		public Font ShaiyaFont;
		[XmlElement( ElementName = "ShaiyaFont" )]
		public int XmlShaiyaFont = -1;
		[XmlIgnore]
		public Color ShaiyaTextColor = Color.White;
		[XmlElement( ElementName = "ShaiyaTextColor" )]
		public string XmlShaiyaTextColor {
			get { return ColorTranslator.ToHtml( ShaiyaTextColor ); }
			set { ShaiyaTextColor = ColorTranslator.FromHtml( value ); }
		}
		[XmlIgnore]
		public Color ShaiyaTextBorderColor = Color.Black;
		[XmlElement( ElementName = "ShaiyaTextBorderColor" )]
		public string XmlShaiyaTextBorderColor {
			get { return ColorTranslator.ToHtml( ShaiyaTextBorderColor ); }
			set { ShaiyaTextBorderColor = ColorTranslator.FromHtml( value ); }
		}
		[XmlIgnore]
		public Color BackgroundFixxColor = Color.Transparent;
		[XmlElement( ElementName = "BackgroundFixxColor" )]
		public string XmlBackgroundFixxColor {
			get { return ColorTranslator.ToHtml( BackgroundFixxColor ); }
			set { BackgroundFixxColor = ColorTranslator.FromHtml( value ); }
		}
		[XmlIgnore]
		public Color CustomTextColor = Color.White;
		[XmlElement( ElementName = "CustomTextColor" )]
		public string XmlCustomTextColor {
			get { return ColorTranslator.ToHtml( CustomTextColor ); }
			set { CustomTextColor = ColorTranslator.FromHtml( value ); }
		}
		[XmlIgnore]
		public Color CustomTextBorderColor = Color.Black;
		[XmlElement( ElementName = "CustomTextBorderColor" )]
		public string XmlCustomTextBorderColor {
			get { return ColorTranslator.ToHtml( CustomTextBorderColor ); }
			set { CustomTextBorderColor = ColorTranslator.FromHtml( value ); }
		}
		[XmlIgnore]
		public Color BackgroundGradient1 = Color.Black;
		[XmlElement( ElementName = "BackgroundGradient1" )]
		public string XmlBackgroundGradient1 {
			get { return ColorTranslator.ToHtml( BackgroundGradient1 ); }
			set { BackgroundGradient1 = ColorTranslator.FromHtml( value ); }
		}
		[XmlIgnore]
		public Color BackgroundGradient2 = Color.Black;
		[XmlElement( ElementName = "BackgroundGradient2" )]
		public string XmlBackgroundGradient2 {
			get { return ColorTranslator.ToHtml( BackgroundGradient2 ); }
			set { BackgroundGradient2 = ColorTranslator.FromHtml( value ); }
		}
		[XmlIgnore]
		public Color BackgroundBorderColor = Color.Black;
		[XmlElement( ElementName = "BackgroundBorderColor" )]
		public string XmlBackgroundBorderColor {
			get { return ColorTranslator.ToHtml( BackgroundBorderColor ); }
			set { BackgroundBorderColor = ColorTranslator.FromHtml( value ); }
		}
		[XmlIgnore]
		public Color BackgroundOverlayColor = Color.Black;
		[XmlElement( ElementName = "BackgroundOverlayColor" )]
		public string XmlBackgroundOverlayColor {
			get { return ColorTranslator.ToHtml( BackgroundOverlayColor ); }
			set { BackgroundOverlayColor = ColorTranslator.FromHtml( value ); }
		}
		#endregion

		[XmlIgnore]
		public Image ImageObj;
		[XmlIgnore]
		public bool Initialized = false;


		private System.Reflection.Assembly Assembly;
		private PictureBox mPicBox;
		private PrivateFontCollection mFontColection = new PrivateFontCollection();
		private string[] mFontNames = new string[] { "Arial", "Tahoma", "Visitor TT1 BRK" };
		private Dictionary<string, FontFamily> mFonts = new Dictionary<string, FontFamily>();


		public Userbar() {
		}

		public Userbar( System.Reflection.Assembly Asm, PictureBox picBox, ComboBox Box ) {
			ReInitialize( Asm, picBox, Box );
		}



		public void ReInitialize( System.Reflection.Assembly Asm, PictureBox picBox, ComboBox Box ) {
			Assembly = Asm;
			mPicBox = picBox;

			LoadFonts( Box );
		}



		public void Update() {
			Update( true );
		}

		public void Update( bool SetImage ) {
			Rectangle drawSize = new Rectangle( ( mPicBox.Width - Width ) / 2, ( mPicBox.Height - Height ) / 2, Width, Height );
			Update( drawSize, SetImage );
		}

		public void Update( Rectangle drawSize, bool SetImage ) {
			if( Initialized == false )
				return;

			if( SetImage == true )
				ImageObj = new Bitmap( mPicBox.Width, mPicBox.Height );
			else
				ImageObj = new Bitmap( drawSize.Width, drawSize.Height );
			using( Graphics g = Graphics.FromImage( ImageObj ) ) {
				g.SmoothingMode = SmoothingMode.HighQuality;
				using( GraphicsPath gp = new GraphicsPath() ) {
					gp.AddRectangle( drawSize );
					g.SetClip( gp );
				}

				DrawBackground( g, drawSize );
				DrawShaiyaDetails( g, drawSize );
				DrawCustomString( g, drawSize );
				DrawForeground( g, drawSize );
			}

			if( SetImage == false )
				return;

			mPicBox.Image = ImageObj.Clone() as Image;
			mPicBox.Invalidate();
			ImageObj.Dispose();
		}

		public void SetShaiyaFont( string Fontname, float Size, bool update, int index ) {
			ShaiyaFont = new Font( mFonts[ Fontname ], Size, FontStyle.Regular, GraphicsUnit.World );
			XmlShaiyaFont = index;
			if( update == true )
				Update();
		}

		public void SetCustomFont( string Fontname, float Size, bool update, int index ) {
			CustomFont = new Font( mFonts[ Fontname ], Size, FontStyle.Regular, GraphicsUnit.World );
			XmlCustomFont = index;
			if( update == true )
				Update();
		}





		private void DrawBackground( Graphics g, Rectangle drawSize ) {

			// Background Image
			if( BackgroundImage != null ) {
				Rectangle srcRec, dstRec;
				if( BackgroundImageMode <= 0 ) { // anpassen
					srcRec = new Rectangle( BackgroundImageSrcX, BackgroundImageSrcY, BackgroundImage.Width, BackgroundImage.Height );
					dstRec = new Rectangle( drawSize.X + BackgroundImageDstX, drawSize.Y + BackgroundImageDstY, drawSize.Width, drawSize.Height );
				} else { // ausschneiden
					int w = (int)drawSize.Width.Percent( BackgroundImageDstX );
					int h = (int)drawSize.Height.Percent( BackgroundImageDstY );
					srcRec = new Rectangle( BackgroundImageSrcX, BackgroundImageSrcY, w, h );
					dstRec = new Rectangle( drawSize.X, drawSize.Y, drawSize.Width, drawSize.Height );
				}
				g.DrawImage( BackgroundImage, dstRec, srcRec, GraphicsUnit.Pixel );
			}

			// Background Gradient
			Brush gradientBrush = new LinearGradientBrush( drawSize, Color.FromArgb( 255 - BackgroundOpacity, BackgroundGradient1 ), Color.FromArgb( 255 - BackgroundOpacity, BackgroundGradient2 ), BackgroundGradientMode );
			g.FillRectangle( gradientBrush, drawSize );

			// Ellipse Shine
			Rectangle rec = new Rectangle( drawSize.X - ( drawSize.Width / 3 ), drawSize.Y - drawSize.Height - ( drawSize.Height / 2 ), drawSize.Width + ( ( drawSize.Width / 3 ) * 2 ), drawSize.Height * 2 );
			g.FillEllipse( new SolidBrush( Color.FromArgb( 255 - BackgroundOverlayOpacity, BackgroundOverlayColor ) ), rec );
		}

		private void DrawShaiyaDetails( Graphics g, Rectangle drawSize ) {
			Point stringStart;
			SizeF mesure;

			// never Initialized
			if( ShaiyaName == null || ShaiyaLevel == null )
				return;

			// Icon
			if( ShaiyaClass != null ) {
				stringStart = new Point( drawSize.X + ShaiyaClassPadRight, drawSize.Y + ( drawSize.Height / 2 ) - ( ShaiyaClassHeight / 2 ) + ShaiyaClassPadTop );
				g.DrawImage( ShaiyaClass, new Rectangle( stringStart.X, stringStart.Y, ShaiyaClassWidth, ShaiyaClassHeight ) );
			}

			// Name
			if( ShaiyaName.Trim().Length > 0 ) {
				ShaiyaName = ShaiyaName.Trim();
				mesure = g.MeasureString( ShaiyaName, ShaiyaFont );
				stringStart = new Point( drawSize.X + 20 + ShaiyaNamePadRight, drawSize.Y + ( drawSize.Height / 2 ) - (int)( mesure.Height / 2f ) + ShaiyaNamePadTop );
				if( ShaiyaClass != null )
					stringStart.X += ShaiyaClassWidth;
				if( ShaiyaTextBorder == true )
					g.DrawStringBordered( ShaiyaName, ShaiyaFont, new SolidBrush( ShaiyaTextColor ), new SolidBrush( Color.FromArgb( 255 - ShaiyaTextBorderAlpha, ShaiyaTextBorderColor ) ), stringStart.X, stringStart.Y );
				else
					g.DrawString( ShaiyaName, ShaiyaFont, new SolidBrush( ShaiyaTextColor ), stringStart.X, stringStart.Y );

				// Level
				if( ShaiyaLevel.Trim().Length > 0 ) {
					ShaiyaLevel = ShaiyaLevel.Trim();
					int levelPad = (int)mesure.Width + 10 + ShaiyaLevelPadRight;
					mesure = g.MeasureString( ShaiyaName, ShaiyaFont );
					stringStart = new Point( stringStart.X + levelPad, drawSize.Y + ( drawSize.Height / 2 ) - (int)( mesure.Height / 2f ) + ShaiyaLevelPadTop );
					if( ShaiyaTextBorder == true )
						g.DrawStringBordered( ShaiyaLevel, ShaiyaFont, new SolidBrush( ShaiyaTextColor ), new SolidBrush( Color.FromArgb( 255 - ShaiyaTextBorderAlpha, ShaiyaTextBorderColor ) ), stringStart.X, stringStart.Y );
					else
						g.DrawString( ShaiyaLevel, ShaiyaFont, new SolidBrush( ShaiyaTextColor ), stringStart.X, stringStart.Y );
				}
			}

		}

		private void DrawCustomString( Graphics g, Rectangle drawSize ) {
			// never Initialized
			if( CustomText == null || CustomFont == null )
				return;

			Point stringStart = new Point( drawSize.X + drawSize.Width + CustomPadRight, drawSize.Y + ( drawSize.Height / 2 ) + CustomPadTop );
			SizeF mesure = g.MeasureString( CustomText, CustomFont );
			stringStart.X -= (int)mesure.Width;
			stringStart.Y -= (int)mesure.Height / 2;
			if( CustomTextBorder == true )
				g.DrawStringBordered( CustomText, CustomFont, new SolidBrush( CustomTextColor ), new SolidBrush( Color.FromArgb( 255 - CustomTextBorderAlpha, CustomTextBorderColor ) ), stringStart.X, stringStart.Y );
			else
				g.DrawString( CustomText, CustomFont, new SolidBrush( CustomTextColor ), stringStart.X, stringStart.Y );
		}

		private void DrawForeground( Graphics g, Rectangle drawSize ) {
			if( BackgroundBorder == false || BackgroundBorderColor == null )
				return;

			g.DrawRectangle( new Pen( BackgroundBorderColor ), drawSize.X, drawSize.Y, drawSize.Width - 1, drawSize.Height - 1 );
		}





		private void LoadFonts( ComboBox Box ) {
			Box.Items.Clear();
			foreach( string Fontname in mFontNames ) {
				FontFamily ff = Helper.LoadFont( Fontname );
				if( ff != null ) {
					Box.Items.Add( Fontname );
					mFonts.Add( Fontname, ff );
				}
			}
		}



	}

}
