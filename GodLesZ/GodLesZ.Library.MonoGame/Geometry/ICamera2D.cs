using Microsoft.Xna.Framework;

namespace GodLesZ.Library.MonoGame.Geometry {

	/// <summary>Interface for a basic 2D camera.</summary>
	public interface ICamera2D : ICamera {

		/// <summary>Gets or sets the zoom.</summary>
		float Zoom {
			get;
			set;
		}

		Rectangle ViewportScaled {
			get;
		}

		bool IsInViewport(IPoint2D p);
		bool IsInViewport(IRectangle2D rect);

	}

}
