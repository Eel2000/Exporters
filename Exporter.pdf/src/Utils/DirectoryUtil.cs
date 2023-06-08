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
        public static string CheckOrCreateReportFolder(string folderName = "PDF.Exporter")
        {
            var path = Path.Combine(Environment.GetFolderPath(_filePath), folderName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string realPath = path + "\"" + folderName + "\"" + $"{DateTime.Now.ToString(".dd.MM.yyyy")}.pdf";

            return realPath;
        }

        /// <summary>
        /// Open the specified path file in appropriate app.
        /// </summary>
        /// <param name="path"></param>
        /// <exception cref="AggregateException"></exception>
        public static void OpenFile(string path)
        {
            if (!File.Exists(path))
                throw new AggregateException("File not found. unable to open it. please check the whole process");
            
            var windowsProcess = new Process();
            windowsProcess.StartInfo = new ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = path
            };
            windowsProcess.Start();
        }
    }
}