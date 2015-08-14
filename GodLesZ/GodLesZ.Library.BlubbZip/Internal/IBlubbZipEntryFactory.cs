using System;

using GodLesZ.Library.BlubbZip.Core;

namespace GodLesZ.Library.BlubbZip.Blubb {
	/// <summary>
	/// Defines factory methods for creating new <see cref="BlubbEntry"></see> values.
	/// </summary>
	public interface IBlubbZipEntryFactory {
		/// <summary>
		/// Create a <see cref="BlubbEntry"/> for a file given its name
		/// </summary>
		/// <param name="fileName">The name of the file to create an entry for.</param>
		/// <returns>Returns a <see cref="BlubbEntry">file entry</see> based on the <paramref name="fileName"/> passed.</returns>
		BlubbZipEntry MakeFileEntry( string fileName );

		/// <summary>
		/// Create a <see cref="BlubbEntry"/> for a file given its name
		/// </summary>
		/// <param name="fileName">The name of the file to create an entry for.</param>
		/// <param name="useFileSystem">If true get details from the file system if the file exists.</param>
		/// <returns>Returns a <see cref="BlubbEntry">file entry</see> based on the <paramref name="fileName"/> passed.</returns>
		BlubbZipEntry MakeFileEntry( string fileName, bool useFileSystem );

		/// <summary>
		/// Create a <see cref="BlubbEntry"/> for a directory given its name
		/// </summary>
		/// <param name="directoryName">The name of the directory to create an entry for.</param>
		/// <returns>Returns a <see cref="BlubbEntry">directory entry</see> based on the <paramref name="directoryName"/> passed.</returns>
		BlubbZipEntry MakeDirectoryEntry( string directoryName );

		/// <summary>
		/// Create a <see cref="BlubbEntry"/> for a directory given its name
		/// </summary>
		/// <param name="directoryName">The name of the directory to create an entry for.</param>
		/// <param name="useFileSystem">If true get details from the file system for this directory if it exists.</param>
		/// <returns>Returns a <see cref="BlubbEntry">directory entry</see> based on the <paramref name="directoryName"/> passed.</returns>
		BlubbZipEntry MakeDirectoryEntry( string directoryName, bool useFileSystem );

		/// <summary>
		/// Get/set the <see cref="INameTransform"></see> applicable.
		/// </summary>
		INameTransform NameTransform {
			get;
			set;
		}
	}
}
