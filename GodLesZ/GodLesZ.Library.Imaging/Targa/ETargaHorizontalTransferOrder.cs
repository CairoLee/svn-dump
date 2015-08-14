
namespace GodLesZ.Library.Imaging.Targa {

	/// <summary>
	/// The left-to-right ordering in which pixel data is transferred from the file to the screen.
	/// </summary>
	public enum ETargaHorizontalTransferOrder {
		/// <summary>
		/// Unknown transfer order.
		/// </summary>
		UNKNOWN = -1,

		/// <summary>
		/// Transfer order of pixels is from the right to left.
		/// </summary>
		RIGHT = 0,

		/// <summary>
		/// Transfer order of pixels is from the left to right.
		/// </summary>
		LEFT = 1
	}

}
