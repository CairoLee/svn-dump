using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shaiya.Extended.Library.Geometry {

	public interface IPoint2D {
		int X { get; }
		int Y { get; }
	}

	public interface IPoint3D : IPoint2D {
		int Z { get; }
	}

}
