using System;
using Frogge.Entities.Components;
using Frogge.Systems;

public class PhysicsSystem : GameSystem<PhysicsComponent>
{
    public override void Update(Single deltaTime)
    {
        foreach (PhysicsComponent component in _components)
        {
            // Update component's position based on its velocity
            component.Position += component.Velocity * deltaTime;
            
            // Apply gravity
            component.Velocity += new Vector2(0, 9.8f) * deltaTime;
            
            // Apply friction (this is a very simple model of friction)
            component.Velocity *= 0.99f;
        }
    }
}