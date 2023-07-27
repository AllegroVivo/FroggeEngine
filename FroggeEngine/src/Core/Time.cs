using System;
using System.Diagnostics;

namespace Frogge.Core;

public class Time
{
    private Stopwatch _stopwatch;
    private Double _accumulator;
    private Double _frameTimeLimit;

    public static Single captureDeltaTime
    {
        get; 
        set;
    }

    public static Int32 captureFPS
    {
        get; 
        set;
    }
    
    public static Single deltaTime
    {
        get; 
        private set;
    }
    
    public static Single fixedDeltaTime
    {
        get; 
        private set;
    }

    public static Single fixedTime
    {
        get;
        private set;
    }

    public static Double FixedTimeAsDouble => fixedTime;
    
    public static Single fixedUnscaledDeltaTime
    {
        get; 
        private set;
    }
    
    public static Single fixedUnscaledTime
    {
        get; 
        private set;
    }
    
    public static Single fixedUnscaledTimeAsDouble => fixedUnscaledTime;
    
    public static Int32 frameCount
    {
        get; 
        private set;
    }

    public static Boolean inFixedTimeStep
    {
        get; 
        private set;
    }

    public static Single maximumDeltaTime
    {
        get;
        set;
    }
    
    public static Single maximumParticleDeltaTime
    {
        get;
        set;
    }
    
    public static Single realtimeSinceStartup
    {
        get; 
        private set;
    }
    
    public static Double realtimeSinceStartupAsDouble => realtimeSinceStartup;
    
    public static Single smoothDeltaTime
    {
        get; 
        private set;
    }
    
    public static Single time
    {
        get; 
        private set;
    }
    
    public static Double timeAsDouble => time;
    
    public static Single timeScale
    {
        get; 
        set;
    }
    
    public static Single timeSinceLevelLoad
    {
        get; 
        private set;
    }
    
    public static Double timeSinceLevelLoadAsDouble => timeSinceLevelLoad;
    
    public static Single unscaledDeltaTime
    {
        get; 
        private set;
    }
    
    public static Single unscaledTime
    {
        get; 
        private set;
    }
    
    public static Double unscaledTimeAsDouble => unscaledTime;
    
    public Time()
    {
        _stopwatch = new Stopwatch();
        _stopwatch.Start();
    }
        
    // Update the clock and return whether it's time to update the game
    public Boolean Tick(Int32 fpsLimit)
    {
        _frameTimeLimit = 1.0 / fpsLimit;
        
        _accumulator += GetTimeSinceLastFrame();
        if (_accumulator >= _frameTimeLimit)
        {
            _accumulator -= _frameTimeLimit;
            return true;
        }
        
        return false;
    }

    private Double GetTimeSinceLastFrame()
    {
        Double timeSinceLastFrame = _stopwatch.Elapsed.TotalSeconds;
        _stopwatch.Restart();
        return timeSinceLastFrame;
    }
}