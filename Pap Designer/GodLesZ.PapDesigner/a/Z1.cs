using PapDesigner.Resources;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace a
{
	public class Z1 : IComparable, e<Z1>
	{
		private int[] A;
		private string A;
		public Z1(string text)
		{
			try
			{
				int num = 4;
				string[] array = text.Split(new char[]
				{
					'.'
				});
				if (array.Length != num)
				{
					throw new Exception();
				}
				int num2 = 0;
				this.A = new int[array.Length];
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					string s = array2[i];
					this.A[num2++] = int.Parse(s);
				}
				this.A = text;
			}
			catch (Exception)
			{
				throw new M1();
			}
		}
		public bool A(Z1 z)
		{
			return z != null && this.CompareTo(z) == 0;
		}
		public override bool Equals(object obj)
		{
			return obj is Z1 && Z1.a(this, (Z1)obj);
		}
		public static bool a(Z1 z, Z1 z2)
		{
			if (z != null)
			{
				return z.A(z2);
			}
			return z2 == null || z2.A(z);
		}
		public static bool B(Z1 z, Z1 z2)
		{
			return !Z1.a(z, z2);
		}
		public static bool b(Z1 z, Z1 z2)
		{
			return z.CompareTo(z2) > 0;
		}
		public static bool C(Z1 z, Z1 z2)
		{
			return z.CompareTo(z2) < 0;
		}
		public static bool c(Z1 z, Z1 z2)
		{
			return z.CompareTo(z2) >= 0;
		}
		public static bool D(Z1 z, Z1 z2)
		{
			return z.CompareTo(z2) <= 0;
		}
		public int CompareTo(object obj)
		{
			return this.a(obj, 2147483647);
		}
		public int a(object obj, int val)
		{
			if (!(obj is Z1))
			{
				throw new ArgumentException();
			}
			Z1 z = (Z1)obj;
			for (int i = 0; i < Math.Min(val, this.A.Length); i++)
			{
				if (this.A[i] < z.A[i])
				{
					return -1;
				}
				if (this.A[i] > z.A[i])
				{
					return 1;
				}
			}
			return 0;
		}
		public override string ToString()
		{
			return this.A;
		}
		public override int GetHashCode()
		{
			return this.A.GetHashCode();
		}
	}
	public class z1 : Form
	{
		private static z1 A;
		private h2 A;
		private T1 A;
		private Control A;
		private Form A;
		private Button A;
		private Form a;
		private c A = new c();
		private IContainer A;
		private z1(Form form, h2 h, T1 t)
		{
			if (form == null)
			{
				throw new ArgumentException();
			}
			if (t == null)
			{
				throw new ArgumentException();
			}
			if (t.b() != form)
			{
				throw new ArgumentException();
			}
			this.a();
			base.FormBorderStyle = FormBorderStyle.None;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.WindowState = FormWindowState.Normal;
			this.A = h;
			this.A = t;
			this.a = form;
			base.Show(form);
			t.k();
		}
		public static void A(h2 h, T1 t)
		{
			if (!z1.A())
			{
				z1.A = new z1(t.b(), h, t);
			}
		}
		public static bool A()
		{
			return z1.A != null;
		}
		public static void A()
		{
			if (z1.A())
			{
				z1.A.Close();
			}
		}
		protected override bool ProcessCmdKey(ref Message ptr, Keys keys)
		{
			if (this.A.A(keys))
			{
				return true;
			}
			S.A().A(this.A, (e2)this.A, false);
			bool flag = S.A().e(keys);
			if (!flag)
			{
				d2.a(keys);
			}
			return flag;
		}
		private void A(object obj, EventArgs eventArgs)
		{
			Screen screen = Screen.FromControl(this.a);
			Rectangle workingArea = screen.WorkingArea;
			base.Location = workingArea.Location;
			base.Size = workingArea.Size;
			Control control = this.A.B();
			if (control == null)
			{
				throw new l1();
			}
			this.Text = this.a.Text;
			base.Controls.Add((Control)this.A);
			this.A = control;
			this.A = new Button();
			this.A.Text = null;
			this.A.BackgroundImage = (Image)Icons.A().Clone();
			this.A.BackgroundImageLayout = ImageLayout.Center;
			this.A.Width = this.A.Height;
			this.A.Click += new EventHandler(this.B);
			Form form = new Form();
			form.FormBorderStyle = FormBorderStyle.None;
			form.WindowState = FormWindowState.Normal;
			form.StartPosition = FormStartPosition.Manual;
			form.Location = new Point(base.Location.X + 5, base.Location.Y + 5);
			form.MinimumSize = new Size(this.A.Height, this.A.Height);
			form.Size = form.MinimumSize;
			form.ShowIcon = false;
			form.ShowInTaskbar = false;
			form.Controls.Add(this.A);
			form.Show(this);
			this.A = form;
			this.a.Activated += new EventHandler(this.a);
		}
		private void a(object obj, EventArgs eventArgs)
		{
			z1.A();
		}
		private void B(object obj, EventArgs eventArgs)
		{
			z1.A();
		}
		private void A(object obj, FormClosingEventArgs formClosingEventArgs)
		{
			this.a.Activated -= new EventHandler(this.a);
			this.A.Click -= new EventHandler(this.B);
			if (this.A != null)
			{
				this.A.Controls.Add((Control)this.A);
				this.A.k();
				this.A = null;
			}
			if (this.A != null)
			{
				this.A.Dispose();
				this.A = null;
			}
			base.Dispose();
			z1.A = null;
		}
		protected override void Dispose(bool flag)
		{
			if (flag && this.A != null)
			{
				this.A.Dispose();
			}
			base.Dispose(flag);
		}
		private void a()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(z1));
			base.SuspendLayout();
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(292, 266);
			base.FormBorderStyle = FormBorderStyle.None;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "FullScreenView";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			this.Text = "FullScreenView";
			base.WindowState = FormWindowState.Maximized;
			base.FormClosing += new FormClosingEventHandler(this.A);
			base.Load += new EventHandler(this.A);
			base.ResumeLayout(false);
		}
	}
}
