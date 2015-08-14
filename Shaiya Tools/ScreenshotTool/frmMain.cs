using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Shaiya_Screenshot_Tool {

	public partial class frmMain : Form {
		private Image mScreenshot;

		private RectangleF mPosition1 = RectangleF.Empty;
		private RectangleF mPosition2 = RectangleF.Empty;

		private int mSelectedTextLine = 0;

		public int SelectedTextLine {
			get { return mSelectedTextLine; }
			set {
				mSelectedTextLine = value;
				UpdateImage();
			}
		}


		public frmMain() {
			InitializeComponent();
		}

		#region Menu Program Events
		private void MenuProgramExit_Click( object sender, EventArgs e ) {
			this.Close();
		}

		private void MenuProgramSave_Click( object sender, EventArgs e ) {
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "JPG Image|*.jpg";
			if( dlg.ShowDialog() != DialogResult.OK )
				return;

			DrawImage( false ).Save( dlg.FileName );
		}

		private void MenuProgramOpen_Click( object sender, EventArgs e ) {
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "Image File (*.jpg;*.jpeg;*.bmp;*.png)|*.jpg;*.jpeg;*.bmp;*.png";
			if( dlg.ShowDialog() != DialogResult.OK )
				return;

			mScreenshot = Bitmap.FromFile( dlg.FileName );
			UpdateImage();
		}
		#endregion

		#region Form Events
		private void frmMain_Load( object sender, EventArgs e ) {
			InitializeColorBox();
		}

		private void frmMain_FormClosing( object sender, FormClosingEventArgs e ) {
			Properties.Settings.Default.Save();
		}

		private void frmMain_KeyDown( object sender, KeyEventArgs e ) {
			if( ( e.Modifiers & Keys.Control ) != Keys.Control )
				return;
			if( SelectedTextLine == 0 )
				return;

			switch( e.KeyCode ) {
				case Keys.Left:
					if( SelectedTextLine == 1 )
						Properties.Settings.Default.Addition1 = new Point( Properties.Settings.Default.Addition1.X - 1, Properties.Settings.Default.Addition1.Y );
					else
						Properties.Settings.Default.Addition2 = new Point( Properties.Settings.Default.Addition2.X - 1, Properties.Settings.Default.Addition2.Y );
					e.Handled = true;
					break;
				case Keys.Right:
					if( SelectedTextLine == 1 )
						Properties.Settings.Default.Addition1 = new Point( Properties.Settings.Default.Addition1.X + 1, Properties.Settings.Default.Addition1.Y );
					else
						Properties.Settings.Default.Addition2 = new Point( Properties.Settings.Default.Addition2.X + 1, Properties.Settings.Default.Addition2.Y );
					e.Handled = true;
					break;
				case Keys.Up:
					if( SelectedTextLine == 1 )
						Properties.Settings.Default.Addition1 = new Point( Properties.Settings.Default.Addition1.X, Properties.Settings.Default.Addition1.Y - 1 );
					else
						Properties.Settings.Default.Addition2 = new Point( Properties.Settings.Default.Addition2.X, Properties.Settings.Default.Addition2.Y - 1 );
					e.Handled = true;
					break;
				case Keys.Down:
					if( SelectedTextLine == 1 )
						Properties.Settings.Default.Addition1 = new Point( Properties.Settings.Default.Addition1.X, Properties.Settings.Default.Addition1.Y + 1 );
					else
						Properties.Settings.Default.Addition2 = new Point( Properties.Settings.Default.Addition2.X, Properties.Settings.Default.Addition2.Y + 1 );
					e.Handled = true;
					break;
			}

			if( e.Handled == true )
				UpdateImage();
		}
		#endregion

		#region Effect Events
		private void Effects_ValueChanged( object sender, EventArgs e ) {
			if( mScreenshot != null )
				UpdateImage();
		}

		private void colLine1_ColorChanged( object sender, ColorChangeArgs e ) {
			UpdateImage();
		}

		private void colLine2_ColorChanged( object sender, ColorChangeArgs e ) {
			UpdateImage();
		}
		#endregion

		#region ScreenPreview Events
		private void screenPreview_MouseClick( object sender, MouseEventArgs e ) {
			if( screenPreview.Image == null || mScreenshot == null )
				return;

			if( InRange( e.Location, mPosition1 ) == false ) {
				if( InRange( e.Location, mPosition2 ) == false ) {
					SelectedTextLine = 0;
					return;
				}
				SelectedTextLine = 2;
				return;
			}
			SelectedTextLine = 1;
		}
		#endregion




		private void InitializeColorBox() {
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

			//colLine1.Colors = colLine2.Colors = colors;
			//colLine1.SelectedColor = colors[ 0 ];
			//colLine2.SelectedColor = colors[ 6 ];
		}

		private void UpdateImage() {
			if( mScreenshot == null )
				return;

			screenPreview.Image = DrawImage( true );
		}

		private Image DrawImage( bool Bordered ) {
			Image img = new Bitmap( mScreenshot.Width, mScreenshot.Height );
			Font drawFont1 = new Font( "Celine Dion Handwriting", (float)numFontSize1.Value );
			Font drawFont2 = new Font( "Arial", (float)numFontSize2.Value );
			SizeF stringSize;
			PointF basePoint;

			using( Graphics g = Graphics.FromImage( img ) ) {
				// Screenshot
				g.DrawImage( mScreenshot, 0, 0 );

				// simple Border?
				if( numBorder.Value > 0 )
					g.DrawRectangle( new Pen( Brushes.Black, (float)numBorder.Value ), (float)numBorder.Value / 2f, (float)numBorder.Value / 2f, img.Width - (int)numBorder.Value, img.Height - (int)numBorder.Value );

				// Mainline
				stringSize = g.MeasureString( txtText1.Text, drawFont1 );
				basePoint = new PointF( mScreenshot.Width + Properties.Settings.Default.Addition1.X - stringSize.Width, mScreenshot.Height + Properties.Settings.Default.Addition1.Y - stringSize.Height );
				mPosition1.X = basePoint.X;
				mPosition1.Y = basePoint.Y;
				mPosition1.Width = stringSize.Width;
				mPosition1.Height = stringSize.Height;
				g.DrawString( txtText1.Text, drawFont1, new SolidBrush( colLine1.SelectedColor ), basePoint );

				// Subline
				stringSize = g.MeasureString( txtText2.Text, drawFont2 );
				basePoint = new PointF( mScreenshot.Width + Properties.Settings.Default.Addition2.X - stringSize.Width, mScreenshot.Height + Properties.Settings.Default.Addition2.Y - stringSize.Height );
				mPosition2.X = basePoint.X;
				mPosition2.Y = basePoint.Y;
				mPosition2.Width = stringSize.Width;
				mPosition2.Height = stringSize.Height;
				g.DrawString( txtText2.Text, drawFont2, new SolidBrush( colLine2.SelectedColor ), basePoint );


				if( Bordered == true ) {
					if( SelectedTextLine == 1 )
						g.DrawRectangle( Pens.Red, mPosition1.X, mPosition1.Y, mPosition1.Width, mPosition1.Height );
					else if( SelectedTextLine == 2 )
						g.DrawRectangle( Pens.Red, mPosition2.X, mPosition2.Y, mPosition2.Width, mPosition2.Height );
				}

			}

			return img;
		}

		private bool InRange( Point p, RectangleF r ) {
			float factorX = ( (float)mScreenshot.Width / (float)screenPreview.Width );
			float factorY = ( (float)mScreenshot.Height / (float)screenPreview.Height );
			PointF rP = new PointF( (float)p.X * factorX, (float)p.Y * factorY );

			if( rP.X < r.X || rP.X > ( r.X + r.Width ) )
				return false;
			if( rP.Y < r.Y || rP.Y > ( r.Y + r.Height ) )
				return false;
			return true;
		}



	}




	#region Program.Main
	static class Program {
		/// <summary>
		/// Der Haupteinstiegspunkt für die Anwendung.
		/// </summary>
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault( false );
			Application.Run( new frmMain() );
		}
	} 
	#endregion

}
