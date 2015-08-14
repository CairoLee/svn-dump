using System.Collections.Generic;
using BaseTower;
using Microsoft.Xna.Framework;
using PathDefence.GamePlay;
using PathDefence.Screens;
using TowerInterface;

namespace HealthTower
{
    [TowerKey("HealthTower", "Heilungsturm", true)]
    class HealthTower : Tower
    {
        private float HealthTime;
        private int HealthAmount;
        private double HealthTimer;

        public HealthTower(Game game, GamePlayScreen gamePlayScreen, List<Creep> creeps, Vector2 pathPos, string name) :
            base(game, gamePlayScreen, creeps, pathPos, name) { }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override Shot CreateShotInstance()
        {
            return null;
        }

        protected override void ReadCustomAtrributes() {
			HealthTime = float.Parse(Attributes.Element("HealthTime").Attribute("Value").Value);
			HealthAmount = int.Parse(Attributes.Element("HealthAmount").Attribute("Value").Value);
        }

        private void SetHealthTime(double amount)
        {
            HealthTime = (float)amount;
        }

        private void SetHealthAmount(double amount)
        {
            HealthAmount = (int)amount;
        }

        private double GetHealthTime()
        {
            return HealthTime;
        }

        private double GetHealthAmount()
        {
            return HealthAmount;
        }

        private double GetHealthPerSecond()
        {
            return HealthAmount / (HealthTime / 1000);
        }

        protected override void GenerateAccessToCustomProperties()
        {
            SetProperties.Add("healthtime", SetHealthTime);
            SetProperties.Add("healthamount", SetHealthAmount);

            GetProperties.Add("healthtime", GetHealthTime);
            GetProperties.Add("healthamount", GetHealthAmount);
            GetProperties.Add("healthpersecond", GetHealthPerSecond);
        }

        protected override void AddCustomPropertiesToInfoWindow()
        {
            CustomProperties.Add(new ShowableProperty { Name = "Gesundheitszeit", PropertyName = "healthtime" });
            CustomProperties.Add(new ShowableProperty { Name = "Gesundheitsplus", PropertyName = "healthamount" });
            CustomProperties.Add(new ShowableProperty { Name = "Gesundheit/Sekunde", PropertyName = "healthpersecond" });
        }

        protected override void CustomUpdate(GameTime gameTime)
        {
            if (GamePlayScreen.Creeps.Count > 0)
            {
                if (HealthTimer > HealthTime)
                {
                    HealthTimer = 0;
                    GamePlayScreen.LiveManager.AddHealth(HealthAmount);
                }
                else
                {
                    HealthTimer += gameTime.ElapsedGameTime.TotalMilliseconds;
                }
            }
        }
    }
}
