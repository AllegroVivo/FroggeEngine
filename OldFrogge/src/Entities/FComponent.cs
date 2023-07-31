using System;

namespace Frogge.Entities;

public abstract class FComponent : FObject
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
    
    protected FComponent(String name)
    : base(name)
    {
    }
    
    
    public void _SetGameObject(GameObject gameObject)
    {
        if (_gameObject == null)
            _gameObject = gameObject;
    }
    
    // Optionally, might have some other methods here - just examples.
    public virtual void Update(Single deltaTime) { }
    public virtual void Finalize() { }
}

public abstract class FComponent<T> : FComponent where T : FComponent<T>, new()
{
    protected FComponent()
    : base(typeof(T).Name)
    {
    }
}