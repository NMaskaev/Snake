using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Wall
    {
        private char Char;
        private List<Point> wall = new List<Point>();

        public Wall(int x, int y, char simbol)
        {
            Char = simbol;

            DrowHorizontal(x, 0);
            DrowHorizontal(x, y);

            DrowVertical(0, y);
            DrowVertical(x, y);
        }

        public bool IsHit (Point p)
        {
            foreach (Point WallPoint in wall)
            {
                if (WallPoint == p)
                {
                    return true;
                }
            }

            return false;
        }


        private void DrowHorizontal(int x, int y)
        {
            for (int i = 0; i < x; i++)
            {
                Point p = new Point(i, y, Char);
                p.Drow();
                wall.Add(p);
            }
        }

        private void DrowVertical(int x, int y)
        {
            for (int i = 0; i < y; i++)
            {
                Point p = new Point(x, i, Char);
                p.Drow();
                wall.Add(p);
            }
        }
    }
}
