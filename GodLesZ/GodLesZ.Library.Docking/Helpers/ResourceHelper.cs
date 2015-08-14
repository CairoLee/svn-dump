using System;
using System.Drawing;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace GodLesZ.Library.Docking {
	internal static class ResourceHelper {
		private static ResourceManager _resourceManager = null;

		private static ResourceManager ResourceManager {
			get {
				if (_resourceManager == null)
					_resourceManager = new ResourceManager("GodLesZ.Library.Docking.Strings", typeof(ResourceHelper).Assembly);
				return _resourceManager;
			}

		}

		public static string GetString(string name) {
			return ResourceManager.GetString(name);
		}
	}
}
