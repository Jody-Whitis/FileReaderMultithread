using FileReaderMultithread.Enums;
using FileReaderMultithread.FileClasses;
using System;
using System.IO;

namespace FileReaderMultithread
{
    public class Program
    {
        public static int TotalCount { get; set; }

        static void Main(string[] args)
        {
            try
            {
                string filePath = "C:\\Users\\chick\\Documents\\FileReaderTest";

                TextFileOperations textOperations = new TextFileOperations(filePath);

                TotalCount = textOperations.GetFileCountInDirectory(filePath);

                //todo: move to class in seperate branch
                string file = $"{filePath}\\test.txt";
                string destination = string.Concat(Path.GetDirectoryName(file), $"\\Done\\{Path.GetFileName(file)}");

                int fileMovedStatus = textOperations.MoveFile(file, destination);


                Console.WriteLine(Enum.GetName(typeof(FileOperationStatus),fileMovedStatus));

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                Environment.Exit(1);
            }

        }
    }
}
