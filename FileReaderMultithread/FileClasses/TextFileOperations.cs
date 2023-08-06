using FileReaderMultithread.Utilities;
using System;

namespace FileReaderMultithread.FileClasses
{
    public class TextFileOperations : FileOperations
    {
        public TextFileOperations(string fileName, string extension) : base(fileName)
        {
            this.Extension = extension;
        }

        public override object ReadFileToObject()
        {
            return new object();
        }
    }
}
