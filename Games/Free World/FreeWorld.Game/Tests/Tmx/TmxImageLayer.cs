// Distributed as part of TiledSharp, Copyright 2012 Marshall Ward
// Licensed under the Apache License, Version 2.0
// http://www.apache.org/licenses/LICENSE-2.0

using System.Xml.Linq;

namespace FreeWorld.Game.Tests.Tmx {

	public class TmxImageLayer : TmxLayer {

		public TmxImage Image {
			get;
			protected set;
		}


		public TmxImageLayer(TmxMap map, XElement xImageLayer, string tmxDir = "")
			: base(map) {
			Name = (string)xImageLayer.Attribute("name");
			Width = (int)xImageLayer.Attribute("width");
			Height = (int)xImageLayer.Attribute("height");

			var xVisible = xImageLayer.Attribute("visible");
			Visible = xVisible == null || (bool)xVisible;

			var xOpacity = xImageLayer.Attribute("opacity");
			Opacity = xOpacity == null ? 1.0 : (double)xOpacity;

			Image = new TmxImage(xImageLayer.Element("image"), tmxDir);

			Properties = new PropertyDict(xImageLayer.Element("properties"));
		}


		/// <summary>
		/// Gibt einen <see cref="T:System.String"/> zurück, der das aktuelle <see cref="T:System.Object"/> darstellt.
		/// </summary>
		/// <returns>
		/// Ein <see cref="T:System.String"/>, der das aktuelle <see cref="T:System.Object"/> darstellt.
		/// </returns>
		public override string ToString() {
			return string.Format("{0} ({1} x {2}), visible {3}, opacity {4}", Name, Width, Height, Visible, Opacity);
		}

	}

}
