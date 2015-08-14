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
using System.Drawing.Imaging;

namespace Shaiya_Signatur_Generator {

	[Serializable]
	public enum EDrawOrder {
		Signatur_Rand,
		Custom_Text,
		Charakter_Details,
		Hintergrund_Überlagerung,
		Hintergrund_Verlauf,
		Hintergrund_Image
	}

	[Serializable]
	public class CustomSettingSet {
		public int PadRight = 10;
		public int PadTop = 0;
		public string Text = "Shaiya Signatur Generator";
		public int BorderAlpha = 0;
		public bool TextBorder = true;
		public float Fontsize = 10;
		[XmlIgnore]
		public Font Font;
		[XmlElement( ElementName = "Font" )]
		public int XmlFont = -1;
	}

	[Serializable()]
	[XmlInclude( typeof( Bitmap ) )]
	[XmlInclude( typeof( LinearGradientMode ) )]
	public class Signatur {
		#region Properties
		public int Width = 350;
		public int Height = 20;

		List<CustomSettingSet> CustomTexts = new List<CustomSettingSet>();

		public LinearGradientMode BackgroundGradientMode = LinearGradientMode.Horizontal;
		public int BackgroundOverlayOpacity = 200;
		public int BackgroundOverlayHeight = 30;
		public bool BackgroundBorder = false;
		public int BackgroundOpacity = 0;


		public int ShaiyaTextBorderAlpha = 0;
		public bool ShaiyaTextBorder = true;

		public string ShaiyaName;
		public int ShaiyaNamePadRight = 10;
		public int ShaiyaNamePadTop = 0;
		public float ShaiyaFontsize = 10;

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
		public int BackgroundCorner = 0;
		public int BackgroundImageSrcX = 0;
		public int BackgroundImageSrcY = 0;
		public int BackgroundImageDstX = 0;
		public int BackgroundImageDstY = 0;
		public int BackgroundImageMode = 0;
		public int BackgroundImageOpacity = 0;

		public List<EDrawOrder> DrawOrder = new List<EDrawOrder>();

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


		public Signatur() {
		}

		public Signatur( System.Reflection.Assembly Asm, PictureBox picBox, ComboBox Box ) {
			ReInitialize( Asm, picBox, Box );
		}



		public void ReInitialize( System.Reflection.Assembly Asm, PictureBox picBox, ComboBox Box ) {
			Assembly = Asm;
			mPicBox = picBox;

			LoadFonts( Box );

			DrawOrder.Clear();
			Array draws = Enum.GetValues( typeof( EDrawOrder ) );
			for( int i = 0; i < draws.Length; i++ )
				DrawOrder.Add( (EDrawOrder)draws.GetValue( i ) );
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
				g.InterpolationMode = InterpolationMode.HighQualityBicubic;
				using( GraphicsPath gp = new GraphicsPath() ) {
					if( BackgroundCorner > 0 )
						gp.AddRectangleRounded( drawSize, BackgroundCorner );
					else
						gp.AddRectangle( drawSize );
					g.SetClip( gp );
				}

				for( int i = DrawOrder.Count - 1; i >= 0; i-- ) {
					switch( DrawOrder[ i ] ) {
						case EDrawOrder.Signatur_Rand:
							DrawForeground( g, drawSize );
							break;
						case EDrawOrder.Custom_Text:
							DrawCustomString( g, drawSize );
							break;
						case EDrawOrder.Charakter_Details:
							DrawShaiyaDetails( g, drawSize );
							break;
						case EDrawOrder.Hintergrund_Image:

							DrawBackgroundImage( g, drawSize );
							break;
						case EDrawOrder.Hintergrund_Überlagerung:
							DrawBackgroundOverlay( g, drawSize );
							break;
						case EDrawOrder.Hintergrund_Verlauf:
							DrawBackgroundGradient( g, drawSize );
							break;
					}

				}
			}

			if( SetImage == false )
				return;

			mPicBox.Image = ImageObj.Clone() as Image;
			mPicBox.Invalidate();
			ImageObj.Dispose();
		}

		public void SetShaiyaFont( string Fontname, float Size, bool update, int index ) {
			ShaiyaFontsize = Size;
			ShaiyaFont = new Font( mFonts[ Fontname ], ShaiyaFontsize, FontStyle.Regular, GraphicsUnit.World );
			XmlShaiyaFont = index;
			if( update == true )
				Update();
		}

		public void SetCustomFont( string Fontname, float Size, bool update, int index, int num ) {
			if( CustomTexts.Count - 1 < num )
				return;

			CustomTexts[ num ].Fontsize = Size;
			CustomTexts[ num ].Font = new Font( mFonts[ Fontname ], CustomTexts[ num ].Fontsize, FontStyle.Regular, GraphicsUnit.World );
			CustomTexts[ num ].XmlFont = index;
			if( update == true )
				Update();
		}




		private void DrawBackgroundImage( Graphics g, Rectangle drawSize ) {
			if( BackgroundImage == null )
				return;
			// BackgroundImageOpacity
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

			if( BackgroundImageOpacity > 0 ) {
				ImageAttributes attributes = new ImageAttributes();
				ColorMatrix matrix = new ColorMatrix();
				matrix.Matrix33 = ( (float)(float)( 255 - BackgroundImageOpacity ) / 255.0f );

				attributes.SetColorMatrix( matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap );
				g.DrawImage( BackgroundImage, dstRec, srcRec.X, srcRec.Y, srcRec.Width, srcRec.Height, GraphicsUnit.Pixel, attributes );
				return;
			}

			g.DrawImage( BackgroundImage, dstRec, srcRec.X, srcRec.Y, srcRec.Width, srcRec.Height, GraphicsUnit.Pixel );
		}

