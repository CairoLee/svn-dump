using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PathDefence.Screens;
using TowerInterface;

namespace PathDefence.GamePlay {
	//Diese Klasse dient zum Beschreiben eines speziellen Turms in bestimmten Situationen, z.B
	//gibt es eine Liste mit allen möglichen Türmen die man bauen kann
	public class TowerClass : IComparable {
		public Assembly Assembly;
		public string ClassName;
		public string TowerKey;
		public string TowerName;
		//Zum Sortieren der Klassen (hier nach Kaufpreis)
		public int CompareTo(object obj) {
			if (obj is TowerClass) {
				var tmp = obj as TowerClass;
				int ownPrice = Convert.ToInt32(TowerManager.GetTowerProperty(TowerKey, "Price"));
				int otherPrice = Convert.ToInt32(TowerManager.GetTowerProperty(tmp.TowerKey, "Price"));
				return ownPrice - otherPrice;
			}
			return 0;
		}

		public int GetPrice() {
			return Convert.ToInt32(TowerManager.GetTowerProperty(TowerKey, "Price"));
		}
	}
	///<summary>Diese Klasse kümmert sich um alles was mit den Türmen zu tun hat.
	/// Also zeichnen, updaten, bauen...</summary>
	public class TowerManager : DrawableGameComponent {
		private readonly PathDefenceGame CurrGame;
		private readonly GamePlayScreen GamePlayScreen;
		private Vector2 BuilderGridPosition;
		private Vector2 BuildMarkerOrigin;
		private Vector2 BuildMarkerPosition;
		private Vector2 BuildMarkerScale;
		private Vector2 BuildMarkerSize;
		private Texture2D BuildMarkerTexture;

		private bool BuildMode;
		private float BuildModeRange;
		private bool drawRangeMarker;
		private bool IsTowerToBuildValidPlace;
		private Vector2 OldPosition;
		private Vector2 RangeOrigin;
		private Vector2 RangePosition;
		private Vector2 RangeScale;
		private Vector2 RangeSize;
		private Texture2D RangeTexture;
		public List<TowerClass> TowerClassList;
		//wenn ein Turm verkauft werden soll kommt er hier rein, um später gelöscht zu werden
		private List<ITower> TowerDeleteList;
		private Vector2 TowerGridPosition;
		//Diese Liste beinhaltet alle gebauten Türme
		private List<ITower> TowerList;
		private ITower TowerToBuild;
		private string TowerToBuildKey;
		private bool WaitForMouseUp;
		private MouseState OldState;

		public TowerManager(Game game, GamePlayScreen gamePlayScreen)
			: base(game) {
			CurrGame = (PathDefenceGame)game;
			GamePlayScreen = gamePlayScreen;
		}

		private bool DrawRangeMarker {
			get { return drawRangeMarker; }
			set {
				drawRangeMarker = value;
				if (!value) {
					RangePosition = new Vector2(-9999);
				}
			}
		}

		public ITower SelectedTower { get; private set; }
		//Hier drin befinden sich alle Türme, die gebaut werden können
		//Also alle Turm-Assemblies, zu denen passende Properties gefunden wurden
		//erreichbar sind sie über den TowerKey
		private Dictionary<string, TowerClass> TowerClasses { get; set; }

		public override void Initialize() {
			TowerList = new List<ITower>();
			TowerDeleteList = new List<ITower>();
			TowerClasses = new Dictionary<string, TowerClass>();
			TowerClassList = new List<TowerClass>();
			LoadTowerBinaries();
			CancelBuildMode();
			RangeTexture = CurrGame.Content.Load<Texture2D>("GUI/Range");
			RangeOrigin = new Vector2(RangeTexture.Width / 2f, RangeTexture.Height / 2f);
			BuildMarkerTexture = CurrGame.Content.Load<Texture2D>("GUI/BuildMarker");
			BuildMarkerOrigin = Vector2.Zero;
			base.Initialize();
		}

