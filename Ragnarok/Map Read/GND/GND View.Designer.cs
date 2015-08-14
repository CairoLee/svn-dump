namespace MapRead.GND {
	partial class GNDViewer {
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

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent() {
			this.button1 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.lblData = new System.Windows.Forms.Label();
			this.btnPlus = new System.Windows.Forms.Button();
			this.btnMinus = new System.Windows.Forms.Button();
			( (System.ComponentModel.ISupportInitialize)( this.pictureBox1 ) ).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.button1.Location = new System.Drawing.Point( 614, 13 );
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size( 75, 20 );
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler( this.button1_Click );
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.textBox1.Location = new System.Drawing.Point( 13, 13 );
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size( 595, 20 );
			this.textBox1.TabIndex = 1;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point( 13, 117 );
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size( 676, 444 );
			this.pictureBox1.TabIndex = 3;
			this.pictureBox1.TabStop = false;
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.textBox2.Location = new System.Drawing.Point( 13, 39 );
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size( 595, 20 );
			this.textBox2.TabIndex = 5;
			// 
			// button2
			// 
			this.button2.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.button2.Location = new System.Drawing.Point( 614, 39 );
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size( 75, 20 );
			this.button2.TabIndex = 4;
			this.button2.Text = "button2";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler( this.button2_Click );
			// 
			// lblData
			// 
			this.lblData.AutoSize = true;
			this.lblData.Location = new System.Drawing.Point( 13, 66 );
			this.lblData.Name = "lblData";
			this.lblData.Size = new System.Drawing.Size( 53, 13 );
			this.lblData.TabIndex = 6;
			this.lblData.Text = "Datei Info";
			// 
			// btnPlus
			// 
			this.btnPlus.Location = new System.Drawing.Point( 664, 65 );
			this.btnPlus.Name = "btnPlus";
			this.btnPlus.Size = new System.Drawing.Size( 25, 23 );
			this.btnPlus.TabIndex = 7;
			this.btnPlus.Text = "+";
			this.btnPlus.UseVisualStyleBackColor = true;
			this.btnPlus.Click += new System.EventHandler( this.btnPlus_Click );
			// 
			// btnMinus
			// 
			this.btnMinus.Location = new System.Drawing.Point( 614, 65 );
			this.btnMinus.Name = "btnMinus";
			this.btnMinus.Size = new System.Drawing.Size( 25, 23 );
			this.btnMinus.TabIndex = 8;
			this.btnMinus.Text = "-";
			this.btnMinus.UseVisualStyleBackColor = true;
			this.btnMinus.Click += new System.EventHandler( this.btnMinus_Click );
			// 
			// GNDViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 702, 573 );
			this.Controls.Add( this.btnMinus );
			this.Controls.Add( this.btnPlus );
			this.Controls.Add( this.lblData );
			this.Controls.Add( this.textBox2 );
			this.Controls.Add( this.button2 );
			this.Controls.Add( this.pictureBox1 );
			this.Controls.Add( this.textBox1 );
			this.Controls.Add( this.button1 );
			this.Name = "GNDViewer";
			this.Text = "Form1";
			( (System.ComponentModel.ISupportInitialize)( this.pictureBox1 ) ).EndInit();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label lblData;
		private System.Windows.Forms.Button btnPlus;
		private System.Windows.Forms.Button btnMinus;
	}
}

