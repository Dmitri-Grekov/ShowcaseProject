using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TauWarriorCore.Actions
{
    [Serializable]
    public class Beep : IAction
    {
        public string Name => "Beep";
        public ActionType ActionType => ActionType.Beep;
        public int Count { get; }
        public string Info
        {
            get
            {
                return $"Beep {Count} times";
            }
        }
        public Beep(int count)
        {
            Count = count;
        }
        public IAction GetCopy()
        {
            Beep copy = new Beep(Count);
            return copy;
        }
        public bool Start()
        {
            if (Warrior.Active)
            {
                for (int i = 0; i < Count; i++)
                {
                    Console.Beep();
                    if (Warrior.ChangeState)
                        return false;
                }
                return true;
            }
            return false;
        }
    }
}