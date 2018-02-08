using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class FoodFactory
    {
        int X;
        int Y;

        char Char;

        public Point Food { get; private set; }

        Random rnd = new Random();

        public FoodFactory(int x, int y, char simbol)
        {
            X = x;
            Y = y;
            Char = simbol;
        }

        public void CreateFood()
        {
            Food = new Point(rnd.Next(2, X - 2), rnd.Next(2, Y - 2), Char);
            Food.Drow();
        }

    }
}
