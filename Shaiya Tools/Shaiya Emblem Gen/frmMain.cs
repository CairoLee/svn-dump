using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace ShaiyaEmblemGen {

	public partial class frmMain : Form {
		private Size mEmblemSize = new Size( 64, 64 );
		private Point mEmblemPosition = new Point( 89, 115 );

		public frmMain() {
			InitializeComponent();

			InitColors();
			InitImages();
			InitCombos();
		}

		private void InitImages() {
			System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();

			for( int i = 0; i < 33; i++ ) {
				if( i < 20 ) {
					imagesBG.Images.Add( Bitmap.FromStream( asm.GetManifestResourceStream( "ShaiyaEmblemGen.Resources.bg_" + i + ".png" ) ) );
					imagesFG.Images.Add( Bitmap.FromStream( asm.GetManifestResourceStream( "ShaiyaEmblemGen.Resources.fg_" + i + ".png" ) ) );
				}
				imagesSY.Images.Add( Bitmap.FromStream( asm.GetManifestResourceStream( "ShaiyaEmblemGen.Resources.sy_" + i + ".png" ) ) );
			}
		}

		private void InitCombos() {
			for( int i = 0; i < imagesBG.Images.Count; i++ )
				imageBoxBG.Items.Add( new ImageComboItem( i.ToString( "00" ), imageBoxBG.Font, Color.Black, i ) );
			for( int i = 0; i < imagesFG.Images.Count; i++ )
				imageBoxFG.Items.Add( new ImageComboItem( i.ToString( "00" ), imageBoxFG.Font, Color.Black, i ) );
			for( int i = 0; i < imagesSY.Images.Count; i++ )
				imageBoxSY.Items.Add( new ImageComboItem( i.ToString( "00" ), imageBoxSY.Font, Color.Black, i ) );

			imageBoxBG.SelectedIndex = imageBoxFG.SelectedIndex = imageBoxSY.SelectedIndex = 0;
		}

		private void InitColors() {
			Color[] colors = new Color[]{
				Color.FromArgb( 199, 0, 0 ),
				Color.FromArgb( 123, 0, 3 ),
				Color.FromArgb( 211, 73, 3 ),
				Color.FromArgb( 255, 143, 9 ),
				Color.FromArgb( 255, 145, 118 ),
				Color.FromArgb( 40, 0, 0 ),

				Color.FromArgb( 251, 232, 6 ),
				Color.FromArgb( 190, 201, 0 ),
				Color.FromArgb( 120, 120, 0 ),
				Color.FromArgb( 168, 161, 73 ),
				Color.FromArgb( 243, 232, 170 ),
				Color.FromArgb( 39, 40, 0 ),

				Color.FromArgb( 0, 201, 1 ),
				Color.FromArgb( 133, 238, 145 ),
				Color.FromArgb( 52, 112, 48 ),
				Color.FromArgb( 0, 120, 1 ),
				Color.FromArgb( 0, 43, 0 ),
				Color.FromArgb( 0, 44, 47 ),

				Color.FromArgb( 0, 1, 205 ),
				Color.FromArgb( 39, 120, 199 ),
				Color.FromArgb( 36, 203, 195 ),
				Color.FromArgb( 0, 120, 118 ),
				Color.FromArgb( 0, 1, 114 ),
				Color.FromArgb( 1, 1, 39 ),

				Color.FromArgb( 190, 3, 218 ),
				Color.FromArgb( 254, 195, 189 ),
				Color.FromArgb( 194, 125, 192 ),
				Color.FromArgb( 120, 1, 117 ),
				Color.FromArgb( 121, 123, 180 ),
				Color.FromArgb( 45, 0, 41 ),

				Color.FromArgb( 0, 0, 0 ),
				Color.FromArgb( 120, 120, 120 ),
				Color.FromArgb( 200, 200, 200 ),
				Color.FromArgb( 214, 214, 212 ),
				Color.FromArgb( 41, 38, 125 ),
				Color.FromArgb( 255, 255, 255 ),

			};

			colorBG.Colors = colorFG.Colors = colorSY.Colors = colors;
			colorBG.SelectedColor = colorBG.Colors[ 0 ];
			colorFG.SelectedColor = colorBG.Colors[ 6 ];
			colorSY.SelectedColor = colorBG.Colors[ 12 ];

			UpdateEmblem();
		}




		private void ColorBox_ColorChanged( object sender, ColorChangeArgs e ) {
			UpdateEmblem();
		}

		private void ImageBox_SelectedIndexChanged( object sender, EventArgs e ) {
			UpdateEmblem();
		}




		private void UpdateEmblem() {

			if( imageBoxBG.SelectedIndex < 0 || imageBoxFG.SelectedIndex < 0 || imageBoxSY.SelectedIndex < 0 )
				return;

			using( Image img = new Bitmap( imageEmblem.Width, imageEmblem.Height ) ) {
				using( Graphics g = Graphics.FromImage( img ) ) {
					g.DrawImage( SetColorFilter( imagesBG.Images[ imageBoxBG.SelectedIndex ], colorBG.SelectedColor.R, colorBG.SelectedColor.G, colorBG.SelectedColor.B ), mEmblemPosition.X, mEmblemPosition.Y );
					g.DrawImage( SetColorFilter( imagesFG.Images[ imageBoxFG.SelectedIndex ], colorFG.SelectedColor.R, colorFG.SelectedColor.G, colorFG.SelectedColor.B ), mEmblemPosition.X, mEmblemPosition.Y );
					g.DrawImage( SetColorFilter( imagesSY.Images[ imageBoxSY.SelectedIndex ], colorSY.SelectedColor.R, colorSY.SelectedColor.G, colorSY.SelectedColor.B ), mEmblemPosition.X, mEmblemPosition.Y );

					imageEmblem.Image = img.Clone() as Image;
				}
			}

		}

		public Image SetColorFilter( Image _currentBitmap, int ModR, int ModG, int ModB ) {
			Bitmap bmap = (Bitmap)_currentBitmap.Clone();
			Color c;
			for( int i = 0; i < bmap.Width; i++ ) {
				for( int j = 0; j < bmap.Height; j++ ) {
					c = bmap.GetPixel( i, j );
					if( c.A == 0 ) // transparent
						continue;
					if( c.R < 150 || c.G < 150 || c.B < 150 ) {
						bmap.SetPixel( i, j, Color.FromArgb( c.A, 0, 0, 0 ) );
						continue;
					}

					bmap.SetPixel( i, j, Color.FromArgb( c.A, ModR, ModG, ModB ) );
				}
			}

			return (Bitmap)bmap.Clone();
		}

		public Image ChangePalette( Image _currentBitmap, int ModR, int ModG, int ModB ) {
			MemoryStream stream = new System.IO.MemoryStream();
			_currentBitmap.Save( stream, ImageFormat.Gif );
			Bitmap bmap = new Bitmap( stream );

			Color c;
			for( int i = 0; i < bmap.Palette.Entries.Length; i++ ) {
				c = bmap.Palette.Entries[ i ];
				if( c.A == 0 ) // transparent
					continue;
				if( c.R < 150 && c.G < 150 && c.B < 150 )
					continue;
				bmap.Palette.Entries[ i ] = Color.FromArgb( (byte)ModR.Clamp( 0, 255 ), (byte)ModG.Clamp( 0, 255 ), (byte)ModB.Clamp( 0, 255 ) );
			}

			return (Bitmap)bmap.Clone();
		}

		private void colorBG_ColorChanged( object sender, ColorChangeArgs e ) {

		}

		private void imageEmblem_Click( object sender, EventArgs e ) {
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "PNG Image (*.png)|*.png";
			if( dlg.ShowDialog() != DialogResult.OK )
				return;

			string pathDir = Path.GetDirectoryName( dlg.FileName );
			string pathFile = Path.GetFileNameWithoutExtension( dlg.FileName );
			SaveImages( Path.Combine( pathDir, pathFile ) );
		}

		private void SaveImages( string path ) {
			using( Image imgFull = new Bitmap( imageEmblem.Width, imageEmblem.Height ) ) {
				using( Graphics g = Graphics.FromImage( imgFull ) ) {
					g.DrawImage( imageEmblem.BackgroundImage, 0, 0, imageEmblem.Width, imageEmblem.Height );
					g.DrawImage( imageEmblem.Image, 0, 0 );
					
					imgFull.Save( path + "_full.png", ImageFormat.Png );
				}
			}

			using( Image imgFull = new Bitmap( mEmblemSize.Width, mEmblemSize.Height ) ) {
				using( Graphics g = Graphics.FromImage( imgFull ) ) {
					g.DrawImage( imageEmblem.Image, new Rectangle( 0, 0, mEmblemSize.Width, mEmblemSize.Height ), new Rectangle( mEmblemPosition.X, mEmblemPosition.Y, mEmblemSize.Width, mEmblemSize.Height ), GraphicsUnit.Pixel );

					imgFull.Save( path + "_stripped.png", ImageFormat.Png );
				}
			}

		}

	}

	public static class MathExtensions {
		public static int Clamp( this int Value, int min, int max ) {
			Value = Math.Max( Value, min );
			Value = Math.Min( max, Value );
			return Value;
		}
	}

}
