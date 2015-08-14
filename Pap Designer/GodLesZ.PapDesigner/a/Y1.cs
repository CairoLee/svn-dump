using b;
using d;
using E;
using System;
using System.Drawing;
using System.IO;
using System.Text;
namespace a
{
	public class Y1 : global::b.B
	{
		private new F2 A;
		private new int A;
		private new bool A = true;
		private new f2 A;
		private f2 a;
		private int a;
		public Y1(F2 f, E.a a, bool flag) : base(a)
		{
			this.A = f;
			this.A = flag;
		}
		public new bool A()
		{
			return this.A;
		}
		public new bool a()
		{
			return !this.A;
		}
		public new int A()
		{
			if (this.A == null)
			{
				return this.a;
			}
			Rectangle rectangle = this.A.A;
			if (!this.A())
			{
				return this.a + rectangle.Top;
			}
			return this.a + rectangle.Left;
		}
		public new int a()
		{
			if (this.a == null)
			{
				return this.a;
			}
			Rectangle rectangle = this.a.A;
			if (!this.A())
			{
				return this.a + rectangle.Bottom;
			}
			return this.a + rectangle.Right;
		}
		public int B()
		{
			return this.a;
		}
		public new void A(int num)
		{
			this.a = num;
		}
		public int b()
		{
			if (!this.A())
			{
				return 2147483647;
			}
			return this.a() - this.A();
		}
		public int C()
		{
			if (!this.a())
			{
				return 2147483647;
			}
			return this.a() - this.A();
		}
		public int c()
		{
			return this.A;
		}
		public void a(int num)
		{
			this.A = num;
		}
		public new void A(f2 f, bool flag, bool flag2)
		{
			f2 f2 = null;
			f2 f3 = null;
			if (this.A)
			{
				int num = base.a();
				for (int i = 0; i < this.A.I(); i++)
				{
					f2 f4 = this.A.a(num, i);
					if (f4 != global::b.C<f2, Y1>.h())
					{
						if (f2 == null)
						{
							f2 = f4;
							f3 = f4;
						}
						else
						{
							if (f4.A.Left < f2.A.Left)
							{
								f2 = f4;
							}
							if (f4.A.Right > f3.A.Right)
							{
								f3 = f4;
							}
						}
					}
				}
			}
			else
			{
				int num2 = base.a();
				for (int j = 0; j < this.A.h(); j++)
				{
					f2 f5 = this.A.a(j, num2);
					if (f5 != global::b.C<f2, Y1>.h())
					{
						if (f2 == null)
						{
							f2 = f5;
							f3 = f5;
						}
						else
						{
							if (f5.A.Top < f2.A.Top)
							{
								f2 = f5;
							}
							if (f5.A.Bottom > f3.A.Bottom)
							{
								f3 = f5;
							}
						}
					}
				}
			}
			this.A = f2;
			this.a = f3;
		}
		public new void A()
		{
			if (this.A)
			{
				int num = base.a();
				for (int i = 0; i < this.A.I(); i++)
				{
					f2 f = this.A.a(num, i);
					if (f != global::b.C<f2, Y1>.h())
					{
						d.a a = f.A;
						a.d(this.B());
					}
				}
				return;
			}
			int num2 = base.a();
			for (int j = 0; j < this.A.h(); j++)
			{
				f2 f2 = this.A.a(j, num2);
				if (f2 != global::b.C<f2, Y1>.h())
				{
					d.a a2 = f2.A;
					a2.G(this.B());
				}
			}
		}
	}
	public class y1
	{
		public static bool A(string text, string text2)
		{
			if (text == null && text2 == null)
			{
				return true;
			}
			if (text == null)
			{
				return false;
			}
			if (text2 == null)
			{
				return false;
			}
			if (K1.A())
			{
				text = text.ToLower();
				text2 = text2.ToLower();
			}
			string fullPath = Path.GetFullPath(text);
			string fullPath2 = Path.GetFullPath(text2);
			return fullPath == fullPath2;
		}
		public static string A(string text, int num)
		{
			if (num > 0)
			{
				text = text.Substring(0, Math.Min(text.Length, num));
			}
			char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
			for (int i = 0; i < invalidFileNameChars.Length; i++)
			{
				char oldChar = invalidFileNameChars[i];
				text = text.Replace(oldChar, '_');
			}
			return text;
		}
		public static string A(string text)
		{
			char[] invalidPathChars = Path.GetInvalidPathChars();
			for (int i = 0; i < invalidPathChars.Length; i++)
			{
				char oldChar = invalidPathChars[i];
				text = text.Replace(oldChar, '_');
			}
			return text;
		}
		public static string A(string path, string str)
		{
			return Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path) + str);
		}
		public static string a(string text, string text2)
		{
			text = text.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
			text2 = text2.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
			StringBuilder stringBuilder = new StringBuilder();
			int num = -1;
			int num2 = 0;
			while (num2 < text.Length && num2 < text2.Length)
			{
				char c = text[num2];
				if (char.ToLower(c) != char.ToLower(text2[num2]))
				{
					break;
				}
				stringBuilder.Append(c);
				if (c == Path.DirectorySeparatorChar)
				{
					num = num2;
				}
				num2++;
			}
			if (stringBuilder.Length > num + 1)
			{
				stringBuilder.Length = num + 1;
			}
			return stringBuilder.ToString();
		}
	}
}
