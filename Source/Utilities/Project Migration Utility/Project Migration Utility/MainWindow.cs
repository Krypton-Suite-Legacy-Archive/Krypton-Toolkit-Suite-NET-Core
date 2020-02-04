using ComponentFactory.Krypton.Toolkit;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectMigrationUtility
{
    public partial class MainWindow : Form
    {
        BackgroundWorker worker = new BackgroundWorker();

        public MainWindow()
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