		public override void Draw(GameTime gameTime) {
			//Erst alle Türme zeichnen
			foreach (ITower tower in TowerList) {
				tower.Draw(gameTime);
			}
			//Falls wir was am bauen sind
			if (BuildMode) {
				//Je nachdem ob der aktuele Platz gültig ist oder nicht
				Color color = IsTowerToBuildValidPlace ? Color.Green : Color.Red;
				CurrGame.SpriteBatch.Begin();
				{
					//Zeichnen wir die Markierung WO wir bauen wollen
					CurrGame.SpriteBatch.Draw(BuildMarkerTexture, BuildMarkerPosition, null, color, 0, BuildMarkerOrigin,
											  BuildMarkerScale, SpriteEffects.None, 0);
					//Und die Reichweite des zu bauenden Turms
					CurrGame.SpriteBatch.Draw(RangeTexture, RangePosition, null, Color.White, 0, RangeOrigin, RangeScale,
											  SpriteEffects.None, 0);
				}
				CurrGame.SpriteBatch.End();
			}
			//Falls wir einen Turm ausgewählt haben
			if (DrawRangeMarker) {
				//Müssen wir auch hier die Reichweite darstellen
				CurrGame.SpriteBatch.Begin();
				{
					CurrGame.SpriteBatch.Draw(RangeTexture, RangePosition, null, Color.White, 0, RangeOrigin, RangeScale,
											  SpriteEffects.None, 0);
				}
				CurrGame.SpriteBatch.End();
			}

			base.Draw(gameTime);
		}

		public override void Update(GameTime gameTime) {
			MouseState state = Mouse.GetState();
			//Falls das Siel läuft
			if (GamePlayScreen.GameState == EGameState.Running) {
				//Alle Tower updaten
				foreach (ITower tower in TowerList) {
					tower.Update(gameTime);
				}
				//Dann alle Tower die gelöscht werden wollen auch löschen
				foreach (ITower tower in TowerDeleteList) {
					TowerList.Remove(tower);
				}
				TowerDeleteList.Clear();
			}

			//Falls wir uns im Baumodus befinden
			if (BuildMode) {
				float x = state.X;
				float y = state.Y;
				//Hier finden wir heraus, wo wir gemessen an dem Spielfeld-Grid unsere Baumarkierung platzieren müssen
				float x2 = TowerToBuild.PathSize.X == 1 ? BuildMarkerSize.X : 0;
				float y2 = TowerToBuild.PathSize.Y == 1 ? BuildMarkerSize.Y : BuildMarkerSize.Y / 2;
				x += x2;
				y += y2;

				BuilderGridPosition = new Vector2((int)(x / GamePlayScreen.LevelManager.GridSize.X),
												  (int)(y / GamePlayScreen.LevelManager.GridSize.Y));
				TowerGridPosition = new Vector2(BuilderGridPosition.X - 1, BuilderGridPosition.Y - 1);

				//falls wir die Maus bewegt haben und damit einen neuen Platz für den Turm haben
				if (BuilderGridPosition != OldPosition) {
					//Müssen wir herausfinden, ob der Turm dort gebaut werden darf
					IsTowerToBuildValidPlace = GamePlayScreen.LevelManager.CanBuildTower(TowerGridPosition,
																						 TowerToBuild.PathSize);
					//Hier rechnen wir die Position nun in Pixeln aus
					BuildMarkerPosition = new Vector2(TowerGridPosition.X * GamePlayScreen.LevelManager.GridSize.X,
													  TowerGridPosition.Y * GamePlayScreen.LevelManager.GridSize.Y);

					RangePosition = new Vector2(BuildMarkerPosition.X + BuildMarkerSize.X / 2,
												BuildMarkerPosition.Y + BuildMarkerSize.Y / 2);
					OldPosition = BuilderGridPosition;
				}

				//Falls wir im Baumodus die linke Maustaste drücken
				if (state.LeftButton == ButtonState.Released && OldState.LeftButton == ButtonState.Pressed) {
					//Und wir den Turm dort hinbauen können
					if (IsTowerToBuildValidPlace) {
						//Erstellen wir eine neue Instanz des Towers und platzieren ihn 
						//(wir haben zwar egientlich schon eune Instanz, bei der sind aber die werte nicht mehr aktuell)
						ITower tmpTower = CreateTowerInstance(TowerToBuildKey);
						AddTower(tmpTower);
						//Baumodus ist jetzt vorbei
						CancelBuildMode();
						WaitForMouseUp = true;
					}
				}

				//Rechtsklick beendet den Baumodus
				if (state.RightButton == ButtonState.Pressed) {
					CancelBuildMode();
				}
			} else //Kein Baumodus
            {
				//Falls wir die linke Maustaste drücken, aber nicht auf ein Turm-Info-Fenster klicken
				if (state.LeftButton == ButtonState.Released && OldState.LeftButton == ButtonState.Pressed &&
					!GamePlayScreen.GuiManager.IsClickOnTowerWindow(new Vector2(state.X, state.Y))) {
					bool towerSelected = false;
					//Alle Türme auf Kollision mit der Maus prüfen
					foreach (ITower tower in TowerList) {
						var towerRect = new Rectangle {
							X = (int)tower.Position.X,
							Y = (int)tower.Position.Y,
							Width = (int)tower.Size.X,
							Height = (int)tower.Size.Y
						};
						//Falls wir die Maus wieder losgelassen haben und der Turm unter der Maus ist
						if (!WaitForMouseUp && towerRect.Intersects(new Rectangle(state.X, state.Y, 0, 0))) {
							//Ist das unser ausgewählter Turm
							SelectedTower = tower;
							towerSelected = true;
							//Größe der Reichweitenmarkierung an die Reichweite anpassen
							UpdateRangeMarkerSize();
							RangePosition = new Vector2(SelectedTower.Position.X + SelectedTower.Size.X / 2,
														SelectedTower.Position.Y + SelectedTower.Size.Y / 2);
							DrawRangeMarker = true;
						}
					}
					//Kein Tower ausgewählt, sprich ins Leere geklickt?
					if (!towerSelected && !GamePlayScreen.GuiManager.IsClickOnTowerWindow(new Vector2(state.X, state.Y))) {
						//Dann ist auch kein Turm ausgewählt
						DeselectTower();
					}
				} else {
					WaitForMouseUp = false;
				}
			}
			OldState = state;
			base.Update(gameTime);
		}

