
namespace GodLesZ.Library.Imaging.Targa {

	/// <summary>
	/// The top-to-bottom ordering in which pixel data is transferred from the file to the screen.
	/// </summary>
	public enum ETargaVerticalTransferOrder {
		/// <summary>
		/// Unknown transfer order.
		/// </summary>
		UNKNOWN = -1,

		/// <summary>
		/// Transfer order of pixels is from the bottom to top.
		/// </summary>
		BOTTOM = 0,

		/// <summary>
		/// Transfer order of pixels is from the top to bottom.
		/// </summary>
		TOP = 1
	}

}
