using D;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
namespace a
{
	public class M : IEnumerable
	{
		private List<D.A> A;
		public M(List<D.A> list, List<D.A> list2)
		{
			if (list != null)
			{
				if (list2 != null)
				{
					this.A = new List<D.A>();
					this.A.AddRange(list);
					this.A.AddRange(list2);
					return;
				}
				this.A = list;
				return;
			}
			else
			{
				if (list2 != null)
				{
					this.A = list2;
					return;
				}
				throw new l1();
			}
		}
		public D.A A()
		{
			return this.A[0];
		}
		public D.A[] A()
		{
			return this.A.ToArray();
		}
		public IEnumerator GetEnumerator()
		{
			return this.A.GetEnumerator();
		}
	}
	public class m
	{
		private static m A;
		private Type A;
		private string A;
		private string a;
		private byte[] A;
		private m()
		{
			this.A();
		}
		public static m A()
		{
			if (m.A == null)
			{
				m.A = new m();
			}
			return m.A;
		}
		public Type A()
		{
			return this.A;
		}
		public string A()
		{
			return this.A;
		}
		public string a()
		{
			return this.a;
		}
		public byte[] A()
		{
			return this.A;
		}
		public void A(Type type, string text, string text2, byte[] array)
		{
			this.A();
			try
			{
				using (MemoryStream memoryStream = new MemoryStream())
				{
					Encoding uTF = Encoding.UTF8;
					this.A(memoryStream, uTF, type.FullName);
					this.A(memoryStream, uTF, text);
					this.A(memoryStream, uTF, text2);
					this.A(memoryStream, uTF, "" + array.Length);
					memoryStream.Write(array, 0, array.Length);
					byte[] data = memoryStream.ToArray();
					Clipboard.Clear();
					Clipboard.SetData(this.A(type), data);
				}
			}
			catch (Exception)
			{
			}
		}
		public bool A(Type type)
		{
			try
			{
				if (Clipboard.ContainsData(this.A(type)))
				{
					this.A = type;
					return true;
				}
			}
			catch (Exception)
			{
			}
			return false;
		}
		public bool a(Type type)
		{
			this.A();
			if (!this.A(type))
			{
				return false;
			}
			try
			{
				byte[] buffer = (byte[])Clipboard.GetData(this.A(type));
				using (MemoryStream memoryStream = new MemoryStream(buffer))
				{
					Encoding uTF = Encoding.UTF8;
					Type type2 = Type.GetType(this.A(memoryStream, uTF));
					string text = this.A(memoryStream, uTF);
					string text2 = this.A(memoryStream, uTF);
					int num = int.Parse(this.A(memoryStream, uTF));
					byte[] buffer2 = new byte[num];
					memoryStream.Read(buffer2, 0, num);
					this.A = type2;
					this.A = text;
					this.a = text2;
					this.A = buffer2;
					return true;
				}
			}
			catch (Exception)
			{
			}
			return false;
		}
		public void A()
		{
			this.A = null;
			this.A = null;
			this.a = null;
			this.A = null;
		}
		private string A(Type type)
		{
			return j1.A() + "|" + type.FullName;
		}
		private void A(Stream stream, Encoding encoding, string text)
		{
			text = "" + text;
			byte[] bytes = encoding.GetBytes(text);
			if (bytes.Length > 255)
			{
				throw new l1();
			}
			stream.WriteByte((byte)(bytes.Length & 255));
			stream.Write(bytes, 0, bytes.Length);
		}
		private string A(Stream stream, Encoding encoding)
		{
			int num = stream.ReadByte();
			byte[] array = new byte[num];
			stream.Read(array, 0, num);
			return encoding.GetString(array);
		}
	}
}
