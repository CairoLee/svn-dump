using System;
using System.Collections.Generic;
using System.Xml;
using Rovolution.Server.Objects;


namespace Rovolution.Server.Internal {

	public partial class Parser {

		public static CharacterJobBonus ParseJobBonus(string filepath) {
			CharacterJobBonus bonus = new CharacterJobBonus();
			EClientClass currentClass = EClientClass.Novice;
			using (XmlReader xml = XmlReader.Create(filepath)) {
				while (xml.Read() == true) {
					if (xml.NodeType != XmlNodeType.Element) {
						continue;
					}
					string name = xml.Name;

					if (name == "Job") {
						int idInt = int.Parse(xml.GetAttribute("ID"));
						currentClass = (EClientClass)idInt;
						bonus.Add(currentClass, new Dictionary<int, EStatusAttribute>());
					} else if (name == "Bonus") {
						string attString = xml.GetAttribute("Type");
						EStatusAttribute att = (EStatusAttribute)Enum.Parse(typeof(EStatusAttribute), attString);
						int level = int.Parse(xml.GetAttribute("Level"));

						bonus[currentClass].Add(level, att);
					}
				}

			} // using

			return bonus;
		}

	}

}
