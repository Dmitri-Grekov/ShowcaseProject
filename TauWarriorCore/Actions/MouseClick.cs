using System;
using System.Linq;
using System.Threading;
using TauWarriorCore.Input;

namespace TauWarriorCore.Actions
{
    [Serializable]
    public class MouseClick : IAction
    {
        public string Name => "Mouse Click";
        public ActionType ActionType => ActionType.MouseClick;
        public bool UsePoint { get; }
        public string Point { get; }
        public MouseSpeed Speed { get; }
        public MouseKeys Key { get; }
        public int HoldTime { get; }
        public int Count { get; }
        public string Info
        {
            get
            {
                return $"Click ({Key}) {Count} times{(UsePoint ? $" in \"{Point}\"" : "")}";
            }
        }
        public MouseClick(bool usePoint, string point, MouseSpeed mouseSpeed, MouseKeys key, int holdTime, int count)
        {
            UsePoint = usePoint;
            Point = point;
            Speed = mouseSpeed;
            Key = key;
            HoldTime = holdTime;
            Count = count;
        }
        public IAction GetCopy()
        {
            MouseClick copy = new MouseClick(UsePoint, Point, Speed, Key, HoldTime, Count);
            return copy;
        }
        public bool Start()
        {
            if (Warrior.Active)
            {
                if (UsePoint)
                {
                    Mouse.Move(Warrior.CurrentScript.ScreenPoints.First(x => x.Name == Point).Point, Speed);
                    if (Warrior.ChangeState)
                        return false;
                }
                if (HoldTime == 0)
                {
                    for (int i = 0; i < Count; i++)
                    {
                        Mouse.Click(Key);
                        if (Warrior.ChangeState)
                            return false;
                    }
                }
                else
                {
                    for (int i = 0; i < Count; i++)
                    {
                        Mouse.Hold(Key);
                        Wait(HoldTime);
                        if (Warrior.ChangeState)
                        {
                            Mouse.Release(Key);
                            return false;
                        }
                        Mouse.Release(Key);
                    }
                }
                return true;
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
