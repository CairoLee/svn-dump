using System.IO;

namespace GodLesZ.Library.Amf.Context {
	/// <summary>
	/// Provides a common interface to describe and access data from diverse resource locations.
	/// </summary>
	public interface IResource {
		/// <summary>
		/// Returns a <see cref="System.IO.FileInfo"/> handle for this resource.
		/// </summary>
		FileInfo File { get; }
		/// <summary>
		/// Returns a description for this resource.
		/// </summary>
		string Description { get; }
		/// <summary>
		/// Gets whether this resource actually exist in physical form.
		/// </summary>
		bool Exists { get; }
	}
}
