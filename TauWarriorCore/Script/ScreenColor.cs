using System;
using System.Drawing;

namespace TauWarriorCore.Script
{
    [Serializable]
    public struct ScreenColor
    {
        public string Name { get; set; }
        public Color Color {  get; set; }
        public ScreenColor(string name, Color color)
        {
            Name = name;
            Color = color;
        }
    }
}
