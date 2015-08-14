namespace FRO.AccountChecker {
	partial class frmMain {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.menuMain = new System.Windows.Forms.MenuStrip();
			this.menuMainProgram = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainProgramClose = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainAccounts = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMainAccountsManage = new System.Windows.Forms.ToolStripMenuItem();
			this.btnLogin = new System.Windows.Forms.Button();
			this.pnlCharacters = new System.Windows.Forms.Panel();
			this.cmbAccounts = new System.Windows.Forms.ComboBox();
			this.menuMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuMain
			// 
			this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMainProgram,
            this.menuMainAccounts});
			this.menuMain.Location = new System.Drawing.Point(0, 0);
			this.menuMain.Name = "menuMain";
			this.menuMain.Size = new System.Drawing.Size(652, 24);
			this.menuMain.TabIndex = 0;
			this.menuMain.Text = "menuStrip1";
			// 
			// menuMainProgram
			// 
			this.menuMainProgram.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMainProgramClose});
			this.menuMainProgram.Name = "menuMainProgram";
			this.menuMainProgram.Size = new System.Drawing.Size(59, 20);
			this.menuMainProgram.Text = "Program";
			// 
			// menuMainProgramClose
			// 
			this.menuMainProgramClose.Name = "menuMainProgramClose";
			this.menuMainProgramClose.Size = new System.Drawing.Size(100, 22);
			this.menuMainProgramClose.Text = "Close";
			this.menuMainProgramClose.Click += new System.EventHandler(this.menuMainProgramClose_Click);
			// 
			// menuMainAccounts
			// 
			this.menuMainAccounts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMainAccountsManage});
			this.menuMainAccounts.Name = "menuMainAccounts";
			this.menuMainAccounts.Size = new System.Drawing.Size(63, 20);
			this.menuMainAccounts.Text = "Accounts";
			// 
			// menuMainAccountsManage
			// 
			this.menuMainAccountsManage.Name = "menuMainAccountsManage";
			this.menuMainAccountsManage.Size = new System.Drawing.Size(124, 22);
			this.menuMainAccountsManage.Text = "Manage...";
			this.menuMainAccountsManage.Click += new System.EventHandler(this.menuMainAccountsManage_Click);
			// 
			// btnLogin
			// 
			this.btnLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnLogin.BackColor = System.Drawing.Color.SteelBlue;
			this.btnLogin.ForeColor = System.Drawing.Color.White;
			this.btnLogin.Location = new System.Drawing.Point(577, 32);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(75, 23);
			this.btnLogin.TabIndex = 5;
			this.btnLogin.Text = "Login";
			this.btnLogin.UseVisualStyleBackColor = false;
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			// 
			// pnlCharacters
			// 
			this.pnlCharacters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlCharacters.BackColor = System.Drawing.Color.Transparent;
			this.pnlCharacters.Location = new System.Drawing.Point(0, 61);
			this.pnlCharacters.Name = "pnlCharacters";
			this.pnlCharacters.Size = new System.Drawing.Size(652, 339);
			this.pnlCharacters.TabIndex = 6;
			// 
			// cmbAccounts
			// 
			this.cmbAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbAccounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAccounts.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbAccounts.FormattingEnabled = true;
			this.cmbAccounts.Location = new System.Drawing.Point(0, 34);
			this.cmbAccounts.Name = "cmbAccounts";
			this.cmbAccounts.Size = new System.Drawing.Size(571, 22);
			this.cmbAccounts.TabIndex = 7;
			this.cmbAccounts.SelectedIndexChanged += new System.EventHandler(this.cmbAccounts_SelectedIndexChanged);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(652, 400);
			this.Controls.Add(this.cmbAccounts);
			this.Controls.Add(this.pnlCharacters);
			this.Controls.Add(this.btnLogin);
			this.Controls.Add(this.menuMain);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuMain;
			this.Name = "frmMain";
			this.Text = "fRO Account Checker";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			this.menuMain.ResumeLayout(false);
			this.menuMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuMain;
		private System.Windows.Forms.ToolStripMenuItem menuMainProgram;
		private System.Windows.Forms.ToolStripMenuItem menuMainProgramClose;
		private System.Windows.Forms.Button btnLogin;
		private System.Windows.Forms.Panel pnlCharacters;
		private System.Windows.Forms.ToolStripMenuItem menuMainAccounts;
		private System.Windows.Forms.ToolStripMenuItem menuMainAccountsManage;
		private System.Windows.Forms.ComboBox cmbAccounts;
	}
}

