using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ProjectMigrationUtility
{
    /// <summary></summary>
    internal class Utilities
    {
        int _fileCounter = 0, _diectoryCounter = 0, _replacedTextCounter = 0;

        /// <summary>A temporary list.</summary>
        List<string> _tempList = null;

        /// <summary>Initializes a new instance of the <see cref="Utilities"/> class.</summary>
        public Utilities()
        {

        }

        /// <summary>Compresses the files.</summary>
        /// <param name="input">The input.</param>
        /// <param name="output">The output.</param>
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

        /// <summary>Populates the ListBox.</summary>
        /// <param name="listBox">The list box.</param>
        /// <param name="directory">The directory.</param>
        public static void PopulateListBox(KryptonListBox listBox, string directory)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directory);

            FileInfo[] fileInfo = directoryInfo.GetFiles();

            foreach (FileInfo item in fileInfo)
            {
                listBox.Items.Add(item);
            }
        }

        /// <summary>Populates the ListBox.</summary>
        /// <param name="listBox">The list box.</param>
        /// <param name="fileListing">The file listing.</param>
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
                KryptonMessageBox.Show("There are currently no items in the list/directory.", "Empty List", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>Populates the file list.</summary>
        /// <param name="fileListing">The file listing.</param>
        /// <param name="directory">The directory.</param>
        /// <exception cref="ArgumentNullException">Happens when fileListing is null or empty.</exception>
        public static void PopulateFileList(List<string> fileListing, string directory)
        {
            if (fileListing == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                string[] contents = Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories);

                foreach (string item in contents)
                {
                    fileListing.Add(item);
                }
            }
        }

        /// <summary>Sets the list.</summary>
        /// <param name="list">The list.</param>
        public void SetList(List<string> list) => _tempList = list;

        /// <summary>Gets the list.</summary>
        /// <returns>The list of values.</returns>
        public List<string> GetList() => _tempList;

        /// <summary>Finds the and replace in files.</summary>
        /// <param name="projectDirectory">The project directory.</param>
        /// <param name="originalString">The original string.</param>
        /// <param name="replacementString">The replacement string.</param>
        /// <param name="fileExtensionMask">The file extension mask.</param>
        public static void FindAndReplaceInFiles(string projectDirectory, string originalString, string replacementString, string fileExtensionMask = "cs")
        {
            try
            {
                string[] files = Directory.GetFiles(projectDirectory, $"*.{ fileExtensionMask }", SearchOption.AllDirectories);

                foreach (string file in files)
                {
                    try
                    {
                        string contents = File.ReadAllText(file);

                        contents = contents.Replace(originalString, replacementString);

                        // Make files writable
                        File.SetAttributes(file, FileAttributes.Normal);

                        File.WriteAllText(file, contents);
                    }
                    catch (Exception e1)
                    {
                        KryptonMessageBox.Show($"Error: { e1 }", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception e2)
            {
                KryptonMessageBox.Show($"Error: { e2 }", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Counts the files.</summary>
        /// <param name="path">The path.</param>
        public static void CountFiles(string path)
        {
            Utilities utilities = new Utilities();

            utilities.SetFileCounter(Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Count());
        }

        /// <summary>Counts the directories.</summary>
        /// <param name="path">The path.</param>
        public static void CountDirectories(string path)
        {
            Utilities utilities = new Utilities();

            utilities.SetDirectoryCounter(Directory.GetDirectories(path, "*", SearchOption.AllDirectories).Count());
        }

        public static void UpdateStatus(ToolStripLabel label, string text) => label.Text = text;

        /// <summary>Gets the name of the directory.</summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static string GetDirectoryName(string path) => Path.GetDirectoryName(path);

        /// <summary>Sets the file counter.</summary>
        /// <param name="value">The value.</param>
        public void SetFileCounter(int value) => _fileCounter = value;

        /// <summary>Gets the file counter.</summary>
        /// <returns>The number of files.</returns>
        public int GetFileCounter() => _fileCounter;

        /// <summary>Sets the directory counter's value.</summary>
        /// <param name="value">The value of the directory counter.</param>
        public void SetDirectoryCounter(int value) => _diectoryCounter = value;

        /// <summary>Gets the directory counter value.</summary>
        /// <returns>The value of _diectoryCounter.</returns>
        public int GetDirectoryCounter() => _diectoryCounter;
    }
}