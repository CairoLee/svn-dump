using System.IO;
using Microsoft.Xna.Framework;

namespace GodLesZ.Library.MonoGame.Extensions {

	public static class StreamExtensions {

		public static Vector2 ReadVector2(BinaryReader bin) {
			if ((bin.BaseStream.Length - bin.BaseStream.Position) < 6) {
				return Vector2.Zero;
			}

			Vector2 vec = new Vector2(
				bin.ReadSingle(),
				bin.ReadSingle()
			);

			return vec;
		}

		public static Vector3 ReadVector3(this BinaryReader bin) {
			if ((bin.BaseStream.Length - bin.BaseStream.Position) < 9) {
				return Vector3.Zero;
			}

			Vector3 vec = new Vector3(
				bin.ReadSingle(),
				bin.ReadSingle(),
				bin.ReadSingle()
			);

			return vec;
		}

		public static Vector4 ReadVector4(this BinaryReader bin) {
			if ((bin.BaseStream.Length - bin.BaseStream.Position) < 12) {
				return Vector4.Zero;
			}

			Vector4 vec = new Vector4(
				bin.ReadSingle(),
				bin.ReadSingle(),
				bin.ReadSingle(),
				bin.ReadSingle()
			);

			return vec;
		}

		public static Matrix ReadMatrix(this BinaryReader bin) {
			return bin.ReadMatrix(false);
		}

		public static Matrix ReadMatrix(this BinaryReader bin, bool readFull) {
			if ((bin.BaseStream.Length - bin.BaseStream.Position) < 4 * 12) {
				return Matrix.Identity;
			}

			float m11 = bin.ReadSingle();
			float m12 = bin.ReadSingle();
			float m13 = bin.ReadSingle();
			float m14 = (readFull ? bin.ReadSingle() : 0);
			float m21 = bin.ReadSingle();
			float m22 = bin.ReadSingle();
			float m23 = bin.ReadSingle();
			float m24 = (readFull ? bin.ReadSingle() : 0);
			float m31 = bin.ReadSingle();
			float m32 = bin.ReadSingle();
			float m33 = bin.ReadSingle();
			float m34 = (readFull ? bin.ReadSingle() : 0);
			float m41 = bin.ReadSingle();
			float m42 = bin.ReadSingle();
			float m43 = bin.ReadSingle();
			float m44 = (readFull ? bin.ReadSingle() : 0);

			Matrix m = new Matrix(m11, m12, m13, m14, m21, m22, m23, m24, m31, m32, m33, m34, m41, m42, m43, m44);

			return m;
		}

	}

}
