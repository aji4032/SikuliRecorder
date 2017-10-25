using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Utils = AutomationTool.Utils;

namespace AutomationTool
{
    class Program
    {
        static int Counter = 0;
        public static string ScriptFolder = Path.Combine(Utils.GetFromConfigFile("TestLocation"), (Utils.GetFromConfigFile("ScriptName") + ".sikuli"));
        public static string ScriptFile = Path.Combine(ScriptFolder, (Utils.GetFromConfigFile("ScriptName") + ".py"));

        static bool appRunning = false;
        static bool instructions = true;

        static void Main(string[] args)
        {
            Setup();
            if (instructions)
            {
                Console.WriteLine("*******************************************");
                Console.WriteLine("************** Instructions ***************");
                Console.WriteLine("*******************************************");
                Console.WriteLine("Press F2 to Start/Pause recording.");
                Console.WriteLine("Right click to re-capture last screenshot.");
                Console.WriteLine("*******************************************");
                instructions = false;
            }
            //For KeyDown Operations
            KeyHook.OnKeyDown += key =>
            {
                if (key.ToString().Equals("F2"))
                {
                    if(!appRunning)
                    {
                        Utils.CaptureScreen(new region(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y,
                                Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height),
                                Path.Combine(Program.ScriptFolder, (Counter + ".png")));
                        Utils.WriteToFile(ScriptFile, "wait(Pattern(\"" + Counter + ".png\").similar(0.9), 30)");
                        Counter++;
                    }
                    Console.Write("\a");
                    appRunning = !appRunning;
                }
                if (appRunning)
                {
                    try
                    {
                        Type keyType = Type.GetType("AutomationTool." + key.ToString());
                        MethodInfo keyDownMethod = keyType.GetMethod("onKeyDown", BindingFlags.Static | BindingFlags.Public);
                        Counter = (int)keyDownMethod.Invoke(null, new object[] { Counter });
                    }
                    catch (NullReferenceException)
                    {
                        string Content = "keyDown(\"" + key + "\")";
                        Utils.WriteToFile(ScriptFile, Content);
                    }
                }
            };
            //For KeyDown Operations
            KeyHook.OnKeyUp += key =>
            {
                if (appRunning)
                {
                    try
                    {
                        Type keyType = Type.GetType("AutomationTool." + key.ToString());
                        MethodInfo keyUpMethod = keyType.GetMethod("onKeyUp", BindingFlags.Static | BindingFlags.Public);
                        Counter = (int)keyUpMethod.Invoke(keyUpMethod, new object[] { Counter });
                    }
                    catch (NullReferenceException)
                    {
                        string Content = "keyUp(\"" + key + "\")";
                        Utils.WriteToFile(ScriptFile, Content);
                    }
                }
            };
            KeyHook.Initialize();
            Console.Read();
        }
        private static void Setup()
        {
            if (!Directory.Exists(ScriptFolder))
                Directory.CreateDirectory(ScriptFolder);
            if (!File.Exists(ScriptFile))
                File.Create(ScriptFile);
        }
    }
}
