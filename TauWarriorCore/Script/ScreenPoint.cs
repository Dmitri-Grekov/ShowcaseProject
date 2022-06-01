using System;
using System.Drawing;

namespace TauWarriorCore.Script
{
    [Serializable]
    public struct ScreenPoint
    {
        public string Name { get; set; }
        public Point Point { get; set; }
        public ScreenPoint(string name, Point point)
        {
            Name = name;
            Point = point;
        }
    }
}
