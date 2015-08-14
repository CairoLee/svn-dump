using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace a
{
	public class P
	{
		private static List<P> A = new List<P>();
		private List<x> A = new List<x>();
		public P()
		{
			P.A.Add(this);
		}
		public virtual x A(string text, string text2, string text3, EventHandler eventHandler)
		{
			x x = new x(text, text2, text3, eventHandler);
			this.A.Add(x);
			return x;
		}
		public virtual void a(ToolStripItemCollection toolStripItemCollection)
		{
			toolStripItemCollection.Add(new ToolStripSeparator());
			foreach (x current in this.A)
			{
				if (current.a() == "-")
				{
					toolStripItemCollection.Add(new ToolStripSeparator());
				}
				else
				{
					current.A(toolStripItemCollection);
				}
			}
		}
		public virtual void B(bool flag)
		{
			foreach (x current in this.A)
			{
				current.a(flag);
			}
		}
		public virtual void b()
		{
			foreach (x current in this.A)
			{
				current.a(current.A());
			}
		}
		public virtual void C(bool flag)
		{
			foreach (x current in this.A)
			{
				current.A(flag);
			}
		}
		public virtual void c(bool flag, bool flag2)
		{
			foreach (x current in this.A)
			{
				current.A(flag2);
				current.a(flag);
			}
		}
		public virtual void D()
		{
			this.c(true, true);
		}
		public virtual void d()
		{
			this.c(false, false);
		}
		public virtual void E(params object[] array)
		{
			foreach (x current in this.A)
			{
				current.A(array);
			}
		}
		public static void F(Dictionary<Keys, int> dictionary)
		{
			foreach (P current in P.A)
			{
				foreach (x current2 in current.A)
				{
					if (current2.A() != Keys.None)
					{
						if (dictionary.ContainsKey(current2.A()))
						{
							Keys key;
							dictionary[key = current2.A()] = dictionary[key] + 1;
						}
						else
						{
							dictionary[current2.A()] = 1;
						}
					}
				}
			}
		}
		public virtual bool e(Keys keys)
		{
			foreach (x current in this.A)
			{
				if (current.a() && current.A() && current.A() != Keys.None && keys == current.A())
				{
					current.A()(null, null);
					return true;
				}
			}
			return false;
		}
		public static void F(ToolStripItemCollection toolStripItemCollection)
		{
			ToolStripItem toolStripItem = null;
			bool flag = true;
			foreach (ToolStripItem toolStripItem2 in toolStripItemCollection)
			{
				if (toolStripItem2 is ToolStripMenuItem && toolStripItem2.Visible)
				{
					flag = false;
				}
				else
				{
					if (toolStripItem2 is ToolStripSeparator)
					{
						toolStripItem2.Visible = !flag;
						flag = true;
					}
				}
				if (toolStripItem2.Visible)
				{
					toolStripItem = toolStripItem2;
				}
			}
			if (toolStripItem is ToolStripSeparator)
			{
				toolStripItem.Visible = false;
			}
		}
		public static void F(object obj, EventArgs eventArgs)
		{
			ToolStripItemCollection toolStripItemCollection = null;
			ToolStripDropDownItem toolStripDropDownItem = obj as ToolStripDropDownItem;
			if (toolStripDropDownItem != null)
			{
				toolStripItemCollection = toolStripDropDownItem.DropDownItems;
			}
			else
			{
				ToolStripDropDownMenu toolStripDropDownMenu = obj as ToolStripDropDownMenu;
				if (toolStripDropDownMenu != null)
				{
					toolStripItemCollection = toolStripDropDownMenu.Items;
				}
			}
			if (toolStripItemCollection != null)
			{
				P.F(toolStripItemCollection);
			}
		}
	}
	public class p : P
	{
		private new static p A;
		private new q1 A = q1.A();
		private new x A;
		private new x a;
		private new x B;
		private p()
		{
			this.A = this.A("Neues Projekt erstellen...", null, "ProjectNew", new EventHandler(this.A));
			this.A.A((Keys)131150);
			this.a = this.A("Projektdatei öffnen...", null, "ProjectOpen", new EventHandler(this.a));
			this.a.A((Keys)131151);
			this.B = this.A("Zuletzt geöffnet", null, null, null);
		}
		public static p A()
		{
			if (p.A == null)
			{
				p.A = new p();
			}
			return p.A;
		}
		public void A(ToolStripItemCollection toolStripItemCollection)
		{
			ToolStripMenuItem toolStripMenuItem = null;
			foreach (ToolStripItem toolStripItem in toolStripItemCollection)
			{
				ToolStripMenuItem toolStripMenuItem2 = toolStripItem as ToolStripMenuItem;
				if (toolStripMenuItem2 != null && toolStripMenuItem2.Tag == this.B)
				{
					toolStripMenuItem = toolStripMenuItem2;
					break;
				}
			}
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.DropDownItems.Clear();
				string[] array = K1.A().A();
				for (int i = 0; i < array.Length; i++)
				{
					string text = array[i];
					toolStripMenuItem.DropDownItems.Add(text, null, new EventHandler(this.B));
				}
			}
			this.D();
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Enabled = toolStripMenuItem.HasDropDownItems;
			}
		}
		private void A(object obj, EventArgs eventArgs)
		{
			string text = obj.ToString().Split(new char[]
			{
				'.'
			})[0];
			this.A.A(true, text);
		}
		private void a(object obj, EventArgs eventArgs)
		{
			this.A.A().Update();
			this.A.A();
		}
		private void B(object obj, EventArgs eventArgs)
		{
			using (new C())
			{
				this.A.A().Update();
				string text = obj.ToString();
				this.A.A(new string[]
				{
					text
				}, false, false);
			}
		}
	}
}
