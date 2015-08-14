using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace GodLesZ.eAthenaEditor.Library.Script {
	
	[XmlRoot("ScriptCommandList")]
	public class ScriptCommandList : List<ScriptCommand> {

	}

}
