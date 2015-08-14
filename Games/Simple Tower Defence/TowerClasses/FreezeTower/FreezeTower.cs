using System.Collections.Generic;
using BaseTower;
using Microsoft.Xna.Framework;
using PathDefence.GamePlay;
using PathDefence.Screens;
using TowerInterface;

namespace FreezeTower
{
    [TowerKey("FreezeTower", "Freezeturm", true)]
    public class FreezeTower : Tower
    {
        private float FreezePercentage;
        private float FreezeTime;

        private Dictionary<Creep, float> FreezeValues { get; set; }
        private Dictionary<Creep, float> FreezeTimes { get; set; }
        private List<Creep> FrozenCreeps;

        public FreezeTower(Game game, GamePlayScreen gamePlayScreen, List<Creep> creeps, Vector2 position, string name)
            : base(game, gamePlayScreen, creeps, position, name) { }

        public override void Initialize()
        {
            base.Initialize();
            FreezeValues = new Dictionary<Creep, float>();
            FreezeTimes = new Dictionary<Creep, float>();
            FrozenCreeps = new List<Creep>();
        }

        protected override Shot CreateShotInstance()
        {
            var shot = new FreezeShot(CurrGame, this, Target, CreepList, Position, ShotTextureName, ShotSpeed, Damage,
                                      FreezePercentage, FreezeTime);
            shot.Initialize();
            return shot;
        }

        protected override Creep SelectTarget(List<CreepDescriptor> availableTargets)
        {
            if (availableTargets.Count == 0)
                return null;
            foreach (var availableTarget in availableTargets)
            {
                if (!FreezeTimes.ContainsKey(availableTarget.Creep))
                    return availableTarget.Creep;
            }
            return null;
        }

        protected override void CustomUpdate(GameTime gameTime)
        {
            if (Target != null && FreezeTimes.ContainsKey(Target))
                Target = null;
        }

        public void CustomCreepUpdate(Creep creep, GameTime gameTime)
        {
            double freezeTime = FreezeTimes[creep];
            float freezeValue = FreezeValues[creep];

            if (freezeTime > 0)
            {
                if (creep.InitialSpeed * freezeValue < creep.Speed)
                {
                    creep.Speed = creep.InitialSpeed * freezeValue;
                }
                freezeTime -= gameTime.ElapsedGameTime.TotalMilliseconds;
                FreezeTimes[creep] = (float)freezeTime;
                if (freezeTime <= 0)
                {
                    RestoreCreepSpeed(creep);
                    creep.CustomUpdate -= CustomCreepUpdate;
                    FreezeValues.Remove(creep);
                    FreezeTimes.Remove(creep);
                    FrozenCreeps.Remove(creep);
                }
            }
        }

        private void SetFreezeValue(float value, Creep creep)
        {
            if (!FreezeValues.ContainsKey(creep))
            {
                FreezeValues.Add(creep, 0);
            }
            FreezeValues[creep] = value;
        }

        private void SetFreezeTime(float value, Creep creep)
        {
            if (!FreezeTimes.ContainsKey(creep))
            {
                FreezeTimes.Add(creep, 0);
            }
            FreezeTimes[creep] = value;
        }

        public void FreezeCreep(float time, float value, Creep creep)
        {
            SetFreezeTime(time,creep);
            SetFreezeValue(value,creep);
            if(!FrozenCreeps.Contains(creep))
                FrozenCreeps.Add(creep);
        }

        protected override void ReadCustomAtrributes()
        {
            FreezePercentage = float.Parse(Attributes.Element("FreezePercentage").Attribute("Value").Value);
			FreezeTime = float.Parse(Attributes.Element("FreezeTime").Attribute("Value").Value); 
        }

        private void SetFreezePercentage(double amount)
        {
            FreezePercentage = (float)amount;
        }

        private void SetFreezeTime(double amount)
        {
            FreezeTime = (float)amount;
        }

        private double GetFreezeTime()
        {
            return FreezeTime;
        }

        private double GetFreezePercentage()
        {
            return FreezePercentage;
        }

        private void RestoreCreepSpeed(Creep creep)
        {
            creep.Speed = creep.InitialSpeed;
        }

        public override void Sell()
        {
            foreach (var creep in FrozenCreeps)
            {
                RestoreCreepSpeed(creep);
            }
            base.Sell();
        }

        protected override void GenerateAccessToCustomProperties()
        {
            SetProperties.Add("freezepercentage", SetFreezePercentage);
            SetProperties.Add("freezetime", SetFreezeTime);
            GetProperties.Add("freezepercentage", GetFreezePercentage);
            GetProperties.Add("freezetime", GetFreezeTime);
        }

        protected override void AddCustomPropertiesToInfoWindow()
        {
            CustomProperties.Add(new ShowableProperty { Name = "Freeze-Zeit", PropertyName = "freezetime" });
            CustomProperties.Add(new ShowableProperty { Name = "Geschwindigkeit in %", PropertyName = "freezepercentage" });
        }
    }
}