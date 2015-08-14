namespace Sbt {
	partial class frmMain {
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose( bool disposing ) {
			if( disposing && ( components != null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( frmMain ) );
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.MenuProgram = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuProgramOpenList = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuProgramSaveOverlay = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuProgramClose = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuSettingsPlaySound = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuSettingsTimerPerRow = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuSettingsTimerPerRowInput = new System.Windows.Forms.ToolStripTextBox();
			this.timerBreiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuSettingsTimerWidth = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuSettingsOverlaySettings = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.panelBossList = new System.Windows.Forms.Panel();
			this.trayIco = new System.Windows.Forms.NotifyIcon( this.components );
			this.menuStrip.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.MenuProgram,
            this.MenuSettings} );
			this.menuStrip.Location = new System.Drawing.Point( 0, 0 );
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size( 390, 24 );
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "menuStrip1";
			// 
			// MenuProgram
			// 
			this.MenuProgram.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.MenuProgramOpenList,
            this.toolStripSeparator1,
            this.MenuProgramSaveOverlay,
            this.toolStripSeparator4,
            this.MenuProgramClose} );
			this.MenuProgram.Name = "MenuProgram";
			this.MenuProgram.Size = new System.Drawing.Size( 67, 20 );
			this.MenuProgram.Text = "Programm";
			// 
			// MenuProgramOpenList
			// 
			this.MenuProgramOpenList.Name = "MenuProgramOpenList";
			this.MenuProgramOpenList.Size = new System.Drawing.Size( 184, 22 );
			this.MenuProgramOpenList.Text = "Liste öffnen...";
			this.MenuProgramOpenList.Click += new System.EventHandler( this.MenuProgramOpenList_Click );
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size( 181, 6 );
			// 
			// MenuProgramSaveOverlay
			// 
			this.MenuProgramSaveOverlay.Name = "MenuProgramSaveOverlay";
			this.MenuProgramSaveOverlay.Size = new System.Drawing.Size( 184, 22 );
			this.MenuProgramSaveOverlay.Text = "Overlay speichern...";
			this.MenuProgramSaveOverlay.Click += new System.EventHandler( this.MenuProgramSaveOverlay_Click );
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size( 181, 6 );
			// 
			// MenuProgramClose
			// 
			this.MenuProgramClose.Name = "MenuProgramClose";
			this.MenuProgramClose.Size = new System.Drawing.Size( 184, 22 );
			this.MenuProgramClose.Text = "Beenden";
			this.MenuProgramClose.Click += new System.EventHandler( this.MenuProgramClose_Click );
			// 
			// MenuSettings
			// 
			this.MenuSettings.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.MenuSettingsPlaySound,
            this.toolStripSeparator2,
            this.MenuSettingsTimerPerRow,
            this.timerBreiteToolStripMenuItem,
            this.toolStripSeparator3,
            this.MenuSettingsOverlaySettings} );
			this.MenuSettings.Name = "MenuSettings";
			this.MenuSettings.Size = new System.Drawing.Size( 82, 20 );
			this.MenuSettings.Text = "Einstellungen";
			// 
			// MenuSettingsPlaySound
			// 
			this.MenuSettingsPlaySound.Checked = global::Sbt.Properties.Settings.Default.PlaySound;
			this.MenuSettingsPlaySound.CheckOnClick = true;
			this.MenuSettingsPlaySound.CheckState = System.Windows.Forms.CheckState.Checked;
			this.MenuSettingsPlaySound.Name = "MenuSettingsPlaySound";
			this.MenuSettingsPlaySound.Size = new System.Drawing.Size( 201, 22 );
			this.MenuSettingsPlaySound.Text = "Ton bei Timeout";
			this.MenuSettingsPlaySound.Click += new System.EventHandler( this.MenuSettingsPlaySound_Click );
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size( 198, 6 );
			// 
			// MenuSettingsTimerPerRow
			// 
			this.MenuSettingsTimerPerRow.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.MenuSettingsTimerPerRowInput} );
			this.MenuSettingsTimerPerRow.Name = "MenuSettingsTimerPerRow";
			this.MenuSettingsTimerPerRow.Size = new System.Drawing.Size( 201, 22 );
			this.MenuSettingsTimerPerRow.Text = "Timer pro Spalte";
			// 
			// MenuSettingsTimerPerRowInput
			// 
			this.MenuSettingsTimerPerRowInput.MaxLength = 2;
			this.MenuSettingsTimerPerRowInput.Name = "MenuSettingsTimerPerRowInput";
			this.MenuSettingsTimerPerRowInput.Size = new System.Drawing.Size( 100, 21 );
			this.MenuSettingsTimerPerRowInput.Text = global::Sbt.Properties.Settings.Default.TimerPerRow;
			this.MenuSettingsTimerPerRowInput.TextChanged += new System.EventHandler( this.MenuSettingsTimerPerRowInput_TextChanged );
			// 
			// timerBreiteToolStripMenuItem
			// 
			this.timerBreiteToolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.MenuSettingsTimerWidth} );
			this.timerBreiteToolStripMenuItem.Name = "timerBreiteToolStripMenuItem";
			this.timerBreiteToolStripMenuItem.Size = new System.Drawing.Size( 201, 22 );
			this.timerBreiteToolStripMenuItem.Text = "Timer Breite";
			// 
			// MenuSettingsTimerWidth
			// 
			this.MenuSettingsTimerWidth.Name = "MenuSettingsTimerWidth";
			this.MenuSettingsTimerWidth.Size = new System.Drawing.Size( 100, 21 );
			this.MenuSettingsTimerWidth.Text = global::Sbt.Properties.Settings.Default.TimerWidth;
			this.MenuSettingsTimerWidth.TextChanged += new System.EventHandler( this.MenuSettingsTimerWidth_TextChanged );
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size( 198, 6 );
			// 
			// MenuSettingsOverlaySettings
			// 
			this.MenuSettingsOverlaySettings.Name = "MenuSettingsOverlaySettings";
			this.MenuSettingsOverlaySettings.Size = new System.Drawing.Size( 201, 22 );
			this.MenuSettingsOverlaySettings.Text = "Overlay Einstellungen...";
			this.MenuSettingsOverlaySettings.Click += new System.EventHandler( this.MenuSettingsOverlaySettings_Click );
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus} );
			this.statusStrip.Location = new System.Drawing.Point( 0, 200 );
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size( 390, 22 );
			this.statusStrip.TabIndex = 1;
			this.statusStrip.Text = "statusStrip1";
			// 
			// lblStatus
			// 
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size( 11, 17 );
			this.lblStatus.Text = "-";
			// 
			// panelBossList
			// 
			this.panelBossList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelBossList.Location = new System.Drawing.Point( 0, 24 );
			this.panelBossList.Name = "panelBossList";
			this.panelBossList.Size = new System.Drawing.Size( 390, 176 );
			this.panelBossList.TabIndex = 2;
			// 
			// trayIco
			// 
			this.trayIco.Icon = ( (System.Drawing.Icon)( resources.GetObject( "trayIco.Icon" ) ) );
			this.trayIco.Text = "Shaiya Boss Timer\r\nRechtsklick zum aktualisieren";
			this.trayIco.Visible = true;
			this.trayIco.MouseMove += new System.Windows.Forms.MouseEventHandler( this.trayIcon_MouseMove );
			this.trayIco.DoubleClick += new System.EventHandler( this.notifyIcon1_DoubleClick );
			this.trayIco.MouseClick += new System.Windows.Forms.MouseEventHandler( this.trayIcon_MouseClick );
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 390, 222 );
			this.Controls.Add( this.panelBossList );
			this.Controls.Add( this.statusStrip );
			this.Controls.Add( this.menuStrip );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
			this.MainMenuStrip = this.menuStrip;
			this.MaximizeBox = false;
			this.Name = "frmMain";
			this.Text = "Shaiya Boss Timer";
			this.Load += new System.EventHandler( this.frmMain_Load );
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.frmMain_FormClosing );
			this.Resize += new System.EventHandler( this.frmMain_Resize );
			this.menuStrip.ResumeLayout( false );
			this.menuStrip.PerformLayout();
			this.statusStrip.ResumeLayout( false );
			this.statusStrip.PerformLayout();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.Panel panelBossList;
		private System.Windows.Forms.ToolStripMenuItem MenuProgram;
		private System.Windows.Forms.ToolStripMenuItem MenuProgramClose;
		private System.Windows.Forms.ToolStripStatusLabel lblStatus;
		private System.Windows.Forms.ToolStripMenuItem MenuProgramOpenList;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem MenuSettings;
		private System.Windows.Forms.ToolStripMenuItem MenuSettingsPlaySound;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem MenuSettingsTimerPerRow;
		private System.Windows.Forms.ToolStripTextBox MenuSettingsTimerPerRowInput;
		private System.Windows.Forms.ToolStripMenuItem timerBreiteToolStripMenuItem;
		private System.Windows.Forms.ToolStripTextBox MenuSettingsTimerWidth;
		private System.Windows.Forms.NotifyIcon trayIco;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem MenuSettingsOverlaySettings;
		private System.Windows.Forms.ToolStripMenuItem MenuProgramSaveOverlay;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
	}
}

