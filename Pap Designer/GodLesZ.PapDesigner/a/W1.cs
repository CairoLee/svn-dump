using c;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
namespace a
{
	[DefaultMember("Item")]
	public class W1<T_ITEM> : IEnumerable<T_ITEM>, IEnumerable, v1 where T_ITEM : P1<T_ITEM>
	{
		public delegate bool A(T_ITEM);
		public delegate void a(T_ITEM);
		public delegate void B(T_ITEM, int);
		private List<T_ITEM> A = new List<T_ITEM>();
		private Dictionary<string, T_ITEM> A = new Dictionary<string, T_ITEM>();
		private Dictionary<T_ITEM, string> A = new Dictionary<T_ITEM, string>();
		private W1<T_ITEM>.A A;
		private W1<T_ITEM>.a A;
		private W1<T_ITEM>.B A;
		private W1<T_ITEM>.a a;
		private W1<T_ITEM>.A a;
		private W1<T_ITEM>.a B;
		private W1<T_ITEM>.a b;
		private W1<T_ITEM>.a C;
		public int B()
		{
			return this.A.Count;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void B(W1<T_ITEM>.A a)
		{
			this.A = (W1<T_ITEM>.A)Delegate.Combine(this.A, a);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void b(W1<T_ITEM>.A value)
		{
			this.A = (W1<T_ITEM>.A)Delegate.Remove(this.A, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void B(W1<T_ITEM>.a a)
		{
			this.A = (W1<T_ITEM>.a)Delegate.Combine(this.A, a);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void b(W1<T_ITEM>.a value)
		{
			this.A = (W1<T_ITEM>.a)Delegate.Remove(this.A, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void B(W1<T_ITEM>.B b)
		{
			this.A = (W1<T_ITEM>.B)Delegate.Combine(this.A, b);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void b(W1<T_ITEM>.B value)
		{
			this.A = (W1<T_ITEM>.B)Delegate.Remove(this.A, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void C(W1<T_ITEM>.a a)
		{
			this.a = (W1<T_ITEM>.a)Delegate.Combine(this.a, a);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void c(W1<T_ITEM>.a value)
		{
			this.a = (W1<T_ITEM>.a)Delegate.Remove(this.a, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void C(W1<T_ITEM>.A a)
		{
			this.a = (W1<T_ITEM>.A)Delegate.Combine(this.a, a);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void c(W1<T_ITEM>.A value)
		{
			this.a = (W1<T_ITEM>.A)Delegate.Remove(this.a, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void D(W1<T_ITEM>.a a)
		{
			this.B = (W1<T_ITEM>.a)Delegate.Combine(this.B, a);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void d(W1<T_ITEM>.a value)
		{
			this.B = (W1<T_ITEM>.a)Delegate.Remove(this.B, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void E(W1<T_ITEM>.a a)
		{
			this.b = (W1<T_ITEM>.a)Delegate.Combine(this.b, a);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void e(W1<T_ITEM>.a value)
		{
			this.b = (W1<T_ITEM>.a)Delegate.Remove(this.b, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void F(W1<T_ITEM>.a a)
		{
			this.C = (W1<T_ITEM>.a)Delegate.Combine(this.C, a);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void f(W1<T_ITEM>.a value)
		{
			this.C = (W1<T_ITEM>.a)Delegate.Remove(this.C, value);
		}
		public T_ITEM B(int index)
		{
			return this.A[index];
		}
		public T_ITEM B(string text)
		{
			return this.b(text);
		}
		public T_ITEM b(int index)
		{
			return this.A[index];
		}
		public T_ITEM b(string key)
		{
			T_ITEM result = default(T_ITEM);
			if (this.A.TryGetValue(key, out result))
			{
				return result;
			}
			return default(T_ITEM);
		}
		public int B(T_ITEM item)
		{
			return this.A.IndexOf(item);
		}
		public int B(string text)
		{
			T_ITEM t_ITEM = this.b(text);
			if (t_ITEM != null)
			{
				return this.B(t_ITEM);
			}
			return -1;
		}
		public bool B(string key)
		{
			return this.A.ContainsKey(key);
		}
		public bool B(T_ITEM key)
		{
			return this.A.ContainsKey(key);
		}
		public bool b(T_ITEM t_ITEM)
		{
			bool result;
			try
			{
				this.B(t_ITEM);
				result = true;
			}
			catch (ArgumentException)
			{
				result = false;
			}
			return result;
		}
		public void B(T_ITEM t_ITEM)
		{
			if (this.B(t_ITEM))
			{
				throw new ArgumentException("Item already exist in the pool");
			}
			if (this.B(t_ITEM.b()))
			{
				throw new ArgumentException("Name '" + t_ITEM.b() + "' already exist in the pool");
			}
			if (this.A != null)
			{
				Delegate[] invocationList = this.A.GetInvocationList();
				Delegate[] array = invocationList;
				for (int i = 0; i < array.Length; i++)
				{
					W1<T_ITEM>.A a = (W1<T_ITEM>.A)array[i];
					if (!a(t_ITEM))
					{
						throw new InvalidOperationException("Item '" + t_ITEM.b() + "' was not accepted");
					}
				}
			}
		}
		public void b(T_ITEM t_ITEM)
		{
			this.B(t_ITEM, this.B());
		}
		public void B(T_ITEM t_ITEM, int num)
		{
			this.B(t_ITEM);
			if (this.A != null)
			{
				this.A(t_ITEM);
			}
			this.A.Insert(num, t_ITEM);
			this.A.Add(t_ITEM.b(), t_ITEM);
			this.A.Add(t_ITEM, t_ITEM.b());
			t_ITEM.B(new P1<T_ITEM>.A(this.B));
			t_ITEM.B(new P1<T_ITEM>.a(this.B));
			if (this.A != null)
			{
				this.A(t_ITEM, num);
			}
			if (this.a != null)
			{
				this.a(t_ITEM);
			}
		}
		public bool C(T_ITEM t_ITEM)
		{
			bool result;
			try
			{
				this.C(t_ITEM);
				result = true;
			}
			catch (ArgumentException)
			{
				result = false;
			}
			return result;
		}
		public void C(T_ITEM t_ITEM)
		{
			if (!this.B(t_ITEM))
			{
				throw new ArgumentException("Item '" + t_ITEM.b() + "' not contained in the pool");
			}
			if (!object.ReferenceEquals(this.A[t_ITEM], t_ITEM.b()))
			{
				throw new l1();
			}
			if (!object.ReferenceEquals(this.A[t_ITEM.b()], t_ITEM))
			{
				throw new l1();
			}
			if (this.a != null && this.A != null)
			{
				Delegate[] invocationList = this.a.GetInvocationList();
				Delegate[] array = invocationList;
				for (int i = 0; i < array.Length; i++)
				{
					W1<T_ITEM>.A a = (W1<T_ITEM>.A)array[i];
					if (!a(t_ITEM))
					{
						throw new InvalidOperationException("Removal if item '" + t_ITEM.b() + "' was not accepted");
					}
				}
			}
		}
		public void c(T_ITEM t_ITEM)
		{
			this.C(t_ITEM);
			if (this.B != null)
			{
				this.B(t_ITEM);
			}
			t_ITEM.b(new P1<T_ITEM>.a(this.B));
			t_ITEM.b(new P1<T_ITEM>.A(this.B));
			if (!this.A.Remove(t_ITEM))
			{
				throw new l1();
			}
			if (!this.A.Remove(t_ITEM.b()))
			{
				throw new l1();
			}
			this.A.Remove(t_ITEM);
			if (this.b != null)
			{
				this.b(t_ITEM);
			}
			if (this.C != null)
			{
				this.C(t_ITEM);
			}
		}
		public virtual bool a(string text)
		{
			return o1.b(text);
		}
		public virtual bool A(string text)
		{
			return this.a(text) && !this.B(text);
		}
		public T_ITEM[] B()
		{
			return this.A.ToArray();
		}
		public void B()
		{
			T_ITEM[] array = this.B();
			T_ITEM[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				T_ITEM t_ITEM = array2[i];
				this.C(t_ITEM);
			}
			T_ITEM[] array3 = array;
			for (int j = 0; j < array3.Length; j++)
			{
				T_ITEM t_ITEM2 = array3[j];
				this.c(t_ITEM2);
			}
			this.A.Clear();
			this.A.Clear();
			this.A.Clear();
		}
		public string B(string arg)
		{
			int num = 0;
			foreach (string current in this.A.Keys)
			{
				h2 h = this.A[current] as h2;
				if (h == null || !h.e())
				{
					string[] array = current.Split(new char[]
					{
						" "[0]
					});
					if (array.Length != 2 || array[0] != arg)
					{
						break;
					}
					try
					{
						num = Math.Max(num, int.Parse(array[1]));
					}
					catch
					{
					}
				}
			}
			string text;
			do
			{
				num++;
				text = arg + " " + num;
			}
			while (this.A.ContainsKey(text));
			return text;
		}
		public string b(string text)
		{
			if (!this.B(text))
			{
				return text;
			}
			string text2 = text;
			int num = 2;
			if (text2.Trim().EndsWith("]"))
			{
				int num2 = text2.LastIndexOf("[");
				int num3 = text2.LastIndexOf("]");
				string s = text2.Substring(num2 + 1, num3 - num2 - 1);
				try
				{
					int num4 = int.Parse(s);
					if (num4 < 2147483647 && num4 >= 0)
					{
						num = int.Parse(s) + 1;
						text2 = text2.Substring(0, num2).TrimEnd(new char[0]);
					}
				}
				catch (Exception)
				{
				}
			}
			do
			{
				text = string.Format("{0} [{1}]", text2, num++);
			}
			while (this.B(text));
			return text;
		}
		public IEnumerator<T_ITEM> GetEnumerator()
		{
			W1<T_ITEM>.b b = new W1<T_ITEM>.b(0);
			b.A = this;
			return b;
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
		private bool B(T_ITEM t_ITEM, string text)
		{
			return this.A(text);
		}
		private void B(T_ITEM t_ITEM, string text)
		{
			this.A.Remove(this.A[t_ITEM]);
			this.A.Remove(t_ITEM);
			this.A.Add(t_ITEM, t_ITEM.b());
			this.A.Add(t_ITEM.b(), t_ITEM);
		}
	}
	public class w1
	{
		public Z1 A = j1.A();
		public FileInfo A;
		public c1<p1> A;
		public c1<global::c.a> A;
		public static string A(string text)
		{
			text = text.Replace("\n", "\r\n");
			return text.Replace("\r\r\n", "\r\n");
		}
	}
}
