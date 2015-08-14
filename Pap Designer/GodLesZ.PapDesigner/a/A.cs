using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
namespace a
{
	internal class A
	{
		public static string[] A;
		[STAThread]
		private static int A(string[] array)
		{
			char c = global::a.A.A(array);
			bool flag = j1.A();
			try
			{
				if (c == 'u')
				{
					K1.A(true);
					string path = K1.B();
					n1.A();
					Directory.Delete(path, true);
					int result = 0;
					return result;
				}
				n1.A("");
				K1.A(false);
				global::a.A.A = array;
				if (!flag)
				{
					throw new ApplicationException();
				}
				n1.a("" + DateTime.Now);
				if (c == 's')
				{
					new d2().a();
				}
				else
				{
					new a<r1>().Run(array);
				}
			}
			catch (Exception ex)
			{
				if (flag)
				{
					n1.A(ex);
				}
				int result = 3;
				return result;
			}
			return 0;
		}
		private static char A(string[] array)
		{
			if (array == null)
			{
				return '\0';
			}
			if (array.Length < 1)
			{
				return '\0';
			}
			if (array[0].Length != 2)
			{
				return '\0';
			}
			if (!array[0].StartsWith("/") && !array[0].StartsWith("-"))
			{
				return '\0';
			}
			return char.ToLower(array[0][1]);
		}
	}
	public class a<T_FORM> : WindowsFormsApplicationBase where T_FORM : Form, b, new()
	{
		public a()
		{
			base.IsSingleInstance = true;
			base.EnableVisualStyles = true;
			base.ShutdownStyle = ShutdownMode.AfterMainFormCloses;
			base.StartupNextInstance += new StartupNextInstanceEventHandler(this.A);
		}
		protected void A(object obj, StartupNextInstanceEventArgs startupNextInstanceEventArgs)
		{
			string[] array = new string[startupNextInstanceEventArgs.CommandLine.Count];
			startupNextInstanceEventArgs.CommandLine.CopyTo(array, 0);
			object[] args = new object[]
			{
				array
			};
			T_FORM t_FORM = (T_FORM)((object)base.MainForm);
			B method = new B(t_FORM.A);
			t_FORM.Invoke(method, args);
		}
		protected override void OnCreateMainForm()
		{
			base.MainForm = Activator.CreateInstance<T_FORM>();
			string[] array = new string[base.CommandLineArgs.Count];
			base.CommandLineArgs.CopyTo(array, 0);
			T_FORM t_FORM = (T_FORM)((object)base.MainForm);
			t_FORM.A(array);
		}
	}
}
namespace A
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
			if (object.ReferenceEquals(global::A.A.A, null))
			{
				ResourceManager a = new ResourceManager("PapDesigner.Resources.SpecialCursors", typeof(A).Assembly);
				global::A.A.A = a;
			}
			return global::A.A.A;
		}
		internal static CultureInfo A()
		{
			return global::A.A.A;
		}
		internal static void A(CultureInfo a)
		{
			global::A.A.A = a;
		}
		internal static byte[] A()
		{
			object @object = global::A.A.A().GetObject("Add", global::A.A.A);
			return (byte[])@object;
		}
		internal static byte[] a()
		{
			object @object = global::A.A.A().GetObject("AddActivity", global::A.A.A);
			return (byte[])@object;
		}
		internal static byte[] B()
		{
			object @object = global::A.A.A().GetObject("AddComment", global::A.A.A);
			return (byte[])@object;
		}
		internal static byte[] b()
		{
			object @object = global::A.A.A().GetObject("AddCondition", global::A.A.A);
			return (byte[])@object;
		}
		internal static byte[] C()
		{
			object @object = global::A.A.A().GetObject("AddConnector", global::A.A.A);
			return (byte[])@object;
		}
		internal static byte[] c()
		{
			object @object = global::A.A.A().GetObject("AddInput", global::A.A.A);
			return (byte[])@object;
		}
		internal static byte[] D()
		{
			object @object = global::A.A.A().GetObject("AddInteraction", global::A.A.A);
			return (byte[])@object;
		}
		internal static byte[] d()
		{
			object @object = global::A.A.A().GetObject("AddLoop", global::A.A.A);
			return (byte[])@object;
		}
		internal static byte[] E()
		{
			object @object = global::A.A.A().GetObject("AddModule", global::A.A.A);
			return (byte[])@object;
		}
		internal static byte[] e()
		{
			object @object = global::A.A.A().GetObject("AddOutput", global::A.A.A);
			return (byte[])@object;
		}
		internal static byte[] F()
		{
			object @object = global::A.A.A().GetObject("CatchRect", global::A.A.A);
			return (byte[])@object;
		}
		internal static byte[] f()
		{
			object @object = global::A.A.A().GetObject("ChangeToActivity", global::A.A.A);
			return (byte[])@object;
		}
		internal static byte[] G()
		{
			object @object = global::A.A.A().GetObject("ChangeToCondition", global::A.A.A);
			return (byte[])@object;
		}
		internal static byte[] g()
		{
			object @object = global::A.A.A().GetObject("ChangeToInput", global::A.A.A);
			return (byte[])@object;
		}
		internal static byte[] H()
		{
			object @object = global::A.A.A().GetObject("ChangeToInteraction", global::A.A.A);
			return (byte[])@object;
		}
		internal static byte[] h()
		{
			object @object = global::A.A.A().GetObject("ChangeToLoop", global::A.A.A);
			return (byte[])@object;
		}
		internal static byte[] I()
		{
			object @object = global::A.A.A().GetObject("ChangeToModule", global::A.A.A);
			return (byte[])@object;
		}
		internal static byte[] i()
		{
			object @object = global::A.A.A().GetObject("ChangeToOutput", global::A.A.A);
			return (byte[])@object;
		}
		internal static byte[] J()
		{
			object @object = global::A.A.A().GetObject("Clipboard", global::A.A.A);
			return (byte[])@object;
		}
		internal static byte[] j()
		{
			object @object = global::A.A.A().GetObject("Hand", global::A.A.A);
			return (byte[])@object;
		}
		internal static byte[] K()
		{
			object @object = global::A.A.A().GetObject("Move", global::A.A.A);
			return (byte[])@object;
		}
		internal static byte[] k()
		{
			object @object = global::A.A.A().GetObject("MoveNS", global::A.A.A);
			return (byte[])@object;
		}
		internal static byte[] L()
		{
			object @object = global::A.A.A().GetObject("MoveNSAdd", global::A.A.A);
			return (byte[])@object;
		}
		internal static byte[] l()
		{
			object @object = global::A.A.A().GetObject("Replicate", global::A.A.A);
			return (byte[])@object;
		}
	}
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0"), DebuggerNonUserCode, CompilerGenerated]
	internal class a
	{
		private static ResourceManager A;
		private static CultureInfo A;
		internal a()
		{
		}
		internal static ResourceManager A()
		{
			if (object.ReferenceEquals(global::A.a.A, null))
			{
				ResourceManager a = new ResourceManager("PapDesigner.Resources.Symbols16", typeof(a).Assembly);
				global::A.a.A = a;
			}
			return global::A.a.A;
		}
		internal static CultureInfo A()
		{
			return global::A.a.A;
		}
		internal static void A(CultureInfo a)
		{
			global::A.a.A = a;
		}
		internal static Bitmap A()
		{
			object @object = global::A.a.A().GetObject("sym_act_16", global::A.a.A);
			return (Bitmap)@object;
		}
		internal static Bitmap a()
		{
			object @object = global::A.a.A().GetObject("sym_branch_16", global::A.a.A);
			return (Bitmap)@object;
		}
		internal static Bitmap B()
		{
			object @object = global::A.a.A().GetObject("sym_conn_16", global::A.a.A);
			return (Bitmap)@object;
		}
		internal static Bitmap b()
		{
			object @object = global::A.a.A().GetObject("sym_in_16", global::A.a.A);
			return (Bitmap)@object;
		}
		internal static Bitmap C()
		{
			object @object = global::A.a.A().GetObject("sym_info_16", global::A.a.A);
			return (Bitmap)@object;
		}
		internal static Bitmap c()
		{
			object @object = global::A.a.A().GetObject("sym_loop_16", global::A.a.A);
			return (Bitmap)@object;
		}
		internal static Bitmap D()
		{
			object @object = global::A.a.A().GetObject("sym_mod_16", global::A.a.A);
			return (Bitmap)@object;
		}
		internal static Bitmap d()
		{
			object @object = global::A.a.A().GetObject("sym_out_16", global::A.a.A);
			return (Bitmap)@object;
		}
	}
}
