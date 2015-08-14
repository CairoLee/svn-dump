using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
namespace a
{
	public class H
	{
		public static void A(ToolTip toolTip)
		{
			K1.UserSettings userSettings = K1.A().A();
			toolTip.AutoPopDelay = userSettings.ToolTipAutoPopDelay;
			toolTip.InitialDelay = userSettings.ToolTipInitialDelay;
			toolTip.ReshowDelay = userSettings.ToolTipReshowDelay;
		}
		public static void A(ToolTip toolTip, Control control, Control control2)
		{
			toolTip.SetToolTip(control2, toolTip.GetToolTip(control));
		}
	}
	public class h<T> : ICollection<T>, ICollection, IEnumerable<T>, IEnumerable
	{
		private Dictionary<T, T> A = new Dictionary<T, T>();
		private bool A;
		public h()
		{
		}
		public h(ICollection<T> collection, bool a)
		{
			foreach (T current in collection)
			{
				this.Add(current);
			}
			this.A = a;
		}
		public int get_Count()
		{
			return this.A.Count;
		}
		public bool get_IsReadOnly()
		{
			return this.A;
		}
		public void Add(T t)
		{
			if (this.A)
			{
				throw new InvalidOperationException();
			}
			this.A.Add(t, t);
		}
		public void Clear()
		{
			if (this.A)
			{
				throw new InvalidOperationException();
			}
			this.A.Clear();
		}
		public bool Contains(T key)
		{
			return this.A.ContainsKey(key);
		}
		public bool a(T key, out T value)
		{
			return this.A.TryGetValue(key, out value);
		}
		public void CopyTo(T[] array, int index)
		{
			this.A.Keys.CopyTo(array, index);
		}
		public T[] a()
		{
			T[] array = new T[this.get_Count()];
			this.CopyTo(array, 0);
			return array;
		}
		public bool Remove(T key)
		{
			if (this.A)
			{
				throw new InvalidOperationException();
			}
			return this.A.Remove(key);
		}
		public bool get_IsSynchronized()
		{
			throw new NotImplementedException();
		}
		public object get_SyncRoot()
		{
			throw new NotImplementedException();
		}
		public void CopyTo(Array array, int num)
		{
			throw new NotImplementedException();
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.A.Keys.GetEnumerator();
		}
		IEnumerator<T> IEnumerable<T>.A()
		{
			return this.A.Keys.GetEnumerator();
		}
	}
}
