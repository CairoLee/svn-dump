namespace ShaiyaEmblemGen {
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.imagesBG = new System.Windows.Forms.ImageList( this.components );
			this.imagesFG = new System.Windows.Forms.ImageList( this.components );
			this.imagesSY = new System.Windows.Forms.ImageList( this.components );
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.imageBoxBG = new ShaiyaEmblemGen.ImageComboBox();
			this.imageBoxSY = new ShaiyaEmblemGen.ImageComboBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.imageBoxFG = new ShaiyaEmblemGen.ImageComboBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.colorBG = new ShaiyaEmblemGen.ColorBox();
			this.panel4 = new System.Windows.Forms.Panel();
			this.colorFG = new ShaiyaEmblemGen.ColorBox();
			this.panel5 = new System.Windows.Forms.Panel();
			this.colorSY = new ShaiyaEmblemGen.ColorBox();
			this.imageEmblem = new System.Windows.Forms.PictureBox();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel5.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize)( this.imageEmblem ) ).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 46, 0 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 62, 13 );
			this.label1.TabIndex = 1;
			this.label1.Text = "Hintergrund";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 173, 0 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 65, 13 );
			this.label2.TabIndex = 4;
			this.label2.Text = "Vordergrund";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point( 300, 0 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 41, 13 );
			this.label3.TabIndex = 7;
			this.label3.Text = "Symbol";
			// 
			// imagesBG
			// 
			this.imagesBG.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imagesBG.ImageSize = new System.Drawing.Size( 64, 64 );
			this.imagesBG.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// imagesFG
			// 
			this.imagesFG.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imagesFG.ImageSize = new System.Drawing.Size( 64, 64 );
			this.imagesFG.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// imagesSY
			// 
			this.imagesSY.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imagesSY.ImageSize = new System.Drawing.Size( 64, 64 );
			this.imagesSY.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Absolute, 43F ) );
			this.tableLayoutPanel1.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 86.07954F ) );
			this.tableLayoutPanel1.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Absolute, 127F ) );
			this.tableLayoutPanel1.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Absolute, 127F ) );
			this.tableLayoutPanel1.Controls.Add( this.label1, 1, 0 );
			this.tableLayoutPanel1.Controls.Add( this.imageBoxBG, 1, 1 );
			this.tableLayoutPanel1.Controls.Add( this.label3, 3, 0 );
			this.tableLayoutPanel1.Controls.Add( this.imageBoxSY, 3, 1 );
			this.tableLayoutPanel1.Controls.Add( this.panel1, 0, 1 );
			this.tableLayoutPanel1.Controls.Add( this.panel2, 0, 2 );
			this.tableLayoutPanel1.Controls.Add( this.label2, 2, 0 );
			this.tableLayoutPanel1.Controls.Add( this.imageBoxFG, 2, 1 );
			this.tableLayoutPanel1.Controls.Add( this.panel3, 1, 2 );
			this.tableLayoutPanel1.Controls.Add( this.panel4, 2, 2 );
			this.tableLayoutPanel1.Controls.Add( this.panel5, 3, 2 );
			this.tableLayoutPanel1.Location = new System.Drawing.Point( 12, 12 );
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Absolute, 13F ) );
			this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 50F ) );
			this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Absolute, 31F ) );
			this.tableLayoutPanel1.Size = new System.Drawing.Size( 424, 122 );
			this.tableLayoutPanel1.TabIndex = 10;
			// 
			// imageBoxBG
			// 
			this.imageBoxBG.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.imageBoxBG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.imageBoxBG.FormattingEnabled = true;
			this.imageBoxBG.ImageList = this.imagesBG;
			this.imageBoxBG.ItemHeight = 64;
			this.imageBoxBG.Location = new System.Drawing.Point( 46, 16 );
			this.imageBoxBG.Name = "imageBoxBG";
			this.imageBoxBG.Size = new System.Drawing.Size( 121, 70 );
			this.imageBoxBG.TabIndex = 0;
			this.imageBoxBG.SelectedIndexChanged += new System.EventHandler( this.ImageBox_SelectedIndexChanged );
			// 
			// imageBoxSY
			// 
			this.imageBoxSY.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.imageBoxSY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.imageBoxSY.FormattingEnabled = true;
			this.imageBoxSY.ImageList = this.imagesSY;
			this.imageBoxSY.ItemHeight = 64;
			this.imageBoxSY.Location = new System.Drawing.Point( 300, 16 );
			this.imageBoxSY.Name = "imageBoxSY";
			this.imageBoxSY.Size = new System.Drawing.Size( 121, 70 );
			this.imageBoxSY.TabIndex = 6;
			this.imageBoxSY.SelectedIndexChanged += new System.EventHandler( this.ImageBox_SelectedIndexChanged );
			// 
			// panel1
			// 
			this.panel1.Controls.Add( this.label4 );
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point( 3, 16 );
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size( 37, 72 );
			this.panel1.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point( 2, 28 );
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size( 24, 13 );
			this.label4.TabIndex = 2;
			this.label4.Text = "Bild";
			// 
			// panel2
			// 
			this.panel2.Controls.Add( this.label5 );
			this.panel2.Location = new System.Drawing.Point( 3, 94 );
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size( 37, 18 );
			this.panel2.TabIndex = 6;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point( 2, 6 );
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size( 34, 13 );
			this.label5.TabIndex = 0;
			this.label5.Text = "Farbe";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// imageBoxFG
			// 
			this.imageBoxFG.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.imageBoxFG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.imageBoxFG.FormattingEnabled = true;
			this.imageBoxFG.ImageList = this.imagesFG;
			this.imageBoxFG.ItemHeight = 64;
			this.imageBoxFG.Location = new System.Drawing.Point( 173, 16 );
			this.imageBoxFG.Name = "imageBoxFG";
			this.imageBoxFG.Size = new System.Drawing.Size( 121, 70 );
			this.imageBoxFG.TabIndex = 3;
			this.imageBoxFG.SelectedIndexChanged += new System.EventHandler( this.ImageBox_SelectedIndexChanged );
			// 
			// panel3
			// 
			this.panel3.Controls.Add( this.colorBG );
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point( 46, 94 );
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size( 121, 25 );
			this.panel3.TabIndex = 9;
			// 
			// colorBG
			// 
			this.colorBG.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.Black,
        System.Drawing.Color.Gray,
        System.Drawing.Color.Maroon,
        System.Drawing.Color.Olive,
        System.Drawing.Color.Green,
        System.Drawing.Color.Teal,
        System.Drawing.Color.Navy,
        System.Drawing.Color.Purple,
        System.Drawing.Color.White,
        System.Drawing.Color.Silver,
        System.Drawing.Color.Red,
        System.Drawing.Color.Yellow,
        System.Drawing.Color.Lime,
        System.Drawing.Color.Aqua,
        System.Drawing.Color.Blue,
        System.Drawing.Color.Fuchsia};
			this.colorBG.ColorsPerRow = 6;
			this.colorBG.Dock = System.Windows.Forms.DockStyle.Fill;
			this.colorBG.Location = new System.Drawing.Point( 0, 0 );
			this.colorBG.Name = "colorBG";
			this.colorBG.SelectedColor = System.Drawing.Color.Black;
			this.colorBG.Size = new System.Drawing.Size( 121, 25 );
			this.colorBG.TabIndex = 0;
			this.colorBG.ColorChanged += new ShaiyaEmblemGen.ColorChangedHandler( this.ColorBox_ColorChanged );
			// 
			// panel4
			// 
			this.panel4.Controls.Add( this.colorFG );
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point( 173, 94 );
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size( 121, 25 );
			this.panel4.TabIndex = 10;
			// 
			// colorFG
			// 
			this.colorFG.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.Black,
        System.Drawing.Color.Gray,
        System.Drawing.Color.Maroon,
        System.Drawing.Color.Olive,
        System.Drawing.Color.Green,
        System.Drawing.Color.Teal,
        System.Drawing.Color.Navy,
        System.Drawing.Color.Purple,
        System.Drawing.Color.White,
        System.Drawing.Color.Silver,
        System.Drawing.Color.Red,
        System.Drawing.Color.Yellow,
        System.Drawing.Color.Lime,
        System.Drawing.Color.Aqua,
        System.Drawing.Color.Blue,
        System.Drawing.Color.Fuchsia};
			this.colorFG.ColorsPerRow = 6;
			this.colorFG.Dock = System.Windows.Forms.DockStyle.Fill;
			this.colorFG.Location = new System.Drawing.Point( 0, 0 );
			this.colorFG.Name = "colorFG";
			this.colorFG.SelectedColor = System.Drawing.Color.Black;
			this.colorFG.Size = new System.Drawing.Size( 121, 25 );
			this.colorFG.TabIndex = 1;
			this.colorFG.ColorChanged += new ShaiyaEmblemGen.ColorChangedHandler( this.ColorBox_ColorChanged );
			// 
			// panel5
			// 
			this.panel5.Controls.Add( this.colorSY );
			this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel5.Location = new System.Drawing.Point( 300, 94 );
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size( 121, 25 );
			this.panel5.TabIndex = 11;
			// 
			// colorSY
			// 
			this.colorSY.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.Black,
        System.Drawing.Color.Gray,
        System.Drawing.Color.Maroon,
        System.Drawing.Color.Olive,
        System.Drawing.Color.Green,
        System.Drawing.Color.Teal,
        System.Drawing.Color.Navy,
        System.Drawing.Color.Purple,
        System.Drawing.Color.White,
        System.Drawing.Color.Silver,
        System.Drawing.Color.Red,
        System.Drawing.Color.Yellow,
        System.Drawing.Color.Lime,
        System.Drawing.Color.Aqua,
        System.Drawing.Color.Blue,
        System.Drawing.Color.Fuchsia};
			this.colorSY.ColorsPerRow = 6;
			this.colorSY.Dock = System.Windows.Forms.DockStyle.Fill;
			this.colorSY.Location = new System.Drawing.Point( 0, 0 );
			this.colorSY.Name = "colorSY";
			this.colorSY.SelectedColor = System.Drawing.Color.Black;
			this.colorSY.Size = new System.Drawing.Size( 121, 25 );
			this.colorSY.TabIndex = 1;
			this.colorSY.ColorChanged += new ShaiyaEmblemGen.ColorChangedHandler( this.ColorBox_ColorChanged );
			// 
			// imageEmblem
			// 
			this.imageEmblem.BackgroundImage = global::ShaiyaEmblemGen.Properties.Resources.Mantel;
			this.imageEmblem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.imageEmblem.Location = new System.Drawing.Point( 101, 140 );
			this.imageEmblem.Name = "imageEmblem";
			this.imageEmblem.Size = new System.Drawing.Size( 235, 498 );
			this.imageEmblem.TabIndex = 11;
			this.imageEmblem.TabStop = false;
			this.imageEmblem.Click += new System.EventHandler( this.imageEmblem_Click );
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 438, 648 );
			this.Controls.Add( this.imageEmblem );
			this.Controls.Add( this.tableLayoutPanel1 );
			this.Name = "frmMain";
			this.Text = "Shaiya Emblem Generator v1.0 - by GodLesZ";
			this.tableLayoutPanel1.ResumeLayout( false );
			this.tableLayoutPanel1.PerformLayout();
			this.panel1.ResumeLayout( false );
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout( false );
			this.panel2.PerformLayout();
			this.panel3.ResumeLayout( false );
			this.panel4.ResumeLayout( false );
			this.panel5.ResumeLayout( false );
			( (System.ComponentModel.ISupportInitialize)( this.imageEmblem ) ).EndInit();
			this.ResumeLayout( false );

		}

		#endregion

		private ImageComboBox imageBoxBG;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private ImageComboBox imageBoxFG;
		private System.Windows.Forms.Label label3;
		private ImageComboBox imageBoxSY;
		private System.Windows.Forms.ImageList imagesBG;
		private System.Windows.Forms.ImageList imagesFG;
		private System.Windows.Forms.ImageList imagesSY;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.PictureBox imageEmblem;
		private ColorBox colorBG;
		private ColorBox colorFG;
		private ColorBox colorSY;

	}
}

