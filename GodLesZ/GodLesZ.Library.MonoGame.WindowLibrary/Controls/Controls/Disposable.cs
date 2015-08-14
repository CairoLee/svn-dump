using System;

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	public abstract class Disposable : Unknown, IDisposable {

		private static int count = 0;

		public static int Count { get { return count; } }

		protected Disposable() {
			count += 1;
		}

		~Disposable() {
			Dispose(false);
		}

		public void Dispose() {
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing) {
			if (disposing) {
				count -= 1;
			}
		}

	}

}
