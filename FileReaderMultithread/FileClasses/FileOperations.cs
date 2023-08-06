using FileReaderMultithread.FileClasses;
using System.IO;

namespace FileReaderMultithread.Utilities
{
    public abstract class FileOperations : FileOperationsInterface
    {
        protected string FileName { get; set; }
        protected string[] Delimiter { get; set; }

        protected string Extension { get;set; }

        public FileOperations(string fileName)
        {
            FileName = fileName;
        }

        object FileOperationsInterface.ReadFileToObject()
        {
            return ReadFileToObject();
        }

        public abstract object ReadFileToObject();

        public int GetFileCountInDirectory(string workingDirectory)
        {
            int countOfFiles = 0;

            if (Directory.Exists(workingDirectory)){
                countOfFiles = Directory.GetFiles(workingDirectory, Extension,SearchOption.TopDirectoryOnly).Length;
            }

            return countOfFiles;
        }
         
    }
}
