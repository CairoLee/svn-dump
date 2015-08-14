using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using eAthenaTool.Plugins.EditSprite.Controls;

namespace eAthenaTool.Plugins.EditSprite {

	public partial class frmPaletteEditor : Form {
		private Color[] mPal;

		public event PaletteColorChangedHandler OnColorChanged;

		public frmPaletteEditor( Color[] Palette ) {
			mPal = Palette;

			InitializeComponent();
			InitializePalette();
		}


		private void InitializePalette() {
			for( int i = 0; i < mPal.Length; i++ ) {
				PaletteColor item = new PaletteColor( mPal[ i ] );
				int x = ( ( pnlColors.Controls.Count % 16 ) * item.Width ) + ( ( pnlColors.Controls.Count % 16 ) * 3 );
				int y = ( ( pnlColors.Controls.Count / 16 ) * item.Height ) + ( ( pnlColors.Controls.Count / 16 ) * 3 );
				item.Location = new Point( x, y );
				item.Tag = i;
				item.Click += new EventHandler( PaletteColor_Click );
				item.MouseEnter += new EventHandler( PaletteColor_MouseEnter );
				pnlColors.Controls.Add( item );
			}
		}



		private void PaletteColor_MouseEnter( object sender, EventArgs e ) {
			PaletteColor item = sender as PaletteColor;
			int index = (int)item.Tag;

			lblColorIndex.Text = "Index: " + ( index + 1 );
			lblColorRGB.Text = "Farbe: " + string.Format( "{0}, {1}, {2}", mPal[ index ].R, mPal[ index ].G, mPal[ index ].B );
		}

		private void PaletteColor_Click( object sender, EventArgs e ) {
			PaletteColor item = sender as PaletteColor;
			int index = (int)item.Tag;
			using( ColorDialog dlg = new ColorDialog() ) {
				if( dlg.ShowDialog( this ) != DialogResult.OK || item.Color == dlg.Color )
					return;
				item.Color = dlg.Color;
				if( OnColorChanged != null )
					OnColorChanged( new PaletteColorChangedEventArgs( index, dlg.Color ) );
			}
		}

	}

	public delegate void PaletteColorChangedHandler( PaletteColorChangedEventArgs e );

}
