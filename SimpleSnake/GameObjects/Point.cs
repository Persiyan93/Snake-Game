using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Point
    { 
        public Point(int x,int y)
        {
            this.Xaxis = x;
            this.Yaxis = y;
        }
        public int Xaxis { get; set; }
        public int Yaxis { get; set; }
        public void Draw(char symbol)
        {
            Console.SetCursorPosition(this.Xaxis, this.Yaxis);
            Console.WriteLine(symbol);
            Console.CursorVisible = false;
        }
        public void Draw(int x,int y,char symbol)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }
    }
}
