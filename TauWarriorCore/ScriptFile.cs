using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using TauWarriorCore.Actions;
using TauWarriorCore.Script;

namespace TauWarriorCore
{
    [Serializable]
    public class ScriptFile
    {
        public static string ScriptsFolder { get; } = "Scripts";
        public static string ScreenShotFolder { get; } = "ScreenShots";
        public static string ScriptExtension { get; } = "war";
        public static string ScriptHoldState { get; } = "_hold";
        public static string ScriptMainState { get; } = "_main";
        public string Name { get; set; } = "";
        public string Version { get; set; } = "0";
        public List<ScreenArea> ScreenAreas { get; } = new List<ScreenArea>();
        public List<ScreenPoint> ScreenPoints { get; } = new List<ScreenPoint>();
        public List<ScreenImage> ScreenImages { get; } = new List<ScreenImage>();
        public List<ScreenColor> ScreenColors { get; } = new List<ScreenColor>();
        public List<ScriptState> States { get; } = new List<ScriptState>();
        public List<ScriptPassiveState> PassiveStates { get; } = new List<ScriptPassiveState>();
        public List<ScriptMouseAction> MouseActions { get; } = new List<ScriptMouseAction>();
        public List<ScriptKeyboardAction> KeyboardActions { get; } = new List<ScriptKeyboardAction>();
        public List<ScriptGamePadAction> GamePadActions { get; } = new List<ScriptGamePadAction>();
        public List<ScriptRemapConfig> RemapConfigs { get; } = new List<ScriptRemapConfig>();
        public ScriptFile()
        {
            Name = "temp";
            States.Add(new ScriptState(ScriptMainState, ScriptHoldState, new List<IAction>()));
            States.Add(new ScriptState(ScriptHoldState, ScriptHoldState, new List<IAction>() { new Wait(1) }));
        }
        public static void Save(ScriptFile script)
        {
            if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, ScriptsFolder)))
                Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, ScriptsFolder));
            IFormatter formatter = new BinaryFormatter();
            FileStream temp = new FileStream(Path.Combine(Environment.CurrentDirectory, ScriptsFolder, script.Name + "." + ScriptExtension + ".temp"), FileMode.Create);
            formatter.Serialize(temp, script);
            FileStream original = new FileStream(Path.Combine(Environment.CurrentDirectory, ScriptsFolder, script.Name + "." + ScriptExtension), FileMode.OpenOrCreate);
            temp.Position = 0;
            temp.CopyTo(original);
            temp.Close();
            temp.Dispose();
            File.Delete(Path.Combine(Environment.CurrentDirectory, ScriptsFolder, script.Name + "." + ScriptExtension + ".temp"));
            original.Close();
            original.Dispose();
        }
        public static ScriptFile Load(string fileName)
        {
            FileStream original = new FileStream(Path.Combine(Environment.CurrentDirectory, ScriptsFolder, fileName), FileMode.Open, FileAccess.Read);
            IFormatter formatter = new BinaryFormatter();
            ScriptFile script = (ScriptFile)formatter.Deserialize(original);
            original.Close();
            original.Dispose();
            return script;
        }
    }
}