using a;
using b;
using System;
using System.Drawing;
using System.Xml;
namespace E
{
	public sealed class a
	{
		public int A;
		public global::b.B A;
	}
	public class A : global::b.a
	{
		public A(Point point) : base(point, "Ende")
		{
		}
		public A(XmlReader xmlReader, w1 w) : base(xmlReader, w)
		{
		}
		public override int r()
		{
			return 1;
		}
		public override int S()
		{
			return 3;
		}
		public override bool v(G2 g)
		{
			return g == G2.South && base.v(g);
		}
	}
}
