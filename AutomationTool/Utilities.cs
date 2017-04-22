using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Rectangle s_rect = new Rectangle(window.Location.x - (window.width/2), window.Location.y - (window.height/2), window.width, window.height);

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
    }
}
