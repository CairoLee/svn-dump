namespace GodLesZ.SiedlerOnline.TradeListener {
	partial class frmLanguage {
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLanguage));
			this.btnChoose = new System.Windows.Forms.Button();
			this.cmbLanguage = new GodLesZ.Library.Controls.ImageComboBox();
			this.imagesLanguage = new System.Windows.Forms.ImageList(this.components);
			this.label2 = new System.Windows.Forms.Label();
			this.imgLanguage = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.imgLanguage)).BeginInit();
			this.SuspendLayout();
			// 
			// btnChoose
			// 
			this.btnChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnChoose.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnChoose.Enabled = false;
			this.btnChoose.Location = new System.Drawing.Point(269, 112);
			this.btnChoose.Name = "btnChoose";
			this.btnChoose.Size = new System.Drawing.Size(75, 23);
			this.btnChoose.TabIndex = 1;
			this.btnChoose.Text = "OK";
			this.btnChoose.UseVisualStyleBackColor = true;
			this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
			// 
			// cmbLanguage
			// 
			this.cmbLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbLanguage.BackgroundColorItemFocused = System.Drawing.SystemColors.ControlLight;
			this.cmbLanguage.BackgroundColorItemSelected = System.Drawing.SystemColors.ControlLightLight;
			this.cmbLanguage.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbLanguage.FormattingEnabled = true;
			this.cmbLanguage.ImageList = this.imagesLanguage;
			this.cmbLanguage.ImagePlace = 0;
			this.cmbLanguage.ItemHeight = 16;
			this.cmbLanguage.Location = new System.Drawing.Point(76, 39);
			this.cmbLanguage.Name = "cmbLanguage";
			this.cmbLanguage.Size = new System.Drawing.Size(268, 22);
			this.cmbLanguage.TabIndex = 3;
			this.cmbLanguage.SelectedIndexChanged += new System.EventHandler(this.cmbLanguage_SelectedIndexChanged);
			// 
			// imagesLanguage
			// 
			this.imagesLanguage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagesLanguage.ImageStream")));
			this.imagesLanguage.TransparentColor = System.Drawing.Color.Transparent;
			this.imagesLanguage.Images.SetKeyName(0, "flag_germany.png");
			this.imagesLanguage.Images.SetKeyName(1, "flag_great_britain.png");
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(73, 13);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(269, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Please select a language for interface & resource names:";
			// 
			// imgLanguage
			// 
			this.imgLanguage.Image = global::GodLesZ.SiedlerOnline.TradeListener.Properties.Resources.flag_great_britain;
			this.imgLanguage.Location = new System.Drawing.Point(12, 12);
			this.imgLanguage.Name = "imgLanguage";
			this.imgLanguage.Size = new System.Drawing.Size(48, 48);
			this.imgLanguage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.imgLanguage.TabIndex = 7;
			this.imgLanguage.TabStop = false;
			// 
			// frmLanguage
			// 
			this.AcceptButton = this.btnChoose;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(356, 147);
			this.Controls.Add(this.imgLanguage);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cmbLanguage);
			this.Controls.Add(this.btnChoose);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(265, 144);
			this.Name = "frmLanguage";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "DSO Trade Listener - Language Selection";
			((System.ComponentModel.ISupportInitialize)(this.imgLanguage)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnChoose;
		private GodLesZ.Library.Controls.ImageComboBox cmbLanguage;
		private System.Windows.Forms.PictureBox imgLanguage;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ImageList imagesLanguage;
	}
}