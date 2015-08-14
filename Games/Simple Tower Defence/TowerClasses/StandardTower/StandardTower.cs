using System.Collections.Generic;
using BaseTower;
using Microsoft.Xna.Framework;
using PathDefence.GamePlay;
using PathDefence.Screens;
using TowerInterface;

namespace StandardTower
{
    [TowerKey("StandardTower", "Standardturm", true)]
    public class StandardTower : Tower
    {
        public StandardTower(Game game, GamePlayScreen gamePlayScreen, List<Creep> creeps, Vector2 position, string name)
            : base(game, gamePlayScreen, creeps, position,name) {}

        public override void Initialize()
        {
            base.Initialize();
        }
    }
}