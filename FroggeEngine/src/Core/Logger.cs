using System;

using log4net;
using log4net.Config;

namespace Frogge.Core;

public class Logger
{
    private ILog _log;

    public Logger()
    {
        // Basic configuration that logs messages to the console.
        BasicConfigurator.Configure();
        _log = LogManager.GetLogger(typeof(Logger));
    }
    
    public void Log(String message)
    {
        _log.Info(message);
    }
    
    public void Error(String message)
    {
        _log.Error(message);
    }
    
    public void Warn(String message)
    {
        _log.Warn(message);
    }
    
    public void Fatal(String message)
    {
        _log.Fatal(message);
    }
}