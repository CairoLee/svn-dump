
namespace GodLesZ.Library.Imaging.Targa {

	/// <summary>
	/// Indicates the type of color map, if any, included with the image file. 
	/// </summary>
	public enum ETargetColorMapType : byte {
		/// <summary>
		/// No color map was included in the file.
		/// </summary>
		NO_COLOR_MAP = 0,

		/// <summary>
		/// Color map was included in the file.
		/// </summary>
		COLOR_MAP_INCLUDED = 1
	}

}
