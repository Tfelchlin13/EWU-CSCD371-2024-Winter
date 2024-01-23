using System;
#nullable enable
using System;
using System.IO;
namespace Logger;

public class LogFactory
{
    private string? _FilePath;
    public  BaseLogger? CreateLogger(string className)
    {
        if (_FilePath == null)
        {
            
            return null;
        }

        BaseLogger logger = new Filelogger(_FilePath);
    }
    public void ConfigureFileLogger(string filePath)
    {
        _FilePath = filePath;
    }

}
