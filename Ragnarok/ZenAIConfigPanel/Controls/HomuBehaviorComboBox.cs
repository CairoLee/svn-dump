using System;
using System.Drawing;
using System.Windows.Forms;
using ZenAIConfigPanel.Library;

namespace ZenAIConfigPanel.Controls {

	public class HomuBehaviorComboBox : ComboBox {

		public HomuBehaviorComboBox() {
			DropDownStyle = ComboBoxStyle.DropDownList;
			DrawMode = DrawMode.OwnerDrawFixed;
		}


		protected override void OnDrawItem(DrawItemEventArgs e) {
			if (e.Index == -1 || Items[e.Index] == null) {
				base.OnDrawItem(e);
				return;
			}

			object item = Items[e.Index];
			if (Enum.IsDefined(typeof(EHomuBehavior), item) == false) {
				base.OnDrawItem(e);
				return;
			}

			EHomuBehavior behav = (EHomuBehavior)Enum.Parse(typeof(EHomuBehavior), item.ToString());
			Color texCol = Color.Black;
			switch (behav) {
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

			if ((e.State & DrawItemState.Selected) != 0)
				e.Graphics.FillRectangle(new SolidBrush(Color.LightBlue), e.Bounds);
			else
				e.Graphics.FillRectangle(new SolidBrush(BackColor), e.Bounds);

			e.Graphics.DrawString(behav.ToString(), Font, new SolidBrush(texCol), new Point(e.Bounds.X, e.Bounds.Y));
		}

	}

}
