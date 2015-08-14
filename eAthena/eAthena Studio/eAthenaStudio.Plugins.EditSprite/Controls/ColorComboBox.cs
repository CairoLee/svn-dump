using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace eAthenaStudio.Plugins.EditSprite.Controls {

	public class ColorComboBox : ComboBox {
		private static List<ColorComboBoxItem> mColorItems;

		private int mPadding = 4;

		new public int Padding {
			get { return mPadding; }
			set { mPadding = value; }
		}

		public Color SelectedColor {
			get { return (Items[SelectedIndex] as ColorComboBoxItem).Color; }
		}

		public event EventHandler SelectedColorChanged;


		public ColorComboBox() {
			IntegralHeight = false;
			Sorted = false;
			DropDownStyle = ComboBoxStyle.DropDownList;
			DrawMode = DrawMode.OwnerDrawFixed;

			if (mColorItems == null) {
				mColorItems = new List<ColorComboBoxItem>();
				mColorItems.Add(new ColorComboBoxItem(Color.Transparent));
				mColorItems.Add(new ColorComboBoxItem(Color.Fuchsia));
				mColorItems.Add(new ColorComboBoxItem(Color.Blue));
				mColorItems.Add(new ColorComboBoxItem(Color.FromKnownColor(KnownColor.Highlight)));
				mColorItems.Add(new ColorComboBoxItem(Color.White));
				mColorItems.Add(new ColorComboBoxItem(Color.Black));
				mColorItems.Add(new ColorComboBoxItem(Color.Gray));
			}
			if (Items.Count == 0)
				Items.AddRange(mColorItems.ToArray());

			SelectedIndex = 0;
		}


		protected override void OnSelectedIndexChanged(EventArgs e) {
			if (SelectedIndex == -1)
				SelectedItem = null;
			else
				SelectedItem = Items[SelectedIndex];
			if (SelectedColorChanged != null)
				SelectedColorChanged(this, EventArgs.Empty);
		}

		protected override void OnDrawItem(System.Windows.Forms.DrawItemEventArgs e) {
			if (e.Index == -1)
				return;
			ColorComboBoxItem item = Items[e.Index] as ColorComboBoxItem;
			if (item == null) {
				base.OnDrawItem(e);
				return;
			}

			if ((e.State & DrawItemState.Focus) == 0)
				e.Graphics.FillRectangle(new SolidBrush(SystemColors.Window), e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
			else
				e.Graphics.FillRectangle(new SolidBrush(SystemColors.Highlight), e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);

			e.Graphics.FillRectangle(new SolidBrush(item.Color), e.Bounds.X + mPadding / 2, e.Bounds.Y + mPadding / 2, e.Bounds.Width - mPadding, e.Bounds.Height - mPadding);
		}

	}

}


