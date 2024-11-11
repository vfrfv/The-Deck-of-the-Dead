public class Idling2Hands : MovementState
{
    public Idling2Hands(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    public override void Enter()
    {
        base.Enter();

        CharacterView.StartIdling2Hands();
    }

    public override void Exit()
    {
        base.Exit();

        CharacterView.StopIdling2Hands();
    }

    public override void Update()
    {
        base.Update();

        if (IsMoving())
            return;

        StateSwitcher.SwitchState<RunningDefaultState>();
    }
}
