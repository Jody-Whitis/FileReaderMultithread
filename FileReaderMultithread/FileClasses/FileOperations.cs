using FileReaderMultithread.FileClasses;
using System;
using System.IO;
 
namespace FileReaderMultithread.Utilities
{
    public abstract class FileOperations : FileOperationsInterface
    {
        protected string FilePath { get; set; }
        protected string FileName { get; set; }
        protected string[] Delimiter { get; set; }
        public string Extension { get;set; }

        public FileOperations(string fileName, string extensions, string[] delimiter)
        {
            FileName = fileName;
            Extension = extensions;
            Delimiter = delimiter;
        }

        public FileOperations(string filePath)
        {
            FilePath = filePath;
        }

        public FileOperations()
        {

        }

        object FileOperationsInterface.ReadFileToObject()
        {
            return ReadFileToObject();
        }

        public abstract object ReadFileToObject();

        public Boolean MoveFile(string fileName)
        {
            try
            {
                string fileDestination = string.Concat(FilePath,$"\\Done");

                if (!File.Exists(fileDestination))
                {
                    Directory.CreateDirectory(fileDestination);
                }
               
                File.Move(fileName, fileDestination);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;

            }
        } 

        public int GetFileCountInDirectory(string workingDirectory)
        {
            int countOfFiles = 0;

            if (Directory.Exists(workingDirectory)){
                countOfFiles = Directory.GetFiles(workingDirectory, $"*{Extension}").Length;
            }

            return countOfFiles;
        }
         
    }
}
