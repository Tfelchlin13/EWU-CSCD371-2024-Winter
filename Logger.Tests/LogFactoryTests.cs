using System.Net.WebSockets;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests

{
    private LogFactory? _logFactory;
    [TestInitialize]
    public void Constructor()
    {
        _logFactory = new();
    }

    [TestMethod]
    public void CreateLogger_ClassName_Success()
    {
       
    }
    [TestMethod]
    public void CreateLogger_ClassName_Failure()
    {
       

    }

}
