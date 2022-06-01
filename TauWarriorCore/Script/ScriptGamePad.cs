using System;
using System.Diagnostics;
using TauWarriorCore.Input;

namespace TauWarriorCore.Script
{
    [Serializable]
    public class ScriptGamePad
    {
        private readonly Stopwatch stopwatch = new Stopwatch();
        private bool pressed = false;
        public ScriptGamePadAction GamePadAction { get; }
        public ScriptGamePad(ScriptGamePadAction gamePadAction)
        {
            GamePadAction = gamePadAction;
        }
        public bool Check()
        {
            if (GamePadAction.HoldTime == 0)
            {
                if (!pressed)
                {
                    if (GamePadAction.GamepadType == GamePadType.GamePad)
                    {
                        if (GamePad.IsPressed(GamePadAction.GamepadKey, GamePadAction.GamepadIndex))
                        {
                            pressed = true;
                            return true;
                        }
                    }
                    else
                    {
                        if (JoyStick.IsPressed(GamePadAction.JoystickKey, GamePadAction.GamepadIndex))
                        {
                            pressed = true;
                            return true;
                        }
                    }
                }
                else
                {
                    if (GamePadAction.GamepadType == GamePadType.GamePad)
                    {
                        if (!GamePad.IsPressed(GamePadAction.GamepadKey, GamePadAction.GamepadIndex))
                        {
                            pressed = false;
                        }
                    }
                    else
                    {
                        if (!JoyStick.IsPressed(GamePadAction.JoystickKey, GamePadAction.GamepadIndex))
                        {
                            pressed = false;
                        }
                    }
                }
            }
            else
            {
                if (!pressed)
                {
                    if (GamePadAction.GamepadType == GamePadType.GamePad)
                    {
                        if (GamePad.IsPressed(GamePadAction.GamepadKey, GamePadAction.GamepadIndex))
                        {
                            pressed = true;
                            stopwatch.Restart();
                        }
                    }
                    else
                    {
                        if (JoyStick.IsPressed(GamePadAction.JoystickKey, GamePadAction.GamepadIndex))
                        {
                            pressed = true;
                            stopwatch.Restart();
                        }
                    }
                }
                else
                {
                    if (GamePadAction.GamepadType == GamePadType.GamePad)
                    {
                        if (!GamePad.IsPressed(GamePadAction.GamepadKey, GamePadAction.GamepadIndex))
                        {
                            pressed = false;
                            stopwatch.Stop();
                            if (stopwatch.ElapsedMilliseconds >= GamePadAction.HoldTime)
                                return true;
                            else
                                return false;
                        }
                    }
                    else
                    {
                        if (!JoyStick.IsPressed(GamePadAction.JoystickKey, GamePadAction.GamepadIndex))
                        {
                            pressed = false;
                            stopwatch.Stop();
                            if (stopwatch.ElapsedMilliseconds >= GamePadAction.HoldTime)
                                return true;
                            else
                                return false;
                        }
                    }
                }
            }
            return false;
        }
    }
}