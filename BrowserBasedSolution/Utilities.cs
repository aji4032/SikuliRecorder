using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;
using System.Runtime.InteropServices;
using System.Configuration;

namespace BrowserBasedSolution
{
    class Utils
    {
        public static void CaptureScreen(Rectangle Region, String file)
        {
            try
                {
                    using (Bitmap bmp = new Bitmap(Region.Width, Region.Height))
                    {
                        using (Graphics gScreen = Graphics.FromImage(bmp))
                            gScreen.CopyFromScreen(Region.Location, Point.Empty, Region.Size);
                        bmp.Save(file, System.Drawing.Imaging.ImageFormat.Png);
                    }
            }
            catch (Exception)
            {
                Utils.WriteToFile(Program.LogFile, "[error] Failed to capture screenshot!");
                Environment.Exit(0);
            }
        }
             
        public static Point CurrentMousePosition()
        {
            return Cursor.Position;
        }
        public static void WriteToFile(String filename, String Content)
        {
            using (System.IO.StreamWriter file =
               new System.IO.StreamWriter(filename, true))
            {
                file.WriteLine(Content);
            }
        }

        public static String GetFromConfigFile(String Key)
        {
            return ConfigurationManager.AppSettings[Key] != null ? ConfigurationManager.AppSettings[Key].ToString() : null;
        }
        public static void StoreToConfigFile(String Key, String Value)
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
