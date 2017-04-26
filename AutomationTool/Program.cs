using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationTool
{
    class Program
    {
        static int Counter = 0;

        static void Main(string[] args)
        {            
                KeyHook.OnKeyDown += key =>
                {
                    if (key.ToString() == "LButton")
                        LeftMouseButtonScenario();
                    else
                    {
                        string Content = "Type(\"" + key + "\")";
                        Utilities.WriteToFile(@"C:\Users\Aji\Desktop\Test.sikuli\Test.py", Content);
                    }
                };
                KeyHook.Initialize();
                Console.WriteLine("Press enter to stop...");
                Console.Read();
        }
        static void LeftMouseButtonScenario()
        {
            String Location = @"C:\Users\Aji\Desktop\Test.sikuli";
            region Screen = new region(0, 0, 1366, 728);
            string filename = Path.Combine(Location, (Counter + ".png"));
            Utilities.CaptureScreen(Screen, filename);
            string Content = "click(Location(" + Utilities.CurrentMousePosition().x + "," + Utilities.CurrentMousePosition().y + "))";
            Utilities.WriteToFile(@"C:\Users\Aji\Desktop\Test.sikuli\Test.py", Content);
            Content = "wait(\"" + Counter + ".png\", 60)";
            Utilities.WriteToFile(@"C:\Users\Aji\Desktop\Test.sikuli\Test.py", Content);
            Console.WriteLine("\a");
            Counter++;
        }
    }
}
