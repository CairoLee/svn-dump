using System;
using System.Windows.Forms;
namespace a
{
	public class C : IDisposable
	{
		private const int A = 300;
		private static int a = 0;
		private static DateTime A = DateTime.Now;
		public C()
		{
			if (C.a++ == 0)
			{
				C.A = DateTime.Now;
				C.A(true);
			}
		}
		public void Dispose()
		{
			if (C.a > 0 && --C.a == 0)
			{
				int num = Math.Max(0, 300 - (int)DateTime.Now.Subtract(C.A).TotalMilliseconds);
				if (num > 30)
				{
					Timer timer = new Timer();
					timer.Tick += new EventHandler(C.A);
					timer.Interval = num;
					timer.Start();
					return;
				}
				C.A();
			}
		}
		private static void A(bool flag)
		{
			Application.UseWaitCursor = flag;
			Cursor cursor = flag ? Cursors.WaitCursor : Cursors.Default;
			foreach (Form form in Application.OpenForms)
			{
				if (form is d2)
				{
					g.A(form, cursor);
				}
			}
		}
		private static void A(object obj, EventArgs eventArgs)
		{
			Timer timer = (Timer)obj;
			timer.Stop();
			timer.Dispose();
			C.A();
		}
		private static void A()
		{
			if (C.a <= 0)
			{
				C.A(false);
			}
		}
	}
	public class c
	{
		private string A;
		private DateTime A = DateTime.MinValue;
		public bool A(Keys keys)
		{
			TimeSpan timeSpan = DateTime.Now.Subtract(this.A);
			this.A = DateTime.Now;
			if (this.A == keys.ToString() && timeSpan.TotalMilliseconds < 100.0)
			{
				return true;
			}
			this.A = keys.ToString();
			return false;
		}
	}
}
