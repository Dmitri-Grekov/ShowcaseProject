using System;
using System.Collections.Generic;

namespace TauWarriorCore.Actions
{
    [Serializable]
    public class OneFromAllCondition : IAction
    {
        public string Name => "One From All Condition";
        public ActionType ActionType => ActionType.OneFromAllCondition;
        public List<IAction> Conditions { get; }
        public bool NotTrue { get; }
        public string Info
        {
            get
            {
                return $"One from {Conditions.Count} conditions";
            }
        }
        public OneFromAllCondition(List<IAction> conditions, bool notTrue)
        {
            Conditions = conditions;
            NotTrue = notTrue;
        }
        public IAction GetCopy()
        {
            OneFromAllCondition copy = new OneFromAllCondition(Conditions, NotTrue);
            return copy;
        }
        public bool Start()
        {
            if (Warrior.Active)
            {
                if (!NotTrue)
                {
                    foreach (IAction action in Conditions)
                    {
                        if (action.Start())
                        {
                            return true;
                        }
                        if (Warrior.ChangeState)
                            return false;
                    }
                }
                else
                {
                    foreach (IAction action in Conditions)
                    {
                        if (!action.Start())
                        {
                            return true;
                        }
                        if (Warrior.ChangeState)
                            return false;
                    }
                }
            }
            return false;
        }
    }
}