using System;

using Frogge.Core;
using Frogge.Graphical;

namespace Frogge.Math;

/// <summary>
/// A collection of common math functions.
/// </summary>
public static class Mathf
{
    /// <summary>
    /// Degrees-to-radians conversion constant.
    /// </summary>
    public static Single DegreesToRadians => (Single)(System.Math.PI * 2) / 360;

    /// <summary>
    /// A tiny floating point value.
    /// </summary>
    public static Single Epsilon => 1e-5f;
    
    /// <summary>
    /// A representation of positive infinity.
    /// </summary>
    public static Single Infinity => Single.PositiveInfinity;
    
    /// <summary>
    /// A representation of negative infinity.
    /// </summary>
    public static Single NegativeInfinity => Single.NegativeInfinity;
    
    /// <summary>
    /// The well-known 3.14159265358979... value.
    /// </summary>
    public static Single PI => (Single)System.Math.PI;
    
    /// <summary>
    /// Radians-to-degrees conversion constant.
    /// </summary>
    public static Single RadiansToDegrees => 360 / (Single)(System.Math.PI * 2);
    
    // ------------------------------------------------------------------------------------------ /
    /// <summary>
    /// Returns the absolute value of a single-precision floating-point number.
    /// </summary>
    /// <param name="value">A number that is greater than or equal to <see cref="F:System.Single.MinValue" />,
    /// but less than or equal to <see cref="F:System.Single.MaxValue" />.</param>
    /// <returns>A single-precision floating-point number, x, such that <see cref="F:System.Single.MinValue" />
    /// ≤ x ≤<see cref="F:System.Single.MaxValue" />.</returns>
    /// <exception cref="System.ArgumentOutOfRangeException">Thrown if value is less than <see cref="F:System.Single.MinValue" />,
    /// or greater than to <see cref="F:System.Single.MaxValue" /></exception>
    public static Single Abs(Single value)
    {
        if (value is < Single.MinValue or > Single.MaxValue)
        {
            throw new ArgumentOutOfRangeException(
                nameof(value), "Value must be greater than or equal to Single.MinValue and less than or equal to Single.MaxValue"
                );
        }
        
        return System.Math.Abs(value);
    }

    /// <summary>
    /// Returns the angle whose cosine is the specified number.
    /// </summary>
    /// <param name="value">A number representing a cosine, where -1 ≤ value ≤ 1.</param>
    /// <returns>An angle, θ, measured in radians, such that 0 ≤ θ ≤ π.</returns>
    /// <exception cref="System.ArgumentOutOfRangeException">Thrown if value is less than
    /// -1 or greater than 1.</exception>
    public static Single Acos(Single value)
    {
        if (value is < -1 or > 1)
        {
            throw new ArgumentOutOfRangeException(
                nameof(value), "Value must be greater than or equal to -1 and less than or equal to 1"
                );
        }
        
        return (Single)System.Math.Acos(value);
    }

    /// <summary>
    /// Checks if two single-precision floating-point numbers are approximately equal, within a small tolerance.
    /// </summary>
    /// <param name="a">The first single-precision floating-point number.</param>
    /// <param name="b">The second single-precision floating-point number.</param>
    /// <returns>
    /// True if the absolute difference between a and b is less than the maximum of two calculated tolerances:
    /// the product of Epsilon and the maximum of the absolute values of a and b, or Epsilon times 8.
    /// Otherwise, returns false. </returns>
    public static Boolean Approximately(Single a, Single b) => 
        Abs(b - a) < Max(Epsilon * Max(Abs(a), Abs(b)), Epsilon * 8);

    /// <summary>
    /// Returns the angle whose sine is the specified number.
    /// </summary>
    /// <param name="value">A number representing a sine, where -1 ≤ value ≤ 1.</param>
    /// <returns>An angle, θ, measured in radians, such that -π/2 ≤ θ ≤ π/2.</returns>
    /// <exception cref="System.ArgumentOutOfRangeException">Thrown if value is less than
    /// -1 or greater than 1.</exception>
    public static Single ASin(Single value)
    {
        if (value is < -1 or > 1)
        {
            throw new ArgumentOutOfRangeException(
                nameof(value), "Value must be greater than or equal to -1 and less than or equal to 1"
                );
        }
        
        return (Single)System.Math.Asin(value);
    }

