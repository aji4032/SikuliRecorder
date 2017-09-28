using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;
using System.Runtime.InteropServices;
using System.Configuration;

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
        public region()
        {
            Location = new point();
            this.width = 0;
            this.height = 0;
        }
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
    class Utils
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

        public static void CropImage()
        {
            region ToCrop = new region();
            ToCrop.Location.x = Convert.ToInt32(GetFromConfigFile("RegionX"));
            ToCrop.Location.y = Convert.ToInt32(GetFromConfigFile("RegionY"));
            ToCrop.width = Convert.ToInt32(GetFromConfigFile("RegionW"));
            ToCrop.height = Convert.ToInt32(GetFromConfigFile("RegionH"));

            DirectoryInfo d = new DirectoryInfo(
                                  Path.Combine( GetFromConfigFile("TestLocation"),
                                                GetFromConfigFile("ScriptName")+".sikuli"));

            FileInfo[] Files = d.GetFiles("*.png");
            foreach (FileInfo file in Files)
            {
                Rectangle cropRect = new Rectangle(ToCrop.Location.x, ToCrop.Location.y, ToCrop.width, ToCrop.height);
                Bitmap src = Image.FromFile(Path.Combine(d.ToString(),file.ToString())) as Bitmap;
                Bitmap target = new Bitmap(cropRect.Width, cropRect.Height);

                using (Graphics g = Graphics.FromImage(target))
                {
                    g.DrawImage(src, new Rectangle(0, 0, target.Width, target.Height),
                                     cropRect,
                                     GraphicsUnit.Pixel);
                    target.Save(Path.Combine(d.ToString(), "Cropped_" + file.ToString()), System.Drawing.Imaging.ImageFormat.Png);
                }
            }
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

        public static string GetFromConfigFile(string Key)
        {
            return ConfigurationManager.AppSettings[Key] != null ? ConfigurationManager.AppSettings[Key].ToString() : null;
        }
        public static void StoreToConfigFile(string Key, string Value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[Key] == null)
                config.AppSettings.Settings.Add(Key, Value);
            else
                config.AppSettings.Settings[Key].Value = Value;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
        }
    }
    public static class KeyHook
    {
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);
        public delegate void KeyEventDelegate(Keys key);
        private static Thread _pollingThread;
        public static event KeyEventDelegate OnKeyDown;
        public static event KeyEventDelegate OnKeyUp;
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
    }
}
