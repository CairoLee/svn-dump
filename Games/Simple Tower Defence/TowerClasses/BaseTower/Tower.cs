using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using PathDefence;
using PathDefence.GamePlay;
using PathDefence.Screens;
using TowerInterface;
using XNASimpleTemplates;

namespace BaseTower {
	public abstract class Tower : GameComponentBase<PathDefenceGame>, ITower {
		protected readonly List<Creep> CreepList;

		protected readonly GamePlayScreen GamePlayScreen;
		protected XElement Attributes;
		private XElement UpgradesNode;

		private string PropertyString;
		private List<Shot> ShotDeleteList;
		private float ShotInterval;
		private List<Shot> ShotList;
		protected float ShotSpeed;
		protected string ShotTextureName;
		private Stopwatch ShotTimer;

		protected Creep Target;
		private string TowerName;

		public float Price { get; protected set; }
		public float Range { get; protected set; }
		public float Damage { get; protected set; }
		public float Interval { get { return ShotInterval; } }
		public string Description { get; protected set; }
		public string Name { get; set; }
		public string Key { get; set; }

		public Vector2 PathPosition { get; protected set; }
		public Vector2 PathSize { get; protected set; }

		private Dictionary<string, Upgrade> AvailableUpgrades;
		public Dictionary<string, IUpgrade> PossibleUpgrades { get; private set; }
		private List<string> BoughtUpgrades;
		public Dictionary<string, PropertyChanger.Get> GetProperties { get; private set; }
		protected Dictionary<string, PropertyChanger.Set> SetProperties { get; private set; }
		public List<IShowableProperty> CustomProperties { get; private set; }

		protected Tower(Game game, GamePlayScreen gamePlayScreen, List<Creep> creeps, Vector2 pathPos, string name)
			: base(game) {
			GamePlayScreen = gamePlayScreen;
			PathPosition = pathPos;
			CreepList = creeps;
			Name = name;
		}

		private Vector2 MiddlePosition {
			get { return new Vector2(Position.X + Size.X / 2, Position.Y + Size.Y / 2); }
		}

		#region ITowerInterface Members
		public override void Initialize() {
			Assembly assembly = Assembly.GetCallingAssembly();
			foreach (Type towerClass in assembly.GetTypes()) {
				if (towerClass == GetType()) {
					foreach (TowerKey attribute in towerClass.GetCustomAttributes(true)) {
						TowerName = attribute.Key;
						break;
					}
				}
			}
			if (TowerName.Length < 1) {
				throw new Exception(string.Format("Für Turm {0} konnte kein Klassenname ermittlet werden!", GetType().Name));
			}
			PossibleUpgrades = new Dictionary<string, IUpgrade>();
			AvailableUpgrades = new Dictionary<string, Upgrade>();
			BoughtUpgrades = new List<string>();
			SetProperties = new Dictionary<string, PropertyChanger.Set>();
			GetProperties = new Dictionary<string, PropertyChanger.Get>();
			CustomProperties = new List<IShowableProperty>();
			PropertyString = TowerName + ".xml";
			ReadTowerAttributes();
			GenerateAccessToProperties();
			AddCustomPropertiesToInfoWindow();
			ReadAllUpgrades();
			TextureDirectory = "Tower/Textures/";
			SpriteBatch = CurrGame.SpriteBatch;
			Position = new Vector2((PathPosition.X - 1) * GamePlayScreen.LevelManager.GridSize.X,
								   (PathPosition.Y - 1) * GamePlayScreen.LevelManager.GridSize.Y);
			Size = new Vector2(PathSize.X * GamePlayScreen.LevelManager.GridSize.X,
							   PathSize.Y * GamePlayScreen.LevelManager.GridSize.Y);
			ShotList = new List<Shot>();
			ShotDeleteList = new List<Shot>();
			OriginType = OriginType.TopLeft;
			ShotTimer = Stopwatch.StartNew();

			base.Initialize();
		}

		public virtual void Sell() {
			GamePlayScreen.MoneyManager.AddMoney(Price * 0.75f);
			GamePlayScreen.TowerManager.RemoveTower(this);
		}

		public override void Draw(GameTime gameTime) {
			foreach (Shot shot in ShotList) {
				shot.Draw(gameTime);
			}
			base.Draw(gameTime);
		}

		public override void Update(GameTime gameTime) {
			if (Target == null || Target.CreepState != CreepState.Running || (Position - Target.Position).Length() > Range) {
				SearchTarget();
			} else {
				if (ShotTimer.ElapsedMilliseconds >= ShotInterval) {
					Shot shot = CreateShotInstance();
					if (shot != null) {
						shot.Initialize();
						ShotList.Add(shot);
						ShotTimer.Reset();
						ShotTimer.Start();
					}
				}
			}

			foreach (Shot shot in ShotList) {
				shot.Update(gameTime);
			}

			foreach (Shot shot in ShotDeleteList) {
				ShotList.Remove(shot);
			}
			ShotDeleteList.Clear();

			CustomUpdate(gameTime);

			base.Update(gameTime);
		}

		protected virtual void CustomUpdate(GameTime gameTime) { }

		#endregion

		public void DeleteShot(Shot shot) {
			ShotDeleteList.Add(shot);
		}

		private void SearchTarget() {
			var targets = new List<CreepDescriptor>();
			foreach (Creep creep in CreepList) {
				float dist = (MiddlePosition - creep.Position).Length();
				if (dist <= Range) {
					targets.Add(new CreepDescriptor { Creep = creep, Distance = dist });
				}
			}
			Target = SelectTarget(targets);
		}

