using System.Collections.Generic;
using BaseTower;
using Microsoft.Xna.Framework;
using PathDefence.GamePlay;
using TowerInterface;

namespace FreezeTower
{
    [TowerKey("FreezeShot", "Freezeshot", false)]
    internal class FreezeShot : Shot
    {
        private readonly float FreezePercentage;
        private readonly float FreezeTime;
        private new readonly FreezeTower Parent;

        public FreezeShot(Game game, Tower parent, Creep target, List<Creep> creeps, Vector2 position,
                          string shotTextName, float speed, float damage, float percentage, float time)
            : base(game, parent, target, creeps, position, shotTextName, speed, damage)
        {
            FreezePercentage = percentage;
            FreezeTime = time;
            Parent = (FreezeTower) parent;
        }

        protected override void HitTarget()
        {
            Parent.FreezeCreep(FreezeTime,FreezePercentage,Target);

            Target.CustomUpdate -= Parent.CustomCreepUpdate;
            Target.CustomUpdate += Parent.CustomCreepUpdate;
            base.HitTarget();
        }
    }
}