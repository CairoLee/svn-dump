using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GodLesZ.Library.Ragnarok.MonoGame.Format.Rsm {

	/// <summary>
	/// Represetns a drawable <see cref=" RoRsmFile"/> model.
	/// </summary>
	public class DrawableRoRsm : RoRsmFile {
		private GraphicsDevice mDevice;
		private VertexBuffer mVertexBuffer;
		//private VertexDeclaration mVertexDeclaration;
		private List<VertexPositionColor> mVerticesList = new List<VertexPositionColor>();


		public DrawableRoRsm(string filename, GraphicsDevice device)
			: base() {
			mDevice = device;

			Read(filename);
		}

		public DrawableRoRsm(Stream stream, GraphicsDevice device)
			: base() {
			mDevice = device;

			Read(stream);
		}


		/// <summary>
		/// Draws all meshes in this model @ once.
		/// </summary>
		/// <param name="device"></param>
		/// <param name="effect"></param>
		/// <param name="matrixView"></param>
		/// <param name="matrixProjection"></param>
		/// <param name="matixWorld"></param>
		public void DrawAll(GraphicsDevice device, BasicEffect effect, Matrix matrixView, Matrix matrixProjection, Matrix matixWorld) {
			if (mVerticesList.Count == 0) {
				// Catch VerticeList from all Meshes
				for (int i = 0; i < Meshes.Count; i++) {
					mVerticesList.AddRange((Meshes[i] as DrawableRoRsmMesh).VerticesList);
				}

				mVertexBuffer = new VertexBuffer(device, typeof(VertexPositionColor), mVerticesList.Count, BufferUsage.None);
				mVertexBuffer.SetData<VertexPositionColor>(mVerticesList.ToArray());
				//mVertexDeclaration = new VertexDeclaration(device, VertexPositionColorTexture.VertexElements);
			}

			effect.CurrentTechnique.Passes[0].Apply();
			effect.Projection = matrixProjection;
			effect.World = matixWorld;
			effect.View = matrixView;

			//Device.VertexDeclaration = mVertexDeclaration;
			//Device.Vertices[ 0 ].SetSource( mVertexBuffer, 0, VertexPositionColorTexture.SizeInBytes );
			device.SetVertexBuffer(mVertexBuffer);
			device.DrawPrimitives(PrimitiveType.TriangleList, 0, mVerticesList.Count);
		}

		/// <summary>
		/// Draws each mesh in this model in its own call
		/// </summary>
		/// <param name="device"></param>
		/// <param name="effect"></param>
		/// <param name="matrixView"></param>
		/// <param name="matrixProjection"></param>
		/// <param name="matrixWorld"></param>
		public void DrawSingle(GraphicsDevice device, BasicEffect effect, Matrix matrixView, Matrix matrixProjection, Matrix matrixWorld) {
			for (int i = 0; i < Meshes.Count; i++) {
				(Meshes[i] as DrawableRoRsmMesh).Draw(device, effect, matrixView, matrixProjection, matrixWorld);
			}
		}


		protected override void ReadMesh() {
			// Override internal mesh read method to fill the mesh list
			// with drawable meshes
			DrawableRoRsmMesh m = new DrawableRoRsmMesh(Reader, Version);
			if (m.IsValid == true) {
				m.SetUpVertices(mDevice);
				Meshes.Add(m);
			} else {
				// TODO: debug in valid meshes
			}
		}

	}

}
