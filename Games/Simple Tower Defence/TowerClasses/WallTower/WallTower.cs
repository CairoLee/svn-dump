using System.Collections.Generic;
using BaseTower;
using Microsoft.Xna.Framework;
using PathDefence.GamePlay;
using PathDefence.Screens;
using TowerInterface;

namespace WallTower
{
    [TowerKey("WallTower", "Blockade", true)]
    public class WallTower : Tower
    {
        public WallTower(Game game, GamePlayScreen gamePlayScreen, List<Creep> creeps, Vector2 position, string name)
            : base(game, gamePlayScreen, creeps, position,name) {}

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override Shot CreateShotInstance()
        {
            return null;
        }
    }
}