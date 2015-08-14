namespace GodLesZ.FunRO.Patcher {
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
			this.stateWoe = new System.Windows.Forms.PictureBox();
			this.statePlayers = new System.Windows.Forms.Label();
			this.stateMap = new System.Windows.Forms.PictureBox();
			this.stateChar = new System.Windows.Forms.PictureBox();
			this.stateLogin = new System.Windows.Forms.PictureBox();
			this.btnPatcherOptions = new GodLesZ.FunRO.Patcher.Controls.ImageButon();
			this.btnWebVote = new GodLesZ.FunRO.Patcher.Controls.ImageButon();
			this.btnGameSetup = new GodLesZ.FunRO.Patcher.Controls.ImageButon();
			this.stateProgress = new System.Windows.Forms.PictureBox();
			this.btnGameStart = new GodLesZ.FunRO.Patcher.Controls.ImageButon();
			this.btnWebForum = new GodLesZ.FunRO.Patcher.Controls.ImageButon();
			this.webBrowser = new System.Windows.Forms.WebBrowser();
			this.lblStatusText = new System.Windows.Forms.Label();
			this.panelHead = new System.Windows.Forms.Panel();
			this.btnClose = new GodLesZ.FunRO.Patcher.Controls.ImageButon();
			this.panelMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.stateWoe)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stateMap)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stateChar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stateLogin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.btnPatcherOptions)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.btnWebVote)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.btnGameSetup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stateProgress)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.btnGameStart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.btnWebForum)).BeginInit();
			this.panelHead.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
			this.SuspendLayout();
			// 
			// panelMain
			// 
			this.panelMain.BackColor = System.Drawing.Color.Transparent;
			this.panelMain.BackgroundImage = LayoutManager.GetImage("background");
			this.panelMain.Controls.Add(this.stateWoe);
			this.panelMain.Controls.Add(this.statePlayers);
			this.panelMain.Controls.Add(this.stateMap);
			this.panelMain.Controls.Add(this.stateChar);
			this.panelMain.Controls.Add(this.stateLogin);
			this.panelMain.Controls.Add(this.btnPatcherOptions);
			this.panelMain.Controls.Add(this.btnWebVote);
			this.panelMain.Controls.Add(this.btnGameSetup);
			this.panelMain.Controls.Add(this.stateProgress);
			this.panelMain.Controls.Add(this.btnGameStart);
			this.panelMain.Controls.Add(this.btnWebForum);
			this.panelMain.Controls.Add(this.webBrowser);
			this.panelMain.Controls.Add(this.lblStatusText);
			this.panelMain.Controls.Add(this.panelHead);
			this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelMain.Location = new System.Drawing.Point(0, 0);
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new System.Drawing.Size(957, 444);
			this.panelMain.TabIndex = 6;
			// 
			// stateWoe
			// 
			this.stateWoe.Image = LayoutManager.GetImage("woe_inactive");
			this.stateWoe.Location = new System.Drawing.Point(887, 244);
			this.stateWoe.Name = "stateWoe";
			this.stateWoe.Size = new System.Drawing.Size(29, 17);
			this.stateWoe.TabIndex = 30;
			this.stateWoe.TabStop = false;
			// 
			// statePlayers
			// 
			this.statePlayers.AutoSize = true;
			this.statePlayers.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.statePlayers.ForeColor = System.Drawing.Color.Gray;
			this.statePlayers.Location = new System.Drawing.Point(884, 215);
			this.statePlayers.Margin = new System.Windows.Forms.Padding(0);
			this.statePlayers.Name = "statePlayers";
			this.statePlayers.Size = new System.Drawing.Size(16, 22);
			this.statePlayers.TabIndex = 29;
			this.statePlayers.Text = "?";
			this.statePlayers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// stateMap
			// 
			this.stateMap.Image = LayoutManager.GetImage("server_online");
			this.stateMap.Location = new System.Drawing.Point(887, 195);
			this.stateMap.Name = "stateMap";
			this.stateMap.Size = new System.Drawing.Size(53, 17);
			this.stateMap.TabIndex = 28;
			this.stateMap.TabStop = false;
			// 
			// stateChar
			// 
			this.stateChar.Image = LayoutManager.GetImage("server_online");
			this.stateChar.Location = new System.Drawing.Point(887, 173);
			this.stateChar.Name = "stateChar";
			this.stateChar.Size = new System.Drawing.Size(53, 17);
			this.stateChar.TabIndex = 27;
			this.stateChar.TabStop = false;
			// 
			// stateLogin
			// 
			this.stateLogin.Image = LayoutManager.GetImage("server_online");
			this.stateLogin.Location = new System.Drawing.Point(887, 151);
			this.stateLogin.Name = "stateLogin";
			this.stateLogin.Size = new System.Drawing.Size(53, 17);
			this.stateLogin.TabIndex = 26;
			this.stateLogin.TabStop = false;
			// 
			// btnPatcherOptions
			// 
			this.btnPatcherOptions.BackgroundImage = LayoutManager.GetImage("btn_options");
			this.btnPatcherOptions.BackgroundImageClicked = null;
			this.btnPatcherOptions.BackgroundImageHover = LayoutManager.GetImage("btn_options_hover");
			this.btnPatcherOptions.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnPatcherOptions.Location = new System.Drawing.Point(885, 372);
			this.btnPatcherOptions.Name = "btnPatcherOptions";
			this.btnPatcherOptions.Size = new System.Drawing.Size(72, 19);
			this.btnPatcherOptions.TabIndex = 25;
			this.btnPatcherOptions.TabStop = false;
			this.btnPatcherOptions.Click += new System.EventHandler(this.btnPatcherOptions_Click);
			// 
			// btnWebVote
			// 
			this.btnWebVote.BackgroundImage = LayoutManager.GetImage("btn_vote");
			this.btnWebVote.BackgroundImageClicked = LayoutManager.GetImage("btn_vote_clicked");
			this.btnWebVote.BackgroundImageHover = LayoutManager.GetImage("btn_vote_hover");
			this.btnWebVote.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnWebVote.Location = new System.Drawing.Point(420, 372);
			this.btnWebVote.Name = "btnWebVote";
			this.btnWebVote.Size = new System.Drawing.Size(72, 19);
			this.btnWebVote.TabIndex = 24;
			this.btnWebVote.TabStop = false;
			this.btnWebVote.Click += new System.EventHandler(this.btnWebVote_Click);
			// 
			// btnGameSetup
			// 
			this.btnGameSetup.BackgroundImage = LayoutManager.GetImage("btn_setup");
			this.btnGameSetup.BackgroundImageClicked = LayoutManager.GetImage("btn_setup_clicked");
			this.btnGameSetup.BackgroundImageHover = LayoutManager.GetImage("btn_setup_hover");
			this.btnGameSetup.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnGameSetup.Location = new System.Drawing.Point(278, 372);
			this.btnGameSetup.Name = "btnGameSetup";
			this.btnGameSetup.Size = new System.Drawing.Size(72, 19);
			this.btnGameSetup.TabIndex = 23;
			this.btnGameSetup.TabStop = false;
			this.btnGameSetup.Click += new System.EventHandler(this.btnGameSetup_Click);
			// 
			// stateProgress
			// 
			this.stateProgress.Image = ((System.Drawing.Image)(resources.GetObject("stateProgress.Image")));
			this.stateProgress.Location = new System.Drawing.Point(293, 352);
			this.stateProgress.Name = "stateProgress";
			this.stateProgress.Size = new System.Drawing.Size(540, 8);
			this.stateProgress.TabIndex = 21;
			this.stateProgress.TabStop = false;
			// 
			// btnGameStart
			// 
			this.btnGameStart.BackgroundImage = LayoutManager.GetImage("btn_start");
			this.btnGameStart.BackgroundImageClicked = LayoutManager.GetImage("btn_start_clicked");
			this.btnGameStart.BackgroundImageHover = LayoutManager.GetImage("btn_start_hover");
			this.btnGameStart.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnGameStart.Location = new System.Drawing.Point(856, 334);
			this.btnGameStart.Name = "btnGameStart";
			this.btnGameStart.Size = new System.Drawing.Size(87, 31);
			this.btnGameStart.TabIndex = 16;
			this.btnGameStart.TabStop = false;
			this.btnGameStart.Click += new System.EventHandler(this.btnGameStart_Click);
			// 
			// btnWebForum
			// 
			this.btnWebForum.BackgroundImage = LayoutManager.GetImage("btn_forum");
			this.btnWebForum.BackgroundImageClicked = LayoutManager.GetImage("btn_forum_clicked");
			this.btnWebForum.BackgroundImageHover = LayoutManager.GetImage("btn_forum_hover");
			this.btnWebForum.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnWebForum.Location = new System.Drawing.Point(349, 372);
			this.btnWebForum.Name = "btnWebForum";
			this.btnWebForum.Size = new System.Drawing.Size(72, 19);
			this.btnWebForum.TabIndex = 15;
			this.btnWebForum.TabStop = false;
			this.btnWebForum.Click += new System.EventHandler(this.btnForum_Click);
			// 
			// webBrowser
			// 
			this.webBrowser.Location = new System.Drawing.Point(283, 60);
			this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser.Name = "webBrowser";
			this.webBrowser.ScrollBarsEnabled = false;
			this.webBrowser.Size = new System.Drawing.Size(549, 260);
			this.webBrowser.TabIndex = 0;
			this.webBrowser.Url = new System.Uri("http://funro.nu/patcher/notice.html", System.UriKind.Absolute);
			// 
			// lblStatusText
			// 
			this.lblStatusText.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblStatusText.ForeColor = System.Drawing.Color.Gray;
			this.lblStatusText.Location = new System.Drawing.Point(289, 329);
			this.lblStatusText.Margin = new System.Windows.Forms.Padding(0);
			this.lblStatusText.Name = "lblStatusText";
			this.lblStatusText.Size = new System.Drawing.Size(544, 20);
			this.lblStatusText.TabIndex = 0;
			this.lblStatusText.Text = "Downloading Patch Data...";
			this.lblStatusText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panelHead
			// 
			this.panelHead.BackColor = System.Drawing.Color.Transparent;
			this.panelHead.Controls.Add(this.btnClose);
			this.panelHead.Location = new System.Drawing.Point(278, 16);
			this.panelHead.Name = "panelHead";
			this.panelHead.Size = new System.Drawing.Size(679, 17);
			this.panelHead.TabIndex = 5;
			this.panelHead.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelHead_MouseDown);
			this.panelHead.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelHead_MouseMove);
			this.panelHead.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelHead_MouseUp);
			// 
			// btnClose
			// 
			this.btnClose.BackgroundImage = LayoutManager.GetImage("btn_close");
			this.btnClose.BackgroundImageClicked = null;
			this.btnClose.BackgroundImageHover = LayoutManager.GetImage("btn_close_hover");
			this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnClose.Location = new System.Drawing.Point(664, 4);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(9, 9);
			this.btnClose.TabIndex = 16;
			this.btnClose.TabStop = false;
			this.btnClose.Click += new System.EventHandler(this.lblClose_Click);
			// 
			// frmMain
			// 
			this.BackColor = System.Drawing.Color.MistyRose;
			this.ClientSize = new System.Drawing.Size(957, 444);
			this.Controls.Add(this.panelMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "InsaneRO Patcher";
			this.TransparencyKey = System.Drawing.Color.MistyRose;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			this.Shown += new System.EventHandler(this.frmMain_Shown);
			this.panelMain.ResumeLayout(false);
			this.panelMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.stateWoe)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.stateMap)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.stateChar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.stateLogin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.btnPatcherOptions)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.btnWebVote)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.btnGameSetup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.stateProgress)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.btnGameStart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.btnWebForum)).EndInit();
			this.panelHead.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblStatusText;
		private System.Windows.Forms.WebBrowser webBrowser;
		private System.Windows.Forms.Panel panelHead;
		private System.Windows.Forms.Panel panelMain;
		private GodLesZ.FunRO.Patcher.Controls.ImageButon btnWebForum;
		private GodLesZ.FunRO.Patcher.Controls.ImageButon btnGameStart;
		private System.Windows.Forms.PictureBox stateProgress;
		private GodLesZ.FunRO.Patcher.Controls.ImageButon btnClose;
		private GodLesZ.FunRO.Patcher.Controls.ImageButon btnPatcherOptions;
		private GodLesZ.FunRO.Patcher.Controls.ImageButon btnWebVote;
		private GodLesZ.FunRO.Patcher.Controls.ImageButon btnGameSetup;
		private System.Windows.Forms.PictureBox stateLogin;
		private System.Windows.Forms.PictureBox stateWoe;
		private System.Windows.Forms.Label statePlayers;
		private System.Windows.Forms.PictureBox stateMap;
		private System.Windows.Forms.PictureBox stateChar;
	}
}

