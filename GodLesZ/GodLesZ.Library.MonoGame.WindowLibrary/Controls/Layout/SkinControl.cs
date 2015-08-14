using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	public class SkinControl : SkinBase {
		public string Inherits = null;
		public Size DefaultSize;
		public int ResizerSize;
		public Size MinimumSize;
		public Margins OriginMargins;
		public Margins ClientMargins;
		public SkinList<SkinLayer> Layers = new SkinList<SkinLayer>();
		public SkinList<SkinAttribute> Attributes = new SkinList<SkinAttribute>();

		public SkinControl()
			: base() {
		}

		public SkinControl(SkinControl source)
			: base(source) {
			this.Inherits = source.Inherits;
			this.DefaultSize = source.DefaultSize;
			this.MinimumSize = source.MinimumSize;
			this.OriginMargins = source.OriginMargins;
			this.ClientMargins = source.ClientMargins;
			this.ResizerSize = source.ResizerSize;
			this.Layers = new SkinList<SkinLayer>(source.Layers);
			this.Attributes = new SkinList<SkinAttribute>(source.Attributes);
		}

	}

}
