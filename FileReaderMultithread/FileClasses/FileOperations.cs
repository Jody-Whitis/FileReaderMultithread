using FileReaderMultithread.Enums;
using FileReaderMultithread.FileClasses;
using System;
using System.IO;

namespace FileReaderMultithread.Utilities
{
    public abstract class FileOperations : FileOperationsInterface
    {
        protected FileIOInterface FileIOInstance { get; set; }

        protected string FilePath { get; set; }

        protected string FileName { get; set; }

        protected string[] Delimiter { get; set; }

        public string Extension { get; set; }

        public FileOperations(string fileName, string extensions, string[] delimiter, FileIOInterface mockFileIO)
        {
            FileName = fileName;
            Extension = extensions;
            Delimiter = delimiter;
            FileIOInstance = mockFileIO;
        }

        public FileOperations(string fileName, string extensions, string[] delimiter)
        {
            FileName = fileName;
            Extension = extensions;
            Delimiter = delimiter;
            FileIOInstance = new FileIORealOperations();
        }

        public FileOperations(string filePath)
        {

            FilePath = filePath;
            FileIOInstance = new FileIORealOperations();

        }

        public FileOperations()
        {

        }

        object FileOperationsInterface.ReadFileToObject()
        {
            return ReadFileToObject();
        }

        public abstract object ReadFileToObject();

        
        public int MoveFile(string filePath, string destinationPath)
        {
            int fileStatus = Convert.ToInt32(FileOperationStatus.DefaultStatus);

            try
            {

                if (!FileIOInstance.DirectoryExists(Path.GetDirectoryName(destinationPath)))
                {

                    FileIOInstance.CreateDirectory(Path.GetDirectoryName(destinationPath));

                }

                if (!FileIOInstance.FileExists(filePath))
                {

                    fileStatus = Convert.ToInt32(FileOperationStatus.FileSourceDoesNotExists);

                }

                else if (!FileIOInstance.FileExists(destinationPath))
                {

                    FileIOInstance.FileMove(filePath, destinationPath);

                    fileStatus = Convert.ToInt32(FileOperationStatus.FileMoved);

                }

                else
                {

                    fileStatus = Convert.ToInt32(FileOperationStatus.FileDestinationExistsNotMoved);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                fileStatus = Convert.ToInt32(FileOperationStatus.FileError);

            }

            return fileStatus;
        }

        public int GetFileCountInDirectory(string workingDirectory)
        {
            int countOfFiles = 0;

            if (FileIOInstance.DirectoryExists(workingDirectory))
            {
                countOfFiles = FileIOInstance.DirectoryGetFiles(workingDirectory, $"*{Extension}").Length;
            }

            return countOfFiles;
        }
    }
}
