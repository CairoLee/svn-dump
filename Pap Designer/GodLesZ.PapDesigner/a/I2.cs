using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
namespace a
{
	public class I2 : UserControl
	{
		public delegate void A(o1);
		private const int A = 0;
		private const int a = 2;
		private const int B = 4;
		private const int b = 6;
		private const int C = 8;
		private W1<h2> A;
		private Dictionary<o1, TreeNode> A = new Dictionary<o1, TreeNode>();
		private o1 A;
		private TreeNode A;
		private bool A;
		private bool a;
		private bool B;
		private h2 A;
		private p1 A;
		private bool b;
		private TreeNode a;
		private TreeNode B;
		private TreeNode b;
		private I2.A A;
		private IContainer A;
		private TreeView A;
		internal ToolStripMenuItem A;
		internal ToolStripMenuItem a;
		private ContextMenuStrip A;
		private ImageList A;
		public I2()
		{
			this.b();
		}
		public W1<h2> A()
		{
			return this.A;
		}
		public void A(W1<h2> w)
		{
			if (this.A != w)
			{
				if (this.A != null)
				{
					this.A.b(new W1<h2>.B(this.A));
					this.A.e(new W1<h2>.a(this.a));
					foreach (h2 current in this.A)
					{
						this.a(current);
					}
				}
				this.A = w;
				if (this.A != null)
				{
					int num = 0;
					foreach (h2 current2 in this.A)
					{
						this.A(current2, num++);
					}
					this.A.B(new W1<h2>.B(this.A));
					this.A.E(new W1<h2>.a(this.a));
				}
			}
		}
		public h2 A()
		{
			for (TreeNode treeNode = this.A.SelectedNode; treeNode != null; treeNode = treeNode.Parent)
			{
				if (treeNode.Tag is h2)
				{
					return (h2)treeNode.Tag;
				}
			}
			return null;
		}
		public p1 A()
		{
			for (TreeNode treeNode = this.A.SelectedNode; treeNode != null; treeNode = treeNode.Parent)
			{
				if (treeNode.Tag is p1)
				{
					return (p1)treeNode.Tag;
				}
			}
			return null;
		}
		public void A(h2 key)
		{
			TreeNode selectedNode = this.A[key];
			this.A.SelectedNode = selectedNode;
			this.B();
		}
		public void A(p1 key)
		{
			TreeNode selectedNode = this.A[key];
			this.A.SelectedNode = selectedNode;
			this.B();
		}
		public void A()
		{
			this.A.BeginUpdate();
		}
		public void a()
		{
			this.A.EndUpdate();
		}
		public bool A()
		{
			return this.A.Focus();
		}
		private void A(h2 h, int num)
		{
			J2<h2> j = new J2<h2>(h);
			this.A.Add(h, j);
			if (h.e())
			{
				int i;
				for (i = 0; i < this.A.Nodes.Count; i++)
				{
					J2<h2> j2 = this.A.Nodes[i] as J2<h2>;
					if (!j2.A().e())
					{
						break;
					}
				}
				this.A.Nodes.Insert(i, j);
				j.ImageIndex = this.A.ImageIndex + 4;
				j.SelectedImageIndex = this.A.SelectedImageIndex + 4;
			}
			else
			{
				this.A.Nodes.Add(j);
				j.ImageIndex = this.A.ImageIndex;
				j.SelectedImageIndex = this.A.SelectedImageIndex;
			}
			h.E().B(new W1<p1>.B(this.A));
			h.E().E(new W1<p1>.a(this.a));
			int num2 = 0;
			foreach (p1 current in h.E())
			{
				this.A(current, num2++);
			}
			j.Expand();
			this.B();
		}
		private void a(h2 h)
		{
			TreeNode treeNode = this.A[h];
			foreach (p1 current in h.E())
			{
				this.a(current);
			}
			h.E().b(new W1<p1>.B(this.A));
			h.E().e(new W1<p1>.a(this.a));
			this.A.Remove(h);
			treeNode.Remove();
			this.B();
		}
		private void A(p1 p, int index)
		{
			h2 h = this.A(p);
			TreeNode treeNode = this.A[h];
			J2<p1> j = new J2<p1>(p);
			this.A.Add(p, j);
			treeNode.Nodes.Insert(index, j);
			int num = h.e() ? 6 : 2;
			j.ImageIndex = this.A.ImageIndex + num;
			j.SelectedImageIndex = this.A.SelectedImageIndex + num;
			this.B();
		}
		private void a(p1 key)
		{
			TreeNode treeNode = this.A[key];
			this.A.Remove(key);
			if (this.b == treeNode)
			{
				this.b = null;
			}
			else
			{
				if (this.b != null)
				{
					this.A(this.b);
				}
			}
			treeNode.Remove();
			this.B();
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void A(I2.A a)
		{
			this.A = (I2.A)Delegate.Combine(this.A, a);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void a(I2.A value)
		{
			this.A = (I2.A)Delegate.Remove(this.A, value);
		}
		private h2 A(p1 p)
		{
			if (p != null)
			{
				foreach (h2 current in this.A)
				{
					if (current.E().B(p))
					{
						return current;
					}
				}
			}
			return null;
		}
		private o1 A()
		{
			for (TreeNode treeNode = this.A.SelectedNode; treeNode != null; treeNode = treeNode.Parent)
			{
				if (treeNode.Tag is o1)
				{
					return (o1)treeNode.Tag;
				}
			}
			return null;
		}
		private void B()
		{
			o1 o = this.A;
			this.A = this.A();
			if (this.A != o && this.A != null)
			{
				this.A(this.A);
			}
		}
		private p1 A(TreeNode treeNode, bool flag)
		{
			if (treeNode == null)
			{
				return null;
			}
			p1 p = treeNode.Tag as p1;
			if (p == null)
			{
				return null;
			}
			if (flag && this.A(treeNode.Parent, true) == null)
			{
				return null;
			}
			return p;
		}
		private h2 A(TreeNode treeNode, bool flag)
		{
			if (treeNode == null)
			{
				return null;
			}
			h2 h = treeNode.Tag as h2;
			if (h == null)
			{
				return null;
			}
			if (flag && treeNode.Parent != null)
			{
				return null;
			}
			return h;
		}
		private void A(TreeNode treeNode)
		{
			try
			{
				this.A.BeginUpdate();
				if (this.b != null)
				{
					this.b.Nodes.Clear();
				}
				if (treeNode != null)
				{
					p1 p = this.A(treeNode, true);
					h2 h = this.A();
					if (p != null && h != null)
					{
						this.A(h.E(), treeNode, null);
						this.b = treeNode;
						treeNode.Expand();
					}
				}
			}
			finally
			{
				this.A.EndUpdate();
			}
		}
		private void A(W1<p1> w, TreeNode treeNode, h<p1> h)
		{
			p1 p = this.A(treeNode, false);
			if (p == null)
			{
				return;
			}
			if (h == null)
			{
				h = new h<p1>();
			}
			h.Add(p);
			foreach (p1 current in w)
			{
				if (!h.Contains(current))
				{
					Q1 q = current as Q1;
					if (q != null && q.A(p.b()))
					{
						TreeNode treeNode2 = new J2<p1>(q);
						treeNode2.ImageIndex = this.A.ImageIndex + 8;
						treeNode2.SelectedImageIndex = this.A.SelectedImageIndex + 8;
						treeNode.Nodes.Add(treeNode2);
						this.A(w, treeNode2, h);
					}
				}
			}
		}
		private void A(TreeNode treeNode, int x, int y)
		{
			if (!this.a)
			{
				this.a = true;
				R.A().a(this.A.Items);
				Q.A().a(this.A.Items);
				q.A().a(this.A.Items);
				r.A().a(this.A.Items);
				s.A().a(this.A.Items);
				this.A.Opened += new EventHandler(P.F);
			}
			this.A.Tag = treeNode;
			this.a(treeNode);
			this.A.Show(this.A, x, y);
			this.A = true;
			this.A = this.A.SelectedNode;
			this.A.SelectedNode = treeNode;
		}
		private void a(TreeNode treeNode)
		{
			bool flag = treeNode.Nodes.Count > 0;
			this.A.Visible = (flag && !treeNode.IsExpanded);
			this.a.Visible = (flag && treeNode.IsExpanded);
			if (treeNode is J2<h2>)
			{
				h2 h = ((J2<h2>)treeNode).A();
				p1 p = (h == this.A()) ? this.A() : null;
				R.A().A(h);
				Q.A().A(h, true);
				q.A().A(h, p);
				r.A().d();
				s.A().d();
				return;
			}
			if (treeNode is J2<p1>)
			{
				p1 p2 = ((J2<p1>)treeNode).A();
				h2 h2 = q1.A().A(p2);
				R.A().d();
				Q.A().d();
				q.A().d();
				r.A().A(h2, p2);
				s.A().A(h2, p2);
			}
		}
		private void A(object obj, ToolStripDropDownClosedEventArgs toolStripDropDownClosedEventArgs)
		{
			this.A = false;
			this.A.SelectedNode = this.A;
		}
		private void A(object obj, EventArgs eventArgs)
		{
			((TreeNode)this.A.Tag).ExpandAll();
		}
		private void a(object obj, EventArgs eventArgs)
		{
			((TreeNode)this.A.Tag).Collapse();
		}
		private void A(object obj, TreeNodeMouseClickEventArgs treeNodeMouseClickEventArgs)
		{
			if (treeNodeMouseClickEventArgs.Button == MouseButtons.Right)
			{
				this.A(treeNodeMouseClickEventArgs.Node, treeNodeMouseClickEventArgs.X, treeNodeMouseClickEventArgs.Y);
			}
		}
		private void a(object obj, TreeNodeMouseClickEventArgs treeNodeMouseClickEventArgs)
		{
			if (treeNodeMouseClickEventArgs.Node.Nodes.Count == 0 && treeNodeMouseClickEventArgs.Button == MouseButtons.Left)
			{
				this.A(treeNodeMouseClickEventArgs.Node, treeNodeMouseClickEventArgs.X, treeNodeMouseClickEventArgs.Y);
			}
		}
		private void A(object obj, KeyEventArgs keyEventArgs)
		{
			if (this.A.Focused && keyEventArgs.KeyCode == Keys.Delete)
			{
				TreeNode selectedNode = this.A.SelectedNode;
				if (selectedNode == null)
				{
					return;
				}
				if (selectedNode.Tag is h2)
				{
					q1.A().b((h2)selectedNode.Tag);
				}
				if (selectedNode.Tag is p1)
				{
					h2 h = this.A();
					p1 p = this.A();
					r.A(h, p, false);
				}
			}
			this.A(keyEventArgs);
		}
		private void a(object obj, KeyEventArgs keyEventArgs)
		{
			this.A(keyEventArgs);
		}
		private void A(KeyEventArgs keyEventArgs)
		{
			if (this.A != null)
			{
				bool flag = (keyEventArgs.Modifiers & Keys.Control) == Keys.Control;
				if (this.b != flag)
				{
					this.b = flag;
					this.a(null, null);
				}
			}
		}
		private void A(object obj, TreeViewEventArgs treeViewEventArgs)
		{
			if (!this.A)
			{
				this.B();
				TreeNode selectedNode = this.A.SelectedNode;
				if (this.A(selectedNode, true) != null)
				{
					if (this.B)
					{
						this.B = selectedNode;
						return;
					}
					this.A(selectedNode);
				}
			}
		}
		private void A(object obj, NodeLabelEditEventArgs nodeLabelEditEventArgs)
		{
			if (nodeLabelEditEventArgs.Node == null)
			{
				return;
			}
			if (nodeLabelEditEventArgs.Node.Tag is h2)
			{
				nodeLabelEditEventArgs.CancelEdit = ((h2)nodeLabelEditEventArgs.Node.Tag).F();
				return;
			}
			if (nodeLabelEditEventArgs.Node.Tag is p1)
			{
				nodeLabelEditEventArgs.CancelEdit = ((p1)nodeLabelEditEventArgs.Node.Tag).J();
				return;
			}
			nodeLabelEditEventArgs.CancelEdit = false;
		}
		private void a(object obj, NodeLabelEditEventArgs nodeLabelEditEventArgs)
		{
			nodeLabelEditEventArgs.CancelEdit = true;
			if (nodeLabelEditEventArgs.Node == null)
			{
				return;
			}
			if (string.IsNullOrEmpty(nodeLabelEditEventArgs.Label))
			{
				return;
			}
			o1 o = (o1)nodeLabelEditEventArgs.Node.Tag;
			if (o == null)
			{
				return;
			}
			string text = o1.b(nodeLabelEditEventArgs.Label);
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			if (text == o.b())
			{
				return;
			}
			bool flag = false;
			q1 q = q1.A();
			if (o is h2)
			{
				R1 r = q.A((h2)o);
				flag = r.a(text);
			}
			else
			{
				if (o is p1)
				{
					p1 p = (p1)o;
					R1 r2 = q.A(q.A(p));
					flag = r2.a(p, text);
				}
			}
			if (!flag)
			{
				string text2 = "Der Name '" + text + "' ist unzulässig oder bereits vergeben";
				MessageBox.Show(this, text2, j1.a(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		private void A(object obj, MouseEventArgs mouseEventArgs)
		{
			this.B = true;
			TreeNode nodeAt = this.A.GetNodeAt(mouseEventArgs.Location);
			p1 p = this.A(nodeAt, true);
			if (p != null && !p.J())
			{
				if (p != this.A())
				{
					this.A(p);
				}
				this.A = this.A(p);
				this.A = p;
				this.b = false;
				this.a = null;
				this.a(obj, mouseEventArgs);
			}
		}
		private void a(object obj, MouseEventArgs mouseEventArgs)
		{
			if (this.A == null)
			{
				return;
			}
			if (mouseEventArgs != null)
			{
				this.a = this.A.GetNodeAt(mouseEventArgs.Location);
			}
			h2 h = this.A(this.a, true);
			if (h == null)
			{
				p1 p = this.A(this.a, true);
				h = this.A(p);
			}
			if (h == null || h.F())
			{
				this.Cursor = Cursors.No;
				return;
			}
			if (this.b || h != this.A)
			{
				this.Cursor = X.A().D();
				return;
			}
			this.Cursor = X.A().c();
		}
		private void B(object obj, MouseEventArgs mouseEventArgs)
		{
			this.a(null, null);
			try
			{
				if (this.A != null)
				{
					if (mouseEventArgs != null)
					{
						this.a = this.A.GetNodeAt(mouseEventArgs.Location);
					}
					h2 h = this.A(this.a, true);
					p1 p = this.A(this.a, true);
					if (h == null)
					{
						h = this.A(p);
					}
					if (h != null && !h.F() && p != this.A)
					{
						if (this.b || h != this.A)
						{
							r.A();
							byte[] array = null;
							if (r.A(this.A, this.A, ref array))
							{
								int num = h.E(p) + 1;
								R.A(h, array, num);
							}
						}
						else
						{
							int num2 = this.A.E(p) + 1;
							q1 q = q1.A();
							q.A(this.A).A(this.A, num2);
						}
					}
				}
			}
			finally
			{
				this.B(null, null);
				this.B = false;
				if (this.B != null)
				{
					this.A(this.B);
					this.B = null;
				}
			}
		}
		private void B(object obj, EventArgs eventArgs)
		{
			this.Cursor = Cursors.Default;
			this.A = null;
			this.A = null;
			this.b = false;
			this.a = null;
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
			this.A = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(I2));
			this.A = new TreeView();
			this.A = new ImageList(this.A);
			this.A = new ToolStripMenuItem();
			this.a = new ToolStripMenuItem();
			this.A = new ContextMenuStrip(this.A);
			this.A.SuspendLayout();
			base.SuspendLayout();
			this.A.Dock = DockStyle.Fill;
			this.A.HideSelection = false;
			this.A.HotTracking = true;
			this.A.ImageIndex = 0;
			this.A.ImageList = this.A;
			this.A.LabelEdit = true;
			this.A.Location = new Point(0, 0);
			this.A.Name = "treeView";
			this.A.SelectedImageIndex = 1;
			this.A.Size = new Size(208, 201);
			this.A.TabIndex = 0;
			this.A.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(this.a);
			this.A.AfterLabelEdit += new NodeLabelEditEventHandler(this.a);
			this.A.AfterSelect += new TreeViewEventHandler(this.A);
			this.A.MouseUp += new MouseEventHandler(this.B);
			this.A.MouseMove += new MouseEventHandler(this.a);
			this.A.MouseLeave += new EventHandler(this.B);
			this.A.NodeMouseClick += new TreeNodeMouseClickEventHandler(this.A);
			this.A.KeyUp += new KeyEventHandler(this.a);
			this.A.BeforeLabelEdit += new NodeLabelEditEventHandler(this.A);
			this.A.KeyDown += new KeyEventHandler(this.A);
			this.A.MouseDown += new MouseEventHandler(this.A);
			this.A.ImageStream = (ImageListStreamer)componentResourceManager.GetObject("imageList.ImageStream");
			this.A.TransparentColor = Color.Transparent;
			this.A.Images.SetKeyName(0, "PapDesigner.png");
			this.A.Images.SetKeyName(1, "PapDesigner.png");
			this.A.Images.SetKeyName(2, "Diagram.png");
			this.A.Images.SetKeyName(3, "Properties.png");
			this.A.Images.SetKeyName(4, "Help.png");
			this.A.Images.SetKeyName(5, "Help.png");
			this.A.Images.SetKeyName(6, "Lightning-off.png");
			this.A.Images.SetKeyName(7, "Lightning-on.png");
			this.A.Images.SetKeyName(8, "NavigatePrev.png");
			this.A.Images.SetKeyName(9, "NavigatePrev.png");
			this.A.Name = "cmiNodeExpand";
			this.A.Size = new Size(149, 22);
			this.A.Text = "Erweitern";
			this.A.Click += new EventHandler(this.A);
			this.a.Name = "cmiNodeCollapse";
			this.a.Size = new Size(149, 22);
			this.a.Text = "Reduzieren";
			this.a.Click += new EventHandler(this.a);
			this.A.Items.AddRange(new ToolStripItem[]
			{
				this.A,
				this.a
			});
			this.A.Name = "cmNode";
			this.A.Size = new Size(150, 48);
			this.A.Closed += new ToolStripDropDownClosedEventHandler(this.A);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.A);
			base.Name = "ProjectTreeView";
			base.Size = new Size(208, 201);
			this.A.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
	public class i2 : Form
	{
		private h2 A;
		private v1 A;
		private V A;
		private Color A = SystemColors.Window;
		private string A;
		private Control[] A;
		private IContainer A;
		private Button A;
		private Button a;
		private Label A;
		private TextBox A;
		private TextBox a;
		private Label a;
		private Label B;
		private Label b;
		private Label C;
		private Label c;
		private Label D;
		private Label d;
		private Label E;
		private CheckBox A;
		public i2(string text, h2 h, v1 v)
		{
			this.A();
			this.Font = d2.a().Font;
			this.A = h;
			this.A = v;
			this.A.MaxLength = 64;
			this.a.MaxLength = 64;
			this.A = this.A.BackColor;
			this.A = this.a.Text;
			this.A = new Control[]
			{
				this.A,
				this.a
			};
			if (!string.IsNullOrEmpty(text))
			{
				this.Text = text;
			}
			this.A.Text = h.b();
			this.a.Text = h.E();
			this.c.Text = h.f();
			this.D.Text = h.E().ToString("dd.MM.yy HH:mm");
			this.E.Text = h.e().ToString("dd.MM.yy HH:mm");
			this.A = h.E();
			this.A.Checked = V.B(this.A, null);
			this.A.Enabled = !h.e();
			this.A.Visible = !K1.A().A().SuppressProjectProtectionSwitch;
			if (h.E())
			{
				this.A.Text = "";
				if (string.IsNullOrEmpty(this.a.Text))
				{
					this.a.Text = K1.A().A().DefaultAuthorName;
				}
				this.A.Enabled = false;
			}
		}
		private void A(object obj, EventArgs eventArgs)
		{
			this.A(true);
		}
		private void a(object obj, EventArgs eventArgs)
		{
			this.A(false);
		}
		private void B(object obj, EventArgs eventArgs)
		{
			this.A(false);
		}
		private void b(object obj, EventArgs eventArgs)
		{
			this.A(false);
		}
		private void A(object obj, CancelEventArgs cancelEventArgs)
		{
			cancelEventArgs.Cancel = !this.A();
		}
		private void a(object obj, CancelEventArgs cancelEventArgs)
		{
			cancelEventArgs.Cancel = !this.a();
		}
		private void C(object obj, EventArgs eventArgs)
		{
			TextBox textBox = (TextBox)obj;
			textBox.Text = o1.b(textBox.Text);
		}
		private void c(object obj, EventArgs eventArgs)
		{
			if (this.A.Checked)
			{
				bool @checked = W.A(ref this.A);
				this.A.Checked = @checked;
			}
			else
			{
				if (W.A(this.A))
				{
					this.A = null;
				}
				this.A.Checked = V.B(this.A, null);
			}
			this.A(false);
		}
		private void D(object obj, EventArgs eventArgs)
		{
			if (this.A(true))
			{
				string text = o1.b(this.A.Text);
				string text2 = o1.b(this.a.Text);
				bool flag = false;
				if (this.A.b() != text)
				{
					this.A.b(text);
					flag = true;
				}
				if (this.A.E() != text2)
				{
					K1.A().A().DefaultAuthorName = text2;
					this.A.E(text2);
					flag = true;
				}
				if (V.B(this.A.E(), this.A))
				{
					this.A.E(V.B(this.A, null));
					this.A.E(this.A);
					flag = true;
				}
				base.DialogResult = (flag ? DialogResult.OK : DialogResult.Cancel);
			}
		}
		private bool A()
		{
			string text = o1.b(this.A.Text);
			bool flag = this.A.A(text) || text == this.A.b();
			this.A(this.A, !flag && this.A.Text.Trim().Length > 0);
			return flag;
		}
		private bool a()
		{
			bool flag = !string.IsNullOrEmpty(this.a.Text.Trim());
			this.A(this.a, !flag && this.a.Text.Trim().Length > 0);
			return flag;
		}
		private void A(Control control, bool flag)
		{
			Color color = this.A.Checked ? this.BackColor : this.A;
			control.BackColor = (flag ? k1.A : color);
		}
		private bool A(bool flag)
		{
			if (!this.ValidateChildren())
			{
				if (flag)
				{
					this.A[0].Focus();
					Control[] array = this.A;
					for (int i = 0; i < array.Length; i++)
					{
						Control control = array[i];
						TextBox textBox = control as TextBox;
						if (textBox != null && !textBox.ReadOnly && textBox.BackColor == k1.A)
						{
							textBox.Focus();
							textBox.SelectAll();
							break;
						}
					}
				}
				this.A.Checked = false;
				this.a.Text = this.A;
				this.A.Enabled = false;
				return false;
			}
			bool @checked = this.A.Checked;
			foreach (Control control2 in base.Controls)
			{
				TextBox textBox2 = control2 as TextBox;
				if (textBox2 != null)
				{
					textBox2.ReadOnly = @checked;
					textBox2.BackColor = (@checked ? this.BackColor : this.A);
				}
			}
			bool flag2 = !@checked || !this.A.F();
			this.a.Text = (flag2 ? this.A : "Schließen");
			this.A.Visible = flag2;
			this.A.Enabled = flag2;
			return flag2;
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(i2));
			this.A = new Button();
			this.a = new Button();
			this.A = new Label();
			this.A = new TextBox();
			this.a = new TextBox();
			this.a = new Label();
			this.B = new Label();
			this.b = new Label();
			this.C = new Label();
			this.c = new Label();
			this.D = new Label();
			this.d = new Label();
			this.E = new Label();
			this.A = new CheckBox();
			base.SuspendLayout();
			this.A.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.A.Location = new Point(164, 151);
			this.A.Name = "btnOk";
			this.A.Size = new Size(75, 23);
			this.A.TabIndex = 10;
			this.A.Text = "OK";
			this.A.UseVisualStyleBackColor = true;
			this.A.Click += new EventHandler(this.D);
			this.a.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.a.DialogResult = DialogResult.Cancel;
			this.a.Location = new Point(245, 151);
			this.a.Name = "btnCancel";
			this.a.Size = new Size(75, 23);
			this.a.TabIndex = 11;
			this.a.Text = "Abbrechen";
			this.a.UseVisualStyleBackColor = true;
			this.A.AutoSize = true;
			this.A.Location = new Point(12, 15);
			this.A.Name = "lbTitle";
			this.A.Size = new Size(27, 13);
			this.A.TabIndex = 0;
			this.A.Text = "Titel";
			this.A.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.A.Location = new Point(72, 12);
			this.A.Name = "tbTitle";
			this.A.Size = new Size(248, 20);
			this.A.TabIndex = 1;
			this.A.Leave += new EventHandler(this.C);
			this.A.Validating += new CancelEventHandler(this.A);
			this.A.TextChanged += new EventHandler(this.a);
			this.a.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.a.Location = new Point(72, 38);
			this.a.Name = "tbAuthor";
			this.a.Size = new Size(248, 20);
			this.a.TabIndex = 3;
			this.a.Leave += new EventHandler(this.C);
			this.a.Validating += new CancelEventHandler(this.a);
			this.a.TextChanged += new EventHandler(this.B);
			this.a.AutoSize = true;
			this.a.Location = new Point(12, 41);
			this.a.Name = "lbAuthor";
			this.a.Size = new Size(44, 13);
			this.a.TabIndex = 2;
			this.a.Text = "Ersteller";
			this.B.AutoSize = true;
			this.B.Location = new Point(12, 67);
			this.B.Name = "lbFileName";
			this.B.Size = new Size(32, 13);
			this.B.TabIndex = 4;
			this.B.Text = "Datei";
			this.b.AutoSize = true;
			this.b.Location = new Point(12, 93);
			this.b.Name = "lbDateCreated";
			this.b.Size = new Size(38, 13);
			this.b.TabIndex = 6;
			this.b.Text = "Erstellt";
			this.C.AutoSize = true;
			this.C.Location = new Point(12, 119);
			this.C.Name = "lbDateModified";
			this.C.Size = new Size(51, 13);
			this.C.TabIndex = 8;
			this.C.Text = "Geändert";
			this.c.AutoSize = true;
			this.c.Location = new Point(69, 67);
			this.c.Name = "lbFileNameValue";
			this.c.Size = new Size(36, 13);
			this.c.TabIndex = 12;
			this.c.Text = "<text>";
			this.D.AutoSize = true;
			this.D.Location = new Point(69, 93);
			this.D.Name = "lbDateCreatedValue";
			this.D.Size = new Size(36, 13);
			this.D.TabIndex = 12;
			this.D.Text = "<text>";
			this.d.AutoSize = true;
			this.d.Location = new Point(69, 119);
			this.d.Name = "label2";
			this.d.Size = new Size(36, 13);
			this.d.TabIndex = 12;
			this.d.Text = "<text>";
			this.E.AutoSize = true;
			this.E.Location = new Point(69, 119);
			this.E.Name = "lbDateModifiedValue";
			this.E.Size = new Size(36, 13);
			this.E.TabIndex = 12;
			this.E.Text = "<text>";
			this.A.AutoSize = true;
			this.A.Location = new Point(12, 157);
			this.A.Name = "cbProtectProject";
			this.A.Size = new Size(124, 17);
			this.A.TabIndex = 13;
			this.A.Text = "Dokument geschützt";
			this.A.UseVisualStyleBackColor = true;
			this.A.Click += new EventHandler(this.c);
			this.A.CheckedChanged += new EventHandler(this.b);
			base.AcceptButton = this.A;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.AutoValidate = AutoValidate.EnableAllowFocusChange;
			base.CancelButton = this.a;
			base.ClientSize = new Size(332, 186);
			base.Controls.Add(this.A);
			base.Controls.Add(this.E);
			base.Controls.Add(this.d);
			base.Controls.Add(this.D);
			base.Controls.Add(this.c);
			base.Controls.Add(this.C);
			base.Controls.Add(this.b);
			base.Controls.Add(this.B);
			base.Controls.Add(this.a);
			base.Controls.Add(this.a);
			base.Controls.Add(this.A);
			base.Controls.Add(this.A);
			base.Controls.Add(this.a);
			base.Controls.Add(this.A);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			this.MaximumSize = new Size(550, 240);
			base.MinimizeBox = false;
			this.MinimumSize = new Size(340, 220);
			base.Name = "ProjectPropertyDialog";
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterParent;
			this.Text = "Projekteigenschaften";
			base.Shown += new EventHandler(this.A);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
