namespace ProjectMigrationUtility
{
    partial class MainWindowOld
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtProjectDirectory = new System.Windows.Forms.TextBox();
            this.btnBrowseProjectDirectory = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkCompressFiles = new System.Windows.Forms.CheckBox();
            this.btnVerifyBackup = new System.Windows.Forms.Button();
            this.btnStartBackup = new System.Windows.Forms.Button();
            this.btnBrowseBackupDirectory = new System.Windows.Forms.Button();
            this.txtBackupDirectory = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbMigrate = new System.Windows.Forms.GroupBox();
            this.btnStartMigration = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslCurrentStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.tspbCopyFiles = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.groupBox1.SuspendLayout();
            this.gbMigrate.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Project Directory:";
            // 
            // txtProjectDirectory
            // 
            this.txtProjectDirectory.Font = new System.Drawing.Font("Arial", 12F);
            this.txtProjectDirectory.Location = new System.Drawing.Point(161, 9);
            this.txtProjectDirectory.Name = "txtProjectDirectory";
            this.txtProjectDirectory.Size = new System.Drawing.Size(734, 26);
            this.txtProjectDirectory.TabIndex = 1;
            // 
            // btnBrowseProjectDirectory
            // 
            this.btnBrowseProjectDirectory.Font = new System.Drawing.Font("Arial", 12F);
            this.btnBrowseProjectDirectory.Location = new System.Drawing.Point(901, 9);
            this.btnBrowseProjectDirectory.Name = "btnBrowseProjectDirectory";
            this.btnBrowseProjectDirectory.Size = new System.Drawing.Size(35, 26);
            this.btnBrowseProjectDirectory.TabIndex = 2;
            this.btnBrowseProjectDirectory.Text = ".&..";
            this.btnBrowseProjectDirectory.UseVisualStyleBackColor = true;
            this.btnBrowseProjectDirectory.Click += new System.EventHandler(this.btnBrowseProjectDirectory_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkCompressFiles);
            this.groupBox1.Controls.Add(this.btnVerifyBackup);
            this.groupBox1.Controls.Add(this.btnStartBackup);
            this.groupBox1.Controls.Add(this.btnBrowseBackupDirectory);
            this.groupBox1.Controls.Add(this.txtBackupDirectory);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(920, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Step 1: Backup";
            // 
            // chkCompressFiles
            // 
            this.chkCompressFiles.AutoSize = true;
            this.chkCompressFiles.Font = new System.Drawing.Font("Arial", 12F);
            this.chkCompressFiles.Location = new System.Drawing.Point(108, 66);
            this.chkCompressFiles.Name = "chkCompressFiles";
            this.chkCompressFiles.Size = new System.Drawing.Size(157, 22);
            this.chkCompressFiles.TabIndex = 8;
            this.chkCompressFiles.Text = "C&ompress Backup";
            this.chkCompressFiles.UseVisualStyleBackColor = true;
            // 
            // btnVerifyBackup
            // 
            this.btnVerifyBackup.Enabled = false;
            this.btnVerifyBackup.Font = new System.Drawing.Font("Arial", 12F);
            this.btnVerifyBackup.Location = new System.Drawing.Point(477, 66);
            this.btnVerifyBackup.Name = "btnVerifyBackup";
            this.btnVerifyBackup.Size = new System.Drawing.Size(174, 26);
            this.btnVerifyBackup.TabIndex = 7;
            this.btnVerifyBackup.Text = "V&erify Backup";
            this.btnVerifyBackup.UseVisualStyleBackColor = true;
            this.btnVerifyBackup.Click += new System.EventHandler(this.btnVerifyBackup_Click);
            // 
            // btnStartBackup
            // 
            this.btnStartBackup.Enabled = false;
            this.btnStartBackup.Font = new System.Drawing.Font("Arial", 12F);
            this.btnStartBackup.Location = new System.Drawing.Point(297, 66);
            this.btnStartBackup.Name = "btnStartBackup";
            this.btnStartBackup.Size = new System.Drawing.Size(174, 26);
            this.btnStartBackup.TabIndex = 6;
            this.btnStartBackup.Text = "&Commence Backup";
            this.btnStartBackup.UseVisualStyleBackColor = true;
            this.btnStartBackup.Click += new System.EventHandler(this.btnStartBackup_Click);
            // 
            // btnBrowseBackupDirectory
            // 
            this.btnBrowseBackupDirectory.Font = new System.Drawing.Font("Arial", 12F);
            this.btnBrowseBackupDirectory.Location = new System.Drawing.Point(879, 33);
            this.btnBrowseBackupDirectory.Name = "btnBrowseBackupDirectory";
            this.btnBrowseBackupDirectory.Size = new System.Drawing.Size(35, 26);
            this.btnBrowseBackupDirectory.TabIndex = 5;
            this.btnBrowseBackupDirectory.Text = ".&..";
            this.btnBrowseBackupDirectory.UseVisualStyleBackColor = true;
            this.btnBrowseBackupDirectory.Click += new System.EventHandler(this.btnBrowseBackupDirectory_Click);
            // 
            // txtBackupDirectory
            // 
            this.txtBackupDirectory.Font = new System.Drawing.Font("Arial", 12F);
            this.txtBackupDirectory.Location = new System.Drawing.Point(172, 34);
            this.txtBackupDirectory.Name = "txtBackupDirectory";
            this.txtBackupDirectory.Size = new System.Drawing.Size(701, 26);
            this.txtBackupDirectory.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Backup Directory:";
            // 
            // gbMigrate
            // 
            this.gbMigrate.Controls.Add(this.btnStartMigration);
            this.gbMigrate.Enabled = false;
            this.gbMigrate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMigrate.Location = new System.Drawing.Point(16, 194);
            this.gbMigrate.Name = "gbMigrate";
            this.gbMigrate.Size = new System.Drawing.Size(920, 100);
            this.gbMigrate.TabIndex = 4;
            this.gbMigrate.TabStop = false;
            this.gbMigrate.Text = "Step 2: Migrate";
            // 
            // btnStartMigration
            // 
            this.btnStartMigration.Enabled = false;
            this.btnStartMigration.Font = new System.Drawing.Font("Arial", 12F);
            this.btnStartMigration.Location = new System.Drawing.Point(383, 33);
            this.btnStartMigration.Name = "btnStartMigration";
            this.btnStartMigration.Size = new System.Drawing.Size(174, 26);
            this.btnStartMigration.TabIndex = 6;
            this.btnStartMigration.Text = "Commence M&igration";
            this.btnStartMigration.UseVisualStyleBackColor = true;
            this.btnStartMigration.Click += new System.EventHandler(this.btnStartMigration_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslCurrentStatus,
            this.tspbCopyFiles,
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 345);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(948, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslCurrentStatus
            // 
            this.tsslCurrentStatus.Name = "tsslCurrentStatus";
            this.tsslCurrentStatus.Size = new System.Drawing.Size(800, 17);
            this.tsslCurrentStatus.Spring = true;
            this.tsslCurrentStatus.Text = "Ready";
            this.tsslCurrentStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Arial", 12F);
            this.btnClose.Location = new System.Drawing.Point(865, 307);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(71, 26);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "C&lose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tspbCopyFiles
            // 
            this.tspbCopyFiles.Name = "tspbCopyFiles";
            this.tspbCopyFiles.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(48, 17);
            this.toolStripStatusLabel1.Text = "({0}/{1})";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 367);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gbMigrate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBrowseProjectDirectory);
            this.Controls.Add(this.txtProjectDirectory);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbMigrate.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProjectDirectory;
        private System.Windows.Forms.Button btnBrowseProjectDirectory;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBrowseBackupDirectory;
        private System.Windows.Forms.TextBox txtBackupDirectory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkCompressFiles;
        private System.Windows.Forms.Button btnVerifyBackup;
        private System.Windows.Forms.Button btnStartBackup;
        private System.Windows.Forms.GroupBox gbMigrate;
        private System.Windows.Forms.Button btnStartMigration;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslCurrentStatus;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolStripProgressBar tspbCopyFiles;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
    }
}

