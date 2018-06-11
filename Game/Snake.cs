using System.Collections.Generic;

namespace Game
{
    public class Snake
    {
        public Snake(Position position)
        {
            Reset(position);
        }

        public Queue<SnakeBody> SnakeBodyParts { get; set; } = new Queue<SnakeBody>();
        public Position Position { get; private set; }
        public SnakeBody Head { get; private set; }
        public Direction Direction { get; set; } = Direction.Up;

        public void Reset(Position position)
        {
            Direction = Direction.Up;
            Position = position;
            SnakeBodyParts.Clear();
            Grow();
            Grow();
            Grow();
        }

        public void TurnLeft()
        {
            if (Direction == 0)
            {
                Direction = (Direction) 3;
            }
            else
            {
                Direction--;
            }
        }

        public void TurnRight()
        {
            if (Direction == (Direction) 3)
            {
                Direction = 0;
            }
            else
            {
                Direction++;
            }
        }

        public void Grow()
        {
            SnakeBodyParts.Enqueue(
                new SnakeBody
                {
                    Position = new Position
                    {
                        X = Position.X,
                        Y = Position.Y
                    }
                }
            );
            Head = SnakeBodyParts.Peek();
        }

        private void UpdatePosition()
        {
            SnakeBodyParts.Dequeue();
            Grow();
        }

        public void Move()
        {
            switch (Direction)
            {
                case Direction.Up:
                    Position.Y--;
                    break;
                case Direction.Down:
                    Position.Y++;
                    break;
                case Direction.Left:
                    Position.X--;
                    break;
                case Direction.Right:
                    Position.X++;
                    break;
            }

            UpdatePosition();
        }
    }
}