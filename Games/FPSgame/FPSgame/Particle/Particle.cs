using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FPSgame {

	public struct Particle {
		public Vector3 Position;
		public Vector2 Position2D;
		public Vector2 Scale2D;
		public Vector2 Scale2DUp;
		public Vector2 Scale2DUp2;
		public Vector3 Scale;
		public Vector3 Rotation;
		public float Rotation2D;
		public float Rotation2DUp;
		public float Rotation2DUp2;
		public Matrix World;
		public float Alpha;
		public float AlphaUp1;
		public float AlphaUp2;
		public Texture2D Texture;
		public Texture2D Norm;
		public Model Model;
		public Vector3 BaseColor;
		public Vector3 BaseColorUp1;
		public Vector3 BaseColorUp2;
		public int NumEffect;

		public Vector3 PowerUp1;
		public Vector3 ScaleUp1;
		public Vector3 RotationUp1;

		public Vector3 PowerUp2;
		public Vector3 ScaleUp2;
		public Vector3 RotationUp2;
		public SpriteFont Font;
		public Color Color;
		public string Text;

		public bool AdditiveRender;
		public float LifeTime;
		public bool Active;
		public int Technic;
		public int[] ParticleNodes;

		public void Reset() {
			Position = Vector3.Zero;
			Position2D = Vector2.Zero;
			Scale2D = Vector2.Zero;
			Scale = Vector3.Zero;
			Rotation2D = 0;
			Rotation2DUp = 0;
			Rotation = Vector3.Zero;
			World = Matrix.Identity;
			Alpha = 0;
			AlphaUp1 = 0;
			AlphaUp2 = 0;
			BaseColor = Vector3.Zero;
			BaseColorUp1 = Vector3.Zero;
			BaseColorUp2 = Vector3.Zero;
			PowerUp1 = Vector3.Zero;
			ScaleUp1 = Vector3.Zero;
			RotationUp1 = Vector3.Zero;
			PowerUp2 = Vector3.Zero;
			ScaleUp2 = Vector3.Zero;
			RotationUp2 = Vector3.Zero;
			Text = "";
			LifeTime = 0;
			AdditiveRender = false;
			Technic = 1;
			Active = false;
		}

	}

}
