using System;
using System.Linq;
using TauWarriorCore.Image;
using TauWarriorCore.Script;

namespace TauWarriorCore.Actions
{
    [Serializable]
    public class ScreenExists : IAction
    {
        public string Name => "Screen Exists";
        public ActionType ActionType => ActionType.ScreenExists;
        public string Image { get; }
        public bool FullScreen { get; }
        public bool IsColor { get; }
        public string Color { get; }
        public string Area { get; }
        public int Count { get; }
        public int Accuracy { get; }
        public string Info
        {
            get
            {
                return $"Exists {(IsColor ? $"\"{Color}\" color" : $"{Count}x\"{Image}\" image")} ({Accuracy}%) accuracy";
            }
        }
        public ScreenExists(string image, bool fullScreen, bool isColor, string color, string area, int count, int accuracy)
        {
            Image = image;
            FullScreen = fullScreen;
            IsColor = isColor;
            Color = color;
            Area = area;
            Count = count;
            Accuracy = accuracy;
        }
        public IAction GetCopy()
        {
            ScreenExists copy = new ScreenExists(Image, FullScreen, IsColor, Color, Area, Count, Accuracy);
            return copy;
        }
        public bool Start()
        {
            if (Warrior.Active)
            {
                if (FullScreen)
                {
                    if (IsColor)
                    {
                        var points = Screen.FindFirst(Warrior.CurrentScript.ScreenColors.First(x => x.Name == Color).Color, Accuracy);
                        if (points != null)
                            return true;
                        else
                            return false;
                    }
                    else
                    {
                        if (Count == 1)
                        {
                            var points = Screen.FindFirst(Image, Accuracy);
                            if (points != null)
                                return true;
                            else
                                return false;
                        }
                        else
                        {
                            var points = Screen.FindAll(Image, Accuracy);
                            if (points.Count >= Count)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
                else
                {
                    if (IsColor)
                    {
                        ScreenArea area = Warrior.CurrentScript.ScreenAreas.First(x => x.Name == Area);
                        var points = Screen.FindFirst(Warrior.CurrentScript.ScreenColors.First(x => x.Name == Color).Color, Accuracy, area.LeftTop, area.RightBottom);
                        if (points != null)
                            return true;
                        else
                            return false;
                    }
                    else
                    {
                        ScreenArea area = Warrior.CurrentScript.ScreenAreas.First(x => x.Name == Area);
                        if (Count == 1)
                        {
                            var points = Screen.FindFirst(Image, Accuracy, area.LeftTop, area.RightBottom);
                            if (points != null)
                                return true;
                            else
                                return false;
                        }
                        else
                        {
                            var points = Screen.FindAll(Image, Accuracy, area.LeftTop, area.RightBottom);
                            if (points.Count >= Count)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}
