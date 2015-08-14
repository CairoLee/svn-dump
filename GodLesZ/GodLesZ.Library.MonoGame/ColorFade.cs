using Microsoft.Xna.Framework;

namespace GodLesZ.Library.MonoGame {

	/// <summary>
	/// Implements a updateable color fade using lower and higher alpha.
	/// </summary>
	public class ColorFade {
		private float mAlpha = 0f;
		private float mSpeed;
		private byte mMin, mMax;
		private bool mFadeIn = true;

		public byte Alpha {
			get { return (byte)mAlpha; }
		}

		public Color ColorFaded {
			get;
			protected set;
		}

		public Color ColorBase {
			get;
			set;
		}


		/// <summary>
		/// Initialize a new fadeable color.
		/// </summary>
		/// <param name="colorBase">Base color</param>
		/// <param name="min">Min alpha value</param>
		/// <param name="max">max Alpha value</param>
		/// <param name="speed">Alpha update apeed</param>
		public ColorFade(Color colorBase, byte min, byte max, float speed) {
			ColorBase = colorBase;
			mMin = min;
			mMax = max;
			mSpeed = speed;
		}


		public Color Update() {
			if (mAlpha < mMin - mSpeed) {
				mAlpha = mMin;
				mFadeIn = true;
			}
			if (mAlpha > mMax - mSpeed) {
				mAlpha = mMax;
				mFadeIn = false;
			}

			if (mFadeIn) {
				if (mAlpha < mMax) {
					mAlpha += mSpeed;
				} else {
					mFadeIn = false;
				}
			} else {
				if (mAlpha > mMin) {
					mAlpha -= mSpeed;
				} else {
					mFadeIn = true;
				}
			}

			return UpdateColor();
		}

		public Color UpdateColor() {
			ColorFaded = new Color(ColorBase.R, ColorBase.G, ColorBase.B, Alpha);

			return ColorFaded;
		}


	}

}
