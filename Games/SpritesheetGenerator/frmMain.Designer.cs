namespace SpritesheetGenerator
{
    partial class frmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.listFiles = new System.Windows.Forms.ListBox();
            this.btnOpenFiles = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtImagesPerRow = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtImageWidth = new System.Windows.Forms.TextBox();
            this.txtImageHeight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnImageUp = new System.Windows.Forms.Button();
            this.btnImageDown = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listFiles
            // 
            this.listFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listFiles.FormattingEnabled = true;
            this.listFiles.Location = new System.Drawing.Point(12, 12);
            this.listFiles.Name = "listFiles";
            this.listFiles.Size = new System.Drawing.Size(250, 381);
            this.listFiles.TabIndex = 0;
            // 
            // btnOpenFiles
            // 
            this.btnOpenFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFiles.Location = new System.Drawing.Point(382, 12);
            this.btnOpenFiles.Name = "btnOpenFiles";
            this.btnOpenFiles.Size = new System.Drawing.Size(93, 23);
            this.btnOpenFiles.TabIndex = 1;
            this.btnOpenFiles.Text = "Durchsuchen";
            this.btnOpenFiles.UseVisualStyleBackColor = true;
            this.btnOpenFiles.Click += new System.EventHandler(this.btnOpenFiles_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(269, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bilder pro Reihe/Animation";
            // 
            // txtImagesPerRow
            // 
            this.txtImagesPerRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImagesPerRow.Location = new System.Drawing.Point(408, 90);
            this.txtImagesPerRow.Name = "txtImagesPerRow";
            this.txtImagesPerRow.Size = new System.Drawing.Size(62, 20);
            this.txtImagesPerRow.TabIndex = 3;
            this.txtImagesPerRow.Text = "4";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(269, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Breite pro Bild";
            // 
            // txtImageWidth
            // 
            this.txtImageWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImageWidth.Location = new System.Drawing.Point(408, 120);
            this.txtImageWidth.Name = "txtImageWidth";
            this.txtImageWidth.Size = new System.Drawing.Size(62, 20);
            this.txtImageWidth.TabIndex = 5;
            this.txtImageWidth.Text = "32";
            // 
            // txtImageHeight
            // 
            this.txtImageHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImageHeight.Location = new System.Drawing.Point(408, 146);
            this.txtImageHeight.Name = "txtImageHeight";
            this.txtImageHeight.Size = new System.Drawing.Size(62, 20);
            this.txtImageHeight.TabIndex = 7;
            this.txtImageHeight.Text = "48";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(269, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Höhe pro Bild";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(377, 370);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(93, 23);
            this.btnGenerate.TabIndex = 8;
            this.btnGenerate.Text = "Erstellen";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnImageUp
            // 
            this.btnImageUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImageUp.Location = new System.Drawing.Point(268, 12);
            this.btnImageUp.Name = "btnImageUp";
            this.btnImageUp.Size = new System.Drawing.Size(52, 23);
            this.btnImageUp.TabIndex = 9;
            this.btnImageUp.Text = "UP";
            this.btnImageUp.UseVisualStyleBackColor = true;
            this.btnImageUp.Click += new System.EventHandler(this.btnImageUp_Click);
            // 
            // btnImageDown
            // 
            this.btnImageDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImageDown.Location = new System.Drawing.Point(268, 39);
            this.btnImageDown.Name = "btnImageDown";
            this.btnImageDown.Size = new System.Drawing.Size(52, 23);
            this.btnImageDown.TabIndex = 10;
            this.btnImageDown.Text = "DOWN";
            this.btnImageDown.UseVisualStyleBackColor = true;
            this.btnImageDown.Click += new System.EventHandler(this.btnImageDown_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 408);
            this.Controls.Add(this.btnImageDown);
            this.Controls.Add(this.btnImageUp);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtImageHeight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtImageWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtImagesPerRow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOpenFiles);
            this.Controls.Add(this.listFiles);
            this.Name = "frmMain";
            this.Text = "Spritesheet Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listFiles;
        private System.Windows.Forms.Button btnOpenFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtImagesPerRow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtImageWidth;
        private System.Windows.Forms.TextBox txtImageHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnImageUp;
        private System.Windows.Forms.Button btnImageDown;
    }
}

