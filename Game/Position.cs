namespace Game
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;

            var position = (Position) obj;
            return X == position.X && Y == position.Y;
        }
    }
}