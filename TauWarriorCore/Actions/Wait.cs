using System;
using System.Threading;

namespace TauWarriorCore.Actions
{
    [Serializable]
    public class Wait : IAction
    {
        public string Name => "Wait";
        public ActionType ActionType => ActionType.Wait;
        public int Milliseconds { get; }
        public string Info
        {
            get
            {
                return $"Wait {Milliseconds} ms";
            }
        }
        public Wait(int milliseconds)
        {
            Milliseconds = milliseconds;
        }
        public IAction GetCopy()
        {
            Wait copy = new Wait(Milliseconds);
            return copy;
        }
        public bool Start()
        {
            if (Warrior.Active)
            {
                WaitMS(Milliseconds);
                if (Warrior.ChangeState)
                    return false;
                return true;
            }
            return false;
        }
        private void WaitMS(int ms)
        {
            while (ms > 0)
            {
                if (ms > 10)
                {
                    Thread.Sleep(10);
                    ms -= 10;
                    if (Warrior.ChangeState)
                        return;
                }
                else
                {
                    Thread.Sleep(ms);
                    ms = 0;
                }
            }
        }
    }
}
