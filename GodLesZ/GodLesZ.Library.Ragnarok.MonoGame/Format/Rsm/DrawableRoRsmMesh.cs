using System;
using System.Collections.Generic;
using System.IO;
using GodLesZ.Library.Formats;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GodLesZ.Library.Ragnarok.MonoGame.Format.Rsm {

	/// <summary>
	/// Represents a drawable mesh from a <see cref="DrawableRoRsm"/> model.
	/// </summary>
	public class DrawableRoRsmMesh : RoRsmMesh {
		private VertexBuffer mVertexBuffer;
		//private VertexDeclaration mVertexDeclaration;
		private List<VertexPositionColor> mVerticesList = new List<VertexPositionColor>();

		public List<VertexPositionColor> VerticesList {
			get { return mVerticesList; }
		}

		public DrawableRoRsmMesh(BinaryReader bin, GenericFileFormatVersion version)
			: base(bin, version) {
		}


		/// <summary>
		/// Initialize the vertice list and creates the vertex buffer.
		/// </summary>
		/// <param name="Device"></param>
		public void SetUpVertices(GraphicsDevice Device) {
			if (MainVectors == null || MainVectors.Count == 0) {
				throw new Exception("No main vector defined. Invalid model?");
			}

			for (int i = 0; i < MainVectors.Count; i++) {
				Vector3 v = MainVectors[i];
				mVerticesList.Add(new VertexPositionColor(new Vector3(v.X, v.Z, v.Y), Color.White));
				mVerticesList.Add(new VertexPositionColor(new Vector3(v.X, v.Z, v.Y), Color.White));
				mVerticesList.Add(new VertexPositionColor(new Vector3(v.X, v.Z, v.Y), Color.White));
			}

			mVertexBuffer = new VertexBuffer(Device, typeof(VertexPositionColor), mVerticesList.Count, BufferUsage.None);
			mVertexBuffer.SetData<VertexPositionColor>(mVerticesList.ToArray());
			//mVertexDeclaration = new VertexDeclaration(Device, VertexPositionColorTexture.VertexElements);
		}

		/// <summary>
		/// Draws the vertice list on the given surface.
		/// </summary>
		/// <param name="device"></param>
		/// <param name="effect"></param>
		/// <param name="matrixView"></param>
		/// <param name="matrixProjection"></param>
		/// <param name="matrixWorld"></param>
		public void Draw(GraphicsDevice device, BasicEffect effect, Matrix matrixView, Matrix matrixProjection, Matrix matrixWorld) {
			effect.CurrentTechnique.Passes[0].Apply();

			effect.Projection = matrixProjection;
			effect.World = matrixWorld;
			effect.View = matrixView;

			//Device.VertexDeclaration = mVertexDeclaration;
			//Device.Vertices[0].SetSource(mVertexBuffer, 0, VertexPositionColorTexture.SizeInBytes);
			device.SetVertexBuffer(mVertexBuffer);
			device.DrawPrimitives(PrimitiveType.TriangleList, 0, mVerticesList.Count);
		}

	}

}
