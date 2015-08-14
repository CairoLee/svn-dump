using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	public class SkinLayer : SkinBase {
		public SkinImage Image = new SkinImage();
		public int Width;
		public int Height;
		public int OffsetX;
		public int OffsetY;
		public EAlignment Alignment;
		public Margins SizingMargins;
		public Margins ContentMargins;
		public SkinStates<LayerStates> States;
		public SkinStates<LayerOverlays> Overlays;
		public SkinText Text = new SkinText();
		public SkinList<SkinAttribute> Attributes = new SkinList<SkinAttribute>();

		public SkinLayer()
			: base() {
			States.Enabled.Color = Color.White;
			States.Pressed.Color = Color.White;
			States.Focused.Color = Color.White;
			States.Hovered.Color = Color.White;
			States.Disabled.Color = Color.White;

			Overlays.Enabled.Color = Color.White;
			Overlays.Pressed.Color = Color.White;
			Overlays.Focused.Color = Color.White;
			Overlays.Hovered.Color = Color.White;
			Overlays.Disabled.Color = Color.White;
		}

		public SkinLayer(SkinLayer source)
			: base(source) {
			if (source != null) {
				this.Image = new SkinImage(source.Image);
				this.Width = source.Width;
				this.Height = source.Height;
				this.OffsetX = source.OffsetX;
				this.OffsetY = source.OffsetY;
				this.Alignment = source.Alignment;
				this.SizingMargins = source.SizingMargins;
				this.ContentMargins = source.ContentMargins;
				this.States = source.States;
				this.Overlays = source.Overlays;
				this.Text = new SkinText(source.Text);
				this.Attributes = new SkinList<SkinAttribute>(source.Attributes);
			} else {
				throw new Exception("Parameter for SkinLayer copy constructor cannot be null.");
			}
		}

	}

}
