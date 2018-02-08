using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Char { get; set; }

        public void Drow()
        {
            DrowPoint(Char);
        }

        public void Clear()
        {
            DrowPoint(' ');
        }

        void DrowPoint(char Simbol)
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Simbol);
        }

        public Point(int x, int y, char simbol)
        {
            X = x;
            Y = y;
            Char = simbol;
        }

        public static bool operator == (Point a, Point b) => (a.X == b.X && a.Y == b.Y);

        public static bool operator !=(Point a, Point b) => (a.X != b.X || a.Y != b.Y);
    }
}
