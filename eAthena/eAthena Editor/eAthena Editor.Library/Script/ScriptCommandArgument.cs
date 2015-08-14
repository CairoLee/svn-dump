using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace GodLesZ.eAthenaEditor.Library.Script {

	public class ScriptCommandArgument {
		[XmlAttribute()]
		public string Name {
			get;
			set;
		}

		[XmlAttribute()]
		public EScriptArgumentType Type {
			get;
			set;
		}

		public string Description {
			get;
			set;
		}

		[XmlAttribute()]
		public bool Optional {
			get;
			set;
		}


		public ScriptCommandArgument() {
			Name = "";
			Type = EScriptArgumentType.String;
			Description = "";
			Optional = false;
		}


		public override string ToString() {
			return string.Format("{0} ({1}): {2}{3}", Name, Type, Description, (Optional == true ? " optional" : ""));
		}

	}

}
