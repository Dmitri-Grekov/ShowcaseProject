using System.Collections.Generic;

namespace TauWarriorCore.Actions
{
    public interface IAction
    {
        public string Name { get; }
        public ActionType ActionType { get; }
        public string Info { get; }
        public bool Start();
        public IAction GetCopy();
    }
    public enum ActionType
    {
        Beep, ChangeState, IfElse, KeyboardPress, KeyboardText, MouseClick, MouseDragDrop, MouseMove, OneFromAllCondition, OpenProcess, Pack, Repeat, ScreenExists, ScreenFindClick, ScreenFindMove, ScreenShot, Wait, While
    }
}
