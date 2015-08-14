// Distributed as part of TiledSharp, Copyright 2012 Marshall Ward
// Licensed under the Apache License, Version 2.0
// http://www.apache.org/licenses/LICENSE-2.0

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using GodLesZ.Library.Xna.Geometry;
using Microsoft.Xna.Framework;

namespace FreeWorld.Game.Tests.Tmx {

	public class TmxObjectGroup : ITmxElement {

		public string Name {
			get;
			private set;
		}

		public uint? Color {
			get;
			private set;
		}

		public double Opacity {
			get;
			private set;
		}

		public bool Visible {
			get;
			private set;
		}

		public TmxList<TmxObject> Objects {
			get;
			private set;
		}

		public PropertyDict Properties {
			get;
			private set;
		}


		public TmxObjectGroup(XElement xObjectGroup) {
			Name = (string)xObjectGroup.Attribute("name");

			var xColor = (string)xObjectGroup.Attribute("color");
			if (xColor != null) {
				xColor = xColor.TrimStart("#".ToCharArray());
				Color = UInt32.Parse(xColor, NumberStyles.HexNumber);
			}

			var xOpacity = xObjectGroup.Attribute("opacity");
			Opacity = xOpacity == null ? 1.0 : (double)xOpacity;

			var xVisible = xObjectGroup.Attribute("visible");
			Visible = xVisible == null || (bool)xVisible;

			Objects = new TmxList<TmxObject>();
			foreach (var e in xObjectGroup.Elements("object")) {
				Objects.Add(new TmxObject(e));
			}

			Properties = new PropertyDict(xObjectGroup.Element("properties"));
		}


		public List<TmxObject> GetObjectsByPosition(Point2D pos) {
			var objects = new List<TmxObject>();
			if (Objects.Count == 0) {
				return objects;
			}

			objects.AddRange(Objects.Where(tmxObject => tmxObject.Bounds.Contains(pos)));
			return objects;
		}

	}

}
