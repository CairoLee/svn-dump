using System;
namespace a
{
	public abstract class F1 : d1
	{
		protected new int A = -1;
		protected new K A;
		protected new K a;
		public F1(h2 h, p1 p, string text) : base(h, text)
		{
			this.A = p.A();
		}
		public F1(h2 h, s1 s, string text) : base(h, text)
		{
			this.A = s.A().A();
			if (s is T1)
			{
				this.a = (this.A = new K((T1)s));
			}
		}
		public new int A()
		{
			return this.A;
		}
		public new p1 A()
		{
			return (p1)base.d().E().B(this.A);
		}
	}
	public class f1 : F1
	{
		private new string A;
		private new string a;
		private new bool A;
		private new bool a;
		public f1(h2 h, p1 p, string text) : base(h, p, text)
		{
			this.A = base.A().b();
			this.A = base.A().E();
		}
		protected override bool D()
		{
			this.a = base.A().b();
			this.a = base.A().E();
			return this.a != this.A || this.A != this.a;
		}
		protected override void C()
		{
			if (base.A().b() != this.A)
			{
				base.A().b(this.A);
			}
			if (base.A().E() != this.A)
			{
				base.A().e(this.A);
			}
		}
		protected override void c()
		{
			if (base.A().b() != this.a)
			{
				base.A().b(this.a);
			}
			if (base.A().E() != this.a)
			{
				base.A().e(this.a);
			}
		}
	}
}
