namespace MapRead.GAT {
	partial class GATViewer {
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
			this.btnOpenGat = new System.Windows.Forms.Button();
			this.txtFile = new System.Windows.Forms.TextBox();
			this.lblZoomText = new System.Windows.Forms.Label();
			this.btnZoomPlus = new System.Windows.Forms.Button();
			this.btnZoomMinus = new System.Windows.Forms.Button();
			this.lblZoom = new System.Windows.Forms.Label();
			this.PictureBoxColor6 = new System.Windows.Forms.PictureBox();
			this.lblColor6 = new System.Windows.Forms.Label();
			this.PictureBoxColor5 = new System.Windows.Forms.PictureBox();
			this.lblColor5 = new System.Windows.Forms.Label();
			this.PictureBoxColor4 = new System.Windows.Forms.PictureBox();
			this.lblColor4 = new System.Windows.Forms.Label();
			this.PictureBoxColor3 = new System.Windows.Forms.PictureBox();
			this.lblColor3 = new System.Windows.Forms.Label();
			this.PictureBoxColor2 = new System.Windows.Forms.PictureBox();
			this.lblColor2 = new System.Windows.Forms.Label();
			this.PictureBoxColor1 = new System.Windows.Forms.PictureBox();
			this.lblColor1 = new System.Windows.Forms.Label();
			this.PictureBoxMap = new System.Windows.Forms.PictureBox();
			this.PictureBoxColor7 = new System.Windows.Forms.PictureBox();
			this.lblColor7 = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.programmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.neuZeichnenRefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.imageSpeichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.xMLVonMapSpeichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			( (System.ComponentModel.ISupportInitialize)( this.PictureBoxColor6 ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.PictureBoxColor5 ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.PictureBoxColor4 ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.PictureBoxColor3 ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.PictureBoxColor2 ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.PictureBoxColor1 ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.PictureBoxMap ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.PictureBoxColor7 ) ).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOpenGat
			// 
			this.btnOpenGat.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnOpenGat.Location = new System.Drawing.Point( 353, 33 );
			this.btnOpenGat.Name = "btnOpenGat";
			this.btnOpenGat.Size = new System.Drawing.Size( 81, 20 );
			this.btnOpenGat.TabIndex = 0;
			this.btnOpenGat.Text = "Open GAT";
			this.btnOpenGat.UseVisualStyleBackColor = true;
			this.btnOpenGat.Click += new System.EventHandler( this.btnOpenGat_Click );
			// 
			// txtFile
			// 
			this.txtFile.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtFile.Location = new System.Drawing.Point( 13, 33 );
			this.txtFile.Name = "txtFile";
			this.txtFile.Size = new System.Drawing.Size( 334, 20 );
			this.txtFile.TabIndex = 1;
			// 
			// lblZoomText
			// 
			this.lblZoomText.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.lblZoomText.Location = new System.Drawing.Point( 544, 33 );
			this.lblZoomText.Name = "lblZoomText";
			this.lblZoomText.Size = new System.Drawing.Size( 38, 20 );
			this.lblZoomText.TabIndex = 4;
			this.lblZoomText.Text = "Zoom:";
			this.lblZoomText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnZoomPlus
			// 
			this.btnZoomPlus.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnZoomPlus.Location = new System.Drawing.Point( 480, 33 );
			this.btnZoomPlus.Name = "btnZoomPlus";
			this.btnZoomPlus.Size = new System.Drawing.Size( 27, 20 );
			this.btnZoomPlus.TabIndex = 5;
			this.btnZoomPlus.Text = "+1";
			this.btnZoomPlus.UseVisualStyleBackColor = true;
			this.btnZoomPlus.Click += new System.EventHandler( this.btnZoomPlus_Click );
			// 
			// btnZoomMinus
			// 
			this.btnZoomMinus.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnZoomMinus.Location = new System.Drawing.Point( 513, 33 );
			this.btnZoomMinus.Name = "btnZoomMinus";
			this.btnZoomMinus.Size = new System.Drawing.Size( 25, 20 );
			this.btnZoomMinus.TabIndex = 6;
			this.btnZoomMinus.Text = "-1";
			this.btnZoomMinus.UseVisualStyleBackColor = true;
			this.btnZoomMinus.Click += new System.EventHandler( this.btnZoomMinus_Click );
			// 
			// lblZoom
			// 
			this.lblZoom.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.lblZoom.Location = new System.Drawing.Point( 588, 32 );
			this.lblZoom.Name = "lblZoom";
			this.lblZoom.Size = new System.Drawing.Size( 35, 20 );
			this.lblZoom.TabIndex = 7;
			this.lblZoom.Text = "1";
			this.lblZoom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// PictureBoxColor6
			// 
			this.PictureBoxColor6.Location = new System.Drawing.Point( 561, 103 );
			this.PictureBoxColor6.Name = "PictureBoxColor6";
			this.PictureBoxColor6.Size = new System.Drawing.Size( 31, 13 );
			this.PictureBoxColor6.TabIndex = 23;
			this.PictureBoxColor6.TabStop = false;
			this.PictureBoxColor6.Click += new System.EventHandler( this.PictureBoxColor6_Click );
			// 
			// lblColor6
			// 
			this.lblColor6.AutoSize = true;
			this.lblColor6.Location = new System.Drawing.Point( 350, 103 );
			this.lblColor6.Name = "lblColor6";
			this.lblColor6.Size = new System.Drawing.Size( 35, 13 );
			this.lblColor6.TabIndex = 22;
			this.lblColor6.Text = "label6";
			// 
			// PictureBoxColor5
			// 
			this.PictureBoxColor5.Location = new System.Drawing.Point( 561, 84 );
			this.PictureBoxColor5.Name = "PictureBoxColor5";
			this.PictureBoxColor5.Size = new System.Drawing.Size( 31, 13 );
			this.PictureBoxColor5.TabIndex = 21;
			this.PictureBoxColor5.TabStop = false;
			this.PictureBoxColor5.Click += new System.EventHandler( this.PictureBoxColor5_Click );
			// 
			// lblColor5
			// 
			this.lblColor5.AutoSize = true;
			this.lblColor5.Location = new System.Drawing.Point( 350, 84 );
			this.lblColor5.Name = "lblColor5";
			this.lblColor5.Size = new System.Drawing.Size( 35, 13 );
			this.lblColor5.TabIndex = 20;
			this.lblColor5.Text = "label5";
			// 
			// PictureBoxColor4
			// 
			this.PictureBoxColor4.Location = new System.Drawing.Point( 561, 65 );
			this.PictureBoxColor4.Name = "PictureBoxColor4";
			this.PictureBoxColor4.Size = new System.Drawing.Size( 31, 13 );
			this.PictureBoxColor4.TabIndex = 19;
			this.PictureBoxColor4.TabStop = false;
			this.PictureBoxColor4.Click += new System.EventHandler( this.PictureBoxColor4_Click );
			// 
			// lblColor4
			// 
			this.lblColor4.AutoSize = true;
			this.lblColor4.Location = new System.Drawing.Point( 350, 65 );
			this.lblColor4.Name = "lblColor4";
			this.lblColor4.Size = new System.Drawing.Size( 35, 13 );
			this.lblColor4.TabIndex = 18;
			this.lblColor4.Text = "label4";
			// 
			// PictureBoxColor3
			// 
			this.PictureBoxColor3.Location = new System.Drawing.Point( 223, 103 );
			this.PictureBoxColor3.Name = "PictureBoxColor3";
			this.PictureBoxColor3.Size = new System.Drawing.Size( 31, 13 );
			this.PictureBoxColor3.TabIndex = 17;
			this.PictureBoxColor3.TabStop = false;
			this.PictureBoxColor3.Click += new System.EventHandler( this.PictureBoxColor3_Click );
			// 
			// lblColor3
			// 
			this.lblColor3.AutoSize = true;
			this.lblColor3.Location = new System.Drawing.Point( 12, 103 );
			this.lblColor3.Name = "lblColor3";
			this.lblColor3.Size = new System.Drawing.Size( 35, 13 );
			this.lblColor3.TabIndex = 16;
			this.lblColor3.Text = "label3";
			// 
			// PictureBoxColor2
			// 
			this.PictureBoxColor2.Location = new System.Drawing.Point( 223, 84 );
			this.PictureBoxColor2.Name = "PictureBoxColor2";
			this.PictureBoxColor2.Size = new System.Drawing.Size( 31, 13 );
			this.PictureBoxColor2.TabIndex = 15;
			this.PictureBoxColor2.TabStop = false;
			this.PictureBoxColor2.Click += new System.EventHandler( this.PictureBoxColor2_Click );
			// 
			// lblColor2
			// 
			this.lblColor2.AutoSize = true;
			this.lblColor2.Location = new System.Drawing.Point( 12, 84 );
			this.lblColor2.Name = "lblColor2";
			this.lblColor2.Size = new System.Drawing.Size( 35, 13 );
			this.lblColor2.TabIndex = 14;
			this.lblColor2.Text = "label2";
			// 
			// PictureBoxColor1
			// 
			this.PictureBoxColor1.Location = new System.Drawing.Point( 223, 65 );
			this.PictureBoxColor1.Name = "PictureBoxColor1";
			this.PictureBoxColor1.Size = new System.Drawing.Size( 31, 13 );
			this.PictureBoxColor1.TabIndex = 13;
			this.PictureBoxColor1.TabStop = false;
			this.PictureBoxColor1.Click += new System.EventHandler( this.PictureBoxColor1_Click );
			// 
			// lblColor1
			// 
			this.lblColor1.AutoSize = true;
			this.lblColor1.Location = new System.Drawing.Point( 12, 65 );
			this.lblColor1.Name = "lblColor1";
			this.lblColor1.Size = new System.Drawing.Size( 35, 13 );
			this.lblColor1.TabIndex = 12;
			this.lblColor1.Text = "label1";
			// 
			// PictureBoxMap
			// 
			this.PictureBoxMap.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.PictureBoxMap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.PictureBoxMap.Location = new System.Drawing.Point( 12, 181 );
			this.PictureBoxMap.Name = "PictureBoxMap";
			this.PictureBoxMap.Size = new System.Drawing.Size( 611, 381 );
			this.PictureBoxMap.TabIndex = 24;
			this.PictureBoxMap.TabStop = false;
			// 
			// PictureBoxColor7
			// 
			this.PictureBoxColor7.Location = new System.Drawing.Point( 561, 122 );
			this.PictureBoxColor7.Name = "PictureBoxColor7";
			this.PictureBoxColor7.Size = new System.Drawing.Size( 31, 13 );
			this.PictureBoxColor7.TabIndex = 26;
			this.PictureBoxColor7.TabStop = false;
			this.PictureBoxColor7.Click += new System.EventHandler( this.PictureBoxColor7_Click );
			// 
			// lblColor7
			// 
			this.lblColor7.AutoSize = true;
			this.lblColor7.Location = new System.Drawing.Point( 350, 122 );
			this.lblColor7.Name = "lblColor7";
			this.lblColor7.Size = new System.Drawing.Size( 35, 13 );
			this.lblColor7.TabIndex = 25;
			this.lblColor7.Text = "label7";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.programmToolStripMenuItem,
            this.mapToolStripMenuItem} );
			this.menuStrip1.Location = new System.Drawing.Point( 0, 0 );
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size( 635, 24 );
			this.menuStrip1.TabIndex = 27;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// programmToolStripMenuItem
			// 
			this.programmToolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.beendenToolStripMenuItem} );
			this.programmToolStripMenuItem.Name = "programmToolStripMenuItem";
			this.programmToolStripMenuItem.Size = new System.Drawing.Size( 67, 20 );
			this.programmToolStripMenuItem.Text = "Programm";
			// 
			// beendenToolStripMenuItem
			// 
			this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
			this.beendenToolStripMenuItem.Size = new System.Drawing.Size( 152, 22 );
			this.beendenToolStripMenuItem.Text = "Beenden";
			this.beendenToolStripMenuItem.Click += new System.EventHandler( this.beendenToolStripMenuItem_Click );
			// 
			// mapToolStripMenuItem
			// 
			this.mapToolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.neuZeichnenRefreshToolStripMenuItem,
            this.toolStripSeparator1,
            this.imageSpeichernToolStripMenuItem,
            this.xMLVonMapSpeichernToolStripMenuItem} );
			this.mapToolStripMenuItem.Name = "mapToolStripMenuItem";
			this.mapToolStripMenuItem.Size = new System.Drawing.Size( 39, 20 );
			this.mapToolStripMenuItem.Text = "Map";
			// 
			// neuZeichnenRefreshToolStripMenuItem
			// 
			this.neuZeichnenRefreshToolStripMenuItem.Name = "neuZeichnenRefreshToolStripMenuItem";
			this.neuZeichnenRefreshToolStripMenuItem.Size = new System.Drawing.Size( 180, 22 );
			this.neuZeichnenRefreshToolStripMenuItem.Text = "Neu zeichnen/Refresh";
			this.neuZeichnenRefreshToolStripMenuItem.Click += new System.EventHandler( this.neuZeichnenRefreshToolStripMenuItem_Click );
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size( 177, 6 );
			// 
			// imageSpeichernToolStripMenuItem
			// 
			this.imageSpeichernToolStripMenuItem.Name = "imageSpeichernToolStripMenuItem";
			this.imageSpeichernToolStripMenuItem.Size = new System.Drawing.Size( 180, 22 );
			this.imageSpeichernToolStripMenuItem.Text = "Image speichern";
			this.imageSpeichernToolStripMenuItem.Click += new System.EventHandler( this.imageSpeichernToolStripMenuItem_Click );
			// 
			// xMLVonMapSpeichernToolStripMenuItem
			// 
			this.xMLVonMapSpeichernToolStripMenuItem.Name = "xMLVonMapSpeichernToolStripMenuItem";
			this.xMLVonMapSpeichernToolStripMenuItem.Size = new System.Drawing.Size( 186, 22 );
			this.xMLVonMapSpeichernToolStripMenuItem.Text = "XML von Map speichern";
			this.xMLVonMapSpeichernToolStripMenuItem.Click += new System.EventHandler( this.xMLVonMapSpeichernToolStripMenuItem_Click );
			// 
			// GATViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size( 635, 574 );
			this.Controls.Add( this.PictureBoxColor7 );
			this.Controls.Add( this.lblColor7 );
			this.Controls.Add( this.PictureBoxMap );
			this.Controls.Add( this.PictureBoxColor6 );
			this.Controls.Add( this.lblColor6 );
			this.Controls.Add( this.PictureBoxColor5 );
			this.Controls.Add( this.lblColor5 );
			this.Controls.Add( this.PictureBoxColor4 );
			this.Controls.Add( this.lblColor4 );
			this.Controls.Add( this.PictureBoxColor3 );
			this.Controls.Add( this.lblColor3 );
			this.Controls.Add( this.PictureBoxColor2 );
			this.Controls.Add( this.lblColor2 );
			this.Controls.Add( this.PictureBoxColor1 );
			this.Controls.Add( this.lblColor1 );
			this.Controls.Add( this.lblZoom );
			this.Controls.Add( this.btnZoomMinus );
			this.Controls.Add( this.btnZoomPlus );
			this.Controls.Add( this.lblZoomText );
			this.Controls.Add( this.txtFile );
			this.Controls.Add( this.btnOpenGat );
			this.Controls.Add( this.menuStrip1 );
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "GATViewer";
			this.Text = "Gat View";
			this.Paint += new System.Windows.Forms.PaintEventHandler( this.MapRead_Paint );
			( (System.ComponentModel.ISupportInitialize)( this.PictureBoxColor6 ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.PictureBoxColor5 ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.PictureBoxColor4 ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.PictureBoxColor3 ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.PictureBoxColor2 ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.PictureBoxColor1 ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.PictureBoxMap ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.PictureBoxColor7 ) ).EndInit();
			this.menuStrip1.ResumeLayout( false );
			this.menuStrip1.PerformLayout();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnOpenGat;
		private System.Windows.Forms.TextBox txtFile;
		private System.Windows.Forms.Label lblZoomText;
		private System.Windows.Forms.Button btnZoomPlus;
		private System.Windows.Forms.Button btnZoomMinus;
		private System.Windows.Forms.Label lblZoom;
		private System.Windows.Forms.PictureBox PictureBoxColor6;
		private System.Windows.Forms.Label lblColor6;
		private System.Windows.Forms.PictureBox PictureBoxColor5;
		private System.Windows.Forms.Label lblColor5;
		private System.Windows.Forms.PictureBox PictureBoxColor4;
		private System.Windows.Forms.Label lblColor4;
		private System.Windows.Forms.PictureBox PictureBoxColor3;
		private System.Windows.Forms.Label lblColor3;
		private System.Windows.Forms.PictureBox PictureBoxColor2;
		private System.Windows.Forms.Label lblColor2;
		private System.Windows.Forms.PictureBox PictureBoxColor1;
		private System.Windows.Forms.Label lblColor1;
		private System.Windows.Forms.PictureBox PictureBoxMap;
		private System.Windows.Forms.PictureBox PictureBoxColor7;
		private System.Windows.Forms.Label lblColor7;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem programmToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mapToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem neuZeichnenRefreshToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem imageSpeichernToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem xMLVonMapSpeichernToolStripMenuItem;
	}
}

