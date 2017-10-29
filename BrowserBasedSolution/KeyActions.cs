using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;


namespace BrowserBasedSolution
{
    //miscellanous keys
    //ENTER, TAB, ESC, BACKSPACE, DELETE, INSERT, SPACE
    class Return
    {
        public static int onKeyDown(int Counter)
        {
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            string Content = "type(Key.ENTER)";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }
    }
    class Tab
    {
        public static int onKeyDown(int Counter)
        {
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            string Content = "type(Key.TAB)";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }
    }
    class Escape
    {
        public static int onKeyDown(int Counter)
        {
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            string Content = "type(Key.ESC)";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }
    }
    class Back
    {
        public static int onKeyDown(int Counter)
        {
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            string Content = "type(Key.BACKSPACE)";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }
    }
    class Delete
    {
        public static int onKeyDown(int Counter)
        {
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            string Content = "type(Key.DELETE)";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }
    }
    class Insert
    {
        public static int onKeyDown(int Counter)
        {
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            string Content = "type(Key.INSERT)";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }
    }
    class Space
    {
        public static int onKeyDown(int Counter)
        {
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            string Content = "type(Key.SPACE)";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }
    }
    
    //function keys
    //F1, F2, F3, F4, F5, F6, F7, F8, F9, F10, F11, F12, F13, F14, F15
    class F1
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
    class F3
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
    class F4
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
    class F5
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
    class F6
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
    class F7
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
    class F8
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
    class F9
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
    class F10
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
    class F11
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
    class F12
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
    class F13
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
    class F14
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
    class F15
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

    //navigation keys
    //HOME, END, LEFT, RIGHT, DOWN, UP, PAGE_DOWN, PAGE_UP
    class Home
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
    class End
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
    class Left
    {
        public static int onKeyDown(int Counter)
        {
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            string Content = "type(Key.LEFT)";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }
    }
    class Right
    {
        public static int onKeyDown(int Counter)
        {
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            string Content = "type(Key.RIGHT)";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }
    }
    class Down
    {
        public static int onKeyDown(int Counter)
        {
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            string Content = "type(Key.DOWN)";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }
    }
    class Up
    {
        public static int onKeyDown(int Counter)
        {
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            string Content = "type(Key.UP)";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }
    }
    class PageUp
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

    //special keys
    //PRINTSCREEN, PAUSE, CAPS_LOCK, SCROLL_LOCK, NUM_LOCK
    class PrintScreen
    {
        public static int onKeyDown(int Counter)
        {
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            string filename = Path.Combine(Program.ScriptFolder, (Counter + ".png"));
            Utils.CaptureScreen(Program.ScreenSize, filename);
            Console.WriteLine("\a");
            Counter++;
            return Counter;
        }
    }

    //numpad keys
    //NUM0, NUM1, NUM2, NUM3, NUM4, NUM5, NUM6, NUM7, NUM8, NUM9, SEPARATOR, ADD, MINUS, MULTIPLY, DIVIDE
    class NumPad0
    {
        public static int onKeyDown(int Counter)
        {
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            string Content = "type(\"0\")";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }
    }
    class NumPad1
    {
        public static int onKeyDown(int Counter)
        {
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            string Content = "type(\"1\")";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }
    }
    class NumPad2
    {
        public static int onKeyDown(int Counter)
        {
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            string Content = "type(\"2\")";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }
    }
    class NumPad3
    {
        public static int onKeyDown(int Counter)
        {
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            string Content = "type(\"3\")";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }
    }
    class NumPad4
    {
        public static int onKeyDown(int Counter)
        {
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            string Content = "type(\"4\")";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }
    }
    class NumPad5
    {
        public static int onKeyDown(int Counter)
        {
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            string Content = "type(\"5\")";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }
    }
    class NumPad6
    {
        public static int onKeyDown(int Counter)
        {
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            string Content = "type(\"6\")";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }
    }
    class NumPad7
    {
        public static int onKeyDown(int Counter)
        {
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            string Content = "type(\"7\")";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }
    }
    class NumPad8
    {
        public static int onKeyDown(int Counter)
        {
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            string Content = "type(\"8\")";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }
    }
    class NumPad9
    {
        public static int onKeyDown(int Counter)
        {
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            string Content = "type(\"9\")";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }
    }
    class D0
    {
        public static int onKeyDown(int Counter)
        {
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            string Content = "type(\"0\")";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }
    }
    class D1
    {
        public static int onKeyDown(int Counter)
        {
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            string Content = "type(\"1\")";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }
    }
    class D2
    {
        public static int onKeyDown(int Counter)
        {
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            string Content = "type(\"2\")";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }
    }
    class D3
    {
        public static int onKeyDown(int Counter)
        {
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            string Content = "type(\"3\")";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }
    }
    class D4
    {
        public static int onKeyDown(int Counter)
        {
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            string Content = "type(\"4\")";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }
    }
    class D5
    {
        public static int onKeyDown(int Counter)
        {
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            string Content = "type(\"5\")";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }
    }
    class D6
    {
        public static int onKeyDown(int Counter)
        {
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            string Content = "type(\"6\")";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }
    }
    class D7
    {
        public static int onKeyDown(int Counter)
        {
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            string Content = "type(\"7\")";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }
    }
    class D8
    {
        public static int onKeyDown(int Counter)
        {
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            string Content = "type(\"8\")";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }
    }
    class D9
    {
        public static int onKeyDown(int Counter)
        {
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            string Content = "type(\"9\")";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }
    }

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
            String Content = null;
            String filename = Path.Combine(Program.ScriptFolder, (++Counter + ".png"));

            if (!isLocWithinBounds(keyUpPt))
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
            Thread.Sleep(3000);
            Utils.CaptureScreen(Program.ScreenSize, filename);
            Console.WriteLine("\a");
            Counter++;
            return Counter;
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
        private static bool isLocWithinBounds(Point keyUpLocation)
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
    class MButton
    {
        public static int onKeyDown(int Counter)
        {
            Point keyDownPt = Utils.CurrentMousePosition();
            String Content = "hover(Location(" + keyDownPt.X + "," + keyDownPt.Y + "))";
            Content += "\nmouseDown(Button.MIDDLE)";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }
        public static int onKeyUp(int Counter)
        {
            Point keyUpPt = Utils.CurrentMousePosition();
            String Content = "hover(Location(" + keyUpPt.X + "," + keyUpPt.Y + "))";
            Content += "\nmouseUp(Button.MIDDLE)";
            Utils.WriteToFile(Program.ScriptFile, Content);
            return Counter;
        }

    }
}
