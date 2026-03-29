namespace SpaceBot.Core.StateMachine
{
    public enum BotState
    {
        Idle,
        SearchTarget,
        LockTarget,
        MoveToTarget,
        WaitCollect,
        Recover
    }
}
