namespace GodLesZ.eAthenaEditor.Editor {
	partial class frmFindAndReplace {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFindAndReplace));
			this.label1 = new System.Windows.Forms.Label();
			this.lblReplaceWith = new System.Windows.Forms.Label();
			this.txtLookFor = new System.Windows.Forms.TextBox();
			this.txtReplaceWith = new System.Windows.Forms.TextBox();
			this.btnFindNext = new System.Windows.Forms.Button();
			this.btnReplace = new System.Windows.Forms.Button();
			this.btnReplaceAll = new System.Windows.Forms.Button();
			this.chkMatchWholeWord = new System.Windows.Forms.CheckBox();
			this.chkMatchCase = new System.Windows.Forms.CheckBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnFindPrevious = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Such Text";
			// 
			// lblReplaceWith
			// 
			this.lblReplaceWith.AutoSize = true;
			this.lblReplaceWith.Location = new System.Drawing.Point(12, 35);
			this.lblReplaceWith.Name = "lblReplaceWith";
			this.lblReplaceWith.Size = new System.Drawing.Size(64, 13);
			this.lblReplaceWith.TabIndex = 2;
			this.lblReplaceWith.Text = "Ersetzen mit";
			// 
			// txtLookFor
			// 
			this.txtLookFor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtLookFor.Location = new System.Drawing.Point(90, 6);
			this.txtLookFor.Name = "txtLookFor";
			this.txtLookFor.Size = new System.Drawing.Size(240, 20);
			this.txtLookFor.TabIndex = 1;
			// 
			// txtReplaceWith
			// 
			this.txtReplaceWith.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtReplaceWith.Location = new System.Drawing.Point(90, 32);
			this.txtReplaceWith.Name = "txtReplaceWith";
			this.txtReplaceWith.Size = new System.Drawing.Size(240, 20);
			this.txtReplaceWith.TabIndex = 3;
			// 
			// btnFindNext
			// 
			this.btnFindNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFindNext.Location = new System.Drawing.Point(234, 105);
			this.btnFindNext.Name = "btnFindNext";
			this.btnFindNext.Size = new System.Drawing.Size(96, 23);
			this.btnFindNext.TabIndex = 6;
			this.btnFindNext.Text = "Suche nächstes";
			this.btnFindNext.UseVisualStyleBackColor = true;
			this.btnFindNext.Click += new System.EventHandler(this.btnFindNext_Click);
			// 
			// btnReplace
			// 
			this.btnReplace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnReplace.Location = new System.Drawing.Point(234, 134);
			this.btnReplace.Name = "btnReplace";
			this.btnReplace.Size = new System.Drawing.Size(96, 23);
			this.btnReplace.TabIndex = 7;
			this.btnReplace.Text = "Ersetzen";
			this.btnReplace.UseVisualStyleBackColor = true;
			this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
			// 
			// btnReplaceAll
			// 
			this.btnReplaceAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnReplaceAll.Location = new System.Drawing.Point(130, 134);
			this.btnReplaceAll.Name = "btnReplaceAll";
			this.btnReplaceAll.Size = new System.Drawing.Size(98, 23);
			this.btnReplaceAll.TabIndex = 9;
			this.btnReplaceAll.Text = "Alles ersetzen";
			this.btnReplaceAll.UseVisualStyleBackColor = true;
			this.btnReplaceAll.Click += new System.EventHandler(this.btnReplaceAll_Click);
			// 
			// chkMatchWholeWord
			// 
			this.chkMatchWholeWord.AutoSize = true;
			this.chkMatchWholeWord.Location = new System.Drawing.Point(221, 58);
			this.chkMatchWholeWord.Name = "chkMatchWholeWord";
			this.chkMatchWholeWord.Size = new System.Drawing.Size(108, 17);
			this.chkMatchWholeWord.TabIndex = 5;
			this.chkMatchWholeWord.Text = "nur ganze Wörter";
			this.chkMatchWholeWord.UseVisualStyleBackColor = true;
			// 
			// chkMatchCase
			// 
			this.chkMatchCase.AutoSize = true;
			this.chkMatchCase.Location = new System.Drawing.Point(90, 58);
			this.chkMatchCase.Name = "chkMatchCase";
			this.chkMatchCase.Size = new System.Drawing.Size(125, 17);
			this.chkMatchCase.TabIndex = 4;
			this.chkMatchCase.Text = "Groß/Klein beachten";
			this.chkMatchCase.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(12, 134);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "Abbruch";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnFindPrevious
			// 
			this.btnFindPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFindPrevious.Location = new System.Drawing.Point(130, 105);
			this.btnFindPrevious.Name = "btnFindPrevious";
			this.btnFindPrevious.Size = new System.Drawing.Size(98, 23);
			this.btnFindPrevious.TabIndex = 6;
			this.btnFindPrevious.Text = "Suche vorheriges";
			this.btnFindPrevious.UseVisualStyleBackColor = true;
			this.btnFindPrevious.Click += new System.EventHandler(this.btnFindPrevious_Click);
			// 
			// FindAndReplaceForm
			// 
			this.AcceptButton = this.btnReplace;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(342, 169);
			this.Controls.Add(this.chkMatchCase);
			this.Controls.Add(this.chkMatchWholeWord);
			this.Controls.Add(this.btnReplaceAll);
			this.Controls.Add(this.btnReplace);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnFindPrevious);
			this.Controls.Add(this.btnFindNext);
			this.Controls.Add(this.txtReplaceWith);
			this.Controls.Add(this.txtLookFor);
			this.Controls.Add(this.lblReplaceWith);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FindAndReplaceForm";
			this.ShowIcon = false;
			this.Text = "Suchen und Ersetzen";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FindAndReplaceForm_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblReplaceWith;
		private System.Windows.Forms.TextBox txtLookFor;
		private System.Windows.Forms.TextBox txtReplaceWith;
		private System.Windows.Forms.Button btnFindNext;
		private System.Windows.Forms.Button btnReplace;
		private System.Windows.Forms.Button btnReplaceAll;
		private System.Windows.Forms.CheckBox chkMatchWholeWord;
		private System.Windows.Forms.CheckBox chkMatchCase;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnFindPrevious;
	}
}