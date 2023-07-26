using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Frogge.Input;

public class Keyboard
{
    private HashSet<Keys> _currentState;
    private HashSet<Keys> _previousState;

    public Keyboard()
    {
        _currentState = new HashSet<Keys>();
        _previousState = new HashSet<Keys>();
    }

    public void Update()
    {
        // Save current state
        _previousState = new HashSet<Keys>(_currentState);
        
        // Update the current state
        _currentState.Clear();

        foreach (Keys key in Enum.GetValues(typeof(Keys)))
        {
            if (IsKeyDown(key)){}

            {
                _currentState.Add(key);
            }
        }
    }

    public Boolean IsKeyPressed(Keys key)
    {
        return _currentState.Contains(key);
    }
    
    public Boolean WasKeyPressed(Keys key)
    {
        return _currentState.Contains(key) && !_previousState.Contains(key);
    }
    
    public Boolean WasKeyReleased(Keys key)
    {
        return !_currentState.Contains(key) && _previousState.Contains(key);
    }

    [DllImport("user32.dll")]
    public static extern Int16 GetAsyncKeyState(Int32 vKey);

    public static Boolean IsKeyDown(Keys key)
    {
        return (GetAsyncKeyState((Int32)key) & 0x8000) != 0;
    }
}
