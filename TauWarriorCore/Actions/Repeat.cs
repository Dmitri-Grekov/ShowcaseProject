using System;
using System.Collections.Generic;

namespace TauWarriorCore.Actions
{
    [Serializable]
    public class Repeat : IAction
    {
        public string Name => "Repeat";
        public ActionType ActionType => ActionType.Repeat;
        public List<IAction> Actions { get; }
        public int Count { get; }
        public string Info
        {
            get
            {
                return $"Repeat {Count} times {Actions.Count} actions";
            }
        }
        public Repeat(List<IAction> actions, int count)
        {
            Actions = actions;
            Count = count;
        }
        public IAction GetCopy()
        {
            Repeat copy = new Repeat(Actions, Count);
            return copy;
        }
        public bool Start()
        {
            if (Warrior.Active)
            {
                for (int i = 0; i < Count; i++)
                {
                    foreach (IAction action in Actions)
                    {
                        action.Start();
                        if (Warrior.ChangeState)
                            return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}
