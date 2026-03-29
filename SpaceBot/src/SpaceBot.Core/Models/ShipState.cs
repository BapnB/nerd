namespace SpaceBot.Core.Models
{
    public sealed class ShipState
    {
        public ShipState(Point2 position)
        {
            Position = position;
        }

        public Point2 Position { get; }
    }
}
