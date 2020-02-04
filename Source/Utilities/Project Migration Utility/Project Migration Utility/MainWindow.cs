using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnBrowseProjectDirectory_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog cofd = new CommonOpenFileDialog();

            cofd.IsFolderPicker = true;

            cofd.Title = "Browse for a Project Directory:";

            if (cofd.ShowDialog() == CommonFileDialogResult.Ok) txtProjectDirectory.Text = Path.GetFullPath(cofd.FileName);
        }
    }
}
