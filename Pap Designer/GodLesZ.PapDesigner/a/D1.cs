using System;
using System.Collections.Generic;
namespace a
{
	public class D1<T_TYPE> : c1<T_TYPE> where T_TYPE : L
	{
		private int A = -1;
		private Dictionary<int, T_TYPE> A = new Dictionary<int, T_TYPE>();
		public Dictionary<int, T_TYPE>.ValueCollection C()
		{
			return this.A.Values;
		}
		public int A(T_TYPE t_TYPE)
		{
			if (t_TYPE.A() >= 0)
			{
				try
				{
					return this.C(t_TYPE, t_TYPE.A());
				}
				catch
				{
					string message = "attempt to register already registered id";
					throw new ArgumentException(message);
				}
			}
			int num = this.A;
			do
			{
				if (num == 2147483647)
				{
					num = -1;
				}
				num++;
			}
			while (this.A.ContainsKey(num));
			return this.C(t_TYPE, num);
		}
		public bool a(int key, out T_TYPE value)
		{
			return this.A.TryGetValue(key, out value);
		}
		public L B(int key)
		{
			return this.A[key];
		}
		public void b(T_TYPE t_TYPE)
		{
			this.A.Remove(t_TYPE.A());
		}
		private int C(T_TYPE value, int num)
		{
			this.A.Add(num, value);
			this.A = Math.Max(this.A, num);
			if (value.A() != num)
			{
				value.a(num);
			}
			return num;
		}
	}
	public abstract class d1
	{
		public enum A
		{
			Initial,
			NoChanges,
			MayUndo,
			MayRedo
		}
		private h2 A;
		private string A;
		private d1.A A;
		public d1(h2 a, string text)
		{
			this.A = a;
			this.A = text.TrimEnd(new char[]
			{
				'.'
			});
		}
		public h2 d()
		{
			return this.A;
		}
		public string d()
		{
			return this.A;
		}
		public d1.A d()
		{
			return this.A;
		}
		public virtual bool A()
		{
			if (this.A != d1.A.Initial)
			{
				throw new l1();
			}
			if (this.D())
			{
				this.A = d1.A.MayUndo;
				return true;
			}
			this.A = d1.A.NoChanges;
			return false;
		}
		public virtual void a()
		{
			if (this.A != d1.A.Initial)
			{
				throw new l1();
			}
			this.C();
		}
		public virtual void B()
		{
			if (this.A != d1.A.MayUndo)
			{
				throw new l1();
			}
			this.C();
			this.A = d1.A.MayRedo;
		}
		public virtual void b()
		{
			if (this.A != d1.A.MayRedo)
			{
				throw new l1();
			}
			this.c();
			this.A = d1.A.MayUndo;
		}
		protected abstract void C();
		protected abstract void c();
		protected abstract bool D();
	}
}
