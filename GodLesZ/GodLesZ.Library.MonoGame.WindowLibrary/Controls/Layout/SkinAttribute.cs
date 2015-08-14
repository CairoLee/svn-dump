using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	public class SkinAttribute : SkinBase {
		public string Value;

		public SkinAttribute()
			: base() {
		}

		public SkinAttribute(SkinAttribute source)
			: base(source) {
			this.Value = source.Value;
		}

	}

}
