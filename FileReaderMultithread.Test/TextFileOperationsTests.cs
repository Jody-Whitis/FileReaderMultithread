using FileReaderMultithread.FileClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace FileReaderMultithread.Test
{
    [TestClass]
    public class TextFileOperationsTests : FileOperationsInterface
    {
        protected Dictionary<string,string> MockFileDirectory {get;set;}
    
        [TestMethod]
        public void ReadFileTests()
        {
            TextFileOperations textFileOperations = new TextFileOperations("mockFile.txt","txt");
            Assert.IsNotNull(textFileOperations.ReadFileToObject());
        }

        [Ignore("Insert expected filecount per machine")]
        [DataRow("q:\\",0)]
        [TestMethod]
        public void GetFileCountInDirectoryTest(string workingDirectory, int expectedCount)
        {
            TextFileOperations textFileOperations = new TextFileOperations("mockFile.txt", "txt", new string[] { });
            Assert.AreEqual(expectedCount, textFileOperations.GetFileCountInDirectory(workingDirectory));   
        }

        public object ReadFileToObject()
        {
            string[] mockTestLines = {"line1","line2","line3"};
            return mockTestLines;
        }

        public int GetFileCountInDirectory(string workingDirectory)
        {
            int fileCount = 0;

            if (MockFileDirectory.ContainsKey(workingDirectory))
            {
                fileCount = MockFileDirectory.Count;
            }

            return fileCount;
        }
    }
}
