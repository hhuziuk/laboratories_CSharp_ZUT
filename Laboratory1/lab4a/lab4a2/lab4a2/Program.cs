using System;
using System.IO;
using System.Windows.Forms;

namespace FotoAlbum
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
            {
                string sourceDirectory = "C:\\Users\\hh53872\\Desktop\\hzk";
                string destinationDirectory = folderBrowserDialog.SelectedPath;

                ProcessDirectory(sourceDirectory, destinationDirectory);
                MessageBox.Show("Zakoñczono kopiowanie plików jpg.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        static void ProcessDirectory(string sourceDirectory, string destinationDirectory)
        {
            string[] fileEntries = Directory.GetFiles(sourceDirectory);
            foreach (string fileName in fileEntries)
            {
                if (Path.GetExtension(fileName).ToLower() == ".jpg")
                {
                    string newFileName = GetNewFileName(fileName);
                    string destFile = Path.Combine(destinationDirectory, newFileName);
                    File.Copy(fileName, destFile, true);
                }
            }

            string[] subdirectoryEntries = Directory.GetDirectories(sourceDirectory);
            foreach (string subdirectory in subdirectoryEntries)
            {
                ProcessDirectory(subdirectory, destinationDirectory);
            }
        }

        static string GetNewFileName(string fileName)
        {
            DateTime creationTime = File.GetCreationTime(fileName);
            string formattedDate = creationTime.ToString("yyyyMMddHHmmss");
            string parentDirectoryName = new DirectoryInfo(Path.GetDirectoryName(fileName)).Name;
            string originalFileName = Path.GetFileNameWithoutExtension(fileName);
            string extension = Path.GetExtension(fileName);
            string newFileName = $"{formattedDate}_{parentDirectoryName}_{originalFileName}{extension}";
            return newFileName;
        }
    }
}