    /// <summary>
    /// Returns the angle whose tangent is the specified number.
    /// </summary>
    /// <param name="value">A number representing a tangent.</param>
    /// <returns>An angle, θ, measured in radians, such that -π/2 ≤ θ ≤ π/2.</returns>
    /// <exception cref="System.ArgumentOutOfRangeException">Thrown if value is less than -1 or greater than 1.</exception>
    public static Single Atan(Single value)
    {
        if (value is < -1 or > 1)
        {
            throw new ArgumentOutOfRangeException(
                nameof(value), "Value must be greater than or equal to -1 and less than or equal to 1"
                );
        }
        
        return (Single)System.Math.Atan(value);
    }

    /// <summary>
    /// Returns the angle whose tangent is the quotient of two specified numbers.
    /// </summary>
    /// <param name="y">The y coordinate of a point.</param>
    /// <param name="x">The x coordinate of a point.</param>
    /// <returns>An angle, θ, measured in radians, such that -π ≤ θ ≤ π, and tan(θ) = y / x, where (x, y) is a
    /// point in the Cartesian plane.</returns>
    /// <exception cref="System.ArgumentException">Thrown if both x and y are 0, as the tangent of the angle is
    /// undefined in this case.</exception>
    public static Single Atan2(Single y, Single x)
    {
        if (x == 0 && y == 0)
        {
            throw new ArgumentException("Cannot calculate the tangent of an angle with both x and y set to 0.");
        }
        return (Single)System.Math.Atan2(y, x);
    }


    /// <summary>
    /// Returns the smallest integral value that is greater than or equal to the specified single-precision
    /// floating-point number. </summary>
    /// <param name="value">A single-precision floating-point number.</param>
    /// <returns>The smallest integral value that is greater than or equal to value. If value is equal
    /// to NaN, NegativeInfinity, or PositiveInfinity, that value is returned.</returns>
    public static Single Ceil(Single value) => (Single)System.Math.Ceiling(value);

    /// <summary>
    /// Returns the smallest integral value that is greater than or equal to the specified single-precision
    /// floating-point number, and converts it to an integer. </summary>
    /// <param name="value">A single-precision floating-point number.</param>
    /// <returns>The smallest integral value that is greater than or equal to value, cast to an integer. If value is
    /// equal to NaN, NegativeInfinity, or PositiveInfinity, that value is returned, cast to an integer.</returns>
    public static Int32 CeilToInt(Single value) => (Int32)Ceil(value);
    
    /// <summary>
    /// Clamps a value between a minimum and maximum value.
    /// </summary>
    /// <param name="value">The value to clamp.</param>
    /// <param name="min">The minimum value. If value is less than min, min is returned.</param>
    /// <param name="max">The maximum value. If value is greater than max, max is returned.</param>
    /// <returns>The clamped value such that min ≤ value ≤ max.</returns>
    public static Single Clamp(Single value, Single min, Single max) => Min(Max(value, min), max);

    /// <summary>
    /// Clamps a value between 0 and 1.
    /// </summary>
    /// <param name="value">The value to clamp.</param>
    /// <returns>The clamped value such that 0 ≤ value ≤ 1.</returns>
    public static Single Clamp01(Single value) => Clamp(value, 0, 1);

    /// <summary>
    /// Returns the closest power of two that is greater than or equal to the specified integer.
    /// </summary>
    /// <param name="value">An integer.</param>
    /// <returns>The closest power of two that is greater than or equal to value.</returns>
    /// <exception cref="System.ArgumentOutOfRangeException">Thrown if value is less than or equal to 0.</exception>
    public static Int32 ClosestPowerOfTwo(Int32 value)
    {
        if (value <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(value), "Value must be greater than 0"
                );
        }
        
