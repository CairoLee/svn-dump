using System;
namespace a
{
	public class G1 : F1
	{
		private new int A = -1;
		private new int a = -1;
		public G1(h2 h, p1 p, string text) : base(h, p, text)
		{
			this.A = h.E(p);
		}
		protected override bool D()
		{
			this.a = base.d().E(base.A());
			return this.a != this.A;
		}
		protected override void C()
		{
			this.A(this.a, this.A);
		}
		protected override void c()
		{
			this.A(this.A, this.a);
		}
		private new void A(int num, int num2)
		{
			int num3 = num2;
			if (num2 > num)
			{
				num3++;
			}
			if (base.d().E(base.A()) != num2)
			{
				base.d().E(base.A(), num3);
			}
		}
	}
	public class g1 : F1
	{
		protected new byte[] A;
		protected new byte[] a;
		protected g1(h2 h, p1 p, string text) : base(h, p, text)
		{
		}
		public g1(h2 h, s1 s, byte[] array, string text) : base(h, s, text)
		{
			this.A = ((array != null) ? array : j2.A(base.A()));
		}
		public g1(h2 h, p1 p, byte[] array, string text) : base(h, p, text)
		{
			this.A = ((array != null) ? array : j2.A(base.A()));
		}
		public new byte[] A()
		{
			return this.a;
		}
		protected override bool D()
		{
			this.a = j2.A(base.A());
			bool flag = j2.A(this.A, this.a);
			if (flag)
			{
				T1 t = this.A.A();
				if (t != null)
				{
					this.a = new K(t);
				}
			}
			return flag;
		}
		protected override void C()
		{
			base.A().I(this.A);
			if (this.A != null)
			{
				this.A.A();
			}
		}
		protected override void c()
		{
			base.A().I(this.a);
			if (this.a != null)
			{
				this.a.A();
			}
		}
	}
}
