using System.Collections.Generic;
using SpaceBot.Core.Models;

namespace SpaceBot.Core.Services
{
    public interface ITargetSelector
    {
        DetectedBox SelectNearest(ShipState ship, IReadOnlyCollection<DetectedBox> boxes);
    }
}
