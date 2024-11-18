using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDrivenProject
{
    public class Compass
    {
        public Point Point;

        public Compass(Point point)
        {
            Point = point;
        }

        public Point Rotate(Point point, Direction dir)
        {
            int val = (int)point;
            if (dir == Direction.RIGHT)
            { 
                val++;
                if (val > 3) val = 0;
                return (Point)val;
            }
            val--;
            if (val < 0) val = 3;
            return (Point)val;
        }
    }
}
