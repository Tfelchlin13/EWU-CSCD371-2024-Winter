using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Logger.Tests;

[TestClass]
public class BaseLoggerMixinsTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Error_WithNullLogger_ThrowsException()
    {


        // Act
        BaseLoggerMixins.Error(null, "");

        // Assert
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Warning_WithNullLogger_ThrowsException()
    {


        // Act
        BaseLoggerMixins.Warning(null, "");

        // Assert
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Information_WithNullLogger_ThrowsException()
    {


        // Act
        BaseLoggerMixins.Information(null, "");

        // Assert
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Debug_WithNullLogger_ThrowsException()
    {


        // Act
        BaseLoggerMixins.Debug(null, "");

        // Assert
    }

    [TestMethod]
    public void Error_WithData_LogsMessage()
    {
        // Arrange
        TestLogger logger = new();

        // Act
        logger.Error("Message {0}", 42);

        // Assert
        Assert.AreEqual(1, logger.LoggedMessages.Count);
        Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
        Assert.AreEqual("BaseLogger Error: Message 42", logger.LoggedMessages[0].Message);

    }
    [TestMethod]
    public void CheckingForClassNameProperty_WhenInstantiatingTestLogger_ShouldReturnTrue()
    { 

        // Act & Assert
        Assert.IsTrue(typeof(BaseLogger).GetProperty("ClassName") != null);
    }

    [TestMethod]
    public void Error_WithData_Successful()
    {
         TestLogger logger = new();
        logger.Error("Message {0}", 10, 45, 100, 55);
        Assert.AreEqual(1, logger.LoggedMessages.Count);
        Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
        Assert.AreEqual("BaseLogger Error: Message 10 45 100 55", logger.LoggedMessages[0].Message);
    }
    [TestMethod]
    public void Warning_WithData_Successful()
    {
        // Arrange
        TestLogger logger = new();

        // Act
        logger.Warning("Message {0} {1} {2} {3}", 10, 45, 100, 55);

        // Assert
        Assert.AreEqual(1, logger.LoggedMessages.Count);
        Assert.AreEqual(LogLevel.Warning, logger.LoggedMessages[0].LogLevel);
        Assert.AreEqual("BaseLogger Warning: Message 10 45 100 55", logger.LoggedMessages[0].Message);
    }
    [TestMethod]
    public void Debug_WithData_Successful()
    {
        // Arrange
        TestLogger logger = new();

        // Act
        logger.Debug("Message {0} {1} {2} {3}", 10, 45, 100, 55);


        // Assert
        Assert.AreEqual(1, logger.LoggedMessages.Count);
        Assert.AreEqual(LogLevel.Debug, logger.LoggedMessages[0].LogLevel); 
        Assert.AreEqual("BaseLogger Debug: Message 10 45 100 55", logger.LoggedMessages[0].Message);

    }
    [TestMethod]
    public void Information_WithData_Successful()
    {
        // Arrange
        TestLogger logger = new ();

        // Act
        logger.Information("Message {0} {1} {2} {3}", 10, 45, 100, 55);

        // Assert
        Assert.AreEqual(1, logger.LoggedMessages.Count);
        Assert.AreEqual(LogLevel.Information, logger.LoggedMessages[0].LogLevel);
        Assert.AreEqual("BaseLogger Information: Message 10 45 100 55", logger.LoggedMessages[0].Message);
    }
    [TestMethod]
    public void LogWithLevel_WithNonNullLogger_Success()
    {
        // Arrange
        TestLogger logger = new ();
        LogLevel logLevel = LogLevel.Warning;
        string message = "Test Message {0} {1}";
        object[] args = [42, "abc"];

        // Act
        BaseLoggerMixins.LogWithLevel(logger, logLevel, message, args);

        // Assert
        Assert.AreEqual(1, logger.LoggedMessages.Count);
        Assert.AreEqual(logLevel, logger.LoggedMessages[0].LogLevel);
        Assert.AreEqual("BaseLogger Warning: Test Message 42 abc", logger.LoggedMessages[0].Message);
    }

}

public class TestLogger : BaseLogger
{
    public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = new List<(LogLevel, string)>();

    public override void Log(LogLevel logLevel, string message)
    {
        LoggedMessages.Add((logLevel, message));
    }

    
}

