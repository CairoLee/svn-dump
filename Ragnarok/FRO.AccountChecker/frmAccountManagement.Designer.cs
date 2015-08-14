namespace FRO.AccountChecker {
	partial class frmAccountManagement {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.menuAccountsManagerClose = new System.Windows.Forms.ToolStripMenuItem();
			this.saveCloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dataAccounts = new System.Windows.Forms.DataGridView();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataAccounts)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAccountsManagerClose});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(655, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// menuAccountsManagerClose
			// 
			this.menuAccountsManagerClose.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveCloseToolStripMenuItem});
			this.menuAccountsManagerClose.Name = "menuAccountsManagerClose";
			this.menuAccountsManagerClose.Size = new System.Drawing.Size(61, 20);
			this.menuAccountsManagerClose.Text = "Manager";
			// 
			// saveCloseToolStripMenuItem
			// 
			this.saveCloseToolStripMenuItem.Name = "saveCloseToolStripMenuItem";
			this.saveCloseToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.saveCloseToolStripMenuItem.Text = "Save && Close";
			this.saveCloseToolStripMenuItem.Click += new System.EventHandler(this.menuAccountsManagerClose_Click);
			// 
			// dataAccounts
			// 
			this.dataAccounts.AllowUserToOrderColumns = true;
			this.dataAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataAccounts.Location = new System.Drawing.Point(0, 24);
			this.dataAccounts.MultiSelect = false;
			this.dataAccounts.Name = "dataAccounts";
			this.dataAccounts.Size = new System.Drawing.Size(655, 327);
			this.dataAccounts.TabIndex = 2;
			this.dataAccounts.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataAccounts_CellEndEdit);
			this.dataAccounts.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataAccounts_UserAddedRow);
			this.dataAccounts.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataAccounts_UserDeletedRow);
			// 
			// frmAccountManagement
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(655, 351);
			this.Controls.Add(this.dataAccounts);
			this.Controls.Add(this.menuStrip1);
			this.KeyPreview = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "frmAccountManagement";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Account Management";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAccountManagement_FormClosing);
			this.Load += new System.EventHandler(this.frmAccountManagement_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataAccounts)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem menuAccountsManagerClose;
		private System.Windows.Forms.ToolStripMenuItem saveCloseToolStripMenuItem;
		private System.Windows.Forms.DataGridView dataAccounts;

	}
}