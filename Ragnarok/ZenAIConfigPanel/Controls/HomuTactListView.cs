using System.Drawing;
using System.Windows.Forms;
using ZenAIConfigPanel.Library;

namespace ZenAIConfigPanel.Controls {

	public class HomuTactListView : ListView {

		public HomuTactListView() {
			OwnerDraw = true;
		}


		protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e) {
			e.DrawDefault = true;
			base.OnDrawColumnHeader(e);
		}

		protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e) {
			ListViewItem item = Items[e.ItemIndex];
			if (item == null || !(item is HomuTactListViewItem)) {
				e.DrawDefault = true;
				return;
			}

			HomuTactListEntry entry = (item as HomuTactListViewItem).Entry;
			Color texCol = Color.Black;
			switch (entry.Behavior) {
				case EHomuBehavior.Attack:
				case EHomuBehavior.Attack1st:
				case EHomuBehavior.AttackLast:
				case EHomuBehavior.AttackWeak:
					texCol = Color.Maroon;
					break;
				case EHomuBehavior.React:
				case EHomuBehavior.React1st:
				case EHomuBehavior.ReactLast:
					texCol = Color.Violet;
					break;
				case EHomuBehavior.Avoid:
					texCol = Color.Gray;
					break;
				case EHomuBehavior.Coward:
					texCol = Color.Blue;
					break;
			}

			SolidBrush drawBrush = new SolidBrush(texCol);
			Point drawPoint = new Point(e.Bounds.X, e.Bounds.Y);

			e.DrawBackground();
			if (SelectedIndices.Contains(e.ItemIndex) == true)
				e.Graphics.FillRectangle(Brushes.LightBlue, e.Bounds);

			if (e.ColumnIndex == 0)
				e.Graphics.DrawString(entry.ID.ToString(), new Font(Font, FontStyle.Bold), drawBrush, drawPoint);
			else if (e.ColumnIndex == 1)
				e.Graphics.DrawString(entry.Name, Font, drawBrush, drawPoint);
			else if (e.ColumnIndex == 2)
				e.Graphics.DrawString(entry.Behavior.ToString(), Font, drawBrush, drawPoint);
			else if (e.ColumnIndex == 3 && entry.Behavior != EHomuBehavior.Avoid)
				e.Graphics.DrawString(entry.Skill.ToString(), Font, drawBrush, drawPoint);
			else if (e.ColumnIndex == 4 && entry.Behavior != EHomuBehavior.Avoid && entry.Skill != EHomuSkillUsage.NoSkill)
				e.Graphics.DrawString(entry.Priority.ToString(), Font, drawBrush, drawPoint);
		}

	}

}
