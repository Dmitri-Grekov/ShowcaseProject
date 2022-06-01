using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Threading;

namespace TauWarriorCore.Image
{
    public static class Screen
    {
        private static readonly List<ImageData> images = new List<ImageData>();
        private static readonly Bitmap screen = ScreenBitmap();
        private static readonly Graphics graphics = Graphics.FromImage(screen);
        private static readonly object locker = new object();        
        public static void ImagesAdd(ImageData data)
        {
            images.Add(data);
        }
        public static void ImagesClear()
        {
            images.Clear();
        }
        public static int Count(string image, int accuracy = 100, Point? leftTop = null, Point? rightBottom = null)
        {
            accuracy = 100 - accuracy;
            return Search(image, (int)accuracy, false, leftTop, rightBottom).Count;
        }
        public static bool Exists(string image, int accuracy = 100, Point? leftTop = null, Point? rightBottom = null)
        {
            accuracy = 100 - accuracy;
            if (Search(image, (int)accuracy, true, leftTop, rightBottom).Count > 0)
                return true;
            else
                return false;
        }
        public static bool Exists(Color color, int accuracy = 100, Point? leftTop = null, Point? rightBottom = null)
        {
            accuracy = 100 - accuracy;
            if (SearchColor(color, (int)accuracy, true, leftTop, rightBottom).Count > 0)
                return true;
            else
                return false;
        }
        public static bool Exists(Color color, Point point, int accuracy = 100)
        {
            accuracy = 100 - accuracy;
            byte[] scr = GetScreen();
            return CheckPixel(scr[(point.Y * screen.Width * 4) + (point.X * 4)], scr[(point.Y * screen.Width * 4) + (point.X * 4) + 1], scr[(point.Y * screen.Width * 4) + (point.X * 4) + 2], color, (int)accuracy);
        }
        public static Point? FindClosest(string image, Point point, int accuracy = 100, Point? leftTop = null, Point? rightBottom = null)
        {
            accuracy = 100 - accuracy;
            var points = Search(image, (int)accuracy, false, leftTop, rightBottom);
            if (points.Count > 0)
                return points.OrderBy(x => Vector2.Distance(new Vector2(x.X, x.Y), new Vector2(point.X, point.Y))).First();
            else
                return null;
        }
        public static Point? FindClosest(Color color, Point point, int accuracy = 100, Point? leftTop = null, Point? rightBottom = null)
        {
            accuracy = 100 - accuracy;
            var points = SearchColor(color, (int)accuracy, false, leftTop, rightBottom);
            if (points.Count > 0)
                return points.OrderBy(x => Vector2.Distance(new Vector2(x.X, x.Y), new Vector2(point.X, point.Y))).First();
            else
                return null;
        }
        public static Point? FindFirst(string image, int accuracy = 100, Point? leftTop = null, Point? rightBottom = null)
        {
            accuracy = 100 - accuracy;
            var points = Search(image, (int)accuracy, true, leftTop, rightBottom);
            if (points.Count > 0)
                return points[0];
            else
                return null;
        }
        public static Point? FindFirst(Color color, int accuracy = 100, Point? leftTop = null, Point? rightBottom = null)
        {
            accuracy = 100 - accuracy;
            var points = SearchColor(color, (int)accuracy, true, leftTop, rightBottom);
            if (points.Count > 0)
                return points[0];
            else
                return null;
        }
        public static List<Point> FindAll(string image, int accuracy = 100, Point? leftTop = null, Point? rightBottom = null)
        {
            accuracy = 100 - accuracy;
            return Search(image, (int)accuracy, false, leftTop, rightBottom);
        }
        public static Bitmap ScreenShot(Point? leftTop = null, Point? rightBottom = null)
        {
            Bitmap scr;
            if (leftTop == null)
            {
                lock (locker)
                {
                    graphics.CopyFromScreen(0, 0, 0, 0, new Size(screen.Width, screen.Height));
                    scr = new Bitmap(screen);
                }
            }
            else
            {
                lock (locker)
                {
                    graphics.CopyFromScreen(0, 0, 0, 0, new Size(screen.Width, screen.Height));
                    scr = screen.Clone(new Rectangle(leftTop.Value, new Size(rightBottom.Value.X - leftTop.Value.X, rightBottom.Value.Y - leftTop.Value.Y)), PixelFormat.Format32bppArgb);
                }
            }
            return scr;
        }
        private static bool CheckPixel(byte blue, byte green, byte red, Color color, int accuracy)
        {
            if (blue < color.B - accuracy
                            || blue > color.B + accuracy
                            || green < color.G - accuracy
                            || green > color.G + accuracy
                            || red < color.R - accuracy
                            || red > color.R + accuracy)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private static byte[] GetScreen()
        {
            lock (locker)
            {
                graphics.CopyFromScreen(0, 0, 0, 0, new Size(screen.Width, screen.Height));
                byte[] data = new byte[screen.Width * screen.Height * 4];
                Rectangle rect = new Rectangle(0, 0, screen.Width, screen.Height);
                BitmapData bitmapData = screen.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                IntPtr ptr = bitmapData.Scan0;
                Marshal.Copy(ptr, data, 0, data.Length);
                screen.UnlockBits(bitmapData);
                return data;
            }
        }
        private static Bitmap ScreenBitmap()
        {
            MonitorInfoEx m = new MonitorInfoEx();
            m.Size = 72;
            GetMonitorInfo(MonitorFromWindow(GetDesktopWindow(), 1), ref m);
            return new Bitmap(m.Monitor.Right, m.Monitor.Bottom, PixelFormat.Format32bppArgb);
        }
        private static List<Point> Search(string image, int accuracy, bool findFirst = false, Point? leftTop = null, Point? rightBottom = null)
        {
            List<Point> points = new List<Point>();
            if (leftTop == null)
            {
                ImageData img = images.First(x => x.Name == image);
                byte[] scr = GetScreen();
                for (int y = 0; y < screen.Height - img.Height + 1; y++)
                {
                    for (int x = 0; x < screen.Width - img.Width + 1; x++)
                    {
                        if (img.CheckPixel(x, y, scr, screen.Width, accuracy))
                        {
                            points.Add(new Point(x + img.Width / 2, y + img.Height / 2));
                            if (findFirst)
                                return points;
                        }
                    }
                }
            }
            else
            {
                ImageData img = images.First(x => x.Name == image);
                byte[] scr = GetScreen();
                for (int y = leftTop.Value.Y; y < rightBottom.Value.Y - img.Height + 1; y++)
                {
                    for (int x = leftTop.Value.X; x < rightBottom.Value.X - img.Width + 1; x++)
                    {
                        if (img.CheckPixel(x, y, scr, screen.Width, accuracy))
                        {
                            points.Add(new Point(x + img.Width / 2, y + img.Height / 2));
                            if (findFirst)
                                return points;
                        }
                    }
                }
            }
            return points;
        }
        private static List<Point> SearchColor(Color color, int accuracy, bool findFirst = false, Point? leftTop = null, Point? rightBottom = null)
        {
            List<Point> points = new List<Point>();
            if (leftTop == null)
            {
                byte[] scr = GetScreen();
                for (int y = 0; y < screen.Height; y++)
                {
                    for (int x = 0; x < screen.Width; x++)
                    {
                        if (CheckPixel(scr[(y * screen.Width * 4) + (x * 4)], scr[(y * screen.Width * 4) + (x * 4) + 1], scr[(y * screen.Width * 4) + (x * 4) + 2], color, accuracy))
                        {
                            points.Add(new Point(x, y));
                            if (findFirst)
                                return points;
                        }
                    }
                }
            }
            else
            {
                byte[] scr = GetScreen();
                for (int y = leftTop.Value.Y; y < rightBottom.Value.Y; y++)
                {
                    for (int x = leftTop.Value.X; x < rightBottom.Value.X; x++)
                    {
                        if (CheckPixel(scr[(y * screen.Width * 4) + (x * 4)], scr[(y * screen.Width * 4) + (x * 4) + 1], scr[(y * screen.Width * 4) + (x * 4) + 2], color, accuracy))
                        {
                            points.Add(new Point(x, y));
                            if (findFirst)
                                return points;
                        }
                    }
                }
            }
            return points;
        }
        private struct MonitorInfoEx
        {
            public int Size;
            public RectStruct Monitor;
            public RectStruct WorkArea;
            public uint Flags;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string DeviceName;

            public void Init()
            {
                Size = 40 + 2 * 32;
                DeviceName = string.Empty;
            }
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct RectStruct
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        [DllImport("user32.dll", SetLastError = false)]
        private static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll")]
        private static extern bool GetMonitorInfo(IntPtr hMonitor, ref MonitorInfoEx lpmi);
        [DllImport("user32.dll")]
        private static extern IntPtr MonitorFromWindow(IntPtr hwnd, uint dwFlags);
    }
}
