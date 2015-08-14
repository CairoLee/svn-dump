using Microsoft.Xna.Framework.Content;
using System;
using Microsoft.Xna.Framework;

namespace SkinnedModel {

	public class Keyframe {

		[ContentSerializer]
		public int Bone {
			get;
			private set;
		}

		[ContentSerializer]
		public TimeSpan Time {
			get;
			private set;
		}

		[ContentSerializer]
		public Matrix Transform {
			get;
			private set;
		}


		public Keyframe() {
			
		}

		public Keyframe(int bone, TimeSpan time, Matrix transform) {
			Bone = bone;
			Time = time;
			Transform = transform;
		}

	}

}