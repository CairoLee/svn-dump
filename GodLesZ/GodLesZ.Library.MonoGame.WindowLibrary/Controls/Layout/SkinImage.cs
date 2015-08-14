using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	public class SkinImage : SkinBase {
		public Texture2D Resource = null;
		public string Asset = null;
		public string Addon = null;

		public SkinImage()
			: base() {
		}

		public SkinImage(SkinImage source)
			: base(source) {
			this.Resource = source.Resource;
			this.Asset = source.Asset;
		}

	}

}
