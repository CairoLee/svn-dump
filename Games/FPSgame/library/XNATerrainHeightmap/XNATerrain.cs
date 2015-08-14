using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace XNATerrainHeightmap {

	public class XNATerrain {
		private readonly Vector3 mHeightmapPosition;
		private readonly Vector3[,] mNormals;

		public int Height {
			get;
			set;
		}

		public float HeightmapHeight {
			get;
			set;
		}

		public float HeightmapWidth {
			get;
			set;
		}

		public float[,] Heights {
			get;
			set;
		}

		public Model Model {
			get;
			set;
		}

		public Vector3 Position {
			get;
			set;
		}

		public Vector3 Rotation {
			get;
			set;
		}

		public float TerrainScale {
			get;
			set;
		}

		public int Width {
			get;
			set;
		}

		public Matrix World {
			get { return Matrix.CreateRotationX(Rotation.X) * Matrix.CreateRotationY(Rotation.Y) * Matrix.CreateRotationZ(Rotation.Z) * Matrix.CreateTranslation(Position); }
		}


		public XNATerrain(float[,] heights, Vector3[,] normals, float terrainScale, Model model) {
			if (heights == null) {
				throw new ArgumentNullException("heights");
			}
			if (normals == null) {
				throw new ArgumentNullException("normals");
			}

			Model = model;
			TerrainScale = terrainScale;
			Heights = heights;
			mNormals = normals;
			HeightmapWidth = (heights.GetLength(0) - 1) * terrainScale;
			HeightmapHeight = (heights.GetLength(1) - 1) * terrainScale;
			Width = heights.GetLength(0);
			Height = heights.GetLength(1);
			mHeightmapPosition.X = (-(heights.GetLength(0) - 1)) / 2f * terrainScale;
			mHeightmapPosition.Z = (-(heights.GetLength(1) - 1)) / 2f * terrainScale;
		}

		public void Draw(Matrix view, Matrix projection) {
			Matrix[] matrixArray = new Matrix[Model.Bones.Count];
			Model.CopyAbsoluteBoneTransformsTo(matrixArray);

			foreach (ModelMesh mesh in Model.Meshes) {
				var enumerator = mesh.Effects.GetEnumerator();
				try {
					while (enumerator.MoveNext()) {
						BasicEffect basicEffect = (BasicEffect)enumerator.Current;
						basicEffect.World = matrixArray[mesh.ParentBone.Index];
						basicEffect.View = view;
						basicEffect.Projection = projection;
						basicEffect.EnableDefaultLighting();
						basicEffect.PreferPerPixelLighting = true;
						basicEffect.FogEnabled = true;
						basicEffect.FogColor = Vector3.Zero;
						basicEffect.FogStart = 1000f;
						basicEffect.FogEnd = 3200f;
					}
				} finally {
					enumerator.Dispose();
				}
				mesh.Draw();
			}
		}

		public void GetHeightAndNormal(Vector3 position, out float height, out Vector3 normal) {
			Vector3 vector3 = position - mHeightmapPosition;
			int x = (int)vector3.X / (int)TerrainScale;
			int z = (int)vector3.Z / (int)TerrainScale;
			float single = vector3.X % TerrainScale / TerrainScale;
			float z1 = vector3.Z % TerrainScale / TerrainScale;
			float single1 = MathHelper.Lerp(Heights[x, z], Heights[x + 1, z], single);
			float single2 = MathHelper.Lerp(Heights[x, z + 1], Heights[x + 1, z + 1], single);
			height = MathHelper.Lerp(single1, single2, z1);
			Vector3 vector31 = Vector3.Lerp(mNormals[x, z], mNormals[x + 1, z], single);
			Vector3 vector32 = Vector3.Lerp(mNormals[x, z + 1], mNormals[x + 1, z + 1], single);
			normal = Vector3.Lerp(vector31, vector32, z1);
			normal.Normalize();
		}

		public bool IsOnHeightmap(Vector3 position) {
			Vector3 vector3 = position - mHeightmapPosition;
			if (vector3.X <= 0f || vector3.X >= HeightmapWidth || vector3.Z <= 0f) {
				return false;
			}

			return vector3.Z < HeightmapHeight;
		}

		public Vector3 Pick(GraphicsDevice device, Matrix view, Matrix projection) {
			MouseState state = Mouse.GetState();
			Viewport viewport = device.Viewport;
			Viewport viewport1 = device.Viewport;
			Vector3 vector3 = viewport.Unproject(new Vector3(state.X, state.Y, viewport1.MinDepth), projection, view, World);
			Viewport viewport2 = device.Viewport;
			Viewport viewport3 = device.Viewport;
			Vector3 vector31 = viewport2.Unproject(new Vector3(state.X, state.Y, viewport3.MaxDepth), projection, view, World);
			Vector3 vector32 = vector31 - vector3;
			float y = 0f / vector32.Y;
			Vector3 vector33 = vector3 + vector32 * y;
			Ray ray = new Ray(vector33, vector32);
			double num = 0;
			bool flag = true;
			for (int i = 0; i < Width; i++) {
				for (int j = 0; j < Height; j++) {
					Vector3 terrainScale = new Vector3();
					terrainScale.X = TerrainScale * (i - (Width - 1) / 2f);
					terrainScale.Y = Heights[i, j] - 1f;
					terrainScale.Z = TerrainScale * (j - (Height - 1) / 2f);
					BoundingBox boundingBox = BoundingBox.CreateFromSphere(new BoundingSphere(terrainScale, TerrainScale));
					float? nullable = ray.Intersects(boundingBox);
					if (nullable.HasValue) {
						double num1 = (double)(Math.Abs(terrainScale.X - vector33.X) + Math.Abs(terrainScale.Y - vector33.Y) + Math.Abs(terrainScale.Z - vector33.Z));
						if (flag || num1 < num) {
							flag = false;
							return terrainScale + Position;
						}
					}
				}
			}
			return Vector3.Zero;
		}
	}
}