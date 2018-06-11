namespace Game
{
    public class SnakeBody : IGameObject
    {
        public Position Position { get; set; }
        public char Apearance { get; } = 'x';
    }
}