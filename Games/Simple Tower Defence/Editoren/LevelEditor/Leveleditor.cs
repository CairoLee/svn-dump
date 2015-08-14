using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TomShane.Neoforce.Controls;
using EventArgs = TomShane.Neoforce.Controls.EventArgs;
using System.Windows.Forms;
using Button = TomShane.Neoforce.Controls.Button;
using ComboBox = TomShane.Neoforce.Controls.ComboBox;
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Label = TomShane.Neoforce.Controls.Label;
using ListBox = TomShane.Neoforce.Controls.ListBox;
using TabControl = TomShane.Neoforce.Controls.TabControl;
using TabPage = TomShane.Neoforce.Controls.TabPage;
using TextBox = TomShane.Neoforce.Controls.TextBox;
using System.IO;

namespace LevelEditor {
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Leveleditor : Game {
		private readonly GraphicsDeviceManager _graphics;

		private readonly WallEditor _wallEditor;
		public SpriteBatch SpriteBatch;

		private readonly Manager _manager;
		private TabControl _tabControl;
		private TabPage _savePage;
		private TabPage _wavePage;
		private Button _addWaveButton;
		private Button _deleteWaveButton;
		private ListBox _waves;
		private ListBox _currentWave;
		private Button _addCreepsButton;
		private TextBox _numberOfCreeps;
		private TextBox _healthOfCreeps;
		private TextBox _speedOfCreeps;
		private ComboBox _creepTexture;
		private Label _speed;
		private Label _texture;
		private Label _health;
		private Label _number;

		private Button _saveButton;
		private Button _fileNameButton;
		private TextBox _path;

		private Button LoadButton;

		private List<Wave> _waveList;
		private List<Creep> _currentCreepList;

		private bool _isEditorActive = true;

		public Leveleditor() {
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			_graphics.PreferredBackBufferWidth = 1200;
			_graphics.PreferredBackBufferHeight = 600;
			//_graphics.IsFullScreen = true;
			IsMouseVisible = true;
			_wallEditor = new WallEditor(this);

			_manager = new Manager(this, _graphics, "Green") { SkinDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Content\Skin\" };


			// Setting up the shared skins directory
		}

		public int Width {
			get { return _graphics.PreferredBackBufferWidth; }
		}

		public int Height {
			get { return _graphics.PreferredBackBufferHeight; }
		}

		protected override void Initialize() {
			SpriteBatch = new SpriteBatch(GraphicsDevice);
			_wallEditor.Initialize();
			_waveList = new List<Wave>();
			_currentCreepList = new List<Creep>();
			InitializeControls();

			base.Initialize();
		}

		private void InitializeControls() {
			_manager.Initialize();
			_manager.AutoCreateRenderTarget = true;

			_tabControl = new TabControl(_manager);
			_tabControl.Init();
			_tabControl.Left = 600;
			_tabControl.Top = 0;
			_tabControl.Width = Width;
			_tabControl.Height = Height;
			_tabControl.Show();
			#region WavePage
			_wavePage = _tabControl.AddPage();
			_wavePage.Text = "Waves";

			#region Constructors
			_health = new Label(_manager);
			_health.Init();
			_texture = new Label(_manager);
			_texture.Init();
			_speed = new Label(_manager);
			_speed.Init();
			_number = new Label(_manager);
			_number.Init();

			_waves = new ListBox(_manager);
			_waves.Init();
			_deleteWaveButton = new Button(_manager);
			_deleteWaveButton.Init();
			_addWaveButton = new Button(_manager);
			_addWaveButton.Init();
			_currentWave = new ListBox(_manager);
			_currentWave.Init();
			_addCreepsButton = new Button(_manager);
			_addCreepsButton.Init();
			_numberOfCreeps = new TextBox(_manager);
			_numberOfCreeps.Init();
			_speedOfCreeps = new TextBox(_manager);
			_speedOfCreeps.Init();
			_healthOfCreeps = new TextBox(_manager);
			_healthOfCreeps.Init();
			_creepTexture = new ComboBox(_manager);
			_creepTexture.Init();
			#endregion

			#region Properties
			_texture.Text = "Textur";
			_texture.Top = 2;
			_texture.Left = 2;
			_texture.Parent = _wavePage;
			_wavePage.Add(_texture);

			_creepTexture.Items.AddRange(new[] { "Slyder", "Drone", "Ape", "Paw" });
			_creepTexture.Text = "Slyder";
			_creepTexture.Width = 80;
			_creepTexture.Left = 2;
			_creepTexture.Top = _texture.Top + _texture.Height + 2;
			_creepTexture.TextColor = Color.LightGray;
			_creepTexture.Parent = _wavePage;

			_health.Text = "Gesundheit";
			_health.Top = 2;
			_health.Left = _creepTexture.Left + _creepTexture.Width + 5;
			_health.Parent = _wavePage;

			_healthOfCreeps.Left = _health.Left;
			_healthOfCreeps.Top = _health.Top + _health.Height + 2;
			_healthOfCreeps.Width = _health.Width;
			_healthOfCreeps.TextColor = Color.LightGray;
			_healthOfCreeps.Parent = _wavePage;

			_speed.Text = "Geschwindigkeit";
			_speed.Left = _health.Left + _health.Width + 5;
			_speed.Top = 2;
			_speed.Width = 93;
			_speed.Parent = _wavePage;

			_speedOfCreeps.Left = _speed.Left;
			_speedOfCreeps.Top = _speed.Top + _speed.Height + 2;
			_speedOfCreeps.Width = _speed.Width;
			_speedOfCreeps.TextColor = Color.LightGray;
			_speedOfCreeps.Parent = _wavePage;

			_number.Text = "Anzahl";
			_number.Top = 2;
			_number.Left = _speed.Left + _speed.Width + 5;
			_number.Width = 40;
			_number.Parent = _wavePage;

			_numberOfCreeps.Left = _number.Left;
			_numberOfCreeps.Top = _number.Top + _number.Height + 2;
			_numberOfCreeps.Width = _number.Width;
			_numberOfCreeps.TextColor = Color.LightGray;
			_numberOfCreeps.Parent = _wavePage;

			_addCreepsButton.Text = "Creeps hinzufügen";
			_addCreepsButton.Top = _numberOfCreeps.Top + _numberOfCreeps.Height - _addCreepsButton.Height;
			_addCreepsButton.Left = _numberOfCreeps.Left + _numberOfCreeps.Width + 5;
			_addCreepsButton.Width = 120;
			_addCreepsButton.Parent = _wavePage;

			_currentWave.Left = 2;
			_currentWave.Top = _creepTexture.Top + _creepTexture.Height + 5;
			_currentWave.Width = _addCreepsButton.Left + _addCreepsButton.Width;
			_currentWave.Height = 150;
			_currentWave.TextColor = Color.LightGray;
			_currentWave.Parent = _wavePage;

			_addWaveButton.Text = "Wave hinzufügen";
			_addWaveButton.Left = 2;
			_addWaveButton.Top = _currentWave.Top + _currentWave.Height + 5;
			_addWaveButton.Width = 150;
			_addWaveButton.Parent = _wavePage;

			_deleteWaveButton.Text = "Wave löschen";
			_deleteWaveButton.Left = _addWaveButton.Left + _addWaveButton.Width + 5;
			_deleteWaveButton.Top = _currentWave.Top + _currentWave.Height + 5;
			_deleteWaveButton.Width = _addWaveButton.Width;
			_deleteWaveButton.Parent = _wavePage;

			_waves.Left = 2;
			_waves.Top = _addWaveButton.Top + _addWaveButton.Height + 5;
			_waves.Width = _currentWave.Width;
			_waves.Height = 150;
			_waves.TextColor = Color.LightGray;
			_waves.Parent = _wavePage;
			_waves.ItemIndexChanged += _waves_ItemIndexChanged;
			#endregion

			#region Events
			_addCreepsButton.Click += AddCreepsButton_Click;
			_addWaveButton.Click += AddWaveButton_Click;
			_deleteWaveButton.Click += DeleteWaveButton_Click;
			#endregion
			#endregion

			#region SavePage
			_savePage = _tabControl.AddPage();
			_savePage.Text = "Speichern & Laden";
			_path = new TextBox(_manager);
			_path.Init();
			_path.Top = 2;
			_path.Left = 2;
			_path.Width = 200;
			_path.Parent = _savePage;
			_path.ReadOnly = true;

			_fileNameButton = new Button(_manager);
			_fileNameButton.Init();
			_fileNameButton.Text = "...";
			_fileNameButton.Width = 17;
			_fileNameButton.Height = _fileNameButton.Width;
			_fileNameButton.Top = _path.Top + _path.Height / 2 - _fileNameButton.Height / 2;
			_fileNameButton.Left = _path.Left + _path.Width + 2;
			_fileNameButton.Parent = _savePage;
			_fileNameButton.Click += delegate {
											var dlg = new SaveFileDialog {
												Filter = "Level-Dateien|*.xml",
												InitialDirectory =
													Path.GetFullPath(
													Path.GetDirectoryName(
														Assembly.GetExecutingAssembly().Location) +
													@"\..\Content\Map")
											};
											dlg.ShowDialog();
											_path.Text = dlg.FileName;
										};

			_saveButton = new Button(_manager);
			_saveButton.Init();
			_saveButton.Top = _path.Top + _path.Height + 2;
			_saveButton.Left = 2;
			_saveButton.Text = "Speichern";
			_saveButton.Width = 120;
			_saveButton.Parent = _savePage;
			_saveButton.Click += delegate {
										if (_path.Text.Length > 0) {
											string fileName = _path.Text;
											Save(fileName);
										}
									};

			LoadButton = new Button(_manager);
			LoadButton.Init();
			LoadButton.Left = 2;
			LoadButton.Top = 50;
			LoadButton.Text = "Laden";
			LoadButton.Width = 120;
			LoadButton.Parent = _savePage;
			LoadButton.Click += LoadButton_Click;
			#endregion
			_manager.Add(_tabControl);
		}

		void LoadButton_Click(object sender, EventArgs e) {
			var dlg = new OpenFileDialog {
				Filter = "Level-Dateien|*.xml",
				InitialDirectory =
					Path.GetFullPath(
					Path.GetDirectoryName(
						Assembly.GetExecutingAssembly().Location) +
					@"\..\Content\Map")
			};
			if (dlg.ShowDialog() == DialogResult.OK) {
				Load(dlg.FileName);
			}
		}

		void _waves_ItemIndexChanged(object sender, EventArgs e) {
			if (_waves.ItemIndex >= 0) {
				_currentCreepList = _waveList[_waves.ItemIndex].Creeps;
			} else {
				_currentCreepList.Clear();
			}
			UpdateCreepBox();
		}

		private void Save(string filename) {
			if (File.Exists(filename)) {
				File.Delete(filename);
			}
			XmlWriter writer = XmlWriter.Create(filename);
			if (writer != null) {
				writer.WriteStartDocument();
				{
					writer.WriteStartElement("PathDefence");
					{
						writer.WriteStartElement("Level");
						{
							writer.WriteAttributeString("Texture", "tiles");
							string text = "";
							foreach (bool b in _wallEditor.Grid) {
								text += b + "-";
							}
							writer.WriteString(text);
						}
						writer.WriteEndElement();

						writer.WriteStartElement("Waves");
						{
							int c = 0;
							foreach (var wave in _waveList) {
								writer.WriteStartElement("Wave" + c);
								{
									foreach (var creep in wave.Creeps) {
										writer.WriteStartElement("Creep");
										{
											writer.WriteAttributeString("Texture", creep.Texture);
											writer.WriteAttributeString("Health", creep.Health.ToString());
											writer.WriteAttributeString("Speed", creep.Speed.ToString());
										}
										writer.WriteEndElement();
									}
								}
								writer.WriteEndElement();
								c++;
							}
						}
					}
					writer.WriteEndElement();
				}
				writer.WriteEndDocument();
				writer.Flush();
				writer.Close();
			}
		}

		private void Load(string filename) {
			var doc = XDocument.Load(filename);
			var nodeLevel = doc.Root.Element("Level");
			string levelString = nodeLevel.Value.Trim();
			int row = 0;
			int column = 0;
			foreach (var s in levelString.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries)) {
				bool parsedBool = false;
				if (bool.TryParse(s, out parsedBool)) {
					_wallEditor.Grid[row, column] = parsedBool;
					column++;
					if (column > 31) {
						row++;
						column = 0;
					}
				}
			}

			foreach (var xmlNode in doc.Root.Element("Waves").Elements()) {
				var creepList = new List<Creep>();
				foreach (var creepNode in xmlNode.Elements()) {
					int health = int.Parse(creepNode.Attribute("Health").Value);
					float speed = float.Parse(creepNode.Attribute("Speed").Value);
					string tex = creepNode.Attribute("Texture").Value;
					creepList.Add(new Creep(health, speed, tex));
				}
				int wt = int.Parse(xmlNode.Attribute("WaitTime").Value);
				_waveList.Add(new Wave(creepList, wt));
			}
			UpdateWaveBox();
		}

		void DeleteWaveButton_Click(object sender, EventArgs e) {
			int selectedWave = _waves.ItemIndex;
			if ((selectedWave >= 0) && (_waveList.Count > selectedWave)) {
				_waveList.RemoveAt(selectedWave);
				_waves.Items.RemoveAt(selectedWave);
				_waves.ItemIndex = -1;
			}
		}

		void AddWaveButton_Click(object sender, EventArgs e) {
			var currWave = new Wave(_currentCreepList, 10000);
			_currentCreepList = new List<Creep>();
			_currentWave.Items.Clear();
			_waveList.Add(currWave);
			UpdateWaveBox();
		}

		void AddCreepsButton_Click(object sender, EventArgs e) {
			try {
				int health = Convert.ToInt32(_healthOfCreeps.Text);
				int speed = Convert.ToInt32(_speedOfCreeps.Text);
				int number = Convert.ToInt32(_numberOfCreeps.Text);
				string texture = _creepTexture.Text.Substring(0, 3).ToLower();
				for (int i = 0; i < number; i++) {
					_currentCreepList.Add(new Creep(health, speed, texture));
				}
				UpdateCreepBox();
			} catch (Exception) {
				_isEditorActive = false;
				var msg = new Window(_manager);
				msg.Init();
				msg.Text = "Fehler";
				msg.Visible = true;
				msg.Width = 255;
				msg.Height = 100;
				msg.Center();
				msg.Closed += delegate { _isEditorActive = true; };
				var lbl = new Label(_manager);
				lbl.Init();
				lbl.Text = "Bitte verwenden Sie korrekte Eingaben!";
				lbl.Parent = msg;
				lbl.Width = 230;
				lbl.Left = 5;
				lbl.Top = 5;

				var close = new Button(_manager);
				close.Init();
				close.Text = "Schließen";
				close.Width = 100;
				close.Parent = msg;
				close.Left = (msg.ClientWidth / 2) - (close.Width / 2);
				close.Top = msg.ClientHeight - close.Height - 8;
				close.Anchor = Anchors.Bottom;
				close.Click += delegate { msg.Close(); };

				_manager.Add(msg);
			}
		}

		private void UpdateCreepBox() {
			_currentWave.Items.Clear();
			foreach (var creep in _currentCreepList) {
				_currentWave.Items.Add(string.Format("Texture: {0}, Gesundheit: {1}, Speed: {2}", creep.Texture, creep.Health, creep.Speed));
			}
			_currentWave.Invalidate();
		}

		private void UpdateWaveBox() {
			_waves.Items.Clear();
			foreach (var wave in _waveList) {
				int allHealth = 0;
				int numberCreeps = wave.Creeps.Count;

				foreach (var creep in wave.Creeps) {
					allHealth += creep.Health;
				}
				_waves.Items.Add(string.Format("Gesamtenergie: {0}, Anzahl: {1}", allHealth, numberCreeps));
			}
		}

		protected override void LoadContent() {
			// Create a new SpriteBatch, which can be used to draw textures.

		}

		protected override void Update(GameTime gameTime) {
			KeyboardState keystate = Keyboard.GetState();
			// Allows the game to exit
			if (keystate.IsKeyDown(Keys.Escape)) {
				AskingForExit();
			}
			if (_isEditorActive)
				_wallEditor.Update(gameTime);
			_manager.Update(gameTime);

			base.Update(gameTime);
		}

		private void AskingForExit() {
			Exit();
		}

		protected override void Draw(GameTime gameTime) {
			GraphicsDevice.Clear(Color.Black);

			_manager.BeginDraw(gameTime);
			_wallEditor.Draw(gameTime);
			//_manager.Draw(gameTime);
			_manager.EndDraw();

			base.Draw(gameTime);
		}
	}
}