using FileReaderMultithread.ApplicationUserHandling;
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
                ApplicationUser applicationUser = new ApplicationUser(50);
                Console.WriteLine(ApplicationUser.USERWELCOME);
                HashSet<string> directories = applicationUser.GetDirectoriesFromUser();
            
                FileMoveTopLevelOperations fileMoveOperations = new FileMoveTopLevelOperations(true, directories.ToList());
                Console.WriteLine("Processing File Move to the Done folder");
                fileMoveOperations.RunFileMove(TotalCount);

                
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                Environment.Exit(1);
            }
            finally
            {

                Console.WriteLine("Exiting Applicaation..");

                Console.ReadKey();

            }

        }

       
    }
}
