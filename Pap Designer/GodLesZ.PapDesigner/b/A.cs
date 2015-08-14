using a;
using c;
using d;
using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Xml;
namespace B
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0"), DebuggerNonUserCode, CompilerGenerated]
	internal class A
	{
		private static ResourceManager A;
		private static CultureInfo A;
		internal A()
		{
		}
		internal static ResourceManager A()
		{
			if (object.ReferenceEquals(global::B.A.A, null))
			{
				ResourceManager a = new ResourceManager("PapDesigner.Properties.Resources", typeof(A).Assembly);
				global::B.A.A = a;
			}
			return global::B.A.A;
		}
		internal static CultureInfo A()
		{
			return global::B.A.A;
		}
		internal static void A(CultureInfo a)
		{
			global::B.A.A = a;
		}
	}
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "8.0.0.0"), CompilerGenerated]
	internal sealed class a : ApplicationSettingsBase
	{
		private static a A = (a)SettingsBase.Synchronized(new a());
		public static a A()
		{
			return a.A;
		}
	}
}
namespace b
{
	public abstract class a : d.a
	{
		public a(Point point, string text) : base(point, text)
		{
		}
		public a(XmlReader xmlReader, w1 w) : base(xmlReader, w)
		{
		}
		public override bool d()
		{
			return false;
		}
		public override Size h()
		{
			return new Size(100, 30);
		}
		public override Color J()
		{
			return Color.LightBlue;
		}
		public override Font K()
		{
			return global::c.C.b();
		}
		public override void P(GraphicsPath graphicsPath)
		{
			Rectangle rectangle = this.L();
			int height = rectangle.Height;
			int num = height / 2;
			Rectangle rectangle2 = rectangle;
			rectangle2.Width = height;
			Rectangle rect = rectangle2;
			rect.X += rectangle.Width - height;
			graphicsPath.AddArc(rectangle2, 90f, 180f);
			graphicsPath.AddLine(rectangle2.X + num, rectangle2.Y, rect.X + num, rect.Y);
			graphicsPath.AddArc(rect, -90f, 180f);
			graphicsPath.AddLine(rectangle2.X + num, rectangle2.Y + height, rect.X + num, rect.Y + height);
		}
		public override int r()
		{
			return 0;
		}
		public override int S()
		{
			return 0;
		}
		public override int s()
		{
			return 0;
		}
		public override int T()
		{
			return 0;
		}
	}
	public class A : a
	{
		public A(Point point) : base(point, "Start")
		{
		}
		public A(XmlReader xmlReader, w1 w) : base(xmlReader, w)
		{
		}
		public override int s()
		{
			return 1;
		}
		public override int T()
		{
			return 1;
		}
		public override bool V(G2 g, bool flag)
		{
			return g == G2.South && base.V(g, flag);
		}
	}
}
