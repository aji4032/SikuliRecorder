using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Utils = AutomationTool.Utils;

namespace AutomationTool
{
    class Program
    {
        static int Counter = 1;
        public static string ScriptFolder = Path.Combine(Utils.GetFromConfigFile("TestLocation"), (Utils.GetFromConfigFile("ScriptName") + ".sikuli"));
        public static string ScriptFile = Path.Combine(ScriptFolder, (Utils.GetFromConfigFile("ScriptName") + ".py"));

        static bool appRunning = false;
        static int  appRunFlag;

        static bool altKey = false;
        static bool ctrlKey = false;
        static bool shiftKey = false;

        static void Main(string[] args)
        {
            Setup();
            //For KeyDown Operations
            KeyHook.OnKeyDown += key =>
            {
                if(appRunning)
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
                else
                { 
                    if (key.ToString().Equals("Menu"))
                        altKey = true;
                    if (key.ToString().Equals("ControlKey"))
                        ctrlKey = true;
                    if (key.ToString().Equals("ShiftKey"))
                        shiftKey = true;
                    //To start the recorder press ALT+CTRL+SHIFT
                    if (altKey && ctrlKey && shiftKey)
                    {
                        Console.WriteLine("\a");
                        appRunning = true;
                        appRunFlag = 3;
                    }
                }
            };
            //For KeyDown Operations
            KeyHook.OnKeyUp += key =>
            {
                if (appRunning)
                {
                    //To make sure initial release of ALT, SHIFT and CTRL keys are not recorded.
                    if (appRunFlag == 0)
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
                    else if (key.ToString().Equals("Menu") || key.ToString().Equals("ControlKey") || key.ToString().Equals("ShiftKey"))
                    {
                        appRunFlag--;
                        if (appRunFlag == 0)
                        {
                            Utils.CaptureScreen(new region(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y,
                                Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height),
                                Path.Combine(ScriptFolder, "0.png"));
                            Console.WriteLine("\a");
                            Utils.WriteToFile(ScriptFile, "wait(\"0.png\", 30)");
                        }
                    }
                }
                else
                {
                    if (key.ToString().Equals("Menu"))
                        altKey = false;
                    if (key.ToString().Equals("ControlKey"))
                        ctrlKey = false;
                    if (key.ToString().Equals("ShiftKey"))
                        shiftKey = false;
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
