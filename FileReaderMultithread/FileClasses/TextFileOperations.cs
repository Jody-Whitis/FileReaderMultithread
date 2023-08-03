using FileReaderMultithread.Utilities;
using System;

namespace FileReaderMultithread.FileClasses
{
    public class TextFileOperations : FileOperations
    {
        public TextFileOperations(string fileName) : base(fileName)
        {
        }

        public override object ReadFileToObject()
        {
            return new object();
        }
    }
}
