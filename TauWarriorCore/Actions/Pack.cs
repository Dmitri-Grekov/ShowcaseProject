using System;
using System.Collections.Generic;

namespace TauWarriorCore.Actions
{
    [Serializable]
    public class Pack : IAction
    {
        public string Name => "Pack";
        public ActionType ActionType => ActionType.Pack;
        public List<IAction> Actions { get; }
        public string Info
        {
            get
            {
                return $"Pack {Actions.Count} actions";
            }
        }
        public Pack(List<IAction> actions)
        {
            Actions = actions;
        }
        public IAction GetCopy()
        {
            Pack copy = new Pack(Actions);
            return copy;
        }
        public bool Start()
        {
            if (Warrior.Active)
            {
                bool result = true;
                foreach (IAction action in Actions)
                {
                    if (!action.Start())
                        result = false;
                    if (Warrior.ChangeState)
                        return false;
                }
                return result;
            }
            return false;
        }
    }
}