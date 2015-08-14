using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Rovolution.Server.Scripting {

	public static class ScriptDatabase {
		private static XmlSerializer mXmlSerializer = new XmlSerializer(typeof(ScriptList));
		public static ScriptList Scripts = new ScriptList();

		/// <summary>Loads all script files in this directory + sub dirs.</summary>
		/// <param name="ScriptListPath">Full pathname of the directory o search in.</param>
		public static void Initialize(string ScriptListPath) {
			ScriptList ScriptEntrys = new ScriptList();
			if (File.Exists(ScriptListPath) == false) {
				ServerConsole.ErrorLine("Can't load File from \"" + ScriptListPath + "\"!");
				return;
			}

			using (FileStream s = File.OpenRead(ScriptListPath)) {
				ScriptEntrys = mXmlSerializer.Deserialize(s) as ScriptList;
			}

			// Build absolute paths and load includes
			string basePath = Path.GetDirectoryName(ScriptListPath);
			for (int i = 0; i < ScriptEntrys.Count; i++) {
				for (int j = 0; j < ScriptEntrys[i].Entrys.Count; j++)
					// Include or path?
					if (ScriptEntrys[i].Entrys[j].Type == EScriptType.Include) {
						string includePath = Path.Combine(Path.GetDirectoryName(ScriptListPath), ScriptEntrys[i].Entrys[j].Path);
						ScriptDatabase.Initialize(includePath);
					} else {
						// Build an absolute path
						ScriptEntrys[i].Entrys[j].Path = Path.Combine(basePath, Path.GetDirectoryName(ScriptEntrys[i].Entrys[j].Path)) + @"\" + Path.GetFileName(ScriptEntrys[i].Entrys[j].Path);
					}
			}

			// Push to static list
			if (ScriptEntrys.Count > 0) {
				Scripts.AddRange(ScriptEntrys);
			}
		}


		/// <summary>Returns all entrys of a type</summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public static ScriptEntry[] GetType(EScriptContent type) {
			List<ScriptEntry> ret = new List<ScriptEntry>();
			for (int i = 0; i < Scripts.Count; i++) {
				if (Scripts[i].Type == type) {
					ret.AddRange(Scripts[i].Entrys);
				}
			}

			return ret.ToArray();
		}


	}


}
