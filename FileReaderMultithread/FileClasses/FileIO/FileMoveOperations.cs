using FileReaderMultithread.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReaderMultithread.FileClasses.FileIO
{
    public class FileMoveTopLevelOperations
    {
        protected List<string> Directories { get; set; } = new List<string>();

        protected Boolean IsMultiThreaded { get; set; }

        protected FileIOInterface FileIOInstance { get; set; } = new FileIORealOperations();

        public int DoneCount { get; set; } = 0;

        readonly object lockCompleted = new object();

        public FileMoveTopLevelOperations()
        {
        }

        public FileMoveTopLevelOperations(bool isMultiThreaded, List<string> directories)
        {
            this.IsMultiThreaded = isMultiThreaded;
            this.Directories = directories;
        }

        public FileMoveTopLevelOperations(bool isMultiThreaded, List<string> directories, FileIOInterface fileOperations)
        {
            this.IsMultiThreaded = isMultiThreaded;
            this.Directories = directories;
            this.FileIOInstance = fileOperations;
        }

        public void RunFileMove(int totalCount)
        {
            try
            {
               
                Directories.ForEach(directory => totalCount += Directory.GetFiles(directory).Count());

                Stopwatch fileMoveTime = new Stopwatch();

                fileMoveTime.Start();

                ProcessFileMove();

                fileMoveTime.Stop();

                Console.WriteLine($"{DoneCount} / {totalCount} done successfully in {fileMoveTime.ElapsedMilliseconds} miliseconds!");

            }

            catch (Exception ex)
            {
                throw new Exception($"RunFileMove Failed! - {ex.ToString()}");
            }
        }

        public void ProcessFileMove()
        {
            if (IsMultiThreaded)
            {
                List<Task> tasks = new List<Task>();

                Directories.ForEach(directory => tasks.Add(Task.Run(() => FileMove(directory))));

                Task.WaitAll(tasks.ToArray());
            }

            else
            {
                Directories.ForEach(directory => FileMove(directory));
            }
        }

        public void FileMove(string workingDirectory)
        {

            lock (lockCompleted)
            {
                TextFileOperations textOperations = new TextFileOperations(workingDirectory);

                string[] files = Directory.GetFiles(workingDirectory);

                foreach (string fileSelected in files)
                {
                    string destination = string.Concat(Path.GetDirectoryName(fileSelected), $"\\Done\\{Path.GetFileName(fileSelected)}");

                    int fileMovedStatus = textOperations.MoveFile(fileSelected, destination);

                    Console.WriteLine($"{DateTime.Now} - [{Enum.GetName(typeof(FileOperationStatus), fileMovedStatus)}] : {Path.GetFileName(fileSelected)}");

                    DoneCount++;
                }


            }

        }

    }
}
