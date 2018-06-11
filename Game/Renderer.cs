using System;

namespace Game
{
    public class Renderer
    {
        private readonly GameField gameField;

        public Renderer(GameField gameField)
        {
            this.gameField = gameField;
        }

        public void Render()
        {
            gameField.Update();
            var grid = gameField.ToString();

            Console.Clear();
            Console.WriteLine(grid);
        }
    }
}