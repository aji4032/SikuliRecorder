using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utils = AutomationTool.Utilities;

namespace AutomationTool
{
    class Program
    {
        static int Counter = 0;
        static string ScriptFolder;
        static string ScriptFile;
        static void Main(string[] args)
        {
            Setup();
            KeyHook.OnKeyUp += key =>
            {
                if (key.ToString() == "LButton")
                    LeftMouseButtonScenario();
                else if (key.ToString() == "RButton")
                    RightMouseButtonScenario();
                else
                {
                    string Content = "Type(\"" + key + "\")";
                    Utilities.WriteToFile(ScriptFile, Content);
                }
            };
            KeyHook.Initialize();
            Console.Read();
        }

        private static void RightMouseButtonScenario()
        {
            Counter--;
            region Screen = new region(0, 0, 1366, 768);
            string filename = Path.Combine(ScriptFolder, (Counter + ".png"));
            Utilities.CaptureScreen(Screen, filename);
            Console.WriteLine("\a");
            Counter++;
        }

        private static void Setup()
        {
            ScriptFolder = Path.Combine(Utilities.GetFromConfigFile("TestLocation"), (Utilities.GetFromConfigFile("ScriptName") + ".sikuli"));
            ScriptFile = Path.Combine(ScriptFolder, (Utilities.GetFromConfigFile("ScriptName") + ".py"));
            if (!Directory.Exists(ScriptFolder))
                Directory.CreateDirectory(ScriptFolder);
            if (!File.Exists(ScriptFile))
                File.Create(ScriptFile);
        }

        static void LeftMouseButtonScenario()
        {
            region Screen = new region(0, 0, 1366, 768);
            string filename = Path.Combine(ScriptFolder, (Counter + ".png"));
            Utilities.CaptureScreen(Screen, filename);
            string Content = "click(Location(" + Utils.CurrentMousePosition().x + "," + Utils.CurrentMousePosition().y + "))";
            Utilities.WriteToFile(ScriptFile, Content);
            Content = "wait(\"" + Counter + ".png\", 60)";
            Utilities.WriteToFile(ScriptFile, Content);
            Console.WriteLine("\a");
            Counter++;
        }
    }
}
