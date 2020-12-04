
namespace FileWatcherLibrary
{
    class FileActionOptions
    {
        public static string sourceDirectoryPath = Manager.GetOptions().sourceDirectoryPath;
        public static string targetDirectoryPath = Manager.GetOptions().targetDirectoryPath;        
        public static string targetArchivePath = Manager.GetOptions().targetArchivePath;
    }
}
