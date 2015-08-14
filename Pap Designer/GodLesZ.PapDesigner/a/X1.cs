using System;
using System.IO;
namespace a
{
	public class X1
	{
	}
	public class x1
	{
		private string A;
		private string a;
		private string B;
		public x1(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				throw new ArgumentException();
			}
			if (text.IndexOfAny(Path.GetInvalidPathChars(), 0) >= 0)
			{
				throw new ArgumentException();
			}
			this.A = text;
			this.a = Path.Combine(Path.GetDirectoryName(text), Path.GetFileNameWithoutExtension(text) + ".temp");
			this.B = Path.Combine(Path.GetDirectoryName(text), Path.GetFileNameWithoutExtension(text) + ".pap-backup");
		}
		public string A()
		{
			return this.A;
		}
		public string a()
		{
			if (File.Exists(this.a))
			{
				File.SetAttributes(this.a, File.GetAttributes(this.a) & ~FileAttributes.ReadOnly);
				File.Delete(this.a);
			}
			return this.a;
		}
		public void A(bool flag)
		{
			try
			{
				if (File.Exists(this.A))
				{
					File.Replace(this.a, this.A, this.B);
				}
				else
				{
					File.Move(this.a, this.A);
				}
			}
			finally
			{
				if (!flag)
				{
					File.Delete(this.B);
				}
				if (File.Exists(this.a))
				{
					File.Delete(this.a);
				}
			}
		}
		public void A()
		{
			File.Delete(this.a);
		}
	}
}
