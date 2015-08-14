using System;
using System.Windows.Forms;
namespace a
{
	public class E : TextBox
	{
		private string A;
		public E()
		{
			base.AcceptsTab = true;
			this.A(4);
		}
		public int A()
		{
			return this.A.Length;
		}
		public void A(int val)
		{
			this.A = new string(' ', Math.Min(val, 8));
		}
		protected override void OnKeyPress(KeyPressEventArgs keyPressEventArgs)
		{
			if (keyPressEventArgs.KeyChar == '\t')
			{
				keyPressEventArgs.Handled = true;
				string text = this.Text;
				string text2 = text.Substring(0, base.SelectionStart);
				string str = text.Substring(base.SelectionStart + this.SelectionLength);
				this.SelectionLength = 0;
				this.Text = text2 + this.A + str;
				base.SelectionStart = text2.Length + this.A.Length;
				return;
			}
			base.OnKeyPress(keyPressEventArgs);
		}
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			if (this.Text.Contains("\t"))
			{
				int num = this.Text.Length - base.SelectionStart;
				this.Text = this.Text.Replace("\t", this.A);
				base.SelectionStart = this.Text.Length - num;
			}
		}
	}
	public interface e<T>
	{
		bool A(T);
	}
}
