namespace FinalSoftware.Games.Defender.Library.Tools {

	public class ColorFade {
		private float mValue = 0f;
		private bool mFadeIn = true;
		private byte mMin, mMax;
		private float mSpeed;

		public byte Value {
			get { return (byte)mValue; }
		}


		public ColorFade( byte min, byte max, float speed ) {
			mMin = min;
			mMax = max;
			mSpeed = speed;
		}


		public byte UpdateAndValue() {
			Update();
			return (byte)mValue;
		}

		public void Update() {
			if( mValue < mMin - mSpeed ) {
				mValue = mMin;
				mFadeIn = true;
			}
			if( mValue > mMax - mSpeed ) {
				mValue = mMax;
				mFadeIn = false;
			}

			if( mFadeIn ) {
				if( mValue < mMax )
					mValue += mSpeed;
				else
					mFadeIn = false;
			} else {
				if( mValue > mMin )
					mValue -= mSpeed;
				else
					mFadeIn = true;
			}
		}


	}

}
