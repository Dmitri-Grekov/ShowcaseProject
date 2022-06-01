using System;

namespace TauWarriorCore.Script
{
    [Serializable]
    public struct ScreenImage
    {
        public string Name { get; set; }
        public byte[] Data { get; set; }
        public ScreenImage(string name, byte[] data)
        {
            Name = name;
            Data = data;
        }
    }
}
