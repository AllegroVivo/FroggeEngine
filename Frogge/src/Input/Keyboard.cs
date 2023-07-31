using System;

namespace Frogge.Input;

public class Keyboard
{
    private KeyboardState _state;

    public KeyboardState State => _state;
    
    public Keyboard()
    {
        _state = new KeyboardState();
    }

    public void Update()
    {
        throw new NotImplementedException();
    }

    public KeyboardState GetState()
    {
        return State;
    }
}