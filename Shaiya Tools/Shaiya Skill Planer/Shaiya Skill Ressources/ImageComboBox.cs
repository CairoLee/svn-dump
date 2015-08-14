using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Ssc {

	public class ImageComboBox : ComboBox {
		private ImageList mImageList = null;
		private int mImagePlace = 0;

		public ImageList ImageList {
			get { return mImageList; }
			set {
				mImageList = value;
				if( mImageList != null )
					ItemHeight = mImageList.ImageSize.Height;
			}
		}

		public int ImagePlace {
			get { return mImagePlace; }
			set { mImagePlace = value; }
		}


		public ImageComboBox() {
			DrawMode = DrawMode.OwnerDrawFixed;
			DropDownStyle = ComboBoxStyle.DropDownList;
		}


		public int IndexOf( string Text ) {
			for( int i = 1; i < Items.Count; i++ ) {
				ImageComboItem item = ( Items[ i ] as ImageComboItem );
				if( item.Text == Text )
					return i;
			}
			return -1;
		}

		public bool Contains( string Text ) {
			return IndexOf( Text ) != -1;
		}

		protected override void OnDrawItem( System.Windows.Forms.DrawItemEventArgs e ) {
			base.OnDrawItem( e );

			e.DrawBackground();
			e.DrawFocusRectangle();

			if( e.Index < 0 )
				return;

			if( !( this.Items[ e.Index ] is ImageComboItem ) ) {
				e.Graphics.DrawString( Items[ e.Index ].ToString(), e.Font, new SolidBrush( e.ForeColor ), e.Bounds.Left, e.Bounds.Top );
				return;
			}

			ImageComboItem CurrItem = this.Items[ e.Index ] as ImageComboItem;
			SizeF fontSize = e.Graphics.MeasureString( CurrItem.Text, CurrItem.Font );
			SolidBrush brush = new SolidBrush( CurrItem.ForeColor );
			int imageX = e.Bounds.Left;
			if( CurrItem.Text != string.Empty && CurrItem.TextAlign == EImageComboItemTextAlign.Left )
				e.Graphics.DrawString( CurrItem.Text, CurrItem.Font, brush, e.Bounds.Left, e.Bounds.Top + ( mImageList.ImageSize.Height / 2 ) - fontSize.Height / 2 );

			if( mImageList != null && CurrItem.ImageIndex != -1 ) {
				if( CurrItem.TextAlign == EImageComboItemTextAlign.Left )
					imageX += (int)fontSize.Width;

				if( mImagePlace > imageX )
					imageX = mImagePlace;
				ImageList.Draw( e.Graphics, imageX, e.Bounds.Top, CurrItem.ImageIndex );
			}

			if( CurrItem.Text != string.Empty && CurrItem.TextAlign == EImageComboItemTextAlign.Right ) {
				imageX += ImageList.ImageSize.Width + 10;
				e.Graphics.DrawString( CurrItem.Text, CurrItem.Font, brush, imageX, e.Bounds.Top + ( mImageList.ImageSize.Height / 2 ) - fontSize.Height / 2 );
			}

		}

	}


	public enum EImageComboItemTextAlign {
		Left,
		Right,
	}

	public class ImageComboItem {
		private Color mForeColor = Color.Black;
		private int mImageIndex = -1;
		private object mTag = null;
		private string mText = "";
		private Font mFont;
		private EImageComboItemTextAlign mTextAlign = EImageComboItemTextAlign.Left;

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

		public EImageComboItemTextAlign TextAlign {
			get { return mTextAlign; }
			set { mTextAlign = value; }
		}


		public ImageComboItem( string Text, Font Font, Color ForeColor ) {
			mText = Text;
			mFont = Font;
			mForeColor = ForeColor;
		}

		public ImageComboItem( string Text, Font Font, Color ForeColor, EImageComboItemTextAlign Align ) {
			mText = Text;
			mFont = Font;
			mForeColor = ForeColor;
			mTextAlign = Align;
		}

		public ImageComboItem( string Text, Font Font, Color ForeColor, int ImageIndex ) {
			mText = Text;
			mFont = Font;
			mForeColor = ForeColor;
			mImageIndex = ImageIndex;
		}

		public ImageComboItem( string Text, Font Font, Color ForeColor, int ImageIndex, EImageComboItemTextAlign Align ) {
			mText = Text;
			mFont = Font;
			mForeColor = ForeColor;
			mImageIndex = ImageIndex;
			mTextAlign = Align;
		}

		public ImageComboItem( string Text, Font Font, Color ForeColor, int ImageIndex, EImageComboItemTextAlign Align, object Tag ) {
			mText = Text;
			mFont = Font;
			mForeColor = ForeColor;
			mImageIndex = ImageIndex;
			mTextAlign = Align;
			mTag = Tag;
		}


		public override string ToString() {
			return mText;
		}

	}



}
