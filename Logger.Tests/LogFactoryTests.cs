using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    [TestMethod]
    public void CreateLogger_WhenCalled_ShouldSetClassNameToDefault()
    {
        // Arrange
        string expectedClassName = "YourClassName"; // Replace with the expected default class name

        // Act
        var logger = LogFactory.CreateLogger();

        // Assert
        Assert.IsNotNull(logger);
        Assert.AreEqual(expectedClassName, logger.ClassName);
    }

}
