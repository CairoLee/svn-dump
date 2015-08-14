using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace GLibary {
	public class ModelCollisionData {
		private int[] indices;

		public int[] Indices {
			get {
				return indices;
			}
			set {
				indices = value;
			}
		}

		private Vector3[] vertices;

		public Vector3[] Vertices {
			get {
				return vertices;
			}
			set {
				vertices = value;
			}
		}

		private Vector3[] normals;

		public Vector3[] Normals {
			get {
				return normals;
			}
			set {
				normals = value;
			}
		}

		private Plane[] polyPlanes;

		public Plane[] PolyPlanes {
			get {
				return polyPlanes;
			}
			set {
				polyPlanes = value;
			}
		}

	}

	public class CollisionModel {

		public Model Model;

		public ModelCollisionData CollisionData;

		public CollisionModel( Model model ) {
			ProcessModel( model );
			Model = model;
		}

		public unsafe void ProcessModel( Model model ) {
			CollisionData = new ModelCollisionData();
			CollisionData.Vertices = Utility.GetFlattenedPositionArray( model );
			CollisionData.Normals = Utility.GetFlattenedNormalArray( model );
			CollisionData.Indices = Utility.GetFlattenedIndexArray( model );
		}


	}


}
