using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace TauWarriorCore.Actions
{
    [Serializable]
    public class OpenProcess : IAction
    {
        public string Name => "Open Process";
        public ActionType ActionType => ActionType.OpenProcess;
        public string FilePath { get; }
        public List<string> Arguments { get; }
        public string Info
        {
            get
            {
                return $"Open {Path.GetFileName(FilePath)}";
            }
        }
        public OpenProcess(string filePath, List<string> arguments)
        {
            FilePath = filePath;
            Arguments = arguments;
        }
        public IAction GetCopy()
        {
            OpenProcess copy = new OpenProcess(FilePath, Arguments);
            return copy;
        }
        public bool Start()
        {
            if (Warrior.Active)
            {
                if (File.Exists(FilePath))
                {
                    Process process = new Process();
                    ProcessStartInfo info = new ProcessStartInfo(FilePath, string.Join(' ', Arguments));
                    info.WorkingDirectory = Path.GetDirectoryName(FilePath);
                    process.StartInfo = info;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}