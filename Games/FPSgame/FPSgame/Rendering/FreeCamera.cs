using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace FPSgame {

	public class FreeCamera : Camera {
	
		public Vector3 Angle;
		public float Speed;
		public float TurnSpeed;


		public FreeCamera(Vector3 position, Vector2 screensize)
			: base(position, screensize) {
			Speed = 250f;
			TurnSpeed = 90f;

		}

		public FreeCamera(Vector3 position, float speed, float turnSpeed, Vector2 screensize)
			: base(position, screensize) {
			Speed = speed;
			TurnSpeed = turnSpeed;
		}


		public void Update(float totalSeconds) {
			int center = (int)ScreenSize.X / 2;
			float delta = totalSeconds;

			KeyboardState keyboard = Keyboard.GetState();
			MouseState mouse = Mouse.GetState();
			int centerX = center;
			int centerY = center;

			Mouse.SetPosition(centerX, centerY);
			Angle.X += MathHelper.ToRadians((mouse.Y - centerY) * TurnSpeed * 0.01f);
			Angle.Y += MathHelper.ToRadians((mouse.X - centerX) * TurnSpeed * 0.01f);
			Vector3 forward = Vector3.Normalize(new Vector3((float)Math.Sin(-Angle.Y), (float)Math.Sin(Angle.X), (float)Math.Cos(-Angle.Y)));
			Vector3 left = Vector3.Normalize(new Vector3((float)Math.Cos(Angle.Y), 0f, (float)Math.Sin(Angle.Y)));

			if (keyboard.IsKeyDown(Keys.W)) {
				Position -= forward * Speed;
			}
			if (keyboard.IsKeyDown(Keys.S)) {
				Position += forward * Speed;
			}
			if (keyboard.IsKeyDown(Keys.A)) {
				Position -= left * Speed;
			}
			if (keyboard.IsKeyDown(Keys.D)) {
				Position += left * Speed;
			}

			View = Matrix.Identity;
			View *= Matrix.CreateTranslation(-Position);
			View *= Matrix.CreateRotationZ(Angle.Z);
			View *= Matrix.CreateRotationY(Angle.Y);
			View *= Matrix.CreateRotationX(Angle.X);
		}

	}

}
