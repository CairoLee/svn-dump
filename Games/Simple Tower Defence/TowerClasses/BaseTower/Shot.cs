using System.Collections.Generic;
using Microsoft.Xna.Framework;
using PathDefence;
using PathDefence.GamePlay;
using XNASimpleTemplates;

namespace BaseTower
{
    public class Shot : GameComponentBase<PathDefenceGame>
    {
        protected readonly float Damage;
        protected readonly Tower Parent;

        protected readonly float StandardSpeed;
        protected float Speed;
        protected readonly Creep Target;
        protected List<Creep> Creeps;
        protected Vector2 LastDir;

        protected ShotState ShotState;

        public Shot(Game game, Tower parent, Creep target, List<Creep> creeps, Vector2 position, string shotTextName,
                    float speed, float damage)
            : base(game)
        {
            Parent = parent;
            Creeps = creeps;
            Position = position;
            TextureName = shotTextName;
            TextureDirectory = "Tower/Textures/Shot/";
            Speed = speed;
            StandardSpeed = speed;
            Damage = damage;
            Target = target;
            ShotState = ShotState.Flying;
        }

        public override void Initialize()
        {
            SpriteBatch = CurrGame.SpriteBatch;
            OriginType = OriginType.Center;
            Size = new Vector2(20, 20);
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            if (ShotState == ShotState.TargetHit || ShotState == ShotState.Out)
            {
                DeleteShot();
            }
            else if (Target == null || Target.CreepState != CreepState.Running)
            {
                ShotState = ShotState.TargetLost;
            }
            else if ((ShotState == ShotState.Flying) && (Target.CreepState == CreepState.Running))
            {
                Vector2 dPos = Position - Target.Position;
                LastDir = dPos;
                double hyp = dPos.Length();
                if (hyp < 10)
                {
                    ShotState = ShotState.TargetHit;
                    HitTarget();
                }
                else
                {
                    double dHyp = hyp - (hyp - (Speed * gameTime.ElapsedGameTime.TotalSeconds * 10));
                    var newdPos = new Vector2((float)(dHyp / hyp) * dPos.X, (float)(dHyp / hyp) * dPos.Y);
                    Position = new Vector2(Position.X - newdPos.X, Position.Y - newdPos.Y);
                }
            }
            if (ShotState == ShotState.TargetLost)
            {
                double hyp = LastDir.Length();
                double dHyp = hyp - (hyp - (Speed * gameTime.ElapsedGameTime.TotalSeconds * 10));
                var newdPos = new Vector2((float)(dHyp / hyp) * LastDir.X, (float)(dHyp / hyp) * LastDir.Y);
                Position = new Vector2(Position.X - newdPos.X, Position.Y - newdPos.Y);
                foreach (var creep in Creeps)
                {
                    Vector2 dPos = Position - creep.Position;
                    double dist = dPos.Length();
                    if (dist < 10)
                    {
                        ShotState = ShotState.TargetHit;
                        creep.Hit((int)Damage);
                    }
                }
            }

            if ((Position.X < -50) || (Position.Y < -50) || (Position.X > CurrGame.CreepFieldWidth + 50) ||
                (Position.Y > CurrGame.CreepFieldHeight + 50))
            {
                ShotState = ShotState.Out;
            }

            base.Update(gameTime);
        }

        protected virtual void HitTarget()
        {
            Target.Hit((int)Damage);
        }

        private void DeleteShot()
        {
            Parent.DeleteShot(this);
        }
    }

    public enum ShotState
    {
        TargetHit,
        TargetLost,
        Flying,
        Out
    }
}