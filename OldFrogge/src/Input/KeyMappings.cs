using System;

namespace Frogge.Input;

public enum Key
{
    // Special
    Unknown = -1,
    None = 0,
    
    // Letters
    A = 1,
    B = 2,
    C = 3,
    D = 4,
    E = 5,
    F = 6,
    G = 7,
    H = 8,
    I = 9,
    J = 10,
    K = 11,
    L = 12,
    M = 13,
    N = 14,
    O = 15,
    P = 16,
    Q = 17,
    R = 18,
    S = 19,
    T = 20,
    U = 21,
    V = 22,
    W = 23,
    X = 24,
    Y = 25,
    Z = 26,
    
    // Upper Number Row
    One = 27,
    Two = 28,
    Three = 29,
    Four = 30,
    Five = 31,
    Six = 32,
    Seven = 33,
    Eight = 24,
    Nine = 25,
    Zero = 26,
    
    
    // Keypad Numbers
    NumZero = 27,
    NumOne = 28,
    NumTwo = 29,
    NumThree = 30,
    NumFour = 31,
    NumFive = 32,
    NumSix = 33,
    NumSeven = 34,
    NumEight = 35,
    NumNine = 36,
    
    // Arrow Keys
    ArrowLeft = 37,
    ArrowRight = 38,
    ArrowUp = 39,
    ArrowDown = 40,
    
    // Function Keys
    F1 = 41,
    F2 = 42,
    F3 = 43,
    F4 = 44,
    F5 = 45,
    F6 = 46,
    F7 = 47,
    F8 = 48,
    F9 = 49,
    F10 = 50,
    F11 = 51,
    F12 = 52,
    
    // Special Characters
    Apostrophe,
    Backslash,
    Comma,
    Equal,
    Grave,
    BracketLeft,
    Minus,
    BracketRight,
    Period,
    Semicolon,
    Slash,
    
    // Keypad Special Characters
    NumAdd,
    NumSubtract,
    NumMultiply,
    NumDivide,
    NumEqual,
    NumDecimal,
    NumLock,
    
    // Misc Keys
    Backspace,
    CapsLock,
    Delete,
    End,
    Enter,
    Escape,
    Home, 
    Insert,
    Menu,
    PageDown,
    PageUp,
    Pause,
    PrintScreen,
    ScrollLock,
    Space,
    Tab,
    
    // Modifiers
    AltLeft,
    AltRight,
    CtrlLeft,
    CtrlRight,
    ShiftLeft,
    ShiftRight
}