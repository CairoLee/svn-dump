using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Rovolution.Server.Scripting {

	[Serializable]
	[XmlRoot(ElementName = "ScriptList")]
	public class ScriptList : List<ScriptListEntry> {

	}

}
