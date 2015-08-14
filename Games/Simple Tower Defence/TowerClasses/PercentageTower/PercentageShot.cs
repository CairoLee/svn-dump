using System;
using System.Collections.Generic;
using BaseTower;
using Microsoft.Xna.Framework;
using PathDefence.GamePlay;
using TowerInterface;

namespace PercentageTower
{
    [TowerKey("PercentageShot", "Percentageshot", false)]
    class PercentageShot : Shot
    {
        private readonly float Percentage;

        public PercentageShot(Game game, Tower parent, Creep target, List<Creep> creeps, Vector2 position, string shotTextName, float speed, float percentage)
            : base(game, parent, target, creeps, position, shotTextName, speed, 0)
        {
            Percentage = percentage;
        }

        protected override void HitTarget()
        {
            Target.Hit((int)Math.Round(Target.Health * Percentage, MidpointRounding.AwayFromZero));
            base.HitTarget();
        }
    }
}
