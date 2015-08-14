using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Ssc {

	[Serializable]
	public class SItemBonus {
		[XmlAttribute]
		public EItemBonus Type;
		[XmlAttribute]
		public int Value;
	}

}
