using FileReaderMultithread.Enums;
using FileReaderMultithread.FileClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FileReaderMultithread
{
    public class Program
    {
        public static int TotalCount { get; set; }

        public static int DoneCount { get; set; }

        public static readonly object lockCompleted = new object();

        static void Main(string[] args)
        {

            try
            {

                ProcessMoveFilesTasks();
                
                Console.ReadKey();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                Environment.Exit(1);
            }

        }


        static void ProcessMoveFiles()
        {
            string directory1 = "C:\\Users\\chick\\Documents\\FileReaderTest";
            string directory2 = "C:\\Users\\chick\\Documents\\FileReaderTest\\1";
            string directory3 = "C:\\Users\\chick\\Documents\\FileReaderTest\\2";

            TotalCount += Directory.GetFiles(directory1).Count();
            TotalCount += Directory.GetFiles(directory2).Count();
            TotalCount += Directory.GetFiles(directory3).Count();

            Stopwatch fileMoveTime = new Stopwatch();

            fileMoveTime.Start();

            FileMove(directory1);
            FileMove(directory2);
            FileMove(directory3);

 
            fileMoveTime.Stop();

            Console.WriteLine($"{DoneCount} of {TotalCount} done successfully in {fileMoveTime.ElapsedMilliseconds} miliseconds!");
         }

        static void ProcessMoveFilesTasks()
        {
            string directory1 = "C:\\Users\\chick\\Documents\\FileReaderTest";
            string directory2 = "C:\\Users\\chick\\Documents\\FileReaderTest\\1";
            string directory3 = "C:\\Users\\chick\\Documents\\FileReaderTest\\2";

            TotalCount += Directory.GetFiles(directory1).Count();
            TotalCount += Directory.GetFiles(directory2).Count();
            TotalCount += Directory.GetFiles(directory3).Count();


            List<Task> tasks = new List<Task>();

            tasks.Add(Task.Run(() => FileMove(directory1)));
            tasks.Add(Task.Run(() => FileMove(directory2)));
            tasks.Add(Task.Run(() => FileMove(directory3)));

            Stopwatch fileMoveTime = new Stopwatch();

            fileMoveTime.Start();
       
            Task.WaitAll(tasks.ToArray());

            fileMoveTime.Stop();

            Console.WriteLine($"{DoneCount} of {TotalCount} done successfully in {fileMoveTime.ElapsedMilliseconds} miliseconds!");
         }

        static void FileMove(string workingDirectory)
        {
            
                TextFileOperations textOperations = new TextFileOperations(workingDirectory);

                string[] files = Directory.GetFiles(workingDirectory);

                foreach (string fileSelected in files)
                {
                    string destination = string.Concat(Path.GetDirectoryName(fileSelected), $"\\Done\\{Path.GetFileName(fileSelected)}");

                    int fileMovedStatus = textOperations.MoveFile(fileSelected, destination);

                    Console.WriteLine($"{DateTime.Now} - {Enum.GetName(typeof(FileOperationStatus), fileMovedStatus)} - {Path.GetFileName(fileSelected)}");

                    DoneCount++;
                }
            
             
        }
    }
}
