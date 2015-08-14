namespace Ssc {
	partial class frmSplash {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( frmSplash ) );
			this.lblLoading = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblLoading
			// 
			this.lblLoading.AutoSize = true;
			this.lblLoading.BackColor = System.Drawing.Color.Transparent;
			this.lblLoading.Font = new System.Drawing.Font( "Kingthings Wrote", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
			this.lblLoading.ForeColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 105 ) ) ) ), ( (int)( ( (byte)( 99 ) ) ) ), ( (int)( ( (byte)( 73 ) ) ) ) );
			this.lblLoading.Location = new System.Drawing.Point( 77, 388 );
			this.lblLoading.Name = "lblLoading";
			this.lblLoading.Size = new System.Drawing.Size( 0, 20 );
			this.lblLoading.TabIndex = 0;
			// 
			// frmSplash
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Fuchsia;
			this.BackgroundImage = global::Ssc.Properties.Resources.Splash;
			this.ClientSize = new System.Drawing.Size( 716, 412 );
			this.Controls.Add( this.lblLoading );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
			this.Name = "frmSplash";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Shaiya Skill Planer - Loading...";
			this.TopMost = true;
			this.TransparencyKey = System.Drawing.Color.Fuchsia;
			this.Load += new System.EventHandler( this.frmSplash_Load );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblLoading;

	}
}