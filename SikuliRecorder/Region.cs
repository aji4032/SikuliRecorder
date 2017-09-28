using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SikuliRecorder
{
    class Region
    {
        public Point Location;
        public int width, height;
        public Region()
        {
            Location = new Point();
            this.width = 0;
            this.height = 0;
        }
        public Region(int width, int height)
        {
            Location = new Point();
            this.width = width;
            this.height = height;
        }
        public Region(Point Location, int width, int height)
        {
            this.Location = Location;
            this.width = width;
            this.height = height;
        }
        public Region(int x, int y, int width, int height)
        {
            Location = new Point(x, y);
            this.width = width;
            this.height = height;
        }
    }
}
