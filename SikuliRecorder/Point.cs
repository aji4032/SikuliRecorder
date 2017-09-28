using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SikuliRecorder
{
    class Point
    {
        public int x, y;
        public Point()
        {
            x = 0;
            y = 0;
        }
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public bool Equals(Point Object)
        {
            if ((this.x == Object.x) && (this.y == Object.y))
                return true;
            return false;
        }
    }
}
