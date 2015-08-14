using System;
using System.Collections.Generic;
using System.Xml.Linq;
using GodLesZ.Library.Xna.Geometry;

namespace FreeWorld.Game.Tests.Tmx {

	/// <summary>
	/// Many TmxObjectTypes are distinguished by null values in fields.
	/// It might be smart to subclass TmxObject
	/// </summary>
	public class TmxObject : ITmxElement {

		public string Name {
			get;
			private set;
		}

		public ETmxObjectType ObjectType {
			get;
			private set;
		}

		public string Type {
			get;
			private set;
		}

		public int X {
			get;
			private set;
		}

		public int Y {
			get;
			private set;
		}

		public Point2D Position {
			get { return new Point2D(X, Y); }
		}

		public bool Visible {
			get;
			private set;
		}

		public int? Width {
			get;
			private set;
		}

		public int? Height {
			get;
			private set;
		}

		public Rectangle2D Bounds {
			get {
				if (Width.HasValue == false || Height.HasValue == false) {
					throw new Exception("Unable to calculate bounds without width and height");
				}
				return new Rectangle2D(X, Y, Width.Value, Height.Value);
			}
		}

		public int? Gid {
			get;
			private set;
		}

		public List<Tuple<int, int>> Points {
			get;
			private set;
		}

		public PropertyDict Properties {
			get;
			private set;
		}


		public TmxObject(XElement xObject) {
			var xName = xObject.Attribute("name");
			Name = xName == null ? "" : (string)xName;

			Type = (string)xObject.Attribute("type");
			X = (int)xObject.Attribute("x");
			Y = (int)xObject.Attribute("y");

			var xVisible = xObject.Attribute("visible");
			Visible = xVisible == null || (bool)xVisible;

			Width = (int?)xObject.Attribute("width");
			Height = (int?)xObject.Attribute("height");

			// Assess object type and assign appropriate content
			var xGid = xObject.Attribute("gid");
			var xEllipse = xObject.Element("ellipse");
			var xPolygon = xObject.Element("polygon");
			var xPolyline = xObject.Element("polyline");

			if (xGid != null) {
				Gid = (int?)xGid;
				ObjectType = ETmxObjectType.Tile;
			} else if (xEllipse != null) {
				ObjectType = ETmxObjectType.Ellipse;
			} else if (xPolygon != null) {
				Points = ParsePoints(xPolygon);
				ObjectType = ETmxObjectType.Polygon;
			} else if (xPolyline != null) {
				Points = ParsePoints(xPolyline);
				ObjectType = ETmxObjectType.Polyline;
			} else {
				ObjectType = ETmxObjectType.Basic;
			}

			Properties = new PropertyDict(xObject.Element("properties"));
		}


		public List<Tuple<int, int>> ParsePoints(XElement xPoints) {
			var points = new List<Tuple<int, int>>();

			var pointString = (string)xPoints.Attribute("points");
			var pointStringPair = pointString.Split(' ');
			foreach (var s in pointStringPair) {
				var pt = s.Split(',');
				var x = int.Parse(pt[0]);
				var y = int.Parse(pt[1]);
				points.Add(Tuple.Create(x, y));
			}

			return points;
		}

	}

}