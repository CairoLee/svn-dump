namespace Sbt {
	partial class frmOverlaySetting {
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
			this.label1 = new System.Windows.Forms.Label();
			this.numY = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.btnOkay = new System.Windows.Forms.Button();
			this.numX = new System.Windows.Forms.NumericUpDown();
			this.chkActive = new System.Windows.Forms.CheckBox();
			( (System.ComponentModel.ISupportInitialize)( this.numY ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.numX ) ).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 12, 35 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 54, 13 );
			this.label1.TabIndex = 1;
			this.label1.Text = "Position X";
			// 
			// numY
			// 
			this.numY.DataBindings.Add( new System.Windows.Forms.Binding( "Value", global::Sbt.Properties.Settings.Default, "OverlayY", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged ) );
			this.numY.Enabled = false;
			this.numY.Location = new System.Drawing.Point( 84, 59 );
			this.numY.Maximum = new decimal( new int[] {
            4000,
            0,
            0,
            0} );
			this.numY.Minimum = new decimal( new int[] {
            1000,
            0,
            0,
            -2147483648} );
			this.numY.Name = "numY";
			this.numY.Size = new System.Drawing.Size( 57, 20 );
			this.numY.TabIndex = 4;
			this.numY.Value = global::Sbt.Properties.Settings.Default.OverlayY;
			this.numY.ValueChanged += new System.EventHandler( this.numY_ValueChanged );
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 12, 61 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 54, 13 );
			this.label2.TabIndex = 3;
			this.label2.Text = "Position Y";
			// 
			// btnOkay
			// 
			this.btnOkay.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnOkay.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOkay.Location = new System.Drawing.Point( 188, 56 );
			this.btnOkay.Name = "btnOkay";
			this.btnOkay.Size = new System.Drawing.Size( 75, 23 );
			this.btnOkay.TabIndex = 5;
			this.btnOkay.Text = "Speichern";
			this.btnOkay.UseVisualStyleBackColor = true;
			this.btnOkay.Click += new System.EventHandler( this.btnOkay_Click );
			// 
			// numX
			// 
			this.numX.DataBindings.Add( new System.Windows.Forms.Binding( "Value", global::Sbt.Properties.Settings.Default, "OverlayX", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged ) );
			this.numX.Enabled = false;
			this.numX.Location = new System.Drawing.Point( 84, 33 );
			this.numX.Maximum = new decimal( new int[] {
            4000,
            0,
            0,
            0} );
			this.numX.Minimum = new decimal( new int[] {
            1000,
            0,
            0,
            -2147483648} );
			this.numX.Name = "numX";
			this.numX.Size = new System.Drawing.Size( 57, 20 );
			this.numX.TabIndex = 2;
			this.numX.Value = global::Sbt.Properties.Settings.Default.OverlayX;
			this.numX.ValueChanged += new System.EventHandler( this.numX_ValueChanged );
			// 
			// chkActive
			// 
			this.chkActive.AutoSize = true;
			this.chkActive.Checked = global::Sbt.Properties.Settings.Default.OverlayActive;
			this.chkActive.DataBindings.Add( new System.Windows.Forms.Binding( "Checked", global::Sbt.Properties.Settings.Default, "OverlayActive", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged ) );
			this.chkActive.Location = new System.Drawing.Point( 13, 13 );
			this.chkActive.Name = "chkActive";
			this.chkActive.Size = new System.Drawing.Size( 88, 17 );
			this.chkActive.TabIndex = 0;
			this.chkActive.Text = "Overlay aktiv";
			this.chkActive.UseVisualStyleBackColor = true;
			this.chkActive.CheckedChanged += new System.EventHandler( this.chkActive_CheckedChanged );
			// 
			// frmOverlaySetting
			// 
			this.AcceptButton = this.btnOkay;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 275, 90 );
			this.Controls.Add( this.btnOkay );
			this.Controls.Add( this.numY );
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.numX );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.chkActive );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmOverlaySetting";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Overlay Einstellungen";
			( (System.ComponentModel.ISupportInitialize)( this.numY ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.numX ) ).EndInit();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.CheckBox chkActive;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numX;
		private System.Windows.Forms.NumericUpDown numY;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnOkay;
	}
}