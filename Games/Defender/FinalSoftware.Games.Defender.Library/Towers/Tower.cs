using System;
using System.Collections.Generic;
using FinalSoftware.Games.Defender.Library.Projectiles;
using FinalSoftware.Games.Defender.Library.Units;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections;

namespace FinalSoftware.Games.Defender.Library.Towers {

	public class Tower {
		public const int MAX_LVL = 15;

		protected DefenderWorld mWorld;
		protected Rectangle mTowerBase;
		protected Vector2 mCenter;
		protected Rectangle mTowerDrawArea;
		protected Texture2D texture, textureMM;
		protected ArrayList mProjectiles = new ArrayList();
		protected Random mRand = new Random();
		protected bool mPlaySound = true;
		protected Color mMinimapColor = Color.White;

		protected string mName;
		protected Unit mTarget;
		protected int mLevel = 1;
		protected float mFiringTimer = 0.0f;
		protected float mFiringRate;
		protected float mDefaultFiringRate;
		protected int mRange;
		protected int mDefaultRange;
		protected int mCost;
		protected int mHealth;

		protected int mDmg;
		protected int mBaseDamage = 0;
		protected int mDefaultDmg;
		protected float mProjectileSpeed;
		protected int mImprecision = 0;
		protected bool mHoming = false;

		protected string mFireSound;
		protected float mTargetCheckTimer;
		protected float mTargetCheckInterval = 1000.0f;
		protected float mFadeInterval = 4000.0f;
		protected float mCurrentInterval = 0;

		private Dictionary<string, TowerEffects> mTowerEffects = new Dictionary<string, TowerEffects>();

		public Color Color {
			get { return mMinimapColor; }
		}

		public Texture2D TextureMM {
			get { return textureMM; }
		}

		public int ProjectileCount {
			get { return mProjectiles.Count; }
		}

		public int UpgradeCost {
			get {
				return (int)(mCost * (1 + ((float)Level / 10f)));
			}
		}

		public Vector2 Center {
			get { return mCenter; }
		}

		public Vector2 Position {
			get { return new Vector2(mTowerBase.X, mTowerBase.Y); }
			set {
				mTowerBase.X = (int)value.X;
				mTowerBase.Y = (int)value.Y;
				SetDrawRectangle();
				mCenter = new Vector2(mTowerBase.Width / 2 + mTowerBase.X, mTowerBase.Height / 2 + mTowerBase.Y);
			}
		}

		public ArrayList Projectiles {
			get { return mProjectiles; }
		}

		public Rectangle TowerBase {
			get { return mTowerBase; }
		}

		public Texture2D Texture {
			get { return texture; }
		}

		public int Dmg {
			get { return mDmg; }
			set { mDmg = value; }
		}

		public int Range {
			get { return mRange; }
			set { mRange = value; }
		}

		public string Name {
			get { return mName; }
		}

		public string NameDisplay {
			get { return (Level > 1 ? "+" + (Level - 1) + " " : "") + Name; }
		}

		public int Level {
			get { return mLevel; }
		}

		/// <summary>
		/// Level as a percent from 1, max is MAX_LVL
		/// </summary>
		public float LevelPercent {
			get { return (float)mLevel / MAX_LVL; }
		}

		public Rectangle DrawArea {
			get { return mTowerDrawArea; }
		}

		public bool PlaySound {
			get { return mPlaySound; }
			set { mPlaySound = value; }
		}

		public int Cost {
			get { return mCost; }
		}

		public string Rate {
			get { return mFiringRate / 1000.0f + "s"; }
		}

		public float DefaultFiringRate {
			get { return mDefaultFiringRate; }
		}

		public int DefaultRange {
			get { return mDefaultRange; }
		}

		public int DefaultDmg {
			get { return mDefaultDmg; }
		}

		public float FiringRate {
			get { return mFiringRate; }
			set { mFiringRate = value; }
		}

		public int Health {
			get { return mHealth; }
			set { mHealth = value; }
		}

		public bool Dead {
			get { return (mHealth == -1); }
		}

		public virtual DefenderWorld GameWorld {
			get { return mWorld; }
		}


		public Tower(Rectangle towerBase) {
			mWorld = DefenderWorld.Instance;
			mTowerBase = towerBase;
			mCenter = new Vector2(towerBase.Width / 2 + towerBase.X, towerBase.Height / 2 + towerBase.Y);
			mHealth = 1000;
		}

		public Tower(Rectangle towerBase, int health) {
			mWorld = DefenderWorld.Instance;
			mTowerBase = towerBase;
			mCenter = new Vector2(towerBase.Width / 2 + towerBase.X, towerBase.Height / 2 + towerBase.Y);
			mHealth = health;
		}


		protected void SetDrawRectangle() {
			int tDrawHeight, tDrawY;

			tDrawHeight = (int)((float)texture.Height / texture.Width * mTowerBase.Width);
			tDrawY = mTowerBase.Y - tDrawHeight + mTowerBase.Height;
			mTowerDrawArea = new Rectangle(mTowerBase.X, tDrawY, mTowerBase.Width, tDrawHeight);
		}


		public virtual void Update(GameTime gameTime) {
			ArrayList keysToRemove = ApplyEffects(gameTime);
			RemoveEffect(keysToRemove);

			Reload(gameTime);

			if (mFiringTimer >= mFiringRate && mTargetCheckTimer >= mTargetCheckInterval) {
				if (mTarget == null || mTarget.Dead || Distance(mTarget) > mRange) {
					mTarget = CheckForTargets();
					if (mTarget == null)
						mTargetCheckTimer = 0;
				} else if (mTarget != null && mTarget.Dead == false) {
					Fire(mTarget);
				}
			} else {
				mTargetCheckTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
			}
			UpdateProjectiles();
		}

