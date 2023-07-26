using System;

namespace Frogge;

public class Vector3
{
    public const Single EPSILON = 1e-5f;
    
    public Single X { get; set; }
    public Single Y { get; set; }
    public Single Z { get; set; }
    
    public Vector3(Single x, Single y, Single z)
    {
        X = x;
        Y = y;
        Z = z;
    }
    
    // Default constructor
    public Vector3() : this(0,0,0) { }
    
    // Int constructor
    public Vector3(Int32 value) : this(value, value, value) { }
    
    // Float constructor
    public Vector3(Single value) : this(value, value, value) { }
    
    // Copy constructor
    public Vector3(Vector3 other) : this(other.X, other.Y, other.Z) { }
    
    public Vector3 Round(Int32 digits = 0)
    {
        return new Vector3((Single)Math.Round(X, digits), (Single)Math.Round(Y, digits), (Single)Math.Round(Z, digits));
    }
    
    public Vector3 FloorDiv(Int32 divisor)
    {
        return new Vector3(X / divisor, Y / divisor, Z / divisor);
    }
    
    public Single Dot(Vector3 other)
    {
        return X * other.X + Y * other.Y + Z * other.Z;
    }
    
    public Vector3 Cross(Vector3 other)
    {
        return new Vector3(Y * other.Z - Z * other.Y, Z * other.X - X * other.Z, X * other.Y - Y * other.X);
    }
    
    public Single Magnitude()
    {
        return (Single)Math.Sqrt(X * X + Y * Y + Z * Z);
    }
    
    public Single SqrMagnitude()
    {
        return X * X + Y * Y + Z * Z;
    }
    
    public Vector3 Normalize()
    {
        Single magnitude = Magnitude();
        return magnitude > EPSILON ? new Vector3(X / magnitude, Y / magnitude, Z / magnitude) : new Vector3();
    }
    
    public Single Distance(Vector3 other)
    {
        Single dx = X - other.X;
        Single dy = Y - other.Y;
        Single dz = Z - other.Z;
        return (Single)Math.Sqrt(dx * dx + dy * dy + dz * dz);
    }
    
    public static Vector3 Lerp(Vector3 a, Vector3 b, Single t)
    {
        return new Vector3(a.X + (b.X - a.X) * t, a.Y + (b.Y - a.Y) * t, a.Z + (b.Z - a.Z) * t);
    }
}