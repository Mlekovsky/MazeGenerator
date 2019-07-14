using System;

namespace MazeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Generator generator = new Generator(10, 10);
            generator.Start();
            Console.WriteLine("Debug:");
        }
    }
}
