using System.Collections.Generic;
using BaseTower;
using Microsoft.Xna.Framework;
using PathDefence.GamePlay;
using PathDefence.Screens;
using TowerInterface;

namespace MoneyTower
{
    [TowerKey("MoneyTower", "Geldgenerator", true)]
    class MoneyTower : Tower
    {
        private float MoneyTime;
        private int MoneyAmount;
        private double MoneyTimer;

        public MoneyTower(Game game, GamePlayScreen gamePlayScreen, List<Creep> creeps, Vector2 pathPos, string name) :
            base(game, gamePlayScreen, creeps, pathPos,name) { }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override Shot CreateShotInstance()
        {
            return null;
        }

        private void SetMoneyTime(double amount)
        {
            MoneyTime = (float) amount;
        }

        private void SetMoneyAmount(double amount)
        {
            MoneyAmount = (int) amount;
        }

        private double GetMoneyTime()
        {
            return MoneyTime;
        }

        private double GetMoneyAmount()
        {
            return MoneyAmount;
        }

        private double GetMoneyPerSecond()
        {
            return MoneyAmount / (MoneyTime / 1000);
        }

        protected override void ReadCustomAtrributes() {
			MoneyTime = float.Parse(Attributes.Element("MoneyTime").Attribute("Value").Value);
			MoneyAmount = int.Parse(Attributes.Element("MoneyAmount").Attribute("Value").Value);
        }

        protected override void GenerateAccessToCustomProperties()
        {
            SetProperties.Add("moneytime",SetMoneyTime);
            SetProperties.Add("moneyamount",SetMoneyAmount);
            GetProperties.Add("moneytime", GetMoneyTime);
            GetProperties.Add("moneyamount", GetMoneyAmount);
            GetProperties.Add("moneypersecond", GetMoneyPerSecond);
        }

        protected override void AddCustomPropertiesToInfoWindow()
        {
            CustomProperties.Add(new ShowableProperty { Name = "Geldzeit", PropertyName = "moneytime" });
            CustomProperties.Add(new ShowableProperty { Name = "Geldplus", PropertyName = "moneyamount" });
            CustomProperties.Add(new ShowableProperty { Name = "Geld/Sekunde", PropertyName = "moneypersecond" });
        }

        protected override void CustomUpdate(GameTime gameTime)
        {
            if (GamePlayScreen.Creeps.Count > 0)
            {
                if (MoneyTimer > MoneyTime)
                {
                    MoneyTimer = 0;
                    GamePlayScreen.MoneyManager.AddMoney(MoneyAmount);
                }
                else
                {
                    MoneyTimer += gameTime.ElapsedGameTime.TotalMilliseconds;
                }
            }
        }
    }
}