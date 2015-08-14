namespace Shaiya_Screenshot_Tool {
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
			this.MenuProgram = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuProgramOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuProgramSave = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuProgramExit = new System.Windows.Forms.ToolStripMenuItem();
			this.screenPreview = new System.Windows.Forms.PictureBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.numBorder = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.txtText2 = new System.Windows.Forms.TextBox();
			this.txtText1 = new System.Windows.Forms.TextBox();
			this.numFontSize2 = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.numFontSize1 = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.colLine2 = new Shaiya_Screenshot_Tool.ColorBox();
			this.colLine1 = new Shaiya_Screenshot_Tool.ColorBox();
			this.MenuMain.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize)( this.screenPreview ) ).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize)( this.numBorder ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.numFontSize2 ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.numFontSize1 ) ).BeginInit();
			this.SuspendLayout();
			// 
			// MenuMain
			// 
			this.MenuMain.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.MenuProgram} );
			this.MenuMain.Location = new System.Drawing.Point( 0, 0 );
			this.MenuMain.Name = "MenuMain";
			this.MenuMain.Size = new System.Drawing.Size( 639, 24 );
			this.MenuMain.TabIndex = 0;
			this.MenuMain.Text = "menuStrip1";
			// 
			// MenuProgram
			// 
			this.MenuProgram.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.MenuProgramOpen,
            this.toolStripSeparator1,
            this.MenuProgramSave,
            this.toolStripSeparator2,
            this.MenuProgramExit} );
			this.MenuProgram.Image = global::Shaiya_Screenshot_Tool.Properties.Resources.Obscura;
			this.MenuProgram.Name = "MenuProgram";
			this.MenuProgram.Size = new System.Drawing.Size( 83, 20 );
			this.MenuProgram.Text = "Programm";
			// 
			// MenuProgramOpen
			// 
			this.MenuProgramOpen.Image = global::Shaiya_Screenshot_Tool.Properties.Resources.B_B_dossier_ferme_256;
			this.MenuProgramOpen.Name = "MenuProgramOpen";
			this.MenuProgramOpen.Size = new System.Drawing.Size( 175, 22 );
			this.MenuProgramOpen.Text = "Screenshot öffnen...";
			this.MenuProgramOpen.Click += new System.EventHandler( this.MenuProgramOpen_Click );
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size( 172, 6 );
			// 
			// MenuProgramSave
			// 
			this.MenuProgramSave.Image = global::Shaiya_Screenshot_Tool.Properties.Resources.dossier_musique_;
			this.MenuProgramSave.Name = "MenuProgramSave";
			this.MenuProgramSave.Size = new System.Drawing.Size( 175, 22 );
			this.MenuProgramSave.Text = "Ergebnis speichern";
			this.MenuProgramSave.Click += new System.EventHandler( this.MenuProgramSave_Click );
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size( 172, 6 );
			// 
			// MenuProgramExit
			// 
			this.MenuProgramExit.Image = global::Shaiya_Screenshot_Tool.Properties.Resources.B_B_Poste_de_travail;
			this.MenuProgramExit.Name = "MenuProgramExit";
			this.MenuProgramExit.Size = new System.Drawing.Size( 175, 22 );
			this.MenuProgramExit.Text = "Beenden";
			this.MenuProgramExit.Click += new System.EventHandler( this.MenuProgramExit_Click );
			// 
			// screenPreview
			// 
			this.screenPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.screenPreview.Location = new System.Drawing.Point( 3, 53 );
			this.screenPreview.Name = "screenPreview";
			this.screenPreview.Padding = new System.Windows.Forms.Padding( 10 );
			this.screenPreview.Size = new System.Drawing.Size( 633, 372 );
			this.screenPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.screenPreview.TabIndex = 1;
			this.screenPreview.TabStop = false;
			this.screenPreview.MouseClick += new System.Windows.Forms.MouseEventHandler( this.screenPreview_MouseClick );
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
			this.tableLayoutPanel1.Controls.Add( this.screenPreview, 0, 1 );
			this.tableLayoutPanel1.Controls.Add( this.panel1, 0, 0 );
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point( 0, 24 );
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Absolute, 50F ) );
			this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle() );
			this.tableLayoutPanel1.Size = new System.Drawing.Size( 639, 428 );
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// panel1
			// 
			this.panel1.Controls.Add( this.colLine2 );
			this.panel1.Controls.Add( this.colLine1 );
			this.panel1.Controls.Add( this.numBorder );
			this.panel1.Controls.Add( this.label5 );
			this.panel1.Controls.Add( this.txtText2 );
			this.panel1.Controls.Add( this.txtText1 );
			this.panel1.Controls.Add( this.numFontSize2 );
			this.panel1.Controls.Add( this.label2 );
			this.panel1.Controls.Add( this.numFontSize1 );
			this.panel1.Controls.Add( this.label1 );
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point( 3, 3 );
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size( 633, 44 );
			this.panel1.TabIndex = 2;
			// 
			// numBorder
			// 
			this.numBorder.DataBindings.Add( new System.Windows.Forms.Binding( "Value", global::Shaiya_Screenshot_Tool.Properties.Settings.Default, "Border", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged ) );
			this.numBorder.Location = new System.Drawing.Point( 480, 1 );
			this.numBorder.Name = "numBorder";
			this.numBorder.Size = new System.Drawing.Size( 38, 20 );
			this.numBorder.TabIndex = 9;
			this.numBorder.Value = global::Shaiya_Screenshot_Tool.Properties.Settings.Default.Border;
			this.numBorder.ValueChanged += new System.EventHandler( this.Effects_ValueChanged );
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point( 441, 3 );
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size( 33, 13 );
			this.label5.TabIndex = 8;
			this.label5.Text = "Rand";
			// 
			// txtText2
			// 
			this.txtText2.DataBindings.Add( new System.Windows.Forms.Binding( "Text", global::Shaiya_Screenshot_Tool.Properties.Settings.Default, "Text2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged ) );
			this.txtText2.Location = new System.Drawing.Point( 118, 23 );
			this.txtText2.Name = "txtText2";
			this.txtText2.Size = new System.Drawing.Size( 144, 20 );
			this.txtText2.TabIndex = 7;
			this.txtText2.Text = global::Shaiya_Screenshot_Tool.Properties.Settings.Default.Text2;
			this.txtText2.TextChanged += new System.EventHandler( this.Effects_ValueChanged );
			// 
			// txtText1
			// 
			this.txtText1.DataBindings.Add( new System.Windows.Forms.Binding( "Text", global::Shaiya_Screenshot_Tool.Properties.Settings.Default, "Text1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged ) );
			this.txtText1.Location = new System.Drawing.Point( 118, 1 );
			this.txtText1.Name = "txtText1";
			this.txtText1.Size = new System.Drawing.Size( 144, 20 );
			this.txtText1.TabIndex = 5;
			this.txtText1.Text = global::Shaiya_Screenshot_Tool.Properties.Settings.Default.Text1;
			this.txtText1.TextChanged += new System.EventHandler( this.Effects_ValueChanged );
			// 
			// numFontSize2
			// 
			this.numFontSize2.DataBindings.Add( new System.Windows.Forms.Binding( "Value", global::Shaiya_Screenshot_Tool.Properties.Settings.Default, "FontSize2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged ) );
			this.numFontSize2.Location = new System.Drawing.Point( 72, 23 );
			this.numFontSize2.Minimum = new decimal( new int[] {
            1,
            0,
            0,
            0} );
			this.numFontSize2.Name = "numFontSize2";
			this.numFontSize2.Size = new System.Drawing.Size( 40, 20 );
			this.numFontSize2.TabIndex = 3;
			this.numFontSize2.Value = global::Shaiya_Screenshot_Tool.Properties.Settings.Default.FontSize2;
			this.numFontSize2.ValueChanged += new System.EventHandler( this.Effects_ValueChanged );
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 2, 27 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 64, 13 );
			this.label2.TabIndex = 2;
			this.label2.Text = "Schriftgröße";
			// 
			// numFontSize1
			// 
			this.numFontSize1.DataBindings.Add( new System.Windows.Forms.Binding( "Value", global::Shaiya_Screenshot_Tool.Properties.Settings.Default, "FontSize1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged ) );
			this.numFontSize1.Location = new System.Drawing.Point( 72, 1 );
			this.numFontSize1.Minimum = new decimal( new int[] {
            1,
            0,
            0,
            0} );
			this.numFontSize1.Name = "numFontSize1";
			this.numFontSize1.Size = new System.Drawing.Size( 40, 20 );
			this.numFontSize1.TabIndex = 1;
			this.numFontSize1.Value = global::Shaiya_Screenshot_Tool.Properties.Settings.Default.FontSize1;
			this.numFontSize1.ValueChanged += new System.EventHandler( this.Effects_ValueChanged );
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 2, 5 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 64, 13 );
			this.label1.TabIndex = 0;
			this.label1.Text = "Schriftgröße";
			// 
			// colLine2
			// 
			this.colLine2.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.Black,
        System.Drawing.Color.White,
        System.Drawing.Color.AliceBlue,
        System.Drawing.Color.AntiqueWhite,
        System.Drawing.Color.Aqua,
        System.Drawing.Color.Aquamarine,
        System.Drawing.Color.Azure,
        System.Drawing.Color.Beige,
        System.Drawing.Color.Bisque,
        System.Drawing.Color.BlanchedAlmond,
        System.Drawing.Color.Blue,
        System.Drawing.Color.BlueViolet,
        System.Drawing.Color.Brown,
        System.Drawing.Color.BurlyWood,
        System.Drawing.Color.CadetBlue,
        System.Drawing.Color.Chartreuse,
        System.Drawing.Color.Chocolate,
        System.Drawing.Color.Coral,
        System.Drawing.Color.CornflowerBlue,
        System.Drawing.Color.Cornsilk,
        System.Drawing.Color.Crimson,
        System.Drawing.Color.Cyan,
        System.Drawing.Color.DarkBlue,
        System.Drawing.Color.DarkCyan,
        System.Drawing.Color.DarkGoldenrod,
        System.Drawing.Color.DarkGray,
        System.Drawing.Color.DarkGreen,
        System.Drawing.Color.DarkKhaki,
        System.Drawing.Color.DarkMagenta,
        System.Drawing.Color.DarkOliveGreen,
        System.Drawing.Color.DarkOrange,
        System.Drawing.Color.DarkOrchid,
        System.Drawing.Color.DarkRed,
        System.Drawing.Color.DarkSalmon,
        System.Drawing.Color.DarkSeaGreen,
        System.Drawing.Color.DarkSlateBlue,
        System.Drawing.Color.DarkSlateGray,
        System.Drawing.Color.DarkTurquoise,
        System.Drawing.Color.DarkViolet,
        System.Drawing.Color.DeepPink,
        System.Drawing.Color.DeepSkyBlue,
        System.Drawing.Color.DimGray,
        System.Drawing.Color.DodgerBlue,
        System.Drawing.Color.Firebrick,
        System.Drawing.Color.FloralWhite,
        System.Drawing.Color.ForestGreen,
        System.Drawing.Color.Fuchsia,
        System.Drawing.Color.Gainsboro,
        System.Drawing.Color.GhostWhite,
        System.Drawing.Color.Gold,
        System.Drawing.Color.Goldenrod,
        System.Drawing.Color.Gray,
        System.Drawing.Color.Green,
        System.Drawing.Color.GreenYellow,
        System.Drawing.Color.Honeydew,
        System.Drawing.Color.HotPink,
        System.Drawing.Color.IndianRed,
        System.Drawing.Color.Indigo,
        System.Drawing.Color.Ivory,
        System.Drawing.Color.Khaki,
        System.Drawing.Color.Lavender,
        System.Drawing.Color.LavenderBlush,
        System.Drawing.Color.LawnGreen,
        System.Drawing.Color.LemonChiffon,
        System.Drawing.Color.LightBlue,
        System.Drawing.Color.LightCoral,
        System.Drawing.Color.LightCyan,
        System.Drawing.Color.LightGoldenrodYellow,
        System.Drawing.Color.LightGray,
        System.Drawing.Color.LightGreen,
        System.Drawing.Color.LightPink,
        System.Drawing.Color.LightSalmon,
        System.Drawing.Color.LightSeaGreen,
        System.Drawing.Color.LightSkyBlue,
        System.Drawing.Color.LightSlateGray,
        System.Drawing.Color.LightSteelBlue,
        System.Drawing.Color.LightYellow,
        System.Drawing.Color.Lime,
        System.Drawing.Color.LimeGreen,
        System.Drawing.Color.Linen,
        System.Drawing.Color.Magenta,
        System.Drawing.Color.Maroon,
        System.Drawing.Color.MediumAquamarine,
        System.Drawing.Color.MediumBlue,
        System.Drawing.Color.MediumOrchid,
        System.Drawing.Color.MediumPurple,
        System.Drawing.Color.MediumSeaGreen,
        System.Drawing.Color.MediumSlateBlue,
        System.Drawing.Color.MediumSpringGreen,
        System.Drawing.Color.MediumTurquoise,
        System.Drawing.Color.MediumVioletRed,
        System.Drawing.Color.MidnightBlue,
        System.Drawing.Color.MintCream,
        System.Drawing.Color.MistyRose,
        System.Drawing.Color.Moccasin,
        System.Drawing.Color.NavajoWhite,
        System.Drawing.Color.Navy,
        System.Drawing.Color.OldLace,
        System.Drawing.Color.Olive,
        System.Drawing.Color.OliveDrab,
        System.Drawing.Color.Orange,
        System.Drawing.Color.OrangeRed,
        System.Drawing.Color.Orchid,
        System.Drawing.Color.PaleGoldenrod,
        System.Drawing.Color.PaleGreen,
        System.Drawing.Color.PaleTurquoise,
        System.Drawing.Color.PaleVioletRed,
        System.Drawing.Color.PapayaWhip,
        System.Drawing.Color.PeachPuff,
        System.Drawing.Color.Peru,
        System.Drawing.Color.Pink,
        System.Drawing.Color.Plum,
        System.Drawing.Color.PowderBlue,
        System.Drawing.Color.Purple,
        System.Drawing.Color.Red,
        System.Drawing.Color.RosyBrown,
        System.Drawing.Color.RoyalBlue,
        System.Drawing.Color.SaddleBrown,
        System.Drawing.Color.Salmon,
        System.Drawing.Color.SandyBrown,
        System.Drawing.Color.SeaGreen,
        System.Drawing.Color.SeaShell,
        System.Drawing.Color.Sienna,
        System.Drawing.Color.Silver,
        System.Drawing.Color.SkyBlue,
        System.Drawing.Color.SlateBlue,
        System.Drawing.Color.SlateGray,
        System.Drawing.Color.Snow,
        System.Drawing.Color.SpringGreen,
        System.Drawing.Color.SteelBlue,
        System.Drawing.Color.Tan,
        System.Drawing.Color.Teal,
        System.Drawing.Color.Thistle,
        System.Drawing.Color.Tomato,
        System.Drawing.Color.Transparent,
        System.Drawing.Color.Turquoise,
        System.Drawing.Color.Violet,
        System.Drawing.Color.Wheat,
        System.Drawing.Color.WhiteSmoke,
        System.Drawing.Color.Yellow,
        System.Drawing.Color.YellowGreen};
			this.colLine2.ColorsPerRow = 12;
			this.colLine2.Location = new System.Drawing.Point( 268, 23 );
			this.colLine2.Name = "colLine2";
			this.colLine2.SelectedColor = System.Drawing.Color.Black;
			this.colLine2.Size = new System.Drawing.Size( 49, 21 );
			this.colLine2.TabIndex = 11;
			this.colLine2.ColorChanged += new Shaiya_Screenshot_Tool.ColorChangedHandler( this.colLine2_ColorChanged );
			// 
			// colLine1
			// 
			this.colLine1.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.Black,
        System.Drawing.Color.White,
        System.Drawing.Color.AliceBlue,
        System.Drawing.Color.AntiqueWhite,
        System.Drawing.Color.Aqua,
        System.Drawing.Color.Aquamarine,
        System.Drawing.Color.Azure,
        System.Drawing.Color.Beige,
        System.Drawing.Color.Bisque,
        System.Drawing.Color.BlanchedAlmond,
        System.Drawing.Color.Blue,
        System.Drawing.Color.BlueViolet,
        System.Drawing.Color.Brown,
        System.Drawing.Color.BurlyWood,
        System.Drawing.Color.CadetBlue,
        System.Drawing.Color.Chartreuse,
        System.Drawing.Color.Chocolate,
        System.Drawing.Color.Coral,
        System.Drawing.Color.CornflowerBlue,
        System.Drawing.Color.Cornsilk,
        System.Drawing.Color.Crimson,
        System.Drawing.Color.Cyan,
        System.Drawing.Color.DarkBlue,
        System.Drawing.Color.DarkCyan,
        System.Drawing.Color.DarkGoldenrod,
        System.Drawing.Color.DarkGray,
        System.Drawing.Color.DarkGreen,
        System.Drawing.Color.DarkKhaki,
        System.Drawing.Color.DarkMagenta,
        System.Drawing.Color.DarkOliveGreen,
        System.Drawing.Color.DarkOrange,
        System.Drawing.Color.DarkOrchid,
        System.Drawing.Color.DarkRed,
        System.Drawing.Color.DarkSalmon,
        System.Drawing.Color.DarkSeaGreen,
        System.Drawing.Color.DarkSlateBlue,
        System.Drawing.Color.DarkSlateGray,
        System.Drawing.Color.DarkTurquoise,
        System.Drawing.Color.DarkViolet,
        System.Drawing.Color.DeepPink,
        System.Drawing.Color.DeepSkyBlue,
        System.Drawing.Color.DimGray,
        System.Drawing.Color.DodgerBlue,
        System.Drawing.Color.Firebrick,
        System.Drawing.Color.FloralWhite,
        System.Drawing.Color.ForestGreen,
        System.Drawing.Color.Fuchsia,
        System.Drawing.Color.Gainsboro,
        System.Drawing.Color.GhostWhite,
        System.Drawing.Color.Gold,
        System.Drawing.Color.Goldenrod,
        System.Drawing.Color.Gray,
        System.Drawing.Color.Green,
        System.Drawing.Color.GreenYellow,
        System.Drawing.Color.Honeydew,
        System.Drawing.Color.HotPink,
        System.Drawing.Color.IndianRed,
        System.Drawing.Color.Indigo,
        System.Drawing.Color.Ivory,
        System.Drawing.Color.Khaki,
        System.Drawing.Color.Lavender,
        System.Drawing.Color.LavenderBlush,
        System.Drawing.Color.LawnGreen,
        System.Drawing.Color.LemonChiffon,
        System.Drawing.Color.LightBlue,
        System.Drawing.Color.LightCoral,
        System.Drawing.Color.LightCyan,
        System.Drawing.Color.LightGoldenrodYellow,
        System.Drawing.Color.LightGray,
        System.Drawing.Color.LightGreen,
        System.Drawing.Color.LightPink,
        System.Drawing.Color.LightSalmon,
        System.Drawing.Color.LightSeaGreen,
        System.Drawing.Color.LightSkyBlue,
        System.Drawing.Color.LightSlateGray,
        System.Drawing.Color.LightSteelBlue,
        System.Drawing.Color.LightYellow,
        System.Drawing.Color.Lime,
        System.Drawing.Color.LimeGreen,
        System.Drawing.Color.Linen,
        System.Drawing.Color.Magenta,
        System.Drawing.Color.Maroon,
        System.Drawing.Color.MediumAquamarine,
        System.Drawing.Color.MediumBlue,
        System.Drawing.Color.MediumOrchid,
        System.Drawing.Color.MediumPurple,
        System.Drawing.Color.MediumSeaGreen,
        System.Drawing.Color.MediumSlateBlue,
        System.Drawing.Color.MediumSpringGreen,
        System.Drawing.Color.MediumTurquoise,
        System.Drawing.Color.MediumVioletRed,
        System.Drawing.Color.MidnightBlue,
        System.Drawing.Color.MintCream,
        System.Drawing.Color.MistyRose,
        System.Drawing.Color.Moccasin,
        System.Drawing.Color.NavajoWhite,
        System.Drawing.Color.Navy,
        System.Drawing.Color.OldLace,
        System.Drawing.Color.Olive,
        System.Drawing.Color.OliveDrab,
        System.Drawing.Color.Orange,
        System.Drawing.Color.OrangeRed,
        System.Drawing.Color.Orchid,
        System.Drawing.Color.PaleGoldenrod,
        System.Drawing.Color.PaleGreen,
        System.Drawing.Color.PaleTurquoise,
        System.Drawing.Color.PaleVioletRed,
        System.Drawing.Color.PapayaWhip,
        System.Drawing.Color.PeachPuff,
        System.Drawing.Color.Peru,
        System.Drawing.Color.Pink,
        System.Drawing.Color.Plum,
        System.Drawing.Color.PowderBlue,
        System.Drawing.Color.Purple,
        System.Drawing.Color.Red,
        System.Drawing.Color.RosyBrown,
        System.Drawing.Color.RoyalBlue,
        System.Drawing.Color.SaddleBrown,
        System.Drawing.Color.Salmon,
        System.Drawing.Color.SandyBrown,
        System.Drawing.Color.SeaGreen,
        System.Drawing.Color.SeaShell,
        System.Drawing.Color.Sienna,
        System.Drawing.Color.Silver,
        System.Drawing.Color.SkyBlue,
        System.Drawing.Color.SlateBlue,
        System.Drawing.Color.SlateGray,
        System.Drawing.Color.Snow,
        System.Drawing.Color.SpringGreen,
        System.Drawing.Color.SteelBlue,
        System.Drawing.Color.Tan,
        System.Drawing.Color.Teal,
        System.Drawing.Color.Thistle,
        System.Drawing.Color.Tomato,
        System.Drawing.Color.Transparent,
        System.Drawing.Color.Turquoise,
        System.Drawing.Color.Violet,
        System.Drawing.Color.Wheat,
        System.Drawing.Color.WhiteSmoke,
        System.Drawing.Color.Yellow,
        System.Drawing.Color.YellowGreen};
			this.colLine1.ColorsPerRow = 12;
			this.colLine1.Location = new System.Drawing.Point( 268, 0 );
			this.colLine1.Name = "colLine1";
			this.colLine1.SelectedColor = System.Drawing.Color.Black;
			this.colLine1.Size = new System.Drawing.Size( 49, 21 );
			this.colLine1.TabIndex = 10;
			this.colLine1.ColorChanged += new Shaiya_Screenshot_Tool.ColorChangedHandler( this.colLine1_ColorChanged );
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 639, 452 );
			this.Controls.Add( this.tableLayoutPanel1 );
			this.Controls.Add( this.MenuMain );
			this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
			this.KeyPreview = true;
			this.MainMenuStrip = this.MenuMain;
			this.Name = "frmMain";
			this.Text = "Screenshot Tool - by GodLesZ";
			this.Load += new System.EventHandler( this.frmMain_Load );
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.frmMain_FormClosing );
			this.KeyDown += new System.Windows.Forms.KeyEventHandler( this.frmMain_KeyDown );
			this.MenuMain.ResumeLayout( false );
			this.MenuMain.PerformLayout();
			( (System.ComponentModel.ISupportInitialize)( this.screenPreview ) ).EndInit();
			this.tableLayoutPanel1.ResumeLayout( false );
			this.panel1.ResumeLayout( false );
			this.panel1.PerformLayout();
			( (System.ComponentModel.ISupportInitialize)( this.numBorder ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.numFontSize2 ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.numFontSize1 ) ).EndInit();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip MenuMain;
		private System.Windows.Forms.ToolStripMenuItem MenuProgram;
		private System.Windows.Forms.ToolStripMenuItem MenuProgramOpen;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem MenuProgramSave;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem MenuProgramExit;
		private System.Windows.Forms.PictureBox screenPreview;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numFontSize2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown numFontSize1;
		private System.Windows.Forms.TextBox txtText2;
		private System.Windows.Forms.TextBox txtText1;
		private System.Windows.Forms.NumericUpDown numBorder;
		private System.Windows.Forms.Label label5;
		private ColorBox colLine1;
		private ColorBox colLine2;
	}
}

