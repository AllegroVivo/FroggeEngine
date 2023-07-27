using System;

namespace Frogge.Engine;

public class MathF
{
    public static Single Clamp(Single value, Single min, Single max) => Math.Min(Math.Max(value, min), max);
    public static Single Lerp(Single a, Single b, Single t) => a + (b - a) * t;
}