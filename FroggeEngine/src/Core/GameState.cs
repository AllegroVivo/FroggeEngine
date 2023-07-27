using System;

namespace Frogge.Core;

public abstract class GameState
{
    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update();
    public abstract void Render();
}