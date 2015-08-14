using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;

namespace SkinnedModel {

	public class AnimationClip {

		[ContentSerializer]
		public TimeSpan Duration {
			get;
			private set;
		}

		[ContentSerializer]
		public List<Keyframe> Keyframes {
			get;
			private set;
		}


		public AnimationClip() {
			
		}

		public AnimationClip(TimeSpan duration, List<Keyframe> keyframes) {
			Duration = duration;
			Keyframes = keyframes;
		}

	}

}