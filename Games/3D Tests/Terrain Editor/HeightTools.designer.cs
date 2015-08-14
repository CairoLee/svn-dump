namespace Ragnarok3D.Editor {
	partial class HeightTools {
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( HeightTools ) );
			this.ChkArrow = new System.Windows.Forms.CheckBox();
			this.imageList1 = new System.Windows.Forms.ImageList( this.components );
			this.ChkRaise = new System.Windows.Forms.CheckBox();
			this.ChkLower = new System.Windows.Forms.CheckBox();
			this.ChkSmooth = new System.Windows.Forms.CheckBox();
			this.ChkFlattern = new System.Windows.Forms.CheckBox();
			this.SlideCursorSize = new System.Windows.Forms.HScrollBar();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SlideCursorForce = new System.Windows.Forms.HScrollBar();
			this.timer1 = new System.Windows.Forms.Timer( this.components );
			this.SuspendLayout();
			// 
			// ChkArrow
			// 
			this.ChkArrow.Appearance = System.Windows.Forms.Appearance.Button;
			this.ChkArrow.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.ChkArrow.Checked = true;
			this.ChkArrow.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ChkArrow.Cursor = System.Windows.Forms.Cursors.Default;
			this.ChkArrow.Dock = System.Windows.Forms.DockStyle.Left;
			this.ChkArrow.FlatAppearance.BorderColor = System.Drawing.Color.White;
			this.ChkArrow.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 180 ) ) ) ), ( (int)( ( (byte)( 213 ) ) ) ), ( (int)( ( (byte)( 155 ) ) ) ) );
			this.ChkArrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ChkArrow.ImageKey = "arrow_icon.bmp";
			this.ChkArrow.ImageList = this.imageList1;
			this.ChkArrow.Location = new System.Drawing.Point( 0, 0 );
			this.ChkArrow.Name = "ChkArrow";
			this.ChkArrow.Size = new System.Drawing.Size( 62, 62 );
			this.ChkArrow.TabIndex = 1;
			this.ChkArrow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.ChkArrow.UseVisualStyleBackColor = true;
			this.ChkArrow.CheckedChanged += new System.EventHandler( this.checkBox1_CheckedChanged );
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "imageList1.ImageStream" ) ) );
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName( 0, "arrow_icon.bmp" );
			this.imageList1.Images.SetKeyName( 1, "smooth_icon.bmp" );
			this.imageList1.Images.SetKeyName( 2, "lower_icon.bmp" );
			this.imageList1.Images.SetKeyName( 3, "rise_icon.bmp" );
			this.imageList1.Images.SetKeyName( 4, "flatten_icon.bmp" );
			// 
			// ChkRaise
			// 
			this.ChkRaise.Appearance = System.Windows.Forms.Appearance.Button;
			this.ChkRaise.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.ChkRaise.Checked = true;
			this.ChkRaise.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ChkRaise.Cursor = System.Windows.Forms.Cursors.Default;
			this.ChkRaise.Dock = System.Windows.Forms.DockStyle.Left;
			this.ChkRaise.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 180 ) ) ) ), ( (int)( ( (byte)( 213 ) ) ) ), ( (int)( ( (byte)( 155 ) ) ) ) );
			this.ChkRaise.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ChkRaise.ImageKey = "rise_icon.bmp";
			this.ChkRaise.ImageList = this.imageList1;
			this.ChkRaise.Location = new System.Drawing.Point( 62, 0 );
			this.ChkRaise.Name = "ChkRaise";
			this.ChkRaise.Size = new System.Drawing.Size( 62, 62 );
			this.ChkRaise.TabIndex = 2;
			this.ChkRaise.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.ChkRaise.UseVisualStyleBackColor = true;
			this.ChkRaise.CheckedChanged += new System.EventHandler( this.checkBox2_CheckedChanged );
			// 
			// ChkLower
			// 
			this.ChkLower.Appearance = System.Windows.Forms.Appearance.Button;
			this.ChkLower.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.ChkLower.Checked = true;
			this.ChkLower.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ChkLower.Cursor = System.Windows.Forms.Cursors.Default;
			this.ChkLower.Dock = System.Windows.Forms.DockStyle.Left;
			this.ChkLower.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 180 ) ) ) ), ( (int)( ( (byte)( 213 ) ) ) ), ( (int)( ( (byte)( 155 ) ) ) ) );
			this.ChkLower.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ChkLower.ImageKey = "lower_icon.bmp";
			this.ChkLower.ImageList = this.imageList1;
			this.ChkLower.Location = new System.Drawing.Point( 124, 0 );
			this.ChkLower.Name = "ChkLower";
			this.ChkLower.Size = new System.Drawing.Size( 62, 62 );
			this.ChkLower.TabIndex = 3;
			this.ChkLower.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.ChkLower.UseVisualStyleBackColor = true;
			this.ChkLower.CheckedChanged += new System.EventHandler( this.checkBox3_CheckedChanged );
			// 
			// ChkSmooth
			// 
			this.ChkSmooth.Appearance = System.Windows.Forms.Appearance.Button;
			this.ChkSmooth.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.ChkSmooth.Checked = true;
			this.ChkSmooth.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ChkSmooth.Cursor = System.Windows.Forms.Cursors.Default;
			this.ChkSmooth.Dock = System.Windows.Forms.DockStyle.Left;
			this.ChkSmooth.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 180 ) ) ) ), ( (int)( ( (byte)( 213 ) ) ) ), ( (int)( ( (byte)( 155 ) ) ) ) );
			this.ChkSmooth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ChkSmooth.ImageKey = "smooth_icon.bmp";
			this.ChkSmooth.ImageList = this.imageList1;
			this.ChkSmooth.Location = new System.Drawing.Point( 186, 0 );
			this.ChkSmooth.Name = "ChkSmooth";
			this.ChkSmooth.Size = new System.Drawing.Size( 62, 62 );
			this.ChkSmooth.TabIndex = 4;
			this.ChkSmooth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.ChkSmooth.UseVisualStyleBackColor = true;
			this.ChkSmooth.CheckedChanged += new System.EventHandler( this.checkBox4_CheckedChanged );
			// 
			// ChkFlattern
			// 
			this.ChkFlattern.Appearance = System.Windows.Forms.Appearance.Button;
			this.ChkFlattern.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.ChkFlattern.Checked = true;
			this.ChkFlattern.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ChkFlattern.Cursor = System.Windows.Forms.Cursors.Default;
			this.ChkFlattern.Dock = System.Windows.Forms.DockStyle.Left;
			this.ChkFlattern.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 180 ) ) ) ), ( (int)( ( (byte)( 213 ) ) ) ), ( (int)( ( (byte)( 155 ) ) ) ) );
			this.ChkFlattern.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ChkFlattern.ImageKey = "flatten_icon.bmp";
			this.ChkFlattern.ImageList = this.imageList1;
			this.ChkFlattern.Location = new System.Drawing.Point( 248, 0 );
			this.ChkFlattern.Name = "ChkFlattern";
			this.ChkFlattern.Size = new System.Drawing.Size( 62, 62 );
			this.ChkFlattern.TabIndex = 5;
			this.ChkFlattern.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.ChkFlattern.UseVisualStyleBackColor = true;
			this.ChkFlattern.CheckedChanged += new System.EventHandler( this.checkBox5_CheckedChanged );
			// 
			// SlideCursorSize
			// 
			this.SlideCursorSize.Cursor = System.Windows.Forms.Cursors.Default;
			this.SlideCursorSize.LargeChange = 1;
			this.SlideCursorSize.Location = new System.Drawing.Point( 365, 10 );
			this.SlideCursorSize.Maximum = 10;
			this.SlideCursorSize.Minimum = 1;
			this.SlideCursorSize.Name = "SlideCursorSize";
			this.SlideCursorSize.Size = new System.Drawing.Size( 141, 17 );
			this.SlideCursorSize.TabIndex = 6;
			this.SlideCursorSize.Value = 2;
			this.SlideCursorSize.Scroll += new System.Windows.Forms.ScrollEventHandler( this.hScrollBar1_Scroll );
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 329, 13 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 33, 13 );
			this.label1.TabIndex = 8;
			this.label1.Text = "Size :";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 322, 39 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 40, 13 );
			this.label2.TabIndex = 9;
			this.label2.Text = "Force :";
			// 
			// SlideCursorForce
			// 
			this.SlideCursorForce.Cursor = System.Windows.Forms.Cursors.Default;
			this.SlideCursorForce.Location = new System.Drawing.Point( 365, 36 );
			this.SlideCursorForce.Minimum = 1;
			this.SlideCursorForce.Name = "SlideCursorForce";
			this.SlideCursorForce.Size = new System.Drawing.Size( 141, 17 );
			this.SlideCursorForce.TabIndex = 7;
			this.SlideCursorForce.Value = 20;
			this.SlideCursorForce.Scroll += new System.Windows.Forms.ScrollEventHandler( this.hScrollBar2_Scroll );
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 30;
			this.timer1.Tick += new System.EventHandler( this.timer1_Tick );
			// 
			// HeightTools
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 520, 62 );
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.SlideCursorForce );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.SlideCursorSize );
			this.Controls.Add( this.ChkFlattern );
			this.Controls.Add( this.ChkSmooth );
			this.Controls.Add( this.ChkLower );
			this.Controls.Add( this.ChkRaise );
			this.Controls.Add( this.ChkArrow );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "HeightTools";
			this.Text = "HeightTools";
			this.Load += new System.EventHandler( this.HeightTools_Load );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox ChkArrow;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.CheckBox ChkRaise;
		private System.Windows.Forms.CheckBox ChkLower;
		private System.Windows.Forms.CheckBox ChkSmooth;
		private System.Windows.Forms.CheckBox ChkFlattern;
		private System.Windows.Forms.HScrollBar SlideCursorSize;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.HScrollBar SlideCursorForce;
		private System.Windows.Forms.Timer timer1;

	}
}