using A;
using c;
using C;
using d;
using D;
using PapDesigner.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace a
{
	public class X
	{
		private static X A;
		private ComponentResourceManager A;
		private Cursor A;
		private Cursor a;
		private Cursor B;
		private Cursor b;
		private Cursor C;
		private Cursor c;
		private Cursor D;
		private Dictionary<Type, Cursor> A;
		private Dictionary<Type, Cursor> a;
		private X()
		{
			this.A = new ComponentResourceManager(typeof(global::A.A));
		}
		public static X A()
		{
			if (X.A == null)
			{
				X.A = new X();
			}
			return X.A;
		}
		public Cursor A()
		{
			if (this.A == null)
			{
				this.A = new Cursor(new MemoryStream((byte[])this.A.GetObject("Hand")));
			}
			return this.A;
		}
		public Cursor a()
		{
			if (this.a == null)
			{
				this.a = new Cursor(new MemoryStream((byte[])this.A.GetObject("Clipboard")));
			}
			return this.a;
		}
		public Cursor B()
		{
			if (this.B == null)
			{
				this.B = new Cursor(new MemoryStream((byte[])this.A.GetObject("CatchRect")));
			}
			return this.B;
		}
		public Cursor b()
		{
			if (this.b == null)
			{
				this.b = new Cursor(new MemoryStream((byte[])this.A.GetObject("Replicate")));
			}
			return this.b;
		}
		public Cursor C()
		{
			if (this.C == null)
			{
				this.C = new Cursor(new MemoryStream((byte[])this.A.GetObject("Move")));
			}
			return this.C;
		}
		public Cursor c()
		{
			if (this.c == null)
			{
				this.c = new Cursor(new MemoryStream((byte[])this.A.GetObject("MoveNS")));
			}
			return this.c;
		}
		public Cursor D()
		{
			if (this.D == null)
			{
				this.D = new Cursor(new MemoryStream((byte[])this.A.GetObject("MoveNSAdd")));
			}
			return this.D;
		}
		public Cursor A(Type key)
		{
			if (this.A == null)
			{
				this.A = new Dictionary<Type, Cursor>();
				this.A.Add(typeof(d.b), new Cursor(new MemoryStream((byte[])this.A.GetObject("AddActivity"))));
				this.A.Add(typeof(d.A), new Cursor(new MemoryStream((byte[])this.A.GetObject("AddComment"))));
				this.A.Add(typeof(global::c.c), new Cursor(new MemoryStream((byte[])this.A.GetObject("AddCondition"))));
				this.A.Add(typeof(global::c.B), new Cursor(new MemoryStream((byte[])this.A.GetObject("AddConnector"))));
				this.A.Add(typeof(D.b), new Cursor(new MemoryStream((byte[])this.A.GetObject("AddInput"))));
				this.A.Add(typeof(d.c), new Cursor(new MemoryStream((byte[])this.A.GetObject("AddInteraction"))));
				this.A.Add(typeof(global::C.b), new Cursor(new MemoryStream((byte[])this.A.GetObject("AddLoop"))));
				this.A.Add(typeof(d.B), new Cursor(new MemoryStream((byte[])this.A.GetObject("AddModule"))));
				this.A.Add(typeof(global::C.c), new Cursor(new MemoryStream((byte[])this.A.GetObject("AddOutput"))));
			}
			Cursor no = Cursors.No;
			this.A.TryGetValue(key, out no);
			return no;
		}
		public Cursor a(Type key)
		{
			if (this.a == null)
			{
				this.a = new Dictionary<Type, Cursor>();
				this.a.Add(typeof(d.b), new Cursor(new MemoryStream((byte[])this.A.GetObject("ChangeToActivity"))));
				this.a.Add(typeof(D.b), new Cursor(new MemoryStream((byte[])this.A.GetObject("ChangeToInput"))));
				this.a.Add(typeof(d.B), new Cursor(new MemoryStream((byte[])this.A.GetObject("ChangeToModule"))));
				this.a.Add(typeof(global::C.c), new Cursor(new MemoryStream((byte[])this.A.GetObject("ChangeToOutput"))));
			}
			Cursor no = Cursors.No;
			this.a.TryGetValue(key, out no);
			return no;
		}
	}
	public class x
	{
		private static ComponentResourceManager A = new ComponentResourceManager(typeof(Icons));
		private static ComponentResourceManager a = new ComponentResourceManager(typeof(global::A.a));
		private List<ToolStripItem> A = new List<ToolStripItem>();
		private string A;
		private string a;
		private string B;
		private Image A;
		private EventHandler A;
		private Keys A;
		private object A;
		private bool A = true;
		private bool a = true;
		public x(string text, string text2, string text3, EventHandler eventHandler)
		{
			this.a = text;
			this.A(text);
			this.a(text2);
			this.A(null);
			this.A = eventHandler;
			this.A(x.A(text3));
		}
		public string A()
		{
			return this.a;
		}
		public string a()
		{
			return this.A;
		}
		public void A(string text)
		{
			this.A = text;
			foreach (ToolStripItem current in this.A)
			{
				current.Text = this.A;
			}
		}
		public string B()
		{
			return this.B;
		}
		public void a(string b)
		{
			this.B = b;
			foreach (ToolStripItem current in this.A)
			{
				current.ToolTipText = this.B;
			}
		}
		public Image A()
		{
			return this.A;
		}
		public void A(Image image)
		{
			this.A = image;
			foreach (ToolStripItem current in this.A)
			{
				current.Image = this.A;
			}
		}
		public EventHandler A()
		{
			return this.A;
		}
		public void A(EventHandler eventHandler)
		{
			if (this.A != null)
			{
				foreach (ToolStripItem current in this.A)
				{
					current.Click -= this.A;
				}
			}
			this.A = eventHandler;
			if (this.A != null)
			{
				foreach (ToolStripItem current2 in this.A)
				{
					current2.Click += this.A;
				}
			}
		}
		public Keys A()
		{
			return this.A;
		}
		public void A(Keys keys)
		{
			this.A = keys;
			foreach (ToolStripItem current in this.A)
			{
				ToolStripMenuItem toolStripMenuItem = current as ToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.ShortcutKeys = this.A;
					toolStripMenuItem.ShowShortcutKeys = true;
				}
			}
		}
		public object A()
		{
			return this.A;
		}
		public void A(object obj)
		{
			this.A = obj;
		}
		public bool A()
		{
			return this.A;
		}
		public void A(bool flag)
		{
			this.A = flag;
			foreach (ToolStripItem current in this.A)
			{
				current.Enabled = this.A;
			}
		}
		public bool a()
		{
			return this.a;
		}
		public void a(bool flag)
		{
			this.a = flag;
			foreach (ToolStripItem current in this.A)
			{
				current.Visible = this.a;
			}
		}
		public static void A(ToolStripMenuItem toolStripMenuItem)
		{
			string text = " - An";
			string text2 = " - Aus";
			string text3 = toolStripMenuItem.Text.Replace(text, "").Replace(text2, "");
			text3 += (toolStripMenuItem.Checked ? text2 : text);
			toolStripMenuItem.Text = text3;
		}
		public static Image A(string text)
		{
			Image image = null;
			if (text != null)
			{
				if (image == null)
				{
					image = (Image)x.A.GetObject(text);
				}
				if (image == null)
				{
					image = (Image)x.a.GetObject(text);
				}
			}
			return image;
		}
		public ToolStripMenuItem A(ToolStripItemCollection toolStripItemCollection)
		{
			ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
			toolStripMenuItem.TextAlign = ContentAlignment.MiddleLeft;
			toolStripMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
			toolStripMenuItem.Text = this.A;
			toolStripMenuItem.ToolTipText = this.B;
			toolStripMenuItem.Image = this.A;
			toolStripMenuItem.Click += this.A;
			toolStripMenuItem.ShortcutKeys = this.A;
			toolStripMenuItem.Visible = this.a;
			toolStripMenuItem.Enabled = this.A;
			toolStripMenuItem.Tag = this;
			toolStripItemCollection.Add(toolStripMenuItem);
			this.A.Add(toolStripMenuItem);
			return toolStripMenuItem;
		}
		public void A(params object[] args)
		{
			this.A(string.Format(this.A(), args));
		}
		public override string ToString()
		{
			return this.a();
		}
	}
}
