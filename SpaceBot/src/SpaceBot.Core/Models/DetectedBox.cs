namespace SpaceBot.Core.Models
{
    public sealed class DetectedBox
    {
        public DetectedBox(string id, TargetType type, Point2 position, double confidence)
        {
            Id = id;
            Type = type;
            Position = position;
            Confidence = confidence;
        }

        public string Id { get; }
        public TargetType Type { get; }
        public Point2 Position { get; }
        public double Confidence { get; }
    }
}
