using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils = BrowserBasedSolution.Utils;


namespace BrowserBasedSolution
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
        static Point keyDownPt;
        public static int onKeyDown(int Counter)
        {
            keyDownPt = Utils.CurrentMousePosition();
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            Point keyUpPt = Utils.CurrentMousePosition();
            TakeScreenshot(++Counter);
            String Content = null;
            if (!isLocationWithinBounds(keyUpPt))
            {
                if (keyUpPt.Equals(keyDownPt))
                    Content = "click(Location(" + keyUpPt.X + "," + keyUpPt.Y + "))";
                else
                    Content = "dragDrop(Location(" + keyDownPt.X + "," + keyDownPt.Y + "),Location(" + keyUpPt.X + "," + keyUpPt.Y + "))";
            }
            else
            {
                String fileToCrop = Path.Combine(Program.ScriptFolder, (Counter - 2 + ".png "));
                Task.Run(() => StartCropProcess(fileToCrop, keyDownPt));
                if (keyUpPt.Equals(keyDownPt))
                {
                    Content = "#click(Location(" + keyUpPt.X + "," + keyUpPt.Y + "))";
                    Content += "\nclick(Pattern(\"" + (Counter - 1) + ".png\").similar(0.9).targetOffset(0, 0))";
                }
                else
                {
                    Content = "#dragDrop(Location(" + keyDownPt.X + "," + keyDownPt.Y + "),Location(" + keyUpPt.X + "," + keyUpPt.Y + "))";
                    Content += "\ndragDrop(Pattern(\"" + (Counter - 1) + ".png\".similar(0.9).targetOffset(0, 0), ";
                    Content += "Pattern(\"" + (Counter - 1) + ".png\".similar(0.9).targetOffset(" + (keyUpPt.X - keyDownPt.X) + ", " + (keyUpPt.Y - keyDownPt.Y) + "))";
                }
            }
            Content += "\nwait(Pattern(\"" + Counter + ".png\").similar(0.9), 30)";
            Utils.WriteToFile(Program.ScriptFile, Content);
            Console.WriteLine("\a");
            Counter++;
            return Counter;
        }
        private static void TakeScreenshot(int Counter)
        {
            String filename = Path.Combine(Program.ScriptFolder, (Counter + ".png"));
            Utils.CaptureScreen(Program.ScreenSize, filename);
        }
        private static void StartCropProcess(String fileToCrop, Point centerLoc)
        {
            String filename = "java";
            String args = @"-jar ChopperTheCropper.jar " + fileToCrop + " " + + centerLoc.X + " " + centerLoc.Y;
            Process clientProcess = new Process();
            clientProcess.StartInfo.FileName = filename;
            clientProcess.StartInfo.Arguments = args;
            clientProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                
            clientProcess.Start();
            clientProcess.WaitForExit();
            if (clientProcess.ExitCode != 0)
            {
                String warning = "[warning [" + clientProcess.ExitCode + "]] Failed to Crop:" + fileToCrop + " at (" + centerLoc.X + ", " + centerLoc.Y + ")";
                Utils.WriteToFile(Program.LogFile, warning);
            }
            clientProcess.Close();
        }
        private static bool isLocationWithinBounds(Point keyUpLocation)
        {
            if (keyUpLocation.X > Program.UserBoundary.X &&
                keyUpLocation.Y > Program.UserBoundary.Y &&
                keyUpLocation.X < (Program.UserBoundary.X + Program.UserBoundary.Width) &&
                keyUpLocation.Y < (Program.UserBoundary.Y + Program.UserBoundary.Height))
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
            string filename = Path.Combine(Program.ScriptFolder, (Counter + ".png"));
            Utils.CaptureScreen(Program.ScreenSize, filename);
            Console.WriteLine("\a");
            Counter++;
            return Counter;
        }
    }
}
