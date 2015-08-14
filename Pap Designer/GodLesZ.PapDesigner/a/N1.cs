using System;
using System.IO;
namespace a
{
	public class N1 : ApplicationException
	{
		private Z1 A;
		private Z1 a;
		public Z1 A()
		{
			return this.A;
		}
		public Z1 a()
		{
			return this.a;
		}
		public N1(Z1 z, Z1 z2) : base("Legacy application version error")
		{
			this.A = z;
			this.a = z2;
		}
	}
	public class n1 : IDisposable
	{
		private static n1 A;
		private static bool A;
		private static string A;
		private TextWriter A;
		private n1()
		{
			if (n1.A)
			{
				throw new l1();
			}
			this.a();
		}
		public void Dispose()
		{
			try
			{
				this.A.Dispose();
			}
			catch (ObjectDisposedException)
			{
			}
			n1.A = null;
			this.A = null;
		}
		~n1()
		{
			this.Dispose();
		}
		private static n1 A()
		{
			if (n1.A == null)
			{
				n1.A = new n1();
			}
			return n1.A;
		}
		public static void A()
		{
			if (n1.A != null)
			{
				n1.A.Dispose();
				n1.A = true;
			}
		}
		private void a()
		{
			int num = 0;
			while (true)
			{
				try
				{
					string path = this.A(num);
					File.Delete(path);
					this.A = File.CreateText(path);
					this.A(num + 1);
					return;
				}
				catch (SystemException)
				{
				}
				if (num > 100)
				{
					break;
				}
				num++;
			}
			throw new l1();
		}
		private string A(int num)
		{
			return Path.Combine(K1.B(), string.Concat(new object[]
			{
				j1.a(),
				"-",
				num,
				".log"
			}));
		}
		private void A(int num)
		{
			int num2 = num;
			while (true)
			{
				try
				{
					string path = this.A(num2);
					if (!File.Exists(path))
					{
						break;
					}
					File.Delete(path);
				}
				catch (IOException)
				{
				}
				num2++;
			}
		}
		public static void A(string value)
		{
			TextWriter a = n1.A().A;
			a.Write(value);
			a.Flush();
		}
		public static void a(string value)
		{
			TextWriter a = n1.A().A;
			a.WriteLine(value);
			a.Flush();
		}
		public static void A(string format, params object[] arg)
		{
			TextWriter a = n1.A().A;
			a.WriteLine(format, arg);
			a.Flush();
		}
		public static void A(object obj, string text, string text2, params object[] arg)
		{
			TextWriter a = n1.A().A;
			a.WriteLine(string.Concat(new string[]
			{
				obj.GetType().Name,
				".",
				text,
				"(..) - ",
				text2
			}), arg);
			a.Flush();
		}
		public static void A(Exception ex)
		{
			TextWriter a = n1.A().A;
			string text = ex.GetType().Name + ": " + ex.Message + "\n";
			if (ex.StackTrace != null)
			{
				text += ex.StackTrace;
				text += "\n";
				if (n1.A == null)
				{
					n1.A = "";
					string pathRoot = Path.GetPathRoot(Environment.CurrentDirectory);
					string text2 = ") in ";
					int num = text.IndexOf(text2 + pathRoot);
					if (num >= 0)
					{
						num += text2.Length;
						int num2 = text.IndexOf(":", num + pathRoot.Length);
						if (num2 > num)
						{
							n1.A = text.Substring(num, num2 - num);
						}
					}
				}
				if (n1.A.Length > 0)
				{
					string text3 = y1.a(j1.e(), n1.A);
					if (!string.IsNullOrEmpty(text3))
					{
						text = text.Replace(text3, "");
					}
				}
			}
			a.WriteLine(text);
			a.Flush();
		}
		public static void B()
		{
		}
	}
}
