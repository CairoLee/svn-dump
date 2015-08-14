namespace Healbot {
	partial class frmHealsettings {
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
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.numHeal7 = new System.Windows.Forms.NumericUpDown();
			this.numHeal6 = new System.Windows.Forms.NumericUpDown();
			this.numHeal5 = new System.Windows.Forms.NumericUpDown();
			this.numHeal4 = new System.Windows.Forms.NumericUpDown();
			this.numHeal3 = new System.Windows.Forms.NumericUpDown();
			this.numHeal2 = new System.Windows.Forms.NumericUpDown();
			this.numHeal1 = new System.Windows.Forms.NumericUpDown();
			( (System.ComponentModel.ISupportInitialize)( this.numHeal7 ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.numHeal6 ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.numHeal5 ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.numHeal4 ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.numHeal3 ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.numHeal2 ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.numHeal1 ) ).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 13, 13 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 245, 39 );
			this.label1.TabIndex = 0;
			this.label1.Text = "Heal wird ab dem eingestelltem Wert und darunter \r\nausgeführt.\r\nDie Werte sind in" +
				" Prozent!";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 16, 76 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 45, 13 );
			this.label2.TabIndex = 1;
			this.label2.Text = "Player 1";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point( 16, 102 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 45, 13 );
			this.label3.TabIndex = 3;
			this.label3.Text = "Player 2";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point( 16, 128 );
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size( 45, 13 );
			this.label4.TabIndex = 5;
			this.label4.Text = "Player 3";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point( 16, 154 );
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size( 45, 13 );
			this.label5.TabIndex = 7;
			this.label5.Text = "Player 4";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point( 138, 76 );
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size( 45, 13 );
			this.label6.TabIndex = 9;
			this.label6.Text = "Player 5";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point( 138, 102 );
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size( 45, 13 );
			this.label7.TabIndex = 11;
			this.label7.Text = "Player 6";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point( 138, 128 );
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size( 45, 13 );
			this.label8.TabIndex = 13;
			this.label8.Text = "Player 7";
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Location = new System.Drawing.Point( 178, 187 );
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size( 75, 23 );
			this.btnSave.TabIndex = 15;
			this.btnSave.Text = "Speichern";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler( this.btnSave_Click );
			// 
			// numHeal7
			// 
			this.numHeal7.DataBindings.Add( new System.Windows.Forms.Binding( "Value", global::Healbot.Properties.Settings.Default, "HealPlayer7", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged ) );
			this.numHeal7.Location = new System.Drawing.Point( 189, 126 );
			this.numHeal7.Maximum = new decimal( new int[] {
            99,
            0,
            0,
            0} );
			this.numHeal7.Minimum = new decimal( new int[] {
            1,
            0,
            0,
            0} );
			this.numHeal7.Name = "numHeal7";
			this.numHeal7.Size = new System.Drawing.Size( 46, 20 );
			this.numHeal7.TabIndex = 14;
			this.numHeal7.Value = global::Healbot.Properties.Settings.Default.HealPlayer7;
			// 
			// numHeal6
			// 
			this.numHeal6.DataBindings.Add( new System.Windows.Forms.Binding( "Value", global::Healbot.Properties.Settings.Default, "HealPlayer6", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged ) );
			this.numHeal6.Location = new System.Drawing.Point( 189, 100 );
			this.numHeal6.Maximum = new decimal( new int[] {
            99,
            0,
            0,
            0} );
			this.numHeal6.Minimum = new decimal( new int[] {
            1,
            0,
            0,
            0} );
			this.numHeal6.Name = "numHeal6";
			this.numHeal6.Size = new System.Drawing.Size( 46, 20 );
			this.numHeal6.TabIndex = 12;
			this.numHeal6.Value = global::Healbot.Properties.Settings.Default.HealPlayer6;
			// 
			// numHeal5
			// 
			this.numHeal5.DataBindings.Add( new System.Windows.Forms.Binding( "Value", global::Healbot.Properties.Settings.Default, "HealPlayer5", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged ) );
			this.numHeal5.Location = new System.Drawing.Point( 189, 74 );
			this.numHeal5.Maximum = new decimal( new int[] {
            99,
            0,
            0,
            0} );
			this.numHeal5.Minimum = new decimal( new int[] {
            1,
            0,
            0,
            0} );
			this.numHeal5.Name = "numHeal5";
			this.numHeal5.Size = new System.Drawing.Size( 46, 20 );
			this.numHeal5.TabIndex = 10;
			this.numHeal5.Value = global::Healbot.Properties.Settings.Default.HealPlayer5;
			// 
			// numHeal4
			// 
			this.numHeal4.DataBindings.Add( new System.Windows.Forms.Binding( "Value", global::Healbot.Properties.Settings.Default, "HealPlayer4", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged ) );
			this.numHeal4.Location = new System.Drawing.Point( 67, 152 );
			this.numHeal4.Maximum = new decimal( new int[] {
            99,
            0,
            0,
            0} );
			this.numHeal4.Minimum = new decimal( new int[] {
            1,
            0,
            0,
            0} );
			this.numHeal4.Name = "numHeal4";
			this.numHeal4.Size = new System.Drawing.Size( 46, 20 );
			this.numHeal4.TabIndex = 8;
			this.numHeal4.Value = global::Healbot.Properties.Settings.Default.HealPlayer4;
			// 
			// numHeal3
			// 
			this.numHeal3.DataBindings.Add( new System.Windows.Forms.Binding( "Value", global::Healbot.Properties.Settings.Default, "HealPlayer3", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged ) );
			this.numHeal3.Location = new System.Drawing.Point( 67, 126 );
			this.numHeal3.Maximum = new decimal( new int[] {
            99,
            0,
            0,
            0} );
			this.numHeal3.Minimum = new decimal( new int[] {
            1,
            0,
            0,
            0} );
			this.numHeal3.Name = "numHeal3";
			this.numHeal3.Size = new System.Drawing.Size( 46, 20 );
			this.numHeal3.TabIndex = 6;
			this.numHeal3.Value = global::Healbot.Properties.Settings.Default.HealPlayer3;
			// 
			// numHeal2
			// 
			this.numHeal2.DataBindings.Add( new System.Windows.Forms.Binding( "Value", global::Healbot.Properties.Settings.Default, "HealPlayer2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged ) );
			this.numHeal2.Location = new System.Drawing.Point( 67, 100 );
			this.numHeal2.Maximum = new decimal( new int[] {
            99,
            0,
            0,
            0} );
			this.numHeal2.Minimum = new decimal( new int[] {
            1,
            0,
            0,
            0} );
			this.numHeal2.Name = "numHeal2";
			this.numHeal2.Size = new System.Drawing.Size( 46, 20 );
			this.numHeal2.TabIndex = 4;
			this.numHeal2.Value = global::Healbot.Properties.Settings.Default.HealPlayer2;
			// 
			// numHeal1
			// 
			this.numHeal1.DataBindings.Add( new System.Windows.Forms.Binding( "Value", global::Healbot.Properties.Settings.Default, "HealPlayer1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged ) );
			this.numHeal1.Location = new System.Drawing.Point( 67, 74 );
			this.numHeal1.Maximum = new decimal( new int[] {
            99,
            0,
            0,
            0} );
			this.numHeal1.Minimum = new decimal( new int[] {
            1,
            0,
            0,
            0} );
			this.numHeal1.Name = "numHeal1";
			this.numHeal1.Size = new System.Drawing.Size( 46, 20 );
			this.numHeal1.TabIndex = 2;
			this.numHeal1.Value = global::Healbot.Properties.Settings.Default.HealPlayer1;
			// 
			// frmHealsettings
			// 
			this.AcceptButton = this.btnSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 265, 222 );
			this.Controls.Add( this.btnSave );
			this.Controls.Add( this.numHeal7 );
			this.Controls.Add( this.label8 );
			this.Controls.Add( this.numHeal6 );
			this.Controls.Add( this.label7 );
			this.Controls.Add( this.numHeal5 );
			this.Controls.Add( this.label6 );
			this.Controls.Add( this.numHeal4 );
			this.Controls.Add( this.label5 );
			this.Controls.Add( this.numHeal3 );
			this.Controls.Add( this.label4 );
			this.Controls.Add( this.numHeal2 );
			this.Controls.Add( this.label3 );
			this.Controls.Add( this.numHeal1 );
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.label1 );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmHealsettings";
			this.Text = "Healwerte";
			( (System.ComponentModel.ISupportInitialize)( this.numHeal7 ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.numHeal6 ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.numHeal5 ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.numHeal4 ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.numHeal3 ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.numHeal2 ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.numHeal1 ) ).EndInit();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button btnSave;
		public System.Windows.Forms.NumericUpDown numHeal1;
		public System.Windows.Forms.NumericUpDown numHeal2;
		public System.Windows.Forms.NumericUpDown numHeal3;
		public System.Windows.Forms.NumericUpDown numHeal4;
		public System.Windows.Forms.NumericUpDown numHeal5;
		public System.Windows.Forms.NumericUpDown numHeal6;
		public System.Windows.Forms.NumericUpDown numHeal7;
	}
}