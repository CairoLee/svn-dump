using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Rovolution.Server.Scripting {

	[Serializable]
	public class ScriptListEntry {

		[XmlAttribute("Type")]
		public EScriptContent Type {
			get;
			set;
		}

		[XmlArray("Entrys")]
		[XmlArrayItem("Entry")]
		public List<ScriptEntry> Entrys {
			get;
			set;
		}


		public ScriptListEntry() {
			Entrys = new List<ScriptEntry>();
		}

		public ScriptListEntry(EScriptContent type, List<ScriptEntry> entrys) : base() {
			Type = type;
			Entrys.AddRange(entrys);
		}

	}

}
