using System;
using Microsoft.Xna.Framework;

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	public class Component : Disposable {
		protected Manager mManager;
		protected bool mInitialized;
		protected bool mAutoInit;

		public virtual Manager Manager {
			get { return mManager; }
			set { mManager = value; }
		}
		public virtual bool Initialized {
			get { return mInitialized; }
		}

		public virtual bool AutoInit {
			get { return mAutoInit; }
			set { mAutoInit = value; }
		}


		public Component(Manager manager) {
			if (manager == null) {
				throw new Exception("Component cannot be created. Manager instance is needed.");
			}

			mManager = manager;
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
				// ?
			}

			base.Dispose(disposing);
		}

		public virtual void Init() {
			mInitialized = true;
		}

		protected internal virtual void Update(GameTime gameTime) {

		}

	}

}
