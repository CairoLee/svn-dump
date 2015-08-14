namespace GodLesZ.Ragnarok.SkillCalculator.Library.Controls {
	partial class MobPanel {
		/// <summary> 
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Komponenten-Designer generierter Code

		/// <summary> 
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MobPanel));
			this.imgMob = new System.Windows.Forms.PictureBox();
			this.lblMobName = new System.Windows.Forms.Label();
			this.pnlElement = new GodLesZ.Ragnarok.SkillCalculator.Library.Controls.MobElementControl();
			this.lblLevel = new System.Windows.Forms.Label();
			this.lblHP = new System.Windows.Forms.Label();
			this.lblSP = new System.Windows.Forms.Label();
			this.lblRace = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.imgMob)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlElement)).BeginInit();
			this.SuspendLayout();
			// 
			// imgMob
			// 
			this.imgMob.BackColor = System.Drawing.Color.Transparent;
			this.imgMob.Location = new System.Drawing.Point(4, 34);
			this.imgMob.Name = "imgMob";
			this.imgMob.Size = new System.Drawing.Size(218, 218);
			this.imgMob.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.imgMob.TabIndex = 0;
			this.imgMob.TabStop = false;
			this.imgMob.Click += new System.EventHandler(this.MobPanelAll_Click);
			this.imgMob.MouseEnter += new System.EventHandler(this.MobPanelAll_MouseEnter);
			this.imgMob.MouseLeave += new System.EventHandler(this.MobPanelAll_MouseLeave);
			// 
			// lblMobName
			// 
			this.lblMobName.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.lblMobName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMobName.ForeColor = System.Drawing.Color.Black;
			this.lblMobName.Location = new System.Drawing.Point(4, 2);
			this.lblMobName.Name = "lblMobName";
			this.lblMobName.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.lblMobName.Size = new System.Drawing.Size(218, 26);
			this.lblMobName.TabIndex = 1;
			this.lblMobName.Text = "Name";
			this.lblMobName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblMobName.Click += new System.EventHandler(this.MobPanelAll_Click);
			this.lblMobName.MouseEnter += new System.EventHandler(this.MobPanelAll_MouseEnter);
			this.lblMobName.MouseLeave += new System.EventHandler(this.MobPanelAll_MouseLeave);
			// 
			// pnlElement
			// 
			this.pnlElement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlElement.BackColor = System.Drawing.Color.Transparent;
			this.pnlElement.Element = GodLesZ.Ragnarok.SkillCalculator.Library.EElement.Neutral;
			this.pnlElement.ElementLevel = 1;
			this.pnlElement.Image = ((System.Drawing.Image)(resources.GetObject("pnlElement.Image")));
			this.pnlElement.Location = new System.Drawing.Point(197, 3);
			this.pnlElement.Name = "pnlElement";
			this.pnlElement.Size = new System.Drawing.Size(24, 24);
			this.pnlElement.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pnlElement.TabIndex = 2;
			this.pnlElement.TabStop = false;
			this.pnlElement.Click += new System.EventHandler(this.MobPanelAll_Click);
			this.pnlElement.MouseEnter += new System.EventHandler(this.MobPanelAll_MouseEnter);
			this.pnlElement.MouseLeave += new System.EventHandler(this.MobPanelAll_MouseLeave);
			// 
			// lblLevel
			// 
			this.lblLevel.AutoSize = true;
			this.lblLevel.Location = new System.Drawing.Point(4, 259);
			this.lblLevel.Name = "lblLevel";
			this.lblLevel.Size = new System.Drawing.Size(37, 13);
			this.lblLevel.TabIndex = 3;
			this.lblLevel.Text = "Lv: 99";
			this.lblLevel.Click += new System.EventHandler(this.MobPanelAll_Click);
			this.lblLevel.MouseEnter += new System.EventHandler(this.MobPanelAll_MouseEnter);
			this.lblLevel.MouseLeave += new System.EventHandler(this.MobPanelAll_MouseLeave);
			// 
			// lblHP
			// 
			this.lblHP.AutoSize = true;
			this.lblHP.Location = new System.Drawing.Point(4, 280);
			this.lblHP.Name = "lblHP";
			this.lblHP.Size = new System.Drawing.Size(55, 13);
			this.lblHP.TabIndex = 4;
			this.lblHP.Text = "HP: 1.000";
			this.lblHP.Click += new System.EventHandler(this.MobPanelAll_Click);
			this.lblHP.MouseEnter += new System.EventHandler(this.MobPanelAll_MouseEnter);
			this.lblHP.MouseLeave += new System.EventHandler(this.MobPanelAll_MouseLeave);
			// 
			// lblSP
			// 
			this.lblSP.AutoSize = true;
			this.lblSP.Location = new System.Drawing.Point(104, 280);
			this.lblSP.Name = "lblSP";
			this.lblSP.Size = new System.Drawing.Size(54, 13);
			this.lblSP.TabIndex = 5;
			this.lblSP.Text = "SP: 1.000";
			this.lblSP.Click += new System.EventHandler(this.MobPanelAll_Click);
			this.lblSP.MouseEnter += new System.EventHandler(this.MobPanelAll_MouseEnter);
			this.lblSP.MouseLeave += new System.EventHandler(this.MobPanelAll_MouseLeave);
			// 
			// lblRace
			// 
			this.lblRace.AutoSize = true;
			this.lblRace.Location = new System.Drawing.Point(104, 259);
			this.lblRace.Name = "lblRace";
			this.lblRace.Size = new System.Drawing.Size(73, 13);
			this.lblRace.TabIndex = 6;
			this.lblRace.Text = "Race: Human";
			this.lblRace.Click += new System.EventHandler(this.MobPanelAll_Click);
			this.lblRace.MouseEnter += new System.EventHandler(this.MobPanelAll_MouseEnter);
			this.lblRace.MouseLeave += new System.EventHandler(this.MobPanelAll_MouseLeave);
			// 
			// MobPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.lblRace);
			this.Controls.Add(this.lblSP);
			this.Controls.Add(this.lblHP);
			this.Controls.Add(this.lblLevel);
			this.Controls.Add(this.pnlElement);
			this.Controls.Add(this.lblMobName);
			this.Controls.Add(this.imgMob);
			this.Name = "MobPanel";
			this.Size = new System.Drawing.Size(226, 374);
			this.Click += new System.EventHandler(this.MobPanelAll_Click);
			this.MouseEnter += new System.EventHandler(this.MobPanelAll_MouseEnter);
			this.MouseLeave += new System.EventHandler(this.MobPanelAll_MouseLeave);
			((System.ComponentModel.ISupportInitialize)(this.imgMob)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlElement)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox imgMob;
		private System.Windows.Forms.Label lblMobName;
		private MobElementControl pnlElement;
		private System.Windows.Forms.Label lblLevel;
		private System.Windows.Forms.Label lblHP;
		private System.Windows.Forms.Label lblSP;
		private System.Windows.Forms.Label lblRace;
	}
}