        return (Int32)System.Math.Pow(2, (Int32)System.Math.Round(System.Math.Log(value, 2)));
    }

    /// <summary>
    /// Converts a correlated color temperature (in Kelvin) to an RGB color.
    /// </summary>
    /// <param name="kelvin">The correlated color temperature in Kelvin. Must be between 1000 and 40000.</param>
    /// <returns>An RGB color that corresponds to the specified correlated color temperature.</returns>
    /// <exception cref="System.ArgumentOutOfRangeException">Thrown if kelvin is less than 1000 or greater than 40000.</exception>
    public static Color CorrelatedColorTemperatureToRGB(Single kelvin)
    {
        //Temperature must fall between 1000 and 40000 degrees
        if (kelvin is < 1000 or > 40000)
        {
            throw new ArgumentOutOfRangeException(
                nameof(kelvin), "Correlated color temperature must fall between 1000 and 40000 degrees"
                );
        }
        
        Single temp = kelvin / 100;
        Single red, green, blue;
        
        if (temp <= 66)
        {
            red = 255;
        }
        else
        {
            red = temp - 60;
            red = 329.698727446f * (Single)System.Math.Pow(red, -0.1332047592f);
            red = Clamp(red, 0, 255);
        }
        
        if (temp <= 66)
        {
            green = temp;
            green = 99.4708025861f * (Single)System.Math.Log(green) - 161.1195681661f;
            green = Clamp(green, 0, 255);
        }
        else
        {
            green = temp - 60;
            green = 288.1221695283f * (Single)System.Math.Pow(green, -0.0755148492f);
            green = Clamp(green, 0, 255);
        }
        
        if (temp >= 66)
        {
            blue = 255;
        }
        else
        {
            if (temp <= 19)
            {
                blue = 0;
            }
            else
            {
                blue = temp - 10;
                blue = 138.5177312231f * (Single)System.Math.Log(blue) - 305.0447927307f;
                blue = Clamp(blue, 0, 255);
            }
        }
        
        return new Color((Byte)red, (Byte)green, (Byte)blue);
    }

    /// <summary>
    /// Returns the cosine of the specified angle.
    /// </summary>
    /// <param name="value">An angle, measured in radians.</param>
    /// <returns>The cosine of value.</returns>
    /// <exception cref="System.ArgumentOutOfRangeException">Thrown if value is less than -π or greater than π.</exception>
    public static Single Cos(Single value)
    {
        if (value is < -(Single)System.Math.PI or > (Single)System.Math.PI)
        {
            throw new ArgumentOutOfRangeException(
                nameof(value), "Value must be greater than or equal to -π and less than or equal to π"
                );
        }
        
        return (Single)System.Math.Cos(value);
    }

    /// <summary>
    /// Calculates the shortest difference between two given angles.
    /// </summary>
    /// <param name="current">The current angle.</param>
    /// <param name="target">The target angle.</param>
    /// <returns>The shortest difference between the current and target angles.</returns>
    public static Single DeltaAngle(Single current, Single target)
    {
        Single delta = Repeat(target - current, 360);
        if (delta > 180)
            delta -= 360;

        return delta;
    }
    
    /// <summary>
    /// Returns e raised to the specified power.
    /// </summary>
    /// <param name="value">A number specifying a power.</param>
    /// <returns>The number e raised to the power value.</returns>
    /// <exception cref="System.ArgumentOutOfRangeException">Thrown if value is greater than or equal to positive infinity.</exception>
    public static Single Exp(Single value)
    { 
        Double result = System.Math.Exp(value);
        if (Double.IsPositiveInfinity(result))
            throw new OverflowException("Overflow occurred in Exp function");

        return (Single)result;
    }

    /// <summary>
    /// Converts a single-precision floating-point number to a half-precision floating-point number.
    /// </summary>
    /// <param name="value">A single-precision floating-point number.</param>
    /// <returns>A half-precision floating-point number that represents the same value as value.</returns>
    public static UInt16 FloatToHalf(Single value)
    {
        if (value is < -65504.0f or > 65504.0f)
            throw new ArgumentOutOfRangeException(nameof(value), "Value is out of range for a half-precision floating point number");

        Byte[] bytes = BitConverter.GetBytes(value);
        UInt32 bits = BitConverter.ToUInt32(bytes, 0);
        UInt16 sign = (UInt16)((bits & 0x80000000) >> 16);
        Int32 exponent = (Int32)(bits & 0x7F800000) >> 23;
        UInt32 fraction = bits & 0x007FFFFF;

        UInt16 halfSign = (UInt16)(sign >> 16);
        UInt16 halfExponent = (UInt16)((exponent - 127 + 15) << 10);
        UInt16 halfFraction = (UInt16)(fraction >> 13);

        return (UInt16)(halfSign | halfExponent | halfFraction);
    }

    /// <summary>
    /// Returns the largest integer less than or equal to the specified single-precision floating-point number.
    /// </summary>
    /// <param name="value">The single-precision floating-point number.</param>
    /// <returns>The largest integer less than or equal to <paramref name="value"/>.</returns>
    public static Single Floor(Single value) => (Single)System.Math.Floor(value);
    
    /// <summary> Converts the specified single-precision floating-point number to an integer and returns the
    /// largest integer less than or equal to the number. </summary>
    /// <param name="value">The single-precision floating-point number.</param>
    /// <returns>The largest integer less than or equal to <paramref name="value"/>.</returns>
    public static Int32 FloorToInt(Single value) => (Int32)Floor(value);
    
    /// <summary>
    /// Converts a gamma-space value to a linear-space value.
    /// </summary>
    /// <param name="value">The gamma-space value.</param>
    /// <returns>The linear-space value.</returns>
    public static Single GammaToLinearSpace(Single value)
    {
        if (value <= 0.04045f)
            return value / 12.92f;

        return (Single)System.Math.Pow((value + 0.055f) / 1.055f, 2.4f);
    }
    
    /// <summary>
    /// Converts a half-precision floating-point number to a single-precision floating-point number.
    /// </summary>
    /// <param name="value">The half-precision floating-point number.</param>
    /// <returns>The single-precision floating-point number.</returns>
    public static Single HalfToFloat(UInt16 value)
    {
        UInt16 sign = (UInt16)((value & 0x8000) << 16);
        UInt16 exponent = (UInt16)(((value & 0x7C00) >> 10) - 15 + 127);
        UInt16 fraction = (UInt16)((value & 0x03FF) << 13);

        UInt32 bits = (UInt32)(sign | exponent << 23 | fraction << 13);
        return BitConverter.ToSingle(BitConverter.GetBytes(bits), 0);
    }

    /// <summary>
    /// Calculates the linear parameter t that produces the interpolant value within the range [a, b].
    /// </summary>
    /// <param name="a">The start value.</param>
    /// <param name="b">The end value.</param>
    /// <param name="value">The interpolant value.</param>
    /// <returns>The linear parameter.</returns>
    public static Single InverseLerp(Single a, Single b, Single value)
    {
        if (a != b)
            return Clamp01((value - a) / (b - a));

        return 0;
    }
    
    /// <summary>
    /// Determines whether the specified value is a power of two.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <returns>true if <paramref name="value"/> is a power of two; otherwise, false.</returns>
    public static Boolean IsPowerOfTwo(Int32 value) => (value & (value - 1)) == 0;
    
    /// <summary>
    /// Linearly interpolates between two values.
    /// </summary>
    /// <param name="a">The start value.</param>
    /// <param name="b">The end value.</param>
    /// <param name="t">The interpolation factor.</param>
    /// <returns>The interpolated value.</returns>
    public static Single Lerp(Single a, Single b, Single t) => a + (b - a) * Clamp01(t);
    
    /// <summary>
    /// Linearly interpolates between two angles.
    /// </summary>
    /// <param name="a">The start angle.</param>
    /// <param name="b">The end angle.</param>
    /// <param name="t">The interpolation factor.</param>
    /// <returns>The interpolated angle.</returns>
    public static Single LerpAngle(Single a, Single b, Single t)
    {
        Single delta = Repeat(b - a, 360);
        if (delta > 180)
            delta -= 360;

        return a + delta * Clamp01(t);
    }
    
    /// <summary>
    /// Linearly interpolates between two values without clamping the interpolation factor.
    /// </summary>
    /// <param name="a">The start value.</param>
    /// <param name="b">The end value.</param>
    /// <param name="t">The interpolation factor.</param>
    /// <returns>The interpolated value.</returns>
    public static Single LerpUnclamped(Single a, Single b, Single t) => a + (b - a) * t;

    /// <summary>
    /// Returns the natural logarithm of a specified number.
    /// </summary>
    /// <param name="value">The number whose logarithm is to be found.</param>
    /// <returns>The natural logarithm of <paramref name="value"/>, as long as <paramref name="value"/> is positive.</returns>
    /// <exception cref="OverflowException">Thrown when <paramref name="value"/> is less than or equal to zero.</exception>
    public static Single Log(Single value)
    {
        Double result = System.Math.Log(value);
        if (Double.IsNegativeInfinity(result))
            throw new OverflowException("Overflow occurred in Log function");

        return (Single)result;
    }
    
    /// <summary>
    /// Returns the base 10 logarithm of a specified number.
    /// </summary>
    /// <param name="value">The number whose logarithm is to be found.</param>
    /// <returns>The base 10 logarithm of <paramref name="value"/>, as long as <paramref name="value"/> is positive.</returns>
    /// <exception cref="OverflowException">Thrown when <paramref name="value"/> is less than or equal to zero.</exception>
    public static Single Log10(Single value)
    {
        Double result = System.Math.Log10(value);
        if (Double.IsNegativeInfinity(result))
            throw new OverflowException("Overflow occurred in Log10 function");

        return (Single)result;
    }
    
    /// <summary>
    /// Returns the larger of two single-precision floating-point numbers.
    /// </summary>
    /// <param name="a">The first of two single-precision floating-point numbers to compare.</param>
    /// <param name="b">The second of two single-precision floating-point numbers to compare.</param>
    /// <returns>The larger of <paramref name="a"/> and <paramref name="b"/>.</returns>
    public static Single Max(Single a, Single b) => System.Math.Max(a, b);

    /// <summary>
    /// Returns the smaller of two single-precision floating-point numbers.
    /// </summary>
    /// <param name="a">The first of two single-precision floating-point numbers to compare.</param>
    /// <param name="b">The second of two single-precision floating-point numbers to compare.</param>
    /// <returns>The smaller of <paramref name="a"/> and <paramref name="b"/>.</returns>
    public static Single Min(Single a, Single b) => System.Math.Min(a, b);

    /// <summary>
    /// Moves a value <paramref name="current"/> towards <paramref name="target"/>.
    /// </summary>
    /// <param name="current">The current value.</param>
    /// <param name="target">The value to move towards.</param>
    /// <param name="maxDelta">The maximum change that should be applied to the value.</param>
    /// <returns>The new value.</returns>
    public static Single MoveTowards(Single current, Single target, Single maxDelta)
    {
        if (Abs(target - current) <= maxDelta)
            return target;

        return current + Sign(target - current) * maxDelta;
    }
    
    /// <summary>
    /// Moves an angle <paramref name="current"/> towards <paramref name="target"/>.
    /// </summary>
    /// <param name="current">The current angle.</param>
    /// <param name="target">The angle to move towards.</param>
    /// <param name="maxDelta">The maximum change that should be applied to the angle.</param>
    /// <returns>The new angle.</returns>
    public static Single MoveTowardsAngle(Single current, Single target, Single maxDelta)
    {
        Single deltaAngle = DeltaAngle(current, target);
        if (-maxDelta < deltaAngle && deltaAngle < maxDelta)
            return target;

        target = current + deltaAngle;
        return MoveTowards(current, target, maxDelta);
    }
    
    /// <summary>
    /// Returns the smallest power of two that is greater than or equal to the specified value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The smallest power of two that is greater than or equal to <paramref name="value"/>.</returns>
    public static Int32 NextPowerOfTwo(Int32 value)
    {
        if (value <= 0)
            return 1;

        value--;
        value |= value >> 16;
        value |= value >> 8;
        value |= value >> 4;
        value |= value >> 2;
        value |= value >> 1;
        value++;

        return value;
    }
    
    /// <summary>
    /// Generates 2D Perlin noise with the specified width, height, and scale.
    /// </summary>
    /// <param name="width">The width of the 2D noise array to be generated.</param>
    /// <param name="height">The height of the 2D noise array to be generated.</param>
    /// <param name="scale">The frequency of the Perlin noise. Higher scale values result in more frequent changes in the noise pattern.</param>
    /// <returns>A single floating-point value representing the Perlin noise at a specific (x, y) coordinate on a 2D plane.</returns>
    public static Single PerlinNoise2D(Int32 width, Int32 height, Single scale)
    {
        return PerlinNoiseInternal.GeneratePerlinNoise(width, height, scale);
    }
    
    /// <summary>
    /// Generates 1D Perlin noise with the specified width and scale.
    /// </summary>
    /// <param name="width">The width of the 1D noise array to be generated.</param>
    /// <param name="scale">The frequency of the Perlin noise. Higher scale values result in more frequent changes in the noise pattern.</param>
    /// <returns>A single floating-point value representing the Perlin noise at a specific (x) coordinate on a 1D plane.</returns>
    public static Single PerlinNoise1D(Int32 width, Single scale)
    {
        return PerlinNoiseInternal.GeneratePerlinNoise(width, 1, scale);
    }
    
    /// <summary>
    /// Ping-pong the input value between 0 and the specified length.
    /// </summary>
    /// <param name="t">The input value to ping-pong.</param>
    /// <param name="length">The length of the ping-pong range.</param>
    /// <returns>A single floating-point value that ping-pongs between 0 and the specified length.</returns>
    public static Single PingPong(Single t, Single length)
    {
        if (length == 0)
            return 0;
        
        t = Repeat(t, length * 2);
        return length - Abs(t - length);
    }
    
    /// <summary>
    /// Returns the result of raising a specified value to a specified power.
    /// </summary>
    /// <param name="value">The number to be raised to a power.</param>
    /// <param name="power">The exponent to which the value is raised.</param>
    /// <returns>A single floating-point value representing the result of raising the specified value to the specified power.</returns>
    /// <exception cref="OverflowException">Thrown if the result of the operation is positive infinity.</exception>
    public static Single Pow(Single value, Single power)
    {
        Double result = System.Math.Pow(value, power);
        if (Double.IsPositiveInfinity(result))
            throw new OverflowException("Overflow occurred in Pow function");

        return (Single)result;
    }

    /// <summary>
    /// Returns the value t clamped to the range [0, length].
    /// </summary>
    /// <param name="t">The input value to be repeated.</param>
    /// <param name="length">The length of the repeat range.</param>
    /// <returns>A single floating-point value representing the value t clamped to the range [0, length].</returns>
    public static Single Repeat(Single t, Single length)
    {
        if (length == 0)
            return 0;
        
        return Clamp(t - Floor(t / length) * length, 0, length);
    }
    
    /// <summary>
    /// Rounds a single-precision floating-point number to the nearest integer value.
    /// </summary>
    /// <param name="value">The number to round.</param>
    /// <returns>The nearest integer value to the input number.</returns>
    public static Single Round(Single value) => (Single)System.Math.Round(value);
    
    /// <summary>
    /// Rounds a single-precision floating-point number to the nearest integer value and converts it to an integer.
    /// </summary>
    /// <param name="value">The number to round and convert.</param>
    /// <returns>An integer value representing the nearest integer to the input number.</returns>
    public static Int32 RoundToInt(Single value) => (Int32)Round(value);
    
    /// <summary>
    /// Returns the sign of the specified number.
    /// </summary>
    /// <param name="value">The number to determine the sign of.</param>
    /// <returns>1 if the number is positive, -1 if the number is negative, or 0 if the number is zero.</returns>
    public static Single Sign(Single value) => System.Math.Sign(value);
    
    /// <summary>
    /// Returns the sine of the specified angle in radians.
    /// </summary>
    /// <param name="value">The angle in radians.</param>
    /// <returns>The sine of the angle.</returns>
    public static Single Sin(Single value) => (Single)System.Math.Sin(value);
    
    /// <summary>
    /// Gradually interpolates between the current value and the target value using a smoothing function.
    /// </summary>
    /// <param name="current">The current value to interpolate from.</param>
    /// <param name="target">The target value to interpolate to.</param>
    /// <param name="currentVelocity">A reference to the current velocity that will be modified by the function.</param>
    /// <param name="smoothTime">The approximate amount of time it will take to reach the target value.</param>
    /// <param name="maxSpeed">The maximum speed limit for the interpolation (optional). Default is positive infinity.</param>
    /// <param name="deltaTime">The time elapsed since the last call to this method (optional). Default is the value of Time.deltaTime.</param>
    /// <returns>The interpolated value between the current and target values based on the smoothing function.</returns>
    public static Single SmoothDamp(Single current, Single target, ref Single currentVelocity, Single smoothTime, 
        Single deltaTime, Single maxSpeed = Single.PositiveInfinity)
    {
        smoothTime = Max(0.0001f, smoothTime);
        Single num = 2f / smoothTime;
        Single num2 = num * deltaTime;
        Single num3 = 1f / (1f + num2 + 0.48f * num2 * num2 + 0.235f * num2 * num2 * num2);
        Single num4 = current - target;
        Single num5 = target;
        Single num6 = maxSpeed * smoothTime;
        num4 = Clamp(num4, -num6, num6);
        target = current - num4;
        Single num7 = (currentVelocity + num * num4) * deltaTime;
        currentVelocity = (currentVelocity - num * num7) * num3;
        Single num8 = target + (num4 + num7) * num3;
        if (num5 - current > 0f == num8 > num5)
        {
            num8 = num5;
            currentVelocity = (num8 - num5) / deltaTime;
        }
        return num8;
    }
    
    /// <summary>
    /// Gradually interpolates between the current angle and the target angle using a smoothing function.
    /// </summary>
    /// <param name="current">The current angle to interpolate from (in degrees).</param>
    /// <param name="target">The target angle to interpolate to (in degrees).</param>
    /// <param name="currentVelocity">A reference to the current velocity that will be modified by the function.</param>
    /// <param name="smoothTime">The approximate amount of time it will take to reach the target angle.</param>
    /// <param name="maxSpeed">The maximum speed limit for the interpolation (optional). Default is positive infinity.</param>
    /// <param name="deltaTime">The time elapsed since the last call to this method (optional). Default is the value of Time.deltaTime.</param>
    /// <returns>The interpolated value between the current and target angles based on the smoothing function.</returns>
    public static Single SmoothDampAngle(Single current, Single target, ref Single currentVelocity, Single smoothTime, 
        Single deltaTime, Single maxSpeed = Single.PositiveInfinity)
    {
        target = current + DeltaAngle(current, target);
        return SmoothDamp(current, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
    }
    
    /// <summary>
    /// Interpolates between two values using a smooth step function.
    /// </summary>
    /// <param name="from">The starting value.</param>
    /// <param name="to">The ending value.</param>
    /// <param name="t">The interpolation parameter (usually between 0 and 1).</param>
    /// <returns>The interpolated value between from and to based on the smooth step function.</returns>
    public static Single SmoothStep(Single from, Single to, Single t)
    {
        t = Clamp01(t);
        t = -2f * t * t * t + 3f * t * t;
        return to * t + from * (1f - t);
    }
    
    /// <summary>
    /// Returns the square root of the specified number.
    /// </summary>
    /// <param name="value">The number whose square root is to be calculated.</param>
    /// <returns>The square root of the input number.</returns>
    public static Single Sqrt(Single value) => (Single)System.Math.Sqrt(value);

    /// <summary>
    /// Returns the tangent of the specified angle in radians.
    /// </summary>
    /// <param name="value">The angle in radians.</param>
    /// <returns>The tangent of the angle.</returns>
    /// <exception cref="System.ArgumentOutOfRangeException">Thrown if value is less than -π or greater than π.</exception>
    public static Single Tan(Single value)
    {
        if (value is < -(Single)System.Math.PI or > (Single)System.Math.PI)
        {
            throw new ArgumentOutOfRangeException(
                nameof(value), "Value must be greater than or equal to -π and less than or equal to π"
                );
        }
        
        return (Single)System.Math.Tan(value);
    }

    /// <summary>
    /// A utility class for generating Perlin noise.
    /// Perlin noise is a pseudo-random pattern of float values generated across a 2D plane.
    /// The noise consists of "waves" whose values gradually increase and decrease across the pattern.
    /// The noise can be used as the basis for texture effects, animation, generating terrain heightmaps, and more.
    /// </summary>
    public static class PerlinNoiseInternal
    {
        private static Int32[] permutation = new Int32[512];
        private static Int32[] p = new Int32[512];

        static PerlinNoiseInternal()
        {
            // Generate a random permutation table with values from 0 to 255.
            Random random = new();

            for (Int32 i = 0; i < 256; i++)
            {
                permutation[i] = i;
            }

            for (Int32 i = 0; i < 256; i++)
            {
                Int32 j = random.Next(256);
                (permutation[i], permutation[j]) = (permutation[j], permutation[i]);
                permutation[i + 256] = permutation[i];
            }
        }

        private static Single Fade(Single t)
        {
            return t * t * t * (t * (t * 6 - 15) + 10);
        }

        private static Single Grad(Int32 hash, Single x, Single y)
        {
            Int32 h = hash & 7;
            Single u = h < 4 ? x : y;
            Single v = h < 4 ? y : x;
            return ((h & 1) == 0 ? u : -u) + ((h & 2) == 0 ? v : -v);
        }

        /// <summary>
        /// Generates 2D Perlin noise with the specified width, height, and scale.
        /// </summary>
        /// <param name="width">The width of the 2D noise array to be generated.</param>
        /// <param name="height">The height of the 2D noise array to be generated.</param>
        /// <param name="scale">The frequency of the Perlin noise. Higher scale values result in more frequent changes in the noise pattern.</param>
        /// <returns>A 2D array of floating-point values representing the Perlin noise across the specified width and height.</returns>
        public static Single GeneratePerlinNoise(Single width, Single height, Single scale)
        {
            // Generate random gradient vectors (unit length) for each integer coordinate.
            Random random = new();
            Single[][] gradientVectors = new Single[2][];
            for (Int32 i = 0; i < 2; i++)
            {
                gradientVectors[i] = new Single[2];
                for (Int32 j = 0; j < 2; j++)
                    gradientVectors[i][j] = (Single)System.Math.Sqrt(2) * (Single)(random.NextDouble() * 2 - 1);
            }

            Single PerlinNoise(Single x, Single y)
            {
                Int32 x0 = (Int32)System.Math.Floor(x);
                Int32 y0 = (Int32)System.Math.Floor(y);
                Int32 x1 = x0 + 1;
                Int32 y1 = y0 + 1;

                Single dx0 = x - x0;
                Single dy0 = y - y0;
                Single dx1 = x - x1;
                Single dy1 = y - y1;

                Int32 hashX0 = permutation[x0 & 255];
                Int32 hashX1 = permutation[x1 & 255];
                Int32 hash00 = permutation[hashX0 + (y0 & 255)];
                Int32 hash01 = permutation[hashX0 + (y1 & 255)];
                Int32 hash10 = permutation[hashX1 + (y0 & 255)];
                Int32 hash11 = permutation[hashX1 + (y1 & 255)];

                Single n00 = Grad(hash00, dx0, dy0);
                Single n01 = Grad(hash01, dx0, dy1);
                Single n10 = Grad(hash10, dx1, dy0);
                Single n11 = Grad(hash11, dx1, dy1);

                Single wx = Fade(dx0);
                Single n0 = Lerp(wx, n00, n01);
                Single n1 = Lerp(wx, n10, n11);

                Single wy = Fade(dy0);
                return Lerp(wy, n0, n1);
            }

            return PerlinNoise(width * scale, height * scale);
        }
    }
}