using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
namespace a
{
	public delegate void B(string[]);
	public interface b
	{
		void A(string[]);
	}
}
namespace A
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0"), DebuggerNonUserCode, CompilerGenerated]
	internal class B
	{
		private static ResourceManager A;
		private static CultureInfo A;
		internal B()
		{
		}
		internal static ResourceManager A()
		{
			if (object.ReferenceEquals(global::A.B.A, null))
			{
				ResourceManager a = new ResourceManager("PapDesigner.Resources.Tutorial", typeof(B).Assembly);
				global::A.B.A = a;
			}
			return global::A.B.A;
		}
		internal static CultureInfo A()
		{
			return global::A.B.A;
		}
		internal static void A(CultureInfo a)
		{
			global::A.B.A = a;
		}
		internal static byte[] A()
		{
			object @object = global::A.B.A().GetObject("Tutorial_Ablaufplan", global::A.B.A);
			return (byte[])@object;
		}
		internal static byte[] a()
		{
			object @object = global::A.B.A().GetObject("Tutorial_Programmierung", global::A.B.A);
			return (byte[])@object;
		}
		internal static byte[] B()
		{
			object @object = global::A.B.A().GetObject("Tutorial_Schleifen", global::A.B.A);
			return (byte[])@object;
		}
		internal static byte[] b()
		{
			object @object = global::A.B.A().GetObject("Tutorial_Unterprogramme", global::A.B.A);
			return (byte[])@object;
		}
		internal static byte[] C()
		{
			object @object = global::A.B.A().GetObject("Tutorial_Verzweigungen", global::A.B.A);
			return (byte[])@object;
		}
	}
}
