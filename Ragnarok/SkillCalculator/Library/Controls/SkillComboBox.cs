using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace GodLesZ.Ragnarok.SkillCalculator.Library.Controls {

	public class SkillComboBox : ComboBox {

		public SkillComboBox()
			: base() {
			DrawMode = DrawMode.OwnerDrawFixed;
			DropDownStyle = ComboBoxStyle.DropDownList;
			ItemHeight = 25;

			MaxDropDownItems = 10;
		}


		protected override void OnDrawItem(DrawItemEventArgs e) {
			if (e.Index == -1) {
				base.OnDrawItem(e);
				return;
			}

			object item = Items[e.Index];
			if (!(item is SkillDBSkill)) {
				base.OnDrawItem(e);
				return;
			}

			SkillDBSkill skill = (item as SkillDBSkill);

			e.DrawBackground();
			e.DrawFocusRectangle();

			if (skill.ImageExists == true) {
				e.Graphics.DrawImageUnscaled(skill.Image, new Point(e.Bounds.X, e.Bounds.Y));
			}

			string text = skill.Name.Replace("_", " ");
			float stringPadddingY = (e.Graphics.MeasureString(text, Font).Height / 2);
			float stringPadddingX = 26;
			e.Graphics.DrawString(text, Font, new SolidBrush(ForeColor), new PointF(e.Bounds.X + stringPadddingX, e.Bounds.Y + stringPadddingY));
		}

	}

}