		//Baut einen neuen Turm
		private void AddTower(ITower tower) {
			TowerList.Add(tower);
			//Dem Levelmanager den Turm mitteilen, damit der weiß, dass dort der Weg blockiert ist
			GamePlayScreen.LevelManager.BuildTower(tower.PathPosition, tower.PathSize);
			//Allen Creeps mitteilen, dass sie sich vielleicht einen neuen Weg suchen müssen
			GamePlayScreen.ChangeCreepGrid(tower);
			//Und das Geld für den Tower abziehen
			GamePlayScreen.MoneyManager.Buy(tower.Price);
		}

		//kein Turm ausgewählt
		public void DeselectTower() {
			SelectedTower = null;
			DrawRangeMarker = false;
		}

		//Baumodus abbrechen
		public void CancelBuildMode() {
			BuildMode = false;
			DrawRangeMarker = false;
			RangeScale = Vector2.Zero;
			BuildMarkerScale = Vector2.Zero;
			RangePosition = new Vector2(-1000, -1000);
			BuildMarkerPosition = new Vector2(-1000, -1000);
			//GamePlayScreen.StartGame();
		}

		//Baumodus starten
		private void EnterBuildMode() {
			TowerToBuild = null;
			SelectedTower = null;
			//GamePlayScreen.StopGame();
			BuildMode = true;
			DrawRangeMarker = true;
		}

