using System.IO;

namespace FileReaderMultithread.FileClasses
{
    public class FileIORealOperations : FileIOInterface
    {
        public void CreateDirectory(string directory)
        {
            Directory.CreateDirectory(directory);
        }

        public bool DirectoryExists(string directory)
        {
            return Directory.Exists(directory);
        }

        public string[] DirectoryGetFiles(string filepath, string searchPattern)
        {
            return Directory.GetFiles(filepath, searchPattern);
        }

        public bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        public void FileMove(string filePath, string destination)
        {
            File.Move(filePath, destination);
        }
    }
}
