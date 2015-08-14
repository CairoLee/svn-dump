namespace GrfEditor.Client {
	partial class FrmSettings {
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
			this.chkErrorOnResnametable = new System.Windows.Forms.CheckBox();
			this.chkEnableResnametableSearch = new System.Windows.Forms.CheckBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// chkErrorOnResnametable
			// 
			this.chkErrorOnResnametable.AutoSize = true;
			this.chkErrorOnResnametable.Checked = global::GrfEditor.Client.Properties.Settings.Default.ErrorOnResnametable;
			this.chkErrorOnResnametable.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkErrorOnResnametable.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::GrfEditor.Client.Properties.Settings.Default, "ErrorOnResnametable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.chkErrorOnResnametable.Location = new System.Drawing.Point(12, 35);
			this.chkErrorOnResnametable.Name = "chkErrorOnResnametable";
			this.chkErrorOnResnametable.Size = new System.Drawing.Size(167, 17);
			this.chkErrorOnResnametable.TabIndex = 1;
			this.chkErrorOnResnametable.Text = "Error if no resnametable found";
			this.chkErrorOnResnametable.UseVisualStyleBackColor = true;
			// 
			// chkEnableResnametableSearch
			// 
			this.chkEnableResnametableSearch.AutoSize = true;
			this.chkEnableResnametableSearch.Checked = global::GrfEditor.Client.Properties.Settings.Default.EnableResnametableSearch;
			this.chkEnableResnametableSearch.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkEnableResnametableSearch.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::GrfEditor.Client.Properties.Settings.Default, "EnableResnametableSearch", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.chkEnableResnametableSearch.Location = new System.Drawing.Point(12, 12);
			this.chkEnableResnametableSearch.Name = "chkEnableResnametableSearch";
			this.chkEnableResnametableSearch.Size = new System.Drawing.Size(165, 17);
			this.chkEnableResnametableSearch.TabIndex = 0;
			this.chkEnableResnametableSearch.Text = "Enable Resnametable search";
			this.chkEnableResnametableSearch.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(402, 282);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "Save";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(483, 282);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// frmSettings
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(570, 317);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.chkErrorOnResnametable);
			this.Controls.Add(this.chkEnableResnametableSearch);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmSettings";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Settings";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox chkEnableResnametableSearch;
		private System.Windows.Forms.CheckBox chkErrorOnResnametable;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
	}
}