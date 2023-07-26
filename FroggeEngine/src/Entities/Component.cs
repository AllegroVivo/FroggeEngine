using System;

namespace Frogge.Objects;

public abstract class Component
{
    // Each component needs a reference to the game object it's attached to
    public GameObject GameObject { get; set; }
    
    // Constructor
    public Component(GameObject gameObject)
    {
        GameObject = gameObject;
    }
    
    // Optionally, might have some other methods here - just examples.
    public virtual void Initialize() { }
    public virtual void Update(Single deltaTime) { }
    public virtual void Finalize() { }
}