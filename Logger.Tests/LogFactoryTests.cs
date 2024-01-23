using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    [TestMethod]
    public void CreateLogger_SetsClassNameUsingObjectInitializer_Success()
    {
        var logFac = new LogFactory();
        var expectedclassName = "LogFactory";
        var logger = logger.CreateLogger(expectedclassName);

        Assert.IsNotNull(logger);
        Assert.AreEqual(expectedclassName, logger.ClassName);
    }

}
