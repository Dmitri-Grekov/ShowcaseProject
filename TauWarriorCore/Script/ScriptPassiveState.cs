using System;
using TauWarriorCore.Actions;

namespace TauWarriorCore.Script
{
    [Serializable]
    public class ScriptPassiveState
    {
        private TimeSpan CurrentTime = TimeSpan.Zero;
        public string Name { get; }
        public string NextState { get; set; }
        public IAction Action { get; set; }
        public TimeSpan Time { get; }
        public ScriptPassiveState(string name, string nextState, IAction action, TimeSpan time)
        {
            Name = name;
            NextState = nextState;
            Action = action;
            Time = time;
        }
        public bool Check(TimeSpan time)
        {
            CurrentTime += time;
            if (CurrentTime >= Time)
            {
                CurrentTime = TimeSpan.Zero;
                return Action.Start();
            }
            return false;
        }
    }
}