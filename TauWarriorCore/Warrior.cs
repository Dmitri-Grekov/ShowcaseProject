using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TauWarriorCore.Image;
using TauWarriorCore.Script;

namespace TauWarriorCore
{
    public static class Warrior
    {
        private static readonly object lockerActive = new object();
        private static readonly object lockerChangeState = new object();
        private static readonly object lockerCurrentState = new object();
        private static readonly object lockerCurrentScript = new object();
        private static readonly List<ScriptMouse> MouseScripts = new List<ScriptMouse>();
        private static readonly List<ScriptKeyboard> KeyboardScripts = new List<ScriptKeyboard>();
        private static readonly List<ScriptGamePad> GamePadScripts = new List<ScriptGamePad>();
        private static ScriptFile currentScript;
        private static string currentState;
        private static bool active = false;
        private static bool changeState = false;
        private static CancellationTokenSource token;
        public static string GetCurrentScreenShotFolder
        {
            get
            {
                string path = Path.Combine(Environment.CurrentDirectory, CurrentScript.Name, ScriptFile.ScreenShotFolder);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                return path;
            }
        }
        public static bool Active
        {
            get { lock (lockerActive) return active; }
            set { lock (lockerActive) active = value; }
        }
        public static bool ChangeState
        {
            get { lock (lockerChangeState) return changeState; }
            set { lock (lockerChangeState) changeState = value; }
        }
        public static string CurrentState
        {
            get { lock (lockerCurrentState) return currentState; }
            set { lock (lockerCurrentState) currentState = value; }
        }
        public static ScriptFile CurrentScript
        {
            get { lock (lockerCurrentScript) return currentScript; }
            set { lock (lockerCurrentScript) currentScript = value; }
        }
        public static void Start(ScriptFile script)
        {
            if (Active)
                Stop();
            token = new CancellationTokenSource();
            CurrentScript = script;
            CurrentState = script.States.First().Name;
            foreach (var img in script.ScreenImages)
            {
                using (var ms = new MemoryStream(img.Data))
                    Screen.ImagesAdd(new ImageData(img.Name, new Bitmap(ms)));
            }
            foreach (var m in script.MouseActions)
            {
                MouseScripts.Add(new ScriptMouse(m));
            }
            foreach (var k in script.KeyboardActions)
            {
                KeyboardScripts.Add(new ScriptKeyboard(k));
            }
            foreach (var g in script.GamePadActions)
            {
                GamePadScripts.Add(new ScriptGamePad(g));
            }
            Active = true;
            WarriorThread();
            PassiveStateThread();
            InputThread();
            GCThread();
        }
        public static void Stop()
        {
            Active = false;
            token.Cancel();
            Screen.ImagesClear();
            MouseScripts.Clear();
            KeyboardScripts.Clear();
            GamePadScripts.Clear();
        }
        private static async void WarriorThread()
        {
            await Task.Run(async () =>
            {
                Thread.CurrentThread.Priority = ThreadPriority.Highest;
                while (Active)
                {
                    foreach (var action in CurrentScript.States.First(x => x.Name == CurrentState).Actions)
                    {
                        if (ChangeState)
                        {
                            break;
                        }
                        action.Start();
                        if (ChangeState)
                        {
                            break;
                        }
                    }
                    if (ChangeState)
                    {
                        ChangeState = false;
                    }
                    else
                    {
                        CurrentState = CurrentScript.States.First(x => x.Name == CurrentState).NextState;
                    }
                    await Task.Delay(1);
                }
            }, token.Token);
        }
        private static async void GCThread()
        {
            await Task.Run(async () =>
            {
                Thread.CurrentThread.Priority = ThreadPriority.BelowNormal;
                while (Active)
                {
                    await Task.Delay(10000);
                    GC.Collect();
                }
            }, token.Token);
        }
        private static async void PassiveStateThread()
        {
            await Task.Run(async () =>
            {
                Thread.CurrentThread.Priority = ThreadPriority.AboveNormal;
                Stopwatch sw = new Stopwatch();
                double time = 0;
                while (Active)
                {
                    time = sw.Elapsed.TotalMilliseconds;
                    sw.Restart();
                    foreach (var state in CurrentScript.PassiveStates)
                    {
                        if (state.Check(TimeSpan.FromMilliseconds(time)))
                        {
                            ChangeState = true;
                            CurrentState = state.NextState;
                        }
                    }
                    await Task.Delay(1000);
                }
            }, token.Token);
        }
        private static async void InputThread()
        {
            await Task.Run(async () =>
            {
                Thread.CurrentThread.Priority = ThreadPriority.Highest;
                while (Active)
                {
                    foreach (var mouse in MouseScripts)
                    {
                        if (mouse.Check())
                        {
                            ChangeState = true;
                            CurrentState = mouse.MouseAction.NextState;
                        }
                    }
                    foreach (var keyboard in KeyboardScripts)
                    {
                        if (keyboard.Check())
                        {
                            ChangeState = true;
                            CurrentState = keyboard.KeyboardAction.NextState;
                        }
                    }
                    foreach (var gamepad in GamePadScripts)
                    {
                        if (gamepad.Check())
                        {
                            ChangeState = true;
                            CurrentState = gamepad.GamePadAction.NextState;
                        }
                    }
                    await Task.Delay(1);
                }
            }, token.Token);
        }
    }
    public enum ImgFormat
    {
        PNG, JPEG, BMP
    }
}
