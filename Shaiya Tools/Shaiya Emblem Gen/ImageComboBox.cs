using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace ShaiyaEmblemGen {

	public class ImageComboBox : ComboBox {
		private ImageList mImageList = null;

		public ImageList ImageList {
			get { return mImageList; }
			set {
				mImageList = value;
				ItemHeight = mImageList.ImageSize.Height;
			}
		}


		public ImageComboBox() {
			DrawMode = DrawMode.OwnerDrawFixed;
		}


		protected override void OnDrawItem( System.Windows.Forms.DrawItemEventArgs e ) {
			base.OnDrawItem( e );

			e.DrawBackground();
			e.DrawFocusRectangle();

			if( e.Index < 0 )
				return;

			if( this.Items[ e.Index ] is ImageComboItem ) {
				ImageComboItem CurrItem = (ImageComboItem)this.Items[ e.Index ];
				SizeF fontSize = e.Graphics.MeasureString( CurrItem.Text, CurrItem.Font );
				if( CurrItem.Text != string.Empty )
					e.Graphics.DrawString( CurrItem.Text, CurrItem.Font, new SolidBrush( CurrItem.ForeColor ), e.Bounds.Left, e.Bounds.Top + ( mImageList.ImageSize.Height / 2 ) - ( fontSize.Width / 2 ) );
				if( mImageList == null || CurrItem.ImageIndex == -1 )
					return;

				this.ImageList.Draw( e.Graphics, e.Bounds.Left + (int)fontSize.Width, e.Bounds.Top, CurrItem.ImageIndex );
				return;
			}
			e.Graphics.DrawString( this.Items[ e.Index ].ToString(), e.Font, new SolidBrush( e.ForeColor ), e.Bounds.Left, e.Bounds.Top );

		}

	}


	public class ImageComboItem {
		private Color mForeColor = Color.Black;
		private int mImageIndex = -1;
		private object mTag = null;
		private string mText = "";
		private Font mFont;

		public Color ForeColor {
			get { return mForeColor; }
			set { mForeColor = value; }
		}

		public int ImageIndex {
			get { return mImageIndex; }
			set { mImageIndex = value; }
		}

		public object Tag {
			get { return mTag; }
			set { mTag = value; }
		}

		public string Text {
			get { return mText; }
			set { mText = value; }
		}

		public Font Font {
			get { return mFont; }
			set { mFont = value; }
		}


		public ImageComboItem( string Text, Font Font, Color ForeColor ) {
			mText = Text;
			mFont = Font;
			mForeColor = ForeColor;
		}

		public ImageComboItem( string Text, Font Font, Color ForeColor, int ImageIndex ) {
			mText = Text;
			mFont = Font;
			mForeColor = ForeColor;
			mImageIndex = ImageIndex;
		}


		public override string ToString() {
			return mText;
		}

	}



}
