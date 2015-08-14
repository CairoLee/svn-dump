namespace InsaneRO.Cards.CardBuilder {
	partial class frmMain {
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose( bool disposing ) {
			if( disposing && ( components != null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.imgPreview = new System.Windows.Forms.PictureBox();
			this.propGrid = new System.Windows.Forms.PropertyGrid();
			this.panelProps = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnSave = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.imgPreview)).BeginInit();
			this.panelProps.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// imgPreview
			// 
			this.imgPreview.Location = new System.Drawing.Point(13, 13);
			this.imgPreview.Name = "imgPreview";
			this.imgPreview.Size = new System.Drawing.Size(240, 350);
			this.imgPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.imgPreview.TabIndex = 0;
			this.imgPreview.TabStop = false;
			this.imgPreview.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imgPreview_MouseDown);
			this.imgPreview.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imgPreview_MouseMove);
			this.imgPreview.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imgPreview_MouseUp);
			// 
			// propGrid
			// 
			this.propGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.propGrid.Location = new System.Drawing.Point(0, 0);
			this.propGrid.Name = "propGrid";
			this.propGrid.Size = new System.Drawing.Size(263, 362);
			this.propGrid.TabIndex = 1;
			this.propGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propGrid_PropertyValueChanged);
			// 
			// panelProps
			// 
			this.panelProps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panelProps.Controls.Add(this.propGrid);
			this.panelProps.Location = new System.Drawing.Point(294, 0);
			this.panelProps.Name = "panelProps";
			this.panelProps.Size = new System.Drawing.Size(263, 362);
			this.panelProps.TabIndex = 2;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 362);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(557, 47);
			this.panel1.TabIndex = 4;
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Location = new System.Drawing.Point(470, 12);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 0;
			this.btnSave.Text = "Speichern";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(557, 409);
			this.Controls.Add(this.panelProps);
			this.Controls.Add(this.imgPreview);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmMain";
			this.Text = "InsaneRO Card Builder";
			((System.ComponentModel.ISupportInitialize)(this.imgPreview)).EndInit();
			this.panelProps.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox imgPreview;
		private System.Windows.Forms.PropertyGrid propGrid;
		private System.Windows.Forms.Panel panelProps;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnSave;
	}
}

