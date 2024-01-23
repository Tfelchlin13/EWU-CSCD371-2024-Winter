using System;
using System.IO;

namespace Logger;

public abstract class BaseLogger
{
    public abstract void Log(LogLevel logLevel, string message);

    public string? ClassName { get; set; }

    
}

    public class FileLogger : BaseLogger
    {
        private readonly string filePath;

        public FileLogger(string filePath)
        {
            this.filePath = filePath;
        }

        public override void Log(LogLevel logLevel, string message)
        {
            // Get the current date/time
            string currentDateTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt");

            // Get the name of the class that created the logger
            string className = ClassName ?? "Unknown";

            // Create the log entry
            string logEntry = $"{currentDateTime} {className} {logLevel}: {message}";

            // Append the log entry to the file
            File.AppendAllText(filePath, logEntry + Environment.NewLine);
        }
    }}

