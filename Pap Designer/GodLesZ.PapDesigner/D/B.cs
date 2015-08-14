using a;
using b;
using d;
using System;
using System.Collections;
using System.Drawing;
using System.Xml;
namespace D
{
	public class B<T_VALUE, T_LANEPTR> : IEnumerable, IEnumerator where T_LANEPTR : global::b.B
	{
		private global::b.C<T_VALUE, T_LANEPTR> A;
		private int A;
		private int a = 2147483647;
		public B(global::b.C<T_VALUE, T_LANEPTR> c)
		{
			this.A = c;
			this.A();
		}
		private void A()
		{
			this.A = this.A.I();
			this.a = 2147483647;
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			this.A();
			return this;
		}
		public T_LANEPTR A()
		{
			return this.A.I(this.a);
		}
		object IEnumerator.get_Current()
		{
			return this.A.I(this.a);
		}
		bool IEnumerator.MoveNext()
		{
			if (this.A != this.A.I())
			{
				throw new InvalidOperationException("collection changed");
			}
			if (this.a == 2147483647)
			{
				this.a = 0;
			}
			else
			{
				this.a++;
			}
			return this.a < this.A.I();
		}
		void IEnumerator.Reset()
		{
			this.A();
		}
	}
	public class b : d.c
	{
		public b(Point point, string text) : base(point, text)
		{
		}
		public b(XmlReader xmlReader, w1 w) : base(xmlReader, w)
		{
		}
		public override string c1(B1 b)
		{
			return b.d();
		}
	}
}
namespace d
{
	public class B : a
	{
		public B(Point point, string text) : base(point, text)
		{
		}
		public B(XmlReader xmlReader, w1 w) : base(xmlReader, w)
		{
		}
		public override Size O()
		{
			return new Size(12, 0);
		}
		public override void z(B1 b)
		{
			Graphics graphics = b.A();
			base.z(b);
			Rectangle rectangle = this.o();
			Pen pen = this.G(b);
			graphics.DrawLine(pen, rectangle.X, rectangle.Y, rectangle.X, rectangle.Y + rectangle.Height);
			graphics.DrawLine(pen, rectangle.X + rectangle.Width, rectangle.Y, rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height);
		}
	}
	public class b : a
	{
		public b(Point point, string text) : base(point, text)
		{
		}
		public b(XmlReader xmlReader, w1 w) : base(xmlReader, w)
		{
		}
	}
}
