using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace eA_Script_VarParser {

	public struct ScriptMessage {
		[XmlAttribute()]
		public int Index;
		[XmlAttribute()]
		public string Constant;
		[XmlAttribute()]
		public string Message;

		public ScriptMessage( int ArrIndex, string Mes, string Const ) {
			Index = ArrIndex;
			Message = Mes;
			Constant = Const;
		}
	}

}
