using System.Collections.Generic;
using BaseTower;
using Microsoft.Xna.Framework;
using PathDefence.GamePlay;
using PathDefence.Screens;
using TowerInterface;

namespace PercentageTower
{
    [TowerKey("PercentageTower", "Prozentualturm", true)]
    class PercentageTower : Tower
    {
        private float Percentage;
        private bool ShotMade;

        public PercentageTower(Game game, GamePlayScreen gamePlayScreen, List<Creep> creeps, Vector2 pathPos, string name) :
            base(game, gamePlayScreen, creeps, pathPos, name) { }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override Shot CreateShotInstance()
        {
            ShotMade = true;
            return new PercentageShot(CurrGame, this, Target, CreepList, Position, ShotTextureName, ShotSpeed, Percentage);
        }

        protected override Creep SelectTarget(List<CreepDescriptor> availableTargets)
        {
            float highestHealth = -1;
            Creep bestCreep = null;
            foreach (var availableTarget in availableTargets)
            {
                if (availableTarget.Creep.Health > highestHealth)
                {
                    highestHealth = availableTarget.Creep.Health;
                    bestCreep = availableTarget.Creep;
                }
            }
            return bestCreep;
        }

        protected override void CustomUpdate(GameTime gameTime)
        {
            if(ShotMade)
            {
                Target = null;
                ShotMade = false;
            }
        }

        protected override void ReadCustomAtrributes() {
			Percentage = float.Parse(Attributes.Element("Percentage").Attribute("Value").Value);
        }

        private void SetPercentage(double amount)
        {
            Percentage = (float)amount;
        }

        private double GetPercentage()
        {
            return Percentage;
        }

        protected override void GenerateAccessToCustomProperties()
        {
            SetProperties.Add("percentage", SetPercentage);
            GetProperties.Add("percentage", GetPercentage);
        }

        protected override void AddCustomPropertiesToInfoWindow()
        {
            CustomProperties.Add(new ShowableProperty { Name = "Schadens-Prozentsatz", PropertyName = "percentage",Hint = "Der Turm zieht dem Gegner so viel Prozent an Energie ab."});
        }
    }
}