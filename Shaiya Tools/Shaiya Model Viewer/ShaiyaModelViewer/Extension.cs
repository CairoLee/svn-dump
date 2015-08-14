using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.IO;

namespace Shaiya_Model_Viewer.Library {

	public static class Extension {

		public static Matrix ReadMatrix( this BinaryReader bin ) {
			Matrix m = new Matrix( bin.ReadSingle(), bin.ReadSingle(), bin.ReadSingle(), bin.ReadSingle(), bin.ReadSingle(), bin.ReadSingle(), bin.ReadSingle(), bin.ReadSingle(), bin.ReadSingle(), bin.ReadSingle(), bin.ReadSingle(), bin.ReadSingle(), bin.ReadSingle(), bin.ReadSingle(), bin.ReadSingle(), bin.ReadSingle() );
			return m;
		}


		public static Vertice ReadVertice( this BinaryReader bin ) {
			Vertice vert = new Vertice();
			vert.CoordXYZ = new Vector3( bin.ReadSingle(), bin.ReadSingle(), bin.ReadSingle() );
			vert.Weight = bin.ReadSingle();
			vert.BoneID01 = bin.ReadByte();
			vert.BoneID02 = bin.ReadByte();
			vert.NULL1 = bin.ReadByte();
			vert.NULL2 = bin.ReadByte();
			vert.NormalXYZ = new Vector3( bin.ReadSingle(), bin.ReadSingle(), bin.ReadSingle() );
			vert.TexCoordUV = new Vector2( bin.ReadSingle(), bin.ReadSingle() );

			return vert;
		}

		public static Face ReadFace( this BinaryReader bin ) {
			Face f = new Face();
			f.Face1 = bin.ReadInt16();
			f.Face2 = bin.ReadInt16();
			f.Face3 = bin.ReadInt16();

			return f;
		}

	}

}
