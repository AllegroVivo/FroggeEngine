using System;
using System.Diagnostics;

using Frogge.Math;

namespace Frogge.Core;

public class Time
{
    private static Stopwatch _stopwatch;
    private static Double _accumulator;
    private static Double _frameTimeLimit;
    private static Single _lastFrameTime;
    private static Single _captureDeltaTime;
    private static Int64 _frameCount;
    private static Single _timeScale = 1.0f;
    private static Single _timeSinceLevelLoad = 0f;

    /// <summary>
    /// Gets or sets the capture delta time.
    /// </summary>
    public static Single captureDeltaTime
    {
        get => _captureDeltaTime;
        set
        {
            _captureDeltaTime = value;
            if (_captureDeltaTime != 0)
                time = _captureDeltaTime * timeScale;
        }
    }

    /// <summary>
    /// Gets or sets the capture framerate.
    /// </summary>
    public static Int32 captureFPS
    {
        get
        {
            if (_captureDeltaTime == 0)
                return 0;
            
            return (Int32)Mathf.Round(1 / _captureDeltaTime);
        }
        set
        {
            if (value == 0)
                _captureDeltaTime = 0;
            
            _captureDeltaTime = 1f / value;
        }
    }
    
    /// <summary>
    /// Gets the interval in seconds from the last frame to the current one.
    /// </summary>
    public static Single deltaTime
    {
        get
        {
            if (inFixedTimeStep)
                return fixedDeltaTime;
            
            return (Single)_stopwatch.Elapsed.TotalSeconds - _lastFrameTime;
        }
    }
    
    /// <summary>
    /// Gets or sets the interval in seconds at which physics and other fixed frame rate updates are performed.
    /// </summary>
    public static Single fixedDeltaTime { get; private set; } = 0.02f;

    /// <summary>
    /// Gets the time in seconds since the start of the game.
    /// </summary>
    public static Single fixedTime { get; private set; }

    /// <summary>
    /// Gets the double-precision time in seconds since the start of the game.
    /// </summary>
    public static Double FixedTimeAsDouble => fixedTime;
    
    /// <summary>
    /// Gets the timeScale-independent interval, in seconds, from the last FixedUpdate phase to the current one.
    /// </summary>
    public static Single fixedUnscaledDeltaTime { get; private set; }
    
    /// <summary>
    /// Gets the timeScale-independent time in seconds since the start of the game.
    /// </summary>
    public static Single fixedUnscaledTime { get; private set; }
    
    /// <summary>
    /// Gets the double-precision, timeScale-independent time in seconds since the start of the game.
    /// </summary>
    public static Single fixedUnscaledTimeAsDouble => fixedUnscaledTime;
    
    public static Int32 frameCount => (Int32)_frameCount;

    /// <summary>
    /// Returns true if called inside a fixed time step callback.
    /// </summary>
    public static Boolean inFixedTimeStep { get; private set; }

    /// <summary>
    /// Gets or sets the maximum value of Time.deltaTime in any given frame.
    /// </summary>
    public static Single maximumDeltaTime { get; set; } = 0.1f;

    /// <summary>
    /// Gets or sets the maximum time a frame can spend on particle updates.
    /// </summary>
    public static Single maximumParticleDeltaTime { get; set; } = 0.03f;

    /// <summary>
    /// Gets the real time in seconds since the game started.
    /// </summary>
    public static Single realtimeSinceStartup => (Single)_stopwatch.Elapsed.TotalSeconds;
    
    /// <summary>
    /// Gets the double-precision real time in seconds since the game started.
    /// </summary>
    public static Double realtimeSinceStartupAsDouble => _stopwatch.Elapsed.TotalSeconds;
    
    /// <summary>
    /// Gets a smoothed out Time.deltaTime.
    /// </summary>
    public static Single smoothDeltaTime
    {
        get; 
        private set;
    }
    
    /// <summary>
    /// Gets the time at the beginning of this frame.
    /// </summary>
    public static Single time
    {
        get
        {
            if (inFixedTimeStep)
                return fixedTime;

            return (Single)_stopwatch.Elapsed.TotalSeconds * timeScale;
        }
        set
        {
            // TODO: Implement
        }
    }

    /// <summary>
    /// Gets the double-precision time at the beginning of this frame.
    /// </summary>
    public static Double timeAsDouble
    {
        get
        {
            if (inFixedTimeStep)
                return fixedTime;

            return _stopwatch.Elapsed.TotalSeconds * timeScale;
        }
    }
    
    /// <summary>
    /// The scale at which time passes.
    /// </summary>
    public static Single timeScale
    {
        get => _timeScale;
        set
        {
            if (value >= 0)
                _timeScale = value;
            else
                throw new ArgumentOutOfRangeException(nameof(value), "Time.timeScale cannot be negative.");
        }
    }
    
    /// <summary>
    /// This property represents the time in seconds since the last non-additive scene has finished loading.
    /// </summary>
    public static Single timeSinceLevelLoad => _timeSinceLevelLoad - (realtimeSinceStartup - time);

    /// <summary>
    /// This property represents the double-precision time in seconds since the last non-additive scene has finished loading.
    /// </summary>
    public static Double timeSinceLevelLoadAsDouble => timeSinceLevelLoad;

    /// <summary>
    /// The timeScale-independent interval in seconds from the last frame to the current one.
    /// </summary>
    public static Single unscaledDeltaTime { get; } = 0f;

    /// <summary>
    /// The timeScale-independent time for this frame (Read Only).
    /// </summary>
    public static Single unscaledTime { get; } = 0f;
    
    /// <summary>
    /// The double-precision timeScale-independent time for this frame (Read Only).
    /// </summary>
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
            _lastFrameTime = (Single)_stopwatch.Elapsed.TotalSeconds;
            
            fixedTime += fixedDeltaTime;
            fixedUnscaledDeltaTime = Mathf.Min(_lastFrameTime - fixedTime, maximumDeltaTime);
            fixedUnscaledTime += fixedUnscaledDeltaTime;

            _frameCount++;
            inFixedTimeStep = true;

            smoothDeltaTime += (deltaTime - smoothDeltaTime) * 0.1f;
            return true;
        }
        
        inFixedTimeStep = false;
        return false;
    }

    private Double GetTimeSinceLastFrame()
    {
        Double timeSinceLastFrame = _stopwatch.Elapsed.TotalSeconds;
        _stopwatch.Restart();
        return timeSinceLastFrame;
    }
}