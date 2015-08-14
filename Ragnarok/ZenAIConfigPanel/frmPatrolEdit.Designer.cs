namespace ZenAIConfigPanel {
	partial class frmPatrolEdit {
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
			this.pnlStepContainer = new System.Windows.Forms.Panel();
			this.panel72 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.panel73 = new System.Windows.Forms.Panel();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnDefault = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// pnlStepContainer
			// 
			this.pnlStepContainer.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.pnlStepContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlStepContainer.Location = new System.Drawing.Point(13, 13);
			this.pnlStepContainer.Name = "pnlStepContainer";
			this.pnlStepContainer.Size = new System.Drawing.Size(286, 286);
			this.pnlStepContainer.TabIndex = 0;
			// 
			// panel72
			// 
			this.panel72.BackColor = System.Drawing.Color.SteelBlue;
			this.panel72.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel72.Location = new System.Drawing.Point(13, 305);
			this.panel72.Name = "panel72";
			this.panel72.Size = new System.Drawing.Size(20, 20);
			this.panel72.TabIndex = 169;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(36, 309);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 13);
			this.label1.TabIndex = 170;
			this.label1.Text = "Alchemist";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(36, 335);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(91, 13);
			this.label2.TabIndex = 172;
			this.label2.Text = "Homunculus Step";
			// 
			// panel73
			// 
			this.panel73.BackColor = System.Drawing.Color.LightSkyBlue;
			this.panel73.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel73.Location = new System.Drawing.Point(13, 331);
			this.panel73.Name = "panel73";
			this.panel73.Size = new System.Drawing.Size(20, 20);
			this.panel73.TabIndex = 171;
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Location = new System.Drawing.Point(225, 373);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 173;
			this.btnSave.Text = "Speichern";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnDefault
			// 
			this.btnDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnDefault.Location = new System.Drawing.Point(12, 373);
			this.btnDefault.Name = "btnDefault";
			this.btnDefault.Size = new System.Drawing.Size(75, 23);
			this.btnDefault.TabIndex = 174;
			this.btnDefault.Text = "Standart";
			this.btnDefault.UseVisualStyleBackColor = true;
			this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
			// 
			// frmPatrolEdit
			// 
			this.AcceptButton = this.btnSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(312, 408);
			this.Controls.Add(this.btnDefault);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.panel73);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.panel72);
			this.Controls.Add(this.pnlStepContainer);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmPatrolEdit";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Bewegung um den Alchemist";
			this.Shown += new System.EventHandler(this.frmPatrolEdit_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel pnlStepContainer;
		private System.Windows.Forms.Panel panel72;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel73;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnDefault;
	}
}