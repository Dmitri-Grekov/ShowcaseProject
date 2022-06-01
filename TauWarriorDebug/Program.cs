using System;
using System.IO;
using System.Threading;
using TauWarriorCore;

namespace TauWarriorDebug
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, ScriptFile.ScriptsFolder)))
                Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, ScriptFile.ScriptsFolder));
            DirectoryInfo scripts = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, ScriptFile.ScriptsFolder));
            var script = scripts.GetFiles();
            Console.Title = $"Waiting...";
            Console.Clear();
            int i = 1;
            foreach (var s in script)
            {
                Console.WriteLine($"{i} = {Path.GetFileNameWithoutExtension(s.Name)}");
                i++;
            }
            int number;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out number))
                    break;
                else
                {
                    Console.Clear();
                    i = 1;
                    foreach (var s in script)
                    {
                        Console.WriteLine($"{i} = {Path.GetFileNameWithoutExtension(s.Name)}");
                        i++;
                    }
                }
            }
            string name = Path.GetFileNameWithoutExtension(script[number - 1].Name);
            var time = DateTime.Now;
            Console.Title = $"Running -> {name}";            
            Warrior.Start(ScriptFile.Load($"{script[number - 1].Name}"));
            while(true)
            {
                Console.Clear();
                var temp = (DateTime.Now - time);
                Console.WriteLine($"Running -> {name} ({temp.ToString(@"d\ h\:mm\:ss")})");
                Thread.Sleep(1000);
            }
        }
    }
}
