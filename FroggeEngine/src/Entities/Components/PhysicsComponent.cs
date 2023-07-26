using System;

namespace Frogge.Entities.Components;

public class PhysicsComponent : Component
{
    public Vector2 Position { get; set; }
    public Vector2 Velocity { get; set; }

    public PhysicsComponent()
    {
        Position = new Vector2().Zero;
        Velocity = new Vector2().Zero;
    }
}