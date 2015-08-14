using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Shaiya.Extended.Library.Geometry {

	public interface ICamera {

		int TileWidth {
			get;
			set;
		}
		int TileHeight {
			get;
			set;
		}

		Point Position {
			get;
			set;
		}
		int X {
			get;
			set;
		}

		int Y {
			get;
			set;
		}

		Matrix TransformMatrix {
			get;
		}

	}

}
