using System;
using System.Diagnostics;
using TauWarriorCore.Input;

namespace TauWarriorCore.Script
{
    [Serializable]
    public class ScriptMouse
    {
        private readonly Stopwatch stopwatch = new Stopwatch();
        private bool pressed = false;
        public ScriptMouseAction MouseAction { get; }
        public ScriptMouse(ScriptMouseAction mouseAction)
        {
            MouseAction = mouseAction;
        }
        public bool Check()
        {
            if (MouseAction.HoldTime == 0)
            {
                if (!pressed)
                {
                    if (Mouse.IsPressed(MouseAction.Key))
                    {
                        pressed = true;
                        return true;
                    }
                }
                else
                {
                    if (!Mouse.IsPressed(MouseAction.Key))
                    {
                        pressed = false;
                    }
                }
            }
            else
            {
                if (!pressed)
                {
                    if (Mouse.IsPressed(MouseAction.Key))
                    {
                        pressed = true;
                        stopwatch.Restart();
                    }
                }
                else
                {
                    if (!Mouse.IsPressed(MouseAction.Key))
                    {
                        pressed = false;
                        stopwatch.Stop();
                        if (stopwatch.ElapsedMilliseconds >= MouseAction.HoldTime)
                            return true;
                        else
                            return false;
                    }
                }
            }
            return false;
        }
    }
}