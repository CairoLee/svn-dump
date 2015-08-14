namespace Ragnarok3D.Editor {
	partial class CustomSize {
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
			this.InputCustomWidth = new System.Windows.Forms.NumericUpDown();
			this.BtnCreateCustomHeightmap = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.InputCustomHeight = new System.Windows.Forms.NumericUpDown();
			( (System.ComponentModel.ISupportInitialize)( this.InputCustomWidth ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.InputCustomHeight ) ).BeginInit();
			this.SuspendLayout();
			// 
			// InputCustomWidth
			// 
			this.InputCustomWidth.Increment = new decimal( new int[] {
            32,
            0,
            0,
            0} );
			this.InputCustomWidth.Location = new System.Drawing.Point( 98, 12 );
			this.InputCustomWidth.Maximum = new decimal( new int[] {
            256,
            0,
            0,
            0} );
			this.InputCustomWidth.Minimum = new decimal( new int[] {
            32,
            0,
            0,
            0} );
			this.InputCustomWidth.Name = "InputCustomWidth";
			this.InputCustomWidth.Size = new System.Drawing.Size( 57, 20 );
			this.InputCustomWidth.TabIndex = 0;
			this.InputCustomWidth.Value = new decimal( new int[] {
            64,
            0,
            0,
            0} );
			// 
			// BtnCreateCustomHeightmap
			// 
			this.BtnCreateCustomHeightmap.Location = new System.Drawing.Point( 12, 73 );
			this.BtnCreateCustomHeightmap.Name = "BtnCreateCustomHeightmap";
			this.BtnCreateCustomHeightmap.Size = new System.Drawing.Size( 142, 23 );
			this.BtnCreateCustomHeightmap.TabIndex = 1;
			this.BtnCreateCustomHeightmap.Text = "Create Heightmap";
			this.BtnCreateCustomHeightmap.UseVisualStyleBackColor = true;
			this.BtnCreateCustomHeightmap.Click += new System.EventHandler( this.BtnCreateCustomHeightmap_Click );
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 12, 14 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 80, 13 );
			this.label1.TabIndex = 2;
			this.label1.Text = "Texture Width :";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 9, 40 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 83, 13 );
			this.label2.TabIndex = 4;
			this.label2.Text = "Texture Height :";
			// 
			// InputCustomHeight
			// 
			this.InputCustomHeight.Increment = new decimal( new int[] {
            32,
            0,
            0,
            0} );
			this.InputCustomHeight.Location = new System.Drawing.Point( 98, 38 );
			this.InputCustomHeight.Maximum = new decimal( new int[] {
            256,
            0,
            0,
            0} );
			this.InputCustomHeight.Minimum = new decimal( new int[] {
            32,
            0,
            0,
            0} );
			this.InputCustomHeight.Name = "InputCustomHeight";
			this.InputCustomHeight.Size = new System.Drawing.Size( 57, 20 );
			this.InputCustomHeight.TabIndex = 3;
			this.InputCustomHeight.Value = new decimal( new int[] {
            64,
            0,
            0,
            0} );
			// 
			// CustomSize
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 166, 108 );
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.InputCustomHeight );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.BtnCreateCustomHeightmap );
			this.Controls.Add( this.InputCustomWidth );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "CustomSize";
			this.Text = "Custom Size";
			( (System.ComponentModel.ISupportInitialize)( this.InputCustomWidth ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.InputCustomHeight ) ).EndInit();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NumericUpDown InputCustomWidth;
		private System.Windows.Forms.Button BtnCreateCustomHeightmap;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown InputCustomHeight;
	}
}