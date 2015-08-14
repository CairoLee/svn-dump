using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace GodLesZ.eAthenaEditor.Library.Script {

	public class ScriptContentLoader {
		public Dictionary<string, ScriptCommand> Commands {
			get;
			private set;
		}

		public Dictionary<string, List<string>> CommandsFlat {
			get;
			private set;
		}

		public Dictionary<string, List<string>> Maps {
			get;
			private set;
		}

		public Dictionary<string, ScriptConstant> Constants {
			get;
			private set;
		}

		public Dictionary<string, List<string>> ConstantsFlat {
			get;
			private set;
		}



		public ScriptContentLoader() {
			Commands = new Dictionary<string, ScriptCommand>();
			CommandsFlat = new Dictionary<string, List<string>>();
			Maps = new Dictionary<string, List<string>>();
			Constants = new Dictionary<string, ScriptConstant>();
			ConstantsFlat = new Dictionary<string, List<string>>();

			LoadContent();
		}


		public void LoadContent() {
			string filepath = Environment.CurrentDirectory + @"/data/ScriptContentCommands.xml";
			if (File.Exists(filepath) == false) {
				MessageBox.Show("Failed to find \"ScriptContentCommands.xml\"!", "Script content error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			using (Stream fs = File.OpenRead(filepath)) {
				XmlSerializer xml = new XmlSerializer(typeof(ScriptCommandList));
				ScriptCommandList commands = (ScriptCommandList)xml.Deserialize(fs);
				if (commands != null) {
					foreach (ScriptCommand cmd in commands) {
						string newIndex = "";

						newIndex = cmd.Name.ToLower();
						Commands.Add(newIndex, cmd);
						PushContentToFlatList(CommandsFlat, newIndex);

						if (cmd.NameOptional.Length > 0) {
							newIndex = cmd.NameOptional.ToLower();
							Commands.Add(newIndex, cmd);
							PushContentToFlatList(CommandsFlat, newIndex);
						}

					}

				}

			}


			filepath = Environment.CurrentDirectory + @"/data/ScriptContentMaps.txt";
			if (File.Exists(filepath) == false) {
				MessageBox.Show("Failed to find \"ScriptContentMaps.xml\"!", "Script content error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			using (Stream fs = File.OpenRead(filepath)) {
				using (StreamReader reader = new StreamReader(fs)) {
					string map = "";
					while ((map = reader.ReadLine()) != null && map.Length > 0) {
						map = map.Trim();
						PushContentToFlatList(Maps, map);
					}
				}
			}



			filepath = Environment.CurrentDirectory + @"/data/ScriptContentConstants.xml";
			if (File.Exists(filepath) == false) {
				MessageBox.Show("Failed to find \"ScriptContentConstants.xml\"!", "Script content error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			using (Stream fs = File.OpenRead(filepath)) {
				XmlSerializer xml = new XmlSerializer(typeof(ScriptConstantList));
				ScriptConstantList constants = (ScriptConstantList)xml.Deserialize(fs);
				if (constants != null) {
					foreach (ScriptConstant constant in constants) {
						string name = constant.Name.ToLower();

						Constants.Add(name, constant);
						PushContentToFlatList(ConstantsFlat, name);
					}

				}

			}


		}


		private void PushContentToFlatList(Dictionary<string, List<string>> list, string key) {
			for (int i = 1; i < key.Length; i++) {
				string nameSub = key.Substring(0, i);
				if (list.ContainsKey(nameSub) == false) {
					list.Add(nameSub, new List<string>());
				}
				list[nameSub].Add(key);
			}

			// add full name
			if (list.ContainsKey(key) == false) {
				list.Add(key, new List<string>());
			}
			list[key].Add(key);
		}

	}

}
