using System.Windows.Forms;
using ZenAIConfigPanel.Library;

namespace ZenAIConfigPanel.Controls {

	public class HomuTactListViewItem : ListViewItem {
		private HomuTactListEntry mEntry;

		public HomuTactListEntry Entry {
			get { return mEntry; }
			set { mEntry = value; }
		}


		public HomuTactListViewItem(HomuTactListEntry Entry)
			: base(new string[] { Entry.ID.ToString(), Entry.Name, Entry.Behavior.ToString(), Entry.Skill.ToString(), Entry.Priority.ToString() }) {
			mEntry = Entry;
		}

	}

}
