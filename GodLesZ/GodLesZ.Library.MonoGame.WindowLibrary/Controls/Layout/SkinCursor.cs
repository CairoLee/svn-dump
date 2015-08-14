using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#if (!XBOX && !XBOX_FAKE)
using System.Windows.Forms;
#endif

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	public class SkinCursor : SkinBase {
#if (!XBOX && !XBOX_FAKE)
		public Cursor Resource = null;
#endif

		public string Asset = null;
		public string Addon = null;

		public SkinCursor()
			: base() {
		}

		public SkinCursor(SkinCursor source)
			: base(source) {
#if (!XBOX && !XBOX_FAKE)
			this.Resource = source.Resource;
#endif

			this.Asset = source.Asset;
		}

	}

}
