using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace Phase2
{
    class Program
    {
        static void Main(string[] args)
        {
            Utilities.CropImage();
        }

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
        class Utilities
        {
            public static void CropImage()
            {
                region ToCrop = new region();
                ToCrop.Location.x = Convert.ToInt32(GetFromConfigFile("RegionX"));
                ToCrop.Location.y = Convert.ToInt32(GetFromConfigFile("RegionY"));
                ToCrop.width = Convert.ToInt32(GetFromConfigFile("RegionW"));
                ToCrop.height = Convert.ToInt32(GetFromConfigFile("RegionH"));

                DirectoryInfo d = new DirectoryInfo(
                                      Path.Combine(GetFromConfigFile("TestLocation"),
                                                    GetFromConfigFile("ScriptName") + ".sikuli"));

                FileInfo[] Files = d.GetFiles("*.png");
                foreach (FileInfo file in Files)
                {
                    Rectangle cropRect = new Rectangle(ToCrop.Location.x, ToCrop.Location.y, ToCrop.width, ToCrop.height);
                    Bitmap src = Image.FromFile(Path.Combine(d.ToString(), file.ToString())) as Bitmap;
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
        public static void CropImage()
        {
            region ToCrop = new region();
            ToCrop.Location.x = Convert.ToInt32(Utilities.GetFromConfigFile("RegionX"));
            ToCrop.Location.y = Convert.ToInt32(Utilities.GetFromConfigFile("RegionY"));
            ToCrop.width = Convert.ToInt32(Utilities.GetFromConfigFile("RegionW"));
            ToCrop.height = Convert.ToInt32(Utilities.GetFromConfigFile("RegionH"));

            DirectoryInfo d = new DirectoryInfo(
                                  Path.Combine(Utilities.GetFromConfigFile("TestLocation"),
                                                Utilities.GetFromConfigFile("ScriptName") + ".sikuli"));

            FileInfo[] Files = d.GetFiles("*.png");
            foreach (FileInfo file in Files)
            {
                Rectangle cropRect = new Rectangle(ToCrop.Location.x, ToCrop.Location.y, ToCrop.width, ToCrop.height);
                Bitmap src = Image.FromFile(Path.Combine(d.ToString(), file.ToString())) as Bitmap;
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
    }
}
