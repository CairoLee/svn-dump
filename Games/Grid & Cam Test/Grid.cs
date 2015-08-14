using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cam_Test {
	class Grid {
		private VertexBuffer vertexBuffer;
		private IndexBuffer indexBuffer;
		private VertexDeclaration vertexDeclaration;

		private VertexPositionColor[] vertices;
		private short[] indices;

		private Point size;
		private Vector2 cellSize;
		private Color color;

		private Vector3 position = Vector3.Zero;
		private Vector3 rotation = Vector3.Zero;
		private Vector3 center = Vector3.Zero;

		private Matrix world;
		private Matrix rotationMatrix;
		private float drawScale;

		private BasicEffect effect;

		public Grid(Vector2 fSize, int seperations, Color gridColor, float scale, Vector3 pos, Vector3 rot) {

			effect = new BasicEffect(CamTest.graphics.GraphicsDevice);
			effect.VertexColorEnabled = true;

			cellSize = new Vector2(fSize.X / seperations, fSize.Y / seperations);
			size = new Point((int)(fSize.X / cellSize.X), (int)(fSize.Y / cellSize.Y));
			center = new Vector3(size.X * cellSize.X * .5f, 0f, size.Y * cellSize.Y * .5f);

			position = pos;
			rotation = rot;
			color = gridColor;
			drawScale = scale;

			SetupVertices();
			SetupIndices();

			Update();
		}

		private void SetupVertices() {
			vertices = new VertexPositionColor[size.X * size.Y + 2];
			vertexDeclaration = new VertexDeclaration(vertices);
			vertexBuffer = new VertexBuffer(CamTest.graphics.GraphicsDevice, typeof(VertexPositionColor), vertices.Length, BufferUsage.None);

			int vertID = 0;

			for (int x = 0; x < size.X + 1; x++) {
				vertices[vertID].Position = new Vector3(x * cellSize.X, 0f, 0f);
				vertices[vertID].Color = color;
				vertices[vertID + 1].Position = new Vector3(x * cellSize.X, 0f, size.Y * cellSize.Y);
				vertices[vertID + 1].Color = color;
				vertID += 2;
			}

			for (int y = 0; y < size.Y + 1; y++) {
				vertices[vertID].Position = new Vector3(0f, 0f, y * cellSize.Y);
				vertices[vertID].Color = color;
				vertices[vertID + 1].Position = new Vector3(size.X * cellSize.X, 0f, y * cellSize.Y);
				vertices[vertID + 1].Color = color;
				vertID += 2;
			}

			vertexBuffer.SetData<VertexPositionColor>(vertices);
		}

		private void SetupIndices() {
			indices = new short[size.X * size.Y + 2];

			for (int i = 0; i < vertices.Length; i += 2) {
				indices[i] = (short)(i);
				indices[i + 1] = (short)(i + 1);
			}

			indexBuffer = new IndexBuffer(CamTest.graphics.GraphicsDevice, sizeof(short) * indices.Length, BufferUsage.None, IndexElementSize.SixteenBits);
			indexBuffer.SetData<short>(indices);
		}

		public void Update() {
			rotationMatrix = Matrix.CreateRotationX(rotation.X) * Matrix.CreateRotationY(rotation.Y) * Matrix.CreateRotationZ(rotation.Z);
			world = Matrix.CreateScale(drawScale) * Matrix.CreateTranslation(position - center * drawScale) * rotationMatrix;
		}

		public void Draw(Matrix view, Matrix projection) {
			CamTest.graphics.GraphicsDevice.RenderState.CullMode = CullMode.CullClockwiseFace;

			effect.Begin();

			effect.World = world;
			effect.View = view;
			effect.Projection = projection;

			effect.CommitChanges();

			foreach (EffectPass pass in effect.CurrentTechnique.Passes) {
				pass.Begin();

				CamTest.graphics.GraphicsDevice.Indices = indexBuffer;
				CamTest.graphics.GraphicsDevice.VertexDeclaration = vertexDeclaration;
				CamTest.graphics.GraphicsDevice.Vertices[0].SetSource(vertexBuffer, 0, VertexPositionColor.SizeInBytes);
				CamTest.graphics.GraphicsDevice.DrawIndexedPrimitives(PrimitiveType.LineList, 0, 0, vertices.Length, 0, vertices.Length / 2);

				pass.End();
			}

			effect.End();
		}
	}
}
