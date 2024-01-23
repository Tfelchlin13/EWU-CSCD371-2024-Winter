using System;
#nullable enable
using System;
using System.IO;
namespace Logger;

public class LogFactory
{
    private string? _FilePath;
    public BaseLogger? CreateLogger(string className)
    {
        if (_FilePath == null)
        {

            return null;
        }
        else {

          BaseLogger logger = new FileLogger(_FilePath);
            return logger;

        }
    }
    public void ConfigureFileLogger(string filePath)
    {
        _FilePath = filePath;
    }

}
