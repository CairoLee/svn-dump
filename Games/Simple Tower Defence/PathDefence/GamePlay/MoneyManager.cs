using System;
using PathDefence.Screens;

namespace PathDefence.GamePlay
{
    //Diese Klasse kümmert sich um die Verwaltung des Geldes.
    public class MoneyManager
    {
        private readonly PathDefenceGame CurrGame;
        private readonly GamePlayScreen GamePlayScreen;

        private double money;

        public MoneyManager(PathDefenceGame game, GamePlayScreen screen)
        {
            CurrGame = game;
            GamePlayScreen = screen;
        }

        public double Money
        {
            get { return money; }
            private set
            {
                money = value;
                GamePlayScreen.ChangeInformation();
                if (MoneyChanged != null)
                    MoneyChanged(Money);
            }
        }

        public event Action<double> MoneyChanged;

        public void Initialize()
        {
            //Startgeld
            Money = 1000;
        }

        public bool CanBuy(double price)
        {
            return ((int) price) <= Money;
        }

        public void Buy(double price)
        {
            Money -= (int) price;
        }

        public void AddMoney(double amount)
        {
            if (((int) amount) > 0)
            {
                Money += (int) amount;
            }
        }
    }
}