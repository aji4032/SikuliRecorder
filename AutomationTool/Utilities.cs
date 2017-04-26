using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace AutomationTool
{
    class point
    {
        public int x, y;
        public point()
        {
            x = 0;
            y = 0;
        }
        public point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Boolean Equals(point Object)
        {
            if ((this.x == Object.x) && (this.y == Object.y))
                return true;
            return false;
        }
    }
    class region
    {
        public point Location;
        public int width, height;
        public region(int width, int height)
        {
            Location = new point();
            this.width = width;
            this.height = height;
        }
        public region(point Location, int width, int height)
        {
            this.Location = Location;
            this.width = width;
            this.height = height;
        }
        public region(int x, int y, int width, int height)
        {
            Location = new point(x, y);
            this.width = width;
            this.height = height;
        }
    }
    class Utilities
    {
        public static void CaptureScreen(region window, string file)
        {
            System.Threading.Thread.Sleep(3000);
            try
                {
                Rectangle s_rect = new Rectangle(window.Location.x, window.Location.y, window.width, window.height);

                using (Bitmap bmp = new Bitmap(s_rect.Width, s_rect.Height))
                {
                    using (Graphics gScreen = Graphics.FromImage(bmp))
                        gScreen.CopyFromScreen(s_rect.Location, Point.Empty, s_rect.Size);
                    bmp.Save(file, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
            catch (Exception) { /*TODO: Any exception handling.*/ }
        }
        public static point CurrentMousePosition()
        {
            point MouseLocation = new point();
            MouseLocation.x = Cursor.Position.X;
            MouseLocation.y = Cursor.Position.Y;
            return MouseLocation;
        }
        public static void WriteToFile(string filename, string Content)
        {
            using (System.IO.StreamWriter file =
               new System.IO.StreamWriter(filename, true))
            {
                file.WriteLine(Content);
            }
        }
    }
    public static class KeyHook
    {
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);

        public delegate void KeyEventDelegate(Keys key);

        private static Thread _pollingThread;
        private static volatile Dictionary<Keys, bool> _keysStates = new Dictionary<Keys, bool>();

        internal static void Initialize()
        {

            if (_pollingThread != null && _pollingThread.IsAlive)
            {
                return;
            }
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
            {
                _keysStates[key] = false;
            }


            _pollingThread = new Thread(PollKeys) { IsBackground = true, Name = "KeyThread" };
            _pollingThread.Start();
        }


        private static void PollKeys()
        {
            while (true)
            {
                Thread.Sleep(10);
                foreach (Keys key in Enum.GetValues(typeof(Keys)))
                {
                    if (((GetAsyncKeyState(key) & (1 << 15)) != 0))
                    {
                        if (_keysStates[key]) continue;
                        OnKeyDown?.Invoke(key);
                        _keysStates[key] = true;
                    }
                    else
                    {
                        if (!_keysStates[key]) continue;
                        OnKeyUp?.Invoke(key);
                        _keysStates[key] = false;
                    }
                }


            }
        }

        public static event KeyEventDelegate OnKeyDown;
        public static event KeyEventDelegate OnKeyUp;
    }

}
