using System;
namespace a
{
	public class E1 : d1
	{
		private new i1 A;
		private new E1 A;
		private new bool A = true;
		private new bool a = true;
		public E1(i1 i, h2 h, string text) : base(h, text)
		{
			this.A = i;
			this.A = true;
			this.a = false;
			this.A = null;
		}
		public E1(E1 e) : base(e.d(), e.d())
		{
			this.A = e.A;
			this.A = false;
			this.a = true;
			this.A = e;
			e.A = this;
		}
		public new bool A()
		{
			return this.A;
		}
		public bool a()
		{
			return this.a;
		}
		public new E1 A()
		{
			return this.A;
		}
		protected override bool D()
		{
			return true;
		}
		protected override void C()
		{
			if (this.a)
			{
				while (this.A.A())
				{
					d1 d = this.A.A();
					this.A.a();
					if (d is E1 && ((E1)d).A)
					{
						return;
					}
				}
			}
		}
		protected override void c()
		{
			if (this.A)
			{
				while (this.A.a())
				{
					d1 d = this.A.a();
					this.A.B();
					if (d is E1 && ((E1)d).a)
					{
						return;
					}
				}
			}
		}
	}
	public class e1 : d1
	{
		private new string A;
		private new string a;
		private new string B;
		private new string b;
		public e1(h2 h, string text) : base(h, text)
		{
			this.A = h.b();
			this.a = h.E();
		}
		protected override bool D()
		{
			this.B = base.d().b();
			this.b = base.d().E();
			return this.B != this.A || this.b != this.a;
		}
		protected override void C()
		{
			if (base.d().b() != this.A)
			{
				base.d().b(this.A);
			}
			if (base.d().E() != this.a)
			{
				base.d().E(this.a);
			}
		}
		protected override void c()
		{
			if (base.d().b() != this.B)
			{
				base.d().b(this.B);
			}
			if (base.d().E() != this.b)
			{
				base.d().E(this.b);
			}
		}
	}
}
