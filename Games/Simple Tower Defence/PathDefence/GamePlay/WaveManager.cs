using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using PathDefence.Screens;
using System.Windows.Forms;
using System.Diagnostics;

namespace PathDefence.GamePlay {
	public class WaveManager {
		private readonly PathDefenceGame CurrGame;
		private readonly GamePlayScreen GamePlayScreen;
		private readonly string Path;
		private int healthNiveau;
		private int LastHealth;
		private Timer WaveTimer;
		private Stopwatch WaveWatch;

		private int wave;

		private XElement WavesNode;
		private int WaitingTime;

		public int Wave {
			get { return wave; }
			private set {
				wave = value;
				GamePlayScreen.ChangeInformation();
			}
		}

		public int HealthNiveau { get { return healthNiveau; } }
		public int RealWave { get; private set; }

		public int TimeLeftNextWave {
			get {
				if (WaveWatch != null)
					return WaitingTime - (int)WaveWatch.ElapsedMilliseconds;
				return 0;
			}
		}

		public WaveManager(Game game, GamePlayScreen screen, string level) {
			CurrGame = (PathDefenceGame)game;
			Path = "Content/Map/" + level + ".xml";
			GamePlayScreen = screen;
		}

		public void Initialize() {
			var xml = XDocument.Load(Path);
			WavesNode = xml.Root.Element("Waves");
			Wave = 0;
			RealWave = 0;
			healthNiveau = 0;
			WaveWatch = new Stopwatch();
			WaveTimer = new Timer { Interval = 200 };
			WaveTimer.Tick += WaveTimer_Tick;
			GetWaitingTime();
			StartAutoWave();
		}

		public void StartAutoWave() {
			WaveWatch.Start();
			WaveTimer.Start();
		}

		public void StopAutoWave() {
			WaveTimer.Stop();
			WaveWatch.Stop();
		}

		private void WaveTimer_Tick(object sender, EventArgs e) {
			if (WaveWatch.ElapsedMilliseconds > WaitingTime) {
				GamePlayScreen.StartNextWave();
			}
			GamePlayScreen.ChangeInformation();
		}

		private void GetWaitingTime(int NextWave) {
			var waveNode = WavesNode.Element("Wave" + NextWave);
			if (waveNode != null) {
				WaitingTime = int.Parse(waveNode.Attribute("WaitTime").Value);
			} else {
				GetWaitingTime(0);
			}
		}

		private void GetWaitingTime() {
			GetWaitingTime(Wave);
		}

		public List<Creep> GetNextWaveCreeps() {
			var result = new List<Creep>();
			var waveNode = WavesNode.Element("Wave" + Wave);
			if (waveNode != null) {
				Queue<int> positions = GenerateRandomList(100);
				foreach (var creep in waveNode.Elements()) {
					int health = int.Parse(creep.Attribute("Health").Value) + healthNiveau;
					LastHealth = health;
					int speed = int.Parse(creep.Attribute("Speed").Value);
					string texture = creep.Attribute("Texture").Value;
					var tmpCreep = new Creep(CurrGame, GamePlayScreen, texture, health, speed, new Vector2(0, positions.Dequeue()));
					tmpCreep.Initialize();
					result.Add(tmpCreep);
				}
				Wave++;
				RealWave++;
				GetWaitingTime();
			} else {
				healthNiveau = LastHealth;
				LastHealth = 0;
				Wave = 0;
				result = GetNextWaveCreeps();
				WaveWatch = Stopwatch.StartNew();
				return result;
			}
			WaveWatch = Stopwatch.StartNew();
			return result;
		}

		public static Queue<int> GenerateRandomList(int count) {
			var result = new Queue<int>();
			var rnd = new Random();
			var table = new Hashtable();
			while (count > 0) {
				int tmp = rnd.Next((int)LevelManager.GridCount.Y);
				if (!table.ContainsKey(tmp)) {
					table.Add(tmp, null);
					result.Enqueue(tmp);
					count--;
				}
				if (table.Count % 32 == 0) {
					table.Clear();
				}
			}
			return result;
		}
	}
}