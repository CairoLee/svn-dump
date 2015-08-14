namespace eACGUI {
	partial class frmMerge {
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( frmMerge ) );
			this.panelButtons = new DevComponents.DotNetBar.PanelEx();
			this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
			this.btnClose = new DevComponents.DotNetBar.ButtonX();
			this.btnSave = new DevComponents.DotNetBar.ButtonX();
			this.panelGrid1 = new DevComponents.DotNetBar.PanelEx();
			this.ConfGridMy = new DevComponents.DotNetBar.Controls.DataGridViewX();
			this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
			this.panelDragDrop = new DevComponents.DotNetBar.PanelEx();
			this.labelX2 = new DevComponents.DotNetBar.LabelX();
			this.btnConfWeb = new DevComponents.DotNetBar.ButtonX();
			this.labelX1 = new DevComponents.DotNetBar.LabelX();
			this.btnConfImport = new DevComponents.DotNetBar.ButtonX();
			this.panelGrid2 = new DevComponents.DotNetBar.PanelEx();
			this.ConfGridExtern = new DevComponents.DotNetBar.Controls.DataGridViewX();
			this.panelFileChoose = new DevComponents.DotNetBar.PanelEx();
			this.btnChangeUP = new DevComponents.DotNetBar.ButtonX();
			this.btnChangeDOWN = new DevComponents.DotNetBar.ButtonX();
			this.labelX4 = new DevComponents.DotNetBar.LabelX();
			this.comboChanges = new DevComponents.DotNetBar.Controls.ComboBoxEx();
			this.labelX3 = new DevComponents.DotNetBar.LabelX();
			this.comboFiles = new DevComponents.DotNetBar.Controls.ComboBoxEx();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panelButtons.SuspendLayout();
			this.panelGrid1.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize)( this.ConfGridMy ) ).BeginInit();
			this.panelDragDrop.SuspendLayout();
			this.panelGrid2.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize)( this.ConfGridExtern ) ).BeginInit();
			this.panelFileChoose.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelButtons
			// 
			this.panelButtons.CanvasColor = System.Drawing.SystemColors.Control;
			this.panelButtons.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
			this.panelButtons.Controls.Add( this.buttonX1 );
			this.panelButtons.Controls.Add( this.btnClose );
			this.panelButtons.Controls.Add( this.btnSave );
			this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelButtons.Location = new System.Drawing.Point( 0, 497 );
			this.panelButtons.Name = "panelButtons";
			this.panelButtons.Size = new System.Drawing.Size( 816, 39 );
			this.panelButtons.Style.Alignment = System.Drawing.StringAlignment.Center;
			this.panelButtons.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.panelButtons.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.panelButtons.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
			this.panelButtons.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.panelButtons.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
			this.panelButtons.Style.GradientAngle = 90;
			this.panelButtons.TabIndex = 0;
			// 
			// buttonX1
			// 
			this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
			this.buttonX1.FocusCuesEnabled = false;
			this.buttonX1.Location = new System.Drawing.Point( 304, 7 );
			this.buttonX1.Name = "buttonX1";
			this.buttonX1.Size = new System.Drawing.Size( 97, 23 );
			this.buttonX1.TabIndex = 2;
			this.buttonX1.Text = "Alles Übernehmen";
			// 
			// btnClose
			// 
			this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnClose.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
			this.btnClose.FocusCuesEnabled = false;
			this.btnClose.Location = new System.Drawing.Point( 631, 7 );
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size( 75, 23 );
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "Schließen";
			this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
			// 
			// btnSave
			// 
			this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnSave.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
			this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
			this.btnSave.FocusCuesEnabled = false;
			this.btnSave.Location = new System.Drawing.Point( 8, 7 );
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size( 118, 23 );
			this.btnSave.TabIndex = 0;
			this.btnSave.Text = "Meine Conf Speichern";
			this.btnSave.Click += new System.EventHandler( this.btnSave_Click );
			// 
			// panelGrid1
			// 
			this.panelGrid1.CanvasColor = System.Drawing.SystemColors.Control;
			this.panelGrid1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
			this.panelGrid1.Controls.Add( this.ConfGridMy );
			this.panelGrid1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panelGrid1.Location = new System.Drawing.Point( 0, 60 );
			this.panelGrid1.Name = "panelGrid1";
			this.panelGrid1.Size = new System.Drawing.Size( 348, 437 );
			this.panelGrid1.Style.Alignment = System.Drawing.StringAlignment.Center;
			this.panelGrid1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.panelGrid1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.panelGrid1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
			this.panelGrid1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.panelGrid1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
			this.panelGrid1.Style.GradientAngle = 90;
			this.panelGrid1.TabIndex = 1;
			this.panelGrid1.Text = "panelEx2";
			// 
			// ConfGridMy
			// 
			this.ConfGridMy.AllowUserToAddRows = false;
			this.ConfGridMy.AllowUserToDeleteRows = false;
			this.ConfGridMy.AllowUserToOrderColumns = true;
			this.ConfGridMy.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
			this.ConfGridMy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.ConfGridMy.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2} );
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle1.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.ConfGridMy.DefaultCellStyle = dataGridViewCellStyle1;
			this.ConfGridMy.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ConfGridMy.GridColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 208 ) ) ) ), ( (int)( ( (byte)( 215 ) ) ) ), ( (int)( ( (byte)( 229 ) ) ) ) );
			this.ConfGridMy.Location = new System.Drawing.Point( 0, 0 );
			this.ConfGridMy.Name = "ConfGridMy";
			this.ConfGridMy.RowHeadersVisible = false;
			this.ConfGridMy.RowHeadersWidth = 25;
			this.ConfGridMy.Size = new System.Drawing.Size( 348, 437 );
			this.ConfGridMy.TabIndex = 3;
			this.ConfGridMy.Scroll += new System.Windows.Forms.ScrollEventHandler( this.ConfGridMy_Scroll );
			this.ConfGridMy.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler( this.ConfGridMy_CellEndEdit );
			// 
			// expandableSplitter1
			// 
			this.expandableSplitter1.BackColor2 = System.Drawing.SystemColors.ControlDarkDark;
			this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.expandableSplitter1.ExpandFillColor = System.Drawing.SystemColors.ControlDarkDark;
			this.expandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.expandableSplitter1.ExpandLineColor = System.Drawing.SystemColors.ControlText;
			this.expandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
			this.expandableSplitter1.GripDarkColor = System.Drawing.SystemColors.ControlText;
			this.expandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
			this.expandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 251 ) ) ) ), ( (int)( ( (byte)( 251 ) ) ) ), ( (int)( ( (byte)( 251 ) ) ) ) );
			this.expandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
			this.expandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 163 ) ) ) ), ( (int)( ( (byte)( 209 ) ) ) ), ( (int)( ( (byte)( 254 ) ) ) ) );
			this.expandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 234 ) ) ) ), ( (int)( ( (byte)( 244 ) ) ) ), ( (int)( ( (byte)( 254 ) ) ) ) );
			this.expandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
			this.expandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
			this.expandableSplitter1.HotExpandFillColor = System.Drawing.SystemColors.ControlDarkDark;
			this.expandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.expandableSplitter1.HotExpandLineColor = System.Drawing.SystemColors.ControlText;
			this.expandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
			this.expandableSplitter1.HotGripDarkColor = System.Drawing.SystemColors.ControlDarkDark;
			this.expandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.expandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 251 ) ) ) ), ( (int)( ( (byte)( 251 ) ) ) ), ( (int)( ( (byte)( 251 ) ) ) ) );
			this.expandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
			this.expandableSplitter1.Location = new System.Drawing.Point( 348, 60 );
			this.expandableSplitter1.Name = "expandableSplitter1";
			this.expandableSplitter1.Size = new System.Drawing.Size( 10, 437 );
			this.expandableSplitter1.TabIndex = 2;
			this.expandableSplitter1.TabStop = false;
			// 
			// panelDragDrop
			// 
			this.panelDragDrop.CanvasColor = System.Drawing.SystemColors.Control;
			this.panelDragDrop.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
			this.panelDragDrop.Controls.Add( this.labelX2 );
			this.panelDragDrop.Controls.Add( this.btnConfWeb );
			this.panelDragDrop.Controls.Add( this.labelX1 );
			this.panelDragDrop.Controls.Add( this.btnConfImport );
			this.panelDragDrop.Dock = System.Windows.Forms.DockStyle.Right;
			this.panelDragDrop.Location = new System.Drawing.Point( 706, 60 );
			this.panelDragDrop.Name = "panelDragDrop";
			this.panelDragDrop.Size = new System.Drawing.Size( 110, 437 );
			this.panelDragDrop.Style.Alignment = System.Drawing.StringAlignment.Center;
			this.panelDragDrop.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.panelDragDrop.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.panelDragDrop.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
			this.panelDragDrop.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.panelDragDrop.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
			this.panelDragDrop.Style.GradientAngle = 90;
			this.panelDragDrop.TabIndex = 3;
			// 
			// labelX2
			// 
			this.labelX2.AutoSize = true;
			this.labelX2.Location = new System.Drawing.Point( 16, 310 );
			this.labelX2.Name = "labelX2";
			this.labelX2.Size = new System.Drawing.Size( 77, 15 );
			this.labelX2.TabIndex = 3;
			this.labelX2.Text = "Web Download";
			// 
			// btnConfWeb
			// 
			this.btnConfWeb.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnConfWeb.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
			this.btnConfWeb.HoverImage = global::eACGUI.Properties.Resources.SVN_Hover;
			this.btnConfWeb.Image = global::eACGUI.Properties.Resources.SVN_Normal;
			this.btnConfWeb.Location = new System.Drawing.Point( 30, 257 );
			this.btnConfWeb.Name = "btnConfWeb";
			this.btnConfWeb.Size = new System.Drawing.Size( 43, 49 );
			this.btnConfWeb.TabIndex = 2;
			this.btnConfWeb.Click += new System.EventHandler( this.btnConfWeb_Click );
			// 
			// labelX1
			// 
			this.labelX1.AutoSize = true;
			this.labelX1.Location = new System.Drawing.Point( 25, 137 );
			this.labelX1.Name = "labelX1";
			this.labelX1.Size = new System.Drawing.Size( 59, 15 );
			this.labelX1.TabIndex = 1;
			this.labelX1.Text = "XML Import";
			// 
			// btnConfImport
			// 
			this.btnConfImport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnConfImport.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
			this.btnConfImport.HoverImage = global::eACGUI.Properties.Resources.Import_Hover;
			this.btnConfImport.Image = global::eACGUI.Properties.Resources.Import_Normal;
			this.btnConfImport.Location = new System.Drawing.Point( 30, 84 );
			this.btnConfImport.Name = "btnConfImport";
			this.btnConfImport.Size = new System.Drawing.Size( 43, 49 );
			this.btnConfImport.TabIndex = 0;
			this.btnConfImport.Click += new System.EventHandler( this.btnConfImport_Click );
			// 
			// panelGrid2
			// 
			this.panelGrid2.CanvasColor = System.Drawing.SystemColors.Control;
			this.panelGrid2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
			this.panelGrid2.Controls.Add( this.ConfGridExtern );
			this.panelGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelGrid2.Location = new System.Drawing.Point( 358, 60 );
			this.panelGrid2.Name = "panelGrid2";
			this.panelGrid2.Size = new System.Drawing.Size( 348, 437 );
			this.panelGrid2.Style.Alignment = System.Drawing.StringAlignment.Center;
			this.panelGrid2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.panelGrid2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.panelGrid2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
			this.panelGrid2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.panelGrid2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
			this.panelGrid2.Style.GradientAngle = 90;
			this.panelGrid2.TabIndex = 4;
			this.panelGrid2.Text = "panelEx4";
			// 
			// ConfGridExtern
			// 
			this.ConfGridExtern.AllowUserToAddRows = false;
			this.ConfGridExtern.AllowUserToDeleteRows = false;
			this.ConfGridExtern.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
			this.ConfGridExtern.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.ConfGridExtern.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4} );
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.ConfGridExtern.DefaultCellStyle = dataGridViewCellStyle2;
			this.ConfGridExtern.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ConfGridExtern.GridColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 208 ) ) ) ), ( (int)( ( (byte)( 215 ) ) ) ), ( (int)( ( (byte)( 229 ) ) ) ) );
			this.ConfGridExtern.Location = new System.Drawing.Point( 0, 0 );
			this.ConfGridExtern.Name = "ConfGridExtern";
			this.ConfGridExtern.RowHeadersVisible = false;
			this.ConfGridExtern.RowHeadersWidth = 25;
			this.ConfGridExtern.Size = new System.Drawing.Size( 348, 437 );
			this.ConfGridExtern.TabIndex = 3;
			this.ConfGridExtern.Scroll += new System.Windows.Forms.ScrollEventHandler( this.ConfGridExtern_Scroll );
			this.ConfGridExtern.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler( this.ConfGridExtern_CellEndEdit );
			// 
			// panelFileChoose
			// 
			this.panelFileChoose.CanvasColor = System.Drawing.SystemColors.Control;
			this.panelFileChoose.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
			this.panelFileChoose.Controls.Add( this.btnChangeUP );
			this.panelFileChoose.Controls.Add( this.btnChangeDOWN );
			this.panelFileChoose.Controls.Add( this.labelX4 );
			this.panelFileChoose.Controls.Add( this.comboChanges );
			this.panelFileChoose.Controls.Add( this.labelX3 );
			this.panelFileChoose.Controls.Add( this.comboFiles );
			this.panelFileChoose.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelFileChoose.Location = new System.Drawing.Point( 0, 0 );
			this.panelFileChoose.Name = "panelFileChoose";
			this.panelFileChoose.Size = new System.Drawing.Size( 816, 60 );
			this.panelFileChoose.Style.Alignment = System.Drawing.StringAlignment.Center;
			this.panelFileChoose.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.panelFileChoose.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.panelFileChoose.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
			this.panelFileChoose.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.panelFileChoose.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
			this.panelFileChoose.Style.GradientAngle = 90;
			this.panelFileChoose.TabIndex = 5;
			// 
			// btnChangeUP
			// 
			this.btnChangeUP.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnChangeUP.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnChangeUP.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
			this.btnChangeUP.HoverImage = global::eACGUI.Properties.Resources.Up_Hover;
			this.btnChangeUP.Image = global::eACGUI.Properties.Resources.Up_Normal;
			this.btnChangeUP.Location = new System.Drawing.Point( 675, 24 );
			this.btnChangeUP.Name = "btnChangeUP";
			this.btnChangeUP.Size = new System.Drawing.Size( 30, 30 );
			this.btnChangeUP.TabIndex = 15;
			this.btnChangeUP.Tooltip = "Springt zur vorherigen Veränderung";
			this.btnChangeUP.Click += new System.EventHandler( this.btnChangeUP_Click );
			// 
			// btnChangeDOWN
			// 
			this.btnChangeDOWN.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnChangeDOWN.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnChangeDOWN.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
			this.btnChangeDOWN.HoverImage = global::eACGUI.Properties.Resources.Down_Hover;
			this.btnChangeDOWN.Image = global::eACGUI.Properties.Resources.Down_Normal;
			this.btnChangeDOWN.Location = new System.Drawing.Point( 636, 24 );
			this.btnChangeDOWN.Name = "btnChangeDOWN";
			this.btnChangeDOWN.Size = new System.Drawing.Size( 30, 30 );
			this.btnChangeDOWN.TabIndex = 14;
			this.btnChangeDOWN.Tooltip = "Springt zur nächsten Veränderung";
			this.btnChangeDOWN.Click += new System.EventHandler( this.btnChangeDOWN_Click );
			// 
			// labelX4
			// 
			this.labelX4.AutoSize = true;
			this.labelX4.Location = new System.Drawing.Point( 3, 39 );
			this.labelX4.Name = "labelX4";
			this.labelX4.Size = new System.Drawing.Size( 69, 15 );
			this.labelX4.TabIndex = 10;
			this.labelX4.Text = "Veränderung:";
			// 
			// comboChanges
			// 
			this.comboChanges.DisplayMember = "Text";
			this.comboChanges.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.comboChanges.FormattingEnabled = true;
			this.comboChanges.ItemHeight = 14;
			this.comboChanges.Location = new System.Drawing.Point( 87, 34 );
			this.comboChanges.Name = "comboChanges";
			this.comboChanges.Size = new System.Drawing.Size( 261, 20 );
			this.comboChanges.TabIndex = 9;
			this.comboChanges.SelectedIndexChanged += new System.EventHandler( this.comboChanges_SelectedIndexChanged );
			// 
			// labelX3
			// 
			this.labelX3.AutoSize = true;
			this.labelX3.Location = new System.Drawing.Point( 3, 16 );
			this.labelX3.Name = "labelX3";
			this.labelX3.Size = new System.Drawing.Size( 31, 15 );
			this.labelX3.TabIndex = 8;
			this.labelX3.Text = "Datei:";
			// 
			// comboFiles
			// 
			this.comboFiles.DisplayMember = "Text";
			this.comboFiles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.comboFiles.FormattingEnabled = true;
			this.comboFiles.ItemHeight = 14;
			this.comboFiles.Location = new System.Drawing.Point( 87, 12 );
			this.comboFiles.Name = "comboFiles";
			this.comboFiles.Size = new System.Drawing.Size( 261, 20 );
			this.comboFiles.TabIndex = 6;
			this.comboFiles.SelectedIndexChanged += new System.EventHandler( this.comboFiles_SelectedIndexChanged );
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.HeaderText = "Einstellung";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.Width = 160;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.HeaderText = "Wert";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.Width = 185;
			// 
			// dataGridViewTextBoxColumn3
			// 
			this.dataGridViewTextBoxColumn3.HeaderText = "Einstellung";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.Width = 160;
			// 
			// dataGridViewTextBoxColumn4
			// 
			this.dataGridViewTextBoxColumn4.HeaderText = "Wert";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.Width = 185;
			// 
			// frmMerge
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 816, 536 );
			this.Controls.Add( this.panelGrid2 );
			this.Controls.Add( this.panelDragDrop );
			this.Controls.Add( this.expandableSplitter1 );
			this.Controls.Add( this.panelGrid1 );
			this.Controls.Add( this.panelFileChoose );
			this.Controls.Add( this.panelButtons );
			this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
			this.Name = "frmMerge";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Config Merge";
			this.Load += new System.EventHandler( this.frmMerge_Load );
			this.panelButtons.ResumeLayout( false );
			this.panelGrid1.ResumeLayout( false );
			( (System.ComponentModel.ISupportInitialize)( this.ConfGridMy ) ).EndInit();
			this.panelDragDrop.ResumeLayout( false );
			this.panelDragDrop.PerformLayout();
			this.panelGrid2.ResumeLayout( false );
			( (System.ComponentModel.ISupportInitialize)( this.ConfGridExtern ) ).EndInit();
			this.panelFileChoose.ResumeLayout( false );
			this.panelFileChoose.PerformLayout();
			this.ResumeLayout( false );

		}

		#endregion

		private DevComponents.DotNetBar.PanelEx panelButtons;
		private DevComponents.DotNetBar.PanelEx panelGrid1;
		private DevComponents.DotNetBar.Controls.DataGridViewX ConfGridMy;
		private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
		private DevComponents.DotNetBar.PanelEx panelDragDrop;
		private DevComponents.DotNetBar.PanelEx panelGrid2;
		private DevComponents.DotNetBar.Controls.DataGridViewX ConfGridExtern;
		private DevComponents.DotNetBar.PanelEx panelFileChoose;
		private DevComponents.DotNetBar.Controls.ComboBoxEx comboFiles;
		private DevComponents.DotNetBar.ButtonX btnConfImport;
		private DevComponents.DotNetBar.LabelX labelX1;
		private DevComponents.DotNetBar.ButtonX btnClose;
		private DevComponents.DotNetBar.ButtonX btnSave;
		private DevComponents.DotNetBar.LabelX labelX2;
		private DevComponents.DotNetBar.ButtonX btnConfWeb;
		private DevComponents.DotNetBar.LabelX labelX4;
		private DevComponents.DotNetBar.Controls.ComboBoxEx comboChanges;
		private DevComponents.DotNetBar.LabelX labelX3;
		private DevComponents.DotNetBar.ButtonX btnChangeUP;
		private DevComponents.DotNetBar.ButtonX btnChangeDOWN;
		private DevComponents.DotNetBar.ButtonX buttonX1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

	}
}