using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;

namespace XNATerrainPipeline {

	[ContentTypeWriter]

	public class HeightMapInfoWriter : ContentTypeWriter<HeightMapInfoContent> {

		public HeightMapInfoWriter() {
		}

		public override string GetRuntimeReader(TargetPlatform targetPlatform) {
			return "XNATerrainHeightmap.HeightMapInfoReader, XNATerrainHeightmap, Version=1.0.0.0, Culture=neutral";
		}

		public override string GetRuntimeType(TargetPlatform targetPlatform) {
			return "XNATerrainHeightmap.XNATerrain, XNATerrainHeightmap, Version=1.0.0.0, Culture=neutral";
		}

		protected override void Write(ContentWriter output, HeightMapInfoContent value) {
			output.WriteObject(value.Model);
			output.Write(value.TerrainScale);
			output.Write(value.Height.GetLength(0));
			output.Write(value.Height.GetLength(1));
			float[,] height = value.Height;
			int upperBound = height.GetUpperBound(0);
			int num = height.GetUpperBound(1);
			for (int i = height.GetLowerBound(0); i <= upperBound; i++) {
				for (int j = height.GetLowerBound(1); j <= num; j++) {
					float single = height[i, j];
					output.Write(single);
				}
			}
			Vector3[,] normals = value.Normals;
			int upperBound1 = normals.GetUpperBound(0);
			int num1 = normals.GetUpperBound(1);
			int lowerBound = normals.GetLowerBound(0);
			while (lowerBound <= upperBound1) {
				for (int k = normals.GetLowerBound(1); k <= num1; k++) {
					Vector3 vector3 = normals[lowerBound, k];
					output.Write(vector3);
				}
				lowerBound++;
			}
		}

	}

}