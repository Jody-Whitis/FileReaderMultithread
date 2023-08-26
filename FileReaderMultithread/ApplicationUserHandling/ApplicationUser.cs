using FileReaderMultithread.Enums;
using FileReaderMultithread.FileClasses;
using System;
using System.Collections.Generic;

namespace FileReaderMultithread.ApplicationUserHandling
{
    public class ApplicationUser
    {

        protected FileIOInterface FileIOInstance { get; set; }

        protected ConsoleInterface ConsoleInstance { get; set; }

        protected int UserInputLimit { get; set; } = 100;

        public static readonly string USERWELCOME = "Welcome!\r\n\r\nKeywords:\r\n[*]'confirm' to finish input." +
            "\r\n[*]'restartinput' to clear current input. " +
            "\r\n[*]'quit' to end application\r\n";

        public ApplicationUser()
        {
            FileIOInstance = new FileIORealOperations();
        }

        public ApplicationUser(int userInputLimit)
        {
            this.UserInputLimit = userInputLimit;
            FileIOInstance = new FileIORealOperations();
            ConsoleInstance = new ConsoleSystemReal();
        }

        public ApplicationUser(int userInputLimit, FileIOInterface fileIOInstance, ConsoleInterface consoleInterface)
        {
            this.UserInputLimit = userInputLimit;
            this.FileIOInstance = fileIOInstance;
            this.ConsoleInstance = consoleInterface;
        }
       
        public HashSet<string> GetDirectoriesFromUser()
        {
            HashSet<string> directories = new HashSet<string>();

            Console.WriteLine("\r\n\r\nEnter Directories to Process:");

            string userInput = ConsoleInstance.ConsoleReadLine();

            int inputCounter = 1;

            while ((userInput.ToUpper() != UserPrompts.ConfirmInput)
                && (inputCounter <= UserInputLimit))
            {
                inputCounter++;

                ProcessDirectoryInput(ref directories, userInput);

                Console.WriteLine($"\r\n\r\nEnter Directories to Process:");

                userInput = ConsoleInstance.ConsoleReadLine();

            }

            return directories;

        }

        protected void ProcessDirectoryInput(ref HashSet<string> directoryList, string userInput)
        {
           
            if (userInput.ToUpper().Equals(UserPrompts.RestartInput))
            {
                Console.WriteLine("Directory List Cleared!");

                directoryList.Clear();

            }

            else if (userInput.ToUpper().Equals(UserPrompts.QuitApplication))
            {

                QuitApplication();

            }
            else
            {

                ValidateDirectory(ref directoryList, userInput);

            }

        }

        protected void ValidateDirectory(ref HashSet<string> directoryList, string directory)
        {
            if (FileIOInstance.DirectoryExists(directory))
            {

                directoryList.Add(directory);

                Console.WriteLine("Directory Added!");


            }
            else
            {

                Console.WriteLine("Directory Does Not Exist!, Skipping");
                
            }
        }

        public void QuitApplication()
        {
            Console.WriteLine("Quitting app...");
            Console.ReadLine();
            Environment.Exit(0);
        }

    }
}
