using System.Collections.Generic;
using System.IO;
using GodLesZ.Library.Formats;
using GodLesZ.Library.MonoGame.Extensions;
using Microsoft.Xna.Framework;

namespace GodLesZ.Library.Ragnarok.MonoGame.Format.Rsm {

	public class RoRsmMesh : GenericFileFormatData {

		public bool IsOnly {
			get;
			set;
		}

		public bool IsValid {
			get;
			protected set;
		}

		public RoRsmMeshHeader Head;
		public RoRsmMeshTransMatrix Matrix;

		public List<int> TextureIndexs = new List<int>();
		public List<Vector3> MainVectors = new List<Vector3>();
		public List<RoRsmMeshTextureVertex> TextureVectors = new List<RoRsmMeshTextureVertex>();
		public List<RoRsmMeshSurface> Surfaces = new List<RoRsmMeshSurface>();
		public List<RoRsmMeshRotationFrame> RotationFrames = new List<RoRsmMeshRotationFrame>();
		public List<RoRsmMeshPositionFrame> PositionFrames = new List<RoRsmMeshPositionFrame>();


		public RoRsmMesh(BinaryReader bin, GenericFileFormatVersion version)
			: base(bin, version) {
			int count;

			Head = new RoRsmMeshHeader(bin, version);

			count = bin.ReadInt32();
			if ((bin.BaseStream.Length - bin.BaseStream.Position) < (4 * count)) {
				IsValid = false;
				return;
			}
			for (int i = 0; i < count; i++) {
				TextureIndexs.Add(bin.ReadInt32());
			}

			Matrix = new RoRsmMeshTransMatrix(bin, version);

			count = bin.ReadInt32();
			if ((bin.BaseStream.Length - bin.BaseStream.Position) < (9 * count)) {
				IsValid = false;
				return;
			}
			for (int i = 0; i < count; i++) {
				MainVectors.Add(bin.ReadVector3());
			}

			count = bin.ReadInt32();
			for (int i = 0; i < count; i++) {
				TextureVectors.Add(new RoRsmMeshTextureVertex(bin, version));
			}


			count = bin.ReadInt32();
			for (int i = 0; i < count; i++) {
				Surfaces.Add(new RoRsmMeshSurface(bin, version));
			}

			if (version.IsCompatible(1, 5)) {
				count = bin.ReadInt32();
				for (int i = 0; i < count; i++) {
					PositionFrames.Add(new RoRsmMeshPositionFrame(bin, version));
				}
			}

			count = bin.ReadInt32();
			for (int i = 0; i < count; i++) {
				RotationFrames.Add(new RoRsmMeshRotationFrame(bin, version));
			}

			IsValid = true;
		}

	}

}
