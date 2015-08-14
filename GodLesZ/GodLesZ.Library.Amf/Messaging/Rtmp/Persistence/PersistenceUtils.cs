using System.IO;
using System.Text;
using GodLesZ.Library.Amf.Messaging.Api;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Persistence {
	class PersistenceUtils {
		public const string PersistencePath = "persistence";

		public static string GetFilename(IScope scope, string folder, string name, string extension) {
			string path = GetPath(scope, folder);
			path = Path.Combine(path, name + extension);
			return path;
		}

		public static string GetPath(IScope scope, string folder) {
			StringBuilder result = new StringBuilder();
			IScope app = ScopeUtils.FindApplication(scope);
			if (app != null) {
				do {
					result.Insert(0, scope.Name + Path.DirectorySeparatorChar);
					scope = scope.Parent;
				}
				while (scope.Depth >= app.Depth);
				result.Insert(0, "apps" + Path.DirectorySeparatorChar);
			}
			result.Insert(0, "~");
			result.Append(folder);
			result.Append(Path.DirectorySeparatorChar);
			return result.ToString();
		}
	}
}
