using Microsoft.Xna.Framework;

namespace GodLesZ.Library.MonoGame.Geometry {

	/// <summary>Interface for a basic 2D camera.</summary>
	public interface ICamera {

		/// <summary>Gets or sets the position of the camera.</summary>
		IPoint Position {
			get;
			set;
		}

		/// <summary>Gets or sets the x coordinate of the <see cref="Position"/>.</summary>
		int X {
			get;
			set;
		}

		/// <summary>Gets or sets the y coordinate of the <see cref="Position"/>.</summary>
		int Y {
			get;
			set;
		}

		/// <summary>Gets the transform matrix.</summary>
		Matrix TransformMatrix {
			get;
		}

		Rectangle Viewport {
			get;
		}


		bool IsInViewport(Point p);
		bool IsInViewport(IPoint p);
		bool IsInViewport(IRectangle rect);
		bool IsInViewport(int x, int y);

		void Refresh();

	}

}
