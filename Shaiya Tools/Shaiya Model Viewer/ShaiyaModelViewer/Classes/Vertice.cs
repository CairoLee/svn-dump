using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Shaiya_Model_Viewer.Library {

	public class Vertice {
		private Vector3 mCoordXYZ;
		private float mWeight;
		private byte mBoneID01;
		private byte mBoneID02;
		private byte mNULL1;
		private byte mNULL2;
		private Vector3 mNormalXYZ;
		private Vector2 mTexCoordUV;

		public Vector3 CoordXYZ {
			get { return mCoordXYZ; }
			set { mCoordXYZ = value; }
		}

		public float Weight {
			get { return mWeight; }
			set { mWeight = value; }
		}

		public byte BoneID01 {
			get { return mBoneID01; }
			set { mBoneID01 = value; }
		}

		public byte BoneID02 {
			get { return mBoneID02; }
			set { mBoneID02 = value; }
		}

		public byte NULL1 {
			get { return mNULL1; }
			set { mNULL1 = value; }
		}

		public byte NULL2 {
			get { return mNULL2; }
			set { mNULL2 = value; }
		}

		public Vector3 NormalXYZ {
			get { return mNormalXYZ; }
			set { mNormalXYZ = value; }
		}

		public Vector2 TexCoordUV {
			get { return mTexCoordUV; }
			set { mTexCoordUV = value; }
		}


		public Vertice() {
		}


		public override string ToString() {
			return string.Format( "{0} {1} {2} {3} {4} {5} {6} {7}", mCoordXYZ.X, mCoordXYZ.Y, mCoordXYZ.Z, mNormalXYZ.X, mNormalXYZ.Y, mNormalXYZ.Z, mTexCoordUV.X, mTexCoordUV.Y );
		}

	}

}
