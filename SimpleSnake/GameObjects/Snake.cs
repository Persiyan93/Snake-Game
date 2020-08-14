using SimpleSnake.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private Queue<Point> snakeElement;
        private Food foods;
        private Wall wall;
        private int nextXPositonOfHead;
        private int nextYPositionOfHead;
        
        private const char SNAKESYMBOL = '\u25CF';

        public Snake(Wall wall,Food food)
        {
            this.wall = wall;
            this.snakeElement = new Queue<Point>();
            this.foods = food;
            this.CreateSnake();
        }
        
        public Queue<Point> Snakeelements => this.snakeElement;

        private void CreateSnake()
        {
            for (int topY = 2; topY < 6; topY++)
            {
                this.snakeElement.Enqueue(new Point(3, topY));
            }
        }
        private void GetNextPoint(Point direcction, Point snakeHead)
        {
            this.nextXPositonOfHead = direcction.Xaxis + snakeHead.Xaxis;
            this.nextYPositionOfHead = direcction.Yaxis + snakeHead.Yaxis;
        }
        private bool IsNextPointleavBorder()
        {
            return this.nextXPositonOfHead == 1 || this.nextXPositonOfHead == wall.Xaxis
                || this.nextYPositionOfHead == 1 || this.nextYPositionOfHead == wall.Yaxis;
        }
        private bool IsItPartFromSnake()
        {
            return snakeElement.Any(x => x.Xaxis == nextXPositonOfHead && x.Yaxis == nextYPositionOfHead);
        }
        public void Moove(Point direction)
        {

            Point snakeHead = null;
            snakeHead = snakeElement.Last();
            GetNextPoint(direction, snakeHead);
            if (IsItPartFromSnake())
            {
                throw new InvalidOperationException("Game Over");
            }
            if (IsNextPointleavBorder())
            {
                throw new InvalidOperationException("You can not leave borders");
            }
            Point newsnakeHead = new Point(nextXPositonOfHead, nextYPositionOfHead);
            snakeElement.Enqueue(newsnakeHead);
            if (!foods.IsFoodPoint(snakeElement))
            {
                snakeElement.Dequeue().Draw(' ');
            }
            foreach (var element in snakeElement)
            {
                element.Draw(SNAKESYMBOL);
            }




        }



    }
}