		protected virtual void UpdateProjectiles() {
			Projectile p;

			for (int i = 0; i < mProjectiles.Count; i++) {
				p = (Projectile)mProjectiles[i];
				if (p.Active) {
					p.UpdateProjectile();
					continue;
				}
				mProjectiles.RemoveAt(i);
				i--;
			}

		}


		protected virtual void Reload(GameTime gameTime) {
			if (mFiringTimer < mFiringRate)
				mFiringTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
		}



		protected virtual void Fire(Unit target) {
			mProjectiles.Add(new Arrow(mWorld, mCenter, target, mDmg, mProjectileSpeed, mImprecision));

			mFiringTimer -= mFiringRate;
			if (mFireSound != null && mPlaySound)
				mWorld.PlaySound(mFireSound, mCenter);
		}


		protected virtual Unit CheckForTargets() {
			return AcquireFirstTarget();
		}


		protected virtual Unit AcquireFirstTarget() {
			return mWorld.Waves.GetFirstTarget(mCenter, mRange);
		}


		protected virtual Unit AcquireRandomTarget() {
			return mWorld.Waves.GetRandomTarget(mCenter, mRange);
		}


		protected virtual Unit AcquireClosestTarget() {
			return mWorld.Waves.GetClosestTarget(mCenter, mRange);
		}


		public virtual int Upgrade() {
			if (mLevel < MAX_LVL) {

				int changeDmg = (int)(mBaseDamage * (mLevel + 1) * .9f);
				if (changeDmg < 1)
					changeDmg = mDefaultDmg + 1;
				mDmg += changeDmg - mDefaultDmg;
				mDefaultDmg = changeDmg;

				int changeRange = (int)(mDefaultRange * .03f);
				mRange += changeRange;
				mDefaultRange += changeRange;
				mLevel++;
				return mCost;
			}
			return 0;
		}


		public virtual void Draw(SpriteBatch sbAlpha, SpriteBatch sbAdditive) {
			Color tColor = Color.White;
			if (mWorld.GameDisplayTowerLvls)
				tColor = new Color((byte)(LevelPercent * 255), (byte)(255 - LevelPercent * 255), 0, 180);
			sbAlpha.Draw(texture, DrawArea, null, tColor, 0, Vector2.Zero, SpriteEffects.None, 0.6f);
		}


		protected float Distance(Unit target) {
			return (target.Center - mCenter).Length();
		}

		protected float Distance(Tower tower) {
			return (tower.Center - mCenter).Length();
		}

		public void AddEffect(string name, TowerEffects effect) {
			if (!mTowerEffects.ContainsKey(name)) {
				mTowerEffects.Add(name, effect);
				effect.ApplyEffect(this);
			}
		}

		protected ArrayList ApplyEffects(GameTime time) {
			ArrayList keysToRemove = new ArrayList();
			foreach (KeyValuePair<string, TowerEffects> kvp in mTowerEffects) {
				if (kvp.Value != null) {
					if (!kvp.Value.IsValid(time)) {
						keysToRemove.Add(kvp.Key);
						kvp.Value.UndoEffect(this);
					} else
						kvp.Value.ApplyEffect(this);
				}
			}
			return keysToRemove;
		}

		protected void RemoveEffect(ArrayList keys) {
			for (int i = 0; i < keys.Count; i++)
				if (keys[i] != null)
					mTowerEffects.Remove((string)keys[i]);

		}

		public void Damage(int dmg) {
			mHealth -= dmg;
			if (mHealth <= 0)
				Die();
		}

		public void Die() {
			mHealth = -1;
			mRange = 0;
		}

		public int CurrentWorth() {
			int worth = mCost;
			for (int i = 0; i < mLevel - 1; i++)
				worth += mCost;
			return (int)((.6f * worth) + 1);
		}



		public virtual void DrawTowerDescription(SpriteBatch Batch, SpriteFont Font, Vector2 BasePos) {
			string desc = "";
			desc += "A weak defensive structure\n";
			desc += "which deals limited damage to unarmored targets.\n";
			Batch.DrawString(Font, desc, BasePos, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0);
		}

		public virtual void DrawStatusDescription(SpriteBatch Batch, SpriteFont Font, Vector2 Pos, int LineSpace, Color Color, float Scale) {
			Batch.DrawString(Font, "DMG: " + Dmg, new Vector2(Pos.X, Pos.Y + LineSpace * 2), Color, 0, Vector2.Zero, Scale, SpriteEffects.None, 0);
			Batch.DrawString(Font, "Range: " + Range, new Vector2(Pos.X, Pos.Y + LineSpace * 3), Color, 0, Vector2.Zero, Scale, SpriteEffects.None, 0);
		}


		public virtual void DrawUpgradeInfo(SpriteBatch Batch, SpriteFont Font, Vector2 BasePos) {
			string text = "";
			text += "Upgrade Cost: " + UpgradeCost + "€\n";
			text += "Dmg + " + ((int)(mBaseDamage * (mLevel + 1) * .9f) - mBaseDamage) + "\nRange + 3%";
			Batch.DrawString(Font, text, BasePos, Color.White, 0, Vector2.Zero, 0.4f, SpriteEffects.None, 0);
		}

		public virtual void DrawUpgradeDescription(SpriteBatch Batch, SpriteFont Font, Vector2 BasePos) {
			string desc = "";
			desc += NameDisplay;
			desc += "\nDmg: " + Dmg + " | Rate: " + Rate;
			desc += "\nRange: " + Range;
			desc += "\nCost: " + Cost;

			Batch.DrawString(Font, desc, BasePos, Color.White, 0, Vector2.Zero, 0.4f, SpriteEffects.None, 0);
		}

	}

}
