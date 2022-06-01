using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TauWarriorCore.Image;
using TauWarriorCore.Input;
using TauWarriorCore.Script;

namespace TauWarriorScript
{
    public class Recorder
    {
        public event EventHandler<EventArgs> RecordAdded;
        private List<string> Record = new List<string>();
        private List<(GamePadKeys key, KeyboardKeys replaceKey)> replaceKeys = new List<(GamePadKeys key, KeyboardKeys replaceKey)>();
        private readonly string keyboardId = "Keyboard";
        private readonly string mouseId = "Mouse";
        private readonly string gamepadId = "Gamepad";
        private readonly string recorderMainFolder = "Recorder";
        private readonly string screenShotFolder = "ScreenShots";
        private readonly string imagesFolder = "Images";
        private readonly string recordFolder = "Records";
        private readonly string screenShotName = "screenshot";
        private readonly string recordName = "record";
        private readonly string pointName = "_point";
        private readonly string areaName = "_area";
        private readonly string colorName = "_color";
        private readonly string imageName = "_img";
        private readonly object locker = new object();
        private bool globalActive = false;
        private bool active = false;
        private Point point1;
        private Point point2;
        private bool areaReading = false;
        private List<(KeyboardKeys key, long time, Stopwatch ms, bool active)> keyboard = new List<(KeyboardKeys key, long time, Stopwatch ms, bool active)>();
        private List<(MouseKeys key, long time, Stopwatch ms, bool active, Point point)> mouse = new List<(MouseKeys key, long time, Stopwatch ms, bool active, Point point)>();
        private List<(GamePadKeys key, long time, Stopwatch ms, bool active)> gamepad = new List<(GamePadKeys key, long time, Stopwatch ms, bool active)>();
        public List<KeyboardKeys> KeyBoardKeys { get; set; } = new List<KeyboardKeys>();
        public List<GamePadKeys> GamepadKeys { get; set; } = new List<GamePadKeys>();
        public List<MouseKeys> MouseKeys { get; set; } = new List<MouseKeys>();
        public bool AreaImage { get; set; }
        public bool AreaPoints { get; set; }
        public bool DirectInput { get; set; }
        public MouseSpeed MouseSpeed { get; set; }
        public string RecorderFolder
        {
            get
            {
                return recorderMainFolder;
            }
        }
        private bool Active
        {
            get { lock (locker) return active; }
            set { lock (locker) active = value; }
        }
        public Recorder()
        {


            globalActive = true;
            Init();
        }
        public async void Init()
        {
            if (!Directory.Exists(Path.Combine(recorderMainFolder, screenShotFolder)))
                Directory.CreateDirectory(Path.Combine(recorderMainFolder, screenShotFolder));
            if (!Directory.Exists(Path.Combine(recorderMainFolder, recordFolder)))
                Directory.CreateDirectory(Path.Combine(recorderMainFolder, recordFolder));
            if (!Directory.Exists(Path.Combine(recorderMainFolder, imagesFolder)))
                Directory.CreateDirectory(Path.Combine(recorderMainFolder, imagesFolder));
            await Task.Run(() =>
            {
                while (globalActive)
                {
                    if (Keyboard.IsPressed(KeyboardKeys.F11))
                    {
                        if (Active == false)
                        {
                            Start();
                            Console.Beep();
                        }
                    }
                    if (Keyboard.IsPressed(KeyboardKeys.F12))
                    {
                        if (Active)
                        {
                            Stop();
                            Console.Beep();
                            Thread.Sleep(1000);
                        }
                    }
                    if (Keyboard.IsPressed(KeyboardKeys.F9))
                    {
                        RecordPoint();
                        Console.Beep();
                        Thread.Sleep(1000);
                    }
                    if (Keyboard.IsPressed(KeyboardKeys.F5))
                    {
                        RecordColor();
                        Console.Beep();
                        Thread.Sleep(1000);
                    }
                    if (Keyboard.IsPressed(KeyboardKeys.F10))
                    {
                        ScreenShot();
                        Console.Beep();
                        Thread.Sleep(1000);
                    }
                    if (Keyboard.IsPressed(KeyboardKeys.F7))
                    {
                        areaReading = true;
                        StartRecordArea();
                        Console.Beep();
                        Thread.Sleep(1000);
                    }
                    if (Keyboard.IsPressed(KeyboardKeys.F8))
                    {
                        if (areaReading)
                        {
                            StopRecordArea();
                            Console.Beep();
                            Thread.Sleep(1000);
                        }
                    }
                    Thread.Sleep(1);
                }
            });
        }
        public void RecordAllKeyboard()
        {
            KeyBoardKeys.Clear();
            KeyBoardKeys.AddRange(Enum.GetValues<KeyboardKeys>());
        }
        public void RecordAllMouse()
        {
            MouseKeys.Clear();
            MouseKeys.AddRange(Enum.GetValues<MouseKeys>());
        }
        public void RecordAllGamePad()
        {
            GamepadKeys.Clear();
            GamepadKeys.AddRange(Enum.GetValues<GamePadKeys>());
        }
        public void RecordAll()
        {
            RecordAllKeyboard();
            RecordAllMouse();
            RecordAllGamePad();
        }
        public void ReplaceGamePadKey(GamePadKeys key, KeyboardKeys replaceKey)
        {
            replaceKeys.RemoveAll(x => x.key == key);
            replaceKeys.Add((key, replaceKey));
        }
        public string[] GetScriptNames()
        {
            return Directory.GetFiles(Path.Combine(recorderMainFolder, recordFolder)).Select(x => Path.GetFileNameWithoutExtension(x)).ToArray();
        }
        public void RemoveFile(string fileName)
        {
            File.Delete(Path.Combine(recorderMainFolder, recordFolder, $"{fileName}.txt"));
        }
        public string GetPath(string fileName)
        {
            return Path.Combine(recorderMainFolder, recordFolder, $"{fileName}.txt");
        }
        public string GetFileText(string fileName)
        {
            return File.ReadAllText(Path.Combine(recorderMainFolder, recordFolder, $"{fileName}.txt"));
        }
        public void Unload()
        {
            globalActive = false;
            Stop();
        }
        private void StartRecordArea()
        {
            point1 = Mouse.Position();
        }
        private void StopRecordArea()
        {
            point2 = Mouse.Position();
            if (AreaPoints)
            {
                string name = GetAreaName();
                MainForm.Script.ScreenAreas.Add(new ScreenArea(name, point1, point2));
                if (AreaImage)
                {
                    Bitmap image = Screen.ScreenShot(point1, point2);
                    string imagePath = Path.Combine(recorderMainFolder, imagesFolder, $"{name}.png");
                    image.Save(imagePath, ImageFormat.Png);
                    MainForm.Script.ScreenImages.Add(new ScreenImage(Path.GetFileNameWithoutExtension(imagePath), File.ReadAllBytes(imagePath)));
                }
            }
            else if (AreaImage)
            {
                string name = GetImageName();
                Bitmap image = Screen.ScreenShot(point1, point2);
                string imagePath = Path.Combine(recorderMainFolder, imagesFolder, $"{name}.png");
                image.Save(imagePath, ImageFormat.Png);
                MainForm.Script.ScreenImages.Add(new ScreenImage(Path.GetFileNameWithoutExtension(imagePath), File.ReadAllBytes(imagePath)));
            }
        }
        private void RecordColor()
        {
            Point mouse = Mouse.Position();
            MainForm.Script.ScreenColors.Add(new ScreenColor(GetColorName(), Screen.ScreenShot().GetPixel(mouse.X, mouse.Y)));
        }
        private void ScreenShot()
        {
            Screen.ScreenShot().Save(GetFileName(), ImageFormat.Bmp);
        }
        private void RecordPoint()
        {
            MainForm.Script.ScreenPoints.Add(new ScreenPoint(GetPointName(), Mouse.Position()));
        }
        private string GetAreaName()
        {
            int i = 1;
            while (MainForm.Script.ScreenAreas.Exists(x => x.Name == $"{areaName}{i}"))
            {
                i++;
            }
            return $"{areaName}{i}";
        }
        private string GetImageName()
        {
            int i = 1;
            while (MainForm.Script.ScreenImages.Exists(x => x.Name == $"{imageName}{i}"))
            {
                i++;
            }
            return $"{imageName}{i}";
        }
        private string GetColorName()
        {
            int i = 1;
            while (MainForm.Script.ScreenColors.Exists(x => x.Name == $"{colorName}{i}"))
            {
                i++;
            }
            return $"{colorName}{i}";
        }
        private string GetPointName()
        {
            int i = 1;
            while (MainForm.Script.ScreenPoints.Exists(x => x.Name == $"{pointName}{i}"))
            {
                i++;
            }
            return $"{pointName}{i}";
        }
        private string GetFileName()
        {
            int i = 1;
            while (File.Exists(Path.Combine(recorderMainFolder, screenShotFolder, $"{screenShotName}{i}.bmp")))
            {
                i++;
            }
            return Path.Combine(recorderMainFolder, screenShotFolder, $"{screenShotName}{i}.bmp");
        }
        private string GetScriptName()
        {
            int i = 1;
            while (File.Exists(Path.Combine(recorderMainFolder, recordFolder, $"{recordName}{i}.txt")))
            {
                i++;
            }
            return Path.Combine(recorderMainFolder, recordFolder, $"{recordName}{i}.txt");
        }
        private async void Start()
        {
            Active = true;
            MouseSpeed speed = MouseSpeed;
            Stopwatch sw = Stopwatch.StartNew();
            Point mousePos = Mouse.Position();
            await Task.Run(() =>
            {
                while (Active)
                {
                    foreach (KeyboardKeys key in KeyBoardKeys)
                    {
                        if (key != KeyboardKeys.F11 && key != KeyboardKeys.F12)
                        {
                            if (Keyboard.IsPressed(key))
                            {
                                int index = keyboard.FindIndex(x => x.key == key && x.active == true);
                                if (index == -1)
                                    keyboard.Add((key, sw.ElapsedMilliseconds, Stopwatch.StartNew(), true));
                            }
                            else
                            {
                                int index = keyboard.FindIndex(x => x.key == key && x.active == true);
                                if (index != -1)
                                {
                                    var t = keyboard[index];
                                    t.ms.Stop();
                                    t.active = false;
                                    keyboard[index] = t;
                                }
                            }
                        }
                    }
                    foreach (MouseKeys key in MouseKeys)
                    {
                        if (Mouse.IsPressed(key))
                        {
                            int index = mouse.FindIndex(x => x.key == key && x.active == true);
                            if (index == -1)
                            {
                                Point pos = Mouse.Position();
                                mouse.Add((key, sw.ElapsedMilliseconds - Mouse.MoveTime(mousePos, pos, speed), Stopwatch.StartNew(), true, pos));
                                mousePos = pos;
                            }
                        }
                        else
                        {
                            int index = mouse.FindIndex(x => x.key == key && x.active == true);
                            if (index != -1)
                            {
                                var t = mouse[index];
                                t.ms.Stop();
                                t.active = false;
                                mouse[index] = t;
                            }
                        }
                    }
                    foreach (GamePadKeys key in GamepadKeys)
                    {
                        if (GamePad.IsPressed(key, GamePadIndex.One))
                        {
                            int index = gamepad.FindIndex(x => x.key == key && x.active == true);
                            if (index == -1)
                                gamepad.Add((key, sw.ElapsedMilliseconds, Stopwatch.StartNew(), true));
                        }
                        else
                        {
                            int index = gamepad.FindIndex(x => x.key == key && x.active == true);
                            if (index != -1)
                            {
                                var t = gamepad[index];
                                t.ms.Stop();
                                t.active = false;
                                gamepad[index] = t;
                            }
                        }
                    }
                    Thread.Sleep(1);
                }
                foreach (var k in keyboard)
                {
                    k.ms.Stop();
                }
                foreach (var m in mouse)
                {
                    m.ms.Stop();
                }
                foreach (var g in gamepad)
                {
                    g.ms.Stop();
                }
            });
            List<(string id, string key, long ms, long time, Point point)> data = new List<(string id, string key, long ms, long time, Point point)>();
            data.AddRange(keyboard.Select(x => (keyboardId, Enum.GetName(typeof(KeyboardKeys), x.key), x.ms.ElapsedMilliseconds, x.time, Point.Empty)));
            data.AddRange(mouse.Select(x => (mouseId, Enum.GetName(typeof(MouseKeys), x.key), x.ms.ElapsedMilliseconds, x.time < 0 ? 0 : x.time, x.point)));
            data.AddRange(gamepad.Select(x => (gamepadId, Enum.GetName(typeof(GamePadKeys), x.key), x.ms.ElapsedMilliseconds, x.time, Point.Empty)));
            data = data.OrderBy(x => x.time).ToList();
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].id == gamepadId)
                {
                    if (replaceKeys.Exists(x => Enum.GetName(typeof(GamePadKeys), x.key) == data[i].key))
                    {
                        data[i] = (keyboardId, Enum.GetName(typeof(KeyboardKeys), replaceKeys.First(x => Enum.GetName(typeof(GamePadKeys), x.key) == data[i].key).replaceKey), data[i].ms, data[i].time, data[i].point);
                    }
                }
            }
            Record.Add($"DirectInput={DirectInput.ToString().ToLower()}:MouseSpeed={MouseSpeed.ToString().ToLower()}:");
            for (int i = 0; i < data.Count; i++)
            {
                if (i == 0)
                {
                    if (data[i].time != 0)
                        Record.Add($"Wait:{data[i].time}:");
                    if (data[i].id == keyboardId || data[i].id == gamepadId)
                        Record.Add($"{data[i].id}:{data[i].key}:{data[i].ms}:");
                    else
                        Record.Add($"{data[i].id}:{data[i].key}:{data[i].ms}:{data[i].point.X}:{data[i].point.Y}:");
                }
                else
                {
                    Record.Add($"Wait:{data[i].time - data[i - 1].time - data[i - 1].ms}:");
                    if (data[i].id == keyboardId || data[i].id == gamepadId)
                        Record.Add($"{data[i].id}:{data[i].key}:{data[i].ms}:");
                    else
                        Record.Add($"{data[i].id}:{data[i].key}:{data[i].ms}:{data[i].point.X}:{data[i].point.Y}:");
                }
            }
            string fileName = GetScriptName();
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                using (StreamWriter s = new StreamWriter(fs))
                {
                    foreach (var l in Record)
                        s.WriteLine(l);
                }
            }
            keyboard.Clear();
            mouse.Clear();
            gamepad.Clear();
            Record.Clear();
            OnRecordAdded();
        }
        private void Stop()
        {
            Active = false;
        }
        private void OnRecordAdded()
        {
            RecordAdded?.Invoke(this, EventArgs.Empty);
        }
    }
}
