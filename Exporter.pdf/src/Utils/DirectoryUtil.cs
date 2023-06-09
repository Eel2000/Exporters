using System;
using System.Diagnostics;
using System.IO;

namespace Exporter.pdf.Utils
{
    public static class DirectoryUtil
    {
        private static readonly Environment.SpecialFolder _filePath = Environment.SpecialFolder.Desktop;

        /// <summary>
        /// Create a default directory where to exports all files
        /// </summary>
        /// <param name="folderName">the folder name</param>
        /// <returns><see cref="string"/> the directory path.</returns>
        public static string CheckOrCreateReportFolder(string folderName = "PDF_Exporter")
        {
            var path = Path.Combine(Environment.GetFolderPath(_filePath), folderName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string realPath = path + "\\" + folderName + $"{DateTime.Now.ToString("dd_MM_yyyy")}.pdf";

            return realPath;
        }

        public static void CreateIfNotExist(string part, string folder)
            => Directory.CreateDirectory(Path.Combine(part, folder));

        /// <summary>
        /// Open the specified path file in its appropriate app.
        /// </summary>
        /// <param name="path"></param>
        /// <exception cref="AggregateException"></exception>
        public static void OpenFile(string path)
        {
            if (!File.Exists(path))
                throw new AggregateException("File not found. unable to open it.");

            var windowsProcess = new Process();
            windowsProcess.StartInfo = new ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = path, 
                ErrorDialog = true,
            };
            windowsProcess.Start();
        }
    }
}