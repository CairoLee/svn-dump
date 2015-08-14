using System;
using System.Xml.Serialization;
using GodLesZ.Library.Xna.Geometry;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FreeWorld.Engine.TileEngine.Animation {

	[Serializable]
	public class TileAnimationFrameImage : ICloneable {

		public TileCellSource TextureSource;
		public Point2D Offset;
		public Color Color;

		[XmlAttribute]
		public float Scale = 1f;
		[XmlAttribute]
		public float Rotation;
		[XmlAttribute]
		public SpriteEffects Mirror;
		[XmlAttribute]
		public bool IsBackground;

		[XmlIgnore]
		public int Width {
			get { return TextureSource.Width; }
		}

		[XmlIgnore]
		public float WidthScaled {
			get { return Width * Scale; }
		}

		[XmlIgnore]
		public int Height {
			get { return TextureSource.Height; }
		}

		[XmlIgnore]
		public float HeightScaled {
			get { return Height * Scale; }
		}

		[XmlIgnore]
		public Rectangle Bounds {
			get { return new Rectangle(Offset.X, Offset.Y, Width, Height); }
		}

		[XmlIgnore]
		public Rectangle BoundsScaled {
			get { return new Rectangle(Offset.X, Offset.Y, (int)WidthScaled, (int)HeightScaled); }
		}

		[XmlIgnore]
		public Point2D TextureCenter {
			get { return new Point2D((int)(WidthScaled / 2f), (int)(HeightScaled / 2f)); }
		}

		[XmlIgnore]
		public string TextureIndex {
			get { return TextureSource.TextureIndex; }
		}

		[XmlIgnore]
		public bool IsForeground {
			get { return IsBackground == false; }
		}


		public TileAnimationFrameImage()
			: this(TileCellSource.Empty, 1f, Point2D.Zero, SpriteEffects.None, Color.White, 0, false) {
		}

		public TileAnimationFrameImage(TileCellSource source, float scale, Point2D pos, SpriteEffects mirror, Color col, float rot, bool isBg) {
			TextureSource = source;
			Scale = scale;
			Offset = new Point2D(pos.X, pos.Y);
			Mirror = mirror;
			Rotation = rot;
			Color = col;
			IsBackground = isBg;
		}


		public virtual void LoadContent(ContentManager content) {
			TextureSource.LoadContent(content);
		}


		public void Draw(SpriteBatch spriteBatch) {
			Draw(spriteBatch, Point2D.Zero);
		}

		public void Draw(SpriteBatch spriteBatch, Point2D basePos) {
			var srcRect = GetSourceRectangle();
			var destRect = GetDestinationRectangle(basePos);
			var imageOrigin = Vector2.Zero;
			var tex = EngineCore.ContentLoader.GetAnimationTileset(TextureIndex);

			if (Rotation.Equals(0) == false) {
				imageOrigin = new Vector2(destRect.X / 2f, destRect.Y / 2f);
			}
			spriteBatch.Draw(tex, destRect, srcRect, Color, Rotation, imageOrigin, Mirror, 0f);
		}


		public Rectangle GetSourceRectangle() {
			return TextureSource.ToRectangle();
		}

		public Rectangle GetDestinationRectangle(Point2D basePos) {
			//var dest = BoundsScaled + basePos;
			var bounds = BoundsScaled;
			var center = TextureCenter;
			var dest = new Rectangle(bounds.X + basePos.X - center.X, bounds.Y + basePos.Y - center.Y, bounds.Width, bounds.Height);
			return dest;
		}


		public object Clone() {
			var img = new TileAnimationFrameImage {
				TextureSource = TextureSource,
				Scale = Scale,
				Offset = Offset,
				Mirror = Mirror,
				Rotation = Rotation,
				Color = Color,
				IsBackground = IsBackground
			};
			return img;
		}

	}

}
