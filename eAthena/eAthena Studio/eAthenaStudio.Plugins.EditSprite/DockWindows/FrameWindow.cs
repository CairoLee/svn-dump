using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GodLesZ.Library.Docking;
using eAthenaStudio.Plugins.EditSprite.Controls;

namespace eAthenaStudio.Plugins.EditSprite {

	public partial class FrameWindow : DockContent {

		/// <summary>
		/// Gets or sets the <see cref="Bitmap"/> image from the <see cref="ZoomableSpriteFrame"/> control
		/// </summary>
		public Bitmap SpriteImage {
			get { return imageSprite.SpriteFrame; }
			set { imageSprite.SpriteFrame = value; }
		}

		public Controls.ZoomableSpriteFrame SpriteControl {
			get { return imageSprite; }
		}

		public float Zoom {
			get { return imageSprite.Zoom; }
			set { imageSprite.Zoom = value; }
		}

		public int PaddingLeft {
			get { return imageSprite.PaddingLeft; }
			set { imageSprite.PaddingLeft = value; }
		}

		public int PaddingBottom {
			get { return imageSprite.PaddingBottom; }
			set { imageSprite.PaddingBottom = value; }
		}

		public Color HoverColor {
			get { return imageSprite.HoverColor; }
			set { imageSprite.HoverColor = value; }
		}

		public Color SelectedColor {
			get { return imageSprite.SelectedColor; }
			set {
				imageSprite.SelectedColor = value;
				Invalidate();
			}
		}


		public FrameWindow() {
			InitializeComponent();
		}


		public void OnMouseScroll(MouseEventArgs e) {
			Zoom += (float)e.Delta / 1000f;
		}

		public void DoResize() {
			imageSprite.DoResize();
		}


		public void SetStatusZoom(string ZoomInfo) {
			lblStatusZoom.Text = ZoomInfo;
		}

		public void SetStatusFrameCount(string FrameInfo) {
			lblStatusFrames.Text = FrameInfo;
		}

		public void SetStatusFrameSize(string FrameInfo) {
			lblStatusSize.Text = FrameInfo;
		}

	}

}
