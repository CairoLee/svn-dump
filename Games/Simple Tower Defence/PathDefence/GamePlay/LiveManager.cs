using Microsoft.Xna.Framework;
using PathDefence.Screens;

namespace PathDefence.GamePlay
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class LiveManager
    {
        private readonly GamePlayScreen GamePlayScreen;
        private PathDefenceGame CurrGame;

        private int health;

        public LiveManager(Game game, GamePlayScreen gamePlayScreen)
        {
            CurrGame = (PathDefenceGame) game;
            GamePlayScreen = gamePlayScreen;
        }

        public int Health
        {
            get { return health; }
            private set
            {
                health = value;
                GamePlayScreen.ChangeInformation();
            }
        }

        public void Initialize()
        {
            Health = GamePlayScreen.LevelManager.GetLevelHealth();
        }

        public void CreepOut(int dHealth)
        {
            Health -= dHealth;
            if (Health <= 0)
            {
                health = 0;
                GamePlayScreen.GameOver(EGameOverReason.Dead);
            }
            GamePlayScreen.ChangeInformation();
        }

        public void AddHealth(int amount)
        {
            Health += amount;
        }
    }
}