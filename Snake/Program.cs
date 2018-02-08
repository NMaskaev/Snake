using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Snake
{
    class Program
    {
        public static int X { get; } = 80;
        public static int Y { get; } = 26;


        static Timer time;
        static Wall Walls;
        static FoodFactory foodFactory;
        static Snake snake;


        static void Main(string[] args)
        {
            setConfig();

            Walls = new Wall(X, Y, '#');
            foodFactory = new FoodFactory(X, Y, '@');
            foodFactory.CreateFood();
            snake = new Snake(X / 2, Y / 2, 3);
            time = new Timer(loop, null, 0, 200);

            MoveSnakeMove();
        }

        private static void MoveSnakeMove()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    snake.Rotation(key.Key);
                }
            }
        }

        private static void Pause()
        {
            //Console.Write("Press any key to continue ...");
            Console.ReadKey();
        }

        private static void setConfig()
        {
            Console.SetWindowSize(X + 1, Y + 1);
            Console.SetBufferSize(X + 1, Y + 1);
            Console.CursorVisible = false;
        }

        static void loop(object obj)
        {
            if (Walls.IsHit(snake.GetHead()) || snake.IsHint(snake.GetHead()) )
            {
                time.Change(0, Timeout.Infinite);
            }
            else if ( snake.Eat(foodFactory.Food) )
            {
                foodFactory.CreateFood();
            }
            else
            {
                snake.Move();
            }
        }
    }
}
