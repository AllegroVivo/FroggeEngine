using System;
using System.Collections.Generic;

namespace Frogge.Engine;

public class StateStack
{
    private Stack<GameState> _states = new();
    
    public void PushState(GameState state)
    {
        _states.Push(state);
        state.Enter();
    }
    
    public void PopState()
    {
        GameState state = _states.Pop();
        state.Exit();
    }
    
    public void SwitchState(GameState state)
    {
        PopState();
        PushState(state);
    }

    public void Update()
    {
        if (_states.Count > 0)
            _states.Peek().Update();
    }

    public void Render()
    {
        if (_states.Count > 0)
            _states.Peek().Render();
    }
}