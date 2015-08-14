using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sprite_Reader {

	public partial class Form1 : Form {
		private SpriteRead SprReader;
		private int SpriteNum = 0;

		public Form1() {
			InitializeComponent();
		}

		private void btnSearch_Click( object sender, EventArgs e ) {
			OpenFileDialog Dlg = new OpenFileDialog();
			Dlg.Filter = "SPR File|*.spr|Image|*.*";
			if( Dlg.ShowDialog() != DialogResult.OK )
				return;

			SprReader = new SpriteRead( this, Dlg.FileName );
			if( SprReader.Sprite.Images[ 0 ].Image == null )
				SprReader.DrawImage( 0 );
			pictureBox1.Image = SprReader.Sprite.Images[ 0 ].Image;

		}

		public void AddStatus( string Line ) {
			AddStatus( Line, Color.Black );
		}

		public void AddStatus( string Line, Color Color ) {
			DateTime Date = DateTime.Now;
			Line = Date.Hour + ":" + Date.Minute + ":" + Date.Second + "| " + Line;

			this.richTextBox1.SelectionFont = new Font( "Tahoma", 8, FontStyle.Regular );
			this.richTextBox1.SelectionColor = Color;
			this.richTextBox1.SelectedText = Line + "\n";
			this.richTextBox1.ScrollToCaret();
			this.richTextBox1.SelectionStart = this.richTextBox1.TextLength;

			this.StatusLabel.Text = Line;
		}


		private void btnImagePrev_Click( object sender, EventArgs e ) {
			if( SprReader == null )
				return;
			if( ( SpriteNum - 1 ) < 0 || ( SpriteNum - 1 ) >= SprReader.Sprite.Images.Length )
				return;

			SpriteNum--;
			AddStatus( "set SpriteNum " + SpriteNum + "/" + SprReader.Sprite.Images.Length );
			if( SprReader.Sprite.Images[ SpriteNum ].Image == null )
				SprReader.DrawImage( SpriteNum );
			pictureBox1.Image = SprReader.Sprite.Images[ SpriteNum ].Image;
		}

		private void btnImageNext_Click( object sender, EventArgs e ) {
			if( SprReader == null )
				return;
			if( ( SpriteNum + 1 ) < 0 || ( SpriteNum + 1 ) >= SprReader.Sprite.Images.Length )
				return;

			SpriteNum++;
			AddStatus( "set SpriteNum " + SpriteNum + "/" + SprReader.Sprite.Images.Length );
			if( SprReader.Sprite.Images[ SpriteNum ].Image == null )
				SprReader.DrawImage( SpriteNum );
			pictureBox1.Image = SprReader.Sprite.Images[ SpriteNum ].Image;
		}

	}

}

