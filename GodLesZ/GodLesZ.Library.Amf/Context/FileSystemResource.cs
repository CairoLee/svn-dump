using System;
using System.Globalization;
using System.IO;
using GodLesZ.Library.Amf.Util;

namespace GodLesZ.Library.Amf.Context {
	class FileSystemResource : IResource {
		/// <summary>
		/// The separator between the protocol name and the resource name.
		/// </summary>
		public const string ProtocolSeparator = "://";
		/// <summary>
		/// The default special character that denotes the base (home, or root)
		/// path.
		/// </summary>
		/// <remarks>
		/// <p>
		/// Will be resolved (by those <see cref="GodLesZ.Library.Amf.Context.IResource"/>
		/// implementations that support it) to the home (or root) path for
		/// the specific <see cref="GodLesZ.Library.Amf.Context.IResource"/> implementation.
		/// </p>
		/// <p>
		/// For example, in the case of a web application this will (probably)
		/// resolve to the virtual directory of the web application.
		/// </p>
		/// </remarks>
		protected const string DefaultBasePathPlaceHolder = "~";

		private FileInfo _fileHandle;

		public FileSystemResource(string resourceName) {
			_fileHandle = ResolveFileHandle(resourceName);
		}

		protected virtual FileInfo ResolveFileHandle(string resourceName) {
			return new FileInfo(ResolveResourceNameWithoutProtocol(resourceName));
		}

		/// <summary>
		/// Resolves the supplied <paramref name="resourceName"/> to its value
		/// sans any leading protocol.
		/// </summary>
		/// <param name="resourceName">
		/// The name of the resource.
		/// </param>
		/// <returns>
		/// The name of the resource without the protocol name.
		/// </returns>
		protected virtual string ResolveResourceNameWithoutProtocol(string resourceName) {
			return ResolveBasePathPlaceHolder(GetResourceNameWithoutProtocol(resourceName), DefaultBasePathPlaceHolder);
		}
		/// <summary>
		/// Resolves the presence of the
		/// <paramref name="basePathPlaceHolder"/> value
		/// in the supplied <paramref name="resourceName"/> into a path.
		/// </summary>
		/// <param name="resourceName">The name of the resource.</param>
		/// <param name="basePathPlaceHolder">The string that is a placeholder for a base path.</param>
		/// <returns>The name of the resource with any <paramref name="basePathPlaceHolder"/> value having been resolved into an actual path.</returns>
		protected virtual string ResolveBasePathPlaceHolder(string resourceName, string basePathPlaceHolder) {
			// Remove extra slashes used to indicate that resource is local (handle the case "/C:/path1/...")
			if (resourceName[0] == '/' && resourceName[2] == ':') {
				resourceName = resourceName.Substring(1);
			}

			if (StringUtils.HasText(resourceName) && resourceName.TrimStart().StartsWith(basePathPlaceHolder)) {
				return resourceName.Replace(basePathPlaceHolder, AppDomain.CurrentDomain.BaseDirectory).TrimStart();
				//return resourceName.Replace(basePathPlaceHolder, FluorineContext.Current.RootPath).TrimStart();
			}
			return resourceName;
		}
		/// <summary>
		/// Strips any protocol name from the supplied.
		/// </summary>
		/// <param name="resourceName">The name of the resource.</param>
		/// <returns>The name of the resource without the protocol name.</returns>
		protected static string GetResourceNameWithoutProtocol(string resourceName) {
			int pos = resourceName.IndexOf(ProtocolSeparator);
			if (pos == -1) {
				return resourceName;
			} else {
				return resourceName.Substring(pos + ProtocolSeparator.Length);
			}
		}


		#region IResource Members

		public FileInfo File {
			get { return _fileHandle; }
		}
		/// <summary>
		/// Returns a description for this resource.
		/// </summary>
		/// <value>
		/// A description for this resource.
		/// </value>
		public string Description {
			get {
				return string.Format(CultureInfo.InvariantCulture, "file [{0}]", _fileHandle.FullName);
			}
		}
		/// <summary>
		/// Gets whether this resource actually exist in physical form.
		/// </summary>
		public bool Exists {
			get {
				if (_fileHandle != null)
					return _fileHandle.Exists;
				return false;
			}
		}

		#endregion
	}
}
