namespace Sbt {
	partial class frmTimerEdit {
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
			this.label2 = new System.Windows.Forms.Label();
			this.numDay = new System.Windows.Forms.NumericUpDown();
			this.numHour = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.numMin = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.numSec = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancle = new System.Windows.Forms.Button();
			this.cbMode = new System.Windows.Forms.ComboBox();
			( (System.ComponentModel.ISupportInitialize)( this.numDay ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.numHour ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.numMin ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.numSec ) ).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 9, 9 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 267, 13 );
			this.label1.TabIndex = 0;
			this.label1.Text = "Um wieviel soll der Timer reduziert oder erhöht werden?";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 72, 40 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 32, 13 );
			this.label2.TabIndex = 1;
			this.label2.Text = "Tage";
			// 
			// numDay
			// 
			this.numDay.Location = new System.Drawing.Point( 12, 37 );
			this.numDay.Name = "numDay";
			this.numDay.Size = new System.Drawing.Size( 54, 20 );
			this.numDay.TabIndex = 2;
			// 
			// numHour
			// 
			this.numHour.Location = new System.Drawing.Point( 135, 37 );
			this.numHour.Name = "numHour";
			this.numHour.Size = new System.Drawing.Size( 54, 20 );
			this.numHour.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point( 195, 40 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 47, 13 );
			this.label3.TabIndex = 3;
			this.label3.Text = "Stunden";
			// 
			// numMin
			// 
			this.numMin.Location = new System.Drawing.Point( 12, 65 );
			this.numMin.Name = "numMin";
			this.numMin.Size = new System.Drawing.Size( 54, 20 );
			this.numMin.TabIndex = 6;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point( 72, 68 );
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size( 45, 13 );
			this.label4.TabIndex = 5;
			this.label4.Text = "Minuten";
			// 
			// numSec
			// 
			this.numSec.Location = new System.Drawing.Point( 135, 65 );
			this.numSec.Name = "numSec";
			this.numSec.Size = new System.Drawing.Size( 54, 20 );
			this.numSec.TabIndex = 8;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point( 195, 68 );
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size( 56, 13 );
			this.label5.TabIndex = 7;
			this.label5.Text = "Sekunden";
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Location = new System.Drawing.Point( 189, 138 );
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size( 81, 23 );
			this.btnSave.TabIndex = 9;
			this.btnSave.Text = "Übernehmen";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler( this.btnSave_Click );
			// 
			// btnCancle
			// 
			this.btnCancle.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
			this.btnCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancle.Location = new System.Drawing.Point( 12, 138 );
			this.btnCancle.Name = "btnCancle";
			this.btnCancle.Size = new System.Drawing.Size( 75, 23 );
			this.btnCancle.TabIndex = 12;
			this.btnCancle.Text = "Abbrechen";
			this.btnCancle.UseVisualStyleBackColor = true;
			this.btnCancle.Click += new System.EventHandler( this.btnCancle_Click );
			// 
			// cbMode
			// 
			this.cbMode.FormattingEnabled = true;
			this.cbMode.Items.AddRange( new object[] {
            "Reduzieren",
            "Erhöhen"} );
			this.cbMode.Location = new System.Drawing.Point( 12, 101 );
			this.cbMode.Name = "cbMode";
			this.cbMode.Size = new System.Drawing.Size( 121, 21 );
			this.cbMode.TabIndex = 13;
			// 
			// frmTimerEdit
			// 
			this.AcceptButton = this.btnSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancle;
			this.ClientSize = new System.Drawing.Size( 282, 173 );
			this.Controls.Add( this.cbMode );
			this.Controls.Add( this.btnCancle );
			this.Controls.Add( this.btnSave );
			this.Controls.Add( this.numSec );
			this.Controls.Add( this.label5 );
			this.Controls.Add( this.numMin );
			this.Controls.Add( this.label4 );
			this.Controls.Add( this.numHour );
			this.Controls.Add( this.label3 );
			this.Controls.Add( this.numDay );
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.label1 );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmTimerEdit";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Timer bearbeiten";
			( (System.ComponentModel.ISupportInitialize)( this.numDay ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.numHour ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.numMin ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.numSec ) ).EndInit();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancle;
		public System.Windows.Forms.NumericUpDown numDay;
		public System.Windows.Forms.NumericUpDown numHour;
		public System.Windows.Forms.NumericUpDown numMin;
		public System.Windows.Forms.NumericUpDown numSec;
		public System.Windows.Forms.ComboBox cbMode;
	}
}