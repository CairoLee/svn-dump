using c;
using d;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace a
{
	public class S1 : Form
	{
		private p1 A;
		private v1 A;
		private Color A = SystemColors.Window;
		private IContainer A;
		private Button A;
		private Button a;
		private Label A;
		private TextBox A;
		private CheckBox A;
		private Label a;
		private Label B;
		private Label b;
		private Label C;
		public S1(string text, p1 p, v1 v)
		{
			this.A();
			this.Font = d2.a().Font;
			this.A = p;
			this.A = v;
			this.A.MaxLength = 64;
			this.A = this.A.BackColor;
			if (!string.IsNullOrEmpty(text))
			{
				this.Text = text;
			}
			this.A.Text = p.b();
			this.B.Text = ((p == null) ? "" : p.J().ToString("dd.MM.yy HH:mm"));
			this.a.Text = ((p == null) ? "" : p.j().ToString("dd.MM.yy HH:mm"));
			this.A.Checked = p.E();
			this.A();
		}
		private void A(object obj, EventArgs eventArgs)
		{
			this.A();
		}
		private void A(object obj, CancelEventArgs cancelEventArgs)
		{
			cancelEventArgs.Cancel = !this.A(this.A.Text, true);
			this.A((Control)obj, cancelEventArgs.Cancel);
		}
		private void a(object obj, EventArgs eventArgs)
		{
			TextBox textBox = (TextBox)obj;
			textBox.Text = o1.b(textBox.Text);
		}
		private void B(object obj, EventArgs eventArgs)
		{
			if (this.A() && this.A(this.A.Text, false))
			{
				this.A.e(this.A.Checked);
				base.DialogResult = DialogResult.OK;
			}
		}
		private void A(Control control, bool flag)
		{
			control.BackColor = (flag ? k1.A : this.A);
			if (flag)
			{
				control.Focus();
			}
		}
		private bool A()
		{
			bool flag = this.ValidateChildren();
			this.A.Enabled = flag;
			return flag;
		}
		private bool A(string text, bool flag)
		{
			string text2 = o1.b(text);
			return text2 == this.A.b() || (this.A.A(text2) && (this.A == null || this.A.A(text2)) && (flag || this.A.a(text2)));
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(S1));
			this.A = new Button();
			this.a = new Button();
			this.A = new Label();
			this.A = new TextBox();
			this.A = new CheckBox();
			this.a = new Label();
			this.B = new Label();
			this.b = new Label();
			this.C = new Label();
			base.SuspendLayout();
			this.A.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.A.Location = new Point(124, 111);
			this.A.Name = "btnOk";
			this.A.Size = new Size(75, 23);
			this.A.TabIndex = 8;
			this.A.Text = "OK";
			this.A.UseVisualStyleBackColor = true;
			this.A.Click += new EventHandler(this.B);
			this.a.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.a.DialogResult = DialogResult.Cancel;
			this.a.Location = new Point(205, 111);
			this.a.Name = "btnCancel";
			this.a.Size = new Size(75, 23);
			this.a.TabIndex = 9;
			this.a.Text = "Abbrechen";
			this.a.UseVisualStyleBackColor = true;
			this.A.AutoSize = true;
			this.A.Location = new Point(23, 16);
			this.A.Name = "lbTitle";
			this.A.Size = new Size(27, 13);
			this.A.TabIndex = 0;
			this.A.Text = "Titel";
			this.A.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.A.Location = new Point(71, 12);
			this.A.Name = "tbTitle";
			this.A.Size = new Size(209, 20);
			this.A.TabIndex = 1;
			this.A.Leave += new EventHandler(this.a);
			this.A.Validating += new CancelEventHandler(this.A);
			this.A.TextChanged += new EventHandler(this.A);
			this.A.AutoSize = true;
			this.A.Location = new Point(71, 80);
			this.A.Name = "cbSymLangEng";
			this.A.Size = new Size(119, 17);
			this.A.TabIndex = 10;
			this.A.Text = "Symboltext englisch";
			this.A.UseVisualStyleBackColor = true;
			this.a.AutoSize = true;
			this.a.Location = new Point(125, 56);
			this.a.Name = "lblDateModifiedValue";
			this.a.Size = new Size(40, 13);
			this.a.TabIndex = 15;
			this.a.Text = "<date>";
			this.B.AutoSize = true;
			this.B.Location = new Point(125, 39);
			this.B.Name = "lblDateCreatedValue";
			this.B.Size = new Size(40, 13);
			this.B.TabIndex = 16;
			this.B.Text = "<date>";
			this.b.AutoSize = true;
			this.b.Location = new Point(68, 56);
			this.b.Name = "lblDateModifiedText";
			this.b.Size = new Size(51, 13);
			this.b.TabIndex = 14;
			this.b.Text = "Geändert";
			this.C.AutoSize = true;
			this.C.Location = new Point(68, 39);
			this.C.Name = "lblDateCreatedText";
			this.C.Size = new Size(38, 13);
			this.C.TabIndex = 13;
			this.C.Text = "Erstellt";
			base.AcceptButton = this.A;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.AutoValidate = AutoValidate.EnableAllowFocusChange;
			base.CancelButton = this.a;
			base.ClientSize = new Size(292, 146);
			base.Controls.Add(this.a);
			base.Controls.Add(this.B);
			base.Controls.Add(this.b);
			base.Controls.Add(this.C);
			base.Controls.Add(this.A);
			base.Controls.Add(this.A);
			base.Controls.Add(this.A);
			base.Controls.Add(this.a);
			base.Controls.Add(this.A);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			this.MaximumSize = new Size(550, 180);
			base.MinimizeBox = false;
			this.MinimumSize = new Size(300, 180);
			base.Name = "DiagramPropertyDialog";
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterParent;
			this.Text = "Diagrammeigenschaften";
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
	public interface s1 : IDisposable
	{
		p1 A();
		void a(p1);
		Control B();
		Form b();
		void C();
		void c(d.a, bool);
		void D(IEnumerable);
		void d(global::c.a);
		void E(Rectangle);
		void e(Rectangle);
		void F();
		void f(Graphics);
		Rectangle G(bool);
		Rectangle g(Rectangle, ref float, out Point, bool);
		void H(Rectangle, float, B1);
	}
}
