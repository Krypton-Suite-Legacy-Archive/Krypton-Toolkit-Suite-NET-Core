using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ProjectMigrationUtility
{
    public partial class MainWindowOld : Form
    {
        BackgroundWorker worker = new BackgroundWorker();

        public MainWindowOld()
        {
            InitializeComponent();

            worker.WorkerSupportsCancellation = true;

            worker.WorkerReportsProgress = true;

            worker.DoWork += Worker_DoWork;

            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;

            worker.ProgressChanged += Worker_ProgressChanged;
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            tspbCopyFiles.Value = e.ProgressPercentage;
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {

            }
            else
            {
                btnStartBackup.Enabled = false;

                btnVerifyBackup.Enabled = true;
            }
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Backup(txtProjectDirectory.Text, txtBackupDirectory.Text);
        }

        private void btnBrowseProjectDirectory_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog cofd = new CommonOpenFileDialog();

            cofd.IsFolderPicker = true;

            cofd.Title = "Browse for a Project Directory:";

            if (cofd.ShowDialog() == CommonFileDialogResult.Ok) txtProjectDirectory.Text = Path.GetFullPath(cofd.FileName);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnStartBackup_Click(object sender, EventArgs e)
        {
            //worker.RunWorkerAsync();

            CopyFiles copyFiles = new CopyFiles(txtProjectDirectory.Text, txtBackupDirectory.Text);

            CopyFilesWindow copyFilesWindow = new CopyFilesWindow();

            copyFilesWindow.SynchronizationObject = this;

            copyFiles.CopyAsync(copyFilesWindow);
        }

        private void btnVerifyBackup_Click(object sender, EventArgs e)
        {
            Process.Start(txtBackupDirectory.Text);
        }

        private void btnStartMigration_Click(object sender, EventArgs e)
        {

        }

        private static void Backup(string sourcePath, string targetPath)
        {
            MainWindowOld window = new MainWindowOld();

            DirectoryInfo source = new DirectoryInfo(sourcePath), target = new DirectoryInfo(targetPath);

            if (!source.Exists) return;

            if (!target.Exists) target.Create();

            FileInfo[] sourceFiles = source.GetFiles();

            for (int i = 0; i < sourceFiles.Length; ++i)
            {
                File.Copy(sourceFiles[i].FullName, target.FullName + "\\" + sourceFiles[i].Name, true);
            }

            DirectoryInfo[] sourceDirectories = source.GetDirectories();

            for (int j = 0; j < sourceDirectories.Length; ++j)
            {
                Backup(sourceDirectories[j].FullName, target.FullName + "\\" + sourceDirectories[j].Name);
            }

            //? if (window.chkCompressFiles.Checked) ZipFile.CreateFromDirectory(sourcePath, targetPath + ".zip");
        }

        private void btnBrowseBackupDirectory_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog cofd = new CommonOpenFileDialog();

            cofd.IsFolderPicker = true;

            cofd.Title = "Browse for a Backup Directory:";

            if (cofd.ShowDialog() == CommonFileDialogResult.Ok) txtBackupDirectory.Text = Path.GetFullPath(cofd.FileName);

            btnStartBackup.Enabled = true;
        }
    }
}
