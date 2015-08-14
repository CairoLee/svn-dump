namespace ImageHelper {
	partial class ArrowControl {
		/// <summary> 
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose( bool disposing ) {
			if( disposing && ( components != null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Vom Komponenten-Designer generierter Code

		/// <summary> 
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent() {
			this.arrowRight = new System.Windows.Forms.PictureBox();
			this.arrowLeft = new System.Windows.Forms.PictureBox();
			this.arrowDown = new System.Windows.Forms.PictureBox();
			this.arrowTop = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.numX = new System.Windows.Forms.NumericUpDown();
			this.numY = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			( (System.ComponentModel.ISupportInitialize)( this.arrowRight ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.arrowLeft ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.arrowDown ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.arrowTop ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.numX ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.numY ) ).BeginInit();
			this.SuspendLayout();
			// 
			// arrowRight
			// 
			this.arrowRight.Cursor = System.Windows.Forms.Cursors.Hand;
			this.arrowRight.Image = global::ImageHelper.Properties.Resources.ArrowRight;
			this.arrowRight.Location = new System.Drawing.Point( 24, 17 );
			this.arrowRight.Name = "arrowRight";
			this.arrowRight.Size = new System.Drawing.Size( 12, 12 );
			this.arrowRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.arrowRight.TabIndex = 3;
			this.arrowRight.TabStop = false;
			this.arrowRight.Click += new System.EventHandler( this.arrowRight_Click );
			// 
			// arrowLeft
			// 
			this.arrowLeft.Cursor = System.Windows.Forms.Cursors.Hand;
			this.arrowLeft.Image = global::ImageHelper.Properties.Resources.ArrowLeft;
			this.arrowLeft.Location = new System.Drawing.Point( 0, 17 );
			this.arrowLeft.Name = "arrowLeft";
			this.arrowLeft.Size = new System.Drawing.Size( 12, 12 );
			this.arrowLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.arrowLeft.TabIndex = 2;
			this.arrowLeft.TabStop = false;
			this.arrowLeft.Click += new System.EventHandler( this.arrowLeft_Click );
			// 
			// arrowDown
			// 
			this.arrowDown.Cursor = System.Windows.Forms.Cursors.Hand;
			this.arrowDown.Image = global::ImageHelper.Properties.Resources.ArrowDown;
			this.arrowDown.Location = new System.Drawing.Point( 12, 29 );
			this.arrowDown.Name = "arrowDown";
			this.arrowDown.Size = new System.Drawing.Size( 12, 12 );
			this.arrowDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.arrowDown.TabIndex = 1;
			this.arrowDown.TabStop = false;
			this.arrowDown.Click += new System.EventHandler( this.arrowDown_Click );
			// 
			// arrowTop
			// 
			this.arrowTop.Cursor = System.Windows.Forms.Cursors.Hand;
			this.arrowTop.Image = global::ImageHelper.Properties.Resources.ArrowTop;
			this.arrowTop.Location = new System.Drawing.Point( 12, 5 );
			this.arrowTop.Name = "arrowTop";
			this.arrowTop.Size = new System.Drawing.Size( 12, 12 );
			this.arrowTop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.arrowTop.TabIndex = 0;
			this.arrowTop.TabStop = false;
			this.arrowTop.Click += new System.EventHandler( this.arrowTop_Click );
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 44, 4 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 14, 13 );
			this.label1.TabIndex = 4;
			this.label1.Text = "X";
			// 
			// numX
			// 
			this.numX.Location = new System.Drawing.Point( 64, 0 );
			this.numX.Name = "numX";
			this.numX.Size = new System.Drawing.Size( 57, 20 );
			this.numX.TabIndex = 5;
			this.numX.ValueChanged += new System.EventHandler( this.numX_ValueChanged );
			// 
			// numY
			// 
			this.numY.Location = new System.Drawing.Point( 64, 26 );
			this.numY.Name = "numY";
			this.numY.Size = new System.Drawing.Size( 57, 20 );
			this.numY.TabIndex = 7;
			this.numY.ValueChanged += new System.EventHandler( this.numY_ValueChanged );
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 44, 30 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 14, 13 );
			this.label2.TabIndex = 6;
			this.label2.Text = "Y";
			// 
			// ArrowControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add( this.numY );
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.numX );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.arrowRight );
			this.Controls.Add( this.arrowLeft );
			this.Controls.Add( this.arrowDown );
			this.Controls.Add( this.arrowTop );
			this.Name = "ArrowControl";
			this.Size = new System.Drawing.Size( 122, 46 );
			( (System.ComponentModel.ISupportInitialize)( this.arrowRight ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.arrowLeft ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.arrowDown ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.arrowTop ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.numX ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.numY ) ).EndInit();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox arrowTop;
		private System.Windows.Forms.PictureBox arrowDown;
		private System.Windows.Forms.PictureBox arrowLeft;
		private System.Windows.Forms.PictureBox arrowRight;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numX;
		private System.Windows.Forms.NumericUpDown numY;
		private System.Windows.Forms.Label label2;
	}
}
