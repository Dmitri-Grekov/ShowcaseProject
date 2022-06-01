using SharpDX.DirectInput;
using System.Diagnostics;
using System.Threading;

namespace TauWarriorCore.Input
{
    public static class JoyStick
    {
        private static readonly DirectInput directInput = new DirectInput();
        private static Joystick controller1 = null;
        private static Joystick controller2 = null;
        private static Joystick controller3 = null;
        private static Joystick controller4 = null;
        private static JoystickState state;
        public static bool IsPressed(JoyStickKeys key, GamePadIndex index)
        {
            switch (index)
            {
                case GamePadIndex.One:
                    if (controller1 != null)
                    {
                        try
                        {
                            state = controller1.GetCurrentState();
                        }
                        catch
                        {
                            controller1 = null;
                            return false;
                        }
                        return IsActive(key);
                    }
                    else
                    {
                        var devices = directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices);
                        if (devices.Count > 0)
                        {
                            controller1 = new Joystick(directInput, devices[0].InstanceGuid);
                            controller1.Acquire();
                            Thread.Sleep(10);
                            state = controller1.GetCurrentState();
                            return IsActive(key);
                        }
                    }
                    ; break;
                case GamePadIndex.Two:
                    if (controller2 != null)
                    {
                        try
                        {
                            state = controller2.GetCurrentState();
                        }
                        catch
                        {
                            controller2 = null;
                            return false;
                        }
                        return IsActive(key);
                    }
                    else
                    {
                        var devices = directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices);
                        if (devices.Count > 1)
                        {
                            controller2 = new Joystick(directInput, devices[1].InstanceGuid);
                            controller2.Acquire();
                            Thread.Sleep(10);
                            state = controller2.GetCurrentState();
                            return IsActive(key);
                        }
                    }
                    ; break;
                case GamePadIndex.Three:
                    if (controller3 != null)
                    {
                        try
                        {
                            state = controller3.GetCurrentState();
                        }
                        catch
                        {
                            controller3 = null;
                            return false;
                        }
                        return IsActive(key);
                    }
                    else
                    {
                        var devices = directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices);
                        if (devices.Count > 2)
                        {
                            controller3 = new Joystick(directInput, devices[2].InstanceGuid);
                            controller3.Acquire();
                            Thread.Sleep(10);
                            state = controller3.GetCurrentState();
                            return IsActive(key);
                        }
                    }
                    ; break;
                case GamePadIndex.Four:
                    if (controller4 != null)
                    {
                        try
                        {
                            state = controller4.GetCurrentState();
                        }
                        catch
                        {
                            controller4 = null;
                            return false;
                        }
                        return IsActive(key);
                    }
                    else
                    {
                        var devices = directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices);
                        if (devices.Count > 3)
                        {
                            controller4 = new Joystick(directInput, devices[3].InstanceGuid);
                            controller4.Acquire();
                            Thread.Sleep(10);
                            state = controller4.GetCurrentState();
                            return IsActive(key);
                        }
                    }
                    ; break;
            }
            return false;
        }
        private static bool IsActive(JoyStickKeys key)
        {
            switch (key)
            {
                case JoyStickKeys.B1: return state.Buttons[0];
                case JoyStickKeys.B2: return state.Buttons[1];
                case JoyStickKeys.B3: return state.Buttons[2];
                case JoyStickKeys.B4: return state.Buttons[3];
                case JoyStickKeys.B5: return state.Buttons[4];
                case JoyStickKeys.B6: return state.Buttons[5];
                case JoyStickKeys.B7: return state.Buttons[6];
                case JoyStickKeys.B8: return state.Buttons[7];
                case JoyStickKeys.B9: return state.Buttons[8];
                case JoyStickKeys.B10: return state.Buttons[9];
                case JoyStickKeys.B11: return state.Buttons[10];
                case JoyStickKeys.B12: return state.Buttons[11];
                case JoyStickKeys.Up: return state.PointOfViewControllers[0] == 0 || state.PointOfViewControllers[0] == 31500 || state.PointOfViewControllers[0] == 4500;
                case JoyStickKeys.Down: return state.PointOfViewControllers[0] == 18000 || state.PointOfViewControllers[0] == 22500 || state.PointOfViewControllers[0] == 13500;
                case JoyStickKeys.Left: return state.PointOfViewControllers[0] == 27000 || state.PointOfViewControllers[0] == 31500 || state.PointOfViewControllers[0] == 22500;
                case JoyStickKeys.Right: return state.PointOfViewControllers[0] == 9000 || state.PointOfViewControllers[0] == 13500 || state.PointOfViewControllers[0] == 4500;
                case JoyStickKeys.RStickUp: return state.RotationZ < 2767;
                case JoyStickKeys.RStickDown: return state.RotationZ > 62768;
                case JoyStickKeys.RStickLeft: return state.Z < 2767;
                case JoyStickKeys.RStickRight: return state.Z > 62768;
                case JoyStickKeys.LStickUp: return state.Y < 2767;
                case JoyStickKeys.LStickDown: return state.Y > 62768;
                case JoyStickKeys.LStickLeft: return state.X < 2767;
                case JoyStickKeys.LStickRight: return state.X > 62768;
            }
            return false;
        }
    }
    public enum JoyStickKeys : int
    {
        NONE, B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, B11, B12, Up, Down, Left, Right, LStickUp, LStickDown, LStickLeft, LStickRight, RStickUp, RStickDown, RStickLeft, RStickRight
    }
}
