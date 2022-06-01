using System;
using System.Diagnostics;
using TauWarriorCore.Input;

namespace TauWarriorCore.Script
{
    [Serializable]
    public class ScriptKeyboard
    {
        private readonly Stopwatch stopwatch = new Stopwatch();
        private bool pressed = false;
        public ScriptKeyboardAction KeyboardAction { get; }
        public ScriptKeyboard(ScriptKeyboardAction keyboardAction)
        {
            KeyboardAction = keyboardAction;
        }
        public bool Check()
        {
            if (KeyboardAction.ModifierKey == KeyboardKeys.NONE)
            {
                if (KeyboardAction.HoldTime == 0)
                {
                    if (!pressed)
                    {
                        if (Keyboard.IsPressed(KeyboardAction.Key))
                        {
                            pressed = true;
                            return true;
                        }
                    }
                    else
                    {
                        if (!Keyboard.IsPressed(KeyboardAction.Key))
                        {
                            pressed = false;
                        }
                    }
                }
                else
                {
                    if (!pressed)
                    {
                        if (Keyboard.IsPressed(KeyboardAction.Key))
                        {
                            pressed = true;
                            stopwatch.Restart();
                        }
                    }
                    else
                    {
                        if (!Keyboard.IsPressed(KeyboardAction.Key))
                        {
                            pressed = false;
                            stopwatch.Stop();
                            if (stopwatch.ElapsedMilliseconds >= KeyboardAction.HoldTime)
                                return true;
                            else
                                return false;
                        }
                    }
                }
            }
            else if (KeyboardAction.SecondModifierKey == KeyboardKeys.NONE)
            {
                if (KeyboardAction.HoldTime == 0)
                {
                    if (!pressed)
                    {
                        if (Keyboard.IsPressed(KeyboardAction.Key) && Keyboard.IsPressed(KeyboardAction.ModifierKey))
                        {
                            pressed = true;
                            return true;
                        }
                    }
                    else
                    {
                        if (!Keyboard.IsPressed(KeyboardAction.Key) && !Keyboard.IsPressed(KeyboardAction.ModifierKey))
                        {
                            pressed = false;
                        }
                    }
                }
                else
                {
                    if (!pressed)
                    {
                        if (Keyboard.IsPressed(KeyboardAction.Key) && Keyboard.IsPressed(KeyboardAction.ModifierKey))
                        {
                            pressed = true;
                            stopwatch.Restart();
                        }
                    }
                    else
                    {
                        if (!Keyboard.IsPressed(KeyboardAction.Key) && !Keyboard.IsPressed(KeyboardAction.ModifierKey))
                        {
                            pressed = false;
                            stopwatch.Stop();
                            if (stopwatch.ElapsedMilliseconds >= KeyboardAction.HoldTime)
                                return true;
                            else
                                return false;
                        }
                    }
                }
            }
            else
            {
                if (KeyboardAction.HoldTime == 0)
                {
                    if (!pressed)
                    {
                        if (Keyboard.IsPressed(KeyboardAction.Key) && Keyboard.IsPressed(KeyboardAction.ModifierKey) && Keyboard.IsPressed(KeyboardAction.SecondModifierKey))
                        {
                            pressed = true;
                            return true;
                        }
                    }
                    else
                    {
                        if (!Keyboard.IsPressed(KeyboardAction.Key) && !Keyboard.IsPressed(KeyboardAction.ModifierKey) && !Keyboard.IsPressed(KeyboardAction.SecondModifierKey))
                        {
                            pressed = false;
                        }
                    }
                }
                else
                {
                    if (!pressed)
                    {
                        if (Keyboard.IsPressed(KeyboardAction.Key) && Keyboard.IsPressed(KeyboardAction.ModifierKey) && Keyboard.IsPressed(KeyboardAction.SecondModifierKey))
                        {
                            pressed = true;
                            stopwatch.Restart();
                        }
                    }
                    else
                    {
                        if (!Keyboard.IsPressed(KeyboardAction.Key) && !Keyboard.IsPressed(KeyboardAction.ModifierKey) && !Keyboard.IsPressed(KeyboardAction.SecondModifierKey))
                        {
                            pressed = false;
                            stopwatch.Stop();
                            if (stopwatch.ElapsedMilliseconds >= KeyboardAction.HoldTime)
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