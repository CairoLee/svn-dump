namespace FreeWorld.Editor.Map
{
	partial class frmNewLayer
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( frmNewLayer ) );
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.chkBackground = new System.Windows.Forms.RadioButton();
			this.chkForeground = new System.Windows.Forms.RadioButton();
			this.SuspendLayout();
			// 
			// okButton
			// 
			this.okButton.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.okButton.Location = new System.Drawing.Point( 229, 38 );
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size( 75, 23 );
			this.okButton.TabIndex = 3;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler( this.okButton_Click );
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point( 310, 38 );
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size( 75, 23 );
			this.cancelButton.TabIndex = 4;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler( this.cancelButton_Click );
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 12, 15 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 38, 13 );
			this.label1.TabIndex = 1;
			this.label1.Text = "Name:";
			// 
			// txtName
			// 
			this.txtName.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtName.Location = new System.Drawing.Point( 56, 12 );
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size( 329, 20 );
			this.txtName.TabIndex = 0;
			// 
			// chkBackground
			// 
			this.chkBackground.AutoSize = true;
			this.chkBackground.Checked = true;
			this.chkBackground.Location = new System.Drawing.Point( 15, 41 );
			this.chkBackground.Name = "chkBackground";
			this.chkBackground.Size = new System.Drawing.Size( 80, 17 );
			this.chkBackground.TabIndex = 5;
			this.chkBackground.TabStop = true;
			this.chkBackground.Text = "Hintergrund";
			this.chkBackground.UseVisualStyleBackColor = true;
			// 
			// chkForeground
			// 
			this.chkForeground.AutoSize = true;
			this.chkForeground.Location = new System.Drawing.Point( 116, 41 );
			this.chkForeground.Name = "chkForeground";
			this.chkForeground.Size = new System.Drawing.Size( 83, 17 );
			this.chkForeground.TabIndex = 6;
			this.chkForeground.Text = "Vordergrund";
			this.chkForeground.UseVisualStyleBackColor = true;
			// 
			// frmNewLayer
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size( 396, 69 );
			this.Controls.Add( this.chkForeground );
			this.Controls.Add( this.chkBackground );
			this.Controls.Add( this.txtName );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.cancelButton );
			this.Controls.Add( this.okButton );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmNewLayer";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Neue Ebene";
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox txtName;
		public System.Windows.Forms.RadioButton chkBackground;
		public System.Windows.Forms.RadioButton chkForeground;
	}
}