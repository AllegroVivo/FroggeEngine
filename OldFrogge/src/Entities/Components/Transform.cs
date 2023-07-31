using System;

using Frogge.Math;

namespace Frogge.Entities.Components;

public class Transform : FComponent<Transform>
{
    public Vector3 Position { get; set; }
    public Vector3 Scale { get; set; }
    public Vector3 Rotation { get; set; }

    public Transform()
    {
        Position = new Vector3().Zero;
        Scale = new Vector3().One;
        Rotation = new Vector3().Zero;
    }
}