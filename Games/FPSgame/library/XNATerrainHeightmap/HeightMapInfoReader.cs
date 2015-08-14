using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework;

namespace XNATerrainHeightmap {

	public class HeightMapInfoReader : ContentTypeReader<XNATerrain> {

		public HeightMapInfoReader() {
		}


		protected override XNATerrain Read(ContentReader input, XNATerrain existingInstance) {
			Model model = input.ReadObject<Model>();
			float single = input.ReadSingle();
			int num = input.ReadInt32();
			int num1 = input.ReadInt32();

			float[,] singleArray = new float[num, num1];
			Vector3[,] vector3Array = new Vector3[num, num1];
			for (int i = 0; i < num; i++) {
				for (int j = 0; j < num1; j++) {
					singleArray[i, j] = input.ReadSingle();
				}
			}
			int num2 = 0;
			while (num2 < num) {
				for (int k = 0; k < num1; k++) {
					vector3Array[num2, k] = input.ReadVector3();
				}
				num2++;
			}
			return new XNATerrain(singleArray, vector3Array, single, model);
		}

	}

}