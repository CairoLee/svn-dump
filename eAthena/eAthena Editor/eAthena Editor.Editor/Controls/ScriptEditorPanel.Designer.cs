namespace GodLesZ.eAthenaEditor.Editor.Controls {
	partial class ScriptEditorPanel {
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScriptEditorPanel));
			this.imagesEntitys = new System.Windows.Forms.ImageList(this.components);
			this.txtEditor = new GodLesZ.eAthenaEditor.Editor.Controls.ScriptTextEditorControl();
			this.cmbEntitys = new GodLesZ.eAthenaEditor.Editor.Controls.ScriptEntityComboBox();
			this.SuspendLayout();
			// 
			// imagesEntitys
			// 
			this.imagesEntitys.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagesEntitys.ImageStream")));
			this.imagesEntitys.TransparentColor = System.Drawing.Color.Transparent;
			this.imagesEntitys.Images.SetKeyName(0, "function_extern.png");
			this.imagesEntitys.Images.SetKeyName(1, "function_intern.png");
			this.imagesEntitys.Images.SetKeyName(2, "kafra.png");
			this.imagesEntitys.Images.SetKeyName(3, "poring.png");
			// 
			// txtEditor
			// 
			this.txtEditor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtEditor.IsReadOnly = false;
			this.txtEditor.Location = new System.Drawing.Point(0, 26);
			this.txtEditor.Name = "txtEditor";
			this.txtEditor.Size = new System.Drawing.Size(730, 413);
			this.txtEditor.TabIndex = 1;
			// 
			// cmbEntitys
			// 
			this.cmbEntitys.BackColor = System.Drawing.SystemColors.Menu;
			this.cmbEntitys.BackgroundColorItemFocused = System.Drawing.SystemColors.ControlLight;
			this.cmbEntitys.BackgroundColorItemSelected = System.Drawing.SystemColors.ControlLightLight;
			this.cmbEntitys.Dock = System.Windows.Forms.DockStyle.Top;
			this.cmbEntitys.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbEntitys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEntitys.FormattingEnabled = true;
			this.cmbEntitys.ImageList = this.imagesEntitys;
			this.cmbEntitys.ImagePlace = 0;
			this.cmbEntitys.ItemHeight = 20;
			this.cmbEntitys.Location = new System.Drawing.Point(0, 0);
			this.cmbEntitys.Name = "cmbEntitys";
			this.cmbEntitys.Size = new System.Drawing.Size(730, 26);
			this.cmbEntitys.TabIndex = 3;
			this.cmbEntitys.SelectedIndexChanged += new System.EventHandler(this.cmbFunctions_SelectedIndexChanged);
			// 
			// ScriptEditorPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.txtEditor);
			this.Controls.Add(this.cmbEntitys);
			this.Name = "ScriptEditorPanel";
			this.Size = new System.Drawing.Size(730, 439);
			this.Enter += new System.EventHandler(this.ScriptEditorPanel_Enter);
			this.ResumeLayout(false);

		}

		#endregion

		private ScriptEntityComboBox cmbEntitys;
		private Controls.ScriptTextEditorControl txtEditor;
		private System.Windows.Forms.ImageList imagesEntitys;
	}
}
