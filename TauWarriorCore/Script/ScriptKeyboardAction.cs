using System;
using TauWarriorCore.Input;

namespace TauWarriorCore.Script
{
    [Serializable]
    public class ScriptKeyboardAction
    {
        public string Name { get; }
        public string NextState { get; set; }
        public KeyboardKeys Key { get; }
        public KeyboardKeys ModifierKey { get; }
        public KeyboardKeys SecondModifierKey { get; }
        public long HoldTime { get; }
        public string KeyText
        {
            get
            {
                if (SecondModifierKey != KeyboardKeys.NONE)
                    return $"{SecondModifierKey}+{ModifierKey}+{Key}";
                else if (ModifierKey != KeyboardKeys.NONE)
                    return $"{ModifierKey}+{Key}";
                else
                    return $"{Key}";
            }
        }
        public ScriptKeyboardAction(string name, string nextState, KeyboardKeys key, KeyboardKeys modifierKey, KeyboardKeys secondModifierKey, long holdTime = 0)
        {
            Name = name;
            NextState = nextState;
            Key = key;
            ModifierKey = modifierKey;
            SecondModifierKey = secondModifierKey;
            HoldTime = holdTime;
        }
    }
}