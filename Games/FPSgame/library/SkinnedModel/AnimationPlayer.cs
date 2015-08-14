using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace SkinnedModel {

	public class AnimationPlayer {
		private readonly Matrix[] mBoneTransforms;
		private int mCurrentKeyframe;
		private readonly SkinningData mSkinningDataValue;
		private readonly Matrix[] mSkinTransforms;
		private readonly Matrix[] mWorldTransforms;

		public AnimationClip CurrentClip {
			get;
			private set;
		}

		public TimeSpan CurrentTime {
			get;
			private set;
		}


		public AnimationPlayer(SkinningData skinningData) {
			if (skinningData == null) {
				throw new ArgumentNullException("skinningData");
			}

			mSkinningDataValue = skinningData;
			mBoneTransforms = new Matrix[skinningData.BindPose.Count];
			mWorldTransforms = new Matrix[skinningData.BindPose.Count];
			mSkinTransforms = new Matrix[skinningData.BindPose.Count];

		}


		public Matrix[] GetBoneTransforms() {
			return mBoneTransforms;
		}

		public Matrix[] GetSkinTransforms() {
			return mSkinTransforms;
		}

		public Matrix[] GetWorldTransforms() {
			return mWorldTransforms;
		}

		public void StartClip(AnimationClip clip) {
			if (clip == null) {
				throw new ArgumentNullException("clip");
			}

			CurrentClip = clip;
			CurrentTime = TimeSpan.Zero;
			mCurrentKeyframe = 0;
			mSkinningDataValue.BindPose.CopyTo(mBoneTransforms, 0);
		}

		public void Update(TimeSpan time, bool relativeToCurrentTime, Matrix rootTransform) {
			UpdateBoneTransforms(time, relativeToCurrentTime);
			UpdateWorldTransforms(rootTransform);
			UpdateSkinTransforms();
		}

		public void UpdateBoneTransforms(TimeSpan time, bool relativeToCurrentTime) {
			bool flag;
			if (CurrentClip == null) {
				throw new InvalidOperationException("AnimationPlayer.Update was called before StartClip");
			}

			bool count = !relativeToCurrentTime;
			if (!count) {
				time = time + CurrentTime;
				while (true) {
					count = time >= CurrentClip.Duration;
					if (!count) {
						break;
					}
					time = time - CurrentClip.Duration;
				}
			}
			if (time < TimeSpan.Zero) {
				flag = false;
			} else {
				flag = !(time >= CurrentClip.Duration);
			}
			count = flag;

			if (!count) {
				throw new ArgumentOutOfRangeException("time");
			}

			count = !(time < CurrentTime);
			if (!count) {
				mCurrentKeyframe = 0;
				mSkinningDataValue.BindPose.CopyTo(mBoneTransforms, 0);
			}
			CurrentTime = time;
			IList<Keyframe> keyframes = CurrentClip.Keyframes;
			while (true) {
				count = mCurrentKeyframe < keyframes.Count;
				if (!count) {
					break;
				}
				Keyframe item = keyframes[mCurrentKeyframe];
				count = !(item.Time > CurrentTime);
				if (count) {
					mBoneTransforms[item.Bone] = item.Transform;
					AnimationPlayer animationPlayer = this;
					animationPlayer.mCurrentKeyframe = animationPlayer.mCurrentKeyframe + 1;
				} else {
					break;
				}
			}
		}

		public void UpdateSkinTransforms() {
			int num = 0;
			while (true) {
				bool length = num < mSkinTransforms.Length;
				if (!length) {
					break;
				}
				mSkinTransforms[num] = mSkinningDataValue.InverseBindPose[num] * mWorldTransforms[num];
				num++;
			}
		}

		public void UpdateWorldTransforms(Matrix rootTransform) {
			mWorldTransforms[0] = mBoneTransforms[0] * rootTransform;
			int num = 1;
			while (true) {
				bool length = num < mWorldTransforms.Length;
				if (!length) {
					break;
				}
				int item = mSkinningDataValue.SkeletonHierarchy[num];
				mWorldTransforms[num] = mBoneTransforms[num] * mWorldTransforms[item];
				num++;
			}
		}

	}

}