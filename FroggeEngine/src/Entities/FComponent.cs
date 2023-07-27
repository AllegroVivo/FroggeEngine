using System;

namespace Frogge.Entities;

public abstract class FComponent : FObject
{
    protected FComponent(String name)
    : base(name)
    {
    }
}

public abstract class FComponent<T> : FComponent where T : FComponent<T>, new()
{
    private GameObject? _gameObject;
    public GameObject GameObject
    {
        get
        {
            if (_gameObject == null)
                throw new NullReferenceException("GameObject is null!");
            
            return _gameObject;
        }
    }

    protected FComponent()
    : base(typeof(T).Name)
    {
    }

    public void _SetGameObject(GameObject gameObject)
    {
        if (_gameObject == null)
            _gameObject = gameObject;
    }
    
    // Optionally, might have some other methods here - just examples.
    public virtual void Update(Single deltaTime) { }
}