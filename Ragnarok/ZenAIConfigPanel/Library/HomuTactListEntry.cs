
namespace ZenAIConfigPanel.Library {

	public class HomuTactListEntry {

		public int ID {
			get;
			set;
		}

		public string Name {
			get;
			set;
		}

		public EHomuBehavior Behavior {
			get;
			set;
		}

		public EHomuSkillUsage Skill {
			get;
			set;
		}

		public int Priority {
			get;
			set;
		}


		public HomuTactListEntry(int id, string name, EHomuBehavior behav, EHomuSkillUsage skill, int priority) {
			ID = id;
			Name = name;
			Behavior = behav;
			Skill = skill;
			Priority = priority;
		}


		public override string ToString() {
			return string.Format("Tact[ {0} ] = {{ \"{1}\", {2}, {3}, {4} }};", ID, Name, Tools.GetConfigName(Behavior), Tools.GetConfigName(Skill), Priority);
		}

	}

}
