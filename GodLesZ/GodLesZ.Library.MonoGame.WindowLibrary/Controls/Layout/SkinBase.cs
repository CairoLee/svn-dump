using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	public class SkinBase {
		public string Name;
		public bool Archive;

		public SkinBase()
			: base() {
			Archive = false;
		}

		public SkinBase(SkinBase source)
			: base() {
			if (source != null) {
				this.Name = source.Name;
				this.Archive = source.Archive;
			}
		}

	}

}
