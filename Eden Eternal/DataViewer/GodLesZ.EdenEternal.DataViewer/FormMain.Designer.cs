namespace GodLesZ.EdenEternal.DataViewer {
	partial class FormMain {
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

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent() {
			this.menuMain = new System.Windows.Forms.MenuStrip();
			this.menuMainProgram = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainProgramExit = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainData = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainDataLoadItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainDataLoadMonster = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.menuMainDataLoadItemTranslation = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainDataLoadMonsterTranslation = new System.Windows.Forms.ToolStripMenuItem();
			this.statusMain = new System.Windows.Forms.StatusStrip();
			this.menuMainDataLoadScene = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuMain
			// 
			this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMainProgram,
            this.menuMainData});
			this.menuMain.Location = new System.Drawing.Point(0, 0);
			this.menuMain.Name = "menuMain";
			this.menuMain.Size = new System.Drawing.Size(662, 24);
			this.menuMain.TabIndex = 0;
			this.menuMain.Text = "menuStrip1";
			// 
			// menuMainProgram
			// 
			this.menuMainProgram.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMainProgramExit});
			this.menuMainProgram.Name = "menuMainProgram";
			this.menuMainProgram.Size = new System.Drawing.Size(65, 20);
			this.menuMainProgram.Text = "Program";
			// 
			// menuMainProgramExit
			// 
			this.menuMainProgramExit.Name = "menuMainProgramExit";
			this.menuMainProgramExit.Size = new System.Drawing.Size(92, 22);
			this.menuMainProgramExit.Text = "Exit";
			// 
			// menuMainData
			// 
			this.menuMainData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMainDataLoadItem,
            this.menuMainDataLoadMonster,
            this.menuMainDataLoadScene,
            this.toolStripSeparator1,
            this.menuMainDataLoadItemTranslation,
            this.menuMainDataLoadMonsterTranslation});
			this.menuMainData.Name = "menuMainData";
			this.menuMainData.Size = new System.Drawing.Size(43, 20);
			this.menuMainData.Text = "Data";
			// 
			// menuMainDataLoadItem
			// 
			this.menuMainDataLoadItem.Name = "menuMainDataLoadItem";
			this.menuMainDataLoadItem.Size = new System.Drawing.Size(206, 22);
			this.menuMainDataLoadItem.Text = "Load item.ini";
			this.menuMainDataLoadItem.Click += new System.EventHandler(this.menuMainDataLoadItem_Click);
			// 
			// menuMainDataLoadMonster
			// 
			this.menuMainDataLoadMonster.Name = "menuMainDataLoadMonster";
			this.menuMainDataLoadMonster.Size = new System.Drawing.Size(206, 22);
			this.menuMainDataLoadMonster.Text = "Load monster.ini";
			this.menuMainDataLoadMonster.Click += new System.EventHandler(this.menuMainDataLoadMonster_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(203, 6);
			// 
			// menuMainDataLoadItemTranslation
			// 
			this.menuMainDataLoadItemTranslation.Name = "menuMainDataLoadItemTranslation";
			this.menuMainDataLoadItemTranslation.Size = new System.Drawing.Size(206, 22);
			this.menuMainDataLoadItemTranslation.Text = "Load item translation";
			this.menuMainDataLoadItemTranslation.Click += new System.EventHandler(this.menuMainDataLoadItemTranslation_Click);
			// 
			// menuMainDataLoadMonsterTranslation
			// 
			this.menuMainDataLoadMonsterTranslation.Name = "menuMainDataLoadMonsterTranslation";
			this.menuMainDataLoadMonsterTranslation.Size = new System.Drawing.Size(206, 22);
			this.menuMainDataLoadMonsterTranslation.Text = "Load monster translation";
			this.menuMainDataLoadMonsterTranslation.Click += new System.EventHandler(this.menuMainDataLoadMonsterTranslation_Click);
			// 
			// statusMain
			// 
			this.statusMain.Location = new System.Drawing.Point(0, 382);
			this.statusMain.Name = "statusMain";
			this.statusMain.Size = new System.Drawing.Size(662, 22);
			this.statusMain.TabIndex = 1;
			this.statusMain.Text = "statusStrip1";
			// 
			// menuMainDataLoadScene
			// 
			this.menuMainDataLoadScene.Name = "menuMainDataLoadScene";
			this.menuMainDataLoadScene.Size = new System.Drawing.Size(206, 22);
			this.menuMainDataLoadScene.Text = "Load scene file";
			this.menuMainDataLoadScene.Click += new System.EventHandler(this.menuMainDataLoadScene_Click);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(662, 404);
			this.Controls.Add(this.statusMain);
			this.Controls.Add(this.menuMain);
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuMain;
			this.Name = "FormMain";
			this.Text = "Form1";
			this.menuMain.ResumeLayout(false);
			this.menuMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuMain;
		private System.Windows.Forms.ToolStripMenuItem menuMainProgram;
		private System.Windows.Forms.ToolStripMenuItem menuMainProgramExit;
		private System.Windows.Forms.StatusStrip statusMain;
		private System.Windows.Forms.ToolStripMenuItem menuMainData;
		private System.Windows.Forms.ToolStripMenuItem menuMainDataLoadItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem menuMainDataLoadItemTranslation;
		private System.Windows.Forms.ToolStripMenuItem menuMainDataLoadMonster;
		private System.Windows.Forms.ToolStripMenuItem menuMainDataLoadMonsterTranslation;
		private System.Windows.Forms.ToolStripMenuItem menuMainDataLoadScene;
	}
}

