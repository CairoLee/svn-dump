using System;
using System.Collections.Generic;
using FinalSoftware.Games.Defender.Game.Towers;
using FinalSoftware.Games.Defender.Library.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using FinalSoftware.Games.Defender.Library;

namespace FinalSoftware.Games.Defender.Game {

	public class Interface : UserInterface {

		public Interface( DefenderGame game )
			: base( game ) {
		}


		public override void TowerType( string buildType ) {
			Rectangle empty = new Rectangle( 0, 0, 0, 0 );
			switch( buildType ) {
				case "Rocket":
					mTowerToBeBuilt = new RocketTower( empty );
					break;
				case "MG":
					mTowerToBeBuilt = new MGTower( empty );
					break;
				case "Pulse":
					mTowerToBeBuilt = new PulseTower( empty );
					break;
				case "Flame":
					mTowerToBeBuilt = new FlameTower( empty );
					break;
				case "Artillery":
					mTowerToBeBuilt = new ArtilleryTower( empty );
					break;
				case "Concussion":
					mTowerToBeBuilt = new SlowingTower( empty );
					break;
				case "Command":
					mTowerToBeBuilt = new CommandCenter( empty );
					break;
				case "Rifle":
					mTowerToBeBuilt = new RifleTower( empty );
					break;
				case "Gamma":
					mTowerToBeBuilt = new GammaRayTower( empty );
					break;
				default:
					mTowerToBeBuilt = null;
					mCanBuild = false;
					break;
			}
		}

	}

}
