using System;

namespace TauWarriorCore.Actions
{
    [Serializable]
    public class ChangeState : IAction
    {
        public string Name => "Change State";
        public ActionType ActionType => ActionType.ChangeState;
        public string NextState { get; }
        public string Info
        {
            get
            {
                return $"Change State to \"{NextState}\"";
            }
        }
        public ChangeState(string nextState)
        {
            NextState = nextState;
        }
        public IAction GetCopy()
        {
            ChangeState copy = new ChangeState(NextState);
            return copy;
        }
        public bool Start()
        {
            if (Warrior.Active)
            {
                Warrior.ChangeState = true;
                Warrior.CurrentState = NextState;
                return true;
            }
            return false;
        }
    }
}
