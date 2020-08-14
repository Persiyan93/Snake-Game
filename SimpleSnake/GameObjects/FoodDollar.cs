using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class FoodDollar : Food
    {
        private const char FOODSYMBOL = '$';
        private const int POINTS = 1;
        public FoodDollar(Wall wall) : base(wall, FOODSYMBOL, POINTS)
        {
        }
    }
}
