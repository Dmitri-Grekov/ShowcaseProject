using System;
using TauWarriorCore.Input;

namespace TauWarriorCore.Actions
{
    [Serializable]
    public class KeyboardText : IAction
    {
        public string Name => "Keyboard Text";
        public ActionType ActionType => ActionType.KeyboardText;
        public string Text { get; }
        public bool DirectInput { get; }
        public string Info
        {
            get
            {
                return $"Text {Text.Length} symbols";
            }
        }
        public KeyboardText(string text, bool directInput)
        {
            Text = text;
            DirectInput = directInput;
        }
        public IAction GetCopy()
        {
            KeyboardText copy = new KeyboardText(Text, DirectInput);
            return copy;
        }
        public bool Start()
        {
            if (Warrior.Active)
            {
                if (DirectInput)
                    Keyboard.PressStringDirectInput(Text);
                else
                    Keyboard.PressString(Text);
                return true;
            }
            return false;
        }
    }
}
