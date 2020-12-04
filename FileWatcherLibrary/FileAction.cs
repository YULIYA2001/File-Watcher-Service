using System;
using System.IO;
using System.Threading;

namespace FileWatcherLibrary
{
    public class FileAction
    {        
        FileSystemWatcher watcher;
        object obj = new object();
        bool enabled = true;
        public FileAction()
        {
            string sourcePath = FileActionOptions.sourceDirectoryPath;
            if (!Directory.Exists(sourcePath))
            {
                Directory.CreateDirectory(sourcePath);
            }
            // Create a new FileSystemWatcher and set its properties.
            watcher = new FileSystemWatcher(sourcePath, "*.txt");

            // Add event handlers
            watcher.Created += Watcher_Created;
        }

        public void Start()
        {
            watcher.EnableRaisingEvents = true;
            while (enabled)
            {
                Thread.Sleep(1000);
            }
        }
        public void Stop()
        {
            watcher.EnableRaisingEvents = false;
            enabled = false;
        }

        // создание файлов
        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            string sourcePath = FileActionOptions.sourceDirectoryPath;
            string targetPath = FileActionOptions.targetDirectoryPath;
            string tarArchivePath = FileActionOptions.targetArchivePath;

            string path = e.FullPath;

            try
            {
                // определения времени создания файла, создание поддиректории archive\YYYY\MM\DD\ 
                DateTime date = File.GetCreationTime(path);
                string subPath = "";
                subPath = subPath + date.Year + '\\' + date.Month + '\\' + date.Day + '\\';
                DirectoryInfo directory = new DirectoryInfo(tarArchivePath);
                if (!directory.Exists)
                {
                    directory.Create();
                }
                directory.CreateSubdirectory(subPath);
                // зашифровка файла, архивирование, перемещение в TargetDirectory, удаление из SourceDirectory
                Encoder.Encrypt(path);
                string tarPath = path.Replace(sourcePath, targetPath);
                tarPath = tarPath.Replace(".txt", date.ToString("-yyyy_MM_dd_HH_mm_ss") + ".gz");
                Archiver.Compress(path, tarPath);
                File.Delete(path);
                // разархивация файла, расшифровывание
                string archivePath = tarPath.Replace(".gz", ".txt");
                archivePath = archivePath.Replace(targetPath, tarArchivePath + "\\" + subPath);
                Archiver.Decompress(tarPath, archivePath);
                Encoder.Decrypt(archivePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
