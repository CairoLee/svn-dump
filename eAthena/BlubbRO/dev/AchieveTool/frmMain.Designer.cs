namespace AchieveTool {
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.txtDesc = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtCutin = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.cmbType = new System.Windows.Forms.ComboBox();
			this.listRequires = new System.Windows.Forms.ListView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.colRequireAchieveID = new System.Windows.Forms.ColumnHeader();
			this.colRequireCount = new System.Windows.Forms.ColumnHeader();
			this.colRequireParam1 = new System.Windows.Forms.ColumnHeader();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.listReceive = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.btnAchieveAdd = new System.Windows.Forms.Button();
			this.btnReceiveDel = new System.Windows.Forms.Button();
			this.btnReceiveAdd = new System.Windows.Forms.Button();
			this.btnRequireDel = new System.Windows.Forms.Button();
			this.btnRequireAdd = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 13, 13 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 35, 13 );
			this.label1.TabIndex = 0;
			this.label1.Text = "Name";
			// 
			// txtName
			// 
			this.txtName.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtName.Location = new System.Drawing.Point( 54, 10 );
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size( 295, 20 );
			this.txtName.TabIndex = 1;
			// 
			// txtDesc
			// 
			this.txtDesc.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtDesc.Location = new System.Drawing.Point( 54, 36 );
			this.txtDesc.Name = "txtDesc";
			this.txtDesc.Size = new System.Drawing.Size( 295, 20 );
			this.txtDesc.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 13, 39 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 32, 13 );
			this.label2.TabIndex = 2;
			this.label2.Text = "Desc";
			// 
			// txtCutin
			// 
			this.txtCutin.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtCutin.Location = new System.Drawing.Point( 54, 62 );
			this.txtCutin.Name = "txtCutin";
			this.txtCutin.Size = new System.Drawing.Size( 295, 20 );
			this.txtCutin.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point( 13, 65 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 31, 13 );
			this.label3.TabIndex = 4;
			this.label3.Text = "Cutin";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point( 13, 92 );
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size( 31, 13 );
			this.label4.TabIndex = 6;
			this.label4.Text = "Type";
			// 
			// cmbType
			// 
			this.cmbType.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbType.FormattingEnabled = true;
			this.cmbType.Items.AddRange( new object[] {
            "KillMob",
            "KillMobRace",
            "KillPlayer",
            "KillHomu",
            "KillMerc",
            "GetLevelBase",
            "GetLevelJob",
            "ExploreRegion",
            "ExploreDungeon",
            "GetJob",
            "StatusActive",
            "Die",
            "Resurect",
            "UseItem",
            "GetItem",
            "QuestFinish",
            "UseKafra",
            "UseSkill",
            "Special",
            "KillWoEGuest",
            "KillWoEHome",
            "PayZeny",
            "GetVendingZeny"} );
			this.cmbType.Location = new System.Drawing.Point( 54, 89 );
			this.cmbType.Name = "cmbType";
			this.cmbType.Size = new System.Drawing.Size( 295, 21 );
			this.cmbType.TabIndex = 7;
			// 
			// listRequires
			// 
			this.listRequires.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.listRequires.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.colRequireAchieveID,
            this.colRequireCount,
            this.colRequireParam1} );
			this.listRequires.FullRowSelect = true;
			this.listRequires.GridLines = true;
			this.listRequires.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listRequires.Location = new System.Drawing.Point( 6, 19 );
			this.listRequires.MultiSelect = false;
			this.listRequires.Name = "listRequires";
			this.listRequires.Size = new System.Drawing.Size( 297, 80 );
			this.listRequires.TabIndex = 8;
			this.listRequires.UseCompatibleStateImageBehavior = false;
			this.listRequires.View = System.Windows.Forms.View.Details;
			this.listRequires.SelectedIndexChanged += new System.EventHandler( this.listRequires_SelectedIndexChanged );
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.groupBox1.Controls.Add( this.btnRequireDel );
			this.groupBox1.Controls.Add( this.btnRequireAdd );
			this.groupBox1.Controls.Add( this.listRequires );
			this.groupBox1.Location = new System.Drawing.Point( 12, 126 );
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size( 337, 106 );
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Benötigt..";
			// 
			// colRequireAchieveID
			// 
			this.colRequireAchieveID.Text = "ID";
			this.colRequireAchieveID.Width = 44;
			// 
			// colRequireCount
			// 
			this.colRequireCount.Text = "Count";
			this.colRequireCount.Width = 43;
			// 
			// colRequireParam1
			// 
			this.colRequireParam1.Text = "Param1";
			this.colRequireParam1.Width = 182;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.groupBox2.Controls.Add( this.btnReceiveDel );
			this.groupBox2.Controls.Add( this.btnReceiveAdd );
			this.groupBox2.Controls.Add( this.listReceive );
			this.groupBox2.Location = new System.Drawing.Point( 12, 238 );
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size( 337, 106 );
			this.groupBox2.TabIndex = 11;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Bekommt..";
			// 
			// listReceive
			// 
			this.listReceive.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.listReceive.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4} );
			this.listReceive.FullRowSelect = true;
			this.listReceive.GridLines = true;
			this.listReceive.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listReceive.Location = new System.Drawing.Point( 6, 19 );
			this.listReceive.MultiSelect = false;
			this.listReceive.Name = "listReceive";
			this.listReceive.Size = new System.Drawing.Size( 297, 80 );
			this.listReceive.TabIndex = 8;
			this.listReceive.UseCompatibleStateImageBehavior = false;
			this.listReceive.View = System.Windows.Forms.View.Details;
			this.listReceive.SelectedIndexChanged += new System.EventHandler( this.listReceive_SelectedIndexChanged );
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "ID";
			this.columnHeader1.Width = 44;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Type";
			this.columnHeader2.Width = 91;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Param1";
			this.columnHeader4.Width = 89;
			// 
			// btnAchieveAdd
			// 
			this.btnAchieveAdd.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnAchieveAdd.Location = new System.Drawing.Point( 12, 355 );
			this.btnAchieveAdd.Name = "btnAchieveAdd";
			this.btnAchieveAdd.Size = new System.Drawing.Size( 343, 23 );
			this.btnAchieveAdd.TabIndex = 12;
			this.btnAchieveAdd.Text = "Hinzufügen";
			this.btnAchieveAdd.UseVisualStyleBackColor = true;
			this.btnAchieveAdd.Click += new System.EventHandler( this.btnAchieveAdd_Click );
			// 
			// btnReceiveDel
			// 
			this.btnReceiveDel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnReceiveDel.Enabled = false;
			this.btnReceiveDel.Image = global::AchieveTool.Properties.Resources.delete;
			this.btnReceiveDel.Location = new System.Drawing.Point( 309, 46 );
			this.btnReceiveDel.Name = "btnReceiveDel";
			this.btnReceiveDel.Size = new System.Drawing.Size( 22, 22 );
			this.btnReceiveDel.TabIndex = 10;
			this.btnReceiveDel.UseVisualStyleBackColor = true;
			this.btnReceiveDel.Click += new System.EventHandler( this.btnReceiveDel_Click );
			// 
			// btnReceiveAdd
			// 
			this.btnReceiveAdd.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnReceiveAdd.Image = global::AchieveTool.Properties.Resources.add;
			this.btnReceiveAdd.Location = new System.Drawing.Point( 309, 18 );
			this.btnReceiveAdd.Name = "btnReceiveAdd";
			this.btnReceiveAdd.Size = new System.Drawing.Size( 22, 22 );
			this.btnReceiveAdd.TabIndex = 9;
			this.btnReceiveAdd.UseVisualStyleBackColor = true;
			this.btnReceiveAdd.Click += new System.EventHandler( this.btnReceiveAdd_Click );
			// 
			// btnRequireDel
			// 
			this.btnRequireDel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnRequireDel.Enabled = false;
			this.btnRequireDel.Image = global::AchieveTool.Properties.Resources.delete;
			this.btnRequireDel.Location = new System.Drawing.Point( 309, 46 );
			this.btnRequireDel.Name = "btnRequireDel";
			this.btnRequireDel.Size = new System.Drawing.Size( 22, 22 );
			this.btnRequireDel.TabIndex = 10;
			this.btnRequireDel.UseVisualStyleBackColor = true;
			this.btnRequireDel.Click += new System.EventHandler( this.btnRequireDel_Click );
			// 
			// btnRequireAdd
			// 
			this.btnRequireAdd.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnRequireAdd.Image = global::AchieveTool.Properties.Resources.add;
			this.btnRequireAdd.Location = new System.Drawing.Point( 309, 18 );
			this.btnRequireAdd.Name = "btnRequireAdd";
			this.btnRequireAdd.Size = new System.Drawing.Size( 22, 22 );
			this.btnRequireAdd.TabIndex = 9;
			this.btnRequireAdd.UseVisualStyleBackColor = true;
			this.btnRequireAdd.Click += new System.EventHandler( this.btnRequireAdd_Click );
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 367, 390 );
			this.Controls.Add( this.btnAchieveAdd );
			this.Controls.Add( this.groupBox2 );
			this.Controls.Add( this.groupBox1 );
			this.Controls.Add( this.cmbType );
			this.Controls.Add( this.label4 );
			this.Controls.Add( this.txtCutin );
			this.Controls.Add( this.label3 );
			this.Controls.Add( this.txtDesc );
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.txtName );
			this.Controls.Add( this.label1 );
			this.Name = "frmMain";
			this.Text = "Achieve Tool";
			this.Shown += new System.EventHandler( this.frmMain_Shown );
			this.groupBox1.ResumeLayout( false );
			this.groupBox2.ResumeLayout( false );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.TextBox txtDesc;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtCutin;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cmbType;
		private System.Windows.Forms.ListView listRequires;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ColumnHeader colRequireAchieveID;
		private System.Windows.Forms.ColumnHeader colRequireCount;
		private System.Windows.Forms.ColumnHeader colRequireParam1;
		private System.Windows.Forms.Button btnRequireAdd;
		private System.Windows.Forms.Button btnRequireDel;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnReceiveDel;
		private System.Windows.Forms.Button btnReceiveAdd;
		private System.Windows.Forms.ListView listReceive;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.Button btnAchieveAdd;
	}
}

