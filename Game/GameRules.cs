namespace Game
{
    public class GameRules
    {
        private readonly GameField gameField;
        private readonly Snake snake;

        public GameRules(GameField gameField, Snake snake)
        {
            this.gameField = gameField;
            this.snake = snake;
        }

        public bool LoseFlag { get; private set; }
        public int Score { get; private set; }

        public void Reset()
        {
            LoseFlag = false;
            Score = 0;
        }

        public void CheckCollision()
        {
            // todo: fix collision
            //foreach (var bodyPart in snake.SnakeBodyParts)
            //{
            //    if (!bodyPart.Equals(snake.Head))
            //    {
            //        if (snake.Position.Equals(bodyPart.Position))
            //        {
            //            LoseFlag = true;
            //            break;
            //        }
            //    }
            //}
            //
            //if (snake.Position.Y == 0 || snake.Position.Y == this.gameField.Rows - 1 || snake.Position.X == 0 ||
            //    snake.Position.X == this.gameField.Columns - 1)
            //{
            //    LoseFlag = true;
            //}


            if (snake.Position.Equals(gameField.Food.Position))
            {
                snake.Grow();
                gameField.AddFood();
                Score++;
            }
        }
    }
}