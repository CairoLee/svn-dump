namespace Sprite_Reader {
	partial class Form1 {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Form1 ) );
			this.inputFilePath = new System.Windows.Forms.TextBox();
			this.btnSearch = new System.Windows.Forms.Button();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.btnImagePrev = new System.Windows.Forms.Button();
			this.btnImageNext = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			( (System.ComponentModel.ISupportInitialize)( this.pictureBox1 ) ).BeginInit();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// inputFilePath
			// 
			this.inputFilePath.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.inputFilePath.Location = new System.Drawing.Point( 10, 14 );
			this.inputFilePath.Name = "inputFilePath";
			this.inputFilePath.Size = new System.Drawing.Size( 279, 20 );
			this.inputFilePath.TabIndex = 0;
			// 
			// btnSearch
			// 
			this.btnSearch.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnSearch.Location = new System.Drawing.Point( 304, 15 );
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size( 103, 19 );
			this.btnSearch.TabIndex = 1;
			this.btnSearch.Text = "Dursuchen";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler( this.btnSearch_Click );
			// 
			// richTextBox1
			// 
			this.richTextBox1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.richTextBox1.Location = new System.Drawing.Point( 10, 39 );
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size( 397, 91 );
			this.richTextBox1.TabIndex = 2;
			this.richTextBox1.Text = "";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.pictureBox1.Location = new System.Drawing.Point( 10, 137 );
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size( 397, 244 );
			this.pictureBox1.TabIndex = 3;
			this.pictureBox1.TabStop = false;
			// 
			// btnImagePrev
			// 
			this.btnImagePrev.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnImagePrev.Location = new System.Drawing.Point( 141, 387 );
			this.btnImagePrev.Name = "btnImagePrev";
			this.btnImagePrev.Size = new System.Drawing.Size( 41, 23 );
			this.btnImagePrev.TabIndex = 4;
			this.btnImagePrev.Text = "<<";
			this.btnImagePrev.UseVisualStyleBackColor = true;
			this.btnImagePrev.Click += new System.EventHandler( this.btnImagePrev_Click );
			// 
			// btnImageNext
			// 
			this.btnImageNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnImageNext.Location = new System.Drawing.Point( 236, 387 );
			this.btnImageNext.Name = "btnImageNext";
			this.btnImageNext.Size = new System.Drawing.Size( 39, 23 );
			this.btnImageNext.TabIndex = 5;
			this.btnImageNext.Text = ">>";
			this.btnImageNext.UseVisualStyleBackColor = true;
			this.btnImageNext.Click += new System.EventHandler( this.btnImageNext_Click );
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel} );
			this.statusStrip1.Location = new System.Drawing.Point( 0, 428 );
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size( 419, 22 );
			this.statusStrip1.TabIndex = 6;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// StatusLabel
			// 
			this.StatusLabel.AutoSize = false;
			this.StatusLabel.Margin = new System.Windows.Forms.Padding( 0, 3, 0, 1 );
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new System.Drawing.Size( 400, 18 );
			this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 419, 450 );
			this.Controls.Add( this.statusStrip1 );
			this.Controls.Add( this.btnImageNext );
			this.Controls.Add( this.btnImagePrev );
			this.Controls.Add( this.pictureBox1 );
			this.Controls.Add( this.richTextBox1 );
			this.Controls.Add( this.btnSearch );
			this.Controls.Add( this.inputFilePath );
			this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
			this.Name = "Form1";
			this.Text = "Sprite Reader";
			( (System.ComponentModel.ISupportInitialize)( this.pictureBox1 ) ).EndInit();
			this.statusStrip1.ResumeLayout( false );
			this.statusStrip1.PerformLayout();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox inputFilePath;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button btnImagePrev;
		private System.Windows.Forms.Button btnImageNext;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
	}
}

