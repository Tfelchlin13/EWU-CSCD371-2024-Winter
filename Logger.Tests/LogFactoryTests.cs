using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    
    [TestMethod]
    public void CreateLogger_NoPathString_NullReturned()
    {
        var factory = new LogFactory();
        Assert.IsNull(factory.CreateLogger());
    }

}
