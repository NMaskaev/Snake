using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    enum Direction
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }

    class Snake
    {
        // private data
        List<Point> snakeBody;
        Direction direction;
        int step = 1;
        Point tail;
        Point head;
        bool rotate;

        public Snake(int x, int y, int length)
        {
            direction = Direction.RIGHT;
            snakeBody = new List<Point>();
            for (int i = x - length; i < x; i++)
            {
                Point p = new Point(i, y, '*');
                p.Drow();
                snakeBody.Add(p);
            }
        }


        public Point GetHead() => snakeBody.Last();
        public void Move()
        {
            head = GetNextPoint();
            snakeBody.Add(head);
            tail = snakeBody.First();
            snakeBody.Remove(tail);
            tail.Clear();
            head.Drow();
            rotate = true;
        }

        Point GetNextPoint()
        {
            Point p = GetHead();
            switch (direction)
            {
                case Direction.LEFT:
                    p.X -= step;
                    break;
                case Direction.RIGHT:
                    p.X += step;
                    break;
                case Direction.UP:
                    p.Y -= step;
                    break;
                case Direction.DOWN:
                    p.Y += step;
                    break;
            }

            return p;
        }

        public void Rotation(ConsoleKey key)
        {
            if (rotate)
            {
                switch (direction)
                {
                    case Direction.LEFT:
                    case Direction.RIGHT:

                        if (key == ConsoleKey.DownArrow)
                            { direction = Direction.DOWN; }
                        else if (key == ConsoleKey.UpArrow)
                            { direction = Direction.UP; }

                        break;

                    case Direction.UP:
                    case Direction.DOWN:

                        if (key == ConsoleKey.LeftArrow)
                            { direction = Direction.LEFT; }
                        else if (key == ConsoleKey.RightArrow)
                            { direction = Direction.RIGHT; }

                        break;
                }
                rotate = false;
            }
        }

        public bool IsHint(Point p)
        {
            for (int i = snakeBody.Count - 2 ; i > 0 ; i--)
            {
                if (snakeBody[i] == p)
                {
                    return true;
                }
            }

            return false;
        }

        public bool Eat (Point p)
        {
            head = GetNextPoint();
            if (head == p)
            {
                snakeBody.Add(head);
                head.Drow();
                return true;
            }

            return false;
        }
    }
}
