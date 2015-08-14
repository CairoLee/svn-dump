namespace Ragnarok3D.Editor {
	partial class PaintTools {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( PaintTools ) );
			this.SlideCursorItensity = new System.Windows.Forms.HScrollBar();
			this.SlideArrowSize = new System.Windows.Forms.HScrollBar();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.ChkBordering = new System.Windows.Forms.CheckBox();
			this.ListeTextureImages = new System.Windows.Forms.ImageList( this.components );
			this.ChkFill = new System.Windows.Forms.CheckBox();
			this.ChkArrow = new System.Windows.Forms.CheckBox();
			this.timer1 = new System.Windows.Forms.Timer( this.components );
			this.label3 = new System.Windows.Forms.Label();
			this.ListeTextures = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.SlideTextureScale = new System.Windows.Forms.TrackBar();
			this.label5 = new System.Windows.Forms.Label();
			this.DropDownTexture = new System.Windows.Forms.ComboBox();
			this.BtnTextureImport = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize)( this.SlideTextureScale ) ).BeginInit();
			this.SuspendLayout();
			// 
			// SlideCursorItensity
			// 
			this.SlideCursorItensity.Cursor = System.Windows.Forms.Cursors.Default;
			this.SlideCursorItensity.Location = new System.Drawing.Point( 349, 126 );
			this.SlideCursorItensity.Minimum = 1;
			this.SlideCursorItensity.Name = "SlideCursorItensity";
			this.SlideCursorItensity.Size = new System.Drawing.Size( 122, 17 );
			this.SlideCursorItensity.TabIndex = 12;
			this.SlideCursorItensity.Value = 20;
			this.SlideCursorItensity.Scroll += new System.Windows.Forms.ScrollEventHandler( this.SlideCursorItensity_Scroll );
			// 
			// SlideArrowSize
			// 
			this.SlideArrowSize.Cursor = System.Windows.Forms.Cursors.Default;
			this.SlideArrowSize.LargeChange = 1;
			this.SlideArrowSize.Location = new System.Drawing.Point( 330, 100 );
			this.SlideArrowSize.Maximum = 10;
			this.SlideArrowSize.Minimum = 1;
			this.SlideArrowSize.Name = "SlideArrowSize";
			this.SlideArrowSize.Size = new System.Drawing.Size( 141, 17 );
			this.SlideArrowSize.TabIndex = 11;
			this.SlideArrowSize.Value = 2;
			this.SlideArrowSize.Scroll += new System.Windows.Forms.ScrollEventHandler( this.SlideArrowSize_Scroll );
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 292, 128 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 52, 13 );
			this.label2.TabIndex = 14;
			this.label2.Text = "Intensity :";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 293, 101 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 33, 13 );
			this.label1.TabIndex = 13;
			this.label1.Text = "Size :";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add( this.ChkBordering );
			this.groupBox1.Controls.Add( this.ChkFill );
			this.groupBox1.Controls.Add( this.ChkArrow );
			this.groupBox1.Location = new System.Drawing.Point( 284, 7 );
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size( 195, 80 );
			this.groupBox1.TabIndex = 15;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Paint Tools";
			// 
			// ChkBordering
			// 
			this.ChkBordering.Appearance = System.Windows.Forms.Appearance.Button;
			this.ChkBordering.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.ChkBordering.Checked = true;
			this.ChkBordering.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ChkBordering.Cursor = System.Windows.Forms.Cursors.Default;
			this.ChkBordering.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.ChkBordering.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 180 ) ) ) ), ( (int)( ( (byte)( 213 ) ) ) ), ( (int)( ( (byte)( 155 ) ) ) ) );
			this.ChkBordering.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ChkBordering.ImageKey = "unfill_icon.bmp";
			this.ChkBordering.ImageList = this.ListeTextureImages;
			this.ChkBordering.Location = new System.Drawing.Point( 125, 15 );
			this.ChkBordering.Name = "ChkBordering";
			this.ChkBordering.Size = new System.Drawing.Size( 62, 61 );
			this.ChkBordering.TabIndex = 13;
			this.ChkBordering.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.ChkBordering.UseVisualStyleBackColor = true;
			this.ChkBordering.CheckedChanged += new System.EventHandler( this.ChkBordering_CheckedChanged );
			// 
			// ListeTextureImages
			// 
			this.ListeTextureImages.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "ListeTextureImages.ImageStream" ) ) );
			this.ListeTextureImages.TransparentColor = System.Drawing.Color.Transparent;
			this.ListeTextureImages.Images.SetKeyName( 0, "arrow_icon.bmp" );
			this.ListeTextureImages.Images.SetKeyName( 1, "fill_icon.bmp" );
			this.ListeTextureImages.Images.SetKeyName( 2, "unfill_icon.bmp" );
			// 
			// ChkFill
			// 
			this.ChkFill.Appearance = System.Windows.Forms.Appearance.Button;
			this.ChkFill.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.ChkFill.Checked = true;
			this.ChkFill.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ChkFill.Cursor = System.Windows.Forms.Cursors.Default;
			this.ChkFill.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.ChkFill.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 180 ) ) ) ), ( (int)( ( (byte)( 213 ) ) ) ), ( (int)( ( (byte)( 155 ) ) ) ) );
			this.ChkFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ChkFill.ImageKey = "fill_icon.bmp";
			this.ChkFill.ImageList = this.ListeTextureImages;
			this.ChkFill.Location = new System.Drawing.Point( 65, 15 );
			this.ChkFill.Name = "ChkFill";
			this.ChkFill.Size = new System.Drawing.Size( 62, 61 );
			this.ChkFill.TabIndex = 12;
			this.ChkFill.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.ChkFill.UseVisualStyleBackColor = true;
			this.ChkFill.CheckedChanged += new System.EventHandler( this.ChkFill_CheckedChanged );
			// 
			// ChkArrow
			// 
			this.ChkArrow.Appearance = System.Windows.Forms.Appearance.Button;
			this.ChkArrow.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.ChkArrow.Checked = true;
			this.ChkArrow.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ChkArrow.Cursor = System.Windows.Forms.Cursors.Default;
			this.ChkArrow.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.ChkArrow.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb( ( (int)( ( (byte)( 180 ) ) ) ), ( (int)( ( (byte)( 213 ) ) ) ), ( (int)( ( (byte)( 155 ) ) ) ) );
			this.ChkArrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ChkArrow.ImageKey = "arrow_icon.bmp";
			this.ChkArrow.ImageList = this.ListeTextureImages;
			this.ChkArrow.Location = new System.Drawing.Point( 6, 15 );
			this.ChkArrow.Name = "ChkArrow";
			this.ChkArrow.Size = new System.Drawing.Size( 62, 61 );
			this.ChkArrow.TabIndex = 11;
			this.ChkArrow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.ChkArrow.UseVisualStyleBackColor = true;
			this.ChkArrow.CheckedChanged += new System.EventHandler( this.ChkArrow_CheckedChanged );
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Tick += new System.EventHandler( this.timer1_Tick );
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Location = new System.Drawing.Point( 12, 158 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 40, 13 );
			this.label3.TabIndex = 49;
			this.label3.Text = "Scale :";
			// 
			// ListeTextures
			// 
			this.ListeTextures.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.ListeTextures.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4} );
			this.ListeTextures.FullRowSelect = true;
			this.ListeTextures.GridLines = true;
			this.ListeTextures.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.ListeTextures.Location = new System.Drawing.Point( 4, 5 );
			this.ListeTextures.MultiSelect = false;
			this.ListeTextures.Name = "ListeTextures";
			this.ListeTextures.ShowGroups = false;
			this.ListeTextures.Size = new System.Drawing.Size( 268, 112 );
			this.ListeTextures.TabIndex = 46;
			this.ListeTextures.UseCompatibleStateImageBehavior = false;
			this.ListeTextures.View = System.Windows.Forms.View.Details;
			this.ListeTextures.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler( this.ListeTextures_ItemSelectionChanged );
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Name";
			this.columnHeader1.Width = 69;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Texture";
			this.columnHeader2.Width = 113;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Scale";
			this.columnHeader4.Width = 52;
			// 
			// SlideTextureScale
			// 
			this.SlideTextureScale.Location = new System.Drawing.Point( 52, 152 );
			this.SlideTextureScale.Maximum = 200;
			this.SlideTextureScale.Minimum = 1;
			this.SlideTextureScale.Name = "SlideTextureScale";
			this.SlideTextureScale.Size = new System.Drawing.Size( 148, 45 );
			this.SlideTextureScale.TabIndex = 44;
			this.SlideTextureScale.TickFrequency = 22;
			this.SlideTextureScale.TickStyle = System.Windows.Forms.TickStyle.None;
			this.SlideTextureScale.Value = 10;
			this.SlideTextureScale.Scroll += new System.EventHandler( this.trackBar4_Scroll );
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Location = new System.Drawing.Point( 9, 128 );
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size( 49, 13 );
			this.label5.TabIndex = 43;
			this.label5.Text = "Texture :";
			// 
			// DropDownTexture
			// 
			this.DropDownTexture.FormattingEnabled = true;
			this.DropDownTexture.Location = new System.Drawing.Point( 60, 125 );
			this.DropDownTexture.Name = "DropDownTexture";
			this.DropDownTexture.Size = new System.Drawing.Size( 136, 21 );
			this.DropDownTexture.TabIndex = 45;
			this.DropDownTexture.SelectedIndexChanged += new System.EventHandler( this.DropDownTexture_SelectedIndexChanged );
			this.DropDownTexture.KeyUp += new System.Windows.Forms.KeyEventHandler( this.DropDownTexture_KeyUp );
			this.DropDownTexture.KeyDown += new System.Windows.Forms.KeyEventHandler( this.DropDownTexture_KeyDown );
			// 
			// BtnTextureImport
			// 
			this.BtnTextureImport.Location = new System.Drawing.Point( 206, 123 );
			this.BtnTextureImport.Name = "BtnTextureImport";
			this.BtnTextureImport.Size = new System.Drawing.Size( 66, 23 );
			this.BtnTextureImport.TabIndex = 51;
			this.BtnTextureImport.Text = "Import..";
			this.BtnTextureImport.UseVisualStyleBackColor = true;
			this.BtnTextureImport.Click += new System.EventHandler( this.BtnTextureImport_Click );
			// 
			// PaintTools
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 490, 184 );
			this.Controls.Add( this.BtnTextureImport );
			this.Controls.Add( this.label3 );
			this.Controls.Add( this.ListeTextures );
			this.Controls.Add( this.SlideTextureScale );
			this.Controls.Add( this.label5 );
			this.Controls.Add( this.DropDownTexture );
			this.Controls.Add( this.groupBox1 );
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.SlideCursorItensity );
			this.Controls.Add( this.SlideArrowSize );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "PaintTools";
			this.Text = "Texture Painting";
			this.Load += new System.EventHandler( this.PaintTools_Load );
			this.groupBox1.ResumeLayout( false );
			( (System.ComponentModel.ISupportInitialize)( this.SlideTextureScale ) ).EndInit();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.HScrollBar SlideCursorItensity;
		private System.Windows.Forms.HScrollBar SlideArrowSize;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox ChkBordering;
		private System.Windows.Forms.CheckBox ChkFill;
		private System.Windows.Forms.CheckBox ChkArrow;
		private System.Windows.Forms.ImageList ListeTextureImages;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListView ListeTextures;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.TrackBar SlideTextureScale;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox DropDownTexture;
		private System.Windows.Forms.Button BtnTextureImport;
	}
}