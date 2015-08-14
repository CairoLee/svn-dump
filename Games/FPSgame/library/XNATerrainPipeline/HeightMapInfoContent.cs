using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;

namespace XNATerrainPipeline {

	public class HeightMapInfoContent {
		[ContentSerializer(ElementName = "Model")]
		public ModelContent Model;

		public float[,] Height {
			get;
			private set;
		}

		public Vector3[,] Normals {
			get;
			set;
		}

		public float TerrainScale {
			get;
			private set;
		}

		[ContentSerializer(ElementName = "Vertex")]
		public VertexContent Vertex {
			get;
			set;
		}


		public HeightMapInfoContent(ModelContent model, MeshContent terrainMesh, float terrainScale, int terrainWidth, int terrainLength) {
			Model = model;
			if (terrainMesh == null) {
				throw new ArgumentNullException("terrainMesh");
			}

			if (terrainWidth <= 0) {
				throw new ArgumentOutOfRangeException("terrainWidth");
			}
			if (terrainLength <= 0) {
				throw new ArgumentOutOfRangeException("terrainLength");
			}

			TerrainScale = terrainScale;
			Height = new float[terrainWidth, terrainLength];
			Normals = new Vector3[terrainWidth, terrainLength];
			GeometryContent item = terrainMesh.Geometry[0];
			for (int i = 0; i < item.Vertices.VertexCount; i++) {
				Vector3 vector3 = item.Vertices.Positions[i];
				Vector3 item1 = (Vector3)item.Vertices.Channels[VertexChannelNames.Normal()][i];
				int x = (int)(vector3.X / terrainScale + (terrainWidth - 1) / 2f);
				int z = (int)(vector3.Z / terrainScale + (terrainLength - 1) / 2f);
				Height[x, z] = vector3.Y;
				Normals[x, z] = item1;
			}
		}

	}

}