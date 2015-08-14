using System;
using System.Collections.Generic;
using System.Xml;
namespace a
{
	public class C1 : l
	{
		public const string A = "2FB25471-B62C-4EE6-BD43-F819C095ACF8";
		public const string a = "0000";
		private h2 A;
		private Z1 A = j1.A();
		private string B;
		private string b;
		private bool A = true;
		public C1()
		{
			this.A = null;
		}
		public C1(h2 h)
		{
			this.A = h;
		}
		public C1(byte[] array)
		{
			j2.A(this, array);
		}
		public h2 A()
		{
			return this.A;
		}
		public Z1 A()
		{
			return this.A;
		}
		public virtual void B(XmlWriter xmlWriter, X1 x)
		{
			if (x == null)
			{
				throw new l1();
			}
			xmlWriter.WriteStartElement("FRAME");
			xmlWriter.WriteAttributeString("GUID", "2FB25471-B62C-4EE6-BD43-F819C095ACF8");
			xmlWriter.WriteAttributeString("FORMAT", "0000");
			xmlWriter.WriteAttributeString("APP_VERSION", j1.A().ToString());
			byte[] array = j2.A(this.A());
			xmlWriter.WriteAttributeString("CHECKSUM", new o(array).ToString());
			this.A().B(xmlWriter, x);
			xmlWriter.WriteEndElement();
		}
		public virtual void b(XmlReader xmlReader, w1 w)
		{
			if (w == null)
			{
				throw new l1();
			}
			this.A = new Z1("0.0.0.0");
			this.B = null;
			this.b = null;
			this.A = false;
			if (xmlReader["GUID"] != "2FB25471-B62C-4EE6-BD43-F819C095ACF8")
			{
				throw new M1();
			}
			if (xmlReader["FORMAT"] != "0000")
			{
				throw new M1();
			}
			if (xmlReader["APP_VERSION"] != null)
			{
				this.A = new Z1(xmlReader["APP_VERSION"]);
			}
			w.A = this.A;
			if (Z1.c(this.A(), new Z1("2.1.0.2")))
			{
				this.A = true;
				this.B = xmlReader["CHECKSUM"];
				if (Z1.a(this.A(), new Z1("2.1.0.2")))
				{
					this.B = o.A(ulong.Parse(this.B));
				}
			}
			xmlReader.ReadStartElement("FRAME");
			this.A = new h2(xmlReader, w);
			if (this.A)
			{
				X1 x = new X1();
				byte[] array = j2.A(this.A, x);
				this.b = new o(array).ToString();
				if (this.b != this.B)
				{
					if (Z1.b(this.A, j1.A()))
					{
						throw new N1(this.A, j1.A());
					}
					if (K1.A().A().DefaultAuthorName != "PAPREPAIR")
					{
						throw new m1();
					}
				}
			}
			using (IEnumerator<p1> enumerator = this.A().E().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					Q1 q = (Q1)enumerator.Current;
					q.A(this.A);
				}
			}
			xmlReader.ReadEndElement();
			if (!xmlReader.EOF)
			{
				throw new M1();
			}
		}
		public virtual void C(w1 w)
		{
			this.A().C(w);
		}
	}
	public interface c1<T_TYPE> where T_TYPE : L
	{
		int A(T_TYPE);
		bool a(int, out T_TYPE);
		L B(int);
		void b(T_TYPE);
	}
}
