using System;

namespace Frogge.Graphics;

public struct Color
{

    public Byte R { get; set; }
    public Byte G { get; set; }
    public Byte B { get; set; }
    public Byte A { get; set; }
    
    public Color(Byte r, Byte g, Byte b)
    {
        R = r;
        G = g;
        B = b;
        A = 255;
    }
    
    public Color(Byte r, Byte g, Byte b, Byte a)
    {
        R = r;
        G = g;
        B = b;
        A = a;
    }

    public Color(Color color)
    {
        R = color.R;
        G = color.G;
        B = color.B;
        A = color.A;
    }
    
    public Color(String hex)
    {
        if (hex.StartsWith("#"))
            hex = hex.Substring(1);

        switch (hex.Length)
        {
            case 6:
                R = Convert.ToByte(hex.Substring(0, 2), 16);
                G = Convert.ToByte(hex.Substring(2, 2), 16);
                B = Convert.ToByte(hex.Substring(4, 2), 16);
                A = 255;
                break;
            case 8:
                R = Convert.ToByte(hex.Substring(0, 2), 16);
                G = Convert.ToByte(hex.Substring(2, 2), 16);
                B = Convert.ToByte(hex.Substring(4, 2), 16);
                A = Convert.ToByte(hex.Substring(6, 2), 16);
                break;
            default:
                throw new ArgumentException("Hex string must be 6 or 8 characters in length.");
        }
    }
    
    public Color(UInt32 hex)
    {
        R = (Byte)((hex >> 24) & 0xFF);
        G = (Byte)((hex >> 16) & 0xFF);
        B = (Byte)((hex >> 8) & 0xFF);
        A = (Byte)(hex & 0xFF);
    }

    public Color(Tuple<Byte, Byte, Byte> rgb)
    {
        R = rgb.Item1;
        G = rgb.Item2;
        B = rgb.Item3;
        A = 255;
    }
    
    public Color(Tuple<Byte, Byte, Byte, Byte> rgba)
    {
        R = rgba.Item1;
        G = rgba.Item2;
        B = rgba.Item3;
        A = rgba.Item4;
    }

    public Color Lerp(Color other, Single t)
    {
        if (t < 0f)
            t = 0f;
        if (t > 1f)
            t = 1f;

        Byte r = (Byte)(R + t * (other.R - R));
        Byte g = (Byte)(G + t * (other.G - G));
        Byte b = (Byte)(B + t * (other.B - B));
        Byte a = (Byte)(A + t * (other.A - A));
        
        return new Color(r, g, b, a);
    }

    public void Update(Byte r, Byte g, Byte b)
    {
        R = r;
        G = g;
        B = b;
        A = 255;
    }
    
    public void Update(Byte r, Byte g, Byte b, Byte a)
    {
        R = r;
        G = g;
        B = b;
        A = a;
    }
    
    public void Update(Color color)
    {
        R = color.R;
        G = color.G;
        B = color.B;
        A = color.A;
    }
    
    public void Update(String hex)
    {
        if (hex.StartsWith("#"))
            hex = hex.Substring(1);

        switch (hex.Length)
        {
            case 6:
                R = Convert.ToByte(hex.Substring(0, 2), 16);
                G = Convert.ToByte(hex.Substring(2, 2), 16);
                B = Convert.ToByte(hex.Substring(4, 2), 16);
                A = 255;
                break;
            case 8:
                R = Convert.ToByte(hex.Substring(0, 2), 16);
                G = Convert.ToByte(hex.Substring(2, 2), 16);
                B = Convert.ToByte(hex.Substring(4, 2), 16);
                A = Convert.ToByte(hex.Substring(6, 2), 16);
                break;
            default:
                throw new ArgumentException("Hex string must be 6 or 8 characters in length.");
        }
    }
    
    public void Update(UInt32 hex)
    {
        R = (Byte)((hex >> 24) & 0xFF);
        G = (Byte)((hex >> 16) & 0xFF);
        B = (Byte)((hex >> 8) & 0xFF);
        A = (Byte)(hex & 0xFF);
    }
    
    public void Update(Tuple<Byte, Byte, Byte> rgb)
    {
        R = rgb.Item1;
        G = rgb.Item2;
        B = rgb.Item3;
        A = 255;
    }
    
    public void Update(Tuple<Byte, Byte, Byte, Byte> rgba)
    {
        R = rgba.Item1;
        G = rgba.Item2;
        B = rgba.Item3;
        A = rgba.Item4;
    }
    
    // Predefined colors
    public static Color Black = new(0, 0, 0);
    public static Color White = new(255, 255, 255);
    public static Color Red = new(255, 0, 0);
    public static Color Green = new(0, 255, 0);
    public static Color Blue = new(0, 0, 255);
    public static Color Yellow = new(255, 255, 0);
    public static Color Magenta = new(255, 0, 255);
    public static Color Cyan = new(0, 255, 255);
}