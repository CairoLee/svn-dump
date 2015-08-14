using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Rovolution.Server.Scripting {

	[Serializable]
	public class ScriptEntry {

		[XmlAttribute("Type")]
		public EScriptType Type {
			get;
			set;
		}

		[XmlAttribute("Path")]
		public string Path {
			get;
			set;
		}


		public ScriptEntry() {
		}

		public ScriptEntry(EScriptType type, string path)
			: base() {
			Type = type;
			Path = path;
		}

	}

}
