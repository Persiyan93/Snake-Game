namespace SimpleSnake
{
    using SimpleSnake.Core;
    using SimpleSnake.GameObjects;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();
            Wall wall = new Wall(150, 40);
            Food food = new FoodDollar(wall);
            Snake snake = new Snake(wall,food);
            Engine engine = new Engine(wall, snake,food);
            engine.Run();
            
        }
    }
}