		//Wird von ausßerhalb aufgerufen um einen Turm mit dem entsprechenden Key zu bauen
		public bool StartTowerBuildMode(string key) {
			bool result = true;
			//Bausmodus starten
			EnterBuildMode();
			key = key.ToLower();
			//Den zu erstellenden Turm schonmal erzeugen um auf wichtige Eigenschaften Zugriff zu bekommen
			TowerToBuild = CreateTowerInstance(key);
			if (TowerToBuild != null) {
				//falls wir uns den Turm leisten können
				if (GamePlayScreen.MoneyManager.CanBuy(TowerToBuild.Price)) {
					BuildModeRange = TowerToBuild.Range;
					RangeSize = new Vector2(2 * BuildModeRange, 2 * BuildModeRange);
					RangeScale = new Vector2(RangeSize.X / RangeTexture.Width, RangeSize.Y / RangeTexture.Height);

					BuildMarkerSize = new Vector2(GamePlayScreen.LevelManager.GridSize.X * TowerToBuild.PathSize.X,
												  GamePlayScreen.LevelManager.GridSize.Y * TowerToBuild.PathSize.Y);
					BuildMarkerScale = new Vector2(BuildMarkerSize.X / BuildMarkerTexture.Width,
												   BuildMarkerSize.Y / BuildMarkerTexture.Height);
					TowerToBuildKey = key;
				} else {
					GamePlayScreen.GuiManager.Log("Nicht Genug Geld vorhanden, Preis = " + TowerToBuild.Price, 1);
					result = false;
				}
			} else {
				GamePlayScreen.GuiManager.Log("Ungültiger TowerKey", 1);
				result = false;
			}
			//Falls was schief gegangen ist, abbrechen
			if (!result) {
				CancelBuildMode();
			}
			return result;
		}

		//erzeugt aus einen Key einen Turminstanz, ohne dass das Spiel die Turmklasse wirklich kennt
		private ITower CreateTowerInstance(string towerKey) {
			towerKey = towerKey.ToLower();
			//falls wir den gewünschten Turm auch haben
			if (TowerClasses.ContainsKey(towerKey)) {
				TowerClass towerClass = TowerClasses[towerKey];
				//Die Konstruktor-Parameter
				var param = new object[] { CurrGame, GamePlayScreen, GamePlayScreen.Creeps, BuilderGridPosition, towerKey };
				//Nun den Turm über seinen Klassennamen und das entsprechende Assembly per Reflection erzeugen
				var tmpTower =
					(ITower)towerClass.Assembly.CreateInstance(towerClass.ClassName, true, BindingFlags.CreateInstance,
																null, param, null, null);
				//Initialisieren
				tmpTower.Initialize();
				tmpTower.Name = towerClass.TowerName;
				tmpTower.Key = towerKey;
				return tmpTower;
			}
			return null;
		}

		//Diese Methode lädt alle Türme die man bauen kann aus den Dlls
		private void LoadTowerBinaries() {
			//Als erstes gehen wir alle Assemblies im Assemblies-Ordner durch
			foreach (string s in Directory.GetFiles("Content\\Tower\\Binaries", "*.dll")) {
				//Laden
				Assembly assembly = Assembly.LoadFile(Path.GetFullPath(s));
				//Jetzt alle Klassen durchgehen, die in der Dll sind.
				foreach (Type towerClass in assembly.GetTypes()) {
					bool isTower = false;
					string key = "";
					string name = "";
					//Jede Dll muss mindestens ein TowerClass-Attribut besitzen,
					//wenn keins da ist, dann ist das schlecht, der Turm kann nicht benutzt werden
					if (towerClass.GetCustomAttributes(true).Length < 1) {
						/*
                        LogFramework.AddLog(String.Format("Klasse \"{0}\" hat kein TowerName-Attribut!",
                                                           towerClass.Name), false, LogType.Warning);
						*/
					} else {
						//Falls wir mindestens ein Attribut haben, alle durchgehen
						foreach (Attribute attribute in towerClass.GetCustomAttributes(true)) {
							//Falls das Attribut das gesuchte ist(nämlich das zur Beschreibung eines Turmes, oder etwas anderem was der Turm braucht
							if (attribute is TowerKey) {
								var att = (attribute as TowerKey);
								//Die Werte auslesen
								isTower = att.IsTower;
								key = att.Key;
								name = att.Name;
							} else {
								/*
                                LogFramework.AddLog(String.Format("Klasse \"{0}\" hat kein TowerName-Attribut!",
                                                                   towerClass.Name), false, LogType.Warning);
								*/
								continue;
							}
						}
						//Jetzt prüfen wir, ob zu dem Turm auch die passenden Properties vorhanden sind
						bool settingsAvailable = AreTowerSettingsAvailable(key);
						//Falls alles stimmt, und wir diesen Turm noch nicht hinzugefügt haben
						if (isTower && settingsAvailable && !TowerClasses.ContainsKey(key.ToLower())) {
							//Machen wir das hier
							TowerClasses.Add(key.ToLower(),
											 new TowerClass {
												 Assembly = assembly,
												 ClassName = towerClass.FullName,
												 TowerKey = key.ToLower(),
												 TowerName = name
											 });
						} else if (isTower && !settingsAvailable) {
							/*
                            LogFramework.AddLog(string.Format("Turm {0} hat keine passenden Properties!", key), false, LogType.Warning);
							*/
						}
					}
				}
			}
			//Jetzt noch alle Klassen nach Preis sortieren
			foreach (var towerClass in TowerClasses) {
				TowerClassList.Add(towerClass.Value);
			}
			TowerClassList.Sort();
		}

