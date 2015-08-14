namespace GodLesZ.EdenEternal.DataViewer.Controls {
	partial class FormMonsterList {
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
			this.monsterList = new GodLesZ.EdenEternal.DataViewer.Controls.MonsterListControl();
			this.SuspendLayout();
			// 
			// monsterList
			// 
			this.monsterList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.monsterList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.monsterList.Location = new System.Drawing.Point(0, 0);
			this.monsterList.MonsterData = null;
			this.monsterList.Name = "monsterList";
			this.monsterList.Size = new System.Drawing.Size(284, 262);
			this.monsterList.TabIndex = 0;
			// 
			// FormMonsterList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.monsterList);
			this.Name = "FormMonsterList";
			this.Text = "FormMonsterList";
			this.ResumeLayout(false);

		}

		#endregion

		private MonsterListControl monsterList;
	}
}