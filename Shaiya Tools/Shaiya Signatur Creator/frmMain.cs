using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Shaiya_Signatur_Creator {

	public partial class frmMain : Form {
		private Font mSignaFont;
		private Image mAvatar = null;


		public frmMain() {
			InitializeComponent();

			mSignaFont = new Font( "Arial", 10f, FontStyle.Regular, GraphicsUnit.World );
		}


		#region MenuProgram Events
		private void MenuProgramClose_Click( object sender, EventArgs e ) {
			this.Close();
		} 
		#endregion

		#region MenuImage Events
		private void MenuImageLoadAva_Click( object sender, EventArgs e ) {
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "PNG Image (*.png)|*.png";
			if( dlg.ShowDialog() != DialogResult.OK )
				return;
		}

		private void MenuImageSave_Click( object sender, EventArgs e ) {
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "PNG Image (*.png)|*.png";
			if( dlg.ShowDialog() != DialogResult.OK )
				return;

			SaveImage( dlg.FileName );
			MessageBox.Show( "Dein Bild wurde erfolgreich gespeichert!", "Speichern erfolgreich", MessageBoxButtons.OK, MessageBoxIcon.Information );
		}
		#endregion

		private void Controls_TextChanged( object sender, EventArgs e ) {
			UpdateImage();
		}





		private void UpdateImage() {
			using( Bitmap overlayImg = new Bitmap( picPreview.Width, picPreview.Height ) ) {
				using( Graphics g = Graphics.FromImage( overlayImg ) ) {
					string name = txtName.Text.Trim();
					int level = SafeParse( txtLevel.Text );
					int hp = SafeParse( txtHP.Text );
					int mp = SafeParse( txtMP.Text );
					int ap = SafeParse( txtAP.Text );

					// Background
					g.DrawImage( Properties.Resources.background, new Rectangle( 0, 0, overlayImg.Width, overlayImg.Height ), new Rectangle( 0, 0, Properties.Resources.background.Width, Properties.Resources.background.Height ), GraphicsUnit.Pixel );

					// Name
					if( name.Length > 0 )
						g.DrawString( name, mSignaFont, Brushes.White, new Point( 137 - (int)( g.MeasureString( name, mSignaFont ).Width / 2 ), 21 ) );

					// Level
					g.DrawString( level.ToString(), mSignaFont, Brushes.White, new Point( 65, 21 ) ); // 31

					// HP
					string hpString = string.Format( "{0}/{0}", hp );
					int hpDiff = (int)( g.MeasureString( hpString, mSignaFont ).Width / 2 );
					g.DrawString( hpString, mSignaFont, Brushes.Black, new Point( 133 - hpDiff, 40 ) );
					g.DrawString( hpString, mSignaFont, Brushes.White, new Point( 132 - hpDiff, 39 ) );
					
					// MP
					string mpString = string.Format( "{0}/{0}", mp );
					int mpDiff = (int)( g.MeasureString( mpString, mSignaFont ).Width / 2 );
					g.DrawString( mpString, mSignaFont, Brushes.Black, new Point( 133 - mpDiff, 56 ) );
					g.DrawString( mpString, mSignaFont, Brushes.White, new Point( 132 - mpDiff, 55 ) );

					// AP
					string apString = string.Format( "{0}/{0}", ap );
					int apDiff = (int)( g.MeasureString( apString, mSignaFont ).Width / 2 );
					g.DrawString( apString, mSignaFont, Brushes.Black, new Point( 133 - apDiff, 72 ) );
					g.DrawString( apString, mSignaFont, Brushes.White, new Point( 132 - apDiff, 71 ) );
				}

				picPreview.Image = overlayImg.Clone() as Image;
			}
		}

		private void SaveImage( string p ) {
			picPreview.Image.Save( p );
		} 

		private int SafeParse( string Text ) {
			int num;
			if( int.TryParse( Text, out num ) == false )
				return 0;
			return num;
		}

	}

}