		//Prüft, ob zu einem gegeben Towerkey auch die Properties existieren
		private bool AreTowerSettingsAvailable(string towerKey) {
			string fileName = CurrGame.ApplicationDirectory + "\\Content\\Tower\\Properties\\" + towerKey + ".xml";
			//Erst überprüfen ob die Datei da ist
			if (File.Exists(fileName)) {
				//Wenn ja, dann wird auch noch überprüft, ob die Datei auch für den Turm passt (die Keys gleich sind)
				var xml = XDocument.Load(fileName);
				string key = xml.Root.Attribute("Key").Value;
				if (towerKey.ToLower() == key.ToLower())
					return true;
				return false;
			}
			return false;
		}

		//Löscht den ausgewählten Turm
		public bool RemoveTower() {
			if (SelectedTower != null) {
				return RemoveTower(SelectedTower);
			}
			return false;
		}

		//Löscht einen Turm
		public bool RemoveTower(ITower tower) {
			if (tower == null) {
				return false;
			}
			//Turm zum Löschen markieren
			TowerDeleteList.Add(tower);
			//Turm aus dem Level (Wegfindung) löschen
			GamePlayScreen.LevelManager.RemoveTower(tower.PathPosition, tower.PathSize);
			//Und die Creeps dürfen sich wieder einen neuen Weg suchen
			GamePlayScreen.ChangeCreepGrid(null);
			return true;
		}

		//Liest das Vorschaubild eines Turmes aus
		public Texture2D GetThumbnail(string towerKey) {
			string texName = GetTowerProperty(towerKey, "Thumbnail");
			string path = CurrGame.ApplicationDirectory + "\\Content\\Tower\\Thumbnails\\" + texName;
			if (!File.Exists(path + ".xnb")) {
				/*
                LogFramework.AddLog("Thumbnail \"{0}\" nicht vorhanden!", aTyp:LogType.Error, objects: new[]{path});
				*/
			}
			var tex = CurrGame.Content.Load<Texture2D>(path);
			return tex;
		}

		//Liest irgendeine Varaible eines Turmes aus seinen Properties aus 
		public static string GetTowerProperty(string towerName, string propertyName) {
			return GetTowerProperty("Base", towerName, propertyName);
		}

		public static string GetTowerProperty(string location, string towerName, string propertyName) {
			var filepath = "Content/Tower/Properties/" + towerName + ".xml";
			var xml = XDocument.Load(filepath);
			var xmlNode = xml.Root.Element(location);
			if (xmlNode == null) {
				/*
                LogFramework.AddLog("Property \"{0}\" bei Turm \"{1}\" nicht gefunden.", aTyp:LogType.Warning, objects: new[]{ propertyName,
                                                   towerName});
				*/
			}
			var attrNode = xmlNode.Element(propertyName);
			string result = attrNode.Attribute("Value").Value;
			return result;
		}

		//Updatet die Größe des Rangemarkers passend zur Reichweite des ausgewählten Turms
		public void UpdateRangeMarkerSize() {
			RangeSize = new Vector2(2 * SelectedTower.Range, 2 * SelectedTower.Range);
			RangeScale = new Vector2(RangeSize.X / RangeTexture.Width, RangeSize.Y / RangeTexture.Height);
		}
	}
}