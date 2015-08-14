namespace Ssc {
	partial class frmAbout {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( frmAbout ) );
			this.logoPictureBox = new System.Windows.Forms.PictureBox();
			this.okButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			( (System.ComponentModel.ISupportInitialize)( this.logoPictureBox ) ).BeginInit();
			this.SuspendLayout();
			// 
			// logoPictureBox
			// 
			this.logoPictureBox.BackColor = System.Drawing.Color.Transparent;
			this.logoPictureBox.Image = global::Ssc.Properties.Resources.godlesz_r0xy;
			this.logoPictureBox.Location = new System.Drawing.Point( 12, 12 );
			this.logoPictureBox.Name = "logoPictureBox";
			this.logoPictureBox.Size = new System.Drawing.Size( 333, 273 );
			this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.logoPictureBox.TabIndex = 12;
			this.logoPictureBox.TabStop = false;
			// 
			// okButton
			// 
			this.okButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.okButton.Location = new System.Drawing.Point( 140, 401 );
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size( 75, 21 );
			this.okButton.TabIndex = 24;
			this.okButton.Text = "&OK";
			this.okButton.Click += new System.EventHandler( this.okButton_Click );
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 125, 303 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 94, 13 );
			this.label1.TabIndex = 25;
			this.label1.Text = "Shaiya Skill Planer";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.SystemColors.ButtonShadow;
			this.label2.Location = new System.Drawing.Point( 12, 322 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 331, 13 );
			this.label2.TabIndex = 26;
			this.label2.Text = "______________________________________________________";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
			this.label3.Location = new System.Drawing.Point( 122, 348 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 111, 15 );
			this.label3.TabIndex = 27;
			this.label3.Text = "Coding © GodLesZ";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
			this.label4.Location = new System.Drawing.Point( 134, 364 );
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size( 86, 15 );
			this.label4.TabIndex = 28;
			this.label4.Text = "Design © r0xy.";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
			this.label5.Location = new System.Drawing.Point( 115, 379 );
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size( 125, 15 );
			this.label5.TabIndex = 29;
			this.label5.Text = "Skill Images © SonoV";
			// 
			// frmAbout
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 355, 430 );
			this.Controls.Add( this.label5 );
			this.Controls.Add( this.label4 );
			this.Controls.Add( this.label3 );
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.logoPictureBox );
			this.Controls.Add( this.okButton );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmAbout";
			this.Padding = new System.Windows.Forms.Padding( 9 );
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "AboutBox1";
			( (System.ComponentModel.ISupportInitialize)( this.logoPictureBox ) ).EndInit();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox logoPictureBox;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;

	}
}
