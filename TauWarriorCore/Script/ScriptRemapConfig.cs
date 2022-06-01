using System;
using System.Collections.Generic;
using TauWarriorCore.Input;

namespace TauWarriorCore.Script
{
    [Serializable]
    public class ScriptRemapConfig
    {
        public bool DirectInput { get; }
        public GamePadIndex GamepadIndex { get; }
        public GamePadType GamepadType { get; }
        public List<GamepadRemap> GamepadKeys { get; }
        public List<JoystickRemap> JoystickKeys { get; }
        public ScriptRemapConfig(GamePadType gamepadType, GamePadIndex gamepadIndex, List<GamepadRemap> remaps, bool directInput)
        {
            GamepadType = gamepadType;
            GamepadIndex = gamepadIndex;
            GamepadKeys = remaps;
            DirectInput = directInput;
        }
        public ScriptRemapConfig(GamePadType gamepadType, GamePadIndex gamepadIndex, List<JoystickRemap> remaps, bool directInput)
        {
            GamepadType = gamepadType;
            GamepadIndex = gamepadIndex;
            JoystickKeys = remaps;
            DirectInput = directInput;
        }
        [Serializable]
        public struct GamepadRemap
        {
            public GamePadKeys GamepadKey { get; }
            public KeyboardKeys KeyboardKey { get; }
            public GamepadRemap(GamePadKeys gamepadKey, KeyboardKeys keyboardKey)
            {
                GamepadKey = gamepadKey;
                KeyboardKey = keyboardKey;
            }
        }
        [Serializable]
        public struct JoystickRemap
        {
            public JoyStickKeys JoystickKey { get; }
            public KeyboardKeys KeyboardKey { get; }
            public JoystickRemap(JoyStickKeys joystickKey, KeyboardKeys keyboardKey)
            {
                JoystickKey = joystickKey;
                KeyboardKey = keyboardKey;
            }
        }
    }
}
