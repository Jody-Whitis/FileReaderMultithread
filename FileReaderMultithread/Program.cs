using FileReaderMultithread.FileClasses;
using System; 

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

                TextFileOperations textOperations = new TextFileOperations(filePath,"txt");

                TotalCount = textOperations.GetFileCountInDirectory(filePath);

                int numberOfFilesFound = 0;
                //todo: move to class in seperate branch
                textOperations.MoveFile($"{filePath}\\test.txt");
                numberOfFilesFound = TotalCount;

                Console.WriteLine(numberOfFilesFound);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(1);
            }

        }
    }
}
