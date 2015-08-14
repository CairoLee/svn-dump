using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using PathDefence.GamePlay;
using PathDefence.InGameGui;
using PathDefence.ScreenManagement;
using TowerInterface;

namespace PathDefence.Screens
{
    public class GamePlayScreen : GameScreen
    {
        private const int CreepInterval = 200;
        private readonly Queue<Creep> AddCreepList = new Queue<Creep>();
        private readonly List<Creep> CreepDeleteList = new List<Creep>();
        private readonly List<Creep> CreepList = new List<Creep>();
        private readonly Stopwatch CreepTimer = new Stopwatch();
        private readonly string levelName;
        private BackgroundGamePlayScreen Background;
        public PathDefenceGame CurrGame;
        private EGameState gameState;
        public GuiManager GuiManager;
        public LevelManager LevelManager;
        public LiveManager LiveManager;
        public PointsManager PointsManager;

        private bool StartWave;
        public TowerManager TowerManager;
        public WaveManager WaveManager;
        public new readonly ScreenManager ScreenManager;

        public GamePlayScreen(string level, ScreenManager manager)
        {
            TransitionOnTime = TimeSpan.FromSeconds(1.5);
            TransitionOffTime = TimeSpan.FromSeconds(0.5);
            levelName = level;
            ScreenManager = manager;
        }

        public int NumberOfCreeps
        {
            get { return CreepList.Count; }
        }

        public int CreepsLeft { get { return AddCreepList.Count; } }

        public float CreepHealth
        {
            get
            {
                float health = 0;
                foreach (Creep creep in CreepList)
                {
                    health += creep.Health;
                }
                return health < 0 ? 0 : health;
            }
        }

        public MoneyManager MoneyManager { get; private set; }

        public EGameState GameState
        {
            get { return gameState; }
        }

        public List<Creep> Creeps
        {
            get { return CreepList; }
        }

        public event Action InformationChanged;

        public void ChangeInformation()
        {
            if (InformationChanged != null)
                InformationChanged();
        }

        public override void LoadContent()
        {
            CurrGame = (PathDefenceGame)ScreenManager.Game;
            LevelManager = new LevelManager(CurrGame, this, levelName);
            LevelManager.Initialize();
            WaveManager = new WaveManager(CurrGame, this, levelName);
            WaveManager.Initialize();
            Background = new BackgroundGamePlayScreen(CurrGame, levelName);
            Background.Initialize();
            TowerManager = new TowerManager(CurrGame, this);
            TowerManager.Initialize();
            MoneyManager = new MoneyManager(CurrGame, this);
            MoneyManager.Initialize();
            LiveManager = new LiveManager(CurrGame, this);
            LiveManager.Initialize();
            PointsManager = new PointsManager();
            PointsManager.Initialize();

            GuiManager = new GuiManager(CurrGame, this);
            GuiManager.Initialize();
            CreepDeleteList.AddRange(CreepList);

            AddCreepList.Clear();

            CreepTimer.Start();

            gameState = EGameState.Running;
            CurrGame.IsMouseVisible = true;
            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            Background.Draw(gameTime);
            LevelManager.Draw(gameTime);
            TowerManager.Draw(gameTime);
            foreach (Creep creep in CreepList)
            {
                creep.Draw(gameTime);
            }
            GuiManager.Draw(gameTime);
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
            if (IsActive)
            {
                if (gameState == EGameState.Running)
                {
                    foreach (Creep creep in CreepList)
                    {
                        creep.Update(gameTime);
                    }

                    foreach (Creep creep in CreepDeleteList)
                    {
                        CreepList.Remove(creep);
                        ChangeInformation();
                    }
                    CreepDeleteList.Clear();

                    if (StartWave && (AddCreepList.Count > 0) && (CreepTimer.ElapsedMilliseconds >= CreepInterval))
                    {
                        AddCreep(AddCreepList.Dequeue());
                        CreepTimer.Reset();
                        CreepTimer.Start();
                        if (AddCreepList.Count == 0)
                        {
                            StartWave = false;
                        }
                        ChangeInformation();
                    }
                }

                TowerManager.Update(gameTime);
                GuiManager.Update(gameTime);
            }
        }

        public override void HandleInput(InputState input)
        {
            if (input.IsPauseGame(ControllingPlayer))
            {
                CurrGame.IsMouseVisible = false;
                ScreenManager.AddScreen(new PauseMenuScreen(), ControllingPlayer);
            }
            else
            {
                if (!CurrGame.IsMouseVisible)
                {
                    CurrGame.IsMouseVisible = true;
                }
            }
        }

        private void AddCreep(Creep creep)
        {
            creep.GridChanged(null);
            CreepList.Add(creep);
            ChangeInformation();
        }

        public void CreepOut(Creep creep)
        {
            if (creep.CreepState == CreepState.Out)
                LiveManager.CreepOut(creep.Health);
            if (creep.CreepState == CreepState.Killed)
            {
                double money = Math.Sqrt(creep.InitialHealth * creep.InitialSpeed);
                MoneyManager.AddMoney(money);
                PointsManager.AddPoints(creep.Points);
            }
            CreepDeleteList.Add(creep);
            ChangeInformation();
        }

        public void ChangeCreepGrid(ITower tower)
        {
            if (tower != null)
            {
                var waypoints = new List<Vector2>();
                for (int i = (int)tower.PathPosition.X - 1; i < tower.PathPosition.X + tower.PathSize.X - 1; i++)
                {
                    for (int j = (int)tower.PathPosition.Y - 1; j < tower.PathPosition.Y + tower.PathSize.Y - 1; j++)
                    {
                        waypoints.Add(new Vector2(i,j));
                    }
                }
                foreach (Creep creep in CreepList)
                {
                    creep.GridChanged(waypoints);
                }
            }
        }

        public bool CheckCreepWay(List<Vector2> newPoints)
        {
            bool Result = true;
            if (newPoints == null)
            {
                foreach (Creep creep in CreepList)
                {
                    if (!LevelManager.IsWayAvailable(creep.GridPosition))
                    {
                        Result = false;
                        break;
                    }
                }
            }
            else
            {
                foreach (var creep in CreepList)
                {
                    if(creep.IsVectorOnPath(newPoints))
                    {
                        if (!LevelManager.IsWayAvailable(creep.GridPosition))
                        {
                            Result = false;
                            break;
                        }
                    }
                }
            }
            return Result;
        }

        private void LoadNextWave()
        {
            foreach (Creep creep in WaveManager.GetNextWaveCreeps())
            {
                AddCreepList.Enqueue(creep);
            }
            ChangeInformation();
        }

        public void StartNextWave()
        {
            StartWave = true;
            LoadNextWave();
        }

        public void GameOver(EGameOverReason reason)
        {
            ChangeInformation();
            switch (reason)
            {
                case EGameOverReason.Dead:
                    WaveManager.StopAutoWave();
                    TowerManager.CancelBuildMode();
                    GuiManager.ShowGameOverWindow();
                    break;
                case EGameOverReason.Won:
                    break;
                case EGameOverReason.Cancelled:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("reason");
            }
        }

        public void StopGame()
        {
            ChangeInformation();
            gameState = EGameState.Paused;
            WaveManager.StopAutoWave();
        }

        public void StartGame()
        {
            ChangeInformation();
            gameState = EGameState.Running;
            WaveManager.StartAutoWave();
        }

        public void RestartLevel()
        {
            LoadContent();
        }
    }
}