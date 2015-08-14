using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using System;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using System.IO;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;

namespace XNATerrainPipeline {

	[ContentProcessor(DisplayName = "Model - XNA Terrain")]
	public class TerrainProcessor : ContentProcessor<Texture2DContent, HeightMapInfoContent> {
		private readonly float mScale;

		[Description("Controls the height of the terrain."), DefaultValue(40f)]
		public float Bumpiness {
			get;
			set;
		}

		[Description("Controls the texture that will be applied to the terrain. If no value is supplied, a texture will not be applied."), DefaultValue("rocks.bmp"), DisplayName("Terrain Texture")]
		public string TerrainTexture {
			get;
			set;
		}

		[DefaultValue(0.1f), Description("Controls how often the texture will be repeated across the terrain.")]
		public float TexCoordScale {
			get;
			set;
		}


		public TerrainProcessor() {
			mScale = 1f;
			Bumpiness = 40f;
			TexCoordScale = 0.1f;
			TerrainTexture = "ground.jpg";
		}

		private void AddVertex(MeshBuilder builder, int texCoordId, int w, int x, int y) {
			builder.SetVertexChannelData(texCoordId, new Vector2(x, y) * TexCoordScale);
			builder.AddTriangleVertex(x + y * w);
		}

		public override HeightMapInfoContent Process(Texture2DContent input, ContentProcessorContext context) {
			MeshBuilder meshBuilder = MeshBuilder.StartMesh("terrain");
			input.ConvertBitmapType(typeof(PixelBitmapContent<float>));
			PixelBitmapContent<float> item = (PixelBitmapContent<float>)input.Mipmaps[0];
			for (int i = 0; i < item.Height; i++) {
				for (int j = 0; j < item.Width; j++) {
					Vector3 width = new Vector3(
						mScale * (j - (item.Width - 1) / 2f),
						width.Y = (item.GetPixel(j, i) - 1f) * Bumpiness,
						width.Z = mScale * (i - (item.Height - 1) / 2f)
					);
					meshBuilder.CreatePosition(width);
				}
			}
			BasicMaterialContent basicMaterialContent = new BasicMaterialContent();
			basicMaterialContent.SpecularColor = new Vector3(0.4f, 0.4f, 0.4f);
			if (!string.IsNullOrEmpty(TerrainTexture)) {
				string directoryName = Path.GetDirectoryName(input.Identity.SourceFilename);
				string str = Path.Combine(directoryName, TerrainTexture);
				basicMaterialContent.Texture = new ExternalReference<TextureContent>(str);
			}
			meshBuilder.SetMaterial(basicMaterialContent);
			int num = meshBuilder.CreateVertexChannel<Vector2>(VertexChannelNames.TextureCoordinate(0));
			int num1 = 0;
			while (num1 < item.Height - 1) {
				for (int k = 0; k < item.Width - 1; k++) {
					AddVertex(meshBuilder, num, item.Width, k, num1);
					AddVertex(meshBuilder, num, item.Width, k + 1, num1);
					AddVertex(meshBuilder, num, item.Width, k + 1, num1 + 1);
					AddVertex(meshBuilder, num, item.Width, k, num1);
					AddVertex(meshBuilder, num, item.Width, k + 1, num1 + 1);
					AddVertex(meshBuilder, num, item.Width, k, num1 + 1);
				}
				num1++;
			}
			MeshContent meshContent = meshBuilder.FinishMesh();
			ModelContent modelContent = context.Convert<MeshContent, ModelContent>(meshContent, "ModelProcessor");
			return new HeightMapInfoContent(modelContent, meshContent, mScale, item.Width, item.Height);
		}
	}
}