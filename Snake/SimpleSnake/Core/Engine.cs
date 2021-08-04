using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using System;
using System.Threading;

namespace SimpleSnake.Core
{
    public class Engine
    {
        public Engine(Wall wall, Snake snake)
        {
            pointsOfDirection = new Point[4];
            this.wall = wall;
            this.snake = snake;
            this.sleepTime = 100;
            //direction = new Direction();
        }
        private Point[] pointsOfDirection;
        private Wall wall;
        private Direction direction;
        private Snake snake;
        private double sleepTime;

        public void Run() 
        {
            this.CreateDirections();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    GetNextdirection();
                }

                bool isMoving = snake.IsMoving(pointsOfDirection[(int)direction]);

                if (!isMoving)
                {
                    AskUserForRestart();
                }

                sleepTime -= 0.01;

                Thread.Sleep((int)sleepTime);
            }
        }

        private void AskUserForRestart()
        {
            int leftX = wall.LeftX+1;
            int topY = 3;

            Console.SetCursorPosition(leftX, topY);
            Console.WriteLine("Would you like to continue? y/n");

            string input = Console.ReadLine();

            if (input == "y")
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                StopGame();
            }
        }

        private void CreateDirections() 
        {
            pointsOfDirection[0] = new Point(1,0);
            pointsOfDirection[1] = new Point(-1,0);
            pointsOfDirection[2] = new Point(0,1);
            pointsOfDirection[3] = new Point(0,-1);
        }
        private void GetNextdirection() 
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            if (userInput.Key == ConsoleKey.LeftArrow)
            {
                if (direction != Direction.Right)
                {
                    direction = Direction.Left;
                }
            }
            else if (userInput.Key == ConsoleKey.RightArrow)
            {
                if (direction != Direction.Left)
                {
                    direction = Direction.Right;
                }
            }
            else if (userInput.Key == ConsoleKey.UpArrow)
            {
                if (direction != Direction.Down)
                {
                    direction = Direction.Up;
                }
            }
            else if (userInput.Key == ConsoleKey.DownArrow)
            {
                if (direction != Direction.Up)
                {
                    direction = Direction.Down;
                }
            }

            Console.CursorVisible = false;
        }
        private void StopGame() 
        {
            Console.SetCursorPosition(20, 10);
            Console.WriteLine("Game over!");
            Environment.Exit(0);
        }
    }
}
