using System;
using System.Windows.Forms;
namespace a
{
	public class V : e<V>
	{
		private string A;
		private V()
		{
		}
		public V(string text)
		{
			if (text == null)
			{
				throw new ArgumentException();
			}
			this.A = new o(text.Trim()).ToString();
		}
		public static V a(string a)
		{
			return new V
			{
				A = a
			};
		}
		public bool a(string text)
		{
			return this.A(new V(text));
		}
		public bool A(V v)
		{
			return v != null && this.A == v.A;
		}
		public override bool Equals(object obj)
		{
			return obj is V && V.a(this, (V)obj);
		}
		public static bool a(V v, V v2)
		{
			if (v != null)
			{
				return v.A(v2);
			}
			return v2 == null || v2.A(v);
		}
		public static bool B(V v, V v2)
		{
			return !V.a(v, v2);
		}
		public override string ToString()
		{
			return this.A;
		}
		public override int GetHashCode()
		{
			return (int)ulong.Parse(this.A);
		}
	}
	public class v
	{
		public static bool A(Control owner)
		{
			return MessageBox.Show(owner, "Systemfehler", j1.a(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK;
		}
		public static bool A(Control owner, string text)
		{
			return MessageBox.Show(owner, text, j1.a(), MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK;
		}
		public static bool a(Control owner, string text)
		{
			return MessageBox.Show(owner, text, j1.a(), MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK;
		}
		public static bool B(Control owner, string text)
		{
			return MessageBox.Show(owner, text, j1.a(), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK;
		}
		public static bool b(Control owner, string text)
		{
			return MessageBox.Show(owner, text, j1.a(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
		}
	}
}
