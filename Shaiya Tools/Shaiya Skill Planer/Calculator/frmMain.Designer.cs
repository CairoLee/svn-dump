using Ssc.Components;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Ssc {

	partial class frmMain {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing ) {
			if( disposing && ( components != null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( frmMain ) );
			this.classImages = new System.Windows.Forms.ImageList( this.components );
			this.StatusMain = new System.Windows.Forms.StatusStrip();
			this.lblSkillPointsText = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblSkillPoints = new System.Windows.Forms.ToolStripStatusLabel();
			this.MenuMain = new System.Windows.Forms.MenuStrip();
			this.MenuProgram = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuProgramClose = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuSettingsWarnOnReset = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuSettingsInfoOnHover = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.cmbLevel = new System.Windows.Forms.ComboBox();
			this.cbClass = new Ssc.ImageComboBox();
			this.cbMode = new System.Windows.Forms.ComboBox();
			this.tabSkills = new System.Windows.Forms.TabControl();
			this.tabPassive = new System.Windows.Forms.TabPage();
			this.skillDescPassive = new Ssc.Components.SkillDescContainer();
			this.panelPassive = new System.Windows.Forms.Panel();
			this.tabBasic = new System.Windows.Forms.TabPage();
			this.skillDescBasic = new Ssc.Components.SkillDescContainer();
			this.panelBasic = new System.Windows.Forms.Panel();
			this.tabCombat = new System.Windows.Forms.TabPage();
			this.skillDescCombat = new Ssc.Components.SkillDescContainer();
			this.panelCombat = new System.Windows.Forms.Panel();
			this.tabSpecial = new System.Windows.Forms.TabPage();
			this.skillDescSpecial = new Ssc.Components.SkillDescContainer();
			this.panelSpecial = new System.Windows.Forms.Panel();
			this.tabOverview = new System.Windows.Forms.TabPage();
			this.splOverview = new System.Windows.Forms.SplitContainer();
			this.btnLoad = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnGenerate = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.StatusMain.SuspendLayout();
			this.MenuMain.SuspendLayout();
			this.tabSkills.SuspendLayout();
			this.tabPassive.SuspendLayout();
			this.tabBasic.SuspendLayout();
			this.tabCombat.SuspendLayout();
			this.tabSpecial.SuspendLayout();
			this.tabOverview.SuspendLayout();
			this.splOverview.Panel1.SuspendLayout();
			this.splOverview.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// classImages
			// 
			this.classImages.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "classImages.ImageStream" ) ) );
			this.classImages.TransparentColor = System.Drawing.Color.Transparent;
			this.classImages.Images.SetKeyName( 0, "Class_1.png" );
			this.classImages.Images.SetKeyName( 1, "Class_2.png" );
			this.classImages.Images.SetKeyName( 2, "Class_3.png" );
			this.classImages.Images.SetKeyName( 3, "Class_4.png" );
			this.classImages.Images.SetKeyName( 4, "Class_5.png" );
			this.classImages.Images.SetKeyName( 5, "Class_6.png" );
			// 
			// StatusMain
			// 
			this.StatusMain.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.lblSkillPointsText,
            this.lblSkillPoints} );
			this.StatusMain.Location = new System.Drawing.Point( 0, 489 );
			this.StatusMain.Name = "StatusMain";
			this.StatusMain.Size = new System.Drawing.Size( 892, 22 );
			this.StatusMain.TabIndex = 4;
			this.StatusMain.Text = "statusStrip1";
			// 
			// lblSkillPointsText
			// 
			this.lblSkillPointsText.Name = "lblSkillPointsText";
			this.lblSkillPointsText.Size = new System.Drawing.Size( 64, 17 );
			this.lblSkillPointsText.Text = "Skill Punkte:";
			// 
			// lblSkillPoints
			// 
			this.lblSkillPoints.Name = "lblSkillPoints";
			this.lblSkillPoints.Size = new System.Drawing.Size( 23, 17 );
			this.lblSkillPoints.Text = "n/a";
			// 
			// MenuMain
			// 
			this.MenuMain.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.MenuProgram,
            this.MenuSettings,
            this.MenuAbout} );
			this.MenuMain.Location = new System.Drawing.Point( 0, 0 );
			this.MenuMain.Name = "MenuMain";
			this.MenuMain.Size = new System.Drawing.Size( 892, 24 );
			this.MenuMain.TabIndex = 5;
			this.MenuMain.Text = "menuStrip1";
			// 
			// MenuProgram
			// 
			this.MenuProgram.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.MenuProgramClose} );
			this.MenuProgram.Name = "MenuProgram";
			this.MenuProgram.Size = new System.Drawing.Size( 67, 20 );
			this.MenuProgram.Text = "Programm";
			// 
			// MenuProgramClose
			// 
			this.MenuProgramClose.Name = "MenuProgramClose";
			this.MenuProgramClose.Size = new System.Drawing.Size( 116, 22 );
			this.MenuProgramClose.Text = "Beenden";
			this.MenuProgramClose.Click += new System.EventHandler( this.MenuProgramClose_Click );
			// 
			// MenuSettings
			// 
			this.MenuSettings.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.MenuSettingsWarnOnReset,
            this.MenuSettingsInfoOnHover} );
			this.MenuSettings.Name = "MenuSettings";
			this.MenuSettings.Size = new System.Drawing.Size( 82, 20 );
			this.MenuSettings.Text = "Einstellungen";
			// 
			// MenuSettingsWarnOnReset
			// 
			this.MenuSettingsWarnOnReset.Checked = global::Ssc.Properties.Settings.Default.WarnOnChange;
			this.MenuSettingsWarnOnReset.CheckOnClick = true;
			this.MenuSettingsWarnOnReset.CheckState = System.Windows.Forms.CheckState.Checked;
			this.MenuSettingsWarnOnReset.Name = "MenuSettingsWarnOnReset";
			this.MenuSettingsWarnOnReset.Size = new System.Drawing.Size( 226, 22 );
			this.MenuSettingsWarnOnReset.Text = "Warnung vor Reset";
			this.MenuSettingsWarnOnReset.Click += new System.EventHandler( this.MenuSettingsWarnOnReset_Click );
			// 
			// MenuSettingsInfoOnHover
			// 
			this.MenuSettingsInfoOnHover.Checked = global::Ssc.Properties.Settings.Default.InfoOnHover;
			this.MenuSettingsInfoOnHover.CheckOnClick = true;
			this.MenuSettingsInfoOnHover.CheckState = System.Windows.Forms.CheckState.Checked;
			this.MenuSettingsInfoOnHover.Name = "MenuSettingsInfoOnHover";
			this.MenuSettingsInfoOnHover.Size = new System.Drawing.Size( 226, 22 );
			this.MenuSettingsInfoOnHover.Text = "Skill Info auch bei \"Mouse Over\"";
			this.MenuSettingsInfoOnHover.Click += new System.EventHandler( this.MenuSettingsInfoOnHover_Click );
			// 
			// MenuAbout
			// 
			this.MenuAbout.Name = "MenuAbout";
			this.MenuAbout.Size = new System.Drawing.Size( 54, 20 );
			this.MenuAbout.Text = "Über...";
			this.MenuAbout.Click += new System.EventHandler( this.MenuAbout_Click );
			// 
			// cmbLevel
			// 
			this.cmbLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbLevel.FormattingEnabled = true;
			this.cmbLevel.Location = new System.Drawing.Point( 286, 2 );
			this.cmbLevel.Name = "cmbLevel";
			this.cmbLevel.Size = new System.Drawing.Size( 48, 21 );
			this.cmbLevel.TabIndex = 2;
			this.cmbLevel.SelectedIndexChanged += new System.EventHandler( this.cmbLevel_SelectedIndexChanged );
			// 
			// cbClass
			// 
			this.cbClass.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbClass.FormattingEnabled = true;
			this.cbClass.ImageList = this.classImages;
			this.cbClass.ImagePlace = 0;
			this.cbClass.ItemHeight = 16;
			this.cbClass.Location = new System.Drawing.Point( 0, 2 );
			this.cbClass.Name = "cbClass";
			this.cbClass.Size = new System.Drawing.Size( 153, 22 );
			this.cbClass.TabIndex = 0;
			this.cbClass.SelectedIndexChanged += new System.EventHandler( this.cbClass_SelectedIndexChanged );
			// 
			// cbMode
			// 
			this.cbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMode.FormattingEnabled = true;
			this.cbMode.Location = new System.Drawing.Point( 159, 2 );
			this.cbMode.Name = "cbMode";
			this.cbMode.Size = new System.Drawing.Size( 121, 21 );
			this.cbMode.TabIndex = 1;
			this.cbMode.SelectedIndexChanged += new System.EventHandler( this.cbMode_SelectedIndexChanged );
			// 
			// tabSkills
			// 
			this.tabSkills.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.tabSkills.Controls.Add( this.tabPassive );
			this.tabSkills.Controls.Add( this.tabBasic );
			this.tabSkills.Controls.Add( this.tabCombat );
			this.tabSkills.Controls.Add( this.tabSpecial );
			this.tabSkills.Controls.Add( this.tabOverview );
			this.tabSkills.Location = new System.Drawing.Point( 3, 34 );
			this.tabSkills.Name = "tabSkills";
			this.tabSkills.Padding = new System.Drawing.Point( 20, 2 );
			this.tabSkills.SelectedIndex = 0;
			this.tabSkills.Size = new System.Drawing.Size( 886, 429 );
			this.tabSkills.TabIndex = 1;
			this.tabSkills.SelectedIndexChanged += new System.EventHandler( this.tabSkills_SelectedIndexChanged );
			// 
			// tabPassive
			// 
			this.tabPassive.Controls.Add( this.skillDescPassive );
			this.tabPassive.Controls.Add( this.panelPassive );
			this.tabPassive.Location = new System.Drawing.Point( 4, 20 );
			this.tabPassive.Name = "tabPassive";
			this.tabPassive.Padding = new System.Windows.Forms.Padding( 3 );
			this.tabPassive.Size = new System.Drawing.Size( 878, 405 );
			this.tabPassive.TabIndex = 0;
			this.tabPassive.Text = "Passive";
			this.tabPassive.UseVisualStyleBackColor = true;
			// 
			// skillDescPassive
			// 
			this.skillDescPassive.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.skillDescPassive.BackColor = System.Drawing.Color.Transparent;
			this.skillDescPassive.Location = new System.Drawing.Point( 490, 0 );
			this.skillDescPassive.Name = "skillDescPassive";
			this.skillDescPassive.Size = new System.Drawing.Size( 391, 402 );
			this.skillDescPassive.TabIndex = 2;
			// 
			// panelPassive
			// 
			this.panelPassive.Location = new System.Drawing.Point( 0, 0 );
			this.panelPassive.Name = "panelPassive";
			this.panelPassive.Size = new System.Drawing.Size( 489, 405 );
			this.panelPassive.TabIndex = 1;
			// 
			// tabBasic
			// 
			this.tabBasic.Controls.Add( this.skillDescBasic );
			this.tabBasic.Controls.Add( this.panelBasic );
			this.tabBasic.Location = new System.Drawing.Point( 4, 20 );
			this.tabBasic.Name = "tabBasic";
			this.tabBasic.Padding = new System.Windows.Forms.Padding( 3 );
			this.tabBasic.Size = new System.Drawing.Size( 878, 405 );
			this.tabBasic.TabIndex = 1;
			this.tabBasic.Text = "Basic";
			this.tabBasic.UseVisualStyleBackColor = true;
			// 
			// skillDescBasic
			// 
			this.skillDescBasic.BackColor = System.Drawing.Color.Transparent;
			this.skillDescBasic.Location = new System.Drawing.Point( 490, 0 );
			this.skillDescBasic.Name = "skillDescBasic";
			this.skillDescBasic.Size = new System.Drawing.Size( 391, 402 );
			this.skillDescBasic.TabIndex = 4;
			// 
			// panelBasic
			// 
			this.panelBasic.Location = new System.Drawing.Point( 0, 0 );
			this.panelBasic.Name = "panelBasic";
			this.panelBasic.Size = new System.Drawing.Size( 489, 405 );
			this.panelBasic.TabIndex = 3;
			// 
			// tabCombat
			// 
			this.tabCombat.Controls.Add( this.skillDescCombat );
			this.tabCombat.Controls.Add( this.panelCombat );
			this.tabCombat.Location = new System.Drawing.Point( 4, 20 );
			this.tabCombat.Name = "tabCombat";
			this.tabCombat.Padding = new System.Windows.Forms.Padding( 3 );
			this.tabCombat.Size = new System.Drawing.Size( 878, 405 );
			this.tabCombat.TabIndex = 2;
			this.tabCombat.Text = "Combat";
			this.tabCombat.UseVisualStyleBackColor = true;
			// 
			// skillDescCombat
			// 
			this.skillDescCombat.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.skillDescCombat.BackColor = System.Drawing.Color.Transparent;
			this.skillDescCombat.Location = new System.Drawing.Point( 490, 0 );
			this.skillDescCombat.Name = "skillDescCombat";
			this.skillDescCombat.Size = new System.Drawing.Size( 391, 402 );
			this.skillDescCombat.TabIndex = 4;
			// 
			// panelCombat
			// 
			this.panelCombat.Location = new System.Drawing.Point( 0, 0 );
			this.panelCombat.Name = "panelCombat";
			this.panelCombat.Size = new System.Drawing.Size( 489, 405 );
			this.panelCombat.TabIndex = 3;
			// 
			// tabSpecial
			// 
			this.tabSpecial.Controls.Add( this.skillDescSpecial );
			this.tabSpecial.Controls.Add( this.panelSpecial );
			this.tabSpecial.Location = new System.Drawing.Point( 4, 20 );
			this.tabSpecial.Name = "tabSpecial";
			this.tabSpecial.Padding = new System.Windows.Forms.Padding( 3 );
			this.tabSpecial.Size = new System.Drawing.Size( 878, 405 );
			this.tabSpecial.TabIndex = 3;
			this.tabSpecial.Text = "Special";
			this.tabSpecial.UseVisualStyleBackColor = true;
			// 
			// skillDescSpecial
			// 
			this.skillDescSpecial.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.skillDescSpecial.BackColor = System.Drawing.Color.Transparent;
			this.skillDescSpecial.Location = new System.Drawing.Point( 490, 0 );
			this.skillDescSpecial.Name = "skillDescSpecial";
			this.skillDescSpecial.Size = new System.Drawing.Size( 391, 402 );
			this.skillDescSpecial.TabIndex = 4;
			// 
			// panelSpecial
			// 
			this.panelSpecial.Location = new System.Drawing.Point( 0, 0 );
			this.panelSpecial.Name = "panelSpecial";
			this.panelSpecial.Size = new System.Drawing.Size( 489, 405 );
			this.panelSpecial.TabIndex = 3;
			// 
			// tabOverview
			// 
			this.tabOverview.Controls.Add( this.splOverview );
			this.tabOverview.Location = new System.Drawing.Point( 4, 20 );
			this.tabOverview.Name = "tabOverview";
			this.tabOverview.Padding = new System.Windows.Forms.Padding( 3 );
			this.tabOverview.Size = new System.Drawing.Size( 884, 405 );
			this.tabOverview.TabIndex = 4;
			this.tabOverview.Text = "Übersicht";
			this.tabOverview.UseVisualStyleBackColor = true;
			// 
			// splOverview
			// 
			this.splOverview.IsSplitterFixed = true;
			this.splOverview.Location = new System.Drawing.Point( 0, 0 );
			this.splOverview.Name = "splOverview";
			this.splOverview.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splOverview.Panel1
			// 
			this.splOverview.Panel1.Controls.Add( this.btnLoad );
			this.splOverview.Panel1.Controls.Add( this.btnSave );
			this.splOverview.Panel1.Controls.Add( this.btnGenerate );
			this.splOverview.Size = new System.Drawing.Size( 495, 405 );
			this.splOverview.SplitterDistance = 26;
			this.splOverview.TabIndex = 1;
			// 
			// btnLoad
			// 
			this.btnLoad.Location = new System.Drawing.Point( 417, 3 );
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size( 75, 23 );
			this.btnLoad.TabIndex = 2;
			this.btnLoad.Text = "Laden";
			this.btnLoad.UseVisualStyleBackColor = true;
			this.btnLoad.Click += new System.EventHandler( this.btnLoad_Click );
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point( 336, 3 );
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size( 75, 23 );
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "Speichern";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler( this.btnSave_Click );
			// 
			// btnGenerate
			// 
			this.btnGenerate.Location = new System.Drawing.Point( 3, 3 );
			this.btnGenerate.Name = "btnGenerate";
			this.btnGenerate.Size = new System.Drawing.Size( 75, 23 );
			this.btnGenerate.TabIndex = 0;
			this.btnGenerate.Text = "Aktualisiern";
			this.btnGenerate.UseVisualStyleBackColor = true;
			this.btnGenerate.Click += new System.EventHandler( this.btnGenerate_Click );
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
			this.tableLayoutPanel1.Controls.Add( this.tabSkills, 0, 1 );
			this.tableLayoutPanel1.Controls.Add( this.panel1, 0, 0 );
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point( 0, 24 );
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Absolute, 31F ) );
			this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle() );
			this.tableLayoutPanel1.Size = new System.Drawing.Size( 892, 465 );
			this.tableLayoutPanel1.TabIndex = 6;
			// 
			// panel1
			// 
			this.panel1.Controls.Add( this.cmbLevel );
			this.panel1.Controls.Add( this.cbClass );
			this.panel1.Controls.Add( this.cbMode );
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point( 3, 3 );
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size( 886, 25 );
			this.panel1.TabIndex = 0;
			// 
			// frmMain
			// 
			this.ClientSize = new System.Drawing.Size( 892, 511 );
			this.Controls.Add( this.tableLayoutPanel1 );
			this.Controls.Add( this.StatusMain );
			this.Controls.Add( this.MenuMain );
			this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
			this.MaximizeBox = false;
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Shaiya Skill Planer v1.0 - by GodLesZ & r0xy.";
			this.Load += new System.EventHandler( this.frmMain_Load );
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.frmMain_FormClosing );
			this.StatusMain.ResumeLayout( false );
			this.StatusMain.PerformLayout();
			this.MenuMain.ResumeLayout( false );
			this.MenuMain.PerformLayout();
			this.tabSkills.ResumeLayout( false );
			this.tabPassive.ResumeLayout( false );
			this.tabBasic.ResumeLayout( false );
			this.tabCombat.ResumeLayout( false );
			this.tabSpecial.ResumeLayout( false );
			this.tabOverview.ResumeLayout( false );
			this.splOverview.Panel1.ResumeLayout( false );
			this.splOverview.ResumeLayout( false );
			this.tableLayoutPanel1.ResumeLayout( false );
			this.panel1.ResumeLayout( false );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private SplitContainer splOverview;
		private TabPage tabBasic;
		private TabPage tabCombat;
		private TabPage tabOverview;
		private TabPage tabPassive;
		private TabControl tabSkills;
		private TabPage tabSpecial;
		private ComboBox cbMode;
		private StatusStrip StatusMain;
		private ToolStripStatusLabel lblSkillPointsText;
		private Button btnGenerate;
		private Button btnSave;
		private MenuStrip MenuMain;
		private ToolStripMenuItem MenuProgram;
		private ToolStripMenuItem MenuProgramClose;
		private ToolStripMenuItem MenuSettings;
		private ToolStripMenuItem MenuSettingsWarnOnReset;
		private Button btnLoad;
		private ToolStripMenuItem MenuAbout;
		private ToolStripMenuItem MenuSettingsInfoOnHover;
		private ToolStripStatusLabel lblSkillPoints;

		private SkillControl[] mSkillPanel;

		private Label lblOverviewClass;
		private Label lblOverviewSkillPoints;
		private Label lblOverviewLevel;
		private Label[] lblOverviewSkills;
		private ImageComboBox cbClass;
		private ImageList classImages;
		private ComboBox cmbLevel;
		private Panel panelPassive;
		private Panel panelBasic;
		private Panel panelCombat;
		private Panel panelSpecial;
		private SkillDescContainer skillDescPassive;
		private SkillDescContainer skillDescBasic;
		private SkillDescContainer skillDescCombat;
		private SkillDescContainer skillDescSpecial;
		private TableLayoutPanel tableLayoutPanel1;
		private Panel panel1;

	}

}
