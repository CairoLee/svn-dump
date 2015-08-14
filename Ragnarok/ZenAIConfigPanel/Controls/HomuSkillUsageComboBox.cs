using System;
using System.Drawing;
using System.Windows.Forms;
using ZenAIConfigPanel.Library;

namespace ZenAIConfigPanel.Controls {

	public class HomuSkillUsageComboBox : ComboBox {

		public HomuSkillUsageComboBox() {
			DropDownStyle = ComboBoxStyle.DropDownList;
			DrawMode = DrawMode.OwnerDrawFixed;
		}


		protected override void OnDrawItem(DrawItemEventArgs e) {
			if (e.Index == -1 || Items[e.Index] == null) {
				base.OnDrawItem(e);
				return;
			}

			object item = Items[e.Index];
			if (Enum.IsDefined(typeof(EHomuSkillUsage), item) == false) {
				base.OnDrawItem(e);
				return;
			}

			EHomuSkillUsage skill = (EHomuSkillUsage)Enum.Parse(typeof(EHomuSkillUsage), item.ToString());
			Color texCol = Color.Black;
			if (skill == EHomuSkillUsage.NoSkill)
				texCol = Color.Gray;

			if ((e.State & DrawItemState.Selected) != 0)
				e.Graphics.FillRectangle(new SolidBrush(Color.LightBlue), e.Bounds);
			else
				e.Graphics.FillRectangle(new SolidBrush(BackColor), e.Bounds);

			e.Graphics.DrawString(skill.ToString(), Font, new SolidBrush(texCol), new Point(e.Bounds.X, e.Bounds.Y));
		}

	}

}
