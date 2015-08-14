namespace FreeWorld.Editor.Map {
	partial class frmNewMap {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( frmNewMap ) );
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtWidth = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtHeight = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// okButton
			// 
			this.okButton.Location = new System.Drawing.Point( 121, 96 );
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size( 75, 23 );
			this.okButton.TabIndex = 3;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler( this.okButton_Click );
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point( 202, 96 );
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
			this.txtName.Location = new System.Drawing.Point( 56, 12 );
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size( 221, 20 );
			this.txtName.TabIndex = 0;
			this.txtName.Text = "neue Map";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 12, 41 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 38, 13 );
			this.label2.TabIndex = 1;
			this.label2.Text = "Width:";
			// 
			// txtWidth
			// 
			this.txtWidth.Location = new System.Drawing.Point( 56, 38 );
			this.txtWidth.Name = "txtWidth";
			this.txtWidth.Size = new System.Drawing.Size( 56, 20 );
			this.txtWidth.TabIndex = 1;
			this.txtWidth.Text = "100";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point( 12, 67 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 41, 13 );
			this.label3.TabIndex = 1;
			this.label3.Text = "Height:";
			// 
			// txtHeight
			// 
			this.txtHeight.Location = new System.Drawing.Point( 56, 64 );
			this.txtHeight.Name = "txtHeight";
			this.txtHeight.Size = new System.Drawing.Size( 56, 20 );
			this.txtHeight.TabIndex = 2;
			this.txtHeight.Text = "100";
			// 
			// frmNewMap
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size( 290, 131 );
			this.Controls.Add( this.txtHeight );
			this.Controls.Add( this.label3 );
			this.Controls.Add( this.txtWidth );
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.txtName );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.cancelButton );
			this.Controls.Add( this.okButton );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmNewMap";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Neue Map";
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		public System.Windows.Forms.TextBox txtName;
		public System.Windows.Forms.TextBox txtWidth;
		public System.Windows.Forms.TextBox txtHeight;
	}
}