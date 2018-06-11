namespace Game
{
    public class Food : IGameObject
    {
        public Position Position { get; }
        public char Apearance { get; } = 'o';

        public Food(Position position)
        {
            Position = position;
        }
    }
}