using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace Rovolution.Tools.SkillTreeConverter {

	public class Program {

		public static void Main(string[] args) {
			Console.WriteLine("Patrh to skill_tree.txt: ");
			string filepath = Console.ReadLine().Replace("\\", "/") + "/skill_tree.txt";
			using (Stream s = new FileStream(filepath, FileMode.Open)) {
				using (StreamReader reader = new StreamReader(s)) {
					string line = null, comment = null, lastLineCommend = null;
					int lastClass = -1;
					string xml = "";
					xml += "<?xml version=\"1.0\"?>\n";
					xml += "<CharacterSkillTree xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\n";
					while ((line = reader.ReadLine()) != null) {
						line = line.Trim();

						if (line.Length == 0) {
							continue;
						}

						// Save comments above new job starts
						if (line.StartsWith("//")) {
							lastLineCommend = line.Substring(2).Trim();
							continue;
						}

						// Trim out ending comment
						int cPos = line.LastIndexOf("//");
						if (cPos != -1) {
							comment = line.Substring(cPos + 2).Trim();
							line = line.Substring(0, cPos).Trim();
						} else {
							// No comment for this linw
							comment = "";
						}

						string[] parts = line.Split(',');
						int p = 3;
						// JobNo,Skill-ID,MaxLV{,JobLV},Prerequisite Skill-ID-1,Prerequisite Skill-ID-1-Lv,PrereqSkill-ID-2,PrereqSkill-ID-2-Lv,PrereqSkill-ID-3,PrereqSkill-ID-3-Lv,PrereqSkill-ID-4,PrereqSkill-ID-4-Lv,PrereqSkill-ID-5,PrereqSkill-ID-5-Lv//CLASS_SKILLNAME#Skill Name#
						int jobNo = int.Parse(parts[0]);
						int skillID = int.Parse(parts[1]);
						int skillMax = int.Parse(parts[2]);
						int jobLv = 0;
						if (parts.Length >= (4 + 5 * 2)) {
							jobLv = int.Parse(parts[3]);
							p = 4;
						}

						// New job? Open new job block
						if (jobNo != lastClass) {
							// Only close block if ever had a job!
							if (lastClass != -1) {
								xml += "\t</Job>\n";
							}

							// Add last Comment
							if (string.IsNullOrEmpty(lastLineCommend) == false) {
								xml += "\t<!-- " + lastLineCommend + " -->\n";
								lastLineCommend = "";
							}
							xml += "\t<Job ID=\"" + jobNo + "\">\n";

							lastClass = jobNo;
						}

						// Parse requirements
						string xmlReq = "";
						for (; p < parts.Length; p += 2) {
							int preID = int.Parse(parts[p]);
							int preLevel = int.Parse(parts[p + 1]);
							// Break out, no more pre skills 
							if (preID == 0) {
								break;
							}

							if (preLevel <= 0) {
								//Console.WriteLine("break out here!");
								// TODO: i know here was some special case for berserk..
							}

							// Add skill
							xmlReq += "\t\t\t<Require ID=\"" + preID + "\" Level=\"" + preLevel + "\" />\n";
						}


						// Add comment before new skill block
						xml += "\t\t<!-- " + comment + " -->\n";

						// Had some required skills?
						if (xmlReq.Length == 0) {
							// No requirements, close skill block
							xml += "\t\t<Skill ID=\"" + skillID + "\" Max=\"" + skillMax + "\" MinLv=\"" + jobLv + "\" />\n";
						} else {
							// Add them after opening the block
							// Open new block
							// TODO: xml cares for empty blocks?
							xml += "\t\t<Skill ID=\"" + skillID + "\" Max=\"" + skillMax + "\" MinLv=\"" + jobLv + "\">\n";

							// Requirements
							xml += xmlReq;

							// Close block
							xml += "\t\t</Skill>\n";
						}
					}

					// Close last job block!
					xml += "\t</Job>\n";
					// Close xml doc
					xml += "</CharacterSkillTree>\n";

					// Write to file
					if (File.Exists("Config/CharacterSkillTree.xml")) {
						File.Delete("Config/CharacterSkillTree.xml");
					}
					File.WriteAllText("Config/CharacterSkillTree.xml", xml);
				}

				Console.WriteLine("Done");
				Console.ReadLine();
			}

		}

	}

}
