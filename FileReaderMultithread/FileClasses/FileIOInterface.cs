
namespace FileReaderMultithread.FileClasses
{
    public interface FileIOInterface
    {
        void FileMove(string filePath, string destination);

        void CreateDirectory(string directory);

        bool DirectoryExists(string directory);

        bool FileExists(string filePath);

        string[] DirectoryGetFiles(string filepath, string searchPattern);
    }
}
