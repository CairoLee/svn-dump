using c;
using C;
using d;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace a
{
	public class C2
	{
		private List<s1> A = new List<s1>();
		public p1 A()
		{
			if (this.A.Count == 0)
			{
				return null;
			}
			return this.A[0].A();
		}
		public void A(s1 s)
		{
			if (this.A.Contains(s))
			{
				throw new l1();
			}
			if (this.A() != null && s.A() != this.A())
			{
				throw new l1();
			}
			this.A.Add(s);
		}
		public void a(s1 item)
		{
			if (!this.A.Contains(item))
			{
				throw new l1();
			}
			this.A.Remove(item);
		}
		public void A()
		{
			foreach (s1 current in this.A)
			{
				current.C();
			}
		}
		public void A(Rectangle rectangle)
		{
			foreach (s1 current in this.A)
			{
				current.E(rectangle);
			}
		}
		public void A(global::c.a a)
		{
			foreach (s1 current in this.A)
			{
				current.d(a);
			}
		}
		public void a()
		{
			foreach (s1 current in this.A)
			{
				current.F();
			}
		}
		public s1[] A(p1 p)
		{
			s1[] array = this.A.ToArray();
			s1[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				s1 s = array2[i];
				s.a(null);
			}
			return array;
		}
		public void A(s1[] array, p1 p)
		{
			for (int i = 0; i < array.Length; i++)
			{
				s1 s = array[i];
				s.a(p);
			}
			this.a();
			this.A();
		}
	}
	public class c2 : Form
	{
		private static Size? A = null;
		private string A;
		private bool A;
		private s1 A;
		private Rectangle A = Rectangle.Empty;
		private IContainer A;
		private Button A;
		private Button a;
		protected E A;
		private CheckBox A;
		private ToolTip A;
		private Button B;
		private ImageList A;
		public c2(s1 s, string text, string text2, d.a a) : this(s, a.E())
		{
			this.Text = text;
			this.A = (a is global::C.C);
			this.a(text2);
			if (a is global::c.c)
			{
				this.A.SetToolTip(this.A, "Bedingten Trennstrich mit dem '~' Zeichen eingeben");
			}
			this.d(null, null);
		}
		protected c2()
		{
		}
		private c2(s1 s, Rectangle rectangle) : this()
		{
			this.D();
			this.Font = d2.a().Font;
			H.A(this.A);
			this.A = s;
			this.A = rectangle;
			this.D(K1.A().A().TextEditDialogLineBreakSwitch);
			if (c2.A.HasValue)
			{
				base.Size = c2.A.Value;
			}
		}
		public bool D()
		{
			return this.A.Checked;
		}
		public void D(bool @checked)
		{
			this.A.Checked = @checked;
			this.F(null, null);
		}
		public virtual string A()
		{
			return this.A;
		}
		public virtual void a(string text)
		{
			this.A = ((text == null) ? "" : text);
			this.A.Text = this.A;
			this.B(this.A);
			this.e(null, null);
		}
		public virtual void B(TextBox textBox)
		{
			textBox.SelectionStart = textBox.Text.Length;
			textBox.SelectionLength = 0;
		}
		public virtual bool b(string text)
		{
			if (!this.c(text))
			{
				return false;
			}
			this.a(this.C(text));
			return true;
		}
		public virtual string C(string text)
		{
			return Regex.Replace(text.Trim(), "[ \\t]+", " ");
		}
		public virtual bool c(string text)
		{
			return text.Length <= 1024 && (!string.IsNullOrEmpty(text.Trim()) || this.A);
		}
		private void D(object obj, EventArgs eventArgs)
		{
			e2 e = this.A as e2;
			if (e != null)
			{
				u.A(this, e.RectangleToScreen(e.L(this.A)));
			}
		}
		private void d(object obj, EventArgs eventArgs)
		{
			if (this.B.ImageIndex == 0)
			{
				this.A.Height = this.A.Bottom - this.A.Top;
				this.A.TabStop = false;
				this.B.ImageIndex = 1;
			}
			else
			{
				this.A.Height = this.A.Top - this.A.Top;
				this.A.TabStop = true;
				this.B.ImageIndex = 0;
			}
			this.A.Focus();
		}
		private void E(object obj, EventArgs eventArgs)
		{
			if (this.b(this.A.Text))
			{
				base.DialogResult = DialogResult.OK;
			}
		}
		private void e(object obj, EventArgs eventArgs)
		{
			this.A.Enabled = this.c(this.A.Text);
			MatchCollection matchCollection = Regex.Matches(this.A.Text, "\\r\\n");
			this.A.ScrollBars = ((matchCollection.Count + 1 >= 3) ? ScrollBars.Vertical : ScrollBars.None);
		}
		private void F(object obj, EventArgs eventArgs)
		{
			base.AcceptButton = (this.A.Checked ? null : this.A);
			this.A.AcceptsReturn = this.A.Checked;
			this.A.Focus();
			K1.A().A().TextEditDialogLineBreakSwitch = this.A.Checked;
		}
		private void D(object obj, FormClosingEventArgs formClosingEventArgs)
		{
			c2.A = new Size?(base.Size);
		}
		protected override void Dispose(bool flag)
		{
			if (flag && this.A != null)
			{
				this.A.Dispose();
			}
			base.Dispose(flag);
		}
		private void D()
		{
			this.A = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(c2));
			this.A = new Button();
			this.a = new Button();
			this.A = new CheckBox();
			this.A = new ToolTip(this.A);
			this.B = new Button();
			this.A = new ImageList(this.A);
			this.A = new E();
			base.SuspendLayout();
			this.A.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.A.Location = new Point(34, 79);
			this.A.Name = "btnOk";
			this.A.Size = new Size(75, 23);
			this.A.TabIndex = 3;
			this.A.Text = "OK";
			this.A.UseVisualStyleBackColor = true;
			this.A.Click += new EventHandler(this.E);
			this.a.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.a.DialogResult = DialogResult.Cancel;
			this.a.Location = new Point(115, 79);
			this.a.Name = "btnCancel";
			this.a.Size = new Size(75, 23);
			this.a.TabIndex = 4;
			this.a.Text = "Abbrechen";
			this.a.UseVisualStyleBackColor = true;
			this.A.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.A.AutoSize = true;
			this.A.Location = new Point(13, 58);
			this.A.Name = "cbCatchReturn";
			this.A.Size = new Size(175, 17);
			this.A.TabIndex = 1;
			this.A.Text = "Zeilenwechsel mit Eingabetaste";
			this.A.SetToolTip(this.A, "Zeilenwechsel mit Eingabetaste anstatt mit STRG+Eingabetaste");
			this.A.UseVisualStyleBackColor = true;
			this.A.CheckedChanged += new EventHandler(this.F);
			this.B.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.B.FlatAppearance.BorderSize = 0;
			this.B.FlatStyle = FlatStyle.Flat;
			this.B.ImageIndex = 0;
			this.B.ImageList = this.A;
			this.B.Location = new Point(12, 79);
			this.B.Name = "btnUtil";
			this.B.Size = new Size(13, 13);
			this.B.TabIndex = 2;
			this.B.UseVisualStyleBackColor = true;
			this.B.Click += new EventHandler(this.d);
			this.A.ImageStream = (ImageListStreamer)componentResourceManager.GetObject("imageList.ImageStream");
			this.A.TransparentColor = Color.Transparent;
			this.A.Images.SetKeyName(0, "NavigateDown2.png");
			this.A.Images.SetKeyName(1, "NavigateUp2.png");
			this.A.AcceptsTab = true;
			this.A.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.A.A(2);
			this.A.Location = new Point(12, 12);
			this.A.Multiline = true;
			this.A.Name = "tbText";
			this.A.Size = new Size(178, 40);
			this.A.TabIndex = 0;
			this.A.TextChanged += new EventHandler(this.e);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(202, 114);
			base.Controls.Add(this.B);
			base.Controls.Add(this.a);
			base.Controls.Add(this.A);
			base.Controls.Add(this.A);
			base.Controls.Add(this.A);
			base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			this.MaximumSize = new Size(600, 420);
			base.MinimizeBox = false;
			this.MinimumSize = new Size(200, 140);
			base.Name = "TextEditDlg";
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterParent;
			this.Text = "Text bearbeiten";
			base.FormClosing += new FormClosingEventHandler(this.D);
			base.Load += new EventHandler(this.D);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
