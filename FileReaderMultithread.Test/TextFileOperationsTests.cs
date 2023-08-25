using FileReaderMultithread.FileClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileReaderMultithread.Test
{
    [TestClass]
    public class TextFileOperationsTests
    {

        [TestMethod]
        public void ReadFileTests()
        {
            TextFileOperations textFileOperations = new TextFileOperations("mockFile.txt","txt");
            Assert.IsNotNull(textFileOperations.ReadFileToObject());
        }

        [DataRow("q:\\documents", 2,DisplayName = "GetFileCountInDirectoryTest - Directory Exists")]
        [DataRow("q:\\nohere", 0, DisplayName = "GetFileCountInDirectoryTest - Directory Doesn't Exists")]
        [TestMethod]
        public void GetFileCountInDirectoryTest(string workingDirectory, int expectedCount)
        {
            string[] mockCDrive = { "q:\\documents\\file1.txt", "q:\\documents\\file2.txt" };

            Mock<FileIOInterface> mockFileIO = new Mock<FileIOInterface>();

            mockFileIO.Setup(x => x.DirectoryGetFiles(It.IsAny<string>(), It.IsAny<string>())).Returns(mockCDrive);

            mockFileIO.Setup(x => x.DirectoryExists(It.IsAny<string>())).Returns(mockCDrive.Any(file => Path.GetDirectoryName(file).Equals(workingDirectory)));

            TextFileOperations textFileOperations = new TextFileOperations("mockFile.txt", "txt", new string[] { }, mockFileIO.Object);

            Assert.AreEqual(expectedCount, textFileOperations.GetFileCountInDirectory(workingDirectory));   
        }

        [DataRow("q:\\documents\\file1.txt", "q:\\done\\file1.txt", 1, DisplayName = "MoveFileTest - File Moved")]
        [DataRow("q:\\documents\\file3.txt", "q:\\done\\file3.txt", 6, DisplayName = "MoveFileTest - Source File Does Not Exists")]
        [DataRow("q:\\documents\\filex.txt", "q:\\done\\filex.txt", 4, DisplayName = "MoveFileTest - Destination File Exists, Not Moved")]
        [TestMethod]
        public void MoveFileTest(string filePath, string destinationPath, int expectedFileStatus)
        {
            List<string> mockCDrive = new List<string>{ "q:\\documents\\file1.txt", "q:\\documents\\filex.txt", "q:\\done\\filex.txt" };

            Mock<FileIOInterface> mockFileIO = new Mock<FileIOInterface>();

            string destinationDirectory = Path.GetDirectoryName(destinationPath);
            mockFileIO.Setup(x => x.DirectoryExists(It.IsAny<string>())).Returns(mockCDrive.Any(file => Path.GetDirectoryName(file).Equals(destinationDirectory)));

            mockFileIO.Setup(x => x.FileExists(filePath)).Returns(mockCDrive.Any(file => file.Equals(filePath)));
            mockFileIO.Setup(x => x.FileExists(destinationPath)).Returns(mockCDrive.Any(file => file.Equals(destinationPath)));

            mockFileIO.Setup(x => x.CreateDirectory(It.IsAny<string>())).Verifiable();

            mockFileIO.Setup(x => x.FileMove(It.IsAny<string>(), It.IsAny<string>())).Verifiable();

            TextFileOperations textFileOperations = new TextFileOperations("mockFile.txt", "txt", new string[] { }, mockFileIO.Object);

            int fileStatus = textFileOperations.MoveFile(filePath, destinationPath);

            Assert.AreEqual(expectedFileStatus, fileStatus);
        }


        [DataRow("q:\\documents\\file1.txt", "q:\\done\\file1.txt", DisplayName = "MoveFileTest - File Moved Exception")]
        [TestMethod]
        public void MoveFileErrorTest(string filePath, string destinationPath)
        {
            List<string> mockCDrive = new List<string> { "q:\\documents\\file1.txt", "q:\\documents\\filex.txt", "q:\\done\\filex.txt" };

            Mock<FileIOInterface> mockFileIO = new Mock<FileIOInterface>();

            string destinationDirectory = Path.GetDirectoryName(destinationPath);
            mockFileIO.Setup(x => x.DirectoryExists(It.IsAny<string>())).Returns(mockCDrive.Any(file => Path.GetDirectoryName(file).Equals(destinationDirectory)));

            mockFileIO.Setup(x => x.FileExists(filePath)).Returns(mockCDrive.Any(file => file.Equals(filePath)));
            mockFileIO.Setup(x => x.FileExists(destinationPath)).Returns(mockCDrive.Any(file => file.Equals(destinationPath)));

            mockFileIO.Setup(x => x.CreateDirectory(It.IsAny<string>())).Verifiable();

            mockFileIO.Setup(x => x.FileMove(It.IsAny<string>(), It.IsAny<string>())).Throws(new System.Exception());

            TextFileOperations textFileOperations = new TextFileOperations("mockFile.txt", "txt", new string[] { }, mockFileIO.Object);

            int fileStatus = textFileOperations.MoveFile(filePath, destinationPath);

            Assert.AreEqual(-1, fileStatus);
        }
    }
}
