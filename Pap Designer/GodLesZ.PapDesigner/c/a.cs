using a;
using b;
using c;
using d;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
namespace c
{
	public interface a : L, l
	{
		string c();
		void D(string);
		bool d();
		Rectangle E();
		bool e(Point);
		Pen F();
		Brush f();
		Pen G(B1);
		Brush g(B1);
	}
	public class A<T_ITEM> : IEnumerable
	{
		private Dictionary<T_ITEM, object> A = new Dictionary<T_ITEM, object>();
		public A()
		{
		}
		public A(T_ITEM t_ITEM) : this()
		{
			this.A(t_ITEM);
		}
		public A(IEnumerable enumerable) : this()
		{
			this.A(enumerable);
		}
		public void A(T_ITEM t_ITEM)
		{
			if (t_ITEM != null)
			{
				this.A[t_ITEM] = t_ITEM;
			}
		}
		public void A(IEnumerable enumerable)
		{
			IEnumerator enumerator = enumerable.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					T_ITEM t_ITEM = (T_ITEM)((object)enumerator.Current);
					this.A(t_ITEM);
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}
		public bool A(T_ITEM key)
		{
			return this.A.ContainsKey(key);
		}
		public IEnumerator GetEnumerator()
		{
			return this.A.Keys.GetEnumerator();
		}
		public void A(e2 e)
		{
			e.D(this);
		}
	}
}
namespace C
{
	public class a<T_VALUE, T_LANEPTR> : IEnumerable, IEnumerator where T_LANEPTR : global::b.B
	{
		private global::b.C<T_VALUE, T_LANEPTR> A;
		private int A;
		private int a = 2147483647;
		public a(global::b.C<T_VALUE, T_LANEPTR> c)
		{
			this.A = c;
			this.A();
		}
		private void A()
		{
			this.A = this.A.h();
			this.a = 2147483647;
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			this.A();
			return this;
		}
		public T_LANEPTR A()
		{
			return this.A.h(this.a);
		}
		object IEnumerator.get_Current()
		{
			return this.A.h(this.a);
		}
		bool IEnumerator.MoveNext()
		{
			if (this.A != this.A.h())
			{
				throw new InvalidOperationException("collection changed");
			}
			if (this.a == 2147483647)
			{
				this.a = 0;
			}
			else
			{
				this.a++;
			}
			return this.a < this.A.h();
		}
		void IEnumerator.Reset()
		{
			this.A();
		}
	}
	public class A : global::c.A<d.a>
	{
		public A()
		{
		}
		public A(d.a a) : base(a)
		{
		}
		public A(IEnumerable enumerable) : base(enumerable)
		{
		}
	}
}
