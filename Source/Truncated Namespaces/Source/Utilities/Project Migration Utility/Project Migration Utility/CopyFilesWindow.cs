using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectMigrationUtility
{
    public partial class CopyFilesWindow : Form, ICopyFilesDiag
    {
        public ISynchronizeInvoke SynchronizationObject { get; set; }

        public CopyFilesWindow()
        {
            InitializeComponent();
        }

        public void Update(Int32 totalFiles, Int32 copiedFiles, Int64 totalBytes, Int64 copiedBytes, String currentFilename)
        {
            pbTotalFiles.Maximum = totalFiles;

            pbTotalFiles.Value = copiedFiles;
            
            pbTotalFiles.Maximum = 100;

            if (totalBytes != 0)
            {
                pbCurrentFile.Value = Convert.ToInt32((100f / (totalBytes / 1024f)) * (copiedBytes / 1024f));
            }

            lblTotalFiles.Text = "Total files (" + copiedFiles + "/" + totalFiles + ")";
            
            lblCurrentFile.Text = currentFilename;

            if (TaskbarManager.IsPlatformSupported)
            {
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);

                TaskbarManager.Instance.SetProgressValue(pbTotalFiles.Value, pbTotalFiles.Maximum);
            }
        }

        private void CopyFilesWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            RaiseCancel();
        }

        private void RaiseCancel()
        {
            if (EN_cancelCopy != null) EN_cancelCopy();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            RaiseCancel();
        }

        public event CopyFiles.DEL_cancelCopy EN_cancelCopy;
    }
}
