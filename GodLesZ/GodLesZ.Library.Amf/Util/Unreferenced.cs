namespace GodLesZ.Library.Amf.Util {
	/// <summary>
	/// Suppresses CS0168.
	/// </summary>
	public class Unreferenced {
		/// <summary>
		/// Suppress CS0168 for the specified object.
		/// </summary>
		/// <param name="obj">The parameter.</param>
		[System.Diagnostics.Conditional("DEBUG")]
		static public void Parameter(params object[] obj) {
			return;
		}
	}
}
