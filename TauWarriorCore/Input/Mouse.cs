using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Threading;

namespace TauWarriorCore.Input
{
    public static class Mouse
    {
        private static readonly Random random = new Random();
        private const int KEY_PRESSED = 0x8000;
        public static void Move(Point point, MouseSpeed mouseSpeed)
        {
            Point start = Position();
            List<PathPoint> path = GetMovePath(start, point, mouseSpeed);
            foreach (var p in path)
            {
                SetPosition(p.Point);
                Thread.Sleep(p.Time);
            }
        }
        public static int MoveTime(Point start, Point point, MouseSpeed mouseSpeed)
        {
            List<PathPoint> path = GetMovePath(start, point, mouseSpeed);
            int time = 0;
            foreach (var p in path)
            {
                time += p.Time;
            }
            return time;
        }
        public static void Click(MouseKeys mouseKey)
        {
            int ms = GenerateClickTime();
            switch (mouseKey)
            {
                case MouseKeys.Left: mouse_event((uint)MouseFlags.LEFTDOWN, 0, 0, 0, 0); Thread.Sleep(ms); mouse_event((uint)MouseFlags.LEFTUP, 0, 0, 0, 0); Thread.Sleep(1); break;
                case MouseKeys.Middle: mouse_event((uint)MouseFlags.MIDDLEDOWN, 0, 0, 0, 0); Thread.Sleep(ms); mouse_event((uint)MouseFlags.MIDDLEUP, 0, 0, 0, 0); Thread.Sleep(1); break;
                case MouseKeys.Right: mouse_event((uint)MouseFlags.RIGHTDOWN, 0, 0, 0, 0); Thread.Sleep(ms); mouse_event((uint)MouseFlags.RIGHTUP, 0, 0, 0, 0); Thread.Sleep(1); break;
                case MouseKeys.XButton1: mouse_event((uint)MouseFlags.XDOWN, 0, 0, (uint)MouseFlags.XBUTTON1, 0); Thread.Sleep(ms); mouse_event((uint)MouseFlags.XUP, 0, 0, (uint)MouseFlags.XBUTTON1, 0); Thread.Sleep(1); break;
                case MouseKeys.XButton2: mouse_event((uint)MouseFlags.XDOWN, 0, 0, (uint)MouseFlags.XBUTTON2, 0); Thread.Sleep(ms); mouse_event((uint)MouseFlags.XUP, 0, 0, (uint)MouseFlags.XBUTTON2, 0); Thread.Sleep(1); break;
            }
        }
        public static void Wheel(MouseWheel mouseWheel)
        {
            if (mouseWheel == MouseWheel.Up)
            {
                mouse_event((uint)MouseFlags.WHEEL, 0, 0, (uint)MouseWheel.Up, 0);
                Thread.Sleep(1);
            }
            else
            {
                int i = (int)MouseWheel.Down;
                mouse_event((uint)MouseFlags.WHEEL, 0, 0, (uint)i, 0);
                Thread.Sleep(1);
            }
        }
        public static bool IsPressed(MouseKeys key)
        {
            return Convert.ToBoolean(GetKeyState(key) & KEY_PRESSED);
        }
        public static void Hold(MouseKeys mouseKey)
        {
            switch (mouseKey)
            {
                case MouseKeys.Left: mouse_event((uint)MouseFlags.LEFTDOWN, 0, 0, 0, 0); Thread.Sleep(1); break;
                case MouseKeys.Middle: mouse_event((uint)MouseFlags.MIDDLEDOWN, 0, 0, 0, 0); Thread.Sleep(1); break;
                case MouseKeys.Right: mouse_event((uint)MouseFlags.RIGHTDOWN, 0, 0, 0, 0); Thread.Sleep(1); break;
                case MouseKeys.XButton1: mouse_event((uint)MouseFlags.XDOWN, 0, 0, (uint)MouseFlags.XBUTTON1, 0); Thread.Sleep(1); break;
                case MouseKeys.XButton2: mouse_event((uint)MouseFlags.XDOWN, 0, 0, (uint)MouseFlags.XBUTTON2, 0); Thread.Sleep(1); break;
            }
        }
        public static void Release(MouseKeys mouseKey)
        {
            switch (mouseKey)
            {
                case MouseKeys.Left: mouse_event((uint)MouseFlags.LEFTUP, 0, 0, 0, 0); Thread.Sleep(1); break;
                case MouseKeys.Middle: mouse_event((uint)MouseFlags.MIDDLEUP, 0, 0, 0, 0); Thread.Sleep(1); break;
                case MouseKeys.Right: mouse_event((uint)MouseFlags.RIGHTUP, 0, 0, 0, 0); Thread.Sleep(1); break;
                case MouseKeys.XButton1: mouse_event((uint)MouseFlags.XUP, 0, 0, (uint)MouseFlags.XBUTTON1, 0); Thread.Sleep(1); break;
                case MouseKeys.XButton2: mouse_event((uint)MouseFlags.XUP, 0, 0, (uint)MouseFlags.XBUTTON2, 0); Thread.Sleep(1); break;
            }
        }
        public static Point Position()
        {
            GetCursorPos(out POINT point);
            return point.ToPoint();
        }
        private static void SetPosition(Point point)
        {
            SetCursorPos(point.X, point.Y);
        }
        private static int GenerateClickTime()
        {
            return random.Next(70, 100);
        }
        private static List<PathPoint> GetMovePath(Point start, Point target, MouseSpeed mouseSpeed)
        {
            List<PathPoint> path = new List<PathPoint>();
            Vector2 startV = new Vector2(start.X, start.Y);
            Vector2 targetV = new Vector2(target.X, target.Y);
            float distance = Vector2.Distance(startV, targetV);
            float points = distance / (float)mouseSpeed;
            Vector2 step = Vector2.Divide(Vector2.Subtract(targetV, startV), points);
            for (int i = 0; i < (int)points; i++)
            {
                startV += step;
                Point point = new Point((int)Math.Round(startV.X), (int)Math.Round(startV.Y));
                point.X = random.Next(point.X - 2, point.X + 3);
                point.Y = random.Next(point.Y - 2, point.Y + 3);
                if (point.X < 0)
                    point.X = 0;
                if (point.Y < 0)
                    point.Y = 0;
                var time = 100 - random.Next((int)Math.Round((float)mouseSpeed * 0.95f), (int)Math.Round((float)mouseSpeed * 1.1f));
                if (time < 5)
                    time = 5;
                path.Add(new PathPoint(point, time));
            }
            path.Add(new PathPoint(target, 1));
            return path;
        }
        private enum MouseFlags : uint
        {
            LEFTDOWN = 0x0002,
            LEFTUP = 0x0004,
            MIDDLEDOWN = 0x0020,
            MIDDLEUP = 0x0040,
            RIGHTDOWN = 0x0008,
            RIGHTUP = 0x0010,
            WHEEL = 0x0800,
            XDOWN = 0x0080,
            XUP = 0x0100,
            XBUTTON1 = 0x0001,
            XBUTTON2 = 0x0002
        }
        private struct PathPoint
        {
            public Point Point { get; }
            public int Time { get; }
            public PathPoint(Point point, int time)
            {
                Point = point;
                Time = time;
            }
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int X;
            public int Y;
            public POINT(int x, int y)
            {
                X = x;
                Y = y;
            }
            public Point ToPoint()
            {
                return new Point(X, Y);
            }
        }
        [DllImport("user32.dll")]
        private static extern short GetKeyState(MouseKeys key);
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(out POINT lpPoint);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetCursorPos(int x, int y);
        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, int dwExtraInfo);
    }
    public enum MouseSpeed
    {
        VerySlow = 10, Slow = 25, Normal = 50, Fast = 75, VeryFast = 90
    }
    public enum MouseKeys
    {
        Left = 0x01, Right = 0x02, Middle = 0x04, XButton1 = 0x05, XButton2 = 0x06
    }
    public enum MouseWheel
    {
        Up = 120, Down = -120
    }
}
