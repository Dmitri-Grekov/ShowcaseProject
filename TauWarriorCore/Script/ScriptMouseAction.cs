using System;
using TauWarriorCore.Input;

namespace TauWarriorCore.Script
{
    [Serializable]
    public class ScriptMouseAction
    {
        public string Name { get; }
        public string NextState { get; set; }
        public MouseKeys Key { get; }
        public long HoldTime { get; }
        public ScriptMouseAction(string name, string nextState, MouseKeys key, long holdTime = 0)
        {
            Name = name;
            NextState = nextState;
            Key = key;
            HoldTime = holdTime;
        }
    }
}