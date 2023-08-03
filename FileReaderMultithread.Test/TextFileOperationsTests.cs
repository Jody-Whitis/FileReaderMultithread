using FileReaderMultithread.FileClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileReaderMultithread.Test
{
    [TestClass]
    public class TextFileOperationsTests: FileOperationsInterface
    {
        [TestMethod]
        public void ReadFileTests()
        {
            TextFileOperations textFileOperations = new TextFileOperations("mockFile.txt");
            Assert.IsNotNull(textFileOperations.ReadFileToObject());
        }

        public object ReadFileToObject()
        {
            string[] mockTestLines = {"line1","line2","line3"};
            return mockTestLines;
        }
    }
}
