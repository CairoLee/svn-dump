using GodLesZ.Library.Amf.Configuration;
using GodLesZ.Library.Amf.Messaging.Api;
using GodLesZ.Library.Amf.Messaging.Api.Stream;
using GodLesZ.Library.Amf.Messaging.Rtmp.Persistence;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Stream {
	/// <summary>
	/// Default filename generator for streams. The files will be stored in a
	/// directory "streams" in the application folder.
	/// </summary>
	class DefaultStreamFilenameGenerator : IStreamFilenameGenerator {
		/// <summary>
		/// Generate stream directory based on relative scope path. The base directory is
		/// <code>streams</code>, e.g. a scope <code>/application/one/two</code> will
		/// generate a directory <code>/streams/one/two</code> inside the application.
		/// </summary>
		/// <param name="scope">Scope.</param>
		/// <returns>Directory based on relative scope path.</returns>
		private string GetStreamDirectory(IScope scope) {
			return PersistenceUtils.GetPath(scope, "streams");
		}

		#region IStreamFilenameGenerator Members

		public void Start(ConfigurationSection configuration) {
		}

		public void Shutdown() {
		}

		public string GenerateFilename(IScope scope, string name, GenerationType type) {
			return GenerateFilename(scope, name, null, type);
		}

		public string GenerateFilename(IScope scope, string name, string extension, GenerationType type) {
			string result = GetStreamDirectory(scope) + name;
			if (extension != null && !string.Empty.Equals(extension)) {
				result += extension;
			}
			return result;
		}
		/// <summary>
		/// The default filenames are relative to the scope path, so always return <code>false</code>.
		/// </summary>
		public bool ResolvesToAbsolutePath {
			get { return false; }
		}

		#endregion
	}
}
