using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
namespace a
{
	public class D : Form
	{
		private IContainer A;
		public D()
		{
			this.A();
			this.Font = d2.a().Font;
		}
		private void A(object obj, KeyEventArgs keyEventArgs)
		{
			if (keyEventArgs.KeyCode == Keys.Escape)
			{
				base.Close();
			}
		}
		private void A(object obj, EventArgs eventArgs)
		{
			base.Activate();
		}
		protected override void Dispose(bool flag)
		{
			if (flag && this.A != null)
			{
				this.A.Dispose();
			}
			base.Dispose(flag);
		}
		private void A()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(D));
			base.SuspendLayout();
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackgroundImage = (Image)componentResourceManager.GetObject("$this.BackgroundImage");
			this.BackgroundImageLayout = ImageLayout.Center;
			base.ClientSize = new Size(494, 544);
			base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "HelpUsageInfoDialog";
			base.ShowInTaskbar = false;
			this.Text = " Hilfe zur Eingabe";
			base.TopMost = true;
			base.MouseEnter += new EventHandler(this.A);
			base.KeyDown += new KeyEventHandler(this.A);
			base.ResumeLayout(false);
		}
	}
	[DefaultMember("Item")]
	public class d : IDisposable
	{
		public const int A = 14;
		public const string A = "Arial";
		public const string a = "Arial Narrow";
		private string B;
		private float A = 1f;
		private Font[] A;
		public d(bool flag)
		{
			this.A = 1f;
			this.A(flag);
			Font font = this.A(14);
			float height = font.GetHeight(96f);
			float height2 = font.GetHeight();
			this.A = height / height2;
			this.A(flag);
		}
		private void A(bool flag)
		{
			this.B = (flag ? "Arial Narrow" : "Arial");
			this.A = new Font[50];
		}
		public void Dispose()
		{
			if (this.A != null)
			{
				Font[] array = this.A;
				for (int i = 0; i < array.Length; i++)
				{
					Font font = array[i];
					if (font != null)
					{
						font.Dispose();
					}
				}
				this.A = null;
			}
		}
		~d()
		{
			this.Dispose();
		}
		public bool A()
		{
			return this.B == "Arial Narrow";
		}
		public void a(bool flag)
		{
			if (this.A() != flag)
			{
				this.A(flag);
			}
		}
		public Font A(int num)
		{
			Font font = this.A[num];
			if (font == null)
			{
				font = (this.A[num] = new Font(this.B, (float)num * this.A));
			}
			return font;
		}
		public static void A(Control control)
		{
			control.Font = new Font(control.Font.Name, (control.Font.Size + SystemFonts.MenuFont.Size) / 2f);
		}
	}
}
