using System;
using System.Drawing;

namespace TauWarriorCore.Script
{
    [Serializable]
    public struct ScreenArea
    {
        public string Name { get; set; }
        public Point LeftTop { get; set; }
        public Point RightBottom { get; set; }
        public ScreenArea(string name, Point leftTop, Point rightBottom)
        {
            Name = name;
            LeftTop = leftTop;
            RightBottom = rightBottom;
        }
    }
}