		private void DrawBackgroundGradient( Graphics g, Rectangle drawSize ) {
			Brush gradientBrush = new LinearGradientBrush( drawSize, Color.FromArgb( 255 - BackgroundOpacity, BackgroundGradient1 ), Color.FromArgb( 255 - BackgroundOpacity, BackgroundGradient2 ), BackgroundGradientMode );
			g.FillRectangle( gradientBrush, drawSize );
		}

		private void DrawBackgroundOverlay( Graphics g, Rectangle drawSize ) {
			if( BackgroundOverlayHeight <= 0 || BackgroundOverlayOpacity >= 255 )
				return;

			Rectangle rec = new Rectangle( drawSize.X, drawSize.Y + drawSize.Height - BackgroundOverlayHeight, drawSize.Width, BackgroundOverlayHeight );
			Brush shineBrush = new LinearGradientBrush( rec, Color.Transparent, Color.FromArgb( 255 - BackgroundOverlayOpacity, BackgroundOverlayColor ), LinearGradientMode.Vertical );

			g.FillRectangle( shineBrush, rec );

			/*
			// Ellipse Shine
			Rectangle rec = new Rectangle( drawSize.X - ( drawSize.Width / 3 ), drawSize.Y - drawSize.Height - ( drawSize.Height / 2 ), drawSize.Width + ( ( drawSize.Width / 3 ) * 2 ), drawSize.Height * 2 );
			g.FillEllipse( new SolidBrush( Color.FromArgb( 255 - BackgroundOverlayOpacity, BackgroundOverlayColor ) ), rec );
			*/
		}

		private void DrawShaiyaDetails( Graphics g, Rectangle drawSize ) {
			Point stringStart;
			SizeF mesure;
			int autoBottomPad = -5;

			// never Initialized
			if( ShaiyaName == null || ShaiyaLevel == null )
				return;

			// Icon
			if( ShaiyaClass != null ) {
				stringStart = new Point( drawSize.X + ShaiyaClassPadRight, drawSize.Y + drawSize.Height - ShaiyaClassHeight + autoBottomPad + ShaiyaClassPadTop );
				g.DrawImage( ShaiyaClass, new Rectangle( stringStart.X, stringStart.Y, ShaiyaClassWidth, ShaiyaClassHeight ) );
			}

			// Name
			if( ShaiyaName.Trim().Length > 0 ) {
				ShaiyaName = ShaiyaName.Trim();
				mesure = g.MeasureString( ShaiyaName, ShaiyaFont );
				stringStart = new Point( drawSize.X + 20 + ShaiyaNamePadRight, drawSize.Y + drawSize.Height - (int)mesure.Height + autoBottomPad + ShaiyaNamePadTop );
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
					stringStart = new Point( stringStart.X + levelPad, drawSize.Y + drawSize.Height - (int)mesure.Height + autoBottomPad + ShaiyaLevelPadTop );
					if( ShaiyaTextBorder == true )
						g.DrawStringBordered( ShaiyaLevel, ShaiyaFont, new SolidBrush( ShaiyaTextColor ), new SolidBrush( Color.FromArgb( 255 - ShaiyaTextBorderAlpha, ShaiyaTextBorderColor ) ), stringStart.X, stringStart.Y );
					else
						g.DrawString( ShaiyaLevel, ShaiyaFont, new SolidBrush( ShaiyaTextColor ), stringStart.X, stringStart.Y );
				}
			}

		}

		private void DrawCustomString( Graphics g, Rectangle drawSize ) {
			if( CustomTexts.Count == 0 )
				return;

			for( int i = 0; i < CustomTexts.Count; i++ ) {
				CustomSettingSet set = CustomTexts[ i ];
				Point stringStart = new Point( drawSize.X + drawSize.Width + set.PadRight, drawSize.Y + ( drawSize.Height / 2 ) + set.PadTop );
				SizeF mesure = g.MeasureString( set.Text, set.Font );
				stringStart.X -= (int)mesure.Width;
				stringStart.Y -= (int)mesure.Height / 2;
				if( set.TextBorder == true )
					g.DrawStringBordered( set.Text, set.Font, new SolidBrush( CustomTextColor ), new SolidBrush( Color.FromArgb( 255 - set.BorderAlpha, CustomTextBorderColor ) ), stringStart.X, stringStart.Y );
				else
					g.DrawString( set.Text, set.Font, new SolidBrush( CustomTextColor ), stringStart.X, stringStart.Y );
			}
		}

		private void DrawForeground( Graphics g, Rectangle drawSize ) {
			if( BackgroundBorder == false || BackgroundBorderColor == null )
				return;

			if( BackgroundCorner > 0 )
				g.DrawRectangleRounded( new Pen( BackgroundBorderColor ), BackgroundCorner, new Rectangle( drawSize.X, drawSize.Y, drawSize.Width - 1, drawSize.Height - 1 ) );
			else
				g.DrawRectangle( new Pen( BackgroundBorderColor ), drawSize.X, drawSize.Y, drawSize.Width - 1, drawSize.Height - 1 );

		}





		private void LoadFonts( ComboBox Box ) {
			Helper.ClearFonts();
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
