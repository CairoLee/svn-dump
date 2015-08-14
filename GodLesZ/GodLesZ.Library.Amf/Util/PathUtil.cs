
using System;
using System.IO;

namespace GodLesZ.Library.Amf.Util {
	public sealed class PathUtil {
		/// <summary>
		/// Normalizes the file or directory name.
		/// </summary>
		/// <param name="path">The file or directory for which to obtain normalized path information.</param>
		/// <returns>The fully qualified location of path.</returns>
		static public string NormalizePath(string path) {
			string result = Path.GetFullPath(path);
			result = result.TrimEnd(new char[] { Path.DirectorySeparatorChar });
			return result;
		}
		/// <summary>
		/// Calculates the path relative to a root.
		/// </summary>
		/// <param name="root">The root.</param>
		/// <param name="path">The path.</param>
		/// <returns>The relative path to the specified root.</returns>
		public static string GetRelativePath(string root, string path) {
			root = NormalizePath(root);
			path = NormalizePath(path);
			if (!ContainsPath(path, root))
				throw new Exception("Could not find root in path while calculating relative path.");
			return string.Format(".{0}", path.Substring(root.Length));
		}
		/// <summary>
		/// Determines whether the first path contains the second path.
		/// </summary>
		/// <param name="path1">The first path.</param>
		/// <param name="path2">The second path.</param>
		/// <returns>
		/// 	<c>true</c> if the first path contains the second path; otherwise, <c>false</c>.
		/// </returns>
		public static bool ContainsPath(string path1, string path2) {
			path1 = NormalizePath(path1);
			path2 = NormalizePath(path2);
			return path2.StartsWith(path1);
		}
	}
}
