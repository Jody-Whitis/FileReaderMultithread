
using FileReaderMultithread.ApplicationUserHandling;
using FileReaderMultithread.FileClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace FileReaderMultithread.Test
{
    [TestClass]
    public class ApplicationUserTests
    {
        [DataRow("q:\\documents\\", 1)]
        [DataRow("restartinput", 0)]
        [DataRow("restaRtinput", 0)]
        [DataRow("RESTARTINPUT", 0)]
        [DataRow("garbage", 0)]
        [TestMethod]
        public void GetDirectoriesFromUserTest(string userInput, int expectedDirectoryCount)
        {
            Mock<ConsoleInterface> mockConsole = new Mock<ConsoleInterface>();
            mockConsole.Setup(x => x.ConsoleReadLine()).Returns(userInput);

            Mock<FileIOInterface> mockFileIO = new Mock<FileIOInterface>();
            mockFileIO.Setup(x => x.DirectoryExists("q:\\documents\\")).Returns(true);
            mockFileIO.Setup(x => x.DirectoryExists("garbage")).Returns(false);

            ApplicationUser applicationUser = new ApplicationUser(3, mockFileIO.Object, mockConsole.Object);

            HashSet<string> directories = applicationUser.GetDirectoriesFromUser();

            Assert.AreEqual(expectedDirectoryCount, directories.Count);

        }

    }
}
