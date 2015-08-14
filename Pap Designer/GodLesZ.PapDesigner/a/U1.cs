using c;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
namespace a
{
	public class U1 : Form
	{
		private static Size? A = null;
		private Color A = SystemColors.Window;
		private s1 A;
		private Rectangle A = Rectangle.Empty;
		private IContainer A;
		private Button A;
		private Button a;
		private Label A;
		private TextBox A;
		public U1(s1 s, string text, string text2, Rectangle rectangle)
		{
			this.A();
			this.Font = d2.a().Font;
			this.A = s;
			this.A = rectangle;
			this.A.MaxLength = 64;
			this.A = this.A.BackColor;
			this.Text = text;
			this.A.Text = text2;
			this.A();
			if (U1.A.HasValue)
			{
				base.Size = U1.A.Value;
			}
		}
		public string A()
		{
			return this.A.Text;
		}
		public void A(string text)
		{
			this.A.Text = text;
		}
		private void A(object obj, EventArgs eventArgs)
		{
			e2 e = this.A as e2;
			if (e != null)
			{
				u.A(this, e.RectangleToScreen(e.L(this.A)));
			}
		}
		private void a(object obj, EventArgs eventArgs)
		{
			this.A();
		}
		private void A(object obj, CancelEventArgs cancelEventArgs)
		{
			cancelEventArgs.Cancel = !this.A(this.A.Text, true);
			this.A((Control)obj, cancelEventArgs.Cancel);
		}
		private void B(object obj, EventArgs eventArgs)
		{
			TextBox textBox = (TextBox)obj;
			textBox.Text = o1.b(textBox.Text);
		}
		private void b(object obj, EventArgs eventArgs)
		{
			if (this.A() && this.A(this.A.Text, false))
			{
				base.DialogResult = DialogResult.OK;
			}
		}
		private void A(object obj, FormClosingEventArgs formClosingEventArgs)
		{
			U1.A = new Size?(base.Size);
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
			if (flag)
			{
				return true;
			}
			this.A(text2);
			return true;
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(U1));
			this.A = new Button();
			this.a = new Button();
			this.A = new Label();
			this.A = new TextBox();
			base.SuspendLayout();
			this.A.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.A.Location = new Point(84, 38);
			this.A.Name = "btnOk";
			this.A.Size = new Size(75, 23);
			this.A.TabIndex = 8;
			this.A.Text = "OK";
			this.A.UseVisualStyleBackColor = true;
			this.A.Click += new EventHandler(this.b);
			this.a.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.a.DialogResult = DialogResult.Cancel;
			this.a.Location = new Point(165, 38);
			this.a.Name = "btnCancel";
			this.a.Size = new Size(75, 23);
			this.a.TabIndex = 9;
			this.a.Text = "Abbrechen";
			this.a.UseVisualStyleBackColor = true;
			this.A.AutoSize = true;
			this.A.Location = new Point(12, 15);
			this.A.Name = "lbTitle";
			this.A.Size = new Size(28, 13);
			this.A.TabIndex = 0;
			this.A.Text = "Text";
			this.A.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.A.Location = new Point(46, 12);
			this.A.Name = "tbTextValue";
			this.A.Size = new Size(194, 20);
			this.A.TabIndex = 1;
			this.A.Leave += new EventHandler(this.B);
			this.A.Validating += new CancelEventHandler(this.A);
			this.A.TextChanged += new EventHandler(this.a);
			base.AcceptButton = this.A;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.AutoValidate = AutoValidate.EnableAllowFocusChange;
			base.CancelButton = this.a;
			base.ClientSize = new Size(252, 74);
			base.Controls.Add(this.A);
			base.Controls.Add(this.A);
			base.Controls.Add(this.a);
			base.Controls.Add(this.A);
			base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			this.MaximumSize = new Size(460, 120);
			base.MinimizeBox = false;
			this.MinimumSize = new Size(260, 100);
			base.Name = "TextLineEditDialog";
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterParent;
			this.Text = "Text bearbeiten";
			base.FormClosing += new FormClosingEventHandler(this.A);
			base.Load += new EventHandler(this.A);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
	public class u1 : Form
	{
		private static u1 A;
		private h2 A;
		private int A = -1;
		private int a = -1;
		private float A;
		private s1[] A;
		private string A;
		private IContainer A;
		private MenuStrip A;
		private ToolStripButton A;
		private ToolStripButton a;
		private ToolStripComboBox A;
		private PrintDialog A;
		private PrintDocument A;
		private PageSetupDialog A;
		private ToolStripButton B;
		private ToolStripButton b;
		private PrintPreviewControl A;
		private u1()
		{
			this.B();
			this.Font = d2.a().Font;
			this.A = this.Text;
			this.A.AutoZoom = true;
			this.A.DefaultPageSettings.Landscape = false;
			this.A.DefaultPageSettings.Margins.Top = 60;
			this.A.DefaultPageSettings.Margins.Left = 60;
			this.A.DefaultPageSettings.Margins.Bottom = 60;
			this.A.DefaultPageSettings.Margins.Right = 60;
			this.A.UseEXDialog = true;
			this.A.AllowPrintToFile = false;
			this.A.AllowCurrentPage = true;
			this.A.AllowSomePages = true;
		}
		private static u1 A()
		{
			if (u1.A == null)
			{
				u1.A = new u1();
			}
			return u1.A;
		}
		private int A()
		{
			if (this.A == null)
			{
				return 0;
			}
			return this.A.E().B();
		}
		private int a()
		{
			return this.A.SelectedIndex;
		}
		public static bool A(h2 h)
		{
			return h != null && h.E().B() > 0;
		}
		public static void A(Form owner, h2 h, p1 p)
		{
			if (u1.A(h))
			{
				h.d(DateTime.Now);
				u1 u = u1.A();
				u.A(h, p);
				u.ShowDialog(owner);
			}
		}
		public static void A()
		{
			u1.A().a(null, null);
		}
		private void A(object obj, PrintEventArgs printEventArgs)
		{
			this.A = 0;
			this.a = this.A() - 1;
			this.A = 0f;
			this.A = new s1[this.A.E().B()];
			for (int i = 0; i < this.A.Length; i++)
			{
				this.A[i] = this.A.E().B(i).f();
			}
			if (printEventArgs.PrintAction != PrintAction.PrintToPreview)
			{
				PrinterSettings printerSettings = this.A.PrinterSettings;
				PrintRange printRange = printerSettings.PrintRange;
				PrintRange printRange2 = printRange;
				if (printRange2 != PrintRange.SomePages)
				{
					if (printRange2 != PrintRange.CurrentPage)
					{
						return;
					}
					this.A = (this.a = this.a());
					return;
				}
				else
				{
					this.A = printerSettings.FromPage - 1;
					this.a = printerSettings.ToPage - 1;
				}
			}
		}
		private void A(object obj, QueryPageSettingsEventArgs queryPageSettingsEventArgs)
		{
		}
		private void A(object obj, PrintPageEventArgs printPageEventArgs)
		{
			Graphics graphics = printPageEventArgs.Graphics;
			p1 p = this.A.E().B(this.A);
			s1 s = this.A[this.A];
			s.f(graphics);
			graphics.DrawRectangle(new Pen(Color.Black), printPageEventArgs.MarginBounds);
			bool flag = p.E();
			string str = flag ? "Project" : "Projekt";
			string text = flag ? "File" : "Datei";
			string text2 = flag ? "Author" : "Ersteller";
			string text3 = flag ? "Diagram" : "Diagramm";
			string text4 = flag ? "Created" : "Erstellt";
			string text5 = flag ? "Modified" : "Geändert";
			string text6 = str + ": " + this.A.b();
			if (!string.IsNullOrEmpty(this.A.f()))
			{
				string text7 = text6;
				text6 = string.Concat(new string[]
				{
					text7,
					"\n",
					text,
					": ",
					Path.GetFileName(this.A.f())
				});
			}
			if (!string.IsNullOrEmpty(this.A.E()))
			{
				string text8 = text6;
				text6 = string.Concat(new string[]
				{
					text8,
					"\n",
					text2,
					": ",
					this.A.E()
				});
			}
			string text9 = text6;
			text6 = string.Concat(new string[]
			{
				text9,
				"\n",
				text3,
				": ",
				s.A().b()
			});
			string text10 = p.J().ToString("dd.MM.yy");
			if (!string.IsNullOrEmpty(text10))
			{
				string text11 = text6;
				text6 = string.Concat(new string[]
				{
					text11,
					"\n",
					text4,
					": ",
					text10
				});
			}
			string text12 = p.j().ToString("dd.MM.yy");
			if (!string.IsNullOrEmpty(text12))
			{
				string text13 = text6;
				text6 = string.Concat(new string[]
				{
					text13,
					"  ",
					text5,
					": ",
					text12
				});
			}
			Font font = global::c.C.A();
			StringFormat stringFormat = new StringFormat();
			SizeF sizeF = graphics.MeasureString(text6, font, new Point(0, 0), stringFormat);
			Rectangle rect = new Rectangle(printPageEventArgs.MarginBounds.Location, sizeF.ToSize());
			int num = 3;
			rect.Width += num * 2;
			rect.Height += num * 2;
			rect.X += printPageEventArgs.MarginBounds.Width - rect.Width;
			rect.Y += printPageEventArgs.MarginBounds.Height - rect.Height;
			graphics.DrawRectangle(new Pen(Color.Black), rect);
			Point p2 = new Point(rect.X + num, rect.Y + num);
			graphics.DrawString(text6, font, global::c.C.A, p2);
			Rectangle marginBounds = printPageEventArgs.MarginBounds;
			marginBounds.Height -= rect.Height;
			if (this.A == 0f && !K1.A().A().SeparatePrintPageScaling)
			{
				this.A = 3.40282347E+38f;
				s1[] array = this.A;
				for (int i = 0; i < array.Length; i++)
				{
					s1 s2 = array[i];
					float val = 0f;
					Point point;
					s2.g(marginBounds, ref val, out point, false);
					this.A = Math.Min(this.A, val);
				}
			}
			B1 b = p.G(s, graphics, a1.Paper, false);
			s.H(marginBounds, this.A, b);
			printPageEventArgs.HasMorePages = (++this.A <= this.a);
		}
		private void a(object obj, PrintEventArgs printEventArgs)
		{
			s1[] array = this.A;
			for (int i = 0; i < array.Length; i++)
			{
				s1 s = array[i];
				s.Dispose();
			}
			this.A = null;
		}
		private void A(object obj, EventArgs eventArgs)
		{
			PrinterSettings printerSettings = this.A.PrinterSettings;
			printerSettings.PrintRange = PrintRange.CurrentPage;
			printerSettings.FromPage = (printerSettings.MinimumPage = 1);
			printerSettings.ToPage = (printerSettings.MaximumPage = this.A());
			base.Visible = false;
			base.Visible = true;
			this.Refresh();
			if (this.A.ShowDialog() == DialogResult.OK)
			{
				this.A.Print();
			}
		}
		private void a(object obj, EventArgs eventArgs)
		{
			Margins margins = this.A.DefaultPageSettings.Margins;
			Margins margins2 = (Margins)margins.Clone();
			if (RegionInfo.CurrentRegion.IsMetric)
			{
				margins.Bottom = (int)((double)margins.Bottom * 2.54);
				margins.Top = (int)((double)margins.Top * 2.54);
				margins.Left = (int)((double)margins.Left * 2.54);
				margins.Right = (int)((double)margins.Right * 2.54);
			}
			DialogResult dialogResult = this.A.ShowDialog();
			if (dialogResult == DialogResult.OK)
			{
				this.A.InvalidatePreview();
				return;
			}
			this.A.DefaultPageSettings.Margins = margins2;
		}
		private void B(object obj, EventArgs eventArgs)
		{
			this.A.StartPage--;
			this.a();
		}
		private void b(object obj, EventArgs eventArgs)
		{
			this.A.StartPage++;
			this.a();
		}
		private void C(object obj, EventArgs eventArgs)
		{
			this.A.StartPage = this.A.SelectedIndex;
			this.a();
		}
		private void A(h2 h, p1 p)
		{
			this.A = h;
			string str = h.e() ? "" : "Projekt ";
			this.Text = this.A + " " + str + h.b();
			this.A.Items.Clear();
			int startPage = 0;
			int num = 0;
			foreach (p1 current in h.E())
			{
				if (current == p)
				{
					startPage = num;
				}
				this.A.Items.Add(string.Concat(new object[]
				{
					"",
					++num,
					": ",
					current.b()
				}));
			}
			this.A.InvalidatePreview();
			this.A.StartPage = startPage;
			this.a();
		}
		private void a()
		{
			this.B.Enabled = (this.A.StartPage > 0);
			this.b.Enabled = (this.A.StartPage < this.A.E() - 1);
			this.A.SelectedIndex = this.A.StartPage;
		}
		protected override void Dispose(bool flag)
		{
			if (flag && this.A != null)
			{
				this.A.Dispose();
			}
			base.Dispose(flag);
		}
		private void B()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(u1));
			this.A = new MenuStrip();
			this.A = new ToolStripButton();
			this.a = new ToolStripButton();
			this.B = new ToolStripButton();
			this.b = new ToolStripButton();
			this.A = new ToolStripComboBox();
			this.A = new PrintDocument();
			this.A = new PrintDialog();
			this.A = new PageSetupDialog();
			this.A = new PrintPreviewControl();
			this.A.SuspendLayout();
			base.SuspendLayout();
			this.A.Items.AddRange(new ToolStripItem[]
			{
				this.A,
				this.a,
				this.B,
				this.b,
				this.A
			});
			this.A.Location = new Point(0, 0);
			this.A.Name = "topMenu";
			this.A.Size = new Size(474, 27);
			this.A.TabIndex = 0;
			this.A.Text = "toolStripTop";
			this.A.Image = (Image)componentResourceManager.GetObject("btnPrint.Image");
			this.A.ImageTransparentColor = Color.Magenta;
			this.A.Name = "btnPrint";
			this.A.Size = new Size(78, 20);
			this.A.Text = "Drucken...";
			this.A.Click += new EventHandler(this.A);
			this.a.Image = (Image)componentResourceManager.GetObject("btnSettings.Image");
			this.a.ImageTransparentColor = Color.Magenta;
			this.a.Name = "btnSettings";
			this.a.Size = new Size(113, 20);
			this.a.Text = "Seite einrichten...";
			this.a.Click += new EventHandler(this.a);
			this.B.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.B.Image = (Image)componentResourceManager.GetObject("btnPrev.Image");
			this.B.ImageTransparentColor = Color.Magenta;
			this.B.Name = "btnPrev";
			this.B.Size = new Size(23, 20);
			this.B.Text = "<<";
			this.B.Click += new EventHandler(this.B);
			this.b.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.b.Image = (Image)componentResourceManager.GetObject("btnNext.Image");
			this.b.ImageTransparentColor = Color.Magenta;
			this.b.Name = "btnNext";
			this.b.Size = new Size(23, 20);
			this.b.Text = ">>";
			this.b.Click += new EventHandler(this.b);
			this.A.Name = "cbPages";
			this.A.Size = new Size(200, 23);
			this.A.SelectedIndexChanged += new EventHandler(this.C);
			this.A.PrintPage += new PrintPageEventHandler(this.A);
			this.A.QueryPageSettings += new QueryPageSettingsEventHandler(this.A);
			this.A.EndPrint += new PrintEventHandler(this.a);
			this.A.BeginPrint += new PrintEventHandler(this.A);
			this.A.Document = this.A;
			this.A.UseEXDialog = true;
			this.A.Document = this.A;
			this.A.AutoZoom = false;
			this.A.Dock = DockStyle.Fill;
			this.A.Document = this.A;
			this.A.Location = new Point(0, 27);
			this.A.Name = "previewControl";
			this.A.Size = new Size(474, 540);
			this.A.TabIndex = 1;
			this.A.Zoom = 0.46535500427716;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(474, 567);
			base.Controls.Add(this.A);
			base.Controls.Add(this.A);
			this.DoubleBuffered = true;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "PrintManager";
			base.ShowInTaskbar = false;
			this.Text = "Druckvorschau";
			this.A.ResumeLayout(false);
			this.A.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
