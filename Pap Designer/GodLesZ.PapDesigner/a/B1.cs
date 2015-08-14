using c;
using C;
using System;
using System.Drawing;
namespace a
{
	public interface B1
	{
		Graphics A();
		int a();
		Color B();
		bool b();
		bool C();
		bool c();
		bool D();
		string d();
		string E();
		int e(global::c.a);
	}
	public class b1 : B1
	{
		private e2 A;
		private Graphics A;
		private bool A;
		private a1 A;
		private bool a;
		private static int A;
		private int a = b1.A = b1.A % 1048576 + 1;
		public b1(e2 e, Graphics graphics, a1 a, bool flag, bool flag2)
		{
			this.A = e;
			this.A = graphics;
			this.A = a;
			this.A = flag;
			this.a = flag2;
		}
		public int a()
		{
			return this.a;
		}
		public Graphics A()
		{
			return this.A;
		}
		public Color B()
		{
			if (this.A == a1.Paper || this.A == a1.Picture)
			{
				return Color.White;
			}
			return this.A.BackColor;
		}
		public bool b()
		{
			return this.A != a1.Screen;
		}
		public bool C()
		{
			return this.A == a1.Picture;
		}
		public bool c()
		{
			return this.A == a1.Clip;
		}
		public bool D()
		{
			return this.A;
		}
		public bool F()
		{
			return this.a;
		}
		public string d()
		{
			if (!this.F())
			{
				return "E";
			}
			return "I";
		}
		public string E()
		{
			if (!this.F())
			{
				return "A";
			}
			return "O";
		}
		public int e(global::c.a a)
		{
			if (this.A.L().A(a))
			{
				return 1;
			}
			if (a is global::C.C && this.A.L().A() != null && !this.A.L().A().D() && this.A.L().A(((global::C.C)a).A()))
			{
				return 1;
			}
			return 0;
		}
	}
}
