using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Timers;

namespace SimpleSnake.Core
{
    public class Engine
    {
        private Snake snake;
        private Wall wall;
        private Point[] directionPointts;
        private Point direction;
        Food food;



        public Engine(Wall wall, Snake snake, Food food)
        {
            this.wall = wall;
            this.snake = snake;
            this.directionPointts = new Point[4];
            this.CreatDirections();
            this.food = food;

        }
        public void Run()
        {
            wall.IntializeWallBorder();
            food.SetRandomPosition(snake.Snakeelements);

            GetNexDirection();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    GetNexDirection();
                }
                Thread.SpinWait(1000000);
                snake.Moove(direction);
                if (food.IsFoodPoint(snake.Snakeelements))
                {
                    food.SetRandomPosition(snake.Snakeelements);
                }
            }
        }
        public void CreatDirections()
        {

            this.directionPointts[0] = new Point(-1, 0);
            this.directionPointts[1] = new Point(1, 0);
            this.directionPointts[2] = new Point(0, -1);
            this.directionPointts[3] = new Point(0, 1);


        }
        public void GetNexDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();
            if (userInput.Key == ConsoleKey.LeftArrow)
            {
                direction = directionPointts[0];
            }
            else if (userInput.Key == ConsoleKey.RightArrow)
            {
                direction = directionPointts[1];
            }
            else if (userInput.Key == ConsoleKey.UpArrow)
            {
                direction = directionPointts[2];

            }
            else if (userInput.Key == ConsoleKey.DownArrow)
            {
                direction = directionPointts[3];
            }
            Console.CursorVisible = false;
        }
    }
}




