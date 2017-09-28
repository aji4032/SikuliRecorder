using System;
using System.IO;
using System.Reflection;
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
            KeyHook.OnKeyDown += key =>
            {
                Console.WriteLine("KD:" + key);
                if(key.ToString().Equals("ControlKey"))
                    Console.WriteLine("this works");
                try
                {
                    Type keyType = Type.GetType("AutomationTool." + key.ToString());
                    MethodInfo keyDownMethod = keyType.GetMethod("onKeyDown", BindingFlags.Static | BindingFlags.Public);
                    Counter = (int)keyDownMethod.Invoke(null, new object[] { Counter });
                } catch (NullReferenceException)
                {
                    string Content = "keyDown(\"" + key + "\")";
                    Utilities.WriteToFile(ScriptFile, Content);
                }
            };
            KeyHook.OnKeyUp += key =>
            {
                Console.WriteLine("KU:" + key);
                try
                {
                    Type keyType = Type.GetType("AutomationTool." + key.ToString());
                    MethodInfo keyUpMethod = keyType.GetMethod("onKeyUp", BindingFlags.Static | BindingFlags.Public);
                    Counter = (int)keyUpMethod.Invoke(keyUpMethod, new object[] { Counter });
                } catch(NullReferenceException)
                {
                    string Content = "keyUp(\"" + key + "\")";
                    Utilities.WriteToFile(ScriptFile, Content);
                }

            };
            KeyHook.Initialize();
            Console.Read();
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
    }
}
