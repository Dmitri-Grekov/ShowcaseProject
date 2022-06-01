using System;
using System.Collections.Generic;

namespace TauWarriorCore.Actions
{
    [Serializable]
    public class IfElse : IAction
    {
        public string Name => "If Else";
        public ActionType ActionType => ActionType.IfElse;
        public List<IAction> Conditions { get; }
        public List<IAction> IfActions { get; }
        public List<IAction> ElseActions { get; }
        public bool AllTrue { get; }
        public bool NotTrue { get; }
        public string Info
        {
            get
            {
                return $"If ({Conditions.Count} Conditions) do {IfActions.Count} actions else {ElseActions.Count} actions";
            }
        }
        public IfElse(List<IAction> conditions, List<IAction> ifActions, List<IAction> elseActions, bool allTrue, bool notTrue)
        {
            Conditions = conditions;
            IfActions = ifActions;
            ElseActions = elseActions;
            AllTrue = allTrue;
            NotTrue = notTrue;
        }
        public IAction GetCopy()
        {
            IfElse copy = new IfElse(Conditions, IfActions, ElseActions, AllTrue, NotTrue);
            return copy;
        }
        public bool Start()
        {
            if (Warrior.Active)
            {
                bool result = true;
                if (AllTrue)
                {
                    if (!NotTrue)
                    {
                        foreach (IAction condition in Conditions)
                        {
                            if (!condition.Start())
                            {
                                result = false;
                                break;
                            }
                            if (Warrior.ChangeState)
                                return false;
                        }
                    }
                    else
                    {
                        foreach (IAction condition in Conditions)
                        {
                            if (condition.Start())
                            {
                                result = false;
                                break;
                            }
                            if (Warrior.ChangeState)
                                return false;
                        }
                    }
                }
                else
                {
                    result = false;
                    if (!NotTrue)
                    {
                        foreach (IAction condition in Conditions)
                        {
                            if (condition.Start())
                            {
                                result = true;
                                break;
                            }
                            if (Warrior.ChangeState)
                                return false;
                        }
                    }
                    else
                    {
                        foreach (IAction condition in Conditions)
                        {
                            if (!condition.Start())
                            {
                                result = true;
                                break;
                            }
                            if (Warrior.ChangeState)
                                return false;
                        }
                    }
                }
                if (result)
                {
                    foreach (IAction action in IfActions)
                    {
                        action.Start();
                        if (Warrior.ChangeState)
                            return false;
                    }
                }
                else
                {
                    foreach (IAction action in ElseActions)
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
