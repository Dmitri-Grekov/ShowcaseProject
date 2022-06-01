using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace TauWarriorCore.Input
{
    public static class Keyboard
    {
        private static readonly Random random = new Random();
        private static readonly Stopwatch stopwatch = new Stopwatch();
        private const uint KEY_KEYUP = 0x0002;
        private const int KEY_PRESSED = 0x8000;
        public static void Press(KeyboardKeys key)
        {
            int ms = GeneratePressTime();
            keybd_event((byte)key, 0, 0, 0);
            Thread.Sleep(ms);
            keybd_event((byte)key, 0, KEY_KEYUP, 0);
            Thread.Sleep(1);
        }
        public static void PressDirectInput(KeyboardKeys key)
        {
            int ms = GeneratePressTime();
            byte k = ConvertToDirectInput(key);
            keybd_event(0, k, 0, 0);
            Thread.Sleep(ms);
            keybd_event(0, k, KEY_KEYUP, 0);
            Thread.Sleep(1);
        }
        public static void PressWithModifier(KeyboardKeys modifier, KeyboardKeys key)
        {
            int ms = GeneratePressTime();
            Hold(modifier);
            Thread.Sleep(ms);
            Press(key);
            Thread.Sleep(ms);
            Release(modifier);
            Thread.Sleep(1);
        }
        public static void PressWithModifier(KeyboardKeys modifier, KeyboardKeys secondModifier, KeyboardKeys key)
        {
            int ms = GeneratePressTime();
            Hold(modifier);
            Thread.Sleep(ms);
            Hold(secondModifier);
            Thread.Sleep(ms);
            Press(key);
            Thread.Sleep(ms);
            Release(secondModifier);
            Thread.Sleep(ms);
            Release(modifier);
            Thread.Sleep(1);
        }
        public static void PressWithModifierDirectInput(KeyboardKeys modifier, KeyboardKeys key)
        {
            int ms = GeneratePressTime();
            HoldDirectInput(modifier);
            Thread.Sleep(ms);
            PressDirectInput(key);
            Thread.Sleep(ms);
            ReleaseDirectInput(modifier);
            Thread.Sleep(1);
        }
        public static void PressWithModifierDirectInput(KeyboardKeys modifier, KeyboardKeys secondModifier, KeyboardKeys key)
        {
            int ms = GeneratePressTime();
            HoldDirectInput(modifier);
            Thread.Sleep(ms);
            HoldDirectInput(secondModifier);
            Thread.Sleep(ms);
            PressDirectInput(key);
            Thread.Sleep(ms);
            ReleaseDirectInput(secondModifier);
            Thread.Sleep(ms);
            ReleaseDirectInput(modifier);
            Thread.Sleep(1);
        }
        public static void PressString(string text)
        {
            foreach (var c in text)
            {
                if (char.IsWhiteSpace(c))
                {
                    Press(KeyboardKeys.SPACE);
                }
                else if (char.IsPunctuation(c))
                {
                    switch (c)
                    {
                        case '/': Press(KeyboardKeys.SLASH); break;
                        case ',': Press(KeyboardKeys.COMMA); break;
                        case '\\': Press(KeyboardKeys.BACKSLASH); break;
                        case '.': Press(KeyboardKeys.DOT); break;
                        case '-': Press(KeyboardKeys.MINUS); break;
                        case ';': Press(KeyboardKeys.SEMICOLON); break;
                        case '[': Press(KeyboardKeys.OPEN_SQUARE_BRACKET); break;
                        case ']': Press(KeyboardKeys.CLOSE_SQUARE_BRACKET); break;
                        case '\'': Press(KeyboardKeys.SINGLE_QUOTE); break;
                        case '!': PressWithModifier(KeyboardKeys.SHIFT, KeyboardKeys.KEY_1); break;
                        case '@': PressWithModifier(KeyboardKeys.SHIFT, KeyboardKeys.KEY_2); break;
                        case '#': PressWithModifier(KeyboardKeys.SHIFT, KeyboardKeys.KEY_3); break;
                        case '%': PressWithModifier(KeyboardKeys.SHIFT, KeyboardKeys.KEY_5); break;
                        case '&': PressWithModifier(KeyboardKeys.SHIFT, KeyboardKeys.KEY_7); break;
                        case '*': PressWithModifier(KeyboardKeys.SHIFT, KeyboardKeys.KEY_8); break;
                        case '(': PressWithModifier(KeyboardKeys.SHIFT, KeyboardKeys.KEY_9); break;
                        case ')': PressWithModifier(KeyboardKeys.SHIFT, KeyboardKeys.KEY_0); break;
                        case '_': PressWithModifier(KeyboardKeys.SHIFT, KeyboardKeys.MINUS); break;
                        case '?': PressWithModifier(KeyboardKeys.SHIFT, KeyboardKeys.SLASH); break;
                        case ':': PressWithModifier(KeyboardKeys.SHIFT, KeyboardKeys.SEMICOLON); break;
                        case '{': PressWithModifier(KeyboardKeys.SHIFT, KeyboardKeys.OPEN_SQUARE_BRACKET); break;
                        case '}': PressWithModifier(KeyboardKeys.SHIFT, KeyboardKeys.CLOSE_SQUARE_BRACKET); break;
                        case '\"': PressWithModifier(KeyboardKeys.SHIFT, KeyboardKeys.SINGLE_QUOTE); break;

                    }
                }
                else if (char.IsSymbol(c))
                {
                    switch (c)
                    {
                        case '=': Press(KeyboardKeys.EQUAL); break;
                        case '`': Press(KeyboardKeys.TILDE); break;
                        case '+': PressWithModifier(KeyboardKeys.SHIFT, KeyboardKeys.EQUAL); break;
                        case '~': PressWithModifier(KeyboardKeys.SHIFT, KeyboardKeys.TILDE); break;
                        case '|': PressWithModifier(KeyboardKeys.SHIFT, KeyboardKeys.BACKSLASH); break;
                        case '<': PressWithModifier(KeyboardKeys.SHIFT, KeyboardKeys.COMMA); break;
                        case '>': PressWithModifier(KeyboardKeys.SHIFT, KeyboardKeys.DOT); break;
                        case '$': PressWithModifier(KeyboardKeys.SHIFT, KeyboardKeys.KEY_4); break;
                        case '^': PressWithModifier(KeyboardKeys.SHIFT, KeyboardKeys.KEY_6); break;
                    }
                }
                else if (char.IsLetterOrDigit(c))
                {
                    if (char.IsUpper(c))
                    {
                        PressWithModifier(KeyboardKeys.SHIFT, (KeyboardKeys)c);
                    }
                    else
                    {
                        Press((KeyboardKeys)char.ToUpper(c));
                    }
                }
            }
        }
        public static void PressStringDirectInput(string text)
        {
            foreach (var c in text)
            {
                if (char.IsWhiteSpace(c))
                {
                    PressDirectInput(KeyboardKeys.SPACE);
                }
                else if (char.IsPunctuation(c))
                {
                    switch (c)
                    {
                        case '/': PressDirectInput(KeyboardKeys.SLASH); break;
                        case ',': PressDirectInput(KeyboardKeys.COMMA); break;
                        case '\\': PressDirectInput(KeyboardKeys.BACKSLASH); break;
                        case '.': PressDirectInput(KeyboardKeys.DOT); break;
                        case '-': PressDirectInput(KeyboardKeys.MINUS); break;
                        case ';': PressDirectInput(KeyboardKeys.SEMICOLON); break;
                        case '[': PressDirectInput(KeyboardKeys.OPEN_SQUARE_BRACKET); break;
                        case ']': PressDirectInput(KeyboardKeys.CLOSE_SQUARE_BRACKET); break;
                        case '\'': PressDirectInput(KeyboardKeys.SINGLE_QUOTE); break;
                        case '!': PressWithModifierDirectInput(KeyboardKeys.SHIFT, KeyboardKeys.KEY_1); break;
                        case '@': PressWithModifierDirectInput(KeyboardKeys.SHIFT, KeyboardKeys.KEY_2); break;
                        case '#': PressWithModifierDirectInput(KeyboardKeys.SHIFT, KeyboardKeys.KEY_3); break;
                        case '%': PressWithModifierDirectInput(KeyboardKeys.SHIFT, KeyboardKeys.KEY_5); break;
                        case '&': PressWithModifierDirectInput(KeyboardKeys.SHIFT, KeyboardKeys.KEY_7); break;
                        case '*': PressWithModifierDirectInput(KeyboardKeys.SHIFT, KeyboardKeys.KEY_8); break;
                        case '(': PressWithModifierDirectInput(KeyboardKeys.SHIFT, KeyboardKeys.KEY_9); break;
                        case ')': PressWithModifierDirectInput(KeyboardKeys.SHIFT, KeyboardKeys.KEY_0); break;
                        case '_': PressWithModifierDirectInput(KeyboardKeys.SHIFT, KeyboardKeys.MINUS); break;
                        case '?': PressWithModifierDirectInput(KeyboardKeys.SHIFT, KeyboardKeys.SLASH); break;
                        case ':': PressWithModifierDirectInput(KeyboardKeys.SHIFT, KeyboardKeys.SEMICOLON); break;
                        case '{': PressWithModifierDirectInput(KeyboardKeys.SHIFT, KeyboardKeys.OPEN_SQUARE_BRACKET); break;
                        case '}': PressWithModifierDirectInput(KeyboardKeys.SHIFT, KeyboardKeys.CLOSE_SQUARE_BRACKET); break;
                        case '\"': PressWithModifierDirectInput(KeyboardKeys.SHIFT, KeyboardKeys.SINGLE_QUOTE); break;

                    }
                }
                else if (char.IsSymbol(c))
                {
                    switch (c)
                    {
                        case '=': PressDirectInput(KeyboardKeys.EQUAL); break;
                        case '`': PressDirectInput(KeyboardKeys.TILDE); break;
                        case '+': PressWithModifierDirectInput(KeyboardKeys.SHIFT, KeyboardKeys.EQUAL); break;
                        case '~': PressWithModifierDirectInput(KeyboardKeys.SHIFT, KeyboardKeys.TILDE); break;
                        case '|': PressWithModifierDirectInput(KeyboardKeys.SHIFT, KeyboardKeys.BACKSLASH); break;
                        case '<': PressWithModifierDirectInput(KeyboardKeys.SHIFT, KeyboardKeys.COMMA); break;
                        case '>': PressWithModifierDirectInput(KeyboardKeys.SHIFT, KeyboardKeys.DOT); break;
                        case '$': PressWithModifierDirectInput(KeyboardKeys.SHIFT, KeyboardKeys.KEY_4); break;
                        case '^': PressWithModifierDirectInput(KeyboardKeys.SHIFT, KeyboardKeys.KEY_6); break;
                    }
                }
                else if (char.IsLetterOrDigit(c))
                {
                    if (char.IsUpper(c))
                    {
                        PressWithModifierDirectInput(KeyboardKeys.SHIFT, (KeyboardKeys)c);
                    }
                    else
                    {
                        PressDirectInput((KeyboardKeys)char.ToUpper(c));
                    }
                }
            }
        }
        public static bool IsPressed(KeyboardKeys key)
        {
            return Convert.ToBoolean(GetKeyState(key) & KEY_PRESSED);
        }
        public static bool IsPressedWithModifier(KeyboardKeys modifier, KeyboardKeys key)
        {
            bool m = Convert.ToBoolean(GetKeyState(modifier) & KEY_PRESSED);
            bool k = Convert.ToBoolean(GetKeyState(key) & KEY_PRESSED);
            if (m && k)
                return true;
            else
                return false;
        }
        public static bool IsPressedWithModifier(KeyboardKeys modifier, KeyboardKeys secondModifier, KeyboardKeys key)
        {
            bool m = Convert.ToBoolean(GetKeyState(modifier) & KEY_PRESSED);
            bool sm = Convert.ToBoolean(GetKeyState(secondModifier) & KEY_PRESSED);
            bool k = Convert.ToBoolean(GetKeyState(key) & KEY_PRESSED);
            if (m && sm && k)
                return true;
            else
                return false;
        }
        public static void Hold(KeyboardKeys key)
        {
            keybd_event((byte)key, 0, 0, 0);
        }
        public static void Release(KeyboardKeys key)
        {
            keybd_event((byte)key, 0, KEY_KEYUP, 0);
        }
        public static void HoldDirectInput(KeyboardKeys key)
        {
            keybd_event(0, ConvertToDirectInput(key), 0, 0);
        }
        public static void ReleaseDirectInput(KeyboardKeys key)
        {
            keybd_event(0, ConvertToDirectInput(key), KEY_KEYUP, 0);
        }
        private static int GeneratePressTime()
        {
            return random.Next(60, 100);
        }
        private static byte ConvertToDirectInput(KeyboardKeys key)
        {
            switch (key)
            {
                case KeyboardKeys.A: return 0x1E;
                case KeyboardKeys.ADD: return 0x4E;
                case KeyboardKeys.ALT: return 0x38;
                case KeyboardKeys.B: return 0x30;
                case KeyboardKeys.BACK: return 0x0E;
                case KeyboardKeys.BACKSLASH: return 0x2B;
                case KeyboardKeys.C: return 0x2E;
                case KeyboardKeys.CLOSE_SQUARE_BRACKET: return 0x1B;
                case KeyboardKeys.COMMA: return 0x33;
                case KeyboardKeys.CTRL: return 0x1D;
                case KeyboardKeys.D: return 0x20;
                case KeyboardKeys.DELETE: return 0xD3;
                case KeyboardKeys.DIVIDE: return 0xB5;
                case KeyboardKeys.DOT: return 0x34;
                case KeyboardKeys.DOWN: return 0xD0;
                case KeyboardKeys.E: return 0x12;
                case KeyboardKeys.END: return 0xCF;
                case KeyboardKeys.EQUAL: return 0x0D;
                case KeyboardKeys.ESCAPE: return 0x01;
                case KeyboardKeys.F: return 0x21;
                case KeyboardKeys.F1: return 0x3B;
                case KeyboardKeys.F10: return 0x44;
                case KeyboardKeys.F11: return 0x57;
                case KeyboardKeys.F12: return 0x58;
                case KeyboardKeys.F2: return 0x3C;
                case KeyboardKeys.F3: return 0x3D;
                case KeyboardKeys.F4: return 0x3E;
                case KeyboardKeys.F5: return 0x3F;
                case KeyboardKeys.F6: return 0x40;
                case KeyboardKeys.F7: return 0x41;
                case KeyboardKeys.F8: return 0x42;
                case KeyboardKeys.F9: return 0x43;
                case KeyboardKeys.G: return 0x22;
                case KeyboardKeys.H: return 0x23;
                case KeyboardKeys.HOME: return 0xC7;
                case KeyboardKeys.I: return 0x17;
                case KeyboardKeys.INSERT: return 0xD2;
                case KeyboardKeys.J: return 0x24;
                case KeyboardKeys.K: return 0x25;
                case KeyboardKeys.KEY_0: return 0x0B;
                case KeyboardKeys.KEY_1: return 0x02;
                case KeyboardKeys.KEY_2: return 0x03;
                case KeyboardKeys.KEY_3: return 0x04;
                case KeyboardKeys.KEY_4: return 0x05;
                case KeyboardKeys.KEY_5: return 0x06;
                case KeyboardKeys.KEY_6: return 0x07;
                case KeyboardKeys.KEY_7: return 0x08;
                case KeyboardKeys.KEY_8: return 0x09;
                case KeyboardKeys.KEY_9: return 0x0A;
                case KeyboardKeys.L: return 0x26;
                case KeyboardKeys.LCONTROL: return 0x1D;
                case KeyboardKeys.LEFT: return 0xCB;
                case KeyboardKeys.LSHIFT: return 0x2A;
                case KeyboardKeys.LWIN: return 0xDB;
                case KeyboardKeys.M: return 0x32;
                case KeyboardKeys.MINUS: return 0x0C;
                case KeyboardKeys.MULTIPLY: return 0x37;
                case KeyboardKeys.N: return 0x31;
                case KeyboardKeys.NONE: return 0;
                case KeyboardKeys.NUMPAD_0: return 0x52;
                case KeyboardKeys.NUMPAD_1: return 0x4F;
                case KeyboardKeys.NUMPAD_2: return 0x50;
                case KeyboardKeys.NUMPAD_3: return 0x51;
                case KeyboardKeys.NUMPAD_4: return 0x4B;
                case KeyboardKeys.NUMPAD_5: return 0x4C;
                case KeyboardKeys.NUMPAD_6: return 0x4D;
                case KeyboardKeys.NUMPAD_7: return 0x47;
                case KeyboardKeys.NUMPAD_8: return 0x48;
                case KeyboardKeys.NUMPAD_9: return 0x49;
                case KeyboardKeys.O: return 0x18;
                case KeyboardKeys.OPEN_SQUARE_BRACKET: return 0x1A;
                case KeyboardKeys.P: return 0x19;
                case KeyboardKeys.PAGE_DOWN: return 0xD1;
                case KeyboardKeys.PAGE_UP: return 0xC9;
                case KeyboardKeys.PAUSE: return 0;
                case KeyboardKeys.PRINT_SCREEN: return 0;
                case KeyboardKeys.Q: return 0x10;
                case KeyboardKeys.R: return 0x13;
                case KeyboardKeys.RCONTROL: return 0x9D;
                case KeyboardKeys.RETURN: return 0x1C;
                case KeyboardKeys.RIGHT: return 0xCD;
                case KeyboardKeys.RSHIFT: return 0x36;
                case KeyboardKeys.RWIN: return 0xDC;
                case KeyboardKeys.S: return 0x1F;
                case KeyboardKeys.SEMICOLON: return 0x27;
                case KeyboardKeys.SHIFT: return 0x2A;
                case KeyboardKeys.SINGLE_QUOTE: return 0x28;
                case KeyboardKeys.SLASH: return 0x35;
                case KeyboardKeys.SPACE: return 0x39;
                case KeyboardKeys.SUBTRACT: return 0x4A;
                case KeyboardKeys.T: return 0x14;
                case KeyboardKeys.TAB: return 0x0F;
                case KeyboardKeys.TILDE: return 0;
                case KeyboardKeys.U: return 0x16;
                case KeyboardKeys.UP: return 0xC8;
                case KeyboardKeys.V: return 0x2F;
                case KeyboardKeys.W: return 0x11;
                case KeyboardKeys.X: return 0x2D;
                case KeyboardKeys.Y: return 0x15;
                case KeyboardKeys.Z: return 0x2C;
                default: return 0;
            }
        }
        [DllImport("user32.dll")]
        private static extern short GetKeyState(KeyboardKeys key);
        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);
    }
    public enum KeyboardKeys : int
    {
        NONE = 0,
        CANCEL = 0x03,
        BACK = 0x08,
        TAB = 0x09,
        RETURN = 0x0D,
        SHIFT = 0x10,
        CTRL = 0x11,
        ALT = 0x12,
        PAUSE = 0x13,
        ESCAPE = 0x1B,
        SPACE = 0x20,
        PAGE_UP = 0x21,
        PAGE_DOWN = 0x22,
        END = 0x23,
        HOME = 0x24,
        LEFT = 0x25,
        UP = 0x26,
        RIGHT = 0x27,
        DOWN = 0x28,
        PRINT_SCREEN = 0x2C,
        INSERT = 0x2D,
        DELETE = 0x2E,
        KEY_0 = 0x30,
        KEY_1 = 0x31,
        KEY_2 = 0x32,
        KEY_3 = 0x33,
        KEY_4 = 0x34,
        KEY_5 = 0x35,
        KEY_6 = 0x36,
        KEY_7 = 0x37,
        KEY_8 = 0x38,
        KEY_9 = 0x39,
        A = 0x41,
        B = 0x42,
        C = 0x43,
        D = 0x44,
        E = 0x45,
        F = 0x46,
        G = 0x47,
        H = 0x48,
        I = 0x49,
        J = 0x4A,
        K = 0x4B,
        L = 0x4C,
        M = 0x4D,
        N = 0x4E,
        O = 0x4F,
        P = 0x50,
        Q = 0x51,
        R = 0x52,
        S = 0x53,
        T = 0x54,
        U = 0x55,
        V = 0x56,
        W = 0x57,
        X = 0x58,
        Y = 0x59,
        Z = 0x5A,
        LWIN = 0x5B,
        RWIN = 0x5C,
        NUMPAD_0 = 0x60,
        NUMPAD_1 = 0x61,
        NUMPAD_2 = 0x62,
        NUMPAD_3 = 0x63,
        NUMPAD_4 = 0x64,
        NUMPAD_5 = 0x65,
        NUMPAD_6 = 0x66,
        NUMPAD_7 = 0x67,
        NUMPAD_8 = 0x68,
        NUMPAD_9 = 0x69,
        MULTIPLY = 0x6A,
        COMMA = 0xBC,
        DOT = 0xBE,
        MINUS = 0xBD,
        EQUAL = 0xBB,
        ADD = 0x6B,
        SLASH = 0xBF,
        TILDE = 0xC0,
        SEMICOLON = 0xBA,
        OPEN_SQUARE_BRACKET = 0xDB,
        CLOSE_SQUARE_BRACKET = 0xDD,
        SINGLE_QUOTE = 0xDE,
        BACKSLASH = 0xE2,
        SUBTRACT = 0x6D,
        DIVIDE = 0x6F,
        F1 = 0x70,
        F2 = 0x71,
        F3 = 0x72,
        F4 = 0x73,
        F5 = 0x74,
        F6 = 0x75,
        F7 = 0x76,
        F8 = 0x77,
        F9 = 0x78,
        F10 = 0x79,
        F11 = 0x7A,
        F12 = 0x7B,
        LSHIFT = 0xA0,
        RSHIFT = 0xA1,
        LCONTROL = 0xA2,
        RCONTROL = 0xA3,
    }
}
