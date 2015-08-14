using System.Collections.Generic;
using System.Xml.Linq;

namespace FreeWorld.Game.Tests.Tmx {

	public class PropertyDict : Dictionary<string, string> {

		public PropertyDict() {

		}

		public PropertyDict(XElement xmlProp) {
			AddRange(xmlProp);
		}


		public void AddRange(XElement xmlProp) {
			if (xmlProp == null) {
				return;
			}

			var properties = xmlProp.Elements("property");
			foreach (var p in properties) {
				var pname = p.Attribute("name").Value;
				var pval = p.Attribute("value").Value;
				Add(pname, pval);
			}
		}

	}

}