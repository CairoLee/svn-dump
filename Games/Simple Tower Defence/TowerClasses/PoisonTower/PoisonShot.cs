using System.Collections.Generic;
using BaseTower;
using Microsoft.Xna.Framework;
using PathDefence.GamePlay;

namespace PoisonTower
{
    [TowerInterface.TowerKey("PoisonShot","Giftshot",false)]
    class PoisonShot:Shot
    {
        private readonly float Time;
        private readonly int Amount;
        private readonly float CounterTime;
        private new readonly PoisonTower Parent;

        public PoisonShot(Game game, Tower parent, Creep target, List<Creep> creeps, 
            Vector2 position, string shotTextName, float speed, float damage,
            float time, int amount, float counterTime) : 
            base(game, parent, target, creeps, position, shotTextName, speed, damage)
        {
            Time = time;
            Amount = amount;
            CounterTime = counterTime;
            Parent = (PoisonTower) parent;
        }

        protected override void HitTarget()
        {
            Parent.PoisonCreep(Time, Amount, CounterTime, Target);

            Target.CustomUpdate -= Parent.CustomCreepUpdate;
            Target.CustomUpdate += Parent.CustomCreepUpdate;

            base.HitTarget();
        }
    }
}
