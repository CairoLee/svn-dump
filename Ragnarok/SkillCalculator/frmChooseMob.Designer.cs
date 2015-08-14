namespace GodLesZ.Ragnarok.SkillCalculator {
	partial class frmChooseMob {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.pnlMobs = new System.Windows.Forms.Panel();
			this.btnSelect = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// pnlMobs
			// 
			this.pnlMobs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlMobs.AutoScroll = true;
			this.pnlMobs.Location = new System.Drawing.Point(12, 12);
			this.pnlMobs.Name = "pnlMobs";
			this.pnlMobs.Size = new System.Drawing.Size(682, 380);
			this.pnlMobs.TabIndex = 0;
			// 
			// btnSelect
			// 
			this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSelect.Enabled = false;
			this.btnSelect.Location = new System.Drawing.Point(619, 417);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(75, 23);
			this.btnSelect.TabIndex = 1;
			this.btnSelect.Text = "Select";
			this.btnSelect.UseVisualStyleBackColor = true;
			this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
			// 
			// frmChooseMob
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(706, 452);
			this.Controls.Add(this.btnSelect);
			this.Controls.Add(this.pnlMobs);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MaximumSize = new System.Drawing.Size(722, 486);
			this.Name = "frmChooseMob";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Choose a mob";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlMobs;
		private System.Windows.Forms.Button btnSelect;
	}
}