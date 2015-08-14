using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace GodLesZ.eAthenaEditor.Library.Script {

	public class ScriptConstant {
		[XmlAttribute()]
		public string Name {
			get;
			set;
		}

		[XmlAttribute()]
		public bool IsCharPropertie {
			get;
			set;
		}

		public string Description {
			get;
			set;
		}


		public ScriptConstant() {
		}


		public override string ToString() {
			return string.Format("{0}: {1}{2}", Name, Description, (IsCharPropertie ? " [Char]" : ""));
		}
	}

}
