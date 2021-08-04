using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSnake.GameObjects
{
    public abstract class Food:Point
    {
        public Food(Wall wall, char foodSymbol, int points):base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            this.foodSumbol = foodSymbol;
            this.FoodPoints = points;
            random = new Random();

        }
        private char foodSumbol;
        private Random random;
        private Wall wall;
        public int FoodPoints { get; private set; }

        public void SetRandomPosition(Queue<Point> snakeElements) 
        {
            LeftX = random.Next(2,wall.LeftX-2);
            TopY = random.Next(2,wall.TopY - 2);
            bool isPointOfTheSnake = snakeElements.Any(x => x.LeftX == LeftX && x.TopY == TopY);

            while (isPointOfTheSnake)
            {
                LeftX = random.Next(2, wall.LeftX - 2);
                TopY = random.Next(2, wall.TopY - 2);
                isPointOfTheSnake = snakeElements.Any(x => x.LeftX == LeftX && x.TopY == TopY);
            }

            Console.BackgroundColor = ConsoleColor.Red;
            Draw(foodSumbol);
            Console.BackgroundColor = ConsoleColor.White;
        }

        public bool IsFoodPoint(Point snake) 
        {
            return snake.TopY == TopY && snake.LeftX == LeftX;
        }
    }
}
