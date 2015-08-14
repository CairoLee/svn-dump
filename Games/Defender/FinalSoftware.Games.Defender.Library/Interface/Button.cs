using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalSoftware.Games.Defender.Library.Interface {

	public class Button {
		protected int mPad;
		protected string mLabel;
		protected string mTooltip;
		protected Rectangle mArea;
		protected Texture2D mTexUp, mTexDown;
		protected bool mDown;
		protected float mLabelScale = 1.0f;
		protected float mLabelX, mLabelY;
		protected bool mShow = false;

		public string Label {
			get { return mLabel; }
		}

		public Vector2 LabelPosition {
			get { return new Vector2(mLabelX, mLabelY); }
		}

		public bool Down {
			get { return mDown; }
		}

		public Rectangle Area {
			get { return mArea; }
		}

		public Texture2D Texture {
			get {
				if (mDown)
					return mTexDown;
				else
					return mTexUp;
			}
		}

		public float LabelScale {
			get { return mLabelScale; }
		}

		public string Tooltip {
			get { return mTooltip; }
		}

		public bool Show {
			get { return mShow; }
			set { mShow = value; }
		}


		public Button(string label, SpriteFont font, Rectangle area, Texture2D texUp, Texture2D texDown, bool down, string tooltip) {
			mLabel = label;
			mArea = area;
			mTooltip = tooltip;
			mTexUp = texUp;
			mTexDown = texDown;
			mDown = down;
			mPad = (int)(area.Width * .05);

			FitLabel(font);
		}


		private void FitLabel(SpriteFont font) {
			float labelWidth = font.MeasureString(mLabel).X;
			float labelHeight = font.MeasureString(mLabel).Y;

			while (labelWidth * mLabelScale + 2 * mPad > mArea.Width || labelHeight * mLabelScale + 2 * mPad > mArea.Height)
				mLabelScale -= 0.01f;

			mLabelX = mArea.X + (mArea.Width - labelWidth * mLabelScale) / 2;
			mLabelY = mArea.Y + (mArea.Height - labelHeight * mLabelScale) / 2;
		}


		public virtual void Press() {
			mDown = true;
		}

		public virtual void Release() {
			mDown = false;
		}


	}
}
