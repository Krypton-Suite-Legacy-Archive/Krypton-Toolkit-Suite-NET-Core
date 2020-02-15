using ComponentFactory.Krypton.Toolkit;
using Microsoft.WindowsAPICodePack.Dialogs;
using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ProjectMigrationUtility
{
    public class KryptonMainWindow : KryptonForm
    {
        #region Design Code
        private System.Windows.Forms.StatusStrip statusStrip1;
        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnBrowseProjectDirectory;
        private KryptonGroupBox kgbStageTwo;
        private KryptonButton kbtnBrowseBackupDirectory;
        private KryptonTextBox ktxtBackupDirectory;
        private KryptonLabel kryptonLabel2;
        private KryptonGroupBox kgbStageThree;
        private System.Windows.Forms.ToolStripStatusLabel tsslCurrentStatus;
        private KryptonButton kbtnVarifyBackup;
        private KryptonButton kbtnBackupProject;
        private KryptonCheckBox kchkCompressBackup;
        private System.Windows.Forms.ToolStripProgressBar tspCopyProgress;
        private KryptonButton kbtnClose;
        private KryptonGroupBox kryptonGroupBox1;
        private KryptonListBox klbProjectFiles;
        private KryptonTextBox ktxtProjectPath;
        private KryptonButton kbtnBrowseCompressedFileDirectory;
        private KryptonTextBox ktxtCompressedFileDirectoryPath;
        private KryptonLabel klblCompressedFileDirectory;
        private KryptonButton kbtnMigrateProject;
        private KryptonLabel kryptonLabel1;

        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslCurrentStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspCopyProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.ktxtProjectPath = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.klbProjectFiles = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kbtnBrowseProjectDirectory = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kbtnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kgbStageThree = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kbtnMigrateProject = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kgbStageTwo = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kbtnBrowseCompressedFileDirectory = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.ktxtCompressedFileDirectoryPath = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.klblCompressedFileDirectory = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kbtnVarifyBackup = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kbtnBackupProject = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kchkCompressBackup = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.kbtnBrowseBackupDirectory = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.ktxtBackupDirectory = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kgbStageThree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kgbStageThree.Panel)).BeginInit();
            this.kgbStageThree.Panel.SuspendLayout();
            this.kgbStageThree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kgbStageTwo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kgbStageTwo.Panel)).BeginInit();
            this.kgbStageTwo.Panel.SuspendLayout();
            this.kgbStageTwo.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslCurrentStatus,
            this.tspCopyProgress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 453);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(1133, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslCurrentStatus
            // 
            this.tsslCurrentStatus.Name = "tsslCurrentStatus";
            this.tsslCurrentStatus.Size = new System.Drawing.Size(1118, 17);
            this.tsslCurrentStatus.Spring = true;
            this.tsslCurrentStatus.Text = "Ready";
            this.tsslCurrentStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tspCopyProgress
            // 
            this.tspCopyProgress.Name = "tspCopyProgress";
            this.tspCopyProgress.Size = new System.Drawing.Size(100, 16);
            this.tspCopyProgress.Visible = false;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonGroupBox1);
            this.kryptonPanel1.Controls.Add(this.kbtnClose);
            this.kryptonPanel1.Controls.Add(this.kgbStageThree);
            this.kryptonPanel1.Controls.Add(this.kgbStageTwo);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1133, 453);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Location = new System.Drawing.Point(17, 12);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.ktxtProjectPath);
            this.kryptonGroupBox1.Panel.Controls.Add(this.klbProjectFiles);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel1);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kbtnBrowseProjectDirectory);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(411, 426);
            this.kryptonGroupBox1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonGroupBox1.TabIndex = 12;
            this.kryptonGroupBox1.Values.Heading = "Step 1: Locate Project Files";
            // 
            // ktxtProjectPath
            // 
            this.ktxtProjectPath.Location = new System.Drawing.Point(17, 44);
            this.ktxtProjectPath.Name = "ktxtProjectPath";
            this.ktxtProjectPath.Size = new System.Drawing.Size(341, 26);
            this.ktxtProjectPath.StateCommon.Content.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktxtProjectPath.StateCommon.Content.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.ktxtProjectPath.TabIndex = 7;
            this.ktxtProjectPath.TextChanged += new System.EventHandler(this.ktxtProjectPath_TextChanged);
            // 
            // klbProjectFiles
            // 
            this.klbProjectFiles.Location = new System.Drawing.Point(17, 76);
            this.klbProjectFiles.Name = "klbProjectFiles";
            this.klbProjectFiles.Size = new System.Drawing.Size(378, 306);
            this.klbProjectFiles.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klbProjectFiles.TabIndex = 5;
            this.klbProjectFiles.MouseEnter += new System.EventHandler(this.klbProjectFiles_MouseEnter);
            this.klbProjectFiles.MouseHover += new System.EventHandler(this.klbProjectFiles_MouseHover);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(133, 16);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(115, 22);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 2;
            this.kryptonLabel1.Values.Text = "Project Files:";
            // 
            // kbtnBrowseProjectDirectory
            // 
            this.kbtnBrowseProjectDirectory.Location = new System.Drawing.Point(364, 44);
            this.kbtnBrowseProjectDirectory.Name = "kbtnBrowseProjectDirectory";
            this.kbtnBrowseProjectDirectory.Size = new System.Drawing.Size(31, 26);
            this.kbtnBrowseProjectDirectory.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnBrowseProjectDirectory.TabIndex = 4;
            this.kbtnBrowseProjectDirectory.Values.Text = "..&.";
            this.kbtnBrowseProjectDirectory.Click += new System.EventHandler(this.kbtnBrowseProjectDirectory_Click);
            // 
            // kbtnClose
            // 
            this.kbtnClose.Location = new System.Drawing.Point(1025, 412);
            this.kbtnClose.Name = "kbtnClose";
            this.kbtnClose.Size = new System.Drawing.Size(96, 26);
            this.kbtnClose.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnClose.TabIndex = 11;
            this.kbtnClose.Values.Text = "&Close";
            this.kbtnClose.Click += new System.EventHandler(this.kbtnClose_Click);
            // 
            // kgbStageThree
            // 
            this.kgbStageThree.Enabled = false;
            this.kgbStageThree.Location = new System.Drawing.Point(445, 222);
            this.kgbStageThree.Name = "kgbStageThree";
            // 
            // kgbStageThree.Panel
            // 
            this.kgbStageThree.Panel.Controls.Add(this.kbtnMigrateProject);
            this.kgbStageThree.Size = new System.Drawing.Size(676, 111);
            this.kgbStageThree.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgbStageThree.TabIndex = 6;
            this.kgbStageThree.Values.Heading = "Step 2: Migrate Project";
            // 
            // kbtnMigrateProject
            // 
            this.kbtnMigrateProject.Enabled = false;
            this.kbtnMigrateProject.Location = new System.Drawing.Point(250, 29);
            this.kbtnMigrateProject.Name = "kbtnMigrateProject";
            this.kbtnMigrateProject.Size = new System.Drawing.Size(184, 26);
            this.kbtnMigrateProject.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnMigrateProject.TabIndex = 12;
            this.kbtnMigrateProject.Values.Text = "Migrate &Project";
            this.kbtnMigrateProject.Click += new System.EventHandler(this.kbtnMigrateProject_Click);
            // 
            // kgbStageTwo
            // 
            this.kgbStageTwo.Enabled = false;
            this.kgbStageTwo.Location = new System.Drawing.Point(445, 12);
            this.kgbStageTwo.Name = "kgbStageTwo";
            // 
            // kgbStageTwo.Panel
            // 
            this.kgbStageTwo.Panel.Controls.Add(this.kbtnBrowseCompressedFileDirectory);
            this.kgbStageTwo.Panel.Controls.Add(this.ktxtCompressedFileDirectoryPath);
            this.kgbStageTwo.Panel.Controls.Add(this.klblCompressedFileDirectory);
            this.kgbStageTwo.Panel.Controls.Add(this.kbtnVarifyBackup);
            this.kgbStageTwo.Panel.Controls.Add(this.kbtnBackupProject);
            this.kgbStageTwo.Panel.Controls.Add(this.kchkCompressBackup);
            this.kgbStageTwo.Panel.Controls.Add(this.kbtnBrowseBackupDirectory);
            this.kgbStageTwo.Panel.Controls.Add(this.ktxtBackupDirectory);
            this.kgbStageTwo.Panel.Controls.Add(this.kryptonLabel2);
            this.kgbStageTwo.Size = new System.Drawing.Size(676, 183);
            this.kgbStageTwo.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgbStageTwo.TabIndex = 5;
            this.kgbStageTwo.Values.Heading = "Step 2: Backup Project";
            // 
            // kbtnBrowseCompressedFileDirectory
            // 
            this.kbtnBrowseCompressedFileDirectory.Enabled = false;
            this.kbtnBrowseCompressedFileDirectory.Location = new System.Drawing.Point(630, 59);
            this.kbtnBrowseCompressedFileDirectory.Name = "kbtnBrowseCompressedFileDirectory";
            this.kbtnBrowseCompressedFileDirectory.Size = new System.Drawing.Size(31, 26);
            this.kbtnBrowseCompressedFileDirectory.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnBrowseCompressedFileDirectory.TabIndex = 13;
            this.kbtnBrowseCompressedFileDirectory.Values.Text = "..&.";
            // 
            // ktxtCompressedFileDirectoryPath
            // 
            this.ktxtCompressedFileDirectoryPath.Enabled = false;
            this.ktxtCompressedFileDirectoryPath.Location = new System.Drawing.Point(255, 59);
            this.ktxtCompressedFileDirectoryPath.Name = "ktxtCompressedFileDirectoryPath";
            this.ktxtCompressedFileDirectoryPath.Size = new System.Drawing.Size(369, 26);
            this.ktxtCompressedFileDirectoryPath.StateCommon.Content.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktxtCompressedFileDirectoryPath.StateCommon.Content.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.ktxtCompressedFileDirectoryPath.TabIndex = 12;
            // 
            // klblCompressedFileDirectory
            // 
            this.klblCompressedFileDirectory.Enabled = false;
            this.klblCompressedFileDirectory.Location = new System.Drawing.Point(22, 61);
            this.klblCompressedFileDirectory.Name = "klblCompressedFileDirectory";
            this.klblCompressedFileDirectory.Size = new System.Drawing.Size(227, 22);
            this.klblCompressedFileDirectory.StateCommon.ShortText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblCompressedFileDirectory.TabIndex = 11;
            this.klblCompressedFileDirectory.Values.Text = "Compressed File Directory:";
            // 
            // kbtnVarifyBackup
            // 
            this.kbtnVarifyBackup.Enabled = false;
            this.kbtnVarifyBackup.Location = new System.Drawing.Point(455, 102);
            this.kbtnVarifyBackup.Name = "kbtnVarifyBackup";
            this.kbtnVarifyBackup.Size = new System.Drawing.Size(184, 26);
            this.kbtnVarifyBackup.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnVarifyBackup.TabIndex = 10;
            this.kbtnVarifyBackup.Values.Text = "V&erify Backup";
            this.kbtnVarifyBackup.Click += new System.EventHandler(this.kbtnVarifyBackup_Click);
            // 
            // kbtnBackupProject
            // 
            this.kbtnBackupProject.Enabled = false;
            this.kbtnBackupProject.Location = new System.Drawing.Point(250, 102);
            this.kbtnBackupProject.Name = "kbtnBackupProject";
            this.kbtnBackupProject.Size = new System.Drawing.Size(184, 26);
            this.kbtnBackupProject.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnBackupProject.TabIndex = 9;
            this.kbtnBackupProject.Values.Text = "&Backup Project";
            this.kbtnBackupProject.Click += new System.EventHandler(this.kbtnBackupProject_Click);
            // 
            // kchkCompressBackup
            // 
            this.kchkCompressBackup.Location = new System.Drawing.Point(57, 106);
            this.kchkCompressBackup.Name = "kchkCompressBackup";
            this.kchkCompressBackup.Size = new System.Drawing.Size(159, 22);
            this.kchkCompressBackup.StateCommon.ShortText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kchkCompressBackup.TabIndex = 8;
            this.kchkCompressBackup.Values.Text = "&Compress Backup";
            this.kchkCompressBackup.CheckedChanged += new System.EventHandler(this.kchkCompressBackup_CheckedChanged);
            // 
            // kbtnBrowseBackupDirectory
            // 
            this.kbtnBrowseBackupDirectory.Location = new System.Drawing.Point(630, 11);
            this.kbtnBrowseBackupDirectory.Name = "kbtnBrowseBackupDirectory";
            this.kbtnBrowseBackupDirectory.Size = new System.Drawing.Size(31, 26);
            this.kbtnBrowseBackupDirectory.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnBrowseBackupDirectory.TabIndex = 7;
            this.kbtnBrowseBackupDirectory.Values.Text = "..&.";
            this.kbtnBrowseBackupDirectory.Click += new System.EventHandler(this.KbtnBrowseBackupDirectory_Click);
            // 
            // ktxtBackupDirectory
            // 
            this.ktxtBackupDirectory.Location = new System.Drawing.Point(182, 11);
            this.ktxtBackupDirectory.Name = "ktxtBackupDirectory";
            this.ktxtBackupDirectory.Size = new System.Drawing.Size(442, 26);
            this.ktxtBackupDirectory.StateCommon.Content.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktxtBackupDirectory.StateCommon.Content.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.ktxtBackupDirectory.TabIndex = 6;
            this.ktxtBackupDirectory.TextChanged += new System.EventHandler(this.ktxtBackupDirectory_TextChanged);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(22, 13);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(154, 22);
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 5;
            this.kryptonLabel2.Values.Text = "Backup Directory:";
            // 
            // KryptonMainWindow
            // 
            this.ClientSize = new System.Drawing.Size(1133, 475);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonMainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kgbStageThree.Panel)).EndInit();
            this.kgbStageThree.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kgbStageThree)).EndInit();
            this.kgbStageThree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kgbStageTwo.Panel)).EndInit();
            this.kgbStageTwo.Panel.ResumeLayout(false);
            this.kgbStageTwo.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kgbStageTwo)).EndInit();
            this.kgbStageTwo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        BackgroundWorker _worker = new BackgroundWorker(), _populateFiles = new BackgroundWorker(), _findAndReplaceWorker = new BackgroundWorker();

        List<string> _fileList = new List<string>();

        #region Constructor
        public KryptonMainWindow()
        {
            InitializeComponent();

            _worker.WorkerSupportsCancellation = true;

            _worker.WorkerReportsProgress = true;

            _worker.ProgressChanged += worker_ProgressChanged;

            _worker.RunWorkerCompleted += worker_RunWorkerCompleted;

            _worker.DoWork += worker_DoWork;

            _populateFiles.WorkerSupportsCancellation = true;

            _populateFiles.WorkerReportsProgress = true;

            _populateFiles.DoWork += populateFiles_DoWork;

            _populateFiles.ProgressChanged += populateFiles_ProgressChanged;

            _populateFiles.RunWorkerCompleted += populateFiles_RunWorkerCompleted;

            _findAndReplaceWorker.WorkerSupportsCancellation = true;

            _findAndReplaceWorker.WorkerReportsProgress = true;

            _findAndReplaceWorker.DoWork += findAndReplaceWorker_DoWork;

            _findAndReplaceWorker.ProgressChanged += findAndReplaceWorker_ProgressChanged;

            _findAndReplaceWorker.RunWorkerCompleted += findAndReplaceWorker_RunWorkerCompleted;
        }
        #endregion

        private void kbtnBrowseProjectDirectory_Click(object sender, EventArgs e)
        {
            ktxtProjectPath.Text = GetDirectoryPath("Browse for a Project:");
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < klbProjectFiles.Items.Count; i++)
            {
                Backup(klbProjectFiles.Items[i].ToString(), ktxtBackupDirectory.Text + "\\" + Path.GetFileName(klbProjectFiles.Items[i].ToString()));

                SetCurrentStatus($"Copying file '{ klbProjectFiles.Items[i].ToString() }', { tspCopyProgress.Value }%");
            }
        }

        private void SetCurrentStatus(string text) => tsslCurrentStatus.Text = text;

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tspCopyProgress.Value = 0;

            tspCopyProgress.Visible = false;

            if (TaskbarManager.IsPlatformSupported)
            {
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);

                TaskbarManager.Instance.SetProgressValue(0, 100);
            }

            _worker.Dispose();

            kgbStageThree.Enabled = true;
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            tspCopyProgress.Visible = true;

            tspCopyProgress.Value = e.ProgressPercentage;

            if (TaskbarManager.IsPlatformSupported)
            {
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);

                TaskbarManager.Instance.SetProgressValue(e.ProgressPercentage, tspCopyProgress.Maximum);
            }

            _worker.Dispose();

            kbtnBackupProject.Enabled = false;

            kbtnVarifyBackup.Enabled = true;
        }

        private void populateFiles_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tspCopyProgress.Value = 0;

            tspCopyProgress.Visible = false;

            if (TaskbarManager.IsPlatformSupported)
            {
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);

                TaskbarManager.Instance.SetProgressValue(0, 100);
            }

            _populateFiles.Dispose();
        }

        private void populateFiles_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (tspCopyProgress.Value != 100)
            {
                tspCopyProgress.Visible = true;

                tspCopyProgress.Value = e.ProgressPercentage;

                if (TaskbarManager.IsPlatformSupported)
                {
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);

                    TaskbarManager.Instance.SetProgressValue(e.ProgressPercentage, tspCopyProgress.Maximum);
                }
            }
        }

        private void populateFiles_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Directory.Exists(ktxtProjectPath.Text)) Utilities.PopulateListBox(klbProjectFiles, ktxtProjectPath.Text);
        }

        private static string GetDirectoryPath(string title)
        {
            CommonOpenFileDialog openFileDialog = new CommonOpenFileDialog();

            openFileDialog.IsFolderPicker = true;

            openFileDialog.Title = title;

            if (openFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                return Path.GetFullPath(openFileDialog.FileName);
            }
            else
            {
                return string.Empty;
            }
        }

        private void KbtnBrowseBackupDirectory_Click(object sender, EventArgs e) => ktxtBackupDirectory.Text = GetDirectoryPath("Browse for a Backup Directory");

        private void ktxtProjectDirectory_TextChanged(object sender, EventArgs e) => kgbStageTwo.Enabled = klbProjectFiles.Items.Count > 0;

        private void Backup(string source, string target, bool overwrite = false)
        {
            FileStream fileStreamOut = new FileStream(target, FileMode.Create), fileStreamIn = new FileStream(source, FileMode.Open);

            byte[] b = new byte[1048756];

            int readBytes;

            while ((readBytes = fileStreamIn.Read(b, 0, b.Length)) > 0)
            {
                fileStreamOut.Write(b, 0, readBytes);

                _worker.ReportProgress((int)(fileStreamIn.Position * 100 / fileStreamIn.Length));
            }

            fileStreamIn.Close();

            fileStreamOut.Close();
        }

        private void kbtnBackupProject_Click(object sender, EventArgs e)
        {
            _worker.RunWorkerAsync();

            //#if !NET40
            //            if (kchkCompressBackup.Checked)
            //            {
            //                if (!string.IsNullOrEmpty(ktxtCompressedFileDirectoryPath.Text))
            //                {
            //                    ZipFile.CreateFromDirectory(ktxtBackupDirectory.Text, ktxtCompressedFileDirectoryPath.Text);
            //                }
            //            }
            //#endif
        }

        private void ktxtProjectPath_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(ktxtProjectPath.Text))
            {
                //_populateFiles.RunWorkerAsync();

                Utilities.PopulateFileList(_fileList, ktxtProjectPath.Text);

                Utilities.PopulateListBox(klbProjectFiles, _fileList);

                kgbStageTwo.Enabled = true;
            }
        }

        private void klbProjectFiles_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();

            tt.SetToolTip(klbProjectFiles, klbProjectFiles.SelectedItem.ToString());
        }

        private void klbProjectFiles_MouseEnter(object sender, EventArgs e)
        {
            if (klbProjectFiles.SelectedItem == null)
            {
                return;
            }
            else
            {
                klbProjectFiles.ToolTipValues.Description = klbProjectFiles.SelectedItem.ToString();
            }
        }

        private void kbtnClose_Click(object sender, EventArgs e)
        {

        }

        private void kbtnMigrateProject_Click(object sender, EventArgs e)
        {
            _findAndReplaceWorker.RunWorkerAsync();
        }

        private void ktxtBackupDirectory_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(ktxtBackupDirectory.Text))
            {
                kchkCompressBackup.Enabled = true;

                kbtnBackupProject.Enabled = true;
            }
        }

        private void findAndReplaceWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tspCopyProgress.Value = 0;

            tspCopyProgress.Visible = false;

            if (TaskbarManager.IsPlatformSupported)
            {
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);

                TaskbarManager.Instance.SetProgressValue(0, 100);
            }

            _findAndReplaceWorker.Dispose();
        }

        private void findAndReplaceWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (tspCopyProgress.Value != 100)
            {
                tspCopyProgress.Visible = true;

                tspCopyProgress.Value = e.ProgressPercentage;

                if (TaskbarManager.IsPlatformSupported)
                {
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);

                    TaskbarManager.Instance.SetProgressValue(e.ProgressPercentage, tspCopyProgress.Maximum);
                }
            }
        }

        private void kchkCompressBackup_CheckedChanged(object sender, EventArgs e)
        {
            EnableCompressedFileDirectoryControls(kchkCompressBackup.Checked);
        }

        private void findAndReplaceWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Utilities.FindAndReplaceInFiles(ktxtProjectPath.Text, "ComponentFactory.Krypton.Docking", "Krypton.Docking");

            Utilities.FindAndReplaceInFiles(ktxtProjectPath.Text, "ComponentFactory.Krypton.Navigator", "Krypton.Navigator");

            Utilities.FindAndReplaceInFiles(ktxtProjectPath.Text, "ComponentFactory.Krypton.Ribbon", "Krypton.Ribbon");

            Utilities.FindAndReplaceInFiles(ktxtProjectPath.Text, "ComponentFactory.Krypton.Toolkit", "Krypton.Toolkit");

            Utilities.FindAndReplaceInFiles(ktxtProjectPath.Text, "ComponentFactory.Krypton.Workspace", "Krypton.Workspace");
        }

        private void kbtnVarifyBackup_Click(object sender, EventArgs e)
        {
            Process.Start(ktxtBackupDirectory.Text);
        }

        private void UpdateStatus(string text) => tsslCurrentStatus.Text = text;

        private void EnableCompressedFileDirectoryControls(bool value)
        {
            klblCompressedFileDirectory.Enabled = value;

            ktxtCompressedFileDirectoryPath.Enabled = value;

            kbtnBrowseCompressedFileDirectory.Enabled = value;
        }
    }
}