namespace Game
{
    public class Floor : IGameObject
    {
        public Position Position { get; set; }
        public char Apearance { get; } = ' ';
    }
}