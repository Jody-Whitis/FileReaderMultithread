using System;

namespace FileReaderMultithread.ApplicationUserHandling
{
    public class ConsoleSystemReal: ConsoleInterface
    {
        public string ConsoleReadLine()
        {
            return Console.ReadLine();
        }
    }
}
