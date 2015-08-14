//using VosSoft.Xna.GameConsole;

//namespace PathDefence.Screens
//{
//    public partial class GamePlayScreen
//    {
//        public GameConsole Console { get; private set; }

//        private void InitializeConsole()
//        {
//            Console.AddCommand("build", BuildTower, true, new[] {"", "", ""});
//            Console.AddCommand("nextwave", NextWave, true, new[] {"", "", ""});
//            Console.AddCommand("killcreeps", KillCreeps, true, new[] {"", "", ""});
//            Console.AddCommand("addmoney", AddMoney, true, new[] {"", "", ""});
//            Console.AddCommand("remove", RemoveTower, true, new[] {"", "", ""});
//        }

//        private void BuildTower(object obj, CommandEventArgs com)
//        {
//            if (com.Args.Length == 1)
//            {
//                if (!TowerManager.IsBuildMode)
//                {
//                    if (!TowerManager.StartTowerBuildMode(com.Args[0]))
//                    {
//                        Console.Log("error while building, cancelling buildmode", 1);
//                        TowerManager.CancelBuildMode();
//                    }
//                }
//                else
//                {
//                    Console.Log("already building a tower!", 1);
//                }
//            }
//        }

//        private void NextWave(object obj, CommandEventArgs com)
//        {
//            int tmp;
//            if (com.Args.Length == 1)
//            {
//                if (!int.TryParse(com.Args[0], out tmp))
//                {
//                    Console.Log("wrong input format", 1);
//                    return;
//                }
//            }
//            else
//            {
//                tmp = 1;
//            }
//            for (int i = 0; i < tmp; i++)
//            {
//                StartNextWave();
//            }
//        }

//        private void KillCreeps(object obj, CommandEventArgs com)
//        {
//            foreach (var creep in CreepList)
//            {
//                creep.Kill();
//            }
//        }

//        private void AddMoney(object obj, CommandEventArgs com)
//        {
//            MoneyManager.AddMoney(100000);
//            Console.Log(string.Format("money: {0}",MoneyManager.Money));
//        }

//        private void RemoveTower(object obj, CommandEventArgs com)
//        {
//            if (TowerManager.RemoveTower()) {}
//            else {}
//        }
//    }
//}
