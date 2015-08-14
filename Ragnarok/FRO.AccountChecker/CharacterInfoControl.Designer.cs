namespace FRO.AccountChecker {
	partial class CharacterInfoControl {
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

		#region Vom Komponenten-Designer generierter Code

		/// <summary> 
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent() {
			this.lblName = new System.Windows.Forms.Label();
			this.lblLevel = new System.Windows.Forms.Label();
			this.lblJob = new System.Windows.Forms.Label();
			this.imgAvatar = new System.Windows.Forms.PictureBox();
			this.lblZeny = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.imgAvatar)).BeginInit();
			this.SuspendLayout();
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(43, 1);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(35, 13);
			this.lblName.TabIndex = 0;
			this.lblName.Text = "Name";
			// 
			// lblLevel
			// 
			this.lblLevel.AutoSize = true;
			this.lblLevel.Location = new System.Drawing.Point(43, 27);
			this.lblLevel.Name = "lblLevel";
			this.lblLevel.Size = new System.Drawing.Size(39, 13);
			this.lblLevel.TabIndex = 1;
			this.lblLevel.Text = "Level: ";
			// 
			// lblJob
			// 
			this.lblJob.AutoSize = true;
			this.lblJob.Location = new System.Drawing.Point(43, 14);
			this.lblJob.Name = "lblJob";
			this.lblJob.Size = new System.Drawing.Size(30, 13);
			this.lblJob.TabIndex = 2;
			this.lblJob.Text = "Job: ";
			// 
			// imgAvatar
			// 
			this.imgAvatar.Location = new System.Drawing.Point(0, 0);
			this.imgAvatar.Name = "imgAvatar";
			this.imgAvatar.Size = new System.Drawing.Size(42, 53);
			this.imgAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.imgAvatar.TabIndex = 3;
			this.imgAvatar.TabStop = false;
			// 
			// lblZeny
			// 
			this.lblZeny.AutoSize = true;
			this.lblZeny.Location = new System.Drawing.Point(43, 40);
			this.lblZeny.Name = "lblZeny";
			this.lblZeny.Size = new System.Drawing.Size(37, 13);
			this.lblZeny.TabIndex = 4;
			this.lblZeny.Text = "Zeny: ";
			// 
			// CharacterInfoControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.lblZeny);
			this.Controls.Add(this.imgAvatar);
			this.Controls.Add(this.lblJob);
			this.Controls.Add(this.lblLevel);
			this.Controls.Add(this.lblName);
			this.Name = "CharacterInfoControl";
			this.Size = new System.Drawing.Size(170, 54);
			((System.ComponentModel.ISupportInitialize)(this.imgAvatar)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Label lblLevel;
		private System.Windows.Forms.Label lblJob;
		private System.Windows.Forms.PictureBox imgAvatar;
		private System.Windows.Forms.Label lblZeny;
	}
}
