using System;
using System.Diagnostics;

namespace Frogge.Engine;

public class Clock
{
    private Stopwatch _stopwatch;
    private Double _accumulator;
    private Double _frameTimeLimit;

    public Clock()
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