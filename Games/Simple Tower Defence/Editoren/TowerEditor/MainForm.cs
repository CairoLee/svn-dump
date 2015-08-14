using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace TowerEditor {
	public struct Attribute {
		public string Name;
		public string Value;
	}

	public struct Upgrade {
		public string Name;
		public string Key;
		public string Type;
		public string Price;
		public string Value;
		public string Requirements;
		public string Description;
	}

	public partial class MainForm : Form {
		private readonly List<Attribute> Attributes = new List<Attribute>();
		private readonly List<Attribute> VisibleLabels = new List<Attribute>();
		private readonly List<Upgrade> Upgrades = new List<Upgrade>();

		public MainForm() {
			InitializeComponent();
		}

		private static DialogResult InputBox(string title, string promptText, ref string value) {
			var form = new Form();
			var label = new Label();
			var textBox = new TextBox();
			var buttonOk = new Button();
			var buttonCancel = new Button();

			form.Text = title;
			label.Text = promptText;
			textBox.Text = value;

			buttonOk.Text = "OK";
			buttonCancel.Text = "Cancel";
			buttonOk.DialogResult = DialogResult.OK;
			buttonCancel.DialogResult = DialogResult.Cancel;

			label.SetBounds(9, 20, 372, 13);
			textBox.SetBounds(12, 36, 372, 20);
			buttonOk.SetBounds(228, 72, 75, 23);
			buttonCancel.SetBounds(309, 72, 75, 23);

			label.AutoSize = true;
			textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
			buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

			form.ClientSize = new Size(396, 107);
			form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
			form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
			form.FormBorderStyle = FormBorderStyle.FixedDialog;
			form.StartPosition = FormStartPosition.CenterScreen;
			form.MinimizeBox = false;
			form.MaximizeBox = false;
			form.AcceptButton = buttonOk;
			form.CancelButton = buttonCancel;

			DialogResult dialogResult = form.ShowDialog();
			value = textBox.Text;
			return dialogResult;
		}

		private void btnDeleteAttribute_Click(object sender, EventArgs e) {
			if (lbxBaseAttributes.SelectedIndex < 0)
				return;
			Attributes.RemoveAt(lbxBaseAttributes.SelectedIndex);
			UpdateAttributeList();
		}

		private void btnAddCustomAttribute_Click(object sender, EventArgs e) {
			string name = "";
			string value = "";
			var result = InputBox("Name", "Name des Attributs?", ref name);
			if (result == DialogResult.Cancel)
				return;
			result = InputBox("Wert", "Wert des Attributs?", ref value);
			if (result == DialogResult.Cancel)
				return;
			Attributes.Add(new Attribute { Name = name, Value = value });
			UpdateAttributeList();
		}

		private void UpdateAttributeList() {
			lbxBaseAttributes.Items.Clear();
			foreach (var attribute in Attributes) {
				lbxBaseAttributes.Items.Add(string.Format("Name: {0}, Wert: {1}", attribute.Name, attribute.Value));
			}
		}

		private void UpdateUpgradeList() {
			lbxUpgrades.Items.Clear();
			foreach (var upgrade in Upgrades) {
				lbxUpgrades.Items.Add(
					string.Format("Typ: {0}, Name: {1}, Key: {2} Wert: {3}, Preis: {4}, Erfoderlich: {5}, Beschreibung: {6}",
					upgrade.Type, upgrade.Name, upgrade.Key, upgrade.Value, upgrade.Price, upgrade.Requirements, upgrade.Description));
			}
		}

		private void btnAddStandardAttributes_Click(object sender, EventArgs e) {
			string damage = "";
			string speed = "100";
			string range = "";
			string interval = "";
			string price = "";
			string texture = "";
			string shotTexture = "";
			string size = "";
			string description = "";

			var result = InputBox("Schaden", "Schaden des Turms?", ref damage);
			if (result == DialogResult.OK && damage.Length > 0)
				Attributes.Add(new Attribute { Name = "Damage", Value = damage });
			result = InputBox("Reichweite", "Reichweite des Turms?", ref range);
			if (result == DialogResult.OK && range.Length > 0)
				Attributes.Add(new Attribute { Name = "Range", Value = range });
			result = InputBox("Intervall", "Schuss-Intervall des Turms?", ref interval);
			if (result == DialogResult.OK && interval.Length > 0)
				Attributes.Add(new Attribute { Name = "Intervall", Value = interval });
			result = InputBox("Geschwindigkeit", "Schuss-Geschwindigkeit des Turms?", ref speed);
			if (result == DialogResult.OK && speed.Length > 0)
				Attributes.Add(new Attribute { Name = "Speed", Value = speed });
			result = InputBox("Preis", "Preis des Turms?", ref price);
			if (result == DialogResult.OK && price.Length > 0)
				Attributes.Add(new Attribute { Name = "Price", Value = price });
			result = InputBox("Textur", "Textur des Turms?", ref texture);
			if (result == DialogResult.OK && texture.Length > 0)
				Attributes.Add(new Attribute { Name = "Texture", Value = texture });
			result = InputBox("Schuss-Textur", "Schuss-Textur des Turms?", ref shotTexture);
			if (result == DialogResult.OK && shotTexture.Length > 0)
				Attributes.Add(new Attribute { Name = "ShotTexture", Value = shotTexture });
			string thumbnail = texture;
			result = InputBox("Thumbnail", "Thumbnail des Turms?", ref thumbnail);
			if (result == DialogResult.OK && thumbnail.Length > 0)
				Attributes.Add(new Attribute { Name = "Thumbnail", Value = thumbnail });
			result = InputBox("Größe", "Größe des Turms?(1-2)", ref size);
			if (result == DialogResult.OK && size.Length > 0)
				Attributes.Add(new Attribute { Name = "Size", Value = size });
			result = InputBox("Beschreibung", "Beschreibung des Turms?", ref description);
			if (result == DialogResult.OK && description.Length > 0)
				Attributes.Add(new Attribute { Name = "Description", Value = description });

			UpdateAttributeList();
		}

		private void SaveTowerSetings(string filename) {
			if (File.Exists(filename)) {
				File.Delete(filename);
			}
			XmlWriter writer = XmlWriter.Create(filename);
			if (writer == null)
				return;
			writer.WriteStartDocument();
			{
				writer.WriteStartElement("Tower");
				writer.WriteAttributeString("Name", tbxName.Text);
				writer.WriteAttributeString("Key", tbxKey.Text);

				{
					writer.WriteStartElement("Base");
					{
						foreach (var attribute in Attributes) {
							writer.WriteStartElement(attribute.Name);
							writer.WriteAttributeString("Value", attribute.Value);
							writer.WriteEndElement();
						}
					}
					writer.WriteEndElement();

					writer.WriteStartElement("Labels");
					{
						foreach (var attribute in VisibleLabels) {
							writer.WriteStartElement(attribute.Name);
							writer.WriteAttributeString("Value", attribute.Value);
							writer.WriteEndElement();
						}
					}
					writer.WriteEndElement();

					writer.WriteStartElement("Upgrades");
					{
						foreach (var upgrade in Upgrades) {
							writer.WriteStartElement("Upgrade");
							{
								writer.WriteAttributeString("Name", upgrade.Name);
								writer.WriteAttributeString("Key", upgrade.Key);
								writer.WriteAttributeString("Type", upgrade.Type);
								writer.WriteAttributeString("Price", upgrade.Price);
								writer.WriteAttributeString("Value", upgrade.Value);
								writer.WriteAttributeString("Requirements", upgrade.Requirements);
								writer.WriteAttributeString("Description", upgrade.Description);
							}
							writer.WriteEndElement();
						}
					}
					writer.WriteEndElement();
				}
				writer.WriteEndElement();
			}
			writer.WriteEndDocument();
			writer.Flush();
			writer.Close();
		}

		private void LoadTowerSettings(string filename) {
			Attributes.Clear();
			Upgrades.Clear();
			UpdateAttributeList();
			UpdateUpgradeList();

			var doc = XDocument.Load(filename);

			tbxName.Text = doc.Root.Attribute("Name").Value;
			tbxKey.Text = doc.Root.Attribute("Key").Value;

			foreach (var el in doc.Root.Elements()) {

				// el: Base
				if (el.Name.ToString() == "Base") {

					foreach (var element in el.Elements()) {
						//Console.WriteLine("    {0}: {1}", element.Name, element.Value);

						string value = element.Attribute("Value").Value;
						string name = element.Name.ToString();
						Attributes.Add(new Attribute { Name = name, Value = value });
					}

				}


				// el: Labels
				if (el.Name.ToString() == "Labels") {
					VisibleLabels.Clear();

					foreach (var element in el.Elements()) {
						//Console.WriteLine("    {0}: {1}", element.Name, element.Value);

						string value = element.Attribute("Value").Value;
						string name = element.Name.ToString();
						VisibleLabels.Add(new Attribute { Name = name, Value = value });

						name = name.Substring(4);
						bool tmp;
						if (bool.TryParse(value, out tmp)) {
							switch (name.ToLower()) {
								case "damage":
									cbxShowDamage.Checked = tmp;
									break;
								case "range":
									cbxShowRange.Checked = tmp;
									break;
								case "interval":
									cbxShowInterval.Checked = tmp;
									break;
							}
						}

					}

				}


				// el: Upgrades
				if (el.Name.ToString() == "Upgrades") {

					foreach (var element in el.Elements()) {
						string name = element.Attribute("Name").Value;
						string key = element.Attribute("Key").Value;
						string type = element.Attribute("Type").Value;
						string price = element.Attribute("Price").Value;
						string value = element.Attribute("Value").Value;
						string req = element.Attribute("Requirements").Value;
						string description = element.Attribute("Description").Value;

						Upgrades.Add(new Upgrade {
							Name = name,
							Key = key,
							Type = type,
							Price = price,
							Value = value,
							Requirements = req,
							Description = description
						});
					}

				}
			}

			UpdateAttributeList();
			UpdateUpgradeList();
		}

		private void btnLoad_Click(object sender, EventArgs e) {
			if (openFileDialog1.ShowDialog() == DialogResult.OK) {
				LoadTowerSettings(openFileDialog1.FileName);
			}
		}

		private void btnSave_Click(object sender, EventArgs e) {
			saveFileDialog1.FileName = tbxKey.Text;
			saveFileDialog1.InitialDirectory =
				Path.GetFullPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\..\Content\Tower\Properties");
			if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
				SaveTowerSetings(saveFileDialog1.FileName);
			}
		}

		private void btnDeleteUpgrade_Click(object sender, EventArgs e) {
			if (lbxUpgrades.SelectedIndex < 0)
				return;
			Upgrades.RemoveAt(lbxUpgrades.SelectedIndex);
			UpdateUpgradeList();
		}

		private void btnChangeAttribute_Click(object sender, EventArgs e) {
			int index = lbxBaseAttributes.SelectedIndex;
			if (index < 0)
				return;
			string name = Attributes[index].Name;
			string value = Attributes[index].Value;
			if (InputBox("Bearbeiten", "Namen bearbeiten...", ref name) == DialogResult.OK) {
				Attributes[index] = new Attribute { Name = name, Value = Attributes[index].Value };
			}
			if (InputBox("Bearbeiten", "Wert bearbeiten...", ref value) == DialogResult.OK) {
				Attributes[index] = new Attribute { Name = Attributes[index].Name, Value = value };
			}
			UpdateAttributeList();
		}

		private void lbxBaseAttributes_DoubleClick(object sender, EventArgs e) {
			btnChangeAttribute.PerformClick();
		}

		private void btnAddUpgrade_Click(object sender, EventArgs e) {
			var upgradeForm = new AddUpgradeForm();
			foreach (var upgrade in Upgrades) {
				upgradeForm.Upgrades.Add(upgrade.Key);
			}
			if (upgradeForm.ShowDialog() != DialogResult.OK)
				return;
			Upgrades.Add(new Upgrade {
				Type = upgradeForm.UpgradeType,
				Name = upgradeForm.UpgradeName,
				Key = upgradeForm.UpgradeKey,
				Price = upgradeForm.UpgradePrice,
				Value = upgradeForm.UpgradeValue,
				Requirements = upgradeForm.UpgradeRequirements,
				Description = upgradeForm.UpgradeDescription
			});

			UpdateUpgradeList();
		}

		private void btnChangeUpgrade_Click(object sender, EventArgs e) {
			int index = lbxUpgrades.SelectedIndex;
			if (index < 0)
				return;
			var upgradeForm = new AddUpgradeForm();
			foreach (var upgrade in Upgrades) {
				upgradeForm.Upgrades.Add(upgrade.Key);
			}
			var selectedUpgrade = Upgrades[index];
			upgradeForm.UpgradeType = selectedUpgrade.Type;
			upgradeForm.UpgradeName = selectedUpgrade.Name;
			upgradeForm.UpgradeKey = selectedUpgrade.Key;
			upgradeForm.UpgradeValue = selectedUpgrade.Value;
			upgradeForm.UpgradePrice = selectedUpgrade.Price;
			upgradeForm.UpgradeRequirements = selectedUpgrade.Requirements;
			upgradeForm.UpgradeDescription = selectedUpgrade.Description;
			if (upgradeForm.ShowDialog() == DialogResult.OK) {
				Upgrades[index] = new Upgrade {
					Type = upgradeForm.UpgradeType,
					Name = upgradeForm.UpgradeName,
					Key = upgradeForm.UpgradeKey,
					Price = upgradeForm.UpgradePrice,
					Value = upgradeForm.UpgradeValue,
					Requirements = upgradeForm.UpgradeRequirements,
					Description = upgradeForm.UpgradeDescription
				};
			}
			UpdateUpgradeList();
			lbxUpgrades.SelectedIndex = index;
		}

		private void lbxUpgrades_DoubleClick(object sender, EventArgs e) {
			btnChangeUpgrade.PerformClick();
		}

		private void cbxShowLabel_CheckedChanged(object sender, EventArgs e) {
			VisibleLabels.Clear();
			VisibleLabels.Add(new Attribute { Name = "ShowDamage", Value = cbxShowDamage.Checked.ToString() });
			VisibleLabels.Add(new Attribute { Name = "ShowRange", Value = cbxShowRange.Checked.ToString() });
			VisibleLabels.Add(new Attribute { Name = "ShowInterval", Value = cbxShowInterval.Checked.ToString() });
		}

	}
}
