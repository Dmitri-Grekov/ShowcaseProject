using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace TauWarriorCore.Image
{
    public class ImageData
    {
        private readonly byte[] PixelData;
        public string Name { get; }
        public int Width { get; }
        public int Height { get; }
        public ImageData(string name, Bitmap image)
        {
            Name = name;
            Width = image.Width;
            Height = image.Height;
            PixelData = new byte[Width * Height * 4];
            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);
            BitmapData bitmapData = image.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            IntPtr ptr = bitmapData.Scan0;
            Marshal.Copy(ptr, PixelData, 0, PixelData.Length);
            image.UnlockBits(bitmapData);
            image.Dispose();
        }
        public bool CheckPixel(int x, int y, byte[] data, int width, int accuracy)
        {
            int line = Width * 4;
            int globalLine = width * 4;
            x *= 4;
            for (int h = 0; h < Height; h++)
            {
                for (int w = 0; w < Width; w++)
                {
                    if (PixelData[(h * line) + (w * 4)] < data[((y + h) * globalLine) + x + (w * 4)] - accuracy
                        || PixelData[(h * line) + (w * 4)] > data[((y + h) * globalLine) + x + (w * 4)] + accuracy
                        || PixelData[(h * line) + (w * 4) + 1] < data[((y + h) * globalLine) + x + (w * 4) + 1] - accuracy
                        || PixelData[(h * line) + (w * 4) + 1] > data[((y + h) * globalLine) + x + (w * 4) + 1] + accuracy
                        || PixelData[(h * line) + (w * 4) + 2] < data[((y + h) * globalLine) + x + (w * 4) + 2] - accuracy
                        || PixelData[(h * line) + (w * 4) + 2] > data[((y + h) * globalLine) + x + (w * 4) + 2] + accuracy)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
