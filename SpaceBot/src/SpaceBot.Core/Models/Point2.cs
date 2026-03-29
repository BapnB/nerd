namespace SpaceBot.Core.Models
{
    public readonly struct Point2
    {
        public Point2(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; }
        public double Y { get; }

        public double DistanceTo(Point2 other)
        {
            var dx = X - other.X;
            var dy = Y - other.Y;
            return System.Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
