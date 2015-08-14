using System;
using Microsoft.Xna.Framework;
using System.Xml.Serialization;

namespace FinalSoftware.Games.Defender.Library.Map {

	[Serializable()]
	public class Crossroad {
		private Random mRand = new Random();
		private Rectangle mArea;
		private CrossroadList mConnections;
		private int mTier;

		public CrossroadList Connections {
			get { return mConnections; }
			set { mConnections = value; }
		}

		[XmlAttribute(AttributeName = "Tier")]
		public int Tier {
			get { return mTier; }
			set { mTier = value; }
		}

		[XmlIgnore()]
		public Vector2 Position {
			get { return new Vector2(mArea.X, mArea.Y); }
			set {
				mArea.X = (int)value.X;
				mArea.Y = (int)value.Y;
			}
		}

		public Rectangle Area {
			get { return mArea; }
			set { mArea = value; }
		}

		public int X {
			get { return mArea.X; }
		}

		public int Y {
			get { return mArea.Y; }
		}

		public int Right {
			get { return mArea.Right; }
		}

		public int Bottom {
			get { return mArea.Bottom; }
		}

		public Crossroad RandomConnection {
			get {
				if (Connections.Count == 0)
					return null;
				return (Connections[mRand.Next(Connections.Count)]);
			}
		}


		public Crossroad() {
			mArea = Rectangle.Empty;
			mConnections = new CrossroadList();
			mTier = 0;
		}

		public Crossroad(Rectangle area, CrossroadList connections, int tier)
			: this() {
			mArea = area;
			mConnections.AddRange(connections);
			mTier = tier;
		}

		public Crossroad(Point pos, CrossroadList connections, int tier)
			: this(new Rectangle(pos.X, pos.Y, DefenderWorld.TileSize, DefenderWorld.TileSize), connections, tier) {
		}

		public Crossroad(Point pos)
			: this(new Rectangle(pos.X, pos.Y, DefenderWorld.TileSize, DefenderWorld.TileSize), new CrossroadList(), 1) {
		}

		public Crossroad(int x, int y)
			: this(new Rectangle(x, y, DefenderWorld.TileSize, DefenderWorld.TileSize), new CrossroadList(), 1) {
		}

	}

}
