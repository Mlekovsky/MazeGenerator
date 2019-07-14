using System;
using System.Collections.Generic;
using System.Text;

namespace MazeGenerator
{
    public class Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Point(Point point)
        {
            this.X = point.X;
            this.Y = point.Y;
        }
    }
}
