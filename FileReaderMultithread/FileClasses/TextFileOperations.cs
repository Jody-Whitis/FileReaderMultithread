using FileReaderMultithread.Enums;
using FileReaderMultithread.Utilities;
using System;

namespace FileReaderMultithread.FileClasses
{
    public class TextFileOperations : FileOperations
    {
        public TextFileOperations()
        {
        }

        public TextFileOperations(string filePath, string extension) : base(filePath)
        {
            Extension = extension;
        }

        public TextFileOperations(string filePath) : base(filePath)
        {
            Extension = FileTypeExtensions.TextFile;
        }

        public TextFileOperations(string fileName, string extension, string[] delimiters) : base(fileName, extension,delimiters)
        {

        }

        public override object ReadFileToObject()
        {
            return new object();
        }
    }
}
