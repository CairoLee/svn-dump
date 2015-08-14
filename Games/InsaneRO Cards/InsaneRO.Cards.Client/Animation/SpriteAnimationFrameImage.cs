using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace InsaneRO.Cards.Client {

	public class SpriteAnimationFrameImage : ICloneable {

		public Texture2D Texture;
		public Point Size = Point.Zero;
		public Point Position = Point.Zero;
		public Color Color = Color.White;
		public float Alpha = 1f;
		public float Rotation = 0f;
		public SpriteEffects Mirror = SpriteEffects.None;
		public float ScaleX = 1f;
		public float ScaleY = 1f;

		public int Width {
			get { return (int)( Size.X * ScaleX ); }
		}

		public int Height {
			get { return (int)( Size.Y * ScaleY ); }
		}

		public Rectangle Bounds {
			get { return new Rectangle( 0, 0, Width, Height ); }
		}


		public SpriteAnimationFrameImage() {
		}

		public SpriteAnimationFrameImage( Texture2D tex, Point size, Point pos, SpriteEffects mirror, Color col, float alpha, float rot ) {
			Texture = tex;
			Size = size;
			Position = pos;
			Mirror = mirror;
			Alpha = alpha;
			Rotation = rot;
			Color = col;
		}


		public object Clone() {
			SpriteAnimationFrameImage img = new SpriteAnimationFrameImage();
			img.Texture = Texture;
			img.Size = Size;
			img.Position = Position;
			img.Mirror = Mirror;
			img.Alpha = Alpha;
			img.Rotation = Rotation;
			img.Color = Color;
			return img;
		}

	}

}
