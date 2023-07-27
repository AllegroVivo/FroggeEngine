using System;
using System.Collections.Generic;

using Frogge.Entities;

namespace Frogge.Systems;

public abstract class GameSystem<T> where T : FComponent
{
    protected List<T> _components;
    
    public GameSystem()
    {
        _components = new List<T>();
    }

    public void RegisterComponent(T component)
    {
        _components.Add(component);
    }
    
    public void UnregisterComponent(T component)
    {
        _components.Remove(component);
    }
    
    public abstract void Update(Single deltaTime);
}