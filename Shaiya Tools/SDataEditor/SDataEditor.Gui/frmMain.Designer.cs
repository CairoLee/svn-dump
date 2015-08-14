namespace SDataEditor.Gui {
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.MenuProgram = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuProgramClose = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuSData = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuSDataItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuExport = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuExportGrid2Text = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.gridData = new System.Windows.Forms.DataGridView();
			this.MenuSDataQuest = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize)( this.gridData ) ).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.MenuProgram,
            this.MenuSData,
            this.MenuExport} );
			this.menuStrip1.Location = new System.Drawing.Point( 0, 0 );
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size( 446, 24 );
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
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
			// MenuSData
			// 
			this.MenuSData.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.MenuSDataItem,
            this.MenuSDataQuest} );
			this.MenuSData.Name = "MenuSData";
			this.MenuSData.Size = new System.Drawing.Size( 48, 20 );
			this.MenuSData.Text = "SData";
			// 
			// MenuSDataItem
			// 
			this.MenuSDataItem.Name = "MenuSDataItem";
			this.MenuSDataItem.Size = new System.Drawing.Size( 189, 22 );
			this.MenuSDataItem.Text = "Item.SData öffnen";
			this.MenuSDataItem.Click += new System.EventHandler( this.MenuSDataItem_Click );
			// 
			// MenuExport
			// 
			this.MenuExport.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.MenuExportGrid2Text} );
			this.MenuExport.Name = "MenuExport";
			this.MenuExport.Size = new System.Drawing.Size( 51, 20 );
			this.MenuExport.Text = "Export";
			// 
			// MenuExportGrid2Text
			// 
			this.MenuExportGrid2Text.Name = "MenuExportGrid2Text";
			this.MenuExportGrid2Text.Size = new System.Drawing.Size( 131, 22 );
			this.MenuExportGrid2Text.Text = "Grid to Text";
			this.MenuExportGrid2Text.Click += new System.EventHandler( this.MenuExportGrid2Text_Click );
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point( 0, 266 );
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size( 446, 22 );
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// gridData
			// 
			this.gridData.AllowUserToAddRows = false;
			this.gridData.AllowUserToDeleteRows = false;
			this.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridData.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridData.Location = new System.Drawing.Point( 0, 24 );
			this.gridData.Name = "gridData";
			this.gridData.ReadOnly = true;
			this.gridData.Size = new System.Drawing.Size( 446, 242 );
			this.gridData.TabIndex = 2;
			// 
			// MenuSDataQuest
			// 
			this.MenuSDataQuest.Name = "MenuSDataQuest";
			this.MenuSDataQuest.Size = new System.Drawing.Size( 189, 22 );
			this.MenuSDataQuest.Text = "NpcQuest.SData öffnen";
			this.MenuSDataQuest.Click += new System.EventHandler( this.MenuSDataQuest_Click );
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 446, 288 );
			this.Controls.Add( this.gridData );
			this.Controls.Add( this.statusStrip1 );
			this.Controls.Add( this.menuStrip1 );
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "frmMain";
			this.Text = "Form1";
			this.menuStrip1.ResumeLayout( false );
			this.menuStrip1.PerformLayout();
			( (System.ComponentModel.ISupportInitialize)( this.gridData ) ).EndInit();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripMenuItem MenuProgram;
		private System.Windows.Forms.ToolStripMenuItem MenuProgramClose;
		private System.Windows.Forms.ToolStripMenuItem MenuSData;
		private System.Windows.Forms.ToolStripMenuItem MenuSDataItem;
		private System.Windows.Forms.DataGridView gridData;
		private System.Windows.Forms.ToolStripMenuItem MenuExport;
		private System.Windows.Forms.ToolStripMenuItem MenuExportGrid2Text;
		private System.Windows.Forms.ToolStripMenuItem MenuSDataQuest;
	}
}

