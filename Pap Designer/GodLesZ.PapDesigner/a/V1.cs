using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
namespace a
{
	public class V1 : UserControl
	{
		public delegate void A(s1);
		private W1<h2> A;
		private Dictionary<h2, B2> A = new Dictionary<h2, B2>();
		private s1 A;
		private V1.A A;
		private IContainer A;
		public V1()
		{
			this.a();
		}
		public W1<h2> A()
		{
			return this.A;
		}
		public void A(W1<h2> w)
		{
			if (this.A != w)
			{
				if (this.A != null)
				{
					this.A.b(new W1<h2>.B(this.A));
					this.A.e(new W1<h2>.a(this.B));
					foreach (h2 current in this.A)
					{
						this.B(current);
					}
				}
				this.A = w;
				if (this.A != null)
				{
					int num = 0;
					foreach (h2 current2 in this.A)
					{
						this.A(current2, num++);
					}
					this.A.B(new W1<h2>.B(this.A));
					this.A.E(new W1<h2>.a(this.B));
				}
			}
		}
		public s1 A()
		{
			B2 b = this.A();
			if (b == null)
			{
				return null;
			}
			return b.A();
		}
		private B2 A()
		{
			foreach (Control control in base.Controls)
			{
				if (control is B2)
				{
					return (B2)control;
				}
			}
			return null;
		}
		public h2 A()
		{
			B2 b = this.A();
			if (b == null)
			{
				return null;
			}
			return (h2)b.Tag;
		}
		public override Cursor get_Cursor()
		{
			return base.Cursor;
		}
		public override void set_Cursor(Cursor cursor)
		{
			base.Cursor = cursor;
			B2 b = this.A();
			foreach (B2 current in this.A.Values)
			{
				if (current != b)
				{
					current.UseWaitCursor = (cursor == Cursors.WaitCursor);
					g.A(current, cursor);
				}
			}
		}
		public void A(h2 h)
		{
			this.A(h);
			this.A();
		}
		public void a(h2 h)
		{
			B2 b = this.A[h];
			b.a(h);
		}
		public s1 A(p1 p)
		{
			foreach (h2 current in this.A)
			{
				if (current.E().B(p))
				{
					B2 b = this.A(current);
					s1 result = b.A(p);
					this.A();
					return result;
				}
			}
			throw new ArgumentException();
		}
		private B2 A(h2 key)
		{
			B2 b = this.A[key];
			if (b != this.A())
			{
				base.Controls.Clear();
				base.Controls.Add(b);
				base.Invalidate();
			}
			return b;
		}
		private void A(h2 h, int num)
		{
			B2 b = new B2();
			b.Dock = DockStyle.Fill;
			b.Tag = h;
			this.A.Add(h, b);
			b.A(h);
			b.A(new B2.A(this.A));
			this.A();
		}
		private void B(h2 key)
		{
			B2 b = this.A[key];
			b.a(new B2.A(this.A));
			b.A(null);
			B2 b2 = this.A[key];
			this.A.Remove(key);
			b2.Dispose();
			this.A();
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void A(V1.A b)
		{
			this.A = (V1.A)Delegate.Combine(this.A, b);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void a(V1.A value)
		{
			this.A = (V1.A)Delegate.Remove(this.A, value);
		}
		private void A(s1 s)
		{
			this.A();
		}
		private void A()
		{
			s1 a = this.A;
			this.A = this.A();
			if (this.A != a && this.A != null)
			{
				this.A(this.A);
			}
		}
		protected override void Dispose(bool flag)
		{
			if (flag && this.A != null)
			{
				this.A.Dispose();
			}
			base.Dispose(flag);
		}
		private void a()
		{
			base.SuspendLayout();
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Name = "FlipView";
			base.Size = new Size(366, 272);
			base.ResumeLayout(false);
		}
	}
	public interface v1
	{
		bool A(string);
	}
}
