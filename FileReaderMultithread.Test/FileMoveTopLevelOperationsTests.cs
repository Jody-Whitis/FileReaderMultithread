using FileReaderMultithread.FileClasses.FileIO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;
using FileReaderMultithread.FileClasses;
using System.Linq;

namespace FileReaderMultithread.Test
{
    [TestClass]
    public class FileMoveTopLevelOperationsTests
    {

        [DataRow(false, "q:\\", "q:\\documents", "q:\\file1.txt", "q:\\file2.txt", 2)]
        [TestMethod]
        public void RunFileMoveTests(bool isMultiThreaded, string directory1, string directory2, string file1, string file2, int expectedDoneCount)
        {
            List<string> fileDirectories = new List<string>();
            fileDirectories.Add(directory1);
            fileDirectories.Add(directory2);    

            List<string> files = new List<string>();
            files.Add(file1);
            files.Add(file2);   

            Mock<FileIOInterface> mockFileOperation = new Mock<FileIOInterface>();
            mockFileOperation.Setup(x => x.DirectoryGetFiles(directory1)).Returns(new string[]{files.FirstOrDefault()});
            mockFileOperation.Setup(x => x.DirectoryGetFiles(directory2)).Returns(new string[] {files.LastOrDefault()});
            mockFileOperation.Setup(x => x.FileMove(It.IsAny<string>(), It.IsAny<string>())).Verifiable();
            mockFileOperation.Setup(x => x.FileExists(It.IsAny<string>())).Returns(true);

            FileMoveTopLevelOperations fileMoveTopLevelOperations = new FileMoveTopLevelOperations(isMultiThreaded, fileDirectories,mockFileOperation.Object);

            fileMoveTopLevelOperations.RunFileMove(0);

            int doneCount = fileMoveTopLevelOperations.DoneCount;

            Assert.AreEqual(expectedDoneCount, doneCount);
        }

    }
}
