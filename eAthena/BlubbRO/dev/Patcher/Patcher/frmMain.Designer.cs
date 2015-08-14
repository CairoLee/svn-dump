namespace GodLesZ.BlubbRO.Patcher {
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
			this.panelMain = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.stateProgress = new System.Windows.Forms.PictureBox();
			this.statePlayer = new System.Windows.Forms.PictureBox();
			this.stateMap = new System.Windows.Forms.PictureBox();
			this.stateChar = new System.Windows.Forms.PictureBox();
			this.stateLogin = new System.Windows.Forms.PictureBox();
			this.btnGameStart = new GodLesZ.BlubbRO.Patcher.ImageButon();
			this.btnForum = new GodLesZ.BlubbRO.Patcher.ImageButon();
			this.webBrowser = new System.Windows.Forms.WebBrowser();
			this.lblStatusText = new System.Windows.Forms.Label();
			this.panelHead = new System.Windows.Forms.Panel();
			this.lblClose = new System.Windows.Forms.Label();
			this.panelMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.stateProgress)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statePlayer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stateMap)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stateChar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stateLogin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.btnGameStart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.btnForum)).BeginInit();
			this.panelHead.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelMain
			// 
			this.panelMain.BackColor = System.Drawing.Color.Transparent;
			this.panelMain.BackgroundImage = global::GodLesZ.BlubbRO.Patcher.Properties.Resources.background;
			this.panelMain.Controls.Add(this.label1);
			this.panelMain.Controls.Add(this.stateProgress);
			this.panelMain.Controls.Add(this.statePlayer);
			this.panelMain.Controls.Add(this.stateMap);
			this.panelMain.Controls.Add(this.stateChar);
			this.panelMain.Controls.Add(this.stateLogin);
			this.panelMain.Controls.Add(this.btnGameStart);
			this.panelMain.Controls.Add(this.btnForum);
			this.panelMain.Controls.Add(this.webBrowser);
			this.panelMain.Controls.Add(this.lblStatusText);
			this.panelMain.Controls.Add(this.panelHead);
			this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelMain.Location = new System.Drawing.Point(0, 0);
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new System.Drawing.Size(600, 300);
			this.panelMain.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(505, 284);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(95, 13);
			this.label1.TabIndex = 22;
			this.label1.Text = "© BlubbRO 2011";
			// 
			// stateProgress
			// 
			this.stateProgress.Image = global::GodLesZ.BlubbRO.Patcher.Properties.Resources.progressbar;
			this.stateProgress.Location = new System.Drawing.Point(8, 245);
			this.stateProgress.Name = "stateProgress";
			this.stateProgress.Size = new System.Drawing.Size(584, 20);
			this.stateProgress.TabIndex = 21;
			this.stateProgress.TabStop = false;
			// 
			// statePlayer
			// 
			this.statePlayer.Location = new System.Drawing.Point(522, 99);
			this.statePlayer.Name = "statePlayer";
			this.statePlayer.Size = new System.Drawing.Size(47, 14);
			this.statePlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.statePlayer.TabIndex = 20;
			this.statePlayer.TabStop = false;
			// 
			// stateMap
			// 
			this.stateMap.Location = new System.Drawing.Point(522, 77);
			this.stateMap.Name = "stateMap";
			this.stateMap.Size = new System.Drawing.Size(47, 14);
			this.stateMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.stateMap.TabIndex = 19;
			this.stateMap.TabStop = false;
			// 
			// stateChar
			// 
			this.stateChar.Location = new System.Drawing.Point(522, 56);
			this.stateChar.Name = "stateChar";
			this.stateChar.Size = new System.Drawing.Size(47, 14);
			this.stateChar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.stateChar.TabIndex = 18;
			this.stateChar.TabStop = false;
			// 
			// stateLogin
			// 
			this.stateLogin.Location = new System.Drawing.Point(522, 35);
			this.stateLogin.Name = "stateLogin";
			this.stateLogin.Size = new System.Drawing.Size(47, 14);
			this.stateLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.stateLogin.TabIndex = 17;
			this.stateLogin.TabStop = false;
			// 
			// btnGameStart
			// 
			this.btnGameStart.BackgroundImage = global::GodLesZ.BlubbRO.Patcher.Properties.Resources.btn_game;
			this.btnGameStart.BackgroundImageHover = global::GodLesZ.BlubbRO.Patcher.Properties.Resources.btn_gameHover;
			this.btnGameStart.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnGameStart.Location = new System.Drawing.Point(436, 155);
			this.btnGameStart.Name = "btnGameStart";
			this.btnGameStart.Size = new System.Drawing.Size(158, 53);
			this.btnGameStart.TabIndex = 16;
			this.btnGameStart.TabStop = false;
			this.btnGameStart.Click += new System.EventHandler(this.btnGameStart_Click);
			// 
			// btnForum
			// 
			this.btnForum.BackgroundImage = global::GodLesZ.BlubbRO.Patcher.Properties.Resources.btn_forum;
			this.btnForum.BackgroundImageHover = global::GodLesZ.BlubbRO.Patcher.Properties.Resources.btn_forumHover;
			this.btnForum.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnForum.Location = new System.Drawing.Point(436, 125);
			this.btnForum.Name = "btnForum";
			this.btnForum.Size = new System.Drawing.Size(158, 26);
			this.btnForum.TabIndex = 15;
			this.btnForum.TabStop = false;
			this.btnForum.Click += new System.EventHandler(this.btnForum_Click);
			// 
			// webBrowser
			// 
			this.webBrowser.Location = new System.Drawing.Point(9, 34);
			this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser.Name = "webBrowser";
			this.webBrowser.ScrollBarsEnabled = false;
			this.webBrowser.Size = new System.Drawing.Size(419, 171);
			this.webBrowser.TabIndex = 0;
			this.webBrowser.Url = new System.Uri("http://blubbro.de/patcher/notice.html", System.UriKind.Absolute);
			// 
			// lblStatusText
			// 
			this.lblStatusText.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblStatusText.ForeColor = System.Drawing.Color.Gray;
			this.lblStatusText.Location = new System.Drawing.Point(2, 215);
			this.lblStatusText.Margin = new System.Windows.Forms.Padding(0);
			this.lblStatusText.Name = "lblStatusText";
			this.lblStatusText.Size = new System.Drawing.Size(592, 20);
			this.lblStatusText.TabIndex = 0;
			this.lblStatusText.Text = "Downloading Patch Data...";
			this.lblStatusText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panelHead
			// 
			this.panelHead.BackColor = System.Drawing.Color.Transparent;
			this.panelHead.Controls.Add(this.lblClose);
			this.panelHead.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelHead.Location = new System.Drawing.Point(0, 0);
			this.panelHead.Name = "panelHead";
			this.panelHead.Size = new System.Drawing.Size(600, 25);
			this.panelHead.TabIndex = 5;
			this.panelHead.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelHead_MouseMove);
			this.panelHead.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelHead_MouseDown);
			this.panelHead.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelHead_MouseUp);
			// 
			// lblClose
			// 
			this.lblClose.AutoSize = true;
			this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblClose.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblClose.ForeColor = System.Drawing.Color.White;
			this.lblClose.Location = new System.Drawing.Point(579, 2);
			this.lblClose.Name = "lblClose";
			this.lblClose.Size = new System.Drawing.Size(19, 22);
			this.lblClose.TabIndex = 2;
			this.lblClose.Text = "X";
			this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
			// 
			// frmMain
			// 
			this.BackColor = System.Drawing.Color.MistyRose;
			this.ClientSize = new System.Drawing.Size(600, 300);
			this.Controls.Add(this.panelMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "BlubbRO Patcher";
			this.TransparencyKey = System.Drawing.Color.MistyRose;
			this.Shown += new System.EventHandler(this.frmMain_Shown);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			this.panelMain.ResumeLayout(false);
			this.panelMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.stateProgress)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statePlayer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.stateMap)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.stateChar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.stateLogin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.btnGameStart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.btnForum)).EndInit();
			this.panelHead.ResumeLayout(false);
			this.panelHead.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblStatusText;
		private System.Windows.Forms.WebBrowser webBrowser;
		private System.Windows.Forms.Panel panelHead;
		private System.Windows.Forms.Panel panelMain;
		private System.Windows.Forms.Label lblClose;
		private ImageButon btnForum;
		private ImageButon btnGameStart;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox stateProgress;
		private System.Windows.Forms.PictureBox statePlayer;
		private System.Windows.Forms.PictureBox stateMap;
		private System.Windows.Forms.PictureBox stateChar;
		private System.Windows.Forms.PictureBox stateLogin;
	}
}

