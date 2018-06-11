using System;
using System.Configuration;
using System.Threading;

namespace Game
{
    public class Game
    {
        private readonly GameField gameField;
        private readonly GameRules gameRules;
        private readonly Renderer renderer;
        private readonly Snake snake;
        private readonly int speed;
        private readonly Position startPosition;

        public Game()
        {
            var appSettings = ConfigurationManager.AppSettings;
            var rows = int.Parse(appSettings["rows"]);
            var columns = int.Parse(appSettings["columns"]);
            speed = int.Parse(appSettings["speed"]);

            startPosition = new Position
            {
                X = columns / 2,
                Y = rows / 2
            };

            gameField = new GameField(rows, columns);
            snake = new Snake(startPosition);
            gameRules = new GameRules(gameField, snake);
            gameField.AddSnake(snake);
            gameField.AddFood();
            renderer = new Renderer(gameField);
        }


        public void Run()
        {
            using (var timer = new Timer(TimerExpiredCallback, null, 0, speed))
            {
                while (!gameRules.LoseFlag)
                {
                    var pressedKey = Console.ReadKey().Key;
                    switch (pressedKey)
                    {
                        case ConsoleKey.RightArrow:
                            snake.TurnRight();
                            break;
                        case ConsoleKey.LeftArrow:
                            snake.TurnLeft();
                            break;
                    }
                }

                gameRules.Reset();
                snake.Reset(startPosition);
            }
        }

        private void TimerExpiredCallback(object obj)
        {
            snake.Move();
            renderer.Render();
            Console.WriteLine("Your score: {0}", gameRules.Score);
            gameRules.CheckCollision();
        }
    }
}