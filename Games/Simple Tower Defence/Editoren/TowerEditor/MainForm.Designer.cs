namespace TowerEditor
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lbxBaseAttributes = new System.Windows.Forms.ListBox();
            this.btnAddStandardAttributes = new System.Windows.Forms.Button();
            this.btnAddCustomAttribute = new System.Windows.Forms.Button();
            this.btnDeleteAttribute = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lbxUpgrades = new System.Windows.Forms.ListBox();
            this.btnAddUpgrade = new System.Windows.Forms.Button();
            this.gbxBaseSettings = new System.Windows.Forms.GroupBox();
            this.cbxShowInterval = new System.Windows.Forms.CheckBox();
            this.cbxShowRange = new System.Windows.Forms.CheckBox();
            this.cbxShowDamage = new System.Windows.Forms.CheckBox();
            this.tbxKey = new System.Windows.Forms.TextBox();
            this.btnChangeAttribute = new System.Windows.Forms.Button();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.gbxUpgrades = new System.Windows.Forms.GroupBox();
            this.btnChangeUpgrade = new System.Windows.Forms.Button();
            this.btnDeleteUpgrade = new System.Windows.Forms.Button();
            this.gbxLoadSave = new System.Windows.Forms.GroupBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.gbxBaseSettings.SuspendLayout();
            this.gbxUpgrades.SuspendLayout();
            this.gbxLoadSave.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbxBaseAttributes
            // 
            this.lbxBaseAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxBaseAttributes.FormattingEnabled = true;
            this.lbxBaseAttributes.HorizontalScrollbar = true;
            this.lbxBaseAttributes.Location = new System.Drawing.Point(6, 74);
            this.lbxBaseAttributes.Name = "lbxBaseAttributes";
            this.lbxBaseAttributes.Size = new System.Drawing.Size(637, 108);
            this.lbxBaseAttributes.TabIndex = 0;
            this.lbxBaseAttributes.DoubleClick += new System.EventHandler(this.lbxBaseAttributes_DoubleClick);
            // 
            // btnAddStandardAttributes
            // 
            this.btnAddStandardAttributes.Location = new System.Drawing.Point(6, 45);
            this.btnAddStandardAttributes.Name = "btnAddStandardAttributes";
            this.btnAddStandardAttributes.Size = new System.Drawing.Size(100, 23);
            this.btnAddStandardAttributes.TabIndex = 1;
            this.btnAddStandardAttributes.Text = "Standard-Attribute";
            this.btnAddStandardAttributes.UseVisualStyleBackColor = true;
            this.btnAddStandardAttributes.Click += new System.EventHandler(this.btnAddStandardAttributes_Click);
            // 
            // btnAddCustomAttribute
            // 
            this.btnAddCustomAttribute.Location = new System.Drawing.Point(112, 45);
            this.btnAddCustomAttribute.Name = "btnAddCustomAttribute";
            this.btnAddCustomAttribute.Size = new System.Drawing.Size(90, 23);
            this.btnAddCustomAttribute.TabIndex = 2;
            this.btnAddCustomAttribute.Text = "Eigenes Attribut";
            this.btnAddCustomAttribute.UseVisualStyleBackColor = true;
            this.btnAddCustomAttribute.Click += new System.EventHandler(this.btnAddCustomAttribute_Click);
            // 
            // btnDeleteAttribute
            // 
            this.btnDeleteAttribute.Location = new System.Drawing.Point(208, 45);
            this.btnDeleteAttribute.Name = "btnDeleteAttribute";
            this.btnDeleteAttribute.Size = new System.Drawing.Size(89, 23);
            this.btnDeleteAttribute.TabIndex = 3;
            this.btnDeleteAttribute.Text = "Attribut löschen";
            this.btnDeleteAttribute.UseVisualStyleBackColor = true;
            this.btnDeleteAttribute.Click += new System.EventHandler(this.btnDeleteAttribute_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(87, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Speichern";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(6, 19);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "Laden";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lbxUpgrades
            // 
            this.lbxUpgrades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxUpgrades.FormattingEnabled = true;
            this.lbxUpgrades.HorizontalScrollbar = true;
            this.lbxUpgrades.Location = new System.Drawing.Point(6, 48);
            this.lbxUpgrades.Name = "lbxUpgrades";
            this.lbxUpgrades.Size = new System.Drawing.Size(637, 108);
            this.lbxUpgrades.TabIndex = 6;
            this.lbxUpgrades.DoubleClick += new System.EventHandler(this.lbxUpgrades_DoubleClick);
            // 
            // btnAddUpgrade
            // 
            this.btnAddUpgrade.Location = new System.Drawing.Point(6, 19);
            this.btnAddUpgrade.Name = "btnAddUpgrade";
            this.btnAddUpgrade.Size = new System.Drawing.Size(116, 23);
            this.btnAddUpgrade.TabIndex = 7;
            this.btnAddUpgrade.Text = "Upgrade hinzufügen";
            this.btnAddUpgrade.UseVisualStyleBackColor = true;
            this.btnAddUpgrade.Click += new System.EventHandler(this.btnAddUpgrade_Click);
            // 
            // gbxBaseSettings
            // 
            this.gbxBaseSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxBaseSettings.Controls.Add(this.cbxShowInterval);
            this.gbxBaseSettings.Controls.Add(this.cbxShowRange);
            this.gbxBaseSettings.Controls.Add(this.cbxShowDamage);
            this.gbxBaseSettings.Controls.Add(this.tbxKey);
            this.gbxBaseSettings.Controls.Add(this.btnChangeAttribute);
            this.gbxBaseSettings.Controls.Add(this.tbxName);
            this.gbxBaseSettings.Controls.Add(this.btnAddCustomAttribute);
            this.gbxBaseSettings.Controls.Add(this.lbxBaseAttributes);
            this.gbxBaseSettings.Controls.Add(this.btnAddStandardAttributes);
            this.gbxBaseSettings.Controls.Add(this.btnDeleteAttribute);
            this.gbxBaseSettings.Location = new System.Drawing.Point(12, 12);
            this.gbxBaseSettings.Name = "gbxBaseSettings";
            this.gbxBaseSettings.Size = new System.Drawing.Size(649, 188);
            this.gbxBaseSettings.TabIndex = 8;
            this.gbxBaseSettings.TabStop = false;
            this.gbxBaseSettings.Text = "BaseSettings";
            // 
            // cbxShowInterval
            // 
            this.cbxShowInterval.AutoSize = true;
            this.cbxShowInterval.Location = new System.Drawing.Point(438, 21);
            this.cbxShowInterval.Name = "cbxShowInterval";
            this.cbxShowInterval.Size = new System.Drawing.Size(93, 17);
            this.cbxShowInterval.TabIndex = 9;
            this.cbxShowInterval.Text = "Zeige Intervall";
            this.cbxShowInterval.UseVisualStyleBackColor = true;
            this.cbxShowInterval.CheckedChanged += new System.EventHandler(this.cbxShowLabel_CheckedChanged);
            // 
            // cbxShowRange
            // 
            this.cbxShowRange.AutoSize = true;
            this.cbxShowRange.Location = new System.Drawing.Point(323, 21);
            this.cbxShowRange.Name = "cbxShowRange";
            this.cbxShowRange.Size = new System.Drawing.Size(109, 17);
            this.cbxShowRange.TabIndex = 8;
            this.cbxShowRange.Text = "Zeige Reichweite";
            this.cbxShowRange.UseVisualStyleBackColor = true;
            this.cbxShowRange.CheckedChanged += new System.EventHandler(this.cbxShowLabel_CheckedChanged);
            // 
            // cbxShowDamage
            // 
            this.cbxShowDamage.AutoSize = true;
            this.cbxShowDamage.Location = new System.Drawing.Point(218, 21);
            this.cbxShowDamage.Name = "cbxShowDamage";
            this.cbxShowDamage.Size = new System.Drawing.Size(99, 17);
            this.cbxShowDamage.TabIndex = 7;
            this.cbxShowDamage.Text = "Zeige Schaden";
            this.cbxShowDamage.UseVisualStyleBackColor = true;
            this.cbxShowDamage.CheckedChanged += new System.EventHandler(this.cbxShowLabel_CheckedChanged);
            // 
            // tbxKey
            // 
            this.tbxKey.Location = new System.Drawing.Point(112, 19);
            this.tbxKey.Name = "tbxKey";
            this.tbxKey.Size = new System.Drawing.Size(100, 20);
            this.tbxKey.TabIndex = 6;
            this.tbxKey.Text = "Key";
            // 
            // btnChangeAttribute
            // 
            this.btnChangeAttribute.Location = new System.Drawing.Point(303, 45);
            this.btnChangeAttribute.Name = "btnChangeAttribute";
            this.btnChangeAttribute.Size = new System.Drawing.Size(75, 23);
            this.btnChangeAttribute.TabIndex = 5;
            this.btnChangeAttribute.Text = "Bearbeiten";
            this.btnChangeAttribute.UseVisualStyleBackColor = true;
            this.btnChangeAttribute.Click += new System.EventHandler(this.btnChangeAttribute_Click);
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(6, 19);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(100, 20);
            this.tbxName.TabIndex = 4;
            this.tbxName.Text = "Name";
            // 
            // gbxUpgrades
            // 
            this.gbxUpgrades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxUpgrades.Controls.Add(this.btnChangeUpgrade);
            this.gbxUpgrades.Controls.Add(this.btnDeleteUpgrade);
            this.gbxUpgrades.Controls.Add(this.lbxUpgrades);
            this.gbxUpgrades.Controls.Add(this.btnAddUpgrade);
            this.gbxUpgrades.Location = new System.Drawing.Point(12, 206);
            this.gbxUpgrades.Name = "gbxUpgrades";
            this.gbxUpgrades.Size = new System.Drawing.Size(649, 165);
            this.gbxUpgrades.TabIndex = 9;
            this.gbxUpgrades.TabStop = false;
            this.gbxUpgrades.Text = "Upgrades";
            // 
            // btnChangeUpgrade
            // 
            this.btnChangeUpgrade.Location = new System.Drawing.Point(232, 19);
            this.btnChangeUpgrade.Name = "btnChangeUpgrade";
            this.btnChangeUpgrade.Size = new System.Drawing.Size(75, 23);
            this.btnChangeUpgrade.TabIndex = 11;
            this.btnChangeUpgrade.Text = "Bearbeiten";
            this.btnChangeUpgrade.UseVisualStyleBackColor = true;
            this.btnChangeUpgrade.Click += new System.EventHandler(this.btnChangeUpgrade_Click);
            // 
            // btnDeleteUpgrade
            // 
            this.btnDeleteUpgrade.Location = new System.Drawing.Point(128, 19);
            this.btnDeleteUpgrade.Name = "btnDeleteUpgrade";
            this.btnDeleteUpgrade.Size = new System.Drawing.Size(98, 23);
            this.btnDeleteUpgrade.TabIndex = 10;
            this.btnDeleteUpgrade.Text = "Upgrade löschen";
            this.btnDeleteUpgrade.UseVisualStyleBackColor = true;
            this.btnDeleteUpgrade.Click += new System.EventHandler(this.btnDeleteUpgrade_Click);
            // 
            // gbxLoadSave
            // 
            this.gbxLoadSave.Controls.Add(this.btnLoad);
            this.gbxLoadSave.Controls.Add(this.btnSave);
            this.gbxLoadSave.Location = new System.Drawing.Point(12, 377);
            this.gbxLoadSave.Name = "gbxLoadSave";
            this.gbxLoadSave.Size = new System.Drawing.Size(169, 49);
            this.gbxLoadSave.TabIndex = 10;
            this.gbxLoadSave.TabStop = false;
            this.gbxLoadSave.Text = "Laden && Speichern";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "*.xml";
            this.saveFileDialog1.Filter = "TowerSettings|*.xml";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 432);
            this.Controls.Add(this.gbxLoadSave);
            this.Controls.Add(this.gbxUpgrades);
            this.Controls.Add(this.gbxBaseSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "TowerEditor";
            this.gbxBaseSettings.ResumeLayout(false);
            this.gbxBaseSettings.PerformLayout();
            this.gbxUpgrades.ResumeLayout(false);
            this.gbxLoadSave.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxBaseAttributes;
        private System.Windows.Forms.Button btnAddStandardAttributes;
        private System.Windows.Forms.Button btnAddCustomAttribute;
        private System.Windows.Forms.Button btnDeleteAttribute;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ListBox lbxUpgrades;
        private System.Windows.Forms.Button btnAddUpgrade;
        private System.Windows.Forms.GroupBox gbxBaseSettings;
        private System.Windows.Forms.GroupBox gbxUpgrades;
        private System.Windows.Forms.Button btnDeleteUpgrade;
        private System.Windows.Forms.GroupBox gbxLoadSave;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnChangeAttribute;
        private System.Windows.Forms.Button btnChangeUpgrade;
        private System.Windows.Forms.TextBox tbxKey;
        private System.Windows.Forms.CheckBox cbxShowInterval;
        private System.Windows.Forms.CheckBox cbxShowRange;
        private System.Windows.Forms.CheckBox cbxShowDamage;
    }
}

