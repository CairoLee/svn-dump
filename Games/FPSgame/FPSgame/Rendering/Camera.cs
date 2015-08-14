using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace FPSgame
{
    public class Camera
    {
        public Matrix World;
        public Matrix View;
        public Matrix Projection;
        public Vector3 Position;
        public Vector3 Lookat;
        public float AspectRatio;
        public float NearPlane;
        public float FarPlane;
        public Vector2 ScreenSize;

       
        public Camera(Vector3 position,Vector2 screensize)
        {
            ScreenSize = screensize;
            this.Position = position;
            this.Lookat = Vector3.Zero;
            AspectRatio = ScreenSize.X / ScreenSize.Y;
            NearPlane = 0.0001f;
            FarPlane = 1000f;
            InitCamera();
        }

        public Camera(Vector3 position, Vector3 lookat, Vector2 screensize)
        {
            ScreenSize = screensize;
            this.Position = position;
            this.Lookat = lookat;
            AspectRatio = ScreenSize.X / ScreenSize.Y;
            NearPlane = 0.0001f;
            FarPlane = 1000f;
            InitCamera();
        }

        private void InitCamera()
        {
            this.View = Matrix.CreateLookAt(Position, Lookat, Vector3.Up);
            this.Projection = Matrix.CreatePerspectiveFieldOfView((float)Math.PI / 3, AspectRatio, NearPlane, FarPlane);
            this.World = Matrix.Identity;
        }
    }
}
