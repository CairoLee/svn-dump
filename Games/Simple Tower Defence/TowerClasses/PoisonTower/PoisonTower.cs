using System.Collections.Generic;
using BaseTower;
using Microsoft.Xna.Framework;
using PathDefence.GamePlay;
using PathDefence.Screens;
using TowerInterface;

namespace PoisonTower
{
    [TowerKey("PoisonTower", "Giftturm", true)]
    class PoisonTower : Tower
    {
        private float PoisonTime;
        private int PoisonAmount;
        private float PoisonCounterTime;

        private Dictionary<Creep, float> PoisonTimes;
        private Dictionary<Creep, int> PoisonValues;
        private Dictionary<Creep, float> PoisonCounterTimes;
        private Dictionary<Creep, float> PoisonTimers;

        public PoisonTower(Game game, GamePlayScreen gamePlayScreen, List<Creep> creeps, Vector2 pathPos, string name) :
            base(game, gamePlayScreen, creeps, pathPos, name) { }

        public override void Initialize()
        {
            base.Initialize();
            PoisonValues = new Dictionary<Creep, int>();
            PoisonTimes = new Dictionary<Creep, float>();
            PoisonCounterTimes = new Dictionary<Creep, float>();
            PoisonTimers = new Dictionary<Creep, float>();
        }

        protected override Shot CreateShotInstance()
        {
            return new PoisonShot(CurrGame, this, Target, CreepList, Position, ShotTextureName, ShotSpeed, Damage, PoisonTime,
                                  PoisonAmount, PoisonCounterTime);
        }

        protected override Creep SelectTarget(List<CreepDescriptor> availableTargets)
        {
            if (availableTargets.Count == 0)
                return null;
            foreach (var availableTarget in availableTargets)
            {
                if (!PoisonValues.ContainsKey(availableTarget.Creep))
                    return availableTarget.Creep;
            }
            return availableTargets[0].Creep;
        }

        protected override void CustomUpdate(GameTime gameTime)
        {
            if (Target != null && PoisonValues.ContainsKey(Target))
                Target = null;
        }

        public void CustomCreepUpdate(Creep creep, GameTime gameTime)
        {
            float time = PoisonTimes[creep];
            int value = PoisonValues[creep];
            float counter = PoisonCounterTimes[creep];
            float timer = PoisonTimers[creep];
            if (time > 0)
            {
                time -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (time <= 0)
                {
                    creep.CustomUpdate -= CustomCreepUpdate;
                    PoisonValues.Remove(creep);
                    PoisonTimes.Remove(creep);
                    PoisonTimers.Remove(creep);
                    PoisonCounterTimes.Remove(creep);
                    return;
                }
                if (timer >= counter)
                {
                    timer = 0;
                    creep.Hit(value);
                }
                else
                {
                    timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                }
                PoisonTimes[creep] = time;
                PoisonTimers[creep] = timer;
            }

        }

        private void SetPoisonValue(int value, Creep creep)
        {
            if (!PoisonValues.ContainsKey(creep))
            {
                PoisonValues.Add(creep, 0);
            }
            PoisonValues[creep] = value;
        }

        private void SetPoisonTime(float value, Creep creep)
        {
            if (!PoisonTimes.ContainsKey(creep))
            {
                PoisonTimes.Add(creep, 0);
            }
            PoisonTimes[creep] = value;
        }

        private void SetPoisonCounterTime(float value, Creep creep)
        {
            if (!PoisonCounterTimes.ContainsKey(creep))
            {
                PoisonCounterTimes.Add(creep, 0);
            }
            PoisonCounterTimes[creep] = value;
        }

        private void SetPoisonTimer(float value, Creep creep)
        {
            if (!PoisonTimers.ContainsKey(creep))
            {
                PoisonTimers.Add(creep, 0);
            }
            PoisonTimers[creep] = value;
        }

        public void PoisonCreep(float time, int value, float counterTime, Creep creep)
        {
            SetPoisonTime(time, creep);
            SetPoisonValue(value, creep);
            SetPoisonCounterTime(counterTime, creep);
            SetPoisonTimer(0,creep);
        }

        protected override void ReadCustomAtrributes() {
			PoisonTime = float.Parse(Attributes.Element("PoisonTime").Attribute("Value").Value);
			PoisonAmount = int.Parse(Attributes.Element("PoisonAmount").Attribute("Value").Value);
			PoisonCounterTime = float.Parse(Attributes.Element("PoisonCounterTime").Attribute("Value").Value);
        }

        private void SetPoisonTime(double amount)
        {
            PoisonTime = (float)amount;
        }

        private void SetPoisonAmount(double amount)
        {
            PoisonAmount = (int)amount;
        }

        private void SetDotCounterTime(double amount)
        {
            PoisonCounterTime = (float)amount;
        }

        private double GetPoisonTime()
        {
            return PoisonTime;
        }

        private double GetPoisonAmount()
        {
            return PoisonAmount;
        }

        private double GetDotCounterTime()
        {
            return PoisonCounterTime;
        }

        private double GetDamageOverall()
        {
            return ((int)(PoisonTime / PoisonCounterTime)) * PoisonAmount;
        }

        protected override void GenerateAccessToCustomProperties()
        {
            SetProperties.Add("poisontime", SetPoisonTime);
            SetProperties.Add("poisonamount", SetPoisonAmount);
            SetProperties.Add("poisoncountertime", SetDotCounterTime);

            GetProperties.Add("poisontime", GetPoisonTime);
            GetProperties.Add("poisonamount", GetPoisonAmount);
            GetProperties.Add("poisoncountertime", GetDotCounterTime);
            GetProperties.Add("damageoverall", GetDamageOverall);
        }

        protected override void AddCustomPropertiesToInfoWindow()
        {
            CustomProperties.Add(new ShowableProperty { Name = "Vergiftungszeit", PropertyName = "poisontime", Hint = "Diese Zeit bleibt der Gegner vergiftet" });
            CustomProperties.Add(new ShowableProperty { Name = "Giftschaden", PropertyName = "poisonamount", Hint = "Dieser Wert ist der Angriffswert des Giftes" });
            CustomProperties.Add(new ShowableProperty { Name = "Gift-Intervall", PropertyName = "poisoncountertime", Hint = "Nach dieser Zeit (in Millisekunden)\ngreift das Gift den Gegner an" });
            CustomProperties.Add(new ShowableProperty { Name = "Gesamtschaden", PropertyName = "damageoverall", Hint = "Das ist der Schaden, der dem\nGegner insgesamt zugeführt wird." });
        }
    }
}