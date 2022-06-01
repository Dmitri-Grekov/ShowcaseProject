using SharpDX.XInput;

namespace TauWarriorCore.Input
{
    public static class GamePad
    {
        private static readonly Controller controller1 = new Controller(UserIndex.One);
        private static readonly Controller controller2 = new Controller(UserIndex.Two);
        private static readonly Controller controller3 = new Controller(UserIndex.Three);
        private static readonly Controller controller4 = new Controller(UserIndex.Four);
        private static State state;
        public static bool IsPressed(GamePadKeys key, GamePadIndex index)
        {
            switch (index)
            {
                case GamePadIndex.One:
                    if (controller1.IsConnected)
                    {
                        state = controller1.GetState();
                        return IsActive(key);
                    }; break;
                case GamePadIndex.Two:
                    if (controller2.IsConnected)
                    {
                        state = controller2.GetState();
                        return IsActive(key);
                    }; break;
                case GamePadIndex.Three:
                    if (controller3.IsConnected)
                    {
                        state = controller3.GetState();
                        return IsActive(key);
                    }; break;
                case GamePadIndex.Four:
                    if (controller4.IsConnected)
                    {
                        state = controller4.GetState();
                        return IsActive(key);
                    }; break;
            }
            return false;
        }
        private static bool IsActive(GamePadKeys key)
        {
            switch (key)
            {
                case GamePadKeys.A: return state.Gamepad.Buttons == GamepadButtonFlags.A;
                case GamePadKeys.B: return state.Gamepad.Buttons == GamepadButtonFlags.B;
                case GamePadKeys.Back: return state.Gamepad.Buttons == GamepadButtonFlags.Back;
                case GamePadKeys.Down: return state.Gamepad.Buttons == GamepadButtonFlags.DPadDown;
                case GamePadKeys.LB: return state.Gamepad.Buttons == GamepadButtonFlags.LeftShoulder;
                case GamePadKeys.Left: return state.Gamepad.Buttons == GamepadButtonFlags.DPadLeft;
                case GamePadKeys.LStick: return state.Gamepad.Buttons == GamepadButtonFlags.LeftThumb;
                case GamePadKeys.LStickDown: return state.Gamepad.LeftThumbY < -30000;
                case GamePadKeys.LStickLeft: return state.Gamepad.LeftThumbX < -30000;
                case GamePadKeys.LStickRight: return state.Gamepad.LeftThumbX > 30000;
                case GamePadKeys.LStickUp: return state.Gamepad.LeftThumbY > 30000;
                case GamePadKeys.LT: return state.Gamepad.LeftTrigger > 250;
                case GamePadKeys.RB: return state.Gamepad.Buttons == GamepadButtonFlags.RightShoulder;
                case GamePadKeys.Right: return state.Gamepad.Buttons == GamepadButtonFlags.DPadRight;
                case GamePadKeys.RStick: return state.Gamepad.Buttons == GamepadButtonFlags.RightThumb;
                case GamePadKeys.RStickDown: return state.Gamepad.RightThumbY < -30000;
                case GamePadKeys.RStickLeft: return state.Gamepad.RightThumbX < -30000;
                case GamePadKeys.RStickRight: return state.Gamepad.RightThumbX > 30000;
                case GamePadKeys.RStickUp: return state.Gamepad.RightThumbY > 30000;
                case GamePadKeys.RT: return state.Gamepad.RightTrigger > 250;
                case GamePadKeys.Start: return state.Gamepad.Buttons == GamepadButtonFlags.Start;
                case GamePadKeys.Up: return state.Gamepad.Buttons == GamepadButtonFlags.DPadUp;
                case GamePadKeys.X: return state.Gamepad.Buttons == GamepadButtonFlags.X;
                case GamePadKeys.Y: return state.Gamepad.Buttons == GamepadButtonFlags.Y;
            }
            return false;
        }
    }
    public enum GamePadType
    {
        GamePad, JoyStick
    }
    public enum GamePadIndex : int
    {
        One, Two, Three, Four
    }
    public enum GamePadKeys : int
    {
        NONE, A, X, Y, B, Start, Back, LStick, RStick, LB, RB, Up, Down, Left, Right, LT, RT, LStickUp, LStickDown, LStickLeft, LStickRight, RStickUp, RStickDown, RStickLeft, RStickRight
    }
}
