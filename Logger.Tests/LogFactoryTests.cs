using System;
using System.Net.WebSockets;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

    [TestClass]
    public class LogFactoryTests
    {
        private LogFactory? _logFactory;

        [TestInitialize]
        public void Setup()
        {
            _logFactory = new LogFactory();
        }

        [TestMethod]
        public void CreateLogger_NoFile_ShouldReturnNull()
        {
            BaseLogger? logger = _logFactory?.CreateLogger(nameof(LogFactoryTests));

            Assert.IsNull(logger);
        }

        [TestMethod]
        public void CreateLogger_File_ShouldReturnFileLogger()
        {

            _logFactory?.ConfigureFileLogger("Test");

            
            BaseLogger? logger = _logFactory?.CreateLogger(nameof(LogFactoryTests));

            Assert.IsInstanceOfType(logger, typeof(FileLogger));
        }
        
    }

