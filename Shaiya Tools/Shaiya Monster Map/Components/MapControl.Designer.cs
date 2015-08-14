namespace ShaiyaMonsterMap.Components {
	partial class MapControl {
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

		#region Vom Komponenten-Designer generierter Code

		/// <summary> 
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( MapControl ) );
			this.tableLayoutMobMap = new System.Windows.Forms.TableLayoutPanel();
			this.listMobPoints = new System.Windows.Forms.ListView();
			this.columnName = new System.Windows.Forms.ColumnHeader();
			this.columnLevel = new System.Windows.Forms.ColumnHeader();
			this.columnElement = new System.Windows.Forms.ColumnHeader();
			this.columnAnzahl = new System.Windows.Forms.ColumnHeader();
			this.imageListPoints = new System.Windows.Forms.ImageList( this.components );
			this.panelMobImages = new System.Windows.Forms.Panel();
			this.imgMobBoss = new System.Windows.Forms.PictureBox();
			this.label3 = new System.Windows.Forms.Label();
			this.imgMob4 = new System.Windows.Forms.PictureBox();
			this.lblMobLevel4 = new System.Windows.Forms.Label();
			this.imgMob3 = new System.Windows.Forms.PictureBox();
			this.lblMobLevel3 = new System.Windows.Forms.Label();
			this.imgMob2 = new System.Windows.Forms.PictureBox();
			this.lblMobLevel2 = new System.Windows.Forms.Label();
			this.imgMob1 = new System.Windows.Forms.PictureBox();
			this.lblMobLevel1 = new System.Windows.Forms.Label();
			this.MonsterMap = new ShaiyaMonsterMap.Components.MobMapImage();
			this.tableLayoutMobMap.SuspendLayout();
			this.panelMobImages.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize)( this.imgMobBoss ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.imgMob4 ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.imgMob3 ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.imgMob2 ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.imgMob1 ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.MonsterMap ) ).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutMobMap
			// 
			this.tableLayoutMobMap.ColumnCount = 2;
			this.tableLayoutMobMap.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Absolute, 518F ) );
			this.tableLayoutMobMap.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
			this.tableLayoutMobMap.Controls.Add( this.listMobPoints, 1, 1 );
			this.tableLayoutMobMap.Controls.Add( this.panelMobImages, 1, 0 );
			this.tableLayoutMobMap.Controls.Add( this.MonsterMap, 0, 0 );
			this.tableLayoutMobMap.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutMobMap.Location = new System.Drawing.Point( 0, 0 );
			this.tableLayoutMobMap.Name = "tableLayoutMobMap";
			this.tableLayoutMobMap.RowCount = 2;
			this.tableLayoutMobMap.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Absolute, 59F ) );
			this.tableLayoutMobMap.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Absolute, 434F ) );
			this.tableLayoutMobMap.Size = new System.Drawing.Size( 818, 518 );
			this.tableLayoutMobMap.TabIndex = 3;
			// 
			// listMobPoints
			// 
			this.listMobPoints.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnLevel,
            this.columnElement,
            this.columnAnzahl} );
			this.listMobPoints.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listMobPoints.Font = new System.Drawing.Font( "Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
			this.listMobPoints.FullRowSelect = true;
			this.listMobPoints.GridLines = true;
			this.listMobPoints.HideSelection = false;
			this.listMobPoints.Location = new System.Drawing.Point( 521, 62 );
			this.listMobPoints.Name = "listMobPoints";
			this.listMobPoints.ShowItemToolTips = true;
			this.listMobPoints.Size = new System.Drawing.Size( 294, 453 );
			this.listMobPoints.SmallImageList = this.imageListPoints;
			this.listMobPoints.TabIndex = 1;
			this.listMobPoints.UseCompatibleStateImageBehavior = false;
			this.listMobPoints.View = System.Windows.Forms.View.Details;
			this.listMobPoints.SelectedIndexChanged += new System.EventHandler( this.listMobPoints_SelectedIndexChanged );
			this.listMobPoints.DoubleClick += new System.EventHandler( this.listMobPoints_DoubleClick );
			this.listMobPoints.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler( this.listMobPoints_ColumnClick );
			// 
			// columnName
			// 
			this.columnName.Text = "Name";
			this.columnName.Width = 110;
			// 
			// columnLevel
			// 
			this.columnLevel.Text = "Level";
			this.columnLevel.Width = 44;
			// 
			// columnElement
			// 
			this.columnElement.Text = "Element";
			this.columnElement.Width = 50;
			// 
			// columnAnzahl
			// 
			this.columnAnzahl.Text = "Anzahl";
			this.columnAnzahl.Width = 85;
			// 
			// imageListPoints
			// 
			this.imageListPoints.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "imageListPoints.ImageStream" ) ) );
			this.imageListPoints.TransparentColor = System.Drawing.Color.Transparent;
			this.imageListPoints.Images.SetKeyName( 0, "Mob1.png" );
			this.imageListPoints.Images.SetKeyName( 1, "Mob2.png" );
			this.imageListPoints.Images.SetKeyName( 2, "Mob3.png" );
			this.imageListPoints.Images.SetKeyName( 3, "Mob4.png" );
			// 
			// panelMobImages
			// 
			this.panelMobImages.Controls.Add( this.imgMobBoss );
			this.panelMobImages.Controls.Add( this.label3 );
			this.panelMobImages.Controls.Add( this.imgMob4 );
			this.panelMobImages.Controls.Add( this.lblMobLevel4 );
			this.panelMobImages.Controls.Add( this.imgMob3 );
			this.panelMobImages.Controls.Add( this.lblMobLevel3 );
			this.panelMobImages.Controls.Add( this.imgMob2 );
			this.panelMobImages.Controls.Add( this.lblMobLevel2 );
			this.panelMobImages.Controls.Add( this.imgMob1 );
			this.panelMobImages.Controls.Add( this.lblMobLevel1 );
			this.panelMobImages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelMobImages.Location = new System.Drawing.Point( 521, 3 );
			this.panelMobImages.Name = "panelMobImages";
			this.panelMobImages.Size = new System.Drawing.Size( 294, 53 );
			this.panelMobImages.TabIndex = 2;
			// 
			// imgMobBoss
			// 
			this.imgMobBoss.Location = new System.Drawing.Point( 2, 35 );
			this.imgMobBoss.Name = "imgMobBoss";
			this.imgMobBoss.Size = new System.Drawing.Size( 14, 14 );
			this.imgMobBoss.TabIndex = 11;
			this.imgMobBoss.TabStop = false;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point( 23, 36 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 54, 13 );
			this.label3.TabIndex = 10;
			this.label3.Text = "Mob Boss";
			// 
			// imgMob4
			// 
			this.imgMob4.Location = new System.Drawing.Point( 108, 21 );
			this.imgMob4.Name = "imgMob4";
			this.imgMob4.Size = new System.Drawing.Size( 12, 12 );
			this.imgMob4.TabIndex = 9;
			this.imgMob4.TabStop = false;
			// 
			// lblMobLevel4
			// 
			this.lblMobLevel4.AutoSize = true;
			this.lblMobLevel4.Location = new System.Drawing.Point( 128, 21 );
			this.lblMobLevel4.Name = "lblMobLevel4";
			this.lblMobLevel4.Size = new System.Drawing.Size( 58, 13 );
			this.lblMobLevel4.TabIndex = 8;
			this.lblMobLevel4.Text = "Mob 16-20";
			// 
			// imgMob3
			// 
			this.imgMob3.Location = new System.Drawing.Point( 108, 6 );
			this.imgMob3.Name = "imgMob3";
			this.imgMob3.Size = new System.Drawing.Size( 12, 12 );
			this.imgMob3.TabIndex = 7;
			this.imgMob3.TabStop = false;
			// 
			// lblMobLevel3
			// 
			this.lblMobLevel3.AutoSize = true;
			this.lblMobLevel3.Location = new System.Drawing.Point( 128, 6 );
			this.lblMobLevel3.Name = "lblMobLevel3";
			this.lblMobLevel3.Size = new System.Drawing.Size( 58, 13 );
			this.lblMobLevel3.TabIndex = 6;
			this.lblMobLevel3.Text = "Mob 11-15";
			// 
			// imgMob2
			// 
			this.imgMob2.Location = new System.Drawing.Point( 3, 21 );
			this.imgMob2.Name = "imgMob2";
			this.imgMob2.Size = new System.Drawing.Size( 12, 12 );
			this.imgMob2.TabIndex = 3;
			this.imgMob2.TabStop = false;
			// 
			// lblMobLevel2
			// 
			this.lblMobLevel2.AutoSize = true;
			this.lblMobLevel2.Location = new System.Drawing.Point( 23, 21 );
			this.lblMobLevel2.Name = "lblMobLevel2";
			this.lblMobLevel2.Size = new System.Drawing.Size( 52, 13 );
			this.lblMobLevel2.TabIndex = 2;
			this.lblMobLevel2.Text = "Mob 6-10";
			// 
			// imgMob1
			// 
			this.imgMob1.Location = new System.Drawing.Point( 3, 6 );
			this.imgMob1.Name = "imgMob1";
			this.imgMob1.Size = new System.Drawing.Size( 12, 12 );
			this.imgMob1.TabIndex = 1;
			this.imgMob1.TabStop = false;
			// 
			// lblMobLevel1
			// 
			this.lblMobLevel1.AutoSize = true;
			this.lblMobLevel1.Location = new System.Drawing.Point( 23, 6 );
			this.lblMobLevel1.Name = "lblMobLevel1";
			this.lblMobLevel1.Size = new System.Drawing.Size( 46, 13 );
			this.lblMobLevel1.TabIndex = 0;
			this.lblMobLevel1.Text = "Mob 1-5";
			// 
			// MonsterMap
			// 
			this.MonsterMap.BackColor = System.Drawing.Color.Transparent;
			this.MonsterMap.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MonsterMap.Factory = null;
			this.MonsterMap.Location = new System.Drawing.Point( 3, 3 );
			this.MonsterMap.Name = "MonsterMap";
			this.tableLayoutMobMap.SetRowSpan( this.MonsterMap, 2 );
			this.MonsterMap.Size = new System.Drawing.Size( 512, 512 );
			this.MonsterMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.MonsterMap.TabIndex = 0;
			this.MonsterMap.TabStop = false;
			this.MonsterMap.Paint += new System.Windows.Forms.PaintEventHandler( this.MonsterMap_Paint );
			// 
			// MapControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add( this.tableLayoutMobMap );
			this.Name = "MapControl";
			this.Size = new System.Drawing.Size( 818, 518 );
			this.KeyUp += new System.Windows.Forms.KeyEventHandler( this.MapControl_KeyUp );
			this.tableLayoutMobMap.ResumeLayout( false );
			this.tableLayoutMobMap.PerformLayout();
			this.panelMobImages.ResumeLayout( false );
			this.panelMobImages.PerformLayout();
			( (System.ComponentModel.ISupportInitialize)( this.imgMobBoss ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.imgMob4 ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.imgMob3 ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.imgMob2 ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.imgMob1 ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.MonsterMap ) ).EndInit();
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutMobMap;
		public System.Windows.Forms.ListView listMobPoints;
		private System.Windows.Forms.ColumnHeader columnName;
		private System.Windows.Forms.ColumnHeader columnLevel;
		private System.Windows.Forms.ColumnHeader columnElement;
		private System.Windows.Forms.ColumnHeader columnAnzahl;
		private System.Windows.Forms.Panel panelMobImages;
		private System.Windows.Forms.PictureBox imgMobBoss;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.PictureBox imgMob4;
		private System.Windows.Forms.Label lblMobLevel4;
		private System.Windows.Forms.PictureBox imgMob3;
		private System.Windows.Forms.Label lblMobLevel3;
		private System.Windows.Forms.PictureBox imgMob2;
		private System.Windows.Forms.Label lblMobLevel2;
		private System.Windows.Forms.PictureBox imgMob1;
		private System.Windows.Forms.Label lblMobLevel1;
		public MobMapImage MonsterMap;
		private System.Windows.Forms.ImageList imageListPoints;

	}
}
