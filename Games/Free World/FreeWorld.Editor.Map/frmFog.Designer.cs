using FreeWorld.Engine.Tools.XnaFake;

namespace FreeWorld.Editor.Map {
	partial class frmFog {
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
			this.ListFogs = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SliderDense = new System.Windows.Forms.TrackBar();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.ColorBox = new System.Windows.Forms.PictureBox();
			this.FogDisplay = new TileDisplay();
			this.label3 = new System.Windows.Forms.Label();
			this.SliderRed = new System.Windows.Forms.TrackBar();
			this.SliderGreen = new System.Windows.Forms.TrackBar();
			this.label4 = new System.Windows.Forms.Label();
			this.SliderBlue = new System.Windows.Forms.TrackBar();
			this.label5 = new System.Windows.Forms.Label();
			( (System.ComponentModel.ISupportInitialize)( this.SliderDense ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.ColorBox ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.SliderRed ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.SliderGreen ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.SliderBlue ) ).BeginInit();
			this.SuspendLayout();
			// 
			// ListFogs
			// 
			this.ListFogs.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left ) ) );
			this.ListFogs.FormattingEnabled = true;
			this.ListFogs.Location = new System.Drawing.Point( 13, 13 );
			this.ListFogs.Name = "ListFogs";
			this.ListFogs.Size = new System.Drawing.Size( 86, 446 );
			this.ListFogs.TabIndex = 0;
			this.ListFogs.SelectedIndexChanged += new System.EventHandler( this.ListFogs_SelectedIndexChanged );
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 102, 323 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 50, 13 );
			this.label1.TabIndex = 2;
			this.label1.Text = "Intensität";
			// 
			// SliderDense
			// 
			this.SliderDense.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.SliderDense.AutoSize = false;
			this.SliderDense.Location = new System.Drawing.Point( 147, 318 );
			this.SliderDense.Maximum = 99;
			this.SliderDense.Minimum = 1;
			this.SliderDense.Name = "SliderDense";
			this.SliderDense.Size = new System.Drawing.Size( 259, 22 );
			this.SliderDense.TabIndex = 3;
			this.SliderDense.Value = 1;
			this.SliderDense.Scroll += new System.EventHandler( this.SliderDense_Scroll );
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
			this.btnOk.Location = new System.Drawing.Point( 105, 437 );
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size( 82, 23 );
			this.btnOk.TabIndex = 4;
			this.btnOk.Text = "Übernehmen";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler( this.btnOk_Click );
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnClose.Location = new System.Drawing.Point( 329, 437 );
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size( 75, 23 );
			this.btnClose.TabIndex = 5;
			this.btnClose.Text = "Abbrechen";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 102, 347 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 34, 13 );
			this.label2.TabIndex = 6;
			this.label2.Text = "Farbe";
			// 
			// ColorBox
			// 
			this.ColorBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ColorBox.Location = new System.Drawing.Point( 155, 345 );
			this.ColorBox.Name = "ColorBox";
			this.ColorBox.Size = new System.Drawing.Size( 30, 18 );
			this.ColorBox.TabIndex = 7;
			this.ColorBox.TabStop = false;
			this.ColorBox.Click += new System.EventHandler( this.ColorBox_Click );
			// 
			// FogDisplay
			// 
			this.FogDisplay.Location = new System.Drawing.Point( 105, 13 );
			this.FogDisplay.Name = "FogDisplay";
			this.FogDisplay.Size = new System.Drawing.Size( 300, 300 );
			this.FogDisplay.TabIndex = 1;
			this.FogDisplay.Text = "tileDisplay1";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point( 198, 347 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 15, 13 );
			this.label3.TabIndex = 8;
			this.label3.Text = "R";
			// 
			// SliderRed
			// 
			this.SliderRed.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.SliderRed.AutoSize = false;
			this.SliderRed.Location = new System.Drawing.Point( 220, 342 );
			this.SliderRed.Maximum = 255;
			this.SliderRed.Name = "SliderRed";
			this.SliderRed.Size = new System.Drawing.Size( 184, 22 );
			this.SliderRed.TabIndex = 9;
			this.SliderRed.Value = 1;
			this.SliderRed.Scroll += new System.EventHandler( this.SliderRed_Scroll );
			// 
			// SliderGreen
			// 
			this.SliderGreen.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.SliderGreen.AutoSize = false;
			this.SliderGreen.Location = new System.Drawing.Point( 220, 363 );
			this.SliderGreen.Maximum = 255;
			this.SliderGreen.Name = "SliderGreen";
			this.SliderGreen.Size = new System.Drawing.Size( 184, 22 );
			this.SliderGreen.TabIndex = 11;
			this.SliderGreen.Value = 1;
			this.SliderGreen.Scroll += new System.EventHandler( this.SliderGreen_Scroll );
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point( 198, 368 );
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size( 15, 13 );
			this.label4.TabIndex = 10;
			this.label4.Text = "G";
			// 
			// SliderBlue
			// 
			this.SliderBlue.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.SliderBlue.AutoSize = false;
			this.SliderBlue.Location = new System.Drawing.Point( 220, 384 );
			this.SliderBlue.Maximum = 255;
			this.SliderBlue.Name = "SliderBlue";
			this.SliderBlue.Size = new System.Drawing.Size( 184, 22 );
			this.SliderBlue.TabIndex = 13;
			this.SliderBlue.Value = 1;
			this.SliderBlue.Scroll += new System.EventHandler( this.SliderBlue_Scroll );
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point( 198, 389 );
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size( 14, 13 );
			this.label5.TabIndex = 12;
			this.label5.Text = "B";
			// 
			// frmFog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 419, 472 );
			this.Controls.Add( this.SliderBlue );
			this.Controls.Add( this.label5 );
			this.Controls.Add( this.SliderGreen );
			this.Controls.Add( this.label4 );
			this.Controls.Add( this.SliderRed );
			this.Controls.Add( this.label3 );
			this.Controls.Add( this.ColorBox );
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.btnClose );
			this.Controls.Add( this.btnOk );
			this.Controls.Add( this.SliderDense );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.FogDisplay );
			this.Controls.Add( this.ListFogs );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmFog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Nebel Einstellung";
			( (System.ComponentModel.ISupportInitialize)( this.SliderDense ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.ColorBox ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.SliderRed ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.SliderGreen ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.SliderBlue ) ).EndInit();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox ListFogs;
		private TileDisplay FogDisplay;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TrackBar SliderDense;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox ColorBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TrackBar SliderRed;
		private System.Windows.Forms.TrackBar SliderGreen;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TrackBar SliderBlue;
		private System.Windows.Forms.Label label5;
	}
}