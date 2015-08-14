#if false
using System;
using FreeWorld.Engine.TileEngine;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FreeWorld.Game.Sprites {

	public class NpcSprite : AnimatedSprite {
		private float mSpeakingRadius = 50f;
		private bool mFollowingTarget = false;

		public AnimatedSprite Target;

		public float SpeakingRadius {
			get { return mSpeakingRadius; }
			set { mSpeakingRadius = (float)Math.Max(value, CollisionRadius); }
		}


		public NpcSprite(Texture2D texture)
			: base(texture) {
		}


		public override void Update(GameTime gameTime, TileMap tileMap, bool HandleInput) {
			//! TODO: let the move be more "real"
			if (Target != null && mFollowingTarget) {
				Position = Target.Center + new Vector2(Target.CollisionRadius + CollisionRadius, 0f);
				FinalPosition = Target.FinalPosition;
				CurrentDirection = Target.CurrentDirection;
			}

			base.Update(gameTime, tileMap, false);
		}

		public bool InSpeakingRange(AnimatedSprite sprite) {
			Vector2 d = Origin - sprite.Origin;

			return (d.Length() < SpeakingRadius);
		}

		public void StartFollowing() {
			mFollowingTarget = true;
		}

		public void StopFollowing() {
			mFollowingTarget = false;
		}

	}
}
#endif