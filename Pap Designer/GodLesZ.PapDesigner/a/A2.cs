using c;
using C;
using d;
using D;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace a
{
	public class A2 : UserControl
	{
		public class A
		{
			private A2 A;
			public A(A2 a)
			{
				this.A = a;
			}
			public Type A()
			{
				return this.A.A();
			}
			public void A()
			{
				this.A.B();
			}
		}
		private ToolStripButton A;
		private s1 A;
		private Timer A;
		private IContainer A;
		private ToolStripContainer A;
		private ToolStrip A;
		private ToolStripButton a;
		private ToolStripButton B;
		private ToolStripButton b;
		private ToolStripButton C;
		private ToolStripButton c;
		private ToolStripButton D;
		private ToolStripButton d;
		private ToolStripButton E;
		private ToolStripButton e;
		private V1 A;
		public A2()
		{
			this.b();
			ProfessionalColorTable professionalColorTable = new ProfessionalColorTable();
			this.A.BackColor = A2.A(professionalColorTable.ToolStripGradientBegin, professionalColorTable.ToolStripGradientEnd);
			ToolStripPanel toolStripPanel = this.A.RightToolStripPanel;
			switch (K1.A().A().PapToolBarPlacement)
			{
			case G2.South:
				toolStripPanel = this.A.BottomToolStripPanel;
				break;
			case G2.West:
				toolStripPanel = this.A.LeftToolStripPanel;
				break;
			case G2.North:
				toolStripPanel = this.A.TopToolStripPanel;
				break;
			}
			toolStripPanel.Controls.Add(this.A);
		}
		public V1 A()
		{
			return this.A;
		}
		public s1 A()
		{
			return this.A;
		}
		public void A(s1 s)
		{
			if (this.A() != s)
			{
				if (this.A() != null)
				{
					this.A().L(null);
				}
				this.A = s;
				if (this.A() != null)
				{
					this.A().L(new A2.A(this));
				}
				this.A();
			}
		}
		private e2 A()
		{
			return this.A() as e2;
		}
		public Type A()
		{
			if (this.A == null)
			{
				return null;
			}
			return (Type)this.A.Tag;
		}
		public void A(h2 h)
		{
			this.A.a(h);
			this.A();
		}
		private void A()
		{
			bool flag = this.A() != null && this.A().A() != null && this.A().A().J();
			this.B();
			foreach (ToolStripItem toolStripItem in this.A.Items)
			{
				toolStripItem.Enabled = (this.A() != null && !flag);
			}
			this.a();
			this.e.Enabled = false;
		}
		private void a()
		{
			if (this.A() != null)
			{
				if (this.A == null)
				{
					this.A = new Timer();
					this.A.Tick += new EventHandler(this.B);
					this.A.Interval = 500;
					this.A.Start();
				}
				this.e.Enabled = this.A().K();
				return;
			}
			if (this.A != null)
			{
				this.A.Stop();
				this.A.Tick -= new EventHandler(this.B);
				this.A.Dispose();
				this.A = null;
			}
			this.e.Enabled = false;
		}
		private void B()
		{
			if (this.A != null)
			{
				this.A(Cursors.Default);
				this.A.Checked = false;
				this.A = null;
			}
		}
		private void A(ToolStripButton toolStripButton)
		{
			this.B();
			this.A = toolStripButton;
			this.A.Checked = true;
			this.A(X.A().A((Type)toolStripButton.Tag));
		}
		private void A(Cursor cursor)
		{
			this.Cursor = cursor;
			this.A.Cursor = cursor;
		}
		private void A(object obj, EventArgs eventArgs)
		{
			T t = T.A();
			x x = t.A();
			this.e.Text = x.a();
			this.e.ToolTipText = x.B();
			this.e.Tag = null;
			t t2 = t.A();
			this.A(t2, this.a, typeof(D.b));
			this.A(t2, this.B, typeof(global::C.c));
			this.A(t2, this.b, typeof(d.b));
			this.A(t2, this.C, typeof(d.B));
			this.A(t2, this.c, typeof(global::c.c));
			this.A(t2, this.D, typeof(global::C.b));
			this.A(t2, this.d, typeof(d.A));
			this.A(t2, this.E, typeof(global::c.B));
			this.A();
		}
		private void A(t t, ToolStripButton toolStripButton, Type type)
		{
			x x = t.A(type);
			toolStripButton.Text = x.a();
			toolStripButton.ToolTipText = x.B();
			toolStripButton.Tag = type;
		}
		private void A(object obj, LayoutEventArgs layoutEventArgs)
		{
			int num = this.A.ImageScalingSize.Width;
			if (this.A.Orientation == Orientation.Horizontal)
			{
				int num2 = 4;
				int num3 = 18;
				num = (base.Size.Width - num3) / this.A.Items.Count - num2;
			}
			else
			{
				int num4 = 6;
				int num5 = 28;
				int num6 = (base.Size.Height - num5) / this.A.Items.Count - num4;
				num = num6 * 2;
			}
			num = Math.Max(86, Math.Min(112, num));
			this.A.ImageScalingSize = new Size(num, num / 2);
		}
		private void a(object obj, EventArgs eventArgs)
		{
			ToolStripButton toolStripButton = (ToolStripButton)obj;
			bool flag = !toolStripButton.Checked;
			this.B();
			if (flag)
			{
				this.A(toolStripButton);
			}
		}
		private void B(object obj, EventArgs eventArgs)
		{
			this.a();
		}
		private void b(object obj, EventArgs eventArgs)
		{
			this.B();
			this.A().k();
			this.a();
			this.e.Enabled = false;
		}
		private void A(object obj, ControlEventArgs controlEventArgs)
		{
			K1.A().A().PapToolBarPlacement = G2.East;
		}
		private void a(object obj, ControlEventArgs controlEventArgs)
		{
			K1.A().A().PapToolBarPlacement = G2.South;
		}
		private void B(object obj, ControlEventArgs controlEventArgs)
		{
			K1.A().A().PapToolBarPlacement = G2.West;
		}
		private void b(object obj, ControlEventArgs controlEventArgs)
		{
			K1.A().A().PapToolBarPlacement = G2.North;
		}
		private static Color A(Color color, Color color2)
		{
			return Color.FromArgb((int)((color.A + color2.A) / 2), (int)((color.R + color2.R) / 2), (int)((color.G + color2.G) / 2), (int)((color.B + color2.B) / 2));
		}
		protected override void Dispose(bool flag)
		{
			if (flag && this.A != null)
			{
				this.A.Dispose();
			}
			base.Dispose(flag);
		}
		private void b()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(A2));
			this.A = new ToolStripContainer();
			this.A = new ToolStrip();
			this.e = new ToolStripButton();
			this.a = new ToolStripButton();
			this.B = new ToolStripButton();
			this.b = new ToolStripButton();
			this.C = new ToolStripButton();
			this.c = new ToolStripButton();
			this.D = new ToolStripButton();
			this.d = new ToolStripButton();
			this.E = new ToolStripButton();
			this.A = new V1();
			this.A.ContentPanel.SuspendLayout();
			this.A.RightToolStripPanel.SuspendLayout();
			this.A.SuspendLayout();
			this.A.SuspendLayout();
			base.SuspendLayout();
			this.A.BottomToolStripPanel.ControlAdded += new ControlEventHandler(this.a);
			this.A.ContentPanel.Controls.Add(this.A);
			this.A.ContentPanel.Size = new Size(423, 547);
			this.A.Dock = DockStyle.Fill;
			this.A.LeftToolStripPanel.ControlAdded += new ControlEventHandler(this.B);
			this.A.Location = new Point(0, 0);
			this.A.Name = "toolStripContainer";
			this.A.RightToolStripPanel.Controls.Add(this.A);
			this.A.RightToolStripPanel.ControlAdded += new ControlEventHandler(this.A);
			this.A.Size = new Size(524, 572);
			this.A.TabIndex = 0;
			this.A.Text = "toolStripContainer1";
			this.A.TopToolStripPanel.ControlAdded += new ControlEventHandler(this.b);
			this.A.Dock = DockStyle.None;
			this.A.GripMargin = new Padding(4);
			this.A.ImageScalingSize = new Size(96, 48);
			this.A.Items.AddRange(new ToolStripItem[]
			{
				this.e,
				this.a,
				this.B,
				this.b,
				this.C,
				this.c,
				this.D,
				this.d,
				this.E
			});
			this.A.Location = new Point(0, 0);
			this.A.Name = "toolStrip";
			this.A.RenderMode = ToolStripRenderMode.Professional;
			this.A.Size = new Size(101, 547);
			this.A.Stretch = true;
			this.A.TabIndex = 4;
			this.A.Layout += new LayoutEventHandler(this.A);
			this.e.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.e.Image = (Image)componentResourceManager.GetObject("tsbAdjustView.Image");
			this.e.ImageTransparentColor = Color.Magenta;
			this.e.Name = "tsbAdjustView";
			this.e.Size = new Size(99, 52);
			this.e.Text = "toolStripButton0";
			this.e.Click += new EventHandler(this.b);
			this.a.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.a.Image = (Image)componentResourceManager.GetObject("tsbFigInput.Image");
			this.a.ImageTransparentColor = Color.Magenta;
			this.a.Name = "tsbFigInput";
			this.a.Size = new Size(99, 52);
			this.a.Text = "toolStripButton1";
			this.a.Click += new EventHandler(this.a);
			this.B.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.B.Image = (Image)componentResourceManager.GetObject("tsbFigOutput.Image");
			this.B.ImageTransparentColor = Color.Magenta;
			this.B.Name = "tsbFigOutput";
			this.B.Size = new Size(99, 52);
			this.B.Text = "toolStripButton2";
			this.B.Click += new EventHandler(this.a);
			this.b.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.b.Image = (Image)componentResourceManager.GetObject("tsbFigActivity.Image");
			this.b.ImageTransparentColor = Color.Magenta;
			this.b.Name = "tsbFigActivity";
			this.b.Size = new Size(99, 52);
			this.b.Text = "toolStripButton3";
			this.b.Click += new EventHandler(this.a);
			this.C.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.C.Image = (Image)componentResourceManager.GetObject("tsbFigModule.Image");
			this.C.ImageTransparentColor = Color.Magenta;
			this.C.Name = "tsbFigModule";
			this.C.Size = new Size(99, 52);
			this.C.Text = "toolStripButton4";
			this.C.Click += new EventHandler(this.a);
			this.c.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.c.Image = (Image)componentResourceManager.GetObject("tsbFigCondition.Image");
			this.c.ImageTransparentColor = Color.Magenta;
			this.c.Name = "tsbFigCondition";
			this.c.Size = new Size(99, 52);
			this.c.Text = "toolStripButton5";
			this.c.Click += new EventHandler(this.a);
			this.D.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.D.Image = (Image)componentResourceManager.GetObject("tsbFigLoop.Image");
			this.D.ImageTransparentColor = Color.Magenta;
			this.D.Name = "tsbFigLoop";
			this.D.Size = new Size(99, 52);
			this.D.Text = "toolStripButton6";
			this.D.Click += new EventHandler(this.a);
			this.d.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.d.Image = (Image)componentResourceManager.GetObject("tsbFigComment.Image");
			this.d.ImageTransparentColor = Color.Magenta;
			this.d.Name = "tsbFigComment";
			this.d.Size = new Size(99, 52);
			this.d.Text = "toolStripButton0";
			this.d.Click += new EventHandler(this.a);
			this.E.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.E.Image = (Image)componentResourceManager.GetObject("tsbFigConnector.Image");
			this.E.ImageTransparentColor = Color.Magenta;
			this.E.Name = "tsbFigConnector";
			this.E.Size = new Size(99, 52);
			this.E.Text = "toolStripButton8";
			this.E.Click += new EventHandler(this.a);
			this.A.Dock = DockStyle.Fill;
			this.A.Location = new Point(0, 0);
			this.A.Name = "flipPanel";
			this.A.A(null);
			this.A.Size = new Size(423, 547);
			this.A.TabIndex = 0;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.A);
			base.Name = "PapToolPanel";
			base.Size = new Size(524, 572);
			base.Load += new EventHandler(this.A);
			this.A.ContentPanel.ResumeLayout(false);
			this.A.RightToolStripPanel.ResumeLayout(false);
			this.A.RightToolStripPanel.PerformLayout();
			this.A.ResumeLayout(false);
			this.A.PerformLayout();
			this.A.ResumeLayout(false);
			this.A.PerformLayout();
			base.ResumeLayout(false);
		}
	}
	public class a2 : Form
	{
		private const int A = 16;
		private const float A = 0.8f;
		private const float a = 1.08f;
		private static int a;
		private Size A = new Size(100, 100);
		private Size a = new Size(100, 100);
		private IContainer A;
		private Button A;
		private Button a;
		private CheckBox A;
		private TextBox A;
		private TextBox a;
		private TrackBar A;
		private Label A;
		private Label a;
		private Label B;
		private CheckBox a;
		private Label b;
		private ToolTip A;
		public a2()
		{
			this.A();
			this.Font = d2.a().Font;
			H.A(this.A);
			H.A(this.A, this.A, this.b);
			H.A(this.A, this.A, this.a);
			H.A(this.A, this.a, this.A);
			this.A.Minimum = -16;
			this.A.Maximum = 16;
			this.A.Value = a2.a;
			this.A.TickFrequency = 2;
			this.A.LargeChange = 2;
			this.A.SmallChange = 1;
			this.A(null, null);
			this.A.Checked = false;
		}
		public Size A()
		{
			return this.a;
		}
		public void A(Size size)
		{
			this.A = size;
			this.A(null, null);
		}
		public bool A()
		{
			return this.A.Checked;
		}
		public void A(bool @checked)
		{
			this.A.Checked = @checked;
		}
		public bool a()
		{
			return this.a.Checked;
		}
		public void a(bool @checked)
		{
			this.a.Checked = @checked;
		}
		private void A(object obj, EventArgs eventArgs)
		{
			float num = (float)Math.Min(16, Math.Max(-16, this.A.Value));
			float num2 = (float)Math.Pow(1.0800000429153442, (double)(num / 0.8f));
			this.a.Width = (int)((float)this.A.Width * num2);
			this.a.Height = (int)((float)this.A.Height * num2);
			this.a.Text = "" + this.a.Width;
			this.A.Text = "" + this.a.Height;
		}
		private void a(object obj, EventArgs eventArgs)
		{
			DialogResult dialogResult = DialogResult.OK;
			if (dialogResult == DialogResult.OK)
			{
				a2.a = this.A.Value;
			}
			base.DialogResult = dialogResult;
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
			this.A = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(a2));
			this.A = new Button();
			this.a = new Button();
			this.A = new CheckBox();
			this.A = new TextBox();
			this.a = new TextBox();
			this.A = new TrackBar();
			this.A = new Label();
			this.a = new Label();
			this.B = new Label();
			this.a = new CheckBox();
			this.b = new Label();
			this.A = new ToolTip(this.A);
			((ISupportInitialize)this.A).BeginInit();
			base.SuspendLayout();
			this.A.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.A.Location = new Point(186, 133);
			this.A.Name = "btnOk";
			this.A.Size = new Size(75, 23);
			this.A.TabIndex = 0;
			this.A.Text = "OK";
			this.A.UseVisualStyleBackColor = true;
			this.A.Click += new EventHandler(this.a);
			this.a.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.a.DialogResult = DialogResult.Cancel;
			this.a.Location = new Point(267, 133);
			this.a.Name = "btnCancel";
			this.a.Size = new Size(75, 23);
			this.a.TabIndex = 1;
			this.a.Text = "Abbrechen";
			this.a.UseVisualStyleBackColor = true;
			this.A.AutoSize = true;
			this.A.Location = new Point(170, 78);
			this.A.Name = "cbTransparent";
			this.A.Size = new Size(150, 17);
			this.A.TabIndex = 9;
			this.A.Text = "Transparenter Hintergrund";
			this.A.SetToolTip(this.A, "Transparenter Hintergrund der Exportgrafik schafft ehöhte Flexibilität bei der Verwendung der Grafik");
			this.A.UseVisualStyleBackColor = true;
			this.A.Location = new Point(63, 102);
			this.A.Name = "textHeight";
			this.A.ReadOnly = true;
			this.A.Size = new Size(75, 20);
			this.A.TabIndex = 7;
			this.A.SetToolTip(this.A, "Pixelhöhe der Exportgrafik");
			this.a.Location = new Point(63, 76);
			this.a.Name = "textWidth";
			this.a.ReadOnly = true;
			this.a.Size = new Size(75, 20);
			this.a.TabIndex = 5;
			this.A.SetToolTip(this.a, "Pixelbreite der Exportgrafik");
			this.A.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.A.Location = new Point(15, 25);
			this.A.Maximum = 100;
			this.A.Name = "trackBar";
			this.A.Size = new Size(330, 45);
			this.A.SmallChange = 5;
			this.A.TabIndex = 3;
			this.A.TickFrequency = 5;
			this.A.TickStyle = TickStyle.TopLeft;
			this.A.SetToolTip(this.A, "Finden Sie das Optimum zwischen Dateigröße und Bildqualität der Exportgrafik");
			this.A.Value = 50;
			this.A.Scroll += new EventHandler(this.A);
			this.A.AutoSize = true;
			this.A.Location = new Point(12, 79);
			this.A.Name = "lbWidth";
			this.A.Size = new Size(34, 13);
			this.A.TabIndex = 4;
			this.A.Text = "Breite";
			this.a.AutoSize = true;
			this.a.Location = new Point(12, 105);
			this.a.Name = "lbHeigth";
			this.a.Size = new Size(33, 13);
			this.a.TabIndex = 6;
			this.a.Text = "Höhe";
			this.B.AutoSize = true;
			this.B.Location = new Point(60, 125);
			this.B.Name = "lbPixel";
			this.B.Size = new Size(29, 13);
			this.B.TabIndex = 8;
			this.B.Text = "Pixel";
			this.a.AutoSize = true;
			this.a.Checked = true;
			this.a.CheckState = CheckState.Checked;
			this.a.Location = new Point(170, 101);
			this.a.Name = "cbOpenGraphic";
			this.a.Size = new Size(170, 17);
			this.a.TabIndex = 10;
			this.a.Text = "Grafik in Standardeditor öffnen";
			this.A.SetToolTip(this.a, "Nach dem Erstellen der Exportdatei wird diese mit dem im System vorgesehene Grafikprogramm geöffnet");
			this.a.UseVisualStyleBackColor = true;
			this.b.AutoSize = true;
			this.b.Location = new Point(12, 9);
			this.b.Name = "lbTrackBar";
			this.b.Size = new Size(94, 13);
			this.b.TabIndex = 2;
			this.b.Text = "Größe / Auflösung";
			base.AcceptButton = this.A;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.CancelButton = this.a;
			base.ClientSize = new Size(354, 168);
			base.Controls.Add(this.b);
			base.Controls.Add(this.B);
			base.Controls.Add(this.a);
			base.Controls.Add(this.A);
			base.Controls.Add(this.a);
			base.Controls.Add(this.A);
			base.Controls.Add(this.a);
			base.Controls.Add(this.A);
			base.Controls.Add(this.a);
			base.Controls.Add(this.A);
			base.Controls.Add(this.A);
			base.FormBorderStyle = FormBorderStyle.FixedSingle;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "PictureExportSettings";
			base.ShowInTaskbar = false;
			this.Text = "Bildeigenschaften der Exportdatei";
			((ISupportInitialize)this.A).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
