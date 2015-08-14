using System.Collections.Generic;
using BaseTower;
using Microsoft.Xna.Framework;
using PathDefence.GamePlay;
using PathDefence.Screens;
using TowerInterface;

namespace MassiveTower
{
    [TowerKey("MassiveTower", "Kolossturm", true)]
    class MassiveTower : Tower
    {
        private float ShotCostMultiplier;

        public MassiveTower(Game game, GamePlayScreen gamePlayScreen, List<Creep> creeps, Vector2 pathPos, string name) :
            base(game, gamePlayScreen, creeps, pathPos, name) { }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override Shot CreateShotInstance()
        {
            float price = Damage * ShotCostMultiplier;
            if (GamePlayScreen.MoneyManager.CanBuy(price))
            {
                GamePlayScreen.MoneyManager.Buy(price);
                return base.CreateShotInstance();
            }
            return null;
        }

        protected override void ReadCustomAtrributes() {
			ShotCostMultiplier = float.Parse(Attributes.Element("ShotCostMultiplier").Attribute("Value").Value);
        }

        private void SetShotCostMultiplier(double amount)
        {
            ShotCostMultiplier = (float)amount;
        }

        private double GetShotCostMultiplier()
        {
            return ShotCostMultiplier;
        }

        private double GetCostPerShot()
        {
            return Damage * ShotCostMultiplier;
        }

        protected override void GenerateAccessToCustomProperties()
        {
            SetProperties.Add("shotcostmultiplier", SetShotCostMultiplier);
            GetProperties.Add("shotcostmultiplier", GetShotCostMultiplier);
            GetProperties.Add("costpershot",GetCostPerShot);
        }

        protected override void AddCustomPropertiesToInfoWindow()
        {
            CustomProperties.Add(new ShowableProperty { Name = "Kostenmultiplikator", PropertyName = "shotcostmultiplier"});
            CustomProperties.Add(new ShowableProperty { Name = "Kosten pro Schuss", PropertyName = "costpershot", Hint = "Kosten pro Schuss: Multiplikator * Schaden" });
        }
    }
}