using System;
using System.Collections;
using System.Windows.Forms;
namespace a
{
	public class G<T> : IEnumerator
	{
		private ICollection[] A;
		private IEnumerator[] A;
		private int A;
		private int a;
		public G(params ICollection[] array)
		{
			this.A = array.Length;
			this.A = new ICollection[this.A];
			Array.Copy(array, this.A, this.A);
		}
		public bool MoveNext()
		{
			while (this.a < this.A)
			{
				if (this.A == null)
				{
					this.A = new IEnumerator[this.A];
				}
				IEnumerator enumerator = this.A[this.a];
				if (enumerator == null)
				{
					enumerator = this.A[this.a].GetEnumerator();
					this.A[this.a] = enumerator;
				}
				if (enumerator.MoveNext())
				{
					return true;
				}
				enumerator.Reset();
				if (enumerator is IDisposable)
				{
					((IDisposable)enumerator).Dispose();
				}
				this.A[this.a] = null;
				this.a++;
			}
			return false;
		}
		public void Reset()
		{
			while (this.a < this.A && this.A != null)
			{
				IEnumerator enumerator = this.A[this.a];
				if (enumerator == null)
				{
					break;
				}
				enumerator.Reset();
				if (enumerator is IDisposable)
				{
					((IDisposable)enumerator).Dispose();
				}
				this.A[this.a] = null;
				this.a++;
			}
			this.a = 0;
		}
		public void A()
		{
			this.Reset();
			this.A = null;
			this.A = null;
		}
		object IEnumerator.get_Current()
		{
			return this.A[this.a].Current;
		}
	}
	internal class g
	{
		public static void A(Control control, Cursor cursor)
		{
			control.Cursor = cursor;
			foreach (Control control2 in control.Controls)
			{
				g.A(control2, cursor);
			}
		}
	}
}
