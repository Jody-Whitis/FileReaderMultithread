using FileReaderMultithread.FileClasses;

namespace FileReaderMultithread.Utilities
{
    public abstract class FileOperations : FileOperationsInterface
    {
        protected string FileName { get; set; }
        protected string[] Delimiter { get; set; }

        public FileOperations(string fileName)
        {
            FileName = fileName;
        }

        object FileOperationsInterface.ReadFileToObject()
        {
            return ReadFileToObject();
        }

        public abstract object ReadFileToObject();
    }
}
