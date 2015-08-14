namespace Ssc {
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
			this.panelMain = new System.Windows.Forms.Panel();
			this.btnClose = new System.Windows.Forms.PictureBox();
			this.panelStatus = new System.Windows.Forms.Panel();
			this.lblGLÜ = new System.Windows.Forms.Label();
			this.lblGES = new System.Windows.Forms.Label();
			this.lblWEI = new System.Windows.Forms.Label();
			this.lblINT = new System.Windows.Forms.Label();
			this.lblABW = new System.Windows.Forms.Label();
			this.lblSTR = new System.Windows.Forms.Label();
			this.txtLevel = new System.Windows.Forms.MaskedTextBox();
			this.txtName = new System.Windows.Forms.TextBox();
			this.imgArmreif2 = new System.Windows.Forms.PictureBox();
			this.imgArmreif1 = new System.Windows.Forms.PictureBox();
			this.imgRing2 = new System.Windows.Forms.PictureBox();
			this.imgRing1 = new System.Windows.Forms.PictureBox();
			this.imgReittier = new System.Windows.Forms.PictureBox();
			this.imgAmulett = new System.Windows.Forms.PictureBox();
			this.imgMantel = new System.Windows.Forms.PictureBox();
			this.imgSchild = new System.Windows.Forms.PictureBox();
			this.imgWaffe = new System.Windows.Forms.PictureBox();
			this.imgSchuhe = new System.Windows.Forms.PictureBox();
			this.imgHandschuh = new System.Windows.Forms.PictureBox();
			this.imgHose = new System.Windows.Forms.PictureBox();
			this.imgRüstung = new System.Windows.Forms.PictureBox();
			this.imgHelm = new System.Windows.Forms.PictureBox();
			this.cbMode = new System.Windows.Forms.ComboBox();
			this.txtGLU = new System.Windows.Forms.MaskedTextBox();
			this.txtGES = new System.Windows.Forms.MaskedTextBox();
			this.txtWEI = new System.Windows.Forms.MaskedTextBox();
			this.txtINT = new System.Windows.Forms.MaskedTextBox();
			this.txtABW = new System.Windows.Forms.MaskedTextBox();
			this.txtSTR = new System.Windows.Forms.MaskedTextBox();
			this.cbClass = new System.Windows.Forms.ComboBox();
			this.lblAP = new System.Windows.Forms.Label();
			this.lblMP = new System.Windows.Forms.Label();
			this.lblHP = new System.Windows.Forms.Label();
			this.lblWALK = new System.Windows.Forms.Label();
			this.lblASPD = new System.Windows.Forms.Label();
			this.lblRES = new System.Windows.Forms.Label();
			this.lblDEF = new System.Windows.Forms.Label();
			this.lblMANG = new System.Windows.Forms.Label();
			this.lblANG = new System.Windows.Forms.Label();
			this.lblPoints = new System.Windows.Forms.Label();
			this.panelMain.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize)( this.btnClose ) ).BeginInit();
			this.panelStatus.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize)( this.imgArmreif2 ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.imgArmreif1 ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.imgRing2 ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.imgRing1 ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.imgReittier ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.imgAmulett ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.imgMantel ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.imgSchild ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.imgWaffe ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.imgSchuhe ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.imgHandschuh ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.imgHose ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.imgRüstung ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.imgHelm ) ).BeginInit();
			this.SuspendLayout();
			// 
			// panelMain
			// 
			this.panelMain.BackColor = System.Drawing.Color.Transparent;
			this.panelMain.BackgroundImage = global::Ssc.Properties.Resources.main_form;
			this.panelMain.Controls.Add( this.btnClose );
			this.panelMain.Controls.Add( this.panelStatus );
			this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelMain.Location = new System.Drawing.Point( 0, 0 );
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new System.Drawing.Size( 339, 288 );
			this.panelMain.TabIndex = 0;
			this.panelMain.MouseMove += new System.Windows.Forms.MouseEventHandler( this.panelMain_MouseMove );
			this.panelMain.MouseDown += new System.Windows.Forms.MouseEventHandler( this.panelMain_MouseDown );
			this.panelMain.MouseUp += new System.Windows.Forms.MouseEventHandler( this.panelMain_MouseUp );
			// 
			// btnClose
			// 
			this.btnClose.Image = global::Ssc.Properties.Resources.btnClose;
			this.btnClose.Location = new System.Drawing.Point( 310, 3 );
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size( 26, 26 );
			this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.btnClose.TabIndex = 26;
			this.btnClose.TabStop = false;
			this.btnClose.MouseLeave += new System.EventHandler( this.btnClose_MouseLeave );
			this.btnClose.MouseDown += new System.Windows.Forms.MouseEventHandler( this.btnClose_MouseDown );
			this.btnClose.MouseUp += new System.Windows.Forms.MouseEventHandler( this.btnClose_MouseUp );
			this.btnClose.MouseEnter += new System.EventHandler( this.btnClose_MouseEnter );
			// 
			// panelStatus
			// 
			this.panelStatus.BackColor = System.Drawing.Color.Transparent;
			this.panelStatus.BackgroundImage = global::Ssc.Properties.Resources.inventory2;
			this.panelStatus.Controls.Add( this.lblPoints );
			this.panelStatus.Controls.Add( this.lblGLÜ );
			this.panelStatus.Controls.Add( this.lblGES );
			this.panelStatus.Controls.Add( this.lblWEI );
			this.panelStatus.Controls.Add( this.lblINT );
			this.panelStatus.Controls.Add( this.lblABW );
			this.panelStatus.Controls.Add( this.lblSTR );
			this.panelStatus.Controls.Add( this.txtLevel );
			this.panelStatus.Controls.Add( this.txtName );
			this.panelStatus.Controls.Add( this.imgArmreif2 );
			this.panelStatus.Controls.Add( this.imgArmreif1 );
			this.panelStatus.Controls.Add( this.imgRing2 );
			this.panelStatus.Controls.Add( this.imgRing1 );
			this.panelStatus.Controls.Add( this.imgReittier );
			this.panelStatus.Controls.Add( this.imgAmulett );
			this.panelStatus.Controls.Add( this.imgMantel );
			this.panelStatus.Controls.Add( this.imgSchild );
			this.panelStatus.Controls.Add( this.imgWaffe );
			this.panelStatus.Controls.Add( this.imgSchuhe );
			this.panelStatus.Controls.Add( this.imgHandschuh );
			this.panelStatus.Controls.Add( this.imgHose );
			this.panelStatus.Controls.Add( this.imgRüstung );
			this.panelStatus.Controls.Add( this.imgHelm );
			this.panelStatus.Controls.Add( this.cbMode );
			this.panelStatus.Controls.Add( this.txtGLU );
			this.panelStatus.Controls.Add( this.txtGES );
			this.panelStatus.Controls.Add( this.txtWEI );
			this.panelStatus.Controls.Add( this.txtINT );
			this.panelStatus.Controls.Add( this.txtABW );
			this.panelStatus.Controls.Add( this.txtSTR );
			this.panelStatus.Controls.Add( this.cbClass );
			this.panelStatus.Controls.Add( this.lblAP );
			this.panelStatus.Controls.Add( this.lblMP );
			this.panelStatus.Controls.Add( this.lblHP );
			this.panelStatus.Controls.Add( this.lblWALK );
			this.panelStatus.Controls.Add( this.lblASPD );
			this.panelStatus.Controls.Add( this.lblRES );
			this.panelStatus.Controls.Add( this.lblDEF );
			this.panelStatus.Controls.Add( this.lblMANG );
			this.panelStatus.Controls.Add( this.lblANG );
			this.panelStatus.Location = new System.Drawing.Point( 13, 39 );
			this.panelStatus.Name = "panelStatus";
			this.panelStatus.Size = new System.Drawing.Size( 313, 237 );
			this.panelStatus.TabIndex = 25;
			// 
			// lblGLÜ
			// 
			this.lblGLÜ.AutoSize = true;
			this.lblGLÜ.ForeColor = System.Drawing.Color.Yellow;
			this.lblGLÜ.Location = new System.Drawing.Point( 220, 91 );
			this.lblGLÜ.Name = "lblGLÜ";
			this.lblGLÜ.Size = new System.Drawing.Size( 28, 13 );
			this.lblGLÜ.TabIndex = 66;
			this.lblGLÜ.Text = "+ 10";
			// 
			// lblGES
			// 
			this.lblGES.AutoSize = true;
			this.lblGES.ForeColor = System.Drawing.Color.Yellow;
			this.lblGES.Location = new System.Drawing.Point( 220, 71 );
			this.lblGES.Name = "lblGES";
			this.lblGES.Size = new System.Drawing.Size( 28, 13 );
			this.lblGES.TabIndex = 65;
			this.lblGES.Text = "+ 10";
			// 
			// lblWEI
			// 
			this.lblWEI.AutoSize = true;
			this.lblWEI.ForeColor = System.Drawing.Color.Yellow;
			this.lblWEI.Location = new System.Drawing.Point( 220, 51 );
			this.lblWEI.Name = "lblWEI";
			this.lblWEI.Size = new System.Drawing.Size( 28, 13 );
			this.lblWEI.TabIndex = 64;
			this.lblWEI.Text = "+ 10";
			// 
			// lblINT
			// 
			this.lblINT.AutoSize = true;
			this.lblINT.ForeColor = System.Drawing.Color.Yellow;
			this.lblINT.Location = new System.Drawing.Point( 104, 91 );
			this.lblINT.Name = "lblINT";
			this.lblINT.Size = new System.Drawing.Size( 28, 13 );
			this.lblINT.TabIndex = 63;
			this.lblINT.Text = "+ 10";
			// 
			// lblABW
			// 
			this.lblABW.AutoSize = true;
			this.lblABW.ForeColor = System.Drawing.Color.Yellow;
			this.lblABW.Location = new System.Drawing.Point( 104, 71 );
			this.lblABW.Name = "lblABW";
			this.lblABW.Size = new System.Drawing.Size( 28, 13 );
			this.lblABW.TabIndex = 62;
			this.lblABW.Text = "+ 10";
			// 
			// lblSTR
			// 
			this.lblSTR.AutoSize = true;
			this.lblSTR.ForeColor = System.Drawing.Color.Yellow;
			this.lblSTR.Location = new System.Drawing.Point( 104, 51 );
			this.lblSTR.Name = "lblSTR";
			this.lblSTR.Size = new System.Drawing.Size( 28, 13 );
			this.lblSTR.TabIndex = 61;
			this.lblSTR.Text = "+ 10";
			// 
			// txtLevel
			// 
			this.txtLevel.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 41 ) ) ) ), ( (int)( ( (byte)( 41 ) ) ) ), ( (int)( ( (byte)( 41 ) ) ) ) );
			this.txtLevel.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtLevel.ForeColor = System.Drawing.Color.White;
			this.txtLevel.Location = new System.Drawing.Point( 197, 7 );
			this.txtLevel.Mask = "00";
			this.txtLevel.Name = "txtLevel";
			this.txtLevel.PromptChar = ' ';
			this.txtLevel.Size = new System.Drawing.Size( 27, 13 );
			this.txtLevel.TabIndex = 60;
			this.txtLevel.Text = "60";
			this.txtLevel.TextChanged += new System.EventHandler( this.StatusText_TextChanged );
			// 
			// txtName
			// 
			this.txtName.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 41 ) ) ) ), ( (int)( ( (byte)( 41 ) ) ) ), ( (int)( ( (byte)( 41 ) ) ) ) );
			this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtName.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
			this.txtName.ForeColor = System.Drawing.Color.White;
			this.txtName.Location = new System.Drawing.Point( 78, 6 );
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size( 65, 13 );
			this.txtName.TabIndex = 59;
			this.txtName.Text = "Blubb";
			// 
			// imgArmreif2
			// 
			this.imgArmreif2.BackColor = System.Drawing.Color.Transparent;
			this.imgArmreif2.Location = new System.Drawing.Point( 290, 26 );
			this.imgArmreif2.Name = "imgArmreif2";
			this.imgArmreif2.Size = new System.Drawing.Size( 20, 20 );
			this.imgArmreif2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.imgArmreif2.TabIndex = 58;
			this.imgArmreif2.TabStop = false;
			this.imgArmreif2.MouseLeave += new System.EventHandler( this.EquipmentImg_MouseLeave );
			this.imgArmreif2.Click += new System.EventHandler( this.EquipmentImg_Click );
			this.imgArmreif2.MouseEnter += new System.EventHandler( this.EquipmentImg_MouseEnter );
			// 
			// imgArmreif1
			// 
			this.imgArmreif1.BackColor = System.Drawing.Color.Transparent;
			this.imgArmreif1.Location = new System.Drawing.Point( 267, 26 );
			this.imgArmreif1.Name = "imgArmreif1";
			this.imgArmreif1.Size = new System.Drawing.Size( 20, 20 );
			this.imgArmreif1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.imgArmreif1.TabIndex = 57;
			this.imgArmreif1.TabStop = false;
			this.imgArmreif1.MouseLeave += new System.EventHandler( this.EquipmentImg_MouseLeave );
			this.imgArmreif1.Click += new System.EventHandler( this.EquipmentImg_Click );
			this.imgArmreif1.MouseEnter += new System.EventHandler( this.EquipmentImg_MouseEnter );
			// 
			// imgRing2
			// 
			this.imgRing2.BackColor = System.Drawing.Color.Transparent;
			this.imgRing2.Location = new System.Drawing.Point( 290, 50 );
			this.imgRing2.Name = "imgRing2";
			this.imgRing2.Size = new System.Drawing.Size( 20, 20 );
			this.imgRing2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.imgRing2.TabIndex = 56;
			this.imgRing2.TabStop = false;
			this.imgRing2.MouseLeave += new System.EventHandler( this.EquipmentImg_MouseLeave );
			this.imgRing2.Click += new System.EventHandler( this.EquipmentImg_Click );
			this.imgRing2.MouseEnter += new System.EventHandler( this.EquipmentImg_MouseEnter );
			// 
			// imgRing1
			// 
			this.imgRing1.BackColor = System.Drawing.Color.Transparent;
			this.imgRing1.Location = new System.Drawing.Point( 267, 50 );
			this.imgRing1.Name = "imgRing1";
			this.imgRing1.Size = new System.Drawing.Size( 20, 20 );
			this.imgRing1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.imgRing1.TabIndex = 55;
			this.imgRing1.TabStop = false;
			this.imgRing1.MouseLeave += new System.EventHandler( this.EquipmentImg_MouseLeave );
			this.imgRing1.Click += new System.EventHandler( this.EquipmentImg_Click );
			this.imgRing1.MouseEnter += new System.EventHandler( this.EquipmentImg_MouseEnter );
			// 
			// imgReittier
			// 
			this.imgReittier.BackColor = System.Drawing.Color.Transparent;
			this.imgReittier.Location = new System.Drawing.Point( 290, 2 );
			this.imgReittier.Name = "imgReittier";
			this.imgReittier.Size = new System.Drawing.Size( 20, 20 );
			this.imgReittier.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.imgReittier.TabIndex = 54;
			this.imgReittier.TabStop = false;
			this.imgReittier.MouseLeave += new System.EventHandler( this.EquipmentImg_MouseLeave );
			this.imgReittier.Click += new System.EventHandler( this.EquipmentImg_Click );
			this.imgReittier.MouseEnter += new System.EventHandler( this.EquipmentImg_MouseEnter );
			// 
			// imgAmulett
			// 
			this.imgAmulett.BackColor = System.Drawing.Color.Transparent;
			this.imgAmulett.Location = new System.Drawing.Point( 267, 2 );
			this.imgAmulett.Name = "imgAmulett";
			this.imgAmulett.Size = new System.Drawing.Size( 20, 20 );
			this.imgAmulett.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.imgAmulett.TabIndex = 53;
			this.imgAmulett.TabStop = false;
			this.imgAmulett.MouseLeave += new System.EventHandler( this.EquipmentImg_MouseLeave );
			this.imgAmulett.Click += new System.EventHandler( this.EquipmentImg_Click );
			this.imgAmulett.MouseEnter += new System.EventHandler( this.EquipmentImg_MouseEnter );
			// 
			// imgMantel
			// 
			this.imgMantel.Location = new System.Drawing.Point( 272, 162 );
			this.imgMantel.Name = "imgMantel";
			this.imgMantel.Size = new System.Drawing.Size( 36, 36 );
			this.imgMantel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.imgMantel.TabIndex = 52;
			this.imgMantel.TabStop = false;
			this.imgMantel.MouseLeave += new System.EventHandler( this.EquipmentImg_MouseLeave );
			this.imgMantel.Click += new System.EventHandler( this.EquipmentImg_Click );
			this.imgMantel.MouseEnter += new System.EventHandler( this.EquipmentImg_MouseEnter );
			// 
			// imgSchild
			// 
			this.imgSchild.Location = new System.Drawing.Point( 272, 122 );
			this.imgSchild.Name = "imgSchild";
			this.imgSchild.Size = new System.Drawing.Size( 36, 36 );
			this.imgSchild.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.imgSchild.TabIndex = 51;
			this.imgSchild.TabStop = false;
			this.imgSchild.MouseLeave += new System.EventHandler( this.EquipmentImg_MouseLeave );
			this.imgSchild.Click += new System.EventHandler( this.EquipmentImg_Click );
			this.imgSchild.MouseEnter += new System.EventHandler( this.EquipmentImg_MouseEnter );
			// 
			// imgWaffe
			// 
			this.imgWaffe.Location = new System.Drawing.Point( 272, 82 );
			this.imgWaffe.Name = "imgWaffe";
			this.imgWaffe.Size = new System.Drawing.Size( 36, 36 );
			this.imgWaffe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.imgWaffe.TabIndex = 50;
			this.imgWaffe.TabStop = false;
			this.imgWaffe.MouseLeave += new System.EventHandler( this.EquipmentImg_MouseLeave );
			this.imgWaffe.Click += new System.EventHandler( this.EquipmentImg_Click );
			this.imgWaffe.MouseEnter += new System.EventHandler( this.EquipmentImg_MouseEnter );
			// 
			// imgSchuhe
			// 
			this.imgSchuhe.Location = new System.Drawing.Point( 2, 161 );
			this.imgSchuhe.Name = "imgSchuhe";
			this.imgSchuhe.Size = new System.Drawing.Size( 36, 36 );
			this.imgSchuhe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.imgSchuhe.TabIndex = 49;
			this.imgSchuhe.TabStop = false;
			this.imgSchuhe.MouseLeave += new System.EventHandler( this.EquipmentImg_MouseLeave );
			this.imgSchuhe.Click += new System.EventHandler( this.EquipmentImg_Click );
			this.imgSchuhe.MouseEnter += new System.EventHandler( this.EquipmentImg_MouseEnter );
			// 
			// imgHandschuh
			// 
			this.imgHandschuh.Location = new System.Drawing.Point( 2, 121 );
			this.imgHandschuh.Name = "imgHandschuh";
			this.imgHandschuh.Size = new System.Drawing.Size( 36, 36 );
			this.imgHandschuh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.imgHandschuh.TabIndex = 48;
			this.imgHandschuh.TabStop = false;
			this.imgHandschuh.MouseLeave += new System.EventHandler( this.EquipmentImg_MouseLeave );
			this.imgHandschuh.Click += new System.EventHandler( this.EquipmentImg_Click );
			this.imgHandschuh.MouseEnter += new System.EventHandler( this.EquipmentImg_MouseEnter );
			// 
			// imgHose
			// 
			this.imgHose.Location = new System.Drawing.Point( 2, 81 );
			this.imgHose.Name = "imgHose";
			this.imgHose.Size = new System.Drawing.Size( 36, 36 );
			this.imgHose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.imgHose.TabIndex = 47;
			this.imgHose.TabStop = false;
			this.imgHose.MouseLeave += new System.EventHandler( this.EquipmentImg_MouseLeave );
			this.imgHose.Click += new System.EventHandler( this.EquipmentImg_Click );
			this.imgHose.MouseEnter += new System.EventHandler( this.EquipmentImg_MouseEnter );
			// 
			// imgRüstung
			// 
			this.imgRüstung.Location = new System.Drawing.Point( 2, 41 );
			this.imgRüstung.Name = "imgRüstung";
			this.imgRüstung.Size = new System.Drawing.Size( 36, 36 );
			this.imgRüstung.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.imgRüstung.TabIndex = 46;
			this.imgRüstung.TabStop = false;
			this.imgRüstung.MouseLeave += new System.EventHandler( this.EquipmentImg_MouseLeave );
			this.imgRüstung.Click += new System.EventHandler( this.EquipmentImg_Click );
			this.imgRüstung.MouseEnter += new System.EventHandler( this.EquipmentImg_MouseEnter );
			// 
			// imgHelm
			// 
			this.imgHelm.Location = new System.Drawing.Point( 2, 1 );
			this.imgHelm.Name = "imgHelm";
			this.imgHelm.Size = new System.Drawing.Size( 36, 36 );
			this.imgHelm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.imgHelm.TabIndex = 45;
			this.imgHelm.TabStop = false;
			this.imgHelm.MouseLeave += new System.EventHandler( this.EquipmentImg_MouseLeave );
			this.imgHelm.Click += new System.EventHandler( this.EquipmentImg_Click );
			this.imgHelm.MouseEnter += new System.EventHandler( this.EquipmentImg_MouseEnter );
			// 
			// cbMode
			// 
			this.cbMode.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 41 ) ) ) ), ( (int)( ( (byte)( 41 ) ) ) ), ( (int)( ( (byte)( 41 ) ) ) ) );
			this.cbMode.Font = new System.Drawing.Font( "Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
			this.cbMode.ForeColor = System.Drawing.Color.White;
			this.cbMode.FormattingEnabled = true;
			this.cbMode.Location = new System.Drawing.Point( 191, 24 );
			this.cbMode.Name = "cbMode";
			this.cbMode.Size = new System.Drawing.Size( 68, 20 );
			this.cbMode.TabIndex = 44;
			// 
			// txtGLU
			// 
			this.txtGLU.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 41 ) ) ) ), ( (int)( ( (byte)( 41 ) ) ) ), ( (int)( ( (byte)( 41 ) ) ) ) );
			this.txtGLU.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtGLU.ForeColor = System.Drawing.Color.White;
			this.txtGLU.Location = new System.Drawing.Point( 197, 91 );
			this.txtGLU.Mask = "000";
			this.txtGLU.Name = "txtGLU";
			this.txtGLU.PromptChar = ' ';
			this.txtGLU.Size = new System.Drawing.Size( 27, 13 );
			this.txtGLU.TabIndex = 43;
			this.txtGLU.Text = "999";
			this.txtGLU.TextChanged += new System.EventHandler( this.StatusText_TextChanged );
			// 
			// txtGES
			// 
			this.txtGES.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 41 ) ) ) ), ( (int)( ( (byte)( 41 ) ) ) ), ( (int)( ( (byte)( 41 ) ) ) ) );
			this.txtGES.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtGES.ForeColor = System.Drawing.Color.White;
			this.txtGES.Location = new System.Drawing.Point( 197, 71 );
			this.txtGES.Mask = "000";
			this.txtGES.Name = "txtGES";
			this.txtGES.PromptChar = ' ';
			this.txtGES.Size = new System.Drawing.Size( 27, 13 );
			this.txtGES.TabIndex = 42;
			this.txtGES.Text = "999";
			this.txtGES.TextChanged += new System.EventHandler( this.StatusText_TextChanged );
			// 
			// txtWEI
			// 
			this.txtWEI.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 41 ) ) ) ), ( (int)( ( (byte)( 41 ) ) ) ), ( (int)( ( (byte)( 41 ) ) ) ) );
			this.txtWEI.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtWEI.ForeColor = System.Drawing.Color.White;
			this.txtWEI.Location = new System.Drawing.Point( 197, 51 );
			this.txtWEI.Mask = "000";
			this.txtWEI.Name = "txtWEI";
			this.txtWEI.PromptChar = ' ';
			this.txtWEI.Size = new System.Drawing.Size( 27, 13 );
			this.txtWEI.TabIndex = 41;
			this.txtWEI.Text = "999";
			this.txtWEI.TextChanged += new System.EventHandler( this.StatusText_TextChanged );
			// 
			// txtINT
			// 
			this.txtINT.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 41 ) ) ) ), ( (int)( ( (byte)( 41 ) ) ) ), ( (int)( ( (byte)( 41 ) ) ) ) );
			this.txtINT.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtINT.ForeColor = System.Drawing.Color.White;
			this.txtINT.Location = new System.Drawing.Point( 82, 91 );
			this.txtINT.Mask = "000";
			this.txtINT.Name = "txtINT";
			this.txtINT.PromptChar = ' ';
			this.txtINT.Size = new System.Drawing.Size( 27, 13 );
			this.txtINT.TabIndex = 40;
			this.txtINT.Text = "999";
			this.txtINT.TextChanged += new System.EventHandler( this.StatusText_TextChanged );
			// 
			// txtABW
			// 
			this.txtABW.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 41 ) ) ) ), ( (int)( ( (byte)( 41 ) ) ) ), ( (int)( ( (byte)( 41 ) ) ) ) );
			this.txtABW.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtABW.ForeColor = System.Drawing.Color.White;
			this.txtABW.Location = new System.Drawing.Point( 82, 71 );
			this.txtABW.Mask = "000";
			this.txtABW.Name = "txtABW";
			this.txtABW.PromptChar = ' ';
			this.txtABW.Size = new System.Drawing.Size( 27, 13 );
			this.txtABW.TabIndex = 39;
			this.txtABW.Text = "999";
			this.txtABW.TextChanged += new System.EventHandler( this.StatusText_TextChanged );
			// 
			// txtSTR
			// 
			this.txtSTR.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 41 ) ) ) ), ( (int)( ( (byte)( 41 ) ) ) ), ( (int)( ( (byte)( 41 ) ) ) ) );
			this.txtSTR.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtSTR.ForeColor = System.Drawing.Color.White;
			this.txtSTR.Location = new System.Drawing.Point( 82, 51 );
			this.txtSTR.Mask = "000";
			this.txtSTR.Name = "txtSTR";
			this.txtSTR.PromptChar = ' ';
			this.txtSTR.Size = new System.Drawing.Size( 27, 13 );
			this.txtSTR.TabIndex = 38;
			this.txtSTR.Text = "999";
			this.txtSTR.TextChanged += new System.EventHandler( this.StatusText_TextChanged );
			// 
			// cbClass
			// 
			this.cbClass.BackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 41 ) ) ) ), ( (int)( ( (byte)( 41 ) ) ) ), ( (int)( ( (byte)( 41 ) ) ) ) );
			this.cbClass.Font = new System.Drawing.Font( "Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
			this.cbClass.ForeColor = System.Drawing.Color.White;
			this.cbClass.FormattingEnabled = true;
			this.cbClass.Location = new System.Drawing.Point( 76, 24 );
			this.cbClass.Name = "cbClass";
			this.cbClass.Size = new System.Drawing.Size( 68, 20 );
			this.cbClass.TabIndex = 37;
			this.cbClass.SelectedIndexChanged += new System.EventHandler( this.cbClass_SelectedIndexChanged );
			// 
			// lblAP
			// 
			this.lblAP.AutoSize = true;
			this.lblAP.ForeColor = System.Drawing.Color.White;
			this.lblAP.Location = new System.Drawing.Point( 89, 175 );
			this.lblAP.Name = "lblAP";
			this.lblAP.Size = new System.Drawing.Size( 40, 13 );
			this.lblAP.TabIndex = 36;
			this.lblAP.Text = "99.999";
			this.lblAP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMP
			// 
			this.lblMP.AutoSize = true;
			this.lblMP.ForeColor = System.Drawing.Color.White;
			this.lblMP.Location = new System.Drawing.Point( 89, 155 );
			this.lblMP.Name = "lblMP";
			this.lblMP.Size = new System.Drawing.Size( 40, 13 );
			this.lblMP.TabIndex = 35;
			this.lblMP.Text = "99.999";
			this.lblMP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblHP
			// 
			this.lblHP.AutoSize = true;
			this.lblHP.ForeColor = System.Drawing.Color.White;
			this.lblHP.Location = new System.Drawing.Point( 89, 135 );
			this.lblHP.Name = "lblHP";
			this.lblHP.Size = new System.Drawing.Size( 40, 13 );
			this.lblHP.TabIndex = 34;
			this.lblHP.Text = "99.999";
			this.lblHP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblWALK
			// 
			this.lblWALK.AutoSize = true;
			this.lblWALK.ForeColor = System.Drawing.Color.White;
			this.lblWALK.Location = new System.Drawing.Point( 137, 219 );
			this.lblWALK.Name = "lblWALK";
			this.lblWALK.Size = new System.Drawing.Size( 40, 13 );
			this.lblWALK.TabIndex = 31;
			this.lblWALK.Text = "Normal";
			// 
			// lblASPD
			// 
			this.lblASPD.AutoSize = true;
			this.lblASPD.ForeColor = System.Drawing.Color.White;
			this.lblASPD.Location = new System.Drawing.Point( 137, 199 );
			this.lblASPD.Name = "lblASPD";
			this.lblASPD.Size = new System.Drawing.Size( 40, 13 );
			this.lblASPD.TabIndex = 30;
			this.lblASPD.Text = "Normal";
			// 
			// lblRES
			// 
			this.lblRES.AutoSize = true;
			this.lblRES.ForeColor = System.Drawing.Color.White;
			this.lblRES.Location = new System.Drawing.Point( 194, 175 );
			this.lblRES.Name = "lblRES";
			this.lblRES.Size = new System.Drawing.Size( 25, 13 );
			this.lblRES.TabIndex = 27;
			this.lblRES.Text = "999";
			// 
			// lblDEF
			// 
			this.lblDEF.AutoSize = true;
			this.lblDEF.ForeColor = System.Drawing.Color.White;
			this.lblDEF.Location = new System.Drawing.Point( 194, 155 );
			this.lblDEF.Name = "lblDEF";
			this.lblDEF.Size = new System.Drawing.Size( 25, 13 );
			this.lblDEF.TabIndex = 24;
			this.lblDEF.Text = "999";
			// 
			// lblMANG
			// 
			this.lblMANG.AutoSize = true;
			this.lblMANG.ForeColor = System.Drawing.Color.White;
			this.lblMANG.Location = new System.Drawing.Point( 194, 135 );
			this.lblMANG.Name = "lblMANG";
			this.lblMANG.Size = new System.Drawing.Size( 52, 13 );
			this.lblMANG.TabIndex = 21;
			this.lblMANG.Text = "999 - 999";
			// 
			// lblANG
			// 
			this.lblANG.AutoSize = true;
			this.lblANG.ForeColor = System.Drawing.Color.White;
			this.lblANG.Location = new System.Drawing.Point( 194, 115 );
			this.lblANG.Name = "lblANG";
			this.lblANG.Size = new System.Drawing.Size( 52, 13 );
			this.lblANG.TabIndex = 18;
			this.lblANG.Text = "999 - 999";
			// 
			// lblPoints
			// 
			this.lblPoints.ForeColor = System.Drawing.Color.LimeGreen;
			this.lblPoints.Location = new System.Drawing.Point( 77, 110 );
			this.lblPoints.Name = "lblPoints";
			this.lblPoints.Size = new System.Drawing.Size( 66, 13 );
			this.lblPoints.TabIndex = 67;
			this.lblPoints.Text = "999 / 999";
			this.lblPoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 339, 288 );
			this.Controls.Add( this.panelMain );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
			this.Name = "frmMain";
			this.Text = "Shaiya Status Calculator";
			this.TransparencyKey = System.Drawing.SystemColors.Control;
			this.Shown += new System.EventHandler( this.frmMain_Shown );
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.frmMain_FormClosing );
			this.panelMain.ResumeLayout( false );
			this.panelMain.PerformLayout();
			( (System.ComponentModel.ISupportInitialize)( this.btnClose ) ).EndInit();
			this.panelStatus.ResumeLayout( false );
			this.panelStatus.PerformLayout();
			( (System.ComponentModel.ISupportInitialize)( this.imgArmreif2 ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.imgArmreif1 ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.imgRing2 ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.imgRing1 ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.imgReittier ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.imgAmulett ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.imgMantel ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.imgSchild ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.imgWaffe ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.imgSchuhe ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.imgHandschuh ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.imgHose ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.imgRüstung ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.imgHelm ) ).EndInit();
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.Panel panelStatus;
		private System.Windows.Forms.Panel panelMain;
		private System.Windows.Forms.PictureBox btnClose;
		private System.Windows.Forms.Label lblWALK;
		private System.Windows.Forms.Label lblASPD;
		private System.Windows.Forms.Label lblRES;
		private System.Windows.Forms.Label lblDEF;
		private System.Windows.Forms.Label lblMANG;
		private System.Windows.Forms.Label lblANG;
		private System.Windows.Forms.Label lblAP;
		private System.Windows.Forms.Label lblMP;
		private System.Windows.Forms.Label lblHP;
		private System.Windows.Forms.ComboBox cbClass;
		private System.Windows.Forms.MaskedTextBox txtSTR;
		private System.Windows.Forms.MaskedTextBox txtGLU;
		private System.Windows.Forms.MaskedTextBox txtGES;
		private System.Windows.Forms.MaskedTextBox txtWEI;
		private System.Windows.Forms.MaskedTextBox txtINT;
		private System.Windows.Forms.MaskedTextBox txtABW;
		private System.Windows.Forms.ComboBox cbMode;
		private System.Windows.Forms.PictureBox imgSchuhe;
		private System.Windows.Forms.PictureBox imgHandschuh;
		private System.Windows.Forms.PictureBox imgHose;
		private System.Windows.Forms.PictureBox imgRüstung;
		private System.Windows.Forms.PictureBox imgHelm;
		private System.Windows.Forms.PictureBox imgArmreif2;
		private System.Windows.Forms.PictureBox imgArmreif1;
		private System.Windows.Forms.PictureBox imgRing2;
		private System.Windows.Forms.PictureBox imgRing1;
		private System.Windows.Forms.PictureBox imgReittier;
		private System.Windows.Forms.PictureBox imgAmulett;
		private System.Windows.Forms.PictureBox imgMantel;
		private System.Windows.Forms.PictureBox imgSchild;
		private System.Windows.Forms.PictureBox imgWaffe;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.MaskedTextBox txtLevel;
		private System.Windows.Forms.Label lblGLÜ;
		private System.Windows.Forms.Label lblGES;
		private System.Windows.Forms.Label lblWEI;
		private System.Windows.Forms.Label lblINT;
		private System.Windows.Forms.Label lblABW;
		private System.Windows.Forms.Label lblSTR;
		private System.Windows.Forms.Label lblPoints;
	}
}

