using SpaceBot.Core.Models;

namespace SpaceBot.Core.StateMachine
{
    public sealed class BotContext
    {
        public BotState State { get; set; } = BotState.Idle;
        public DetectedBox CurrentTarget { get; set; }
    }
}
