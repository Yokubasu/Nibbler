namespace Game
{
    public class Wall : IGameObject
    {
        public Position Position { get; set; }
        public char Apearance { get; } = '#';
    }
}