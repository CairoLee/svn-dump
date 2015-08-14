using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace eAthenaStudio.Plugins.EditSprite.Controls {

	public class ZoomableSpriteFrame : PictureBox {
		private float mZoom = 1f, mZoomOld = 0f;
		private int mPaddingLeft = 40;
		private int mPaddingBottom = 20;
		private Bitmap mSpriteFrame;
		private Color mHoverColor = Color.Transparent;
		private Color mSelectedColor;

		public Bitmap SpriteFrame {
			get { return mSpriteFrame; }
			set {
				mSpriteFrame = value;
				UpdateImage();
			}
		}

		public float Zoom {
			get { return mZoom; }
			set {
				mZoom = Math.Max(1, Math.Min(20, value));
				UpdateImage();
			}
		}

		public int PaddingLeft {
			get { return mPaddingLeft; }
			set {
				mPaddingLeft = value;
				UpdateImage();
			}
		}

		public int PaddingBottom {
			get { return mPaddingBottom; }
			set {
				mPaddingBottom = value;
				UpdateImage();
			}
		}

		public Color HoverColor {
			get { return mHoverColor; }
			set {
				mHoverColor = value;
				UpdateImage();
			}
		}

		public Color SelectedColor {
			get { return mSelectedColor; }
			set {
				mSelectedColor = value;
				UpdateImage();
			}
		}


		public ZoomableSpriteFrame() {
			Font = new Font("Tahoma", 9f);
			ForeColor = Color.White;
			SizeMode = PictureBoxSizeMode.CenterImage;
		}


		// dirty hack to recalc size & location >.<
		public void DoResize() {
			// needed?
			UpdateImage();
		}


		public void OnMouseScroll(MouseEventArgs e) {
			Zoom += (float)e.Delta / 1000f;
			UpdateImage();
		}



		private void UpdateImage() {
			Image = Rescale();
		}

		private Bitmap Rescale() {
			if (mSpriteFrame == null) {
				return null;
			}

			SizeF newSize = new SizeF((float)mSpriteFrame.Width * mZoom, (float)mSpriteFrame.Height * mZoom);
			float pixel = 1f * mZoom;
			Bitmap b = new Bitmap((int)newSize.Width, (int)newSize.Height);
			bool hover = (SelectedColor != Color.Transparent && HoverColor != Color.Transparent);
			using (Graphics g = Graphics.FromImage(b)) {
				for (int x = 0; x < mSpriteFrame.Width; x++)
					for (int y = 0; y < mSpriteFrame.Height; y++) {
						Color drawColor = mSpriteFrame.GetPixel(x, y);
						if (hover && SelectedColor == drawColor)
							drawColor = HoverColor;
						g.FillRectangle(new SolidBrush(drawColor), new RectangleF((float)x * pixel, (float)y * pixel, pixel, pixel));
					}
			}

			mZoomOld = mZoom;
			return b;
		}

	}

}
