using System.Collections.Generic;
using BaseTower;
using Microsoft.Xna.Framework;
using PathDefence.GamePlay;
using PathDefence.Screens;
using TowerInterface;

namespace FireTower
{
    [TowerKey("FireTower", "Feuerturm", true)]
    public class FireTower : Tower
    {
        public FireTower(Game game, GamePlayScreen gamePlayScreen, List<Creep> creeps, Vector2 position, string name)
            : base(game, gamePlayScreen, creeps, position, name) {}

// ReSharper disable RedundantOverridenMember
        public override void Initialize()
        {
            base.Initialize();
        }
// ReSharper restore RedundantOverridenMember
    }
}