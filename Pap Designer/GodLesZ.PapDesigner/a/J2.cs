using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
namespace a
{
	public class J2<T_ITEM> : TreeNode where T_ITEM : P1<T_ITEM>
	{
		private T_ITEM A = default(T_ITEM);
		public J2(T_ITEM t_ITEM) : base(t_ITEM.b())
		{
			this.A = t_ITEM;
			base.Text = t_ITEM.b();
			base.Tag = t_ITEM;
			t_ITEM.B(new P1<T_ITEM>.a(this.A));
		}
		~J2()
		{
			this.A.b(new P1<T_ITEM>.a(this.A));
		}
		public T_ITEM A()
		{
			return this.A;
		}
		public void A(T_ITEM t_ITEM, string text)
		{
			if (!object.ReferenceEquals(this.A, t_ITEM))
			{
				throw new l1();
			}
			base.Name = t_ITEM.b();
			base.Text = t_ITEM.b();
		}
	}
	public class j2
	{
		public static void A(l l, string text)
		{
			FileInfo fileInfo = new FileInfo(text);
			if (!fileInfo.Exists)
			{
				throw new l1();
			}
			w1 w = new w1();
			w.A = fileInfo;
			using (Stream stream = File.OpenRead(text))
			{
				j2.A(l, stream, w);
			}
		}
		public static void A(l l, byte[] buffer)
		{
			w1 w = new w1();
			using (MemoryStream memoryStream = new MemoryStream(buffer))
			{
				j2.A(l, memoryStream, w);
			}
		}
		public static void A(l l, Stream input, w1 w)
		{
			XmlReaderSettings settings = j2.A();
			using (XmlReader xmlReader = XmlReader.Create(input, settings))
			{
				xmlReader.MoveToContent();
				l.b(xmlReader, w);
				l.C(w);
			}
		}
		public static void a(l l, string text)
		{
			x1 x = new x1(text);
			string outputFileName = x.a();
			XmlWriterSettings settings = j2.A(true);
			using (XmlWriter xmlWriter = XmlWriter.Create(outputFileName, settings))
			{
				l.B(xmlWriter, new X1());
			}
			x.A(K1.A().A().KeepBackupFiles);
		}
		public static byte[] A(l l)
		{
			return j2.A(l, new X1());
		}
		public static byte[] A(l l, X1 x)
		{
			byte[] result = null;
			XmlWriterSettings settings = j2.A(false);
			using (MemoryStream memoryStream = new MemoryStream(1024))
			{
				using (XmlWriter xmlWriter = XmlWriter.Create(memoryStream, settings))
				{
					l.B(xmlWriter, x);
				}
				result = memoryStream.ToArray();
			}
			return result;
		}
		public static bool A(byte[] array, byte[] array2)
		{
			if (array == null)
			{
				if (array2 == null)
				{
					throw new l1();
				}
				return true;
			}
			else
			{
				if (array2 == null)
				{
					return true;
				}
				if (array.Length != array2.Length)
				{
					return true;
				}
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] != array2[i])
					{
						return true;
					}
				}
				return false;
			}
		}
		private static XmlWriterSettings A(bool flag)
		{
			return new XmlWriterSettings
			{
				ConformanceLevel = ConformanceLevel.Document,
				OmitXmlDeclaration = !flag,
				Indent = flag,
				NewLineOnAttributes = false,
				CloseOutput = true,
				Encoding = Encoding.UTF8
			};
		}
		private static XmlReaderSettings A()
		{
			return new XmlReaderSettings
			{
				ConformanceLevel = ConformanceLevel.Document,
				IgnoreWhitespace = true
			};
		}
	}
}
