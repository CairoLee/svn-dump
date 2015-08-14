namespace eACGUI {
	partial class AboutBox {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( AboutBox ) );
			this.labelCopyright = new DevComponents.DotNetBar.LabelX();
			this.labelProductName = new DevComponents.DotNetBar.LabelX();
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.logoPictureBox = new System.Windows.Forms.PictureBox();
			this.textBoxDescription = new DevComponents.DotNetBar.Controls.TextBoxX();
			this.okButton = new DevComponents.DotNetBar.ButtonX();
			this.tableLayoutPanel.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize)( this.logoPictureBox ) ).BeginInit();
			this.SuspendLayout();
			// 
			// labelCopyright
			// 
			this.labelCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelCopyright.Location = new System.Drawing.Point( 163, 22 );
			this.labelCopyright.Margin = new System.Windows.Forms.Padding( 6, 0, 3, 0 );
			this.labelCopyright.MaximumSize = new System.Drawing.Size( 0, 17 );
			this.labelCopyright.Name = "labelCopyright";
			this.labelCopyright.Size = new System.Drawing.Size( 251, 17 );
			this.labelCopyright.TabIndex = 0;
			this.labelCopyright.Text = "Copyright";
			// 
			// labelProductName
			// 
			this.labelProductName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelProductName.Location = new System.Drawing.Point( 163, 0 );
			this.labelProductName.Margin = new System.Windows.Forms.Padding( 6, 0, 3, 0 );
			this.labelProductName.MaximumSize = new System.Drawing.Size( 0, 17 );
			this.labelProductName.Name = "labelProductName";
			this.labelProductName.Size = new System.Drawing.Size( 251, 17 );
			this.labelProductName.TabIndex = 19;
			this.labelProductName.Text = "Product Name";
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.ColumnCount = 2;
			this.tableLayoutPanel.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 37.88969F ) );
			this.tableLayoutPanel.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 62.11031F ) );
			this.tableLayoutPanel.Controls.Add( this.logoPictureBox, 0, 0 );
			this.tableLayoutPanel.Controls.Add( this.labelProductName, 1, 0 );
			this.tableLayoutPanel.Controls.Add( this.labelCopyright, 1, 1 );
			this.tableLayoutPanel.Controls.Add( this.textBoxDescription, 1, 2 );
			this.tableLayoutPanel.Controls.Add( this.okButton, 1, 3 );
			this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel.Location = new System.Drawing.Point( 9, 9 );
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 4;
			this.tableLayoutPanel.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 10F ) );
			this.tableLayoutPanel.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 10.9434F ) );
			this.tableLayoutPanel.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 68.33334F ) );
			this.tableLayoutPanel.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 11.25F ) );
			this.tableLayoutPanel.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Absolute, 20F ) );
			this.tableLayoutPanel.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Absolute, 20F ) );
			this.tableLayoutPanel.Size = new System.Drawing.Size( 417, 231 );
			this.tableLayoutPanel.TabIndex = 0;
			// 
			// logoPictureBox
			// 
			this.logoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.logoPictureBox.Image = global::eACGUI.Properties.Resources.About;
			this.logoPictureBox.Location = new System.Drawing.Point( 3, 3 );
			this.logoPictureBox.Name = "logoPictureBox";
			this.tableLayoutPanel.SetRowSpan( this.logoPictureBox, 4 );
			this.logoPictureBox.Size = new System.Drawing.Size( 151, 225 );
			this.logoPictureBox.TabIndex = 12;
			this.logoPictureBox.TabStop = false;
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxDescription.Location = new System.Drawing.Point( 163, 50 );
			this.textBoxDescription.Margin = new System.Windows.Forms.Padding( 6, 3, 3, 3 );
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.ReadOnly = true;
			this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxDescription.Size = new System.Drawing.Size( 251, 151 );
			this.textBoxDescription.TabIndex = 23;
			this.textBoxDescription.TabStop = false;
			this.textBoxDescription.Text = "long Description";
			// 
			// okButton
			// 
			this.okButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.okButton.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.okButton.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.okButton.FocusCuesEnabled = false;
			this.okButton.Location = new System.Drawing.Point( 339, 207 );
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size( 75, 21 );
			this.okButton.TabIndex = 24;
			this.okButton.Text = "&OK";
			this.okButton.Click += new System.EventHandler( this.okButton_Click );
			// 
			// AboutBox
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 435, 249 );
			this.Controls.Add( this.tableLayoutPanel );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutBox";
			this.Padding = new System.Windows.Forms.Padding( 9 );
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "AboutBox1";
			this.tableLayoutPanel.ResumeLayout( false );
			( (System.ComponentModel.ISupportInitialize)( this.logoPictureBox ) ).EndInit();
			this.ResumeLayout( false );

		}

		#endregion

		private DevComponents.DotNetBar.LabelX labelCopyright;
		private DevComponents.DotNetBar.LabelX labelProductName;
		private System.Windows.Forms.PictureBox logoPictureBox;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private DevComponents.DotNetBar.Controls.TextBoxX textBoxDescription;
		private DevComponents.DotNetBar.ButtonX okButton;

	}
}
