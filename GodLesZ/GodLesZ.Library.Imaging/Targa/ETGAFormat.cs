
namespace GodLesZ.Library.Imaging.Targa {

	/// <summary>
	/// The Targa format of the file.
	/// </summary>
	public enum ETGAFormat {
		/// <summary>
		/// Unknown Targa Image format.
		/// </summary>
		UNKNOWN = 0,

		/// <summary>
		/// Original Targa Image format.
		/// </summary>
		/// <remarks>Targa Image does not have a Signature of ""TRUEVISION-XFILE"".</remarks>
		ORIGINAL_TGA = 100,

		/// <summary>
		/// New Targa Image format
		/// </summary>
		/// <remarks>Targa Image has a TargaFooter with a Signature of ""TRUEVISION-XFILE"".</remarks>
		NEW_TGA = 200
	}

}
