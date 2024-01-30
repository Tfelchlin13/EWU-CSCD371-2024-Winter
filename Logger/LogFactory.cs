using System;
#nullable enable
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

          return new FileLogger(_FilePath);

        }
    }
    public void ConfigureFileLogger(string filePath)
    {
        _FilePath = filePath;
    }

}
