using System;
using System.Collections.Generic;
using System.Linq;
using TomShane.Neoforce.Controls;

namespace PathDefence.InGameGui
{
    public partial class GuiManager
    {
        private int CheckSum;
        private Dictionary<string, Use> Commands;
        private bool developMode = true;
        private int LogLevel = 1;
        private bool WaitingForPassword;

        private bool DevelopMode
        {
            get
            {
                if (!developMode)
                {
                    Log("Entwicklungsmodus nicht aktiviert. Um Entwicklungs-Kommandos zu nutzen, bitte aktivieren", 2);
                }
                return developMode;
            }
        }

        private void LoadConsoleCommands()
        {
            Commands = new Dictionary<string, Use>
                           {
                               {"develop", ActivateDevelopMode},
                               {"exit", Exit},
                               {"addmoney", AddMoney},
                               {"help", Help},
                               {"setloglevel", SetLogLevel},
                               {"addhealth",AddHealth},
                               {"crash", CrashApp}
                           };
        }

        private void Console_MessageSent(object sender, ConsoleMessageEventArgs e)
        {
            List<string> Params = e.Message.Text.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = Params[0];
            if (Commands.ContainsKey(command.ToLower()))
            {
                Params.RemoveAt(0);
                Commands[command.ToLower()](Params);
            }
            else
            {
                Log(string.Format("Befehl {0} nicht gefunden. \"Help\" listet alle verfügbaren Befehle auf.", command),
                    2);
            }
        }

        public void Log(string msg, byte channel, int level)
        {
            if (level <= LogLevel)
                Console.MessageBuffer.Add(new ConsoleMessage(msg, channel));
        }

        public void Log(string msg, byte channel)
        {
            Log(msg, channel, 1);
        }

        public void DebugLog(string msg)
        {
            Log(msg, 0, 2);
        }

        private void ActivateDevelopMode(List<string> Params)
        {
            if (developMode)
            {
                ChangeDevelopMode();
                return;
            }
            if (!WaitingForPassword)
            {
                CheckSum = CreateChecksum();
                WaitingForPassword = true;
            }
            else
            {
                if (Params.Count == 1)
                {
                    if (Params[0] == CheckSum.ToString())
                    {
                        Log("Passwort korrekt!", 0);
                        ChangeDevelopMode();
                    }
                    else
                    {
                        Log("Passwort falsch!", 2);
                    }
                    WaitingForPassword = false;
                }
                else
                {
                    WaitingForPassword = false;
                }
            }
        }

        private int CreateChecksum()
        {
            int result = 0;
            var rnd = new Random();
            int tmp = rnd.Next(1000);
            Log(tmp.ToString(), 0);
            Log("Bitte Passwort eingeben (\"develop passwort\")", 0);
            foreach (char s in tmp.ToString())
            {
                result += Convert.ToInt32(s.ToString());
            }
            result += DateTime.Now.Hour;
            return result;
        }

        private void ChangeDevelopMode()
        {
            developMode = !developMode;
            Log("Entwicklungsmodus: " + (developMode ? "an" : "aus"), 0);
        }

        private void Exit(List<string> Params)
        {
            CurrGame.Exit();
        }

        private void AddMoney(List<string> Params)
        {
            if (DevelopMode)
            {
                GamePlayScreen.MoneyManager.AddMoney(10000000);
                Log(string.Format("Geld: {0}", GamePlayScreen.MoneyManager.Money), 0);
            }
        }

        private void CrashApp(List<string> Params)
        {
            if (DevelopMode)
            {
                throw new Exception("Absichtliche Exception! Kein Grund zur Sorge.");
            }
        }

        private void AddHealth(List<string> Params)
        {
            if (DevelopMode)
            {
                GamePlayScreen.LiveManager.AddHealth(10000000);
                Log(string.Format("Energie: {0}", GamePlayScreen.LiveManager.Health), 0);
            }
        }

        private void Help(List<string> Params)
        {
            Log("\"develop\": Aktivert den Entwicklungsmodus mit Zugang zu neuen Funktionen", 0);
            Log("\"exit\": Beendet das Spiel", 0);
            Log("\"help\": Listet alle Befehle mit Beschreibung auf", 0);
            Log("\"addmoney\": Fügt dem Konto 100000 Geld hinzu", 0);
            Log("\"addhealth\": Fügt dem Spieler 10000 Energie hinzu", 0);
            Log("\"crash\": Lässt das Spiel absichtlich abstürzen um das Fehler System zu testen", 0);
            Log("\"setloglevel\": Ändert das Loglevel der Console", 0);
        }

        private void SetLogLevel(List<string> Params)
        {
            int level;
            if (Params.Count == 1 && int.TryParse(Params[0], out level))
            {
                LogLevel = level;
            }
        }

        #region Nested type: Use

        private delegate void Use(List<string> Params);

        #endregion
    }
}