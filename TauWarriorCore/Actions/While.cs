using System;
using System.Collections.Generic;

namespace TauWarriorCore.Actions
{
    [Serializable]
    public class While : IAction
    {
        public string Name => "While";
        public ActionType ActionType => ActionType.While;
        public List<IAction> Conditions { get; }
        public List<IAction> Actions { get; }
        public bool AllTrue { get; }
        public bool NotTrue { get; }
        public int Count { get; }
        public string Info
        {
            get
            {
                return $"While ({(AllTrue ? "All " : "One from ")}{Conditions.Count} Conditions = {(NotTrue ? "False" : "True")}) do {Actions.Count} actions";
            }
        }
        public While(List<IAction> conditions, List<IAction> actions, bool allTrue, bool notTrue, int count)
        {
            Conditions = conditions;
            Actions = actions;
            AllTrue = allTrue;
            NotTrue = notTrue;
            Count = count;
        }
        public IAction GetCopy()
        {
            While copy = new While(Conditions, Actions, AllTrue, NotTrue, Count);
            return copy;
        }
        public bool Start()
        {
            if (Warrior.Active)
            {
                if (Count == 0)
                {
                    while (true)
                    {
                        if (AllTrue)
                        {
                            if (!NotTrue)
                            {
                                foreach (IAction condition in Conditions)
                                {
                                    if (!condition.Start())
                                    {
                                        return true;
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
                                        return true;
                                    }
                                    if (Warrior.ChangeState)
                                        return false;
                                }
                            }
                        }
                        else
                        {
                            bool result = false;
                            if (!NotTrue)
                            {
                                foreach (IAction condition in Conditions)
                                {
                                    if (condition.Start())
                                    {
                                        result = true;
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
                                    }
                                    if (Warrior.ChangeState)
                                        return false;
                                }
                            }
                            if (!result)
                                return true;
                        }
                        foreach (IAction action in Actions)
                        {
                            action.Start();
                            if (Warrior.ChangeState)
                                return false;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < Count; i++)
                    {
                        if (AllTrue)
                        {
                            if (!NotTrue)
                            {
                                foreach (IAction condition in Conditions)
                                {
                                    if (!condition.Start())
                                    {
                                        return true;
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
                                        return true;
                                    }
                                    if (Warrior.ChangeState)
                                        return false;
                                }
                            }
                        }
                        else
                        {
                            bool result = false;
                            if (!NotTrue)
                            {
                                foreach (IAction condition in Conditions)
                                {
                                    if (condition.Start())
                                    {
                                        result = true;
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
                                    }
                                    if (Warrior.ChangeState)
                                        return false;
                                }
                            }
                            if (!result)
                                return true;
                        }
                        foreach (IAction action in Actions)
                        {
                            action.Start();
                            if (Warrior.ChangeState)
                                return false;
                        }
                    }
                }
                return true;
            }
            return false;
        }
    }
}
