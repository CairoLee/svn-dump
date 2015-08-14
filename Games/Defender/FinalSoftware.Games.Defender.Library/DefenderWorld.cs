using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using FinalSoftware.Games.Defender.Library.Animation;
using FinalSoftware.Games.Defender.Library.Interface;
using FinalSoftware.Games.Defender.Library.Map;
using FinalSoftware.Games.Defender.Library.Projectiles;
using FinalSoftware.Games.Defender.Library.Towers;
using FinalSoftware.Games.Defender.Library.Units;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace FinalSoftware.Games.Defender.Library {

	public class DefenderWorld : DefenderComponent {
		public const int Dtier = 1;
		public const int MaxScorches = 500;
		public const int MaxCorpses = 500;
		public const int TileSize = 20;

		protected static DefenderWorld mInstance;

		protected UserInterface mInterface;
		protected DefenderStatus mStatus;
		protected DefenderAudioEffects mAudio;
		protected DefenderMusic mMusic;

		protected Random mSpawnRand = new Random();
		protected Random mSpawnSizeRand = new Random();
		protected int mSpawnSizeRandFrom = 5;
		protected int mSpawnSizeRandTo = 10;
		protected Random mTypeRand = new Random();
		protected float mSpawnTimer = 0f;
		protected float mUnitInterval = 128.0f; // new unit in a wave
		protected float mSpawnInterval = 20000.0f; // new wave
		protected int mBaseSpawnSize = 40; // units per wave
		protected int mCurrentSpawnSize = 40;
		protected int mSpawnHealth = 100;
		protected bool mGameRestart = false;

		protected int mNumberOfWavesPerStage = 10;

		protected DefenderMap mMap;

		public CrossroadList Crossroads;
		public CrossroadList Spawns;
		public Paths Paths;

		protected UnitWaveList mWaves;
		protected ArrayList mTowers = new ArrayList();

		protected SpriteAnimationList mAnimations = new SpriteAnimationList();
		protected SpriteAnimationList mProjectileEffects = new SpriteAnimationList();
		protected ScorchList mScorches = new ScorchList();

		public bool GamePaused = false;
		public bool GameDisplayTowerLvls = false;
		public EUnitType UnitType = EUnitType.Basic;
		public bool StartWaves;

		public Texture2D texMap, texShadow, texPathEnd, texUnit, texRegenUnit, texFastUnit, texAggressiveUnit, texArmorUnit, texBoss, texUnitDead;
		public Texture2D texArrow, texLaser, texRocket, texBullet, texExplosion, texConcussion, texRay;
		public Texture2D texDirtPuff, texDirectHit, texFlash, texFire, texExplosion2, texExplosion3, texSmoke, texConcussionExplode;
		public Texture2D texLightCircle, texScorch, texBase;

		public Rectangle MapBaseArea;


		public static DefenderWorld Instance {
			get { return mInstance; }
		}

		public virtual DefenderAudioEffects Audio {
			get { return mAudio; }
		}

		public virtual DefenderMusic Music {
			get { return mMusic; }
		}

		public virtual UserInterface Interface {
			get { return mInterface; }
		}

		public virtual DefenderStatus Status {
			get { return mStatus; }
		}

		public virtual UnitWaveList Waves {
			get { return mWaves; }
		}

		public ArrayList Towers {
			get { return mTowers; }
		}

		public SpriteAnimationList Animations {
			get { return mAnimations; }
		}

		public SpriteAnimationList ProjectileEffects {
			get { return mProjectileEffects; }
		}

		public ScorchList Scorches {
			get { return mScorches; }
		}


		public SpriteBatch SpriteBatch {
			get { return mInterface.SpriteBatch; }
		}

		public SpriteBatch SpriteBatchAdditive {
			get { return mInterface.SpriteBatchAdditive; }
		}

		public virtual DefenderMap Map {
			get { return mMap; }
		}

		public float NextWaveIn {
			get { return mSpawnInterval - mSpawnTimer; }
		}

		public float SpawnInterval {
			get { return mSpawnInterval; }
			set {
				mSpawnInterval = value;
				mSpawnTimer = value;
			}
		}

		public int SpawnSize {
			get { return mCurrentSpawnSize; }
			set { UpdateWaveSpawnSize(value);  }
		}

		public int SpawnHealth {
			get { return mSpawnHealth; }
			set { mSpawnHealth = value; }
		}

		public bool GameRestart {
			get { return mGameRestart; }
			set { mGameRestart = value; }
		}

		public EGameDifficult GameDifficult {
			get;
			protected set;
		}



		public DefenderWorld(DefenderGame game)
			: base(game) {
			mInstance = this;

			mWaves = new UnitWaveList();
			mSpawnTimer = mSpawnInterval;

			Initialize();
		}


		public virtual object GetWorld() {
			return mInstance;
		}


		public override void Initialize() {
			base.Initialize();
			if (mAudio == null) {
				mAudio = new DefenderAudioEffects(Game);
				Game.Components.Add(Audio);
			}
			if (mInterface == null) {
				mInterface = new UserInterface(Game);
				Game.Components.Add(mInterface);
			}

			mAudio.Initialize();
			if (mMusic == null)
				mMusic = new DefenderMusic(Audio.SoundBank, Audio.Engine);

			if (mStatus == null)
				mStatus = new DefenderStatus();
		}

		protected override void LoadContent() {
			texBase = Game.Content.Load<Texture2D>("textures/texBase");

			texUnit = Game.Content.Load<Texture2D>("texUnitDot");
			texRegenUnit = Game.Content.Load<Texture2D>("texMedicUnit");
			texFastUnit = Game.Content.Load<Texture2D>("texFastUnit");
			texAggressiveUnit = Game.Content.Load<Texture2D>("texAggressiveUnit");
			texArmorUnit = Game.Content.Load<Texture2D>("texArmoredUnit");

			texUnitDead = Game.Content.Load<Texture2D>("texUnitDead");
			texBoss = Game.Content.Load<Texture2D>("texEvilBoss");
			texArrow = Game.Content.Load<Texture2D>("texArrow");
			texRocket = Game.Content.Load<Texture2D>("texRocket");
			texShadow = Game.Content.Load<Texture2D>("textures/texShadow");

			texConcussion = Game.Content.Load<Texture2D>("texConcussion");
			texConcussionExplode = Game.Content.Load<Texture2D>("texConcussionExplode");
			texRay = Game.Content.Load<Texture2D>("texRay");

			texBullet = Game.Content.Load<Texture2D>("texTracer");
			texDirtPuff = Game.Content.Load<Texture2D>("texDirtPuff");
			texFlash = Game.Content.Load<Texture2D>("texFlash");
			texFire = Game.Content.Load<Texture2D>("texFire");

			texMap = Game.Content.Load<Texture2D>("textures/map/map1");
			Texture2D texColorKey = Game.Content.Load<Texture2D>("textures/map/map1Key");

			texLightCircle = Game.Content.Load<Texture2D>("textures/effects/lightCircle");
			texScorch = Game.Content.Load<Texture2D>("textures/effects/scorch");
			texSmoke = Game.Content.Load<Texture2D>("texSmoke");
			texExplosion = Game.Content.Load<Texture2D>("texRocketExplode");
			texExplosion2 = Game.Content.Load<Texture2D>("texExplode2");
			texExplosion3 = Game.Content.Load<Texture2D>("texExplode3");

			SetupMap(texColorKey);

			base.LoadContent();
		}

		private void SetupMap(Texture2D texColorKey) {
			mMap = new DefenderMap(texColorKey);
			#region TowerDefence Final Version Map
			Crossroad x1 = new Crossroad(0, 0);
			Crossroad x2 = new Crossroad(200, 200);
			Crossroad x3 = new Crossroad(520, 280);
			Crossroad x4 = new Crossroad(540, 80);
			Crossroad x5 = new Crossroad(960, 40);
			Crossroad x6 = new Crossroad(1000, 200);
			Crossroad x7 = new Crossroad(900, 300);
			Crossroad x8 = new Crossroad(860, 520);
			Crossroad x9 = new Crossroad(1200, 620);
			Crossroad x10 = new Crossroad(1400, 500);
			Crossroad x11 = new Crossroad(1720, 320);
			Crossroad x12 = new Crossroad(1880, 380);
			Crossroad x13 = new Crossroad(1940, 520);
			Crossroad x14 = new Crossroad(1780, 600);
			Crossroad x15 = new Crossroad(1580, 780);
			Crossroad x16 = new Crossroad(1800, 880);
			Crossroad x17 = new Crossroad(1880, 1160);
			Crossroad x18 = new Crossroad(1600, 1200);
			Crossroad x19 = new Crossroad(1740, 1420);
			Crossroad x20 = new Crossroad(1460, 1560);
			Crossroad x21 = new Crossroad(1180, 1560);
			Crossroad x22 = new Crossroad(1000, 1800);
			Crossroad x23 = new Crossroad(720, 1940);
			Crossroad x24 = new Crossroad(600, 1760);
			Crossroad x25 = new Crossroad(720, 1580);
			Crossroad x26 = new Crossroad(600, 1400);
			Crossroad x27 = new Crossroad(420, 1560);
			Crossroad x28 = new Crossroad(340, 1660);
			Crossroad x29 = new Crossroad(80, 1560);
			Crossroad x30 = new Crossroad(200, 1280);
			Crossroad x31 = new Crossroad(400, 1220);
			Crossroad x32 = new Crossroad(360, 840);
			Crossroad x33 = new Crossroad(60, 780);
			Crossroad x34 = new Crossroad(280, 460);
			Crossroad end = new Crossroad(1800, 1800);

			Crossroads = new CrossroadList(x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13, x14, x15, x16, x17, x18, x19, x20, x21, x22, x23, x24, x25, x26, x27, x28, x29, x30, x31, x32, x33, x34, end);
			Spawns = new CrossroadList(x1);

			#region connections
			x1.Connections.Add(x2);
			x2.Connections.Add(x3);
			x2.Connections.Add(x34);
			x3.Connections.Add(x4);
			x4.Connections.Add(x5);
			x5.Connections.Add(x6);
			x6.Connections.Add(x7);
			x7.Connections.Add(x8);
			x8.Connections.Add(x9);
			x9.Connections.Add(x10);
			x10.Connections.Add(x11);
			x11.Connections.Add(x12);
			x12.Connections.Add(x13);
			x13.Connections.Add(x14);
			x14.Connections.Add(x15);
			x15.Connections.Add(x16);
			x16.Connections.Add(x17);
			x17.Connections.Add(x18);
			x18.Connections.Add(x19);
			x19.Connections.Add(x20);
			x20.Connections.Add(end);
			x34.Connections.Add(x33);
			x33.Connections.Add(x32);
			x32.Connections.Add(x31);
			x31.Connections.Add(x30);
			x30.Connections.Add(x29);
			x29.Connections.Add(x28);
			x28.Connections.Add(x27);
			x27.Connections.Add(x26);
			x26.Connections.Add(x25);
			x25.Connections.Add(x24);
			x24.Connections.Add(x23);
			x23.Connections.Add(x22);
			x22.Connections.Add(x21);
			x21.Connections.Add(x20);
			#endregion
			#endregion

			// Debug cross road structure
			//System.Xml.Serialization.XmlSerializer xml = new System.Xml.Serialization.XmlSerializer(typeof(CrossroadList));
			//xml.Serialize(System.IO.File.OpenWrite("crossroads.xml"), Crossroads);

			Paths = new Paths(Spawns.PathCount + Crossroads.PathCount);
			Paths.CalculatePaths(Crossroads);
			Paths.CalculatePaths(Spawns);

			MapBaseArea = new Rectangle(end.X - 30 + TileSize / 2, end.Y - 30 + TileSize / 2, 60, 60);
		}


		public virtual void SetGameDifficult(EGameDifficult diff) {
			GameDifficult = diff;
			if (diff == EGameDifficult.Easy) {
				SetGameDifficultNormal();
			} else if (diff == EGameDifficult.Medium) {
				SetGameDifficultMedium();
			} else if (diff == EGameDifficult.Hard) {
				SetGameDifficultHard();
			} else {
				throw new ArgumentOutOfRangeException("diff");
			}

			UpdateWaveSpawnSize();
		}

		protected virtual void SetGameDifficultNormal() {
			mBaseSpawnSize = 40;
			mCurrentSpawnSize = 40;

			mSpawnSizeRandFrom = 5;
			mSpawnSizeRandTo = 10;

			SpawnInterval = 18000;
		}

		protected virtual void SetGameDifficultMedium() {
			mBaseSpawnSize = 50;
			mCurrentSpawnSize = 50;

			mSpawnSizeRandFrom = 8;
			mSpawnSizeRandTo = 13;

			SpawnInterval = 13000;
		}

		protected virtual void SetGameDifficultHard() {
			mBaseSpawnSize = 60;
			mCurrentSpawnSize = 60;

			mSpawnSizeRandFrom = 10;
			mSpawnSizeRandTo = 20;

			SpawnInterval = 15000;
		}

		public virtual void UpgradeWaveStatsByDifficult() {
			SpawnSize += mSpawnSizeRand.Next(mSpawnSizeRandFrom, mSpawnSizeRandTo);
		}

		public void UpdateWaveSpawnSize() {
			int size = mBaseSpawnSize;
			for (var i = 0; i < Status.Wave; i++) {
				size += mSpawnSizeRand.Next(mSpawnSizeRandFrom, mSpawnSizeRandTo);
			}

			// Update current size
			UpdateWaveSpawnSize(size);
		}

		public void UpdateWaveSpawnSize(int baseSize) {
			mCurrentSpawnSize = baseSize;
		}
		
		
		#region Updating
		public void UpdateWorld(GameTime gameTime) {
			if (GamePaused)
				return;

			Status.Update(gameTime, this);

			// "Spiel starten" pressed?
			if (StartWaves) {
				// Allow waves to be spawned
				// Easy and Medium: Spawn next wave after previous waves were cleaned
				// Hardcore: perm spawn waves

				UpdateWaves(gameTime);
			}

			UpdateTowers(gameTime);

			mProjectileEffects.Update(gameTime);

			if (Scorches.Count > MaxScorches)
				Scorches.RemoveAt(0);
		}

		private void UpdateTowers(GameTime gameTime) {
			foreach (Tower t in Towers)
				t.Update(gameTime);
		}
		#endregion

		#region Gameplay
		private void UpdateWaves(GameTime gameTime) {
			// Update only if..
			// - base/medium mode - all creeps are killed
			// - hardcore mode - everytime
			var hasUnfinishedWave = false;
			if (GameDifficult != EGameDifficult.Hard) {
				if (Waves.Any(wave => wave.Finished == false)) {
					hasUnfinishedWave = true;
				}
			}

			if (hasUnfinishedWave == false) {
				mSpawnTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
				if (mSpawnTimer > mSpawnInterval) {
					UpgradeWaveStatsByDifficult();
					int spawnPoint = BuildWave();

					Status.Wave++;
					mSpawnTimer = 0f;

					if ((Status.Wave%mNumberOfWavesPerStage) == 0) {
						int bossCount = Math.Max((Status.Wave/10), 1);
						for (int i = 0; i < bossCount; i++)
							mWaves[mWaves.Count - 1].CreateBoss(Spawns[spawnPoint], texUnit, texUnitDead);
					}
				}
			}

			for (int i = 0; i < mWaves.Count; i++) {
				mWaves[i].Update(gameTime);
				if (mWaves[i].Finished) {
					mWaves.RemoveAt(i);
					i--;
				}
			}

		}

		protected virtual int BuildWave() {
			int spawn = mSpawnRand.Next(Spawns.Count);
			UnitType++;
			if ((int)UnitType >= (int)EUnitType.MAX)
				UnitType = EUnitType.Basic;

			mWaves.Add(new UnitWave(UnitType, Spawns[spawn], SpawnSize, TileSize, mUnitInterval));
			return spawn;
		}


		public virtual void BuildTower(Rectangle towerBase, string buildType) {

		}
		#endregion

		#region Animation / Sound Creation
		public void CreateAnimation(string name, Vector2 pos, float scale, float angle, float duration) {
			if (Status.GraphicsQuality > 0.0) {
				switch (name) {
					case "pulseHit":
						if (Status.GraphicsQuality > 0.7) {
							mProjectileEffects.Add(new SpriteAnimation(texLightCircle, pos, duration, scale, 100, angle, true, new Color(200, 50, 50, 75)));
							mProjectileEffects.Add(new SpriteAnimation(texExplosion, pos, 16, 0.25f, 64, angle, true, new Color(180, 25, 80, 150)));
						}
						break;
					case "beamHit":
						if (Status.GraphicsQuality > 0.7) {
							mProjectileEffects.Add(new SpriteAnimation(texLightCircle, pos, duration, scale, 100, angle, true, new Color(255, 180, 0, 255)));
							mProjectileEffects.Add(new SpriteAnimation(texExplosion3, pos, 32, scale * 1.2f, 64, angle, true, new Color(255, 180, 0, 255)));
						}
						break;
					case "lightCircle":
						if (Status.GraphicsQuality > 0.8) {
							mProjectileEffects.Add(new SpriteAnimation(texLightCircle, pos, duration, scale, 100, angle, true, new Color(100, 100, 100, 200)));
						}
						break;
					case "redCircle":
						if (Status.GraphicsQuality > 0.8) {
							mProjectileEffects.Add(new SpriteAnimation(texLightCircle, pos, duration, scale, 100, angle, true, new Color(200, 50, 50, 75)));
						}
						break;
					case "fire":
						if (Status.GraphicsQuality > 0.6) {
							mProjectileEffects.Add(new SpriteAnimation(texLightCircle, pos, duration, scale * 1.5f, 100, angle, true, new Color(100, 100, 100, 200)));
							mProjectileEffects.Add(new SpriteAnimation(texExplosion, pos, duration, scale, 64, angle, true, new Color(240, 180, 180, 220)));
						}
						break;
					case "explosion1":
						if (Status.GraphicsQuality > 0.4) {
							mProjectileEffects.Add(new SpriteAnimation(texLightCircle, pos, 32f, scale * 3, 100, 0, true, new Color(100, 100, 100, 200)));
							mProjectileEffects.Add(new SpriteAnimation(texExplosion, pos, duration, scale, 64, angle, true, Color.White));
							mProjectileEffects.Add(new SpriteAnimation(texExplosion3, pos, duration * 2, scale, 64, angle, false, new Color(0, 0, 0, 75)));
							mProjectileEffects.Add(new SpriteAnimation(texExplosion, pos, duration * 3, scale, 64, angle, false, new Color(0, 0, 0, 75)));
						}
						break;
					case "explosion2":
						if (Status.GraphicsQuality > 0.4) {
							mProjectileEffects.Add(new SpriteAnimation(texExplosion2, pos, duration, scale, 64, angle, true, Color.White));
						}
						break;
					case "explosion3":
						if (Status.GraphicsQuality > 0.4) {
							mProjectileEffects.Add(new SpriteAnimation(texLightCircle, pos, duration, scale * 2, 100, angle, true, new Color(100, 100, 100, 200)));
							mProjectileEffects.Add(new SpriteAnimation(texExplosion3, pos, duration, scale, 64, angle, true, Color.White));
						}
						break;
					case "missile trail":
						if (Status.GraphicsQuality > 0.6) {
							mProjectileEffects.Add(new SpriteAnimation(texSmoke, pos, duration * 6, scale, 64, angle, false, new Color(180, 180, 180, 75)));
							mProjectileEffects.Add(new SpriteAnimation(texExplosion, pos, duration, scale, 64, angle, true, new Color(255, 255, 255, 255)));
						}
						break;
					case "flash":
						if (Status.GraphicsQuality > 0.7) {
							mProjectileEffects.Add(new SpriteAnimation(texFlash, pos, duration, scale, 50, angle, false, new Color(255, 255, 255, 255)));
						}
						break;
					case "dirt puff":
						if (Status.GraphicsQuality > 0.7) {
							mProjectileEffects.Add(new SpriteAnimation(texDirtPuff, pos, duration, scale, 50, 0, false, new Color(220, 200, 160, 200)));
						}
						break;
					case "red puff":
						if (Status.GraphicsQuality > 0.7) {
							mProjectileEffects.Add(new SpriteAnimation(texFlash, pos, duration, scale, 50, 0, false, new Color(240, 60, 5, 200)));
						}
						break;
					case "concussion":
						mProjectileEffects.Add(new SpriteAnimation(texConcussionExplode, pos, duration, scale, 50, 0, true, Color.LightBlue));
						break;
					default:
						break;
				}
			}
		}

		public void PlaySound(string sound, Vector2 position) {
			if (Status.Sound) {
				try {
					Audio.Play3DCue(sound, position);
				} catch {
				}
			}
		}
		#endregion

		#region Drawing
		public void DrawWorldBG(GameTime gameTime) {
			SpriteBatch.Draw(texMap, Map.Bounds, Color.White);

			if (Status.GraphicsQuality >= 0.5)
				foreach (Scorch s in Scorches)
					SpriteBatch.Draw(texScorch, s.Area, null, new Color(25, 25, 25, 120), 0, new Vector2(texScorch.Width / 2, texScorch.Width / 2), SpriteEffects.None, 0);

			SpriteBatch.Draw(Interface.texBlank, MapBaseArea, Color.Green);
			foreach (Crossroad s in Spawns)
				SpriteBatch.Draw(Interface.texBlank, s.Area, Color.Red);

			if (Interface.DrawPaths)
				DrawPaths();
		}

		public void DrawWorldFG(GameTime gameTime) {
			mWaves.Draw(gameTime, SpriteBatch, SpriteBatchAdditive);
			DrawTowers(gameTime);

			mProjectileEffects.Draw(gameTime, SpriteBatch, SpriteBatchAdditive);
		}

		public void DrawTime() {
			SpriteBatch.Draw(Interface.texBlank, new Rectangle(0, 0, 1024, 768), new Color(0, 0, 10, (byte)(Status.Time)));
		}

		private void DrawPaths() {
			foreach (Crossroad x in Crossroads)
				SpriteBatch.Draw(Interface.texBlank, x.Area, Color.Black);
			foreach (Path p in Paths)
				SpriteBatch.Draw(Interface.texUIArrow, p.Rectangle, null, Color.Black, p.Angle, Vector2.Zero, SpriteEffects.None, 0.9f);
		}

		private void DrawTowers(GameTime gameTime) {
			Color tColor = Color.White;
			foreach (Tower t in Towers) {
				Rectangle shadow = t.TowerBase;
				shadow.Y += 10;
				shadow.Width += 20;
				shadow.X -= 10;

				SpriteBatch.Draw(texShadow, shadow, Color.Black);

				t.Draw(SpriteBatch, SpriteBatchAdditive);
			}
		}

		public void DrawProjectiles() {
			foreach (Tower t in Towers) {
				foreach (Projectile p in t.Projectiles) {
					if (p.Additive)
						SpriteBatchAdditive.Draw(p.Texture, p.Area, null, p.Color, p.Angle, Vector2.Zero, SpriteEffects.None, 0.5f);
					else
						SpriteBatch.Draw(p.Texture, p.Area, null, p.Color, p.Angle, Vector2.Zero, SpriteEffects.None, 0.5f);
				}
			}
		}
		#endregion

	}

}
