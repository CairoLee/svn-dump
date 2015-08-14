using System.IO;
using GodLesZ.Library.Formats;
using GodLesZ.Library.MonoGame.Extensions;
using Microsoft.Xna.Framework;

namespace GodLesZ.Library.Ragnarok.MonoGame.Format.Rsm {

	public class RoRsmMeshTransMatrix : GenericFileFormatData {

		/// <summary>
		/// 48 bytes (12x float)
		/// </summary>
		public Matrix Matrix {
			get;
			set;
		}

		/// <summary>
		/// 12 bytes (3x float)
		/// </summary>
		public Vector3 Position {
			get;
			set;
		}

		/// <summary>
		/// 4 bytes
		/// </summary>
		public float RotationAngle {
			get;
			set;
		}

		/// <summary>
		/// 12 bytes (3x float)
		/// </summary>
		public Vector3 RotationAxis {
			get;
			set;
		}

		/// <summary>
		/// 12 bytes (3x float)
		/// </summary>
		public Vector3 Scale {
			get;
			set;
		}


		public RoRsmMeshTransMatrix(BinaryReader bin, GenericFileFormatVersion version)
			: base(bin, version) {
			Matrix = bin.ReadMatrix();
			Position = bin.ReadVector3();
			RotationAngle = bin.ReadSingle();
			RotationAxis = bin.ReadVector3();
			Scale = bin.ReadVector3();
		}

	}

}
