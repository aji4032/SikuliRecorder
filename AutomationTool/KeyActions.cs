﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils = AutomationTool.Utils;


namespace AutomationTool
{
    //miscellanous keys
    //ENTER, TAB, ESC, BACKSPACE, DELETE, INSERT, SPACE

    //function keys
    //F1, F2, F3, F4, F5, F6, F7, F8, F9, F10, F11, F12, F13, F14, F15

    //navigation keys
    //HOME, END, LEFT, RIGHT, DOWN, UP, PAGE_DOWN, PAGE_UP

    //special keys
    //PRINTSCREEN, PAUSE, CAPS_LOCK, SCROLL_LOCK, NUM_LOCK

    //numpad keys
    //NUM0, NUM1, NUM2, NUM3, NUM4, NUM5, NUM6, NUM7, NUM8, NUM9, SEPARATOR, ADD, MINUS, MULTIPLY, DIVIDE

    //modifier keys
    //ALT, CMD, CTRL, META, SHIFT, WIN
    class Menu
    {
        public static int onKeyDown(int Counter)
        {
            string Content = "keyDown(Key.ALT)";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            string Content = "keyUp(Key.ALT)";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }
    }
    class LMenu
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
    class RMenu
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

    class ControlKey
    {
        public static int onKeyDown(int Counter)
        {
            string Content = "keyDown(Key.CTRL)";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            string Content = "keyUp(Key.CTRL)";
            Utils.WriteToFile(Program.ScriptFile, Content);
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

    class ShiftKey
    {
        public static int onKeyDown(int Counter)
        {
            string Content = "keyDown(Key.SHIFT)";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            string Content = "keyUp(Key.SHIFT)";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }
    }
    class LShiftKey
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
    class RShiftKey
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

    class LWin
    {
        public static int onKeyDown(int Counter)
        {
            string Content = "keyDown(Key.WIN)";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            string Content = "keyUp(Key.WIN)";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }
    }

    class F2
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

    //Others:
    //Mouse:
    class LButton
    {
        static point keyDownLocation;
        public static int onKeyDown(int Counter)
        {
            keyDownLocation = Utils.CurrentMousePosition();
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            point keyUpLocation = Utils.CurrentMousePosition();
            TakeScreenshot(Counter);
            string Content = null;
            if (!isLocationWithinBounds(keyUpLocation))
            {
                if (keyUpLocation.Equals(keyDownLocation))
                    Content = "click(Location(" + Utils.CurrentMousePosition().x + "," + Utils.CurrentMousePosition().y + "))";
                else
                    Content = "dragDrop(Location(" + keyDownLocation.x + "," + keyDownLocation.y + "),Location(" + keyUpLocation.x + "," + keyUpLocation.y + "))";
            }
            else
            {
                Task.Run(() => StartCropProcess(Counter, keyDownLocation));
                if (keyUpLocation.Equals(keyDownLocation))
                {
                    Content = "#click(Location(" + Utils.CurrentMousePosition().x + "," + Utils.CurrentMousePosition().y + "))";
                    Content += "\nclick(Pattern(\"" + (Counter - 1) + ".png\").similar(0.9).targetOffset(0, 0))";
                }
                else
                {
                    Content = "#dragDrop(Location(" + keyDownLocation.x + "," + keyDownLocation.y + "),Location(" + keyUpLocation.x + "," + keyUpLocation.y + "))";
                    Content += "\ndragDrop(Pattern(\"" + (Counter - 1) + ".png\".similar(0.9).targetOffset(0, 0), ";
                    Content += "Pattern(\"" + (Counter - 1) + ".png\".similar(0.9).targetOffset(" + (keyUpLocation.x - keyDownLocation.x) + ", " + (keyUpLocation.y - keyDownLocation.y) + "))";
                }
            }
            Content += "\nwait(Pattern(\"" + Counter + ".png\").similar(0.9), 30)";
            Utils.WriteToFile(Program.ScriptFile, Content);
            keyDownLocation = null;
            Counter++;
            Console.WriteLine("\a");
            return Counter;
        }

        private static void TakeScreenshot(int Counter)
        {
            region screen = new region(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            string filename = Path.Combine(Program.ScriptFolder, (Counter + ".png"));
            Utils.CaptureScreen(screen, filename);
        }

        private static void StartCropProcess(int counter, point keyDownLocation)
        {
            Process clientProcess = new Process();
            clientProcess.StartInfo.FileName = "java";
            string args = @"-jar ChopperTheCropper.jar " + Utils.GetFromConfigFile("TestLocation") + "\\" + Utils.GetFromConfigFile("ScriptName") + ".sikuli\\" + (counter - 1) + ".png " + keyDownLocation.x + " " + keyDownLocation.y;
            clientProcess.StartInfo.Arguments = args;
            clientProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            clientProcess.Start();
            //For Future development:
            //int code = clientProcess.ExitCode != 0)
        }

        private static bool isLocationWithinBounds(point keyUpLocation)
        {
            int x = Convert.ToInt32(Utils.GetFromConfigFile("BoundX")),
                y = Convert.ToInt32(Utils.GetFromConfigFile("BoundY")),
                w = Convert.ToInt32(Utils.GetFromConfigFile("BoundW")),
                h = Convert.ToInt32(Utils.GetFromConfigFile("BoundH"));

            if(keyUpLocation.x > x && keyUpLocation.x < (x + w) && keyUpLocation.y > y && keyUpLocation.y < (y + h))
                return true;
            else
                return false;
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
            Counter--;
            Rectangle resolution = Screen.PrimaryScreen.Bounds;
            region screen = new region(resolution.X, resolution.Y, resolution.Width, resolution.Height);
            string filename = Path.Combine(Program.ScriptFolder, (Counter + ".png"));
            Utils.CaptureScreen(screen, filename);
            Console.WriteLine("\a");
            Counter++;
            return Counter;
        }
    }

}
