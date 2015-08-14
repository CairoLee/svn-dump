using System;

namespace ZenAIConfigPanel.Library {

	[AttributeUsage(AttributeTargets.All)]
	public class ConfigDescriptionAttribute : Attribute {

		public string Description {
			get;
			set;
		}

		public string ConfigName {
			get;
			set;
		}


		public ConfigDescriptionAttribute(string description, string configName) {
			Description = description;
			ConfigName = configName;
		}

	}

}
