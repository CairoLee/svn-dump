using System;
namespace a
{
	public class H1 : g1
	{
		private new p1 A;
		public H1(h2 h, p1 p, string text) : base(h, p, text)
		{
			this.A = p;
		}
		protected override bool D()
		{
			this.A = this.A.A();
			this.A = null;
			this.a = j2.A(base.A());
			return true;
		}
		protected override void C()
		{
			base.d().e(base.A());
		}
		protected override void c()
		{
			Q1 q = new Q1(this.a);
			base.d().E(q);
		}
	}
	public class h1 : g1
	{
		private new int A = -1;
		public h1(h2 h, p1 p, byte[] array, string text) : base(h, p, array, text)
		{
			this.A = h.E(p);
		}
		protected override bool D()
		{
			return true;
		}
		protected override void C()
		{
			Q1 q = new Q1(this.A);
			base.d().E(q);
			base.d().E(base.A(), this.A);
		}
		protected override void c()
		{
			base.d().e(base.A());
		}
	}
}
