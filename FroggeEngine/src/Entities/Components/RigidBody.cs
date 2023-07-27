using System;

namespace Frogge.Entities.Components;

public class RigidBody : FComponent<>
{
    public Vector2 Position { get; set; }
    public Vector2 Velocity { get; set; }

    public RigidBody()
    {
        Position = new Vector2().Zero;
        Velocity = new Vector2().Zero;
    }
}