		protected virtual Creep SelectTarget(List<CreepDescriptor> availableTargets) {
			float nearestDist = float.PositiveInfinity;
			Creep nearestCreep = null;
			foreach (var availableTarget in availableTargets) {
				if (availableTarget.Distance < nearestDist) {
					nearestDist = availableTarget.Distance;
					nearestCreep = availableTarget.Creep;
				}
			}
			return nearestCreep;
		}

		private void ReadTowerAttributes() {
			var xml = XDocument.Load(CurrGame.ApplicationDirectory + "\\Content\\Tower\\Properties\\" + PropertyString);
			Attributes = xml.Root.Element("Base");
			Range = int.Parse(Attributes.Element("Range").Attribute("Value").Value);
			TextureName = Attributes.Element("Texture").Attribute("Value").Value;
			Damage = float.Parse(Attributes.Element("Damage").Attribute("Value").Value);
			ShotInterval = float.Parse(Attributes.Element("Interval").Attribute("Value").Value);
			ShotSpeed = float.Parse(Attributes.Element("Speed").Attribute("Value").Value);
			int size = int.Parse(Attributes.Element("Size").Attribute("Value").Value);
			PathSize = new Vector2(size);
			ShotTextureName = Attributes.Element("ShotTexture").Attribute("Value").Value;
			Price = float.Parse(Attributes.Element("Price").Attribute("Value").Value);
			Description = Attributes.Element("Description").Attribute("Value").Value;
			ReadCustomAtrributes();
		}

		protected virtual void ReadCustomAtrributes() { }


		void ChangeDamage(double amount) {
			Damage = (int)amount;
		}

		void ChangeRange(double amount) {
			Range = (int)amount;
		}
		void ChangeSpeed(double amount) {
			ShotSpeed = (float)amount;
		}

		void ChangeInterval(double amount) {
			ShotInterval = (float)amount;
		}

		private void GenerateAccessToProperties() {
			SetProperties.Add("damage", ChangeDamage);
			SetProperties.Add("range", ChangeRange);
			SetProperties.Add("speed", ChangeSpeed);
			SetProperties.Add("interval", ChangeInterval);

			GenerateAccessToCustomProperties();
		}

		protected virtual void GenerateAccessToCustomProperties() { }

		protected virtual void AddCustomPropertiesToInfoWindow() { }

		protected virtual Shot CreateShotInstance() {
			var shot = new Shot(CurrGame, this, Target, CreepList, MiddlePosition, ShotTextureName, ShotSpeed, Damage);
			shot.Initialize();
			return shot;
		}

		private void ReadAllUpgrades() {

			var xml = XDocument.Load(CurrGame.ApplicationDirectory + "\\Content\\Tower\\Properties\\" + PropertyString);
			UpgradesNode = xml.Root.Element("Upgrades");

			var upgrades = UpgradesNode.Elements("Upgrade");

			foreach (var node in upgrades) {
				string name = node.Attribute("Name").Value;
				string key = node.Attribute("Key").Value;
				string type = node.Attribute("Type").Value;
				string description = node.Attribute("Description").Value;
				float amount = float.Parse(node.Attribute("Value").Value);
				int price = int.Parse(node.Attribute("Price").Value);
				string requirements = node.Attribute("Requirements").Value;
				var req = new List<string>();
				req.AddRange(requirements.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries));
				var upgrade = new Upgrade(name, key, type, description, amount, price, req);
				AvailableUpgrades.Add(key.ToLower(), upgrade);
			}
			ReadPossibleUpgrades();
		}

		private void ReadPossibleUpgrades() {
			PossibleUpgrades.Clear();
			foreach (var upgrade in AvailableUpgrades) {
				bool buyable = !BoughtUpgrades.Contains(upgrade.Key.ToLower());
				foreach (var requirement in upgrade.Value.Requirements) {
					if (!BoughtUpgrades.Contains(requirement)) {
						buyable = false;
					}
				}
				if (buyable) {
					PossibleUpgrades.Add(upgrade.Value.Key, upgrade.Value);
				}
			}
		}

		public bool BuyUpgrade(string key) {
			key = key.ToLower();
			if (string.IsNullOrEmpty(key))
				return false;
			key = key.ToLower();
			if (!PossibleUpgrades.ContainsKey(key))
				return false;
			var upgrade = PossibleUpgrades[key];
			if (!GamePlayScreen.MoneyManager.CanBuy(upgrade.Price))
				return false;
			if (SetProperties.ContainsKey(upgrade.Type.ToLower())) {
				SetProperties[upgrade.Type.ToLower()](upgrade.Value);
				GamePlayScreen.MoneyManager.Buy(upgrade.Price);
				BoughtUpgrades.Add(key);
				Price += upgrade.Price;
			} else {
				//LogFramework.AddLog(string.Format("Tower {0} kennt Property {1} nicht!", TowerName, upgrade.Type.ToLower()), false, LogType.Error);
				return false;
			}
			ReadPossibleUpgrades();
			GamePlayScreen.GuiManager.UpdateTowerWindow();
			GamePlayScreen.TowerManager.UpdateRangeMarkerSize();
			return true;
		}
	}

	public class ShowableProperty : IShowableProperty {
		public string Name { get; set; }

		public string PropertyName { get; set; }
		public string Hint { get; set; }
	}

	public class CreepDescriptor {
		public Creep Creep { get; set; }
		public float Distance { get; set; }
	}
}