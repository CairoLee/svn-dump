using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalSoftware.Games.Defender.Library.Interface {

	public class Camera2D {
		private GraphicsDevice mGraphicsDevice;

		private Vector2 mPosition;
		private Vector2 mScreenCenter;
		private Rectangle mBounds;

		private float mZoom = 1.0f;
		private float mMinZoom;
		private float mMaxZoom = 5.0f;

		private Matrix mTransformMatrix;
		private Rectangle mViewArea;

		public Vector2 Position {
			get { return mPosition; }
		}

		public float Zoom {
			get { return mZoom; }
		}

		public Matrix Matrix {
			get { return mTransformMatrix; }
		}

		public Rectangle ViewArea {
			get { return mViewArea; }
		}


		public Camera2D( Rectangle bounds ) {
			mGraphicsDevice = DefenderWorld.Instance.GraphicsDevice;
			mBounds = bounds;

			mPosition = new Vector2( 1000, 1000 );
			mScreenCenter = new Vector2( mGraphicsDevice.Viewport.Width / 2, mGraphicsDevice.Viewport.Height / 2 );

			mMinZoom = MathHelper.Max( (float)mGraphicsDevice.Viewport.Width / bounds.Width, (float)mGraphicsDevice.Viewport.Height / bounds.Height );

			UpdateCamera();
		}

		private void UpdateCamera() {
			float newWidth = mGraphicsDevice.Viewport.Width / mZoom;
			float newHeight = mGraphicsDevice.Viewport.Height / mZoom;
			mViewArea = new Rectangle( (int)( mPosition.X - newWidth / 2 ), (int)( mPosition.Y - newHeight / 2 ), (int)( newWidth ), (int)( newHeight ) );
			mTransformMatrix = Matrix.CreateTranslation( -mPosition.X, -mPosition.Y, 0 ) * Matrix.CreateScale( mZoom, mZoom, 1 ) * Matrix.CreateTranslation( mScreenCenter.X, mScreenCenter.Y, 0 );
		}




		public void Move( Vector2 movement ) {
			mPosition.X = MathHelper.Clamp( mPosition.X + movement.X, ( mBounds.Left + mScreenCenter.X ) / mZoom, mBounds.Right - mScreenCenter.X / mZoom );
			mPosition.Y = MathHelper.Clamp( mPosition.Y + movement.Y, ( mBounds.Top + mScreenCenter.Y ) / mZoom, mBounds.Bottom - mScreenCenter.Y / mZoom );

			UpdateCamera();
		}


		public void ZoomIn( float amount ) {
			mZoom = MathHelper.Clamp( mZoom + amount, mMinZoom, mMaxZoom );
			UpdateCamera();
		}

		public void ZoomOut( float amount ) {
			mZoom = MathHelper.Clamp( mZoom - amount, mMinZoom, mMaxZoom );
			Move( Vector2.Zero );
		}


		public void Focus( Vector2 point ) {
			Move( point - mPosition );
		}

		public override string ToString() {
			return mPosition.ToString() + "\n" + mViewArea.ToString();
		}

	}

}
