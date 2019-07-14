using System;
using System.Collections.Generic;
using System.Text;

namespace MazeGenerator
{
    public class Field
    {
        public bool Visited { get; set; }
        public Point point { get; set; }

        public string text { get; set; }

        public bool topWall { get; set; }
        public bool leftWall { get; set; }
        public bool rightWall { get; set; }
        public bool bottomWall { get; set; }


        public Field(Point point, string text)
        {
            this.point = point;
            this.text = text;
        }
        public void Visit()
        {
            this.Visited = true;
        }
        public bool CheckIfVisited()
        {
            return this.Visited;
        }
        public int getDistanceBetweenTwoFields(Field field)
        {
            return (Math.Abs(this.point.X - field.point.X) + Math.Abs(this.point.Y - field.point.Y));
        }
    }
}
