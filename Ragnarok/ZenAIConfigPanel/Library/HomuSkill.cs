using System;

namespace ZenAIConfigPanel.Library {

	public class HomuSkill {
		public static readonly HomuSkill Empty = new HomuSkill("", "", 0, 0);

		private string mNameInternal;

		public string Name {
			get;
			set;
		}

		public string NameInternal {
			get { return mNameInternal; }
		}

		public int Level {
			get;
			set;
		}

		public int MinSP {
			get;
			set;
		}


		public HomuSkill()
			: this("", "", 0, 0) {
		}

		public HomuSkill(string name, string nameInternal, int minSP, int level) {
			Name = name;
			mNameInternal = nameInternal;
			MinSP = minSP;
			Level = level;
		}


		public override string ToString() {
			string retString = "";
			string nl = Environment.NewLine;
			retString += string.Format("{0} = {{}};{1}", Name, nl);
			retString += string.Format("{0}.MinSP = {1};{2}", Name, MinSP, nl);
			retString += string.Format("{0}.Level = {1};{2}", Name, Level, (Level == 0 ? " -- disabled" : ""));
			return retString;
		}

	}

}
