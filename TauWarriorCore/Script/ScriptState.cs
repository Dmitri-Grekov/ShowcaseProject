using System;
using System.Collections.Generic;
using TauWarriorCore.Actions;

namespace TauWarriorCore.Script
{
    [Serializable]
    public class ScriptState
    {
        public string Name { get; }
        public string NextState { get; set; }
        public List<IAction> Actions { get; }
        public ScriptState(string name, string nextstate, List<IAction> actions)
        {
            Name = name;
            NextState = nextstate;
            Actions = actions;
        }
    }
}