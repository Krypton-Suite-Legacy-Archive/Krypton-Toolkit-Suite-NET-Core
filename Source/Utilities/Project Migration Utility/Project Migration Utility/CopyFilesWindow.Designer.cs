namespace ProjectMigrationUtility
{
    partial class CopyFilesWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTotalFiles = new System.Windows.Forms.Label();
            this.pbTotalFiles = new System.Windows.Forms.ProgressBar();
            this.pbCurrentFile = new System.Windows.Forms.ProgressBar();
            this.lblCurrentFile = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTotalFiles
            // 
            this.lblTotalFiles.AutoSize = true;
            this.lblTotalFiles.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFiles.Location = new System.Drawing.Point(12, 9);
            this.lblTotalFiles.Name = "lblTotalFiles";
            this.lblTotalFiles.Size = new System.Drawing.Size(70, 20);
            this.lblTotalFiles.TabIndex = 0;
            this.lblTotalFiles.Text = "Total Files";
            // 
            // pbTotalFiles
            // 
            this.pbTotalFiles.Location = new System.Drawing.Point(16, 41);
            this.pbTotalFiles.Name = "pbTotalFiles";
            this.pbTotalFiles.Size = new System.Drawing.Size(660, 23);
            this.pbTotalFiles.TabIndex = 1;
            // 
            // pbCurrentFile
            // 
            this.pbCurrentFile.Location = new System.Drawing.Point(16, 130);
            this.pbCurrentFile.Name = "pbCurrentFile";
            this.pbCurrentFile.Size = new System.Drawing.Size(660, 23);
            this.pbCurrentFile.TabIndex = 3;
            // 
            // lblCurrentFile
            // 
            this.lblCurrentFile.AutoSize = true;
            this.lblCurrentFile.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentFile.Location = new System.Drawing.Point(12, 98);
            this.lblCurrentFile.Name = "lblCurrentFile";
            this.lblCurrentFile.Size = new System.Drawing.Size(77, 20);
            this.lblCurrentFile.TabIndex = 2;
            this.lblCurrentFile.Text = "Current File";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Arial", 12F);
            this.btnClose.Location = new System.Drawing.Point(287, 170);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 26);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "C&ancel Copy";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // CopyFilesWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 218);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pbCurrentFile);
            this.Controls.Add(this.lblCurrentFile);
            this.Controls.Add(this.pbTotalFiles);
            this.Controls.Add(this.lblTotalFiles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CopyFilesWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CopyFilesWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CopyFilesWindow_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotalFiles;
        private System.Windows.Forms.ProgressBar pbTotalFiles;
        private System.Windows.Forms.ProgressBar pbCurrentFile;
        private System.Windows.Forms.Label lblCurrentFile;
        private System.Windows.Forms.Button btnClose;
    }
}