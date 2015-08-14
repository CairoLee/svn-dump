using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	public class SkinFont : SkinBase {
		public SpriteFont Resource = null;
		public string Asset = null;
		public string Addon = null;

		public int Height {
			get {
				if (Resource != null) {
					return (int)Resource.MeasureString("AaYy").Y;
				}
				return 0;
			}
		}

		public SkinFont()
			: base() {
		}

		public SkinFont(SkinFont source)
			: base(source) {
			if (source != null) {
				this.Resource = source.Resource;
				this.Asset = source.Asset;
			}
		}

	}

}
