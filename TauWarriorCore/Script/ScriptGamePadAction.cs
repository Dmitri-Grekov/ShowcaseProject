using System;
using TauWarriorCore.Input;

namespace TauWarriorCore.Script
{
    [Serializable]
    public class ScriptGamePadAction
    {
        public string Name { get; }
        public string NextState { get; set; }
        public GamePadType GamepadType { get; }
        public GamePadKeys GamepadKey { get; }
        public GamePadIndex GamepadIndex { get; }
        public JoyStickKeys JoystickKey { get; }
        public long HoldTime { get; }
        public string KeyText
        {
            get
            {
                return $"{(GamepadType == GamePadType.JoyStick ? $"{JoystickKey}" : $"{GamepadKey}")}";
            }
        }
        public ScriptGamePadAction(string name, string nextState, GamePadIndex index, GamePadKeys key, long holdTime = 0)
        {
            Name = name;
            NextState = nextState;
            GamepadIndex = index;
            GamepadKey = key;
            JoystickKey = JoyStickKeys.NONE;
            HoldTime = holdTime;
            GamepadType = GamePadType.GamePad;
        }
        public ScriptGamePadAction(string name, string nextState, GamePadIndex index, JoyStickKeys key, long holdTime = 0)
        {
            Name = name;
            NextState = nextState;
            GamepadIndex = index;
            GamepadKey = GamePadKeys.NONE;
            JoystickKey = key;
            HoldTime = holdTime;
            GamepadType = GamePadType.JoyStick;
        }
    }

}