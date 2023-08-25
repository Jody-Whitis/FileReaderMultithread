using FileReaderMultithread.FileClasses.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FileReaderMultithread
{
    public class Program
    {
        public static int TotalCount { get; set; }

        static void Main(string[] args)
        {

            try
            {
                List<string> directories = new List<string> { };
                directories.Add("C:\\Users\\chick\\Documents\\FileReaderTest");
                directories.Add("C:\\Users\\chick\\Documents\\FileReaderTest\\1");
                directories.Add("C:\\Users\\chick\\Documents\\FileReaderTest\\2");

                FileMoveTopLevelOperations fileMoveOperations = new FileMoveTopLevelOperations(true, directories);
                fileMoveOperations.RunFileMove(TotalCount);

                Console.ReadKey();

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                Environment.Exit(1);
            }

        }

       
    }
}
