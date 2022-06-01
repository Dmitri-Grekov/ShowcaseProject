using System;
using System.Threading;
using TauWarriorCore.Input;

namespace TauWarriorCore.Actions
{
    [Serializable]
    public class KeyboardPress : IAction
    {
        public string Name => "Keyboard Press";
        public ActionType ActionType => ActionType.KeyboardPress;
        public KeyboardKeys Key { get; }
        public KeyboardKeys SecondKey { get; }
        public KeyboardKeys ThirdKey { get; }
        public int HoldTime { get; }
        public int Count { get; }
        public bool DirectInput { get; }
        public string Info
        {
            get
            {
                if (ThirdKey == KeyboardKeys.NONE)
                {
                    if (SecondKey == KeyboardKeys.NONE)
                    {
                        return $"Press ({Key}) {Count} times" + (DirectInput ? " (DirectInput)" : "");
                    }
                    else
                    {
                        return $"Press ({SecondKey}+{Key}) {Count} times" + (DirectInput ? " (DirectInput)" : "");
                    }
                }
                else
                {
                    return $"Press ({ThirdKey}+{SecondKey}+{Key}) {Count} times" + (DirectInput ? " (DirectInput)" : "");
                }
            }
        }
        public KeyboardPress(KeyboardKeys key, KeyboardKeys secondKey, KeyboardKeys thirdKey, int holdTime, int count, bool directInput)
        {
            Key = key;
            SecondKey = secondKey;
            ThirdKey = thirdKey;
            HoldTime = holdTime;
            Count = count;
            DirectInput = directInput;
        }
        public IAction GetCopy()
        {
            KeyboardPress copy = new KeyboardPress(Key, SecondKey, ThirdKey, HoldTime, Count, DirectInput);
            return copy;
        }        
        public bool Start()
        {
            if (Warrior.Active)
            {
                if (HoldTime == 0)
                {
                    if (ThirdKey == KeyboardKeys.NONE)
                    {
                        if (SecondKey == KeyboardKeys.NONE)
                        {
                            if (DirectInput)
                            {
                                for (int i = 0; i < Count; i++)
                                {
                                    Keyboard.PressDirectInput(Key);
                                    if (Warrior.ChangeState)
                                    {
                                        return false;
                                    }
                                }
                            }
                            else
                            {
                                for (int i = 0; i < Count; i++)
                                {
                                    Keyboard.Press(Key);
                                    if (Warrior.ChangeState)
                                    {
                                        return false;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (DirectInput)
                            {
                                for (int i = 0; i < Count; i++)
                                {
                                    Keyboard.PressWithModifierDirectInput(SecondKey, Key);
                                    if (Warrior.ChangeState)
                                    {
                                        return false;
                                    }
                                }
                            }
                            else
                            {
                                for (int i = 0; i < Count; i++)
                                {
                                    Keyboard.PressWithModifier(SecondKey, Key);
                                    if (Warrior.ChangeState)
                                    {
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (DirectInput)
                        {
                            for (int i = 0; i < Count; i++)
                            {
                                Keyboard.PressWithModifierDirectInput(ThirdKey, SecondKey, Key);
                                if (Warrior.ChangeState)
                                {
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < Count; i++)
                            {
                                Keyboard.PressWithModifier(ThirdKey, SecondKey, Key);
                                if (Warrior.ChangeState)
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < Count; i++)
                    {
                        Press(HoldTime);
                        if (Warrior.ChangeState)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            return false;
        }
        private void Press(int ms)
        {
            if (DirectInput)
            {
                if (ms > 300)
                {
                    if (ThirdKey == KeyboardKeys.NONE)
                    {
                        if (SecondKey == KeyboardKeys.NONE)
                        {
                            Keyboard.HoldDirectInput(Key);
                        }
                        else
                        {
                            Keyboard.HoldDirectInput(SecondKey);
                            Keyboard.HoldDirectInput(Key);
                        }
                    }
                    else
                    {
                        Keyboard.HoldDirectInput(ThirdKey);
                        Keyboard.HoldDirectInput(SecondKey);
                        Keyboard.HoldDirectInput(Key);
                    }
                    for (int i = 0; i < ms / 300; i++)
                    {
                        Thread.Sleep(300);
                        if (Warrior.ChangeState)
                        {
                            if (ThirdKey == KeyboardKeys.NONE)
                            {
                                if (SecondKey == KeyboardKeys.NONE)
                                {
                                    Keyboard.ReleaseDirectInput(Key);
                                }
                                else
                                {
                                    Keyboard.ReleaseDirectInput(Key);
                                    Keyboard.ReleaseDirectInput(SecondKey);
                                }
                            }
                            else
                            {
                                Keyboard.ReleaseDirectInput(Key);
                                Keyboard.ReleaseDirectInput(SecondKey);
                                Keyboard.ReleaseDirectInput(ThirdKey);
                            }
                            return;
                        }
                    }
                    if (ThirdKey == KeyboardKeys.NONE)
                    {
                        if (SecondKey == KeyboardKeys.NONE)
                        {
                            Keyboard.ReleaseDirectInput(Key);
                        }
                        else
                        {
                            Keyboard.ReleaseDirectInput(Key);
                            Keyboard.ReleaseDirectInput(SecondKey);
                        }
                    }
                    else
                    {
                        Keyboard.ReleaseDirectInput(Key);
                        Keyboard.ReleaseDirectInput(SecondKey);
                        Keyboard.ReleaseDirectInput(ThirdKey);
                    }
                }
                else
                {
                    if (ThirdKey == KeyboardKeys.NONE)
                    {
                        if (SecondKey == KeyboardKeys.NONE)
                        {
                            Keyboard.HoldDirectInput(Key);
                            Thread.Sleep(ms);
                            Keyboard.ReleaseDirectInput(Key);
                        }
                        else
                        {
                            Keyboard.HoldDirectInput(SecondKey);
                            Keyboard.HoldDirectInput(Key);
                            Thread.Sleep(ms);
                            Keyboard.ReleaseDirectInput(Key);
                            Keyboard.ReleaseDirectInput(SecondKey);
                        }
                    }
                    else
                    {
                        Keyboard.HoldDirectInput(ThirdKey);
                        Keyboard.HoldDirectInput(SecondKey);
                        Keyboard.HoldDirectInput(Key);
                        Thread.Sleep(ms);
                        Keyboard.ReleaseDirectInput(Key);
                        Keyboard.ReleaseDirectInput(SecondKey);
                        Keyboard.ReleaseDirectInput(ThirdKey);
                    }
                }
            }
            else
            {
                if (ms > 300)
                {
                    if (ThirdKey == KeyboardKeys.NONE)
                    {
                        if (SecondKey == KeyboardKeys.NONE)
                        {
                            Keyboard.Hold(Key);
                        }
                        else
                        {
                            Keyboard.Hold(SecondKey);
                            Keyboard.Hold(Key);
                        }
                    }
                    else
                    {
                        Keyboard.Hold(ThirdKey);
                        Keyboard.Hold(SecondKey);
                        Keyboard.Hold(Key);
                    }
                    for (int i = 0; i < ms / 300; i++)
                    {
                        Thread.Sleep(300);
                        if (Warrior.ChangeState)
                        {
                            if (ThirdKey == KeyboardKeys.NONE)
                            {
                                if (SecondKey == KeyboardKeys.NONE)
                                {
                                    Keyboard.Release(Key);
                                }
                                else
                                {
                                    Keyboard.Release(Key);
                                    Keyboard.Release(SecondKey);
                                }
                            }
                            else
                            {
                                Keyboard.Release(Key);
                                Keyboard.Release(SecondKey);
                                Keyboard.Release(ThirdKey);
                            }
                            return;
                        }
                    }
                    if (ThirdKey == KeyboardKeys.NONE)
                    {
                        if (SecondKey == KeyboardKeys.NONE)
                        {
                            Keyboard.Release(Key);
                        }
                        else
                        {
                            Keyboard.Release(Key);
                            Keyboard.Release(SecondKey);
                        }
                    }
                    else
                    {
                        Keyboard.Release(Key);
                        Keyboard.Release(SecondKey);
                        Keyboard.Release(ThirdKey);
                    }
                }
                else
                {
                    if (ThirdKey == KeyboardKeys.NONE)
                    {
                        if (SecondKey == KeyboardKeys.NONE)
                        {
                            Keyboard.Hold(Key);
                            Thread.Sleep(ms);
                            Keyboard.Release(Key);
                        }
                        else
                        {
                            Keyboard.Hold(SecondKey);
                            Keyboard.Hold(Key);
                            Thread.Sleep(ms);
                            Keyboard.Release(Key);
                            Keyboard.Release(SecondKey);
                        }
                    }
                    else
                    {
                        Keyboard.Hold(ThirdKey);
                        Keyboard.Hold(SecondKey);
                        Keyboard.Hold(Key);
                        Thread.Sleep(ms);
                        Keyboard.Release(Key);
                        Keyboard.Release(SecondKey);
                        Keyboard.Release(ThirdKey);
                    }
                }
            }
        }
    }
}
