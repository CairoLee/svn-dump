
namespace ZenAIConfigPanel.Library {

	public enum EHomuSkillUsage {
		[ConfigDescription("don't waste SPs for skills", "WITH_no_skill")]
		NoSkill = 0,
		[ConfigDescription("only one skill in the beginning of the attack", "WITH_one_skill")]
		OneSkill = 1,
		[ConfigDescription("only two skill in the beginning of the attack", "WITH_two_skills")]
		TwoSkills = 2,
		[ConfigDescription("use skills, until the time out expires", "WITH_max_skills")]
		MaxSkills = 3,
		[ConfigDescription("use skills, until there are enough SPs", "WITH_full_power")]
		FullPower = 4,
		[ConfigDescription("use skills after a small delay", "WITH_slow_power")]
		SlowPower = 5,
	}

	public static class EHomuSkillUsageExtension {
		public static bool FromConfig(this string Value, out EHomuSkillUsage Skill) {
			Skill = (EHomuSkillUsage)(-1);
			if (Value == "WITH_no_skill")
				Skill = EHomuSkillUsage.NoSkill;
			else if (Value == "WITH_one_skill")
				Skill = EHomuSkillUsage.OneSkill;
			else if (Value == "WITH_two_skills")
				Skill = EHomuSkillUsage.TwoSkills;
			else if (Value == "WITH_max_skills")
				Skill = EHomuSkillUsage.MaxSkills;
			else if (Value == "WITH_full_power")
				Skill = EHomuSkillUsage.FullPower;
			else if (Value == "WITH_slow_power")
				Skill = EHomuSkillUsage.SlowPower;

			return (Skill != (EHomuSkillUsage)(-1));
		}
	}

}
