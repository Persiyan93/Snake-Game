using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public abstract class Food : Point
    {
        
        protected Food(Wall wall,char foodSymbol,int points) : base(wall.Xaxis,wall.Yaxis)
        {
            this.wall = wall;
            this.foodSymbol = foodSymbol;
             random = new Random();

        }
        private Random random;
        private Wall wall;
        protected  char foodSymbol;
        public int Foodposition { get; private set; }
        public void SetRandomPosition(Queue<Point> snakeElements)
        {

            this.Xaxis = random.Next(1, wall.Xaxis);
            this.Yaxis = random.Next(1, wall.Yaxis);
            bool IspointOfSnake = snakeElements.Any(x => x.Xaxis == this.Xaxis && x.Yaxis == this.Yaxis);
            if (IspointOfSnake)
            {
                SetRandomPosition(snakeElements);
            }
            Console.BackgroundColor = ConsoleColor.Red;
            this.Draw(foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
           //Miss one Line
        }
        public bool IsFoodPoint(Queue<Point>snakeelements)
        {

            if (snakeelements.Any(x => x.Xaxis == this.Xaxis && x.Yaxis == this.Yaxis))
            {
                //Should to generate new food;
                return true;
            }
            return false;
        }
        
       
            
    }
}
