using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private const char WALLSYMBOL = '\u25A0';
        public Wall(int x, int y) : base(x, y)
        {
            
        }
        private void SetHorizontalLine(int maxY)
        {
            for (int leftX = 1; leftX < Xaxis; leftX++)
            {
                this.Draw(leftX, maxY, WALLSYMBOL);
            }
        }
        private void SetVerticalLine(int maxX)
        {
            for (int topY = 1; topY < this.Yaxis; topY++)
            {
                this.Draw(maxX, topY, WALLSYMBOL);
            }
        }
       public void IntializeWallBorder()
        {
            //Set UpperBorder
            SetHorizontalLine(1);
            //Set Bottom Border
            SetHorizontalLine(this.Yaxis);
            //Set Left Border
            SetVerticalLine(1);

            //Set Vertival Border
            SetVerticalLine(this.Xaxis);
        }
    }
}
