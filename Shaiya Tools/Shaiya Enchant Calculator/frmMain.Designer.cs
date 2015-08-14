namespace Shaiya_Enchant_Calculator {
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
			this.StatusMain = new System.Windows.Forms.StatusStrip();
			this.MenuMain = new System.Windows.Forms.MenuStrip();
			this.MenuProgram = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuProgramClose = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.label1 = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.cmbType = new System.Windows.Forms.ComboBox();
			this.cmbFrom = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbTo = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblCostPer = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnCalc = new System.Windows.Forms.Button();
			this.cmbTrycount = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.lblCostAll = new System.Windows.Forms.Label();
			this.MenuMain.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// StatusMain
			// 
			this.StatusMain.Location = new System.Drawing.Point( 0, 344 );
			this.StatusMain.Name = "StatusMain";
			this.StatusMain.Size = new System.Drawing.Size( 362, 22 );
			this.StatusMain.TabIndex = 0;
			this.StatusMain.Text = "statusStrip1";
			// 
			// MenuMain
			// 
			this.MenuMain.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.MenuProgram,
            this.MenuHelp} );
			this.MenuMain.Location = new System.Drawing.Point( 0, 0 );
			this.MenuMain.Name = "MenuMain";
			this.MenuMain.Size = new System.Drawing.Size( 362, 24 );
			this.MenuMain.TabIndex = 1;
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
			// MenuHelp
			// 
			this.MenuHelp.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.MenuHelpAbout} );
			this.MenuHelp.Name = "MenuHelp";
			this.MenuHelp.Size = new System.Drawing.Size( 40, 20 );
			this.MenuHelp.Text = "Hilfe";
			// 
			// MenuHelpAbout
			// 
			this.MenuHelpAbout.Name = "MenuHelpAbout";
			this.MenuHelpAbout.Size = new System.Drawing.Size( 109, 22 );
			this.MenuHelpAbout.Text = "Über...";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font( "Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
			this.label1.Location = new System.Drawing.Point( 12, 38 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 215, 13 );
			this.label1.TabIndex = 2;
			this.label1.Text = "Alle Berechnungen && Chancen basieren auf ";
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Font = new System.Drawing.Font( "Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
			this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
			this.linkLabel1.Location = new System.Drawing.Point( 219, 38 );
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size( 75, 13 );
			this.linkLabel1.TabIndex = 3;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "diesem Thread";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler( this.linkLabel1_LinkClicked );
			// 
			// cmbType
			// 
			this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbType.FormattingEnabled = true;
			this.cmbType.Items.AddRange( new object[] {
            "Waffe",
            "Rüstung"} );
			this.cmbType.Location = new System.Drawing.Point( 15, 73 );
			this.cmbType.Name = "cmbType";
			this.cmbType.Size = new System.Drawing.Size( 84, 21 );
			this.cmbType.TabIndex = 4;
			// 
			// cmbFrom
			// 
			this.cmbFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbFrom.FormattingEnabled = true;
			this.cmbFrom.Location = new System.Drawing.Point( 105, 73 );
			this.cmbFrom.Name = "cmbFrom";
			this.cmbFrom.Size = new System.Drawing.Size( 41, 21 );
			this.cmbFrom.TabIndex = 5;
			this.cmbFrom.SelectedIndexChanged += new System.EventHandler( this.cmbFrom_SelectedIndexChanged );
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 147, 76 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 19, 13 );
			this.label2.TabIndex = 6;
			this.label2.Text = "=>";
			// 
			// cmbTo
			// 
			this.cmbTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTo.Enabled = false;
			this.cmbTo.FormattingEnabled = true;
			this.cmbTo.Location = new System.Drawing.Point( 165, 73 );
			this.cmbTo.Name = "cmbTo";
			this.cmbTo.Size = new System.Drawing.Size( 41, 21 );
			this.cmbTo.TabIndex = 7;
			this.cmbTo.SelectedIndexChanged += new System.EventHandler( this.cmbTo_SelectedIndexChanged );
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.groupBox1.Controls.Add( this.lblCostAll );
			this.groupBox1.Controls.Add( this.label5 );
			this.groupBox1.Controls.Add( this.lblCostPer );
			this.groupBox1.Controls.Add( this.label3 );
			this.groupBox1.Location = new System.Drawing.Point( 15, 134 );
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size( 335, 207 );
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Ergebniss";
			// 
			// lblCostPer
			// 
			this.lblCostPer.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.lblCostPer.AutoSize = true;
			this.lblCostPer.Location = new System.Drawing.Point( 242, 20 );
			this.lblCostPer.Name = "lblCostPer";
			this.lblCostPer.Size = new System.Drawing.Size( 13, 13 );
			this.lblCostPer.TabIndex = 1;
			this.lblCostPer.Text = "0";
			this.lblCostPer.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point( 7, 20 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 151, 13 );
			this.label3.TabIndex = 0;
			this.label3.Text = "Kosten Verzauberung - einzeln";
			// 
			// btnCalc
			// 
			this.btnCalc.Enabled = false;
			this.btnCalc.Location = new System.Drawing.Point( 315, 71 );
			this.btnCalc.Name = "btnCalc";
			this.btnCalc.Size = new System.Drawing.Size( 37, 23 );
			this.btnCalc.TabIndex = 9;
			this.btnCalc.Text = "Calc";
			this.btnCalc.UseVisualStyleBackColor = true;
			this.btnCalc.Click += new System.EventHandler( this.btnCalc_Click );
			// 
			// cmbTrycount
			// 
			this.cmbTrycount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTrycount.FormattingEnabled = true;
			this.cmbTrycount.Items.AddRange( new object[] {
            "100",
            "150",
            "200",
            "300",
            "500",
            "1000"} );
			this.cmbTrycount.Location = new System.Drawing.Point( 233, 73 );
			this.cmbTrycount.Name = "cmbTrycount";
			this.cmbTrycount.Size = new System.Drawing.Size( 67, 21 );
			this.cmbTrycount.TabIndex = 10;
			// 
			// label4
			// 
			this.label4.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point( 300, 76 );
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size( 12, 13 );
			this.label4.TabIndex = 11;
			this.label4.Text = "x";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point( 7, 38 );
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size( 152, 13 );
			this.label5.TabIndex = 2;
			this.label5.Text = "Kosten Verzauberung - gesamt";
			// 
			// lblCostAll
			// 
			this.lblCostAll.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.lblCostAll.AutoSize = true;
			this.lblCostAll.Location = new System.Drawing.Point( 242, 38 );
			this.lblCostAll.Name = "lblCostAll";
			this.lblCostAll.Size = new System.Drawing.Size( 13, 13 );
			this.lblCostAll.TabIndex = 3;
			this.lblCostAll.Text = "0";
			this.lblCostAll.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 362, 366 );
			this.Controls.Add( this.label4 );
			this.Controls.Add( this.cmbTrycount );
			this.Controls.Add( this.btnCalc );
			this.Controls.Add( this.groupBox1 );
			this.Controls.Add( this.cmbTo );
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.cmbFrom );
			this.Controls.Add( this.cmbType );
			this.Controls.Add( this.linkLabel1 );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.StatusMain );
			this.Controls.Add( this.MenuMain );
			this.MainMenuStrip = this.MenuMain;
			this.Name = "frmMain";
			this.Text = "Shaiya Enchatnt Calculator";
			this.Load += new System.EventHandler( this.frmMain_Load );
			this.MenuMain.ResumeLayout( false );
			this.MenuMain.PerformLayout();
			this.groupBox1.ResumeLayout( false );
			this.groupBox1.PerformLayout();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip StatusMain;
		private System.Windows.Forms.MenuStrip MenuMain;
		private System.Windows.Forms.ToolStripMenuItem MenuProgram;
		private System.Windows.Forms.ToolStripMenuItem MenuProgramClose;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.ComboBox cmbType;
		private System.Windows.Forms.ComboBox cmbFrom;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbTo;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnCalc;
		private System.Windows.Forms.ToolStripMenuItem MenuHelp;
		private System.Windows.Forms.ToolStripMenuItem MenuHelpAbout;
		private System.Windows.Forms.Label lblCostPer;
		private System.Windows.Forms.ComboBox cmbTrycount;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblCostAll;
		private System.Windows.Forms.Label label5;
	}
}

