using System;
using System.Collections.Generic;
using System.Text;
using GodLesZ.Library.XNA.WindowLibrary.Controls;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Threading;

namespace GodLesZ.Library.XNA.WindowLibrary.Central {
	public class TaskAutoScroll : Window {

		private Panel pnl1;
		private Panel pnl2;


		public TaskAutoScroll(Manager manager)
			: base(manager) {
			Height = 360;
			MinimumHeight = 99;
			MinimumWidth = 78;
			Text = "Auto Scrolling";
			Center();

			pnl1 = new Panel(manager);
			pnl1.Init();
			pnl1.Parent = this;
			pnl1.Width = 400;
			pnl1.Height = 180;
			pnl1.Left = 20;
			pnl1.Top = 20;
			pnl1.BevelBorder = EBevelBorder.All;
			pnl1.BevelStyle = EBevelStyle.Flat;
			pnl1.BevelMargin = 1;
			pnl1.Anchor = EAnchors.Left | EAnchors.Top | EAnchors.Right;
			pnl1.AutoScroll = true;

			pnl2 = new Panel(manager);
			pnl2.Init();
			pnl2.Parent = this;
			pnl2.Width = 400;
			pnl2.Height = 320;
			pnl2.Left = 40;
			pnl2.Top = 80;
			pnl2.BevelBorder = EBevelBorder.All;
			pnl2.BevelStyle = EBevelStyle.Flat;
			pnl2.BevelMargin = 1;
			pnl2.Text = "2";
			pnl2.Anchor = EAnchors.Left | EAnchors.Top;
			pnl2.Color = Color.White;
		}

		public override void Init() {
			base.Init();
		}

	}
}
