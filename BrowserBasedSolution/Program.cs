using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using Utils = BrowserBasedSolution.Utils;

namespace BrowserBasedSolution
{
    class Program
    {
        public static bool DebugMode;
        public static string TestLocation;
        public static string ScriptFolder;
        public static string ScriptFile;
        public static string LogFile;
        public static Rectangle ScreenSize;
        public static Rectangle UserBoundary;
        static int Counter;
        static bool appRunningStatus;
        static bool instructions = true;

        static void Main(string[] args)
        {
            if (instructions)
            {
                Setup();
                Console.WriteLine("*********************************************");
                Console.WriteLine("*************** Instructions ****************");
                Console.WriteLine("*********************************************");
                Console.WriteLine("1. Press F2 to Start/Pause recording.");
                Console.WriteLine("2. Right click to re-capture last screenshot.");
                Console.WriteLine("*********************************************");
                instructions = false;
            }
            //For KeyDown Operations
            KeyHook.OnKeyDown += key =>
            {
                if (key.ToString().Equals("F2"))
                { 
                    if(!appRunningStatus)
                    {
                        Utils.CaptureScreen(ScreenSize, Path.Combine(Program.ScriptFolder, (Counter + ".png")));
                        Utils.WriteToFile(ScriptFile, "wait(Pattern(\"" + Counter + ".png\").similar(0.9), 30)");
                        Counter++;
                    }
                    appRunningStatus = !appRunningStatus;
                    Console.Write("\a");
                }
                if (appRunningStatus)
                {
                    try
                    {
                        Type keyType = Type.GetType("BrowserBasedSolution." + key.ToString());
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
                if (appRunningStatus)
                {
                    try
                    {
                        Type keyType = Type.GetType("BrowserBasedSolution." + key.ToString());
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
            try
            {
                Counter = 0;
                appRunningStatus = false;
                DebugMode = Boolean.Parse(Utils.GetFromConfigFile("Debug"));
                TestLocation = Utils.GetFromConfigFile("TestLocation");
                ScriptFolder = Path.Combine(TestLocation, (Utils.GetFromConfigFile("ScriptName") + ".sikuli"));
                ScriptFile = Path.Combine(ScriptFolder, (Utils.GetFromConfigFile("ScriptName") + ".py"));
                LogFile = Path.Combine(ScriptFolder, "Log.txt");

                ScreenSize = new Rectangle(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y,
                                    Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                UserBoundary = new Rectangle(
                                            Convert.ToInt32(Utils.GetFromConfigFile("BoundX")),
                                            Convert.ToInt32(Utils.GetFromConfigFile("BoundY")),
                                            Convert.ToInt32(Utils.GetFromConfigFile("BoundW")),
                                            Convert.ToInt32(Utils.GetFromConfigFile("BoundH")));

                if (!Directory.Exists(ScriptFolder))
                    Directory.CreateDirectory(ScriptFolder);
                if (!File.Exists(ScriptFile))
                    File.Create(ScriptFile);
                if (!File.Exists(LogFile))
                    File.Create(LogFile);
            }
            catch(Exception e)
            {
                Console.WriteLine("[error] Failed to Initialize setup!");
                Console.WriteLine(e.Message);
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }
}
