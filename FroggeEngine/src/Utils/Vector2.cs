using System;

namespace Frogge;

public class Vector2
{
    public const Single EPSILON = 1e-5f;
    
    public Single X { get; set; }
    public Single Y { get; set; }
    
    public Vector2(Single x, Single y)
    {
        X = x;
        Y = y;
    }
    
    // Default constructor
    public Vector2() : this(0,0) { }
    
    // Int constructor
    public Vector2(Int32 value) : this(value, value) { }
    
    // Float constructor
    public Vector2(Single value) : this(value, value) { }
    
    // Copy constructor
    public Vector2(Vector2 other) : this(other.X, other.Y) { }

    public Vector2 Round(Int32 digits = 0)
    {
        return new Vector2((Single)Math.Round(X, digits), (Single)Math.Round(Y, digits));
    }

    public Vector2 FloorDiv(Int32 divisor)
    {
        return new Vector2(X / divisor, Y / divisor);
    }

    public Single Dot(Vector2 other)
    {
        return X * other.X + Y * other.Y;
    }

    public Single Cross(Vector2 other)
    {
        return X * other.Y - Y * other.X;
    }
    
    public Single Magnitude()
    {
        return (Single)Math.Sqrt(X * X + Y * Y);
    }
    
    public Single SqrMagnitude()
    {
        return X * X + Y * Y;
    }

    public Vector2 Normalize()
    {
        Single length = Magnitude();
        return length > 0 ? new Vector2(X / length, Y / length) : new Vector2(0, 0);
    }

    public Single DistanceTo(Vector2 target)
    {
        Single dx = target.X - X;
        Single dy = target.Y - Y;
        return (Single)Math.Sqrt(dx * dx + dy * dy);
    }
    
    public static Vector2 Lerp(Vector2 a, Vector2 b, Single t)
    {
        return new Vector2(a.X + (b.X - a.X) * t, a.Y + (b.Y - a.Y) * t);
    }
    
    public Vector2 Lerp(Vector2 target, Single t)
    {
        return Lerp(this, target, t);
    }

    public Vector2 Rotate(Single angle)
    {
        Single radians = angle * (Single)Math.PI / 180f;
        return RotateRadians(radians);
    }

    public Vector2 RotateRadians(Single radians)
    {
        Single cos = (Single)Math.Cos(radians);
        Single sin = (Single)Math.Sin(radians);
        
        // Snap to exact values if close. Damn floating point math.
        if (Math.Abs(cos) < EPSILON) cos = 0;
        if (Math.Abs(sin) < EPSILON) sin = 0;
        if (Math.Abs(cos - 1) < EPSILON) cos = 1;
        if (Math.Abs(sin - 1) < EPSILON) sin = 1;
        if (Math.Abs(cos + 1) < EPSILON) cos = -1;
        if (Math.Abs(sin + 1) < EPSILON) sin = -1;
        
        return new Vector2(X * cos - Y * sin, X * sin + Y * cos);
    }

    public Vector2 Copy()
    {
        return new Vector2(X, Y);
    }
    
    public Boolean ArrivedAt(Vector2 target)
    {
        return DistanceTo(target) < EPSILON;
    }

    public Vector2 Zero => new(0, 0);
    public Vector2 One => new(1, 1);

    public static Vector2 operator +(Vector2 a, Vector2 b) => new(a.X + b.X, a.Y + b.Y);
    public static Vector2 operator -(Vector2 a, Vector2 b) => new(a.X - b.X, a.Y - b.Y);
    public static Vector2 operator *(Vector2 a, Single b) => new(a.X * b, a.Y * b);
    public static Vector2 operator *(Single a, Vector2 b) => new(a * b.X, a * b.Y);
    public static Single operator *(Vector2 a, Vector2 b) => a.X * b.X + a.Y * b.Y;
    public static Vector2 operator /(Vector2 a, Single b) => new(a.X / b, a.Y / b);
    public static Vector2 operator /(Single a, Vector2 b) => new(a / b.X, a / b.Y);
}