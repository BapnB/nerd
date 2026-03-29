using System.Collections.Generic;
using System.Linq;
using SpaceBot.Core.Models;

namespace SpaceBot.Core.Services
{
    public sealed class NearestTargetSelector : ITargetSelector
    {
        public DetectedBox SelectNearest(ShipState ship, IReadOnlyCollection<DetectedBox> boxes)
        {
            if (ship == null || boxes == null || boxes.Count == 0)
            {
                return null;
            }

            // Важно: без приоритета Bonus/Event. Только минимальная дистанция.
            return boxes
                .OrderBy(b => b.Position.DistanceTo(ship.Position))
                .ThenByDescending(b => b.Confidence)
                .FirstOrDefault();
        }
    }
}
