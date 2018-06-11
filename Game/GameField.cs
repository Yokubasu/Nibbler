using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public class GameField
    {
        private Snake snake;

        public GameField(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Grid = new IGameObject[rows, columns];
        }

        public int Rows { get; }
        public int Columns { get; }
        public IGameObject[,] Grid { get; set; }
        public Food Food { get; set; }

        public void AddSnake(Snake snake)
        {
            this.snake = snake;
            GenerateGameObjects(snake.SnakeBodyParts);
        }

        public void AddFood()
        {
            var random = new Random();
            var x = random.Next(1, Columns - 2);
            var y = random.Next(1, Rows - 2);


            Food = new Food(new Position
            {
                X = x,
                Y = y
            });

            if (snake != null && snake.Position.Equals(Food.Position))
            {
                AddFood();
            }
        }

        public void Update()
        {
            GenerateGrid();
            GenerateGameObjects(snake.SnakeBodyParts);
            GenerateFood();
        }

        private void GenerateFood()
        {
            if (Food != null)
            {
                Grid[Food.Position.Y, Food.Position.X] = Food;
            }
        }

        private void GenerateGameObjects(IEnumerable<IGameObject> gameObjects)
        {
            if (gameObjects != null)
            {
                foreach (var gameObject in gameObjects)
                {
                    Grid[gameObject.Position.Y, gameObject.Position.X] = gameObject;
                }
            }
        }

        public void GenerateGrid()
        {
            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Columns; j++)
                {
                    if (i == 0 || i == Rows - 1 || j == 0 || j == Columns - 1)
                    {
                        var wall = new Wall
                        {
                            Position = new Position
                            {
                                X = j,
                                Y = i
                            }
                        };
                        Grid[i, j] = wall;
                    }
                    else
                    {
                        Grid[i, j] = new Floor();
                    }
                }
            }
        }

        public override string ToString()
        {
            if (Grid != null)
            {
                var gridBuilder = new StringBuilder();
                for (var i = 0; i < Rows; i++)
                {
                    for (var j = 0; j < Columns; j++)
                    {
                        gridBuilder.Append(Grid[i, j].Apearance);
                    }

                    gridBuilder.Append("\n");
                }

                return gridBuilder.ToString();
            }

            return "";
        }
    }
}