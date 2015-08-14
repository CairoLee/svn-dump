namespace GodLesZ.SiedlerOnline.TradeListener {
	partial class frmTradeListFilter {
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
			this.label1 = new System.Windows.Forms.Label();
			this.cmbItemOffer = new GodLesZ.Library.Controls.ImageComboBox();
			this.cmbItemOfferOperator = new System.Windows.Forms.ComboBox();
			this.txtItemOfferAmount = new System.Windows.Forms.TextBox();
			this.txtItemDemandedAmount = new System.Windows.Forms.TextBox();
			this.cmbItemDemandedOperator = new System.Windows.Forms.ComboBox();
			this.cmbItemDemanded = new GodLesZ.Library.Controls.ImageComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtRatioAmount = new System.Windows.Forms.TextBox();
			this.cmbRatioOperator = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.txtPlayer = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.chkActive = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(30, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Offer";
			// 
			// cmbItemOffer
			// 
			this.cmbItemOffer.BackgroundColorItemFocused = System.Drawing.SystemColors.ControlLight;
			this.cmbItemOffer.BackgroundColorItemSelected = System.Drawing.SystemColors.ControlLightLight;
			this.cmbItemOffer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbItemOffer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbItemOffer.FormattingEnabled = true;
			this.cmbItemOffer.ImagePlace = 0;
			this.cmbItemOffer.Location = new System.Drawing.Point(83, 61);
			this.cmbItemOffer.Name = "cmbItemOffer";
			this.cmbItemOffer.Size = new System.Drawing.Size(104, 21);
			this.cmbItemOffer.TabIndex = 1;
			// 
			// cmbItemOfferOperator
			// 
			this.cmbItemOfferOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbItemOfferOperator.FormattingEnabled = true;
			this.cmbItemOfferOperator.Items.AddRange(new object[] {
            ">",
            ">=",
            "==",
            "<=",
            "<"});
			this.cmbItemOfferOperator.Location = new System.Drawing.Point(193, 61);
			this.cmbItemOfferOperator.Name = "cmbItemOfferOperator";
			this.cmbItemOfferOperator.Size = new System.Drawing.Size(50, 21);
			this.cmbItemOfferOperator.TabIndex = 2;
			// 
			// txtItemOfferAmount
			// 
			this.txtItemOfferAmount.Location = new System.Drawing.Point(249, 62);
			this.txtItemOfferAmount.Name = "txtItemOfferAmount";
			this.txtItemOfferAmount.Size = new System.Drawing.Size(52, 20);
			this.txtItemOfferAmount.TabIndex = 3;
			this.txtItemOfferAmount.Text = "0";
			// 
			// txtItemDemandedAmount
			// 
			this.txtItemDemandedAmount.Location = new System.Drawing.Point(249, 89);
			this.txtItemDemandedAmount.Name = "txtItemDemandedAmount";
			this.txtItemDemandedAmount.Size = new System.Drawing.Size(52, 20);
			this.txtItemDemandedAmount.TabIndex = 7;
			this.txtItemDemandedAmount.Text = "0";
			// 
			// cmbItemDemandedOperator
			// 
			this.cmbItemDemandedOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbItemDemandedOperator.FormattingEnabled = true;
			this.cmbItemDemandedOperator.Items.AddRange(new object[] {
            ">",
            ">=",
            "==",
            "<=",
            "<"});
			this.cmbItemDemandedOperator.Location = new System.Drawing.Point(193, 88);
			this.cmbItemDemandedOperator.Name = "cmbItemDemandedOperator";
			this.cmbItemDemandedOperator.Size = new System.Drawing.Size(50, 21);
			this.cmbItemDemandedOperator.TabIndex = 6;
			// 
			// cmbItemDemanded
			// 
			this.cmbItemDemanded.BackgroundColorItemFocused = System.Drawing.SystemColors.ControlLight;
			this.cmbItemDemanded.BackgroundColorItemSelected = System.Drawing.SystemColors.ControlLightLight;
			this.cmbItemDemanded.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbItemDemanded.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbItemDemanded.FormattingEnabled = true;
			this.cmbItemDemanded.ImagePlace = 0;
			this.cmbItemDemanded.Location = new System.Drawing.Point(83, 88);
			this.cmbItemDemanded.Name = "cmbItemDemanded";
			this.cmbItemDemanded.Size = new System.Drawing.Size(104, 21);
			this.cmbItemDemanded.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 91);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Demanded";
			// 
			// txtRatioAmount
			// 
			this.txtRatioAmount.Location = new System.Drawing.Point(139, 135);
			this.txtRatioAmount.Name = "txtRatioAmount";
			this.txtRatioAmount.Size = new System.Drawing.Size(48, 20);
			this.txtRatioAmount.TabIndex = 11;
			// 
			// cmbRatioOperator
			// 
			this.cmbRatioOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbRatioOperator.FormattingEnabled = true;
			this.cmbRatioOperator.Items.AddRange(new object[] {
            ">",
            ">=",
            "==",
            "<=",
            "<"});
			this.cmbRatioOperator.Location = new System.Drawing.Point(83, 134);
			this.cmbRatioOperator.Name = "cmbRatioOperator";
			this.cmbRatioOperator.Size = new System.Drawing.Size(50, 21);
			this.cmbRatioOperator.TabIndex = 10;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 137);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Ratio";
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Image = global::GodLesZ.SiedlerOnline.TradeListener.Properties.Resources.delete;
			this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCancel.Location = new System.Drawing.Point(226, 232);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 13;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnAdd.Image = global::GodLesZ.SiedlerOnline.TradeListener.Properties.Resources.add;
			this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAdd.Location = new System.Drawing.Point(145, 232);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 23);
			this.btnAdd.TabIndex = 12;
			this.btnAdd.Text = "Add Filter";
			this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// txtPlayer
			// 
			this.txtPlayer.Location = new System.Drawing.Point(83, 161);
			this.txtPlayer.Name = "txtPlayer";
			this.txtPlayer.Size = new System.Drawing.Size(218, 20);
			this.txtPlayer.TabIndex = 16;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 163);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(36, 13);
			this.label4.TabIndex = 14;
			this.label4.Text = "Player";
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.LightSteelBlue;
			this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label5.Location = new System.Drawing.Point(13, 10);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(288, 36);
			this.label5.TabIndex = 17;
			this.label5.Text = "Build a filter using a resource, operator for comparison and a amount. Operator a" +
    "nd amount are optional.";
			// 
			// chkActive
			// 
			this.chkActive.AutoSize = true;
			this.chkActive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkActive.Location = new System.Drawing.Point(12, 200);
			this.chkActive.Name = "chkActive";
			this.chkActive.Size = new System.Drawing.Size(83, 17);
			this.chkActive.TabIndex = 18;
			this.chkActive.Text = "Active         ";
			this.chkActive.UseVisualStyleBackColor = true;
			// 
			// frmTradeListFilter
			// 
			this.AcceptButton = this.btnAdd;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(313, 267);
			this.Controls.Add(this.chkActive);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtPlayer);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.txtRatioAmount);
			this.Controls.Add(this.cmbRatioOperator);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtItemDemandedAmount);
			this.Controls.Add(this.cmbItemDemandedOperator);
			this.Controls.Add(this.cmbItemDemanded);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtItemOfferAmount);
			this.Controls.Add(this.cmbItemOfferOperator);
			this.Controls.Add(this.cmbItemOffer);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmTradeListFilter";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add New Filter";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private GodLesZ.Library.Controls.ImageComboBox cmbItemOffer;
		private System.Windows.Forms.ComboBox cmbItemOfferOperator;
		private System.Windows.Forms.TextBox txtItemOfferAmount;
		private System.Windows.Forms.TextBox txtItemDemandedAmount;
		private System.Windows.Forms.ComboBox cmbItemDemandedOperator;
		private GodLesZ.Library.Controls.ImageComboBox cmbItemDemanded;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtRatioAmount;
		private System.Windows.Forms.ComboBox cmbRatioOperator;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.TextBox txtPlayer;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox chkActive;
	}
}