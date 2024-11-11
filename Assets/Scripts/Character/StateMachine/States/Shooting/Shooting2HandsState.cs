public class Shooting2HandsState : MovementState
{
    public Shooting2HandsState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    public override void Enter()
    {
        base.Enter();

        CharacterView.StartShootin2Hands();
    }

    public override void Exit()
    {
        base.Exit();

        CharacterView.StopShooting2Hands();
    }
}
