using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using FinalSoftware.Games.Defender.Game.Towers;
using FinalSoftware.Games.Defender.Game.Units;
using FinalSoftware.Games.Defender.Library.Towers;
using FinalSoftware.Games.Defender.Library.Units;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using FinalSoftware.Games.Defender.Library;

namespace FinalSoftware.Games.Defender.Game {

	public class World : DefenderWorld {

		public Texture2D TexTower;
		public Texture2D TexWreckedTower;
		public Texture2D TexTowerConcussion;
		public Texture2D TexTowerCmdCenter;
		public Texture2D TexTowerRifle;
		public Texture2D TexTowerGammaRay;
		public Texture2D TexTowerPulse;
		public Texture2D TexTowerMg;
		public Texture2D TexTowerFlame;
		public Texture2D TexTowerArty;
		public Texture2D TexTowerRocket;
		public Texture2D TexMMartillery;
		public Texture2D TexMMcommand;
		public Texture2D TexMMconcussive;
		public Texture2D TexMMmg;
		public Texture2D TexMMrifle;
		public Texture2D TexMMpulse;
		public Texture2D TexMMrocket;
		public Texture2D TexMMflame;
		public Texture2D TexMMgamma;

		public World(DefenderGame game)
			: base(game) {
			mInstance = this;
		}


		public override void Initialize() {
			mInterface = new Interface(Game);
			Game.Components.Add(mInterface);

			base.Initialize();
		}

		protected override void LoadContent() {
			base.LoadContent();

			TexTower = Game.Content.Load<Texture2D>("Towers/texTower");
			TexTowerArty = Game.Content.Load<Texture2D>("Towers/texTowerArty");
			TexTowerCmdCenter = Game.Content.Load<Texture2D>("Towers/texTowerCmdCenter");
			TexTowerConcussion = Game.Content.Load<Texture2D>("Towers/texTowerConc");
			TexTowerFlame = Game.Content.Load<Texture2D>("Towers/texTowerFlame");
			TexTowerGammaRay = Game.Content.Load<Texture2D>("Towers/texTowerGamma");
			TexTowerMg = Game.Content.Load<Texture2D>("Towers/texTowerMG");
			TexTowerPulse = Game.Content.Load<Texture2D>("Towers/texTowerPulse");
			TexTowerRifle = Game.Content.Load<Texture2D>("Towers/texTowerRifle");
			TexTowerRocket = Game.Content.Load<Texture2D>("Towers/texTowerRocket");

			TexMMartillery = Game.Content.Load<Texture2D>("textures/ui/texMMartillery");
			TexMMcommand = Game.Content.Load<Texture2D>("textures/ui/texMMcommand");
			TexMMconcussive = Game.Content.Load<Texture2D>("textures/ui/texMMconcussive");
			TexMMmg = Game.Content.Load<Texture2D>("textures/ui/texMMmg");
			TexMMrifle = Game.Content.Load<Texture2D>("textures/ui/texMMrifle");
			TexMMpulse = Game.Content.Load<Texture2D>("textures/ui/texMMpulse");
			TexMMrocket = Game.Content.Load<Texture2D>("textures/ui/texMMrocket");
			TexMMflame = Game.Content.Load<Texture2D>("textures/ui/texMMflame");
			TexMMgamma = Game.Content.Load<Texture2D>("textures/ui/texMMgamma");
		}

		public override void BuildTower(Rectangle towerBase, string buildType) {
			switch (buildType) {
				case "Rocket":
					Towers.Add(new RocketTower(towerBase));
					break;
				case "MG":
					Towers.Add(new MGTower(towerBase));
					break;
				case "Artillery":
					Towers.Add(new ArtilleryTower(towerBase));
					break;
				case "Flame":
					Towers.Add(new FlameTower(towerBase));
					break;
				case "Pulse":
					Towers.Add(new PulseTower(towerBase));
					break;
				case "Concussion":
					Towers.Add(new SlowingTower(towerBase));
					break;
				case "Command":
					Towers.Add(new CommandCenter(towerBase));
					break;
				case "Rifle":
					Towers.Add(new RifleTower(towerBase));
					break;
				case "Gamma":
					Towers.Add(new GammaRayTower(towerBase));
					break;
			}

			Map.AddTower(towerBase);

			for (int i = Towers.Count - 1; i > 0; i--) {
				if (((Tower)Towers[i]).TowerBase.Y < ((Tower)Towers[i - 1]).TowerBase.Y) {
					Towers.Reverse(i - 1, 2);
				}
			}

			PlaySound("tick", Interface.Camera.Position);
		}

		protected override int BuildWave() {
			var spawn = mSpawnRand.Next(Spawns.Count);
			UnitType++;
			if ((int)UnitType >= (int)EUnitType.MAX) {
				UnitType = EUnitType.Basic;
			}

			Waves.Add(new UnitTypeWave(UnitType, Spawns[spawn], SpawnSize, TileSize, mUnitInterval));
			return spawn;
		}


	}

}
