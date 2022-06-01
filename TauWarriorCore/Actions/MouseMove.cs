using System;
using System.Linq;
using TauWarriorCore.Input;

namespace TauWarriorCore.Actions
{
    [Serializable]
    public class MouseMove : IAction
    {
        public string Name => "Mouse Move";
        public ActionType ActionType => ActionType.MouseMove;
        public string Point { get; }
        public MouseSpeed Speed { get; }
        public string Info
        {
            get
            {
                return $"Move to \"{Point}\" {Speed}";
            }
        }
        public MouseMove(string point, MouseSpeed mouseSpeed)
        {
            Point = point;
            Speed = mouseSpeed;
        }
        public IAction GetCopy()
        {
            MouseMove copy = new MouseMove(Point, Speed);
            return copy;
        }

        public bool Start()
        {
            if (Warrior.Active)
            {
                Mouse.Move(Warrior.CurrentScript.ScreenPoints.First(x => x.Name == Point).Point, Speed);
                return true;
            }
            return false;
        }
    }
}
