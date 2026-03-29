using System.Collections.Generic;
using SpaceBot.Core.Models;
using SpaceBot.Core.StateMachine;

namespace SpaceBot.Core.Services
{
    public sealed class BotOrchestrator
    {
        private readonly ITargetSelector _selector;
        private readonly BotContext _context = new BotContext();

        public BotOrchestrator(ITargetSelector selector)
        {
            _selector = selector;
        }

        public BotContext Context => _context;

        public void Tick(ShipState ship, IReadOnlyCollection<DetectedBox> boxes, bool targetCollected)
        {
            switch (_context.State)
            {
                case BotState.Idle:
                    _context.State = BotState.SearchTarget;
                    break;

                case BotState.SearchTarget:
                    _context.CurrentTarget = _selector.SelectNearest(ship, boxes);
                    _context.State = _context.CurrentTarget == null ? BotState.SearchTarget : BotState.LockTarget;
                    break;

                case BotState.LockTarget:
                    _context.State = BotState.MoveToTarget;
                    break;

                case BotState.MoveToTarget:
                    // Не ретаргетимся в этом состоянии: летим к зафиксированной цели.
                    _context.State = BotState.WaitCollect;
                    break;

                case BotState.WaitCollect:
                    if (targetCollected)
                    {
                        _context.CurrentTarget = null;
                        _context.State = BotState.SearchTarget;
                    }
                    break;

                case BotState.Recover:
                    _context.CurrentTarget = null;
                    _context.State = BotState.SearchTarget;
                    break;
            }
        }
    }
}
