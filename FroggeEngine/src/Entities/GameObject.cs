using System;
using System.Collections.Generic;
using System.Drawing;

namespace Frogge.Entities;

public abstract class GameObject : FObject
{
    private Dictionary<Type, FComponent> _components;

    protected GameObject(String name)
        : base(name)
    {
        _components = new Dictionary<Type, FComponent<>>();
    }

    public T AddComponent<T>() where T : FComponent<T>, new()
    {
        Type componentType = typeof(T);
        if (!_components.ContainsKey(componentType))
        {
            T component = new();
            component._SetGameObject(this);
            _components.Add(componentType, component);
            return component;
        }

        throw new Exception($"Component of type {componentType} already exists on this GameObject");
    }
        
    public T? GetComponent<T>() where T : FComponent<>
    {
        Type type = typeof(T);
        if (_components.TryGetValue(type, out FComponent<>? component))
            return (T)component;

        return null;
    }
        
    public void RemoveComponent<T>() where T : FComponent<>
    {
        Type type = typeof(T);
        if (_components.TryGetValue(type, out FComponent<>? component))
        {
            component.Finalize();
            _components.Remove(type);
        }
    }
}