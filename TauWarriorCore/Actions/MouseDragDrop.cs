using System;
using System.Drawing;
using System.Linq;
using TauWarriorCore.Image;
using TauWarriorCore.Input;
using TauWarriorCore.Script;

namespace TauWarriorCore.Actions
{
    [Serializable]
    public class MouseDragDrop : IAction
    {
        public string Name => "Mouse Drag Drop";
        public ActionType ActionType => ActionType.MouseDragDrop;
        public bool FirstFullScreen { get; }
        public bool SecondFullScreen { get; }
        public string FirstArea { get; }
        public string SecondArea { get; }
        public bool IsFirstPoint { get; }
        public bool IsSecondPoint { get; }
        public string FirstPoint { get; }
        public string SecondPoint { get; }
        public string FirstImage { get; }
        public string SecondImage { get; }
        public int FirstAccuracy { get; }
        public int SecondAccuracy { get; }
        public MouseSpeed Speed { get; }
        public string Info
        {
            get
            {
                if(IsFirstPoint)
                {
                    if(IsSecondPoint)
                    {
                        return $"DragDrop from \"{FirstPoint}\" point to \"{SecondPoint}\" point";
                    }
                    else
                    {
                        return $"DragDrop from \"{FirstPoint}\" point to \"{SecondImage}\" image";
                    }
                }
                else
                {
                    if (IsSecondPoint)
                    {
                        return $"DragDrop from \"{FirstImage}\" image to \"{SecondPoint}\" point";
                    }
                    else
                    {
                        return $"DragDrop from \"{FirstImage}\" image to \"{SecondImage}\" image";
                    }
                }
            }
        }
        public MouseDragDrop(bool firstFullScreen, bool secondFullScreen, string firstArea, string secondArea, bool isFirstPoint, bool isSecondPoint, string firstPoint, string secondPoint, string firstImage, string secondImage, int firstAccuracy, int secondAccuracy, MouseSpeed speed)
        {
            FirstFullScreen = firstFullScreen;
            SecondFullScreen = secondFullScreen;
            FirstArea = firstArea;
            SecondArea = secondArea;
            IsFirstPoint = isFirstPoint;
            IsSecondPoint = isSecondPoint;
            FirstPoint = firstPoint;
            SecondPoint = secondPoint;
            FirstImage = firstImage;
            SecondImage = secondImage;
            FirstAccuracy = firstAccuracy;
            SecondAccuracy = secondAccuracy;
            Speed = speed;
        }
        public IAction GetCopy()
        {
            MouseDragDrop copy = new MouseDragDrop(FirstFullScreen, SecondFullScreen, FirstArea, SecondArea, IsFirstPoint, IsSecondPoint, FirstPoint, SecondPoint, FirstImage, SecondImage, FirstAccuracy, SecondAccuracy, Speed);
            return copy;
        }
        public bool Start()
        {
            if (Warrior.Active)
            {
                if (FirstFullScreen)
                {
                    if (IsFirstPoint)
                    {
                        Mouse.Move(Warrior.CurrentScript.ScreenPoints.First(x => x.Name == FirstPoint).Point, MouseSpeed.Fast);
                        if (Warrior.ChangeState)
                            return false;
                        if (IsSecondPoint)
                        {
                            Mouse.Hold(MouseKeys.Left);
                            Mouse.Move(Warrior.CurrentScript.ScreenPoints.First(x => x.Name == SecondPoint).Point, Speed);
                            Mouse.Release(MouseKeys.Left);
                            return true;
                        }
                        else
                        {
                            Point? point = Screen.FindClosest(SecondImage, Mouse.Position(), SecondAccuracy);
                            if (Warrior.ChangeState)
                                return false;
                            if (point != null)
                            {
                                Mouse.Hold(MouseKeys.Left);
                                Mouse.Move(point.Value, Speed);
                                Mouse.Release(MouseKeys.Left);
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
                        Point? point = Screen.FindFirst(FirstImage, FirstAccuracy);
                        if (point != null)
                        {
                            Mouse.Move(point.Value, MouseSpeed.Fast);
                            if (Warrior.ChangeState)
                                return false;
                            if (IsSecondPoint)
                            {
                                Mouse.Hold(MouseKeys.Left);
                                Mouse.Move(Warrior.CurrentScript.ScreenPoints.First(x => x.Name == SecondPoint).Point, Speed);
                                Mouse.Release(MouseKeys.Left);
                                return true;
                            }
                            else
                            {
                                Point? secondPoint = Screen.FindClosest(SecondImage, Mouse.Position(), SecondAccuracy);
                                if (Warrior.ChangeState)
                                    return false;
                                if (secondPoint != null)
                                {
                                    Mouse.Hold(MouseKeys.Left);
                                    Mouse.Move(secondPoint.Value, Speed);
                                    Mouse.Release(MouseKeys.Left);
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
                            return false;
                        }
                    }
                }
                else
                {
                    if (IsFirstPoint)
                    {
                        Mouse.Move(Warrior.CurrentScript.ScreenPoints.First(x => x.Name == FirstPoint).Point, MouseSpeed.Fast);
                        if (Warrior.ChangeState)
                            return false;
                        if (IsSecondPoint)
                        {
                            Mouse.Hold(MouseKeys.Left);
                            Mouse.Move(Warrior.CurrentScript.ScreenPoints.First(x => x.Name == SecondPoint).Point, Speed);
                            Mouse.Release(MouseKeys.Left);
                            return true;
                        }
                        else
                        {
                            ScreenArea area = Warrior.CurrentScript.ScreenAreas.First(x => x.Name == SecondArea);
                            Point? point = Screen.FindClosest(SecondImage, Mouse.Position(), SecondAccuracy, area.LeftTop, area.RightBottom);
                            if (Warrior.ChangeState)
                                return false;
                            if (point != null)
                            {
                                Mouse.Hold(MouseKeys.Left);
                                Mouse.Move(point.Value, Speed);
                                Mouse.Release(MouseKeys.Left);
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
                        ScreenArea area = Warrior.CurrentScript.ScreenAreas.First(x => x.Name == FirstArea);
                        Point? point = Screen.FindFirst(FirstImage, FirstAccuracy, area.LeftTop, area.RightBottom);
                        if (point != null)
                        {
                            Mouse.Move(point.Value, MouseSpeed.Fast);
                            if (Warrior.ChangeState)
                                return false;
                            if (IsSecondPoint)
                            {
                                Mouse.Hold(MouseKeys.Left);
                                Mouse.Move(Warrior.CurrentScript.ScreenPoints.First(x => x.Name == SecondPoint).Point, Speed);
                                Mouse.Release(MouseKeys.Left);
                                return true;
                            }
                            else
                            {
                                ScreenArea secondArea = Warrior.CurrentScript.ScreenAreas.First(x => x.Name == SecondArea);
                                Point? secondPoint = Screen.FindClosest(SecondImage, Mouse.Position(), SecondAccuracy, secondArea.LeftTop, secondArea.RightBottom);
                                if (Warrior.ChangeState)
                                    return false;
                                if (secondPoint != null)
                                {
                                    Mouse.Hold(MouseKeys.Left);
                                    Mouse.Move(secondPoint.Value, Speed);
                                    Mouse.Release(MouseKeys.Left);
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
                            return false;
                        }
                    }
                }
            }
            return false;
        }
    }
}
