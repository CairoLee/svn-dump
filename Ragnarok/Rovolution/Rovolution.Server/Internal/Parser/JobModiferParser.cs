using System;
using System.Xml;
using Rovolution.Server.Objects;


namespace Rovolution.Server.Internal {

	public partial class Parser {

		public static CharacterJobModifer ParseJobModifer(string filepath) {
			CharacterJobModifer modifer = new CharacterJobModifer();
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
						modifer.Add(currentClass, new CharacterJobModiferValues());
					} else if (name == "Mod") {
						string typeName = xml.GetAttribute("Name");
						ECharacterJobModifer type = (ECharacterJobModifer)Enum.Parse(typeof(ECharacterJobModifer), typeName);
						int value = int.Parse(xml.GetAttribute("Value"));

						modifer[currentClass].Add((int)type, value);
					} else if (name == "Weapon") {
						int type = int.Parse(xml.GetAttribute("Type"));
						int value = int.Parse(xml.GetAttribute("Value"));

						modifer[currentClass].Add(type, value);
					}
				}

			} // using

			return modifer;
		}

	}

}
