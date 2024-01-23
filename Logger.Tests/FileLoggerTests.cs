using System;
using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;
    [TestClass]
    public class FileLoggerTests
    {
        private string? _testFilePath;

        [TestInitialize]
        public void Initialize()
        {
            _testFilePath = Path.Combine(Environment.CurrentDirectory, "TestLogFile.txt");
            if (_testFilePath != null && File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
        }

        [TestMethod]
        public void Log_ValidInput_SuccessfullyAppendsToFile()
        {
            // Arrange
            if (_testFilePath == null)
            {
                Assert.Fail("Test file path is null.");
                return;
            }

            var fileLogger = new FileLogger(_testFilePath);
            var logMessage = "Test log message";

            // Act
            fileLogger.Log(LogLevel.Information, logMessage);

            // Assert
            var fileContent = File.ReadAllText(_testFilePath);
            Assert.IsTrue(fileContent.Contains(logMessage));
        }

        [TestMethod]
        public void Log_WithClassName_SuccessfullyAppendsClassName()
        {
            // Arrange
            if (_testFilePath == null)
            {
                Assert.Fail("Test file path is null.");
                return;
            }

            var fileLogger = new FileLogger(_testFilePath) { ClassName = "TestClass" };
            var logMessage = "Test log message";

            // Act
            fileLogger.Log(LogLevel.Information, logMessage);

            // Assert
            var fileContent = File.ReadAllText(_testFilePath);
            Assert.IsTrue(fileContent.Contains("TestClass"));
        }

        [TestMethod]
        public void Log_WithNullClassName_SuccessfullyAppendsUnknownClassName()
        {
            // Arrange
            if (_testFilePath == null)
            {
                Assert.Fail("Test file path is null.");
                return;
            }

            var fileLogger = new FileLogger(_testFilePath) { ClassName = null };
            var logMessage = "Test log message";

            // Act
            fileLogger.Log(LogLevel.Information, logMessage);

            // Assert
            var fileContent = File.ReadAllText(_testFilePath);
            Assert.IsTrue(fileContent.Contains("Unknown"));
        }

        [TestMethod]
        public void Log_WithExistingFile_SuccessfullyAppends()
        {
            // Arrange
            if (_testFilePath == null)
            {
                Assert.Fail("Test file path is null.");
                return;
            }

            File.Create(_testFilePath).Dispose();
            var fileLogger = new FileLogger(_testFilePath);
            var logMessage = "Test log message";

            // Act
            fileLogger.Log(LogLevel.Information, logMessage);

            // Assert
            var fileContent = File.ReadAllText(_testFilePath);
            Assert.IsTrue(fileContent.Contains(logMessage));
        }
    }

