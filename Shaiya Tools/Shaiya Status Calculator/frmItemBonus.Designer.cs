namespace Ssc {
	partial class frmItemBonus {
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
			this.btnCancle = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnAddBonus = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.numSockel = new System.Windows.Forms.NumericUpDown();
			( (System.ComponentModel.ISupportInitialize)( this.numSockel ) ).BeginInit();
			this.SuspendLayout();
			// 
			// btnCancle
			// 
			this.btnCancle.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
			this.btnCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancle.Location = new System.Drawing.Point( 12, 141 );
			this.btnCancle.Name = "btnCancle";
			this.btnCancle.Size = new System.Drawing.Size( 75, 23 );
			this.btnCancle.TabIndex = 4;
			this.btnCancle.Text = "Abbrechen";
			this.btnCancle.UseVisualStyleBackColor = true;
			this.btnCancle.Click += new System.EventHandler( this.Button_Click );
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Location = new System.Drawing.Point( 198, 141 );
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size( 75, 23 );
			this.btnSave.TabIndex = 5;
			this.btnSave.Text = "Speichern";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler( this.Button_Click );
			// 
			// btnAddBonus
			// 
			this.btnAddBonus.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnAddBonus.Location = new System.Drawing.Point( 12, 35 );
			this.btnAddBonus.Name = "btnAddBonus";
			this.btnAddBonus.Size = new System.Drawing.Size( 261, 23 );
			this.btnAddBonus.TabIndex = 6;
			this.btnAddBonus.Text = "Bonus hinzufügen";
			this.btnAddBonus.UseVisualStyleBackColor = true;
			this.btnAddBonus.Click += new System.EventHandler( this.btnAddBonus_Click );
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 12, 9 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 58, 13 );
			this.label1.TabIndex = 7;
			this.label1.Text = "Item Name";
			// 
			// txtName
			// 
			this.txtName.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtName.Location = new System.Drawing.Point( 82, 6 );
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size( 82, 20 );
			this.txtName.TabIndex = 8;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 170, 9 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 40, 13 );
			this.label2.TabIndex = 9;
			this.label2.Text = "Sockel";
			// 
			// numSockel
			// 
			this.numSockel.Location = new System.Drawing.Point( 229, 7 );
			this.numSockel.Maximum = new decimal( new int[] {
            5,
            0,
            0,
            0} );
			this.numSockel.Name = "numSockel";
			this.numSockel.Size = new System.Drawing.Size( 46, 20 );
			this.numSockel.TabIndex = 10;
			// 
			// frmItemBonus
			// 
			this.AcceptButton = this.btnSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancle;
			this.ClientSize = new System.Drawing.Size( 285, 176 );
			this.Controls.Add( this.numSockel );
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.txtName );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.btnAddBonus );
			this.Controls.Add( this.btnSave );
			this.Controls.Add( this.btnCancle );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmItemBonus";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Item bearbeiten: ";
			this.Load += new System.EventHandler( this.frmItemBonus_Load );
			( (System.ComponentModel.ISupportInitialize)( this.numSockel ) ).EndInit();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnCancle;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnAddBonus;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.NumericUpDown numSockel;
	}
}