
namespace GodLesZ.Library.Imaging.Targa {

	/// <summary>
	/// Screen destination of first pixel based on the VerticalTransferOrder and HorizontalTransferOrder.
	/// </summary>
	public enum ETargaFirstPixelDestination {
		/// <summary>
		/// Unknown first pixel destination.
		/// </summary>
		UNKNOWN = 0,

		/// <summary>
		/// First pixel destination is the top-left corner of the image.
		/// </summary>
		TOP_LEFT = 1,

		/// <summary>
		/// First pixel destination is the top-right corner of the image.
		/// </summary>
		TOP_RIGHT = 2,

		/// <summary>
		/// First pixel destination is the bottom-left corner of the image.
		/// </summary>
		BOTTOM_LEFT = 3,

		/// <summary>
		/// First pixel destination is the bottom-right corner of the image.
		/// </summary>
		BOTTOM_RIGHT = 4
	}

}
