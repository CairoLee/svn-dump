namespace CaptchaKillerTest {
	partial class frmMain {
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent() {
			this.imgBefore = new System.Windows.Forms.PictureBox();
			this.lblResult = new System.Windows.Forms.Label();
			this.imgAfter = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.numericRemoveBorder = new System.Windows.Forms.NumericUpDown();
			this.btnProcess = new System.Windows.Forms.Button();
			this.numericNoiseKill = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.chkBlur = new System.Windows.Forms.CheckBox();
			this.chkInvertColors = new System.Windows.Forms.CheckBox();
			this.chkLinarizeColors = new System.Windows.Forms.CheckBox();
			this.numericBrightness = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.imgBefore)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imgAfter)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericRemoveBorder)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericNoiseKill)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericBrightness)).BeginInit();
			this.SuspendLayout();
			// 
			// imgBefore
			// 
			this.imgBefore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.imgBefore.Location = new System.Drawing.Point(12, 51);
			this.imgBefore.Name = "imgBefore";
			this.imgBefore.Size = new System.Drawing.Size(255, 255);
			this.imgBefore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.imgBefore.TabIndex = 0;
			this.imgBefore.TabStop = false;
			this.imgBefore.Click += new System.EventHandler(this.imgBefore_Click);
			// 
			// lblResult
			// 
			this.lblResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lblResult.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblResult.Location = new System.Drawing.Point(273, 51);
			this.lblResult.Name = "lblResult";
			this.lblResult.Size = new System.Drawing.Size(130, 32);
			this.lblResult.TabIndex = 1;
			this.lblResult.Text = "Result";
			this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// imgAfter
			// 
			this.imgAfter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.imgAfter.Location = new System.Drawing.Point(409, 51);
			this.imgAfter.Name = "imgAfter";
			this.imgAfter.Size = new System.Drawing.Size(255, 255);
			this.imgAfter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.imgAfter.TabIndex = 2;
			this.imgAfter.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(276, 122);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Border";
			// 
			// numericRemoveBorder
			// 
			this.numericRemoveBorder.Location = new System.Drawing.Point(336, 120);
			this.numericRemoveBorder.Name = "numericRemoveBorder";
			this.numericRemoveBorder.Size = new System.Drawing.Size(52, 20);
			this.numericRemoveBorder.TabIndex = 4;
			this.numericRemoveBorder.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			// 
			// btnProcess
			// 
			this.btnProcess.Location = new System.Drawing.Point(273, 283);
			this.btnProcess.Name = "btnProcess";
			this.btnProcess.Size = new System.Drawing.Size(127, 23);
			this.btnProcess.TabIndex = 5;
			this.btnProcess.Text = "Process";
			this.btnProcess.UseVisualStyleBackColor = true;
			this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
			// 
			// numericNoiseKill
			// 
			this.numericNoiseKill.Location = new System.Drawing.Point(336, 147);
			this.numericNoiseKill.Name = "numericNoiseKill";
			this.numericNoiseKill.Size = new System.Drawing.Size(52, 20);
			this.numericNoiseKill.TabIndex = 7;
			this.numericNoiseKill.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(276, 149);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Noise kill";
			// 
			// chkBlur
			// 
			this.chkBlur.AutoSize = true;
			this.chkBlur.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkBlur.Checked = true;
			this.chkBlur.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkBlur.Location = new System.Drawing.Point(279, 200);
			this.chkBlur.Name = "chkBlur";
			this.chkBlur.Size = new System.Drawing.Size(44, 17);
			this.chkBlur.TabIndex = 8;
			this.chkBlur.Text = "Blur";
			this.chkBlur.UseVisualStyleBackColor = true;
			// 
			// chkInvertColors
			// 
			this.chkInvertColors.AutoSize = true;
			this.chkInvertColors.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkInvertColors.Location = new System.Drawing.Point(279, 223);
			this.chkInvertColors.Name = "chkInvertColors";
			this.chkInvertColors.Size = new System.Drawing.Size(85, 17);
			this.chkInvertColors.TabIndex = 9;
			this.chkInvertColors.Text = "Invert Colors";
			this.chkInvertColors.UseVisualStyleBackColor = true;
			// 
			// chkLinarizeColors
			// 
			this.chkLinarizeColors.AutoSize = true;
			this.chkLinarizeColors.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkLinarizeColors.Location = new System.Drawing.Point(279, 246);
			this.chkLinarizeColors.Name = "chkLinarizeColors";
			this.chkLinarizeColors.Size = new System.Drawing.Size(94, 17);
			this.chkLinarizeColors.TabIndex = 11;
			this.chkLinarizeColors.Text = "Linarize Colors";
			this.chkLinarizeColors.UseVisualStyleBackColor = true;
			// 
			// numericBrightness
			// 
			this.numericBrightness.Location = new System.Drawing.Point(336, 173);
			this.numericBrightness.Name = "numericBrightness";
			this.numericBrightness.Size = new System.Drawing.Size(52, 20);
			this.numericBrightness.TabIndex = 13;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(276, 175);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 13);
			this.label3.TabIndex = 12;
			this.label3.Text = "Brightness";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label4.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(75, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(130, 32);
			this.label4.TabIndex = 14;
			this.label4.Text = "Input";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label5.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(471, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(130, 32);
			this.label5.TabIndex = 15;
			this.label5.Text = "Output";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(681, 318);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.numericBrightness);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.chkLinarizeColors);
			this.Controls.Add(this.chkInvertColors);
			this.Controls.Add(this.chkBlur);
			this.Controls.Add(this.numericNoiseKill);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnProcess);
			this.Controls.Add(this.numericRemoveBorder);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.imgAfter);
			this.Controls.Add(this.lblResult);
			this.Controls.Add(this.imgBefore);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Name = "frmMain";
			this.Text = "Captcha OCR Test";
			this.Load += new System.EventHandler(this.frmMain_Load);
			((System.ComponentModel.ISupportInitialize)(this.imgBefore)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imgAfter)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericRemoveBorder)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericNoiseKill)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericBrightness)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox imgBefore;
		private System.Windows.Forms.Label lblResult;
		private System.Windows.Forms.PictureBox imgAfter;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numericRemoveBorder;
		private System.Windows.Forms.Button btnProcess;
		private System.Windows.Forms.NumericUpDown numericNoiseKill;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox chkBlur;
		private System.Windows.Forms.CheckBox chkInvertColors;
		private System.Windows.Forms.CheckBox chkLinarizeColors;
		private System.Windows.Forms.NumericUpDown numericBrightness;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
	}
}

