
namespace GodLesZ.Library.Imaging.Targa {

	/// <summary>
	/// The type of image read from the file.
	/// </summary>
	public enum ETargaImageType : byte {
		/// <summary>
		/// No image data was found in file.
		/// </summary>
		NO_IMAGE_DATA = 0,

		/// <summary>
		/// Image is an uncompressed, indexed color-mapped image.
		/// </summary>
		UNCOMPRESSED_COLOR_MAPPED = 1,

		/// <summary>
		/// Image is an uncompressed, RGB image.
		/// </summary>
		UNCOMPRESSED_TRUE_COLOR = 2,

		/// <summary>
		/// Image is an uncompressed, Greyscale image.
		/// </summary>
		UNCOMPRESSED_BLACK_AND_WHITE = 3,

		/// <summary>
		/// Image is a compressed, indexed color-mapped image.
		/// </summary>
		RUN_LENGTH_ENCODED_COLOR_MAPPED = 9,

		/// <summary>
		/// Image is a compressed, RGB image.
		/// </summary>
		RUN_LENGTH_ENCODED_TRUE_COLOR = 10,

		/// <summary>
		/// Image is a compressed, Greyscale image.
		/// </summary>
		RUN_LENGTH_ENCODED_BLACK_AND_WHITE = 11
	}

}
