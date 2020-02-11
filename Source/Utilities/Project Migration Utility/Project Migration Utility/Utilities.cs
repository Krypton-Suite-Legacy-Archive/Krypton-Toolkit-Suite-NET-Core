using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ProjectMigrationUtility
{
    internal class Utilities
    {
        List<string> _tempList = null;

        public Utilities()
        {

        }

        public static void CompressFiles(string input, string output)
        {
            Compression.Compress.LZMA.Encoder encoder = new Compression.Compress.LZMA.Encoder();

            using (FileStream fs = new FileStream(input, FileMode.Open))
            {
                using (FileStream stream = new FileStream(output, FileMode.Create))
                {
                    encoder.Code(fs, stream, -1, -1, null);

                    stream.Flush();
                }
            }
        }

        public static void PopulateListBox(KryptonListBox listBox, string directory)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directory);

            FileInfo[] fileInfo = directoryInfo.GetFiles();

            foreach (FileInfo item in fileInfo)
            {
                listBox.Items.Add(item);
            }
        }

        public static void PopulateListBox(KryptonListBox listBox, List<string> fileListing)
        {
            if (fileListing.Count > 0)
            {
                foreach (string item in fileListing)
                {
                    listBox.Items.Add(item);
                }
            }
            else
            {
                KryptonMessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static void PopulateFileList(List<string> fileListing, string directory)
        {
            if (fileListing == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(directory);

                FileInfo[] fileInfo = directoryInfo.GetFiles();

                foreach (FileInfo file in fileInfo)
                {
                    fileListing.Add(file.ToString());
                }
            }
        }

        public void SetList(List<string> list) => _tempList = list;

        public List<string> GetList() => _tempList;
    }
}