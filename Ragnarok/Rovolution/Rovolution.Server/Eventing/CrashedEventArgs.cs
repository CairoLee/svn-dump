using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server {

	public class CrashedEventArgs : EventArgs {
		private readonly Exception mException;

		public Exception Exception {
			get { return mException; }
		}

		public bool Close {
			get;
			set;
		}

		public CrashedEventArgs(Exception e) {
			mException = e;
		}
	}

}
