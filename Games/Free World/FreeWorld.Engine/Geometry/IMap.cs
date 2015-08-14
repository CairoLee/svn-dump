using System;
using System.Collections.Generic;
using System.Text;

namespace FreeWorld.Engine {

	public class IMap : SerialObject {
		protected int mWidth;
		protected int mHeight;

		public int Width {
			get { return mWidth; }
		}

		public int Height {
			get { return mHeight; }
		}

		public virtual void OnEnter( SerialObject obj ) {
		}
		public virtual void OnLeave( SerialObject obj ) {
		}
		public virtual void OnMove( SerialObject obj, Point3D p ) {
		}

	}

}
