namespace Logger;

public abstract class BaseLogger
{
    public abstract void Log(LogLevel logLevel, string message);

    private string _className;

    public string ClassName
    {
        get { return _className; }
        set { _className = value; }
    }
}

