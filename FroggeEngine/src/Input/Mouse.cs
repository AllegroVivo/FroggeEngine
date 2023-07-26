using System;
using System.Runtime.InteropServices;

namespace Frogge.Input;

public class Mouse
{
    public enum Button
    {
        Left = 0x01,
        Right = 0x02,
        Middle = 0x04
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Point
    {
        public int X;
        public int Y;
    }
    
    [DllImport("user32.dll")]
    public static extern Boolean GetCursorPos(out Point lpPoint);
        
    [DllImport("user32.dll")]
    public static extern Int16 GetAsyncKeyState(Int32 vKey);

    public static Point GetPosition()
    {
        GetCursorPos(out Point point);
        return point;
    }

    public static Boolean IsButtonDown(Button button)
    {
        return (GetAsyncKeyState((Int32)button) & 0x8000) != 0;
    }
}