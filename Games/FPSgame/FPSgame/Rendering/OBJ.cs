using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SkinnedModel;

namespace FPSgame {

	public class OBJ {
		private SkinningData mSkinningData;
		private string mPose;
		private string mTemppose;
		private bool mDurationEnable;

		public Vector3 Position;
		public Vector3 Scale;
		public Vector3 Rotation;
		public Matrix World;
		public Matrix Orientation;
		public Model Model;
		public Vector3 Normal;
		public AnimationPlayer AnimationPlayer;
		public float AnimationSpeed;
		public BoundingSphere Bound;
		public int DurationPose;


		public OBJ() {
			Scale = Vector3.One;
			Rotation = Vector3.Zero;
			Orientation = Matrix.Identity;
			SetWorld();
		}



		public void SkinningSetting(string startPose) {
			mSkinningData = Model.Tag as SkinningData;
			if (mSkinningData == null) {
				throw new InvalidOperationException("This model does not contain a SkinningData tag.");
			}
			AnimationPlayer = new AnimationPlayer(mSkinningData);
			AnimationSpeed = 0.04f;
			AnimationClip clip = mSkinningData.AnimationClips[startPose];
			AnimationPlayer.StartClip(clip);
			mTemppose = startPose;
		}

		public void PlayAnimation(string pos, string pos2, int duration) {
			mPose = pos;
			mTemppose = pos2;
			DurationPose = duration;
			AnimationClip clip = mSkinningData.AnimationClips[pos];
			AnimationPlayer.StartClip(clip);
			mDurationEnable = true;
		}



		public void SetWorld() {
			World = Matrix.CreateScale(Scale) * Matrix.CreateRotationX(Rotation.X) * Matrix.CreateRotationY(Rotation.Y) * Matrix.CreateRotationZ(Rotation.Z) * Matrix.CreateTranslation(Position);
		}

		public void SetWorldNormal() {
			World = Matrix.CreateScale(Scale) * Matrix.CreateRotationX(Normal.X) * Matrix.CreateRotationY(Rotation.Y) * Matrix.CreateRotationZ(Normal.Z) * Matrix.CreateTranslation(Position);
		}

		
		public virtual void Update(GameTime gameTime) {
			SetWorld();
		}

		public void UpdateSkinngin(GameTime gameTime, bool normal) {
			if (normal) {
				SetWorldNormal();
			} else {
				SetWorld();
			}

			if (mDurationEnable) {
				if (DurationPose <= 0) {
					mDurationEnable = false;
					AnimationClip clip = mSkinningData.AnimationClips[mTemppose];
					AnimationPlayer.StartClip(clip);
				} else {
					DurationPose -= 1;
				}
			}

			AnimationPlayer.Update(TimeSpan.FromSeconds(AnimationSpeed), true, World);
		}

	}

}
