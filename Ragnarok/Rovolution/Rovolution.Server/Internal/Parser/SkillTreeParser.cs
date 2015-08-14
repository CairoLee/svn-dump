using System.Xml;
using Rovolution.Server.Objects;

namespace Rovolution.Server.Internal {

	public partial class Parser {

		public static SkillTree ParseSkillTree(string filepath) {
			SkillTree tree = new SkillTree();

			SkillTreeJob job = null;
			SkillTreeJobSkill skill = null;
			using (XmlReader xml = XmlReader.Create(filepath)) {
				while (xml.Read() == true) {
					if (xml.NodeType != XmlNodeType.Element) {
						continue;
					}
					string name = xml.Name;

					if (name == "Job") {
						if (job != null) {
							if (skill != null) {
								job.Add(skill.ID, skill);
								skill = null;
							}

							tree.Add(job.ID, job);
							job = null;
						}

						job = new SkillTreeJob {
							ID = int.Parse(xml.GetAttribute("ID"))
						};
					} else if (name == "Skill") {
						if (skill != null) {
							job.Add(skill.ID, skill);
							skill = null;
						}

						skill = new SkillTreeJobSkill {
							ID = int.Parse(xml.GetAttribute("ID")),
							MaxLevel = int.Parse(xml.GetAttribute("Max")),
							JobLevel = int.Parse(xml.GetAttribute("MinLv"))
						};
					} else if (name == "Require") {
						SkillTreeJobSkillRequirement r = new SkillTreeJobSkillRequirement {
							ID = int.Parse(xml.GetAttribute("ID")),
							Level = int.Parse(xml.GetAttribute("Level"))
						};
						skill.Add(r.ID, r);
					}

				} // while

				// Add last skill to last job
				if (job != null && skill != null) {
					job.Add(skill.ID, skill);
				}
				// Add last job to tree
				if (job != null) {
					tree.Add(job.ID, job);
				}
			} // using


			return tree;
		}

	}
}
