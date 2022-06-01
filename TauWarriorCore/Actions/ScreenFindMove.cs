using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using TauWarriorCore.Image;
using TauWarriorCore.Input;
using TauWarriorCore.Script;

namespace TauWarriorCore.Actions
{
    [Serializable]
    public class ScreenFindMove : IAction
    {
        public string Name => "Screen Find Move";
        public ActionType ActionType => ActionType.ScreenFindMove;
        public string Image { get; }
        public bool FullScreen { get; }
        public bool First { get; }
        public bool Closest { get; }
        public bool IsColor { get; }
        public string Color { get; }
        public string Area { get; }
        public MouseSpeed Speed { get; }
        public int Accuracy { get; }
        public string Info
        {
            get
            {
                return $"Find Move {(First ? "First" : (Closest ? "Closest" : "All"))} {(IsColor ? $"\"{Color}\" color" : $"\"{Image}\" image")} ({Accuracy}%) accuracy";
            }
        }
        public ScreenFindMove(string image, bool fullScreen, bool first, bool closest, bool isColor, string area, MouseSpeed speed, string color, int accuracy)
        {
            Image = image;
            FullScreen = fullScreen;
            First = first;
            Closest = closest;
            IsColor = isColor;
            Area = area;
            Speed = speed;
            Color = color;
            Accuracy = accuracy;
        }
        public IAction GetCopy()
        {
            ScreenFindMove copy = new ScreenFindMove(Image, FullScreen, First, Closest, IsColor, Area, Speed, Color, Accuracy);
            return copy;
        }
        public bool Start()
        {
            if (Warrior.Active)
            {
                if (FullScreen)
                {
                    if (First)
                    {
                        Point? point = null;
                        if (IsColor)
                            point = Screen.FindFirst(Warrior.CurrentScript.ScreenColors.First(x => x.Name == Color).Color, Accuracy);
                        else
                            point = Screen.FindFirst(Image, Accuracy);
                        if (Warrior.ChangeState)
                            return false;
                        if (point != null)
                        {
                            Mouse.Move(point.Value, Speed);
                            if (Warrior.ChangeState)
                                return false;                            
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (Closest)
                    {
                        Point? point = null;
                        Point position = Mouse.Position();
                        if (IsColor)
                            point = Screen.FindClosest(Warrior.CurrentScript.ScreenColors.First(x => x.Name == Color).Color, position, Accuracy);
                        else
                            point = Screen.FindClosest(Image, position, Accuracy);
                        if (Warrior.ChangeState)
                            return false;
                        if (point != null)
                        {
                            Mouse.Move(point.Value, Speed);
                            if (Warrior.ChangeState)
                                return false;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        List<Point> points = Screen.FindAll(Image, Accuracy);
                        if (Warrior.ChangeState)
                            return false;
                        if (points.Count > 0)
                        {
                            foreach (var p in points)
                            {
                                Mouse.Move(p, Speed);
                                if (Warrior.ChangeState)
                                    return false;                                
                            }
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    if (First)
                    {
                        Point? point = null;
                        ScreenArea area = Warrior.CurrentScript.ScreenAreas.First(x => x.Name == Area);
                        if (IsColor)
                            point = Screen.FindFirst(Warrior.CurrentScript.ScreenColors.First(x => x.Name == Color).Color, Accuracy, area.LeftTop, area.RightBottom);
                        else
                            point = Screen.FindFirst(Image, Accuracy, area.LeftTop, area.RightBottom);
                        if (Warrior.ChangeState)
                            return false;
                        if (point != null)
                        {
                            Mouse.Move(point.Value, Speed);
                            if (Warrior.ChangeState)
                                return false;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (Closest)
                    {
                        Point? point = null;
                        Point position = Mouse.Position();
                        ScreenArea area = Warrior.CurrentScript.ScreenAreas.First(x => x.Name == Area);
                        if (IsColor)
                            point = Screen.FindClosest(Warrior.CurrentScript.ScreenColors.First(x => x.Name == Color).Color, position, Accuracy, area.LeftTop, area.RightBottom);
                        else
                            point = Screen.FindClosest(Image, position, Accuracy, area.LeftTop, area.RightBottom);
                        if (Warrior.ChangeState)
                            return false;
                        if (point != null)
                        {
                            Mouse.Move(point.Value, Speed);
                            if (Warrior.ChangeState)
                                return false;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        ScreenArea area = Warrior.CurrentScript.ScreenAreas.First(x => x.Name == Area);
                        List<Point> points = Screen.FindAll(Image, Accuracy, area.LeftTop, area.RightBottom);
                        if (Warrior.ChangeState)
                            return false;
                        if (points.Count > 0)
                        {
                            foreach (var p in points)
                            {
                                Mouse.Move(p, Speed);
                                if (Warrior.ChangeState)
                                    return false;
                            }
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            return false;
        }
        private void Wait(int ms)
        {
            while (ms > 0)
            {
                if (ms > 300)
                {
                    Thread.Sleep(300);
                    ms -= 300;
                    if (Warrior.ChangeState)
                        return;
                }
                else
                {
                    Thread.Sleep(ms);
                    ms = 0;
                }
            }
        }
    }
}