namespace GodLesZ.Library.Imaging {
	using System;
	using System.Drawing;

	public class Blob : IDisposable {
		private bool disposed;
		private Bitmap image;
		private Point location;
		private Bitmap owner;

		public Blob(Bitmap image, Point location) {
			this.image = image;
			this.location = location;
		}

		public Blob(Bitmap image, Point location, Bitmap owner) {
			this.image = image;
			this.location = location;
			this.owner = owner;
		}

		public void Dispose() {
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing) {
			if (!this.disposed && disposing) {
				this.image.Dispose();
				this.disposed = true;
			}
		}

		~Blob() {
			this.Dispose(false);
		}

		public Bitmap Image {
			get {
				return this.image;
			}
		}

		public Point Location {
			get {
				return this.location;
			}
		}

		public Bitmap Owner {
			get {
				return this.owner;
			}
		}
	}
}

