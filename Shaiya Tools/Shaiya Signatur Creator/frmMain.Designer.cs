namespace Shaiya_Signatur_Creator {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( frmMain ) );
			this.MenuMain = new System.Windows.Forms.MenuStrip();
			this.StatusMain = new System.Windows.Forms.StatusStrip();
			this.label1 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.txtLevel = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtHP = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtMP = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtAP = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.MenuProgram = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuProgramClose = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuImage = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuImageSave = new System.Windows.Forms.ToolStripMenuItem();
			this.picPreview = new System.Windows.Forms.PictureBox();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuImageLoadAva = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuMain.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize)( this.picPreview ) ).BeginInit();
			this.SuspendLayout();
			// 
			// MenuMain
			// 
			this.MenuMain.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.MenuProgram,
            this.MenuImage} );
			this.MenuMain.Location = new System.Drawing.Point( 0, 0 );
			this.MenuMain.Name = "MenuMain";
			this.MenuMain.Size = new System.Drawing.Size( 379, 24 );
			this.MenuMain.TabIndex = 0;
			this.MenuMain.Text = "menuStrip1";
			// 
			// StatusMain
			// 
			this.StatusMain.Location = new System.Drawing.Point( 0, 248 );
			this.StatusMain.Name = "StatusMain";
			this.StatusMain.Size = new System.Drawing.Size( 379, 22 );
			this.StatusMain.TabIndex = 1;
			this.StatusMain.Text = "statusStrip1";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 9, 147 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 35, 13 );
			this.label1.TabIndex = 3;
			this.label1.Text = "Name";
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point( 50, 144 );
			this.txtName.MaxLength = 13;
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size( 88, 20 );
			this.txtName.TabIndex = 4;
			this.txtName.TextChanged += new System.EventHandler( this.Controls_TextChanged );
			// 
			// txtLevel
			// 
			this.txtLevel.Location = new System.Drawing.Point( 185, 144 );
			this.txtLevel.MaxLength = 2;
			this.txtLevel.Name = "txtLevel";
			this.txtLevel.Size = new System.Drawing.Size( 40, 20 );
			this.txtLevel.TabIndex = 6;
			this.txtLevel.TextChanged += new System.EventHandler( this.Controls_TextChanged );
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 144, 147 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 33, 13 );
			this.label2.TabIndex = 5;
			this.label2.Text = "Level";
			// 
			// txtHP
			// 
			this.txtHP.Location = new System.Drawing.Point( 40, 170 );
			this.txtHP.MaxLength = 5;
			this.txtHP.Name = "txtHP";
			this.txtHP.Size = new System.Drawing.Size( 40, 20 );
			this.txtHP.TabIndex = 8;
			this.txtHP.Text = "99999";
			this.txtHP.TextChanged += new System.EventHandler( this.Controls_TextChanged );
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point( 12, 173 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 22, 13 );
			this.label3.TabIndex = 7;
			this.label3.Text = "HP";
			// 
			// txtMP
			// 
			this.txtMP.Location = new System.Drawing.Point( 113, 170 );
			this.txtMP.MaxLength = 5;
			this.txtMP.Name = "txtMP";
			this.txtMP.Size = new System.Drawing.Size( 40, 20 );
			this.txtMP.TabIndex = 10;
			this.txtMP.Text = "99999";
			this.txtMP.TextChanged += new System.EventHandler( this.Controls_TextChanged );
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point( 85, 173 );
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size( 23, 13 );
			this.label4.TabIndex = 9;
			this.label4.Text = "MP";
			// 
			// txtAP
			// 
			this.txtAP.Location = new System.Drawing.Point( 185, 170 );
			this.txtAP.MaxLength = 5;
			this.txtAP.Name = "txtAP";
			this.txtAP.Size = new System.Drawing.Size( 40, 20 );
			this.txtAP.TabIndex = 12;
			this.txtAP.Text = "99999";
			this.txtAP.TextChanged += new System.EventHandler( this.Controls_TextChanged );
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point( 157, 173 );
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size( 21, 13 );
			this.label5.TabIndex = 11;
			this.label5.Text = "AP";
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
			// MenuImage
			// 
			this.MenuImage.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.MenuImageLoadAva,
            this.toolStripSeparator1,
            this.MenuImageSave} );
			this.MenuImage.Name = "MenuImage";
			this.MenuImage.Size = new System.Drawing.Size( 35, 20 );
			this.MenuImage.Text = "Bild";
			// 
			// MenuImageSave
			// 
			this.MenuImageSave.Name = "MenuImageSave";
			this.MenuImageSave.Size = new System.Drawing.Size( 152, 22 );
			this.MenuImageSave.Text = "Speichern...";
			this.MenuImageSave.Click += new System.EventHandler( this.MenuImageSave_Click );
			// 
			// picPreview
			// 
			this.picPreview.BackColor = System.Drawing.Color.Transparent;
			this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picPreview.Location = new System.Drawing.Point( 12, 27 );
			this.picPreview.Name = "picPreview";
			this.picPreview.Size = new System.Drawing.Size( 213, 104 );
			this.picPreview.TabIndex = 2;
			this.picPreview.TabStop = false;
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size( 149, 6 );
			// 
			// MenuImageLoadAva
			// 
			this.MenuImageLoadAva.Name = "MenuImageLoadAva";
			this.MenuImageLoadAva.Size = new System.Drawing.Size( 152, 22 );
			this.MenuImageLoadAva.Text = "Avatar laden...";
			this.MenuImageLoadAva.Click += new System.EventHandler( this.MenuImageLoadAva_Click );
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 379, 270 );
			this.Controls.Add( this.txtAP );
			this.Controls.Add( this.label5 );
			this.Controls.Add( this.txtMP );
			this.Controls.Add( this.label4 );
			this.Controls.Add( this.txtHP );
			this.Controls.Add( this.label3 );
			this.Controls.Add( this.txtLevel );
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.txtName );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.picPreview );
			this.Controls.Add( this.StatusMain );
			this.Controls.Add( this.MenuMain );
			this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
			this.MainMenuStrip = this.MenuMain;
			this.Name = "frmMain";
			this.Text = "Signatur Creator - by GodLesZ 4 Obscura";
			this.MenuMain.ResumeLayout( false );
			this.MenuMain.PerformLayout();
			( (System.ComponentModel.ISupportInitialize)( this.picPreview ) ).EndInit();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip MenuMain;
		private System.Windows.Forms.StatusStrip StatusMain;
		private System.Windows.Forms.PictureBox picPreview;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.TextBox txtLevel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtHP;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtMP;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtAP;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ToolStripMenuItem MenuProgram;
		private System.Windows.Forms.ToolStripMenuItem MenuProgramClose;
		private System.Windows.Forms.ToolStripMenuItem MenuImage;
		private System.Windows.Forms.ToolStripMenuItem MenuImageSave;
		private System.Windows.Forms.ToolStripMenuItem MenuImageLoadAva;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
	}
}

