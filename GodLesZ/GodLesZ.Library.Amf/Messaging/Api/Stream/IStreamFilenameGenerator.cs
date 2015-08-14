using System;

namespace GodLesZ.Library.Amf.Messaging.Api.Stream {
	/// <summary>
	/// Interface for generating filenames for streams.
	/// </summary>
	[CLSCompliant(false)]
	public interface IStreamFilenameGenerator : IScopeService {
		/// <summary>
		/// Generate a filename without an extension.
		/// </summary>
		/// <param name="scope">Scope to use.</param>
		/// <param name="name">Stream name.</param>
		/// <param name="type">Generation strategy (either playback or record).</param>
		/// <returns>Filename.</returns>
		string GenerateFilename(IScope scope, string name, GenerationType type);
		/// <summary>
		/// Generate a filename with an extension.
		/// </summary>
		/// <param name="scope">Scope to use.</param>
		/// <param name="name">Stream name.</param>
		/// <param name="extension">Extension.</param>
		/// <param name="type">Generation strategy (either playback or record).</param>
		/// <returns>Filename with extension.</returns>
		string GenerateFilename(IScope scope, string name, string extension, GenerationType type);
		/// <summary>
		/// Gets whether generated filename is an absolute path.
		/// </summary>
		/// <remarks>
		/// True if returned filename is an absolute path, else relative to application.
		/// If relative to application, you need to use
		/// <code>scope.Context.GetResources(fileName)[0].File</code> to resolve this to a file.
		/// 
		/// If absolute (ie returns true) simply use <code>new FileInfo(GenerateFilename(scope, name))</code>
		/// </remarks>
		bool ResolvesToAbsolutePath { get; }
	}
}
