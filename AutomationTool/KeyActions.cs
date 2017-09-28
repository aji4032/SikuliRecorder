using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils = AutomationTool.Utilities;


namespace AutomationTool
{
    
    class LButton
    {
        static point keyDownLocation;
        public static int onKeyDown(int Counter)
        {
            keyDownLocation = Utilities.CurrentMousePosition();
            return Counter;
        }

        public static int onKeyUp(int Counter)
        {
            point keyUpLocation = Utilities.CurrentMousePosition();
            String ScriptFolder = Path.Combine(Utilities.GetFromConfigFile("TestLocation"), (Utilities.GetFromConfigFile("ScriptName") + ".sikuli"));
            String ScriptFile = Path.Combine(ScriptFolder, (Utilities.GetFromConfigFile("ScriptName") + ".py"));
            Rectangle resolution = Screen.PrimaryScreen.Bounds;
            region screen = new region(resolution.X,resolution.Y,resolution.Width,resolution.Height);
            string filename = Path.Combine(ScriptFolder, (Counter + ".png"));
            Utilities.CaptureScreen(screen, filename);
            string Content;
            if (keyUpLocation.Equals(keyDownLocation))
                Content = "click(Location(" + Utils.CurrentMousePosition().x + "," + Utils.CurrentMousePosition().y + "))";
            else
                Content = "dragDrop(Location(" + keyDownLocation.x + "," + keyDownLocation.y + "),Location(" + keyUpLocation.x + "," + keyUpLocation.y + "))";
            keyDownLocation = null;
            Utilities.WriteToFile(ScriptFile, Content);
            Content = "wait(\"" + Counter + ".png\", 30)";
            Utilities.WriteToFile(ScriptFile, Content);
            Console.WriteLine("\a");
            Counter++;
            return Counter;
        }
    }
    class RButton
    {
        public static int onKeyDown(int Counter)
        {
            return Counter;
        }

        public static int onKeyUp(int Counter)
        {
            String ScriptFolder = Path.Combine(Utilities.GetFromConfigFile("TestLocation"), (Utilities.GetFromConfigFile("ScriptName") + ".sikuli"));
            Counter--;
            Rectangle resolution = Screen.PrimaryScreen.Bounds;
            region screen = new region(resolution.X, resolution.Y, resolution.Width, resolution.Height);
            string filename = Path.Combine(ScriptFolder, (Counter + ".png"));
            Utils.CaptureScreen(screen, filename);
            Console.WriteLine("\a");
            Counter++;
            return Counter;
        }
    }
    class ControlKey
    {
        public static int onKeyDown(int Counter)
        {
            string Content = "keyDown(Key.CTRL)";
            String ScriptFolder = Path.Combine(Utilities.GetFromConfigFile("TestLocation"), (Utilities.GetFromConfigFile("ScriptName") + ".sikuli"));
            String ScriptFile = Path.Combine(ScriptFolder, (Utilities.GetFromConfigFile("ScriptName") + ".py"));
            Utilities.WriteToFile(ScriptFile, Content);
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            string Content = "keyUp(Key.CTRL)";
            String ScriptFolder = Path.Combine(Utilities.GetFromConfigFile("TestLocation"), (Utilities.GetFromConfigFile("ScriptName") + ".sikuli"));
            String ScriptFile = Path.Combine(ScriptFolder, (Utilities.GetFromConfigFile("ScriptName") + ".py"));
            Utilities.WriteToFile(ScriptFile, Content);
            return Counter;
        }
    }
    class LControlKey
    {
        public static int onKeyDown(int Counter)
        {
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            return Counter;
        }
    }
    class RControlKey
    {
        public static int onKeyDown(int Counter)
        {
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            return Counter;
        }
    }
}
