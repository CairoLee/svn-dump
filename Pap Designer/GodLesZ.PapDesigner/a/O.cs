using System;
using System.ComponentModel;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
namespace a
{
	public class O : UserControl
	{
		private IContainer A;
		public TrackBar A;
		public O()
		{
			this.A();
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
			this.A = new TrackBar();
			((ISupportInitialize)this.A).BeginInit();
			base.SuspendLayout();
			this.A.Dock = DockStyle.Left;
			this.A.Location = new Point(0, 0);
			this.A.Name = "trackBar";
			this.A.Orientation = Orientation.Vertical;
			this.A.Size = new Size(45, 211);
			this.A.TabIndex = 0;
			this.A.TickStyle = TickStyle.None;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.A);
			base.Name = "SmallTrackbar";
			base.Size = new Size(26, 211);
			((ISupportInitialize)this.A).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
	public class o
	{
		private string A;
		public o(byte[] array)
		{
			this.A = o.A(o.A(array));
		}
		public o(string text)
		{
			this.A = o.A(o.A(text));
		}
		public static string A(ulong num)
		{
			int num2 = 16;
			string text = string.Format("{0:X}", num);
			while (text.Length < num2)
			{
				text = "0" + text;
			}
			return text;
		}
		public override string ToString()
		{
			return this.A;
		}
		private static ulong A(byte[] buffer)
		{
			MD5 mD = MD5.Create();
			byte[] array = mD.ComputeHash(buffer);
			if (array.Length != 16)
			{
				throw new l1();
			}
			ulong num = 0uL;
			for (int i = 0; i < 8; i++)
			{
				num <<= 8;
				num += (ulong)(array[i] ^ array[i + 8]);
			}
			return num;
		}
		private static ulong A(string s)
		{
			return o.A(Encoding.UTF8.GetBytes(s));
		}
	}
}
