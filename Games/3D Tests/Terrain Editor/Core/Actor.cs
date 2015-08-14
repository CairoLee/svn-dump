using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ragnarok3D.Editor {
	public class Actor {
		public Vector3 position = Vector3.Zero;
		public Vector3 rotation = Vector3.Zero;

		public Model model;
		public Texture2D texture;
		public Effect effect;
		public Matrix world;

		public float drawScale = 1f;

		public bool bVisible = true;
		public bool bEnabled = true;

		public Actor() {
		}

		public virtual void Update() {
		}

		public virtual void Draw( Matrix view, Matrix projection ) {
		}
	}
}